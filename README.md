# 🎮 Xbox Classic - Multi-Directory XISO Converter Pro

![.NET 10.0](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)
![Platform](https://img.shields.io/badge/Platform-Windows-blue?logo=windows)
![License](https://img.shields.io/badge/License-MIT-green)

A powerful, modern **Windows Forms application (.NET 10)** designed for managing and converting original Xbox (Xbox Classic) games into standard XISO format images and vice-versa. 

---

## 🇵🇱 Opis Projektu (Polish)

**Xbox Classic - Multi-Directory XISO Converter Pro** to intuicyjne narzędzie okienkowe dla systemu Windows pozwalające na hurtowe konwertowanie folderów z grami Xbox Classic do formatu obrazów `.iso` (XISO) oraz wypakowywanie obrazów `.iso` / `.xiso` do katalogów z plikami gry.

Aplikacja posiada wbudowany **parser plików `default.xbe`**, który automatycznie odczytuje identyfikator gry (`TitleId`), pełną nazwę gry (`TitleName`) oraz kod regionu (`NTSC-U`, `PAL`, `NTSC-J`, `Region-Free`).

### ✨ Kluczowe Funkcje

- 🔄 **Dwukierunkowe przetwarzanie wsadowe**:
  - Konwersja wielu folderów z grami -> Obrazy `.iso` (XISO)
  - Ekstrakcja wielu obrazów `.iso` -> Strukura folderów gry
- 🔍 **Automatyczne parsowanie metadanych XBE**:
  - Odczyt binarnego nagłówka `XBE1` oraz certyfikatu gry.
  - Wyciąganie `TitleId`, oryginalnego `TitleName` w Unicode oraz flag bitowych `Region`.
- 🏷️ **Dynamiczne szablony nazw**:
  - Możliwość zdefiniowania wzorca dla plików wyjściowych z użyciem tagów `{TitleId}`, `{TitleName}`, `{Region}` (np. `{TitleId} - {TitleName}.iso`).
- 📁 **Wsparcie dla Drag & Drop oraz Skanowania**:
  - Przeciągnij i upuść pliki/foldery bezpośrednio do aplikacji.
  - Skanuj całe katalogi nadrzędne ze wszystkimi Twoimi grami za jednym kliknięciem.
- ⚡ **Stabilność i Wydajność**:
  - Bezpieczne asynchroniczne wykonywanie operacji w tle (`Task.Run`).
  - Wykorzystanie sprawdzonego silnika `extract-xiso.exe`.

---

## 🇬🇧 Project Description (English)

**Xbox Classic - Multi-Directory XISO Converter Pro** is a modern Windows utility built with .NET 10.0 WinForms that streamlines creating XISO image files from original Xbox game folders and extracting existing XISO images into directory structures.

Features a built-in **`default.xbe` binary parser** that automatically extracts game Title ID, Unicode game title, and region capabilities.

---

## ⚙️ Wymagania / Requirements

1. **System operacyjny / OS**: Windows 10 / 11 (64-bit).
2. **Środowisko / Runtime**: [.NET 10.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/10.0) (lub wersja zapoznawcza SDK).
3. **Silnik zewnętrzny / External Engine**: `extract-xiso.exe` (można umieścić w folderze aplikacji lub wskazać w interfejsie).

---

## 🚀 Jak Uruchomić i skompilować / How to Build

### Kompilacja (Build)
```bash
git clone https://github.com/kuba7528/Xbox-Classic-ISO-Converter.git
cd Xbox-Classic-ISO-Converter
dotnet build -c Release
```

### Publikacja wydania (Publish Standalone/Framework-dependent)
```bash
dotnet publish -c Release -o ./publish
```

---

## 📜 Licencja / License

Distributed under the MIT License. See `LICENSE` for more information.
