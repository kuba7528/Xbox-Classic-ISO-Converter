using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XboxIsoConverter
{
    public class FolderQueueItem
    {
        public string TitleId { get; set; } = "00000000";
        public string TitleName { get; set; } = "Unknown";
        public string Region { get; set; } = "0x00000000";
        public string SourcePath { get; set; } = string.Empty;

        public string DisplayName => $"[{TitleId}] {TitleName} ({Region}) --> {SourcePath}";
    }

    public class IsoQueueItem
    {
        public string IsoPath { get; set; } = string.Empty;
        public string IsoName => Path.GetFileNameWithoutExtension(IsoPath);

        public string DisplayName => $"{Path.GetFileName(IsoPath)} --> {IsoPath}";
    }

    public static class XbeParser
    {
        public static FolderQueueItem ParseFolder(string folderPath)
        {
            var item = new FolderQueueItem 
            { 
                SourcePath = folderPath,
                TitleName = Path.GetFileName(folderPath)
            };

            string xbePath = Path.Combine(folderPath, "default.xbe");
            if (!File.Exists(xbePath))
            {
                var found = Directory.GetFiles(folderPath, "default.xbe", SearchOption.AllDirectories);
                if (found.Length > 0) xbePath = found[0];
                else return item;
            }

            try
            {
                using var fs = new FileStream(xbePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var reader = new BinaryReader(fs);

                byte[] magic = reader.ReadBytes(4);
                if (Encoding.ASCII.GetString(magic) != "XBE1") return item;

                fs.Seek(0x0104, SeekOrigin.Begin);
                uint baseAddr = reader.ReadUInt32();
                uint certAddr = reader.ReadUInt32();

                if (certAddr < baseAddr) return item;

                long certOffset = certAddr - baseAddr;
                fs.Seek(certOffset + 8, SeekOrigin.Begin);

                uint rawTitleId = reader.ReadUInt32();
                item.TitleId = rawTitleId.ToString("X8");

                byte[] nameBytes = reader.ReadBytes(80);
                string rawName = Encoding.Unicode.GetString(nameBytes);
                int nullIdx = rawName.IndexOf('\0');
                string name = (nullIdx >= 0 ? rawName.Substring(0, nullIdx) : rawName).Trim();

                if (!string.IsNullOrWhiteSpace(name))
                    item.TitleName = name;

                fs.Seek(certOffset + 168, SeekOrigin.Begin);
                uint rawRegion = reader.ReadUInt32();
                item.Region = ParseRegion(rawRegion);
            }
            catch
            {
                // W przypadku wyjątku zwróć wygenerowany nagłówek z domyślnymi wartościami
            }

            return item;
        }

        public static string ParseRegion(uint rawRegion)
        {
            if (rawRegion == 0x80000000 || rawRegion == 0xFFFFFFFF || (rawRegion & 0x00000007) == 0x00000007)
                return "Region-Free";

            var regions = new List<string>();
            if ((rawRegion & 0x00000001) != 0) regions.Add("NTSC-U");
            if ((rawRegion & 0x00000002) != 0) regions.Add("NTSC-J");
            if ((rawRegion & 0x00000004) != 0) regions.Add("PAL");

            if (regions.Count > 0)
                return string.Join("/", regions);

            return $"0x{rawRegion:X8}";
        }
    }
}

