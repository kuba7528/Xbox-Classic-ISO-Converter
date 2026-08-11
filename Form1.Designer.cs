namespace XboxIsoConverter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpFolders = new System.Windows.Forms.GroupBox();
            this.lstFolders = new System.Windows.Forms.ListBox();
            this.btnAddFolders = new System.Windows.Forms.Button();
            this.btnAddParentFolder = new System.Windows.Forms.Button();
            this.btnRemoveFolder = new System.Windows.Forms.Button();
            this.btnClearFolders = new System.Windows.Forms.Button();
            
            this.grpIsos = new System.Windows.Forms.GroupBox();
            this.lstIsos = new System.Windows.Forms.ListBox();
            this.btnAddIsos = new System.Windows.Forms.Button();
            this.btnRemoveIso = new System.Windows.Forms.Button();
            this.btnClearIsos = new System.Windows.Forms.Button();

            this.grpNaming = new System.Windows.Forms.GroupBox();
            this.lblOutIso = new System.Windows.Forms.Label();
            this.txtOutIsoDir = new System.Windows.Forms.TextBox();
            this.btnSelectOutIso = new System.Windows.Forms.Button();
            this.lblIsoPattern = new System.Windows.Forms.Label();
            this.txtIsoPattern = new System.Windows.Forms.TextBox();

            this.lblOutExtracted = new System.Windows.Forms.Label();
            this.txtOutExtractedDir = new System.Windows.Forms.TextBox();
            this.btnSelectOutExtracted = new System.Windows.Forms.Button();
            this.lblFolderPattern = new System.Windows.Forms.Label();
            this.txtFolderPattern = new System.Windows.Forms.TextBox();

            this.lblEngine = new System.Windows.Forms.Label();
            this.txtEnginePath = new System.Windows.Forms.TextBox();
            this.btnSelectEngine = new System.Windows.Forms.Button();

            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();

            this.grpFolders.SuspendLayout();
            this.grpIsos.SuspendLayout();
            this.grpNaming.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpFolders
            // 
            this.grpFolders.Controls.Add(this.lstFolders);
            this.grpFolders.Controls.Add(this.btnAddFolders);
            this.grpFolders.Controls.Add(this.btnAddParentFolder);
            this.grpFolders.Controls.Add(this.btnRemoveFolder);
            this.grpFolders.Controls.Add(this.btnClearFolders);
            this.grpFolders.Location = new System.Drawing.Point(12, 12);
            this.grpFolders.Name = "grpFolders";
            this.grpFolders.Size = new System.Drawing.Size(430, 240);
            this.grpFolders.TabIndex = 0;
            this.grpFolders.TabStop = false;
            this.grpFolders.Text = "1. Foldery z Grami (Do Stworzenia ISO)";
            // 
            // lstFolders
            // 
            this.lstFolders.AllowDrop = true;
            this.lstFolders.FormattingEnabled = true;
            this.lstFolders.ItemHeight = 15;
            this.lstFolders.Location = new System.Drawing.Point(10, 22);
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFolders.Size = new System.Drawing.Size(280, 204);
            this.lstFolders.TabIndex = 0;
            this.lstFolders.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstFolders_DragDrop);
            this.lstFolders.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDragEnter);
            // 
            // btnAddFolders
            // 
            this.btnAddFolders.Location = new System.Drawing.Point(300, 22);
            this.btnAddFolders.Name = "btnAddFolders";
            this.btnAddFolders.Size = new System.Drawing.Size(120, 28);
            this.btnAddFolders.TabIndex = 1;
            this.btnAddFolders.Text = "+ Wybierz Folder";
            this.btnAddFolders.Click += new System.EventHandler(this.BtnAddFolders_Click);
            // 
            // btnAddParentFolder
            // 
            this.btnAddParentFolder.Location = new System.Drawing.Point(300, 56);
            this.btnAddParentFolder.Name = "btnAddParentFolder";
            this.btnAddParentFolder.Size = new System.Drawing.Size(120, 28);
            this.btnAddParentFolder.TabIndex = 2;
            this.btnAddParentFolder.Text = "+ Skanuj Katalog";
            this.btnAddParentFolder.Click += new System.EventHandler(this.BtnAddParentFolder_Click);
            // 
            // btnRemoveFolder
            // 
            this.btnRemoveFolder.Location = new System.Drawing.Point(300, 90);
            this.btnRemoveFolder.Name = "btnRemoveFolder";
            this.btnRemoveFolder.Size = new System.Drawing.Size(120, 28);
            this.btnRemoveFolder.TabIndex = 3;
            this.btnRemoveFolder.Text = "Usuń Zaznaczone";
            this.btnRemoveFolder.Click += new System.EventHandler(this.BtnRemoveFolder_Click);
            // 
            // btnClearFolders
            // 
            this.btnClearFolders.Location = new System.Drawing.Point(300, 124);
            this.btnClearFolders.Name = "btnClearFolders";
            this.btnClearFolders.Size = new System.Drawing.Size(120, 28);
            this.btnClearFolders.TabIndex = 4;
            this.btnClearFolders.Text = "Wyczyść Listę";
            this.btnClearFolders.Click += new System.EventHandler(this.BtnClearFolders_Click);

            // 
            // grpIsos
            // 
            this.grpIsos.Controls.Add(this.lstIsos);
            this.grpIsos.Controls.Add(this.btnAddIsos);
            this.grpIsos.Controls.Add(this.btnRemoveIso);
            this.grpIsos.Controls.Add(this.btnClearIsos);
            this.grpIsos.Location = new System.Drawing.Point(455, 12);
            this.grpIsos.Name = "grpIsos";
            this.grpIsos.Size = new System.Drawing.Size(430, 240);
            this.grpIsos.TabIndex = 1;
            this.grpIsos.TabStop = false;
            this.grpIsos.Text = "2. Pliki ISO (Do Wypakowania do Folderu)";
            // 
            // lstIsos
            // 
            this.lstIsos.AllowDrop = true;
            this.lstIsos.FormattingEnabled = true;
            this.lstIsos.ItemHeight = 15;
            this.lstIsos.Location = new System.Drawing.Point(10, 22);
            this.lstIsos.Name = "lstIsos";
            this.lstIsos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstIsos.Size = new System.Drawing.Size(280, 204);
            this.lstIsos.TabIndex = 0;
            this.lstIsos.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstIsos_DragDrop);
            this.lstIsos.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDragEnter);
            // 
            // btnAddIsos
            // 
            this.btnAddIsos.Location = new System.Drawing.Point(300, 22);
            this.btnAddIsos.Name = "btnAddIsos";
            this.btnAddIsos.Size = new System.Drawing.Size(120, 28);
            this.btnAddIsos.TabIndex = 1;
            this.btnAddIsos.Text = "+ Dodaj Pliki ISO";
            this.btnAddIsos.Click += new System.EventHandler(this.BtnAddIsos_Click);
            // 
            // btnRemoveIso
            // 
            this.btnRemoveIso.Location = new System.Drawing.Point(300, 56);
            this.btnRemoveIso.Name = "btnRemoveIso";
            this.btnRemoveIso.Size = new System.Drawing.Size(120, 28);
            this.btnRemoveIso.TabIndex = 2;
            this.btnRemoveIso.Text = "Usuń Zaznaczone";
            this.btnRemoveIso.Click += new System.EventHandler(this.BtnRemoveIso_Click);
            // 
            // btnClearIsos
            // 
            this.btnClearIsos.Location = new System.Drawing.Point(300, 90);
            this.btnClearIsos.Name = "btnClearIsos";
            this.btnClearIsos.Size = new System.Drawing.Size(120, 28);
            this.btnClearIsos.TabIndex = 3;
            this.btnClearIsos.Text = "Wyczyść Listę";
            this.btnClearIsos.Click += new System.EventHandler(this.BtnClearIsos_Click);

            // 
            // grpNaming
            // 
            this.grpNaming.Controls.Add(this.lblOutIso);
            this.grpNaming.Controls.Add(this.txtOutIsoDir);
            this.grpNaming.Controls.Add(this.btnSelectOutIso);
            this.grpNaming.Controls.Add(this.lblIsoPattern);
            this.grpNaming.Controls.Add(this.txtIsoPattern);
            this.grpNaming.Controls.Add(this.lblOutExtracted);
            this.grpNaming.Controls.Add(this.txtOutExtractedDir);
            this.grpNaming.Controls.Add(this.btnSelectOutExtracted);
            this.grpNaming.Controls.Add(this.lblFolderPattern);
            this.grpNaming.Controls.Add(this.txtFolderPattern);
            this.grpNaming.Controls.Add(this.lblEngine);
            this.grpNaming.Controls.Add(this.txtEnginePath);
            this.grpNaming.Controls.Add(this.btnSelectEngine);
            this.grpNaming.Location = new System.Drawing.Point(12, 260);
            this.grpNaming.Name = "grpNaming";
            this.grpNaming.Size = new System.Drawing.Size(873, 150);
            this.grpNaming.TabIndex = 2;
            this.grpNaming.TabStop = false;
            this.grpNaming.Text = "Katalogi Docelowe, Szablony Nazw i Silnik";
            // 
            // lblOutIso
            // 
            this.lblOutIso.Location = new System.Drawing.Point(10, 24);
            this.lblOutIso.Name = "lblOutIso";
            this.lblOutIso.Size = new System.Drawing.Size(140, 23);
            this.lblOutIso.Text = "Katalog Wyjściowy ISO:";
            // 
            // txtOutIsoDir
            // 
            this.txtOutIsoDir.Location = new System.Drawing.Point(155, 21);
            this.txtOutIsoDir.Name = "txtOutIsoDir";
            this.txtOutIsoDir.ReadOnly = true;
            this.txtOutIsoDir.Size = new System.Drawing.Size(280, 23);
            this.txtOutIsoDir.TabIndex = 1;
            // 
            // btnSelectOutIso
            // 
            this.btnSelectOutIso.Location = new System.Drawing.Point(440, 20);
            this.btnSelectOutIso.Name = "btnSelectOutIso";
            this.btnSelectOutIso.Size = new System.Drawing.Size(85, 25);
            this.btnSelectOutIso.TabIndex = 2;
            this.btnSelectOutIso.Text = "Przeglądaj";
            this.btnSelectOutIso.Click += new System.EventHandler(this.BtnSelectOutIso_Click);
            // 
            // lblIsoPattern
            // 
            this.lblIsoPattern.Location = new System.Drawing.Point(535, 24);
            this.lblIsoPattern.Name = "lblIsoPattern";
            this.lblIsoPattern.Size = new System.Drawing.Size(80, 23);
            this.lblIsoPattern.Text = "Wzorzec ISO:";
            // 
            // txtIsoPattern
            // 
            this.txtIsoPattern.Location = new System.Drawing.Point(620, 21);
            this.txtIsoPattern.Name = "txtIsoPattern";
            this.txtIsoPattern.Size = new System.Drawing.Size(240, 23);
            this.txtIsoPattern.TabIndex = 3;
            this.txtIsoPattern.Text = "{TitleId} - {TitleName}.iso";

            // 
            // lblOutExtracted
            // 
            this.lblOutExtracted.Location = new System.Drawing.Point(10, 64);
            this.lblOutExtracted.Name = "lblOutExtracted";
            this.lblOutExtracted.Size = new System.Drawing.Size(140, 23);
            this.lblOutExtracted.Text = "Katalog Wypakowania:";
            // 
            // txtOutExtractedDir
            // 
            this.txtOutExtractedDir.Location = new System.Drawing.Point(155, 61);
            this.txtOutExtractedDir.Name = "txtOutExtractedDir";
            this.txtOutExtractedDir.ReadOnly = true;
            this.txtOutExtractedDir.Size = new System.Drawing.Size(280, 23);
            this.txtOutExtractedDir.TabIndex = 4;
            // 
            // btnSelectOutExtracted
            // 
            this.btnSelectOutExtracted.Location = new System.Drawing.Point(440, 60);
            this.btnSelectOutExtracted.Name = "btnSelectOutExtracted";
            this.btnSelectOutExtracted.Size = new System.Drawing.Size(85, 25);
            this.btnSelectOutExtracted.TabIndex = 5;
            this.btnSelectOutExtracted.Text = "Przeglądaj";
            this.btnSelectOutExtracted.Click += new System.EventHandler(this.BtnSelectOutExtracted_Click);
            // 
            // lblFolderPattern
            // 
            this.lblFolderPattern.Location = new System.Drawing.Point(535, 64);
            this.lblFolderPattern.Name = "lblFolderPattern";
            this.lblFolderPattern.Size = new System.Drawing.Size(80, 23);
            this.lblFolderPattern.Text = "Wzorzec Kat:";
            // 
            // txtFolderPattern
            // 
            this.txtFolderPattern.Location = new System.Drawing.Point(620, 61);
            this.txtFolderPattern.Name = "txtFolderPattern";
            this.txtFolderPattern.Size = new System.Drawing.Size(240, 23);
            this.txtFolderPattern.TabIndex = 6;
            this.txtFolderPattern.Text = "{TitleName} [{TitleId}]";

            // 
            // lblEngine
            // 
            this.lblEngine.Location = new System.Drawing.Point(10, 104);
            this.lblEngine.Name = "lblEngine";
            this.lblEngine.Size = new System.Drawing.Size(140, 23);
            this.lblEngine.Text = "Silnik extract-xiso:";
            // 
            // txtEnginePath
            // 
            this.txtEnginePath.Location = new System.Drawing.Point(155, 101);
            this.txtEnginePath.Name = "txtEnginePath";
            this.txtEnginePath.Size = new System.Drawing.Size(625, 23);
            this.txtEnginePath.TabIndex = 7;
            this.txtEnginePath.Text = "extract-xiso.exe";
            // 
            // btnSelectEngine
            // 
            this.btnSelectEngine.Location = new System.Drawing.Point(790, 100);
            this.btnSelectEngine.Name = "btnSelectEngine";
            this.btnSelectEngine.Size = new System.Drawing.Size(70, 25);
            this.btnSelectEngine.TabIndex = 8;
            this.btnSelectEngine.Text = "Szukaj";
            this.btnSelectEngine.Click += new System.EventHandler(this.BtnSelectEngine_Click);

            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 420);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(873, 25);
            this.progressBar.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 450);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(873, 20);
            this.lblStatus.Text = "Brak pozycji w kolejkach.";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(12, 475);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(873, 42);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Rozpocznij Konwersję Obu Kolejek";
            this.btnStart.UseVisualStyleBackColor = true;

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(898, 530);
            this.Controls.Add(this.grpFolders);
            this.Controls.Add(this.grpIsos);
            this.Controls.Add(this.grpNaming);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xbox Classic - Multi-Directory XISO Converter Pro";
            this.grpFolders.ResumeLayout(false);
            this.grpIsos.ResumeLayout(false);
            this.grpNaming.ResumeLayout(false);
            this.grpNaming.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpFolders;
        private System.Windows.Forms.ListBox lstFolders;
        private System.Windows.Forms.Button btnAddFolders;
        private System.Windows.Forms.Button btnAddParentFolder;
        private System.Windows.Forms.Button btnRemoveFolder;
        private System.Windows.Forms.Button btnClearFolders;

        private System.Windows.Forms.GroupBox grpIsos;
        private System.Windows.Forms.ListBox lstIsos;
        private System.Windows.Forms.Button btnAddIsos;
        private System.Windows.Forms.Button btnRemoveIso;
        private System.Windows.Forms.Button btnClearIsos;

        private System.Windows.Forms.GroupBox grpNaming;
        private System.Windows.Forms.Label lblOutIso;
        private System.Windows.Forms.TextBox txtOutIsoDir;
        private System.Windows.Forms.Button btnSelectOutIso;
        private System.Windows.Forms.Label lblIsoPattern;
        private System.Windows.Forms.TextBox txtIsoPattern;

        private System.Windows.Forms.Label lblOutExtracted;
        private System.Windows.Forms.TextBox txtOutExtractedDir;
        private System.Windows.Forms.Button btnSelectOutExtracted;
        private System.Windows.Forms.Label lblFolderPattern;
        private System.Windows.Forms.TextBox txtFolderPattern;

        private System.Windows.Forms.Label lblEngine;
        private System.Windows.Forms.TextBox txtEnginePath;
        private System.Windows.Forms.Button btnSelectEngine;

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart;
    }
}
