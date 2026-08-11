using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XboxIsoConverter
{
    public partial class Form1 : Form
    {
        private readonly List<FolderQueueItem> folderQueue = new List<FolderQueueItem>();
        private readonly List<IsoQueueItem> isoQueue = new List<IsoQueueItem>();

        public Form1()
        {
            InitializeComponent();
            txtOutIsoDir.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConvertedISOs");
            txtOutExtractedDir.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExtractedGames");
            txtEnginePath.Text = EnsureEngineExtracted();
            btnStart.Click += async (s, e) => await ProcessQueueAsync();
        }

        private string EnsureEngineExtracted()
        {
            string engineFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "extract-xiso.exe");
            if (File.Exists(engineFile))
            {
                return engineFile;
            }

            try
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                string resourceName = "XboxIsoConverter.extract-xiso.exe";

                using Stream? stream = assembly.GetManifestResourceStream(resourceName);
                if (stream != null)
                {
                    using FileStream fs = new FileStream(engineFile, FileMode.Create, FileAccess.Write);
                    stream.CopyTo(fs);
                    return engineFile;
                }
            }
            catch
            {
                // W przypadku błędu zwróć wyznaczoną ścieżkę domyślną
            }

            return engineFile;
        }

        #region Obsługa Listy Folderów
        private void BtnAddFolders_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Wybierz folder z grą (z plikiem default.xbe)";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    AddFolderToQueue(dlg.SelectedPath);
                }
            }
        }

        private void BtnAddParentFolder_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Wybierz katalog zawierający podfoldery z grami";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (var dir in Directory.GetDirectories(dlg.SelectedPath))
                    {
                        AddFolderToQueue(dir);
                    }
                }
            }
        }

        private bool AddFolderToQueue(string folderPath)
        {
            if (folderQueue.Any(f => f.SourcePath.Equals(folderPath, StringComparison.OrdinalIgnoreCase))) return false;

            var item = XbeParser.ParseFolder(folderPath);
            folderQueue.Add(item);
            lstFolders.Items.Add(item.DisplayName);
            UpdateStatusText();
            return true;
        }

        private void BtnRemoveFolder_Click(object sender, EventArgs e)
        {
            for (int i = lstFolders.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = lstFolders.SelectedIndices[i];
                folderQueue.RemoveAt(index);
                lstFolders.Items.RemoveAt(index);
            }
            UpdateStatusText();
        }

        private void BtnClearFolders_Click(object sender, EventArgs e)
        {
            folderQueue.Clear();
            lstFolders.Items.Clear();
            UpdateStatusText();
        }

        private void LstFolders_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                if (e.Data.GetData(DataFormats.FileDrop) is string[] paths)
                {
                    foreach (string path in paths)
                    {
                        if (Directory.Exists(path))
                        {
                            AddFolderToQueue(path);
                        }
                    }
                }
            }
        }
        #endregion

        #region Obsługa Listy Plików ISO
        private void BtnAddIsos_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Obrazy ISO Xbox (*.iso;*.xiso)|*.iso;*.xiso|Wszystkie pliki (*.*)|*.*";
                dlg.Multiselect = true;
                dlg.Title = "Wybierz obrazy ISO gier do wypakowania";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in dlg.FileNames)
                    {
                        AddIsoToQueue(file);
                    }
                }
            }
        }

        private bool AddIsoToQueue(string isoPath)
        {
            if (isoQueue.Any(i => i.IsoPath.Equals(isoPath, StringComparison.OrdinalIgnoreCase))) return false;

            var item = new IsoQueueItem { IsoPath = isoPath };
            isoQueue.Add(item);
            lstIsos.Items.Add(item.DisplayName);
            UpdateStatusText();
            return true;
        }

        private void BtnRemoveIso_Click(object sender, EventArgs e)
        {
            for (int i = lstIsos.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = lstIsos.SelectedIndices[i];
                isoQueue.RemoveAt(index);
                lstIsos.Items.RemoveAt(index);
            }
            UpdateStatusText();
        }

        private void BtnClearIsos_Click(object sender, EventArgs e)
        {
            isoQueue.Clear();
            lstIsos.Items.Clear();
            UpdateStatusText();
        }

        private void LstIsos_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                if (e.Data.GetData(DataFormats.FileDrop) is string[] paths)
                {
                    foreach (string path in paths)
                    {
                        if (File.Exists(path) && (path.EndsWith(".iso", StringComparison.OrdinalIgnoreCase) || path.EndsWith(".xiso", StringComparison.OrdinalIgnoreCase)))
                        {
                            AddIsoToQueue(path);
                        }
                    }
                }
            }
        }
        #endregion

        private void LstDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void BtnSelectOutIso_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtOutIsoDir.Text = dlg.SelectedPath;
                }
            }
        }

        private void BtnSelectOutExtracted_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtOutExtractedDir.Text = dlg.SelectedPath;
                }
            }
        }

        private void BtnSelectEngine_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Plik wykonywalny extract-xiso (*.exe)|*.exe|Wszystkie pliki (*.*)|*.*";
                dlg.Title = "Wskaz ścieżkę do silnika extract-xiso.exe";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtEnginePath.Text = dlg.FileName;
                }
            }
        }

        private void UpdateStatusText()
        {
            lblStatus.Text = $"Kolejka folderów: {folderQueue.Count} | Kolejka ISO: {isoQueue.Count}";
        }

        private string ApplyTemplateFolder(string template, FolderQueueItem item)
        {
            string result = template
                .Replace("{TitleId}", item.TitleId)
                .Replace("{TitleName}", item.TitleName)
                .Replace("{Region}", item.Region);

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                result = result.Replace(c, '_');
            }
            return result;
        }

        private string ApplyTemplateIso(string template, IsoQueueItem item)
        {
            string result = template
                .Replace("{TitleId}", "XISO")
                .Replace("{TitleName}", item.IsoName)
                .Replace("{Region}", "0x00000000");

            foreach (char c in Path.GetInvalidFileNameChars())
            {
                result = result.Replace(c, '_');
            }
            return result;
        }

        private async Task ProcessQueueAsync()
        {
            int totalItems = folderQueue.Count + isoQueue.Count;
            if (totalItems == 0)
            {
                MessageBox.Show("Obie kolejki są puste!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string enginePath = txtEnginePath.Text.Trim();
            if (!File.Exists(enginePath))
            {
                string localEngine = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "extract-xiso.exe");
                if (File.Exists(localEngine))
                {
                    enginePath = localEngine;
                    txtEnginePath.Text = localEngine;
                }
                else
                {
                    MessageBox.Show($"Brak silnika '{enginePath}'! Wskaz prawidłowy plik extract-xiso.exe.", "Błąd Krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Directory.CreateDirectory(txtOutIsoDir.Text);
            Directory.CreateDirectory(txtOutExtractedDir.Text);

            ToggleUI(false);
            progressBar.Value = 0;
            progressBar.Maximum = totalItems;

            int processed = 0;
            var errors = new List<string>();

            // 1. Konwersja Folder -> ISO (zapis do katalogu ISO)
            for (int i = 0; i < folderQueue.Count; i++)
            {
                var item = folderQueue[i];
                lblStatus.Text = $"[{processed + 1}/{totalItems}] Pakowanie do ISO: {item.TitleName}...";

                string isoName = ApplyTemplateFolder(txtIsoPattern.Text, item);
                if (!isoName.EndsWith(".iso", StringComparison.OrdinalIgnoreCase))
                {
                    isoName += ".iso";
                }

                try
                {
                    await Task.Run(() => ExecuteExtractXisoCreate(item.SourcePath, txtOutIsoDir.Text, isoName, enginePath));
                }
                catch (Exception ex)
                {
                    errors.Add($"Wydanie ISO dla '{item.TitleName}': {ex.Message}");
                }

                processed++;
                progressBar.Value = processed;
            }

            // 2. Konwersja ISO -> Folder (zapis do katalogu Wypakowane)
            for (int i = 0; i < isoQueue.Count; i++)
            {
                var item = isoQueue[i];
                lblStatus.Text = $"[{processed + 1}/{totalItems}] Wypakowywanie ISO: {item.IsoName}...";

                string folderName = ApplyTemplateIso(txtFolderPattern.Text, item);
                string targetFolderPath = Path.Combine(txtOutExtractedDir.Text, folderName);
                Directory.CreateDirectory(targetFolderPath);

                try
                {
                    await Task.Run(() => ExecuteExtractXisoExtract(item.IsoPath, targetFolderPath, enginePath));
                }
                catch (Exception ex)
                {
                    errors.Add($"Wypakowywanie ISO '{item.IsoName}': {ex.Message}");
                }

                processed++;
                progressBar.Value = processed;
            }

            if (errors.Count == 0)
            {
                lblStatus.Text = "Zakończono konwersję w osobnych katalogach!";
                MessageBox.Show("Wszystkie operacje zostały zakończone pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblStatus.Text = $"Zakończono z błędami ({errors.Count}/{totalItems}).";
                MessageBox.Show($"Przetwarzanie zakończone, ale wystąpiły błędy ({errors.Count}):\n\n" + string.Join("\n", errors.Take(5)), "Błędy Podczas Konwersji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ToggleUI(true);
        }

        private void ExecuteExtractXisoCreate(string sourceFolder, string outFolder, string isoFileName, string enginePath)
        {
            var psi = new ProcessStartInfo
            {
                FileName = Path.GetFullPath(enginePath),
                Arguments = $"-c \"{sourceFolder}\" \"{isoFileName}\"",
                WorkingDirectory = outFolder,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using var proc = Process.Start(psi);
            if (proc != null)
            {
                var stdoutTask = proc.StandardOutput.ReadToEndAsync();
                var stderrTask = proc.StandardError.ReadToEndAsync();
                proc.WaitForExit();

                string stdout = stdoutTask.Result;
                string stderr = stderrTask.Result;

                if (proc.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Silnik zakończył działanie z kodem {proc.ExitCode}:\n{stderr}\n{stdout}");
                }
            }
        }

        private void ExecuteExtractXisoExtract(string isoFilePath, string destinationDirectory, string enginePath)
        {
            var psi = new ProcessStartInfo
            {
                FileName = Path.GetFullPath(enginePath),
                Arguments = $"-x \"{isoFilePath}\" -d \"{destinationDirectory}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using var proc = Process.Start(psi);
            if (proc != null)
            {
                var stdoutTask = proc.StandardOutput.ReadToEndAsync();
                var stderrTask = proc.StandardError.ReadToEndAsync();
                proc.WaitForExit();

                string stdout = stdoutTask.Result;
                string stderr = stderrTask.Result;

                if (proc.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Silnik zakończył działanie z kodem {proc.ExitCode}:\n{stderr}\n{stdout}");
                }
            }
        }

        private void ToggleUI(bool enabled)
        {
            grpFolders.Enabled = enabled;
            grpIsos.Enabled = enabled;
            grpNaming.Enabled = enabled;
            btnStart.Enabled = enabled;
        }
    }
}

