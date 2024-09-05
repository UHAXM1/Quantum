<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        BTN_TestSaveUpdate = New Button()
        TMR_Main = New Timer(components)
        LV_VPNLogFile = New ListView()
        CH_VPNDateTime = New ColumnHeader()
        CH_VPNPort = New ColumnHeader()
        CH_VPNValid = New ColumnHeader()
        BTN_LogFile = New Button()
        TBE_Startup = New ToggleButtonEx()
        TBE_LogFile = New ToggleButtonEx()
        TXT_Host = New TextBox()
        TXT_Username = New TextBox()
        TXT_Password = New TextBox()
        STS_Main = New StatusStrip()
        TSSL_Main = New ToolStripStatusLabel()
        NI_Main = New NotifyIcon(components)
        TAB_Main = New TabControl()
        TP_Settings = New TabPage()
        TLP_SubMain = New TableLayoutPanel()
        GroupBox1 = New GroupBoxEx()
        TLP_MainSubQuantum = New TableLayoutPanel()
        GB_qBittorrentConfig = New GroupBoxEx()
        TLP_MainSubqBittorrent = New TableLayoutPanel()
        GB_Action = New GroupBoxEx()
        TP_Logs = New TabPage()
        TLP_Logs = New TableLayoutPanel()
        GB_ProtonLog = New GroupBoxEx()
        GB_QuantumLog = New GroupBoxEx()
        LV_QLog = New ListView()
        CH_QDateTime = New ColumnHeader()
        CH_QEvent = New ColumnHeader()
        TP_About = New TabPage()
        TLP_About = New TableLayoutPanel()
        PIC_About = New PictureBox()
        LNK_About = New LinkLabel()
        LNK_AboutProtonVPN = New LinkLabel()
        LBL_Author = New Label()
        CMS_Main = New ContextMenuStrip(components)
        TSMI_ShowHide = New ToolStripMenuItem()
        TSMI_UpdateNow = New ToolStripMenuItem()
        TSMI_Exit = New ToolStripMenuItem()
        TLP_Main = New TableLayoutPanel()
        PRG_Main = New ProgressBarEx()
        TT_Main = New ToolTip(components)
        STS_Main.SuspendLayout()
        TAB_Main.SuspendLayout()
        TP_Settings.SuspendLayout()
        TLP_SubMain.SuspendLayout()
        GroupBox1.SuspendLayout()
        TLP_MainSubQuantum.SuspendLayout()
        GB_qBittorrentConfig.SuspendLayout()
        TLP_MainSubqBittorrent.SuspendLayout()
        GB_Action.SuspendLayout()
        TP_Logs.SuspendLayout()
        TLP_Logs.SuspendLayout()
        GB_ProtonLog.SuspendLayout()
        GB_QuantumLog.SuspendLayout()
        TP_About.SuspendLayout()
        TLP_About.SuspendLayout()
        CType(PIC_About, ComponentModel.ISupportInitialize).BeginInit()
        CMS_Main.SuspendLayout()
        TLP_Main.SuspendLayout()
        SuspendLayout()
        ' 
        ' BTN_TestSaveUpdate
        ' 
        BTN_TestSaveUpdate.Dock = DockStyle.Fill
        BTN_TestSaveUpdate.Location = New Point(3, 19)
        BTN_TestSaveUpdate.Name = "BTN_TestSaveUpdate"
        BTN_TestSaveUpdate.Size = New Size(381, 26)
        BTN_TestSaveUpdate.TabIndex = 6
        BTN_TestSaveUpdate.Text = "Test/Save/Update"
        TT_Main.SetToolTip(BTN_TestSaveUpdate, "Test the qBittorrent settings above, if it connects the settings will be saved, this will also force a port update")
        BTN_TestSaveUpdate.UseVisualStyleBackColor = True
        ' 
        ' TMR_Main
        ' 
        TMR_Main.Interval = 1000
        ' 
        ' LV_VPNLogFile
        ' 
        LV_VPNLogFile.BorderStyle = BorderStyle.FixedSingle
        LV_VPNLogFile.Columns.AddRange(New ColumnHeader() {CH_VPNDateTime, CH_VPNPort, CH_VPNValid})
        LV_VPNLogFile.Dock = DockStyle.Fill
        LV_VPNLogFile.FullRowSelect = True
        LV_VPNLogFile.GridLines = True
        LV_VPNLogFile.HeaderStyle = ColumnHeaderStyle.Nonclickable
        LV_VPNLogFile.Location = New Point(3, 19)
        LV_VPNLogFile.MultiSelect = False
        LV_VPNLogFile.Name = "LV_VPNLogFile"
        LV_VPNLogFile.Size = New Size(387, 127)
        LV_VPNLogFile.TabIndex = 1
        TT_Main.SetToolTip(LV_VPNLogFile, "Double click to see the unparsed log entry")
        LV_VPNLogFile.UseCompatibleStateImageBehavior = False
        LV_VPNLogFile.View = View.Details
        ' 
        ' CH_VPNDateTime
        ' 
        CH_VPNDateTime.Text = "Date/Time"
        CH_VPNDateTime.Width = 100
        ' 
        ' CH_VPNPort
        ' 
        CH_VPNPort.Text = "Port Number"
        CH_VPNPort.Width = 100
        ' 
        ' CH_VPNValid
        ' 
        CH_VPNValid.Text = "Valid"
        ' 
        ' BTN_LogFile
        ' 
        BTN_LogFile.Dock = DockStyle.Fill
        BTN_LogFile.Enabled = False
        BTN_LogFile.Location = New Point(3, 67)
        BTN_LogFile.Name = "BTN_LogFile"
        BTN_LogFile.Size = New Size(375, 26)
        BTN_LogFile.TabIndex = 2
        BTN_LogFile.Text = "(...)"
        BTN_LogFile.UseVisualStyleBackColor = True
        ' 
        ' TBE_Startup
        ' 
        TBE_Startup.AutoSizeMode = AutoSizeMode.GrowAndShrink
        TBE_Startup.BackColor = Color.Transparent
        TBE_Startup.Checked = False
        TBE_Startup.Dock = DockStyle.Fill
        TBE_Startup.ForeColor = SystemColors.ControlText
        TBE_Startup.Location = New Point(4, 3)
        TBE_Startup.Margin = New Padding(4, 3, 4, 3)
        TBE_Startup.Name = "TBE_Startup"
        TBE_Startup.Size = New Size(373, 26)
        TBE_Startup.TabIndex = 0
        TBE_Startup.Text = "Launch Quantum at System Startup"
        TT_Main.SetToolTip(TBE_Startup, "Enable/Disable running Quantum when Windows starts")
        ' 
        ' TBE_LogFile
        ' 
        TBE_LogFile.AutoSizeMode = AutoSizeMode.GrowAndShrink
        TBE_LogFile.Checked = False
        TBE_LogFile.Dock = DockStyle.Fill
        TBE_LogFile.Location = New Point(4, 35)
        TBE_LogFile.Margin = New Padding(4, 3, 4, 3)
        TBE_LogFile.Name = "TBE_LogFile"
        TBE_LogFile.Size = New Size(373, 26)
        TBE_LogFile.TabIndex = 1
        TBE_LogFile.Text = "Locate ProtonVPN log files automaticlly"
        TT_Main.SetToolTip(TBE_LogFile, "Select automatic or manual log file selection")
        ' 
        ' TXT_Host
        ' 
        TXT_Host.Dock = DockStyle.Fill
        TXT_Host.Location = New Point(3, 3)
        TXT_Host.Name = "TXT_Host"
        TXT_Host.PlaceholderText = "Host (e.g. http://127.0.0.1:8080)"
        TXT_Host.Size = New Size(375, 23)
        TXT_Host.TabIndex = 3
        TXT_Host.TextAlign = HorizontalAlignment.Center
        TT_Main.SetToolTip(TXT_Host, "qBittorrent Host Address (e.g. http://127.0.0.1:8080)")
        ' 
        ' TXT_Username
        ' 
        TXT_Username.Dock = DockStyle.Fill
        TXT_Username.Location = New Point(3, 35)
        TXT_Username.Name = "TXT_Username"
        TXT_Username.PlaceholderText = "Username"
        TXT_Username.Size = New Size(375, 23)
        TXT_Username.TabIndex = 4
        TXT_Username.TextAlign = HorizontalAlignment.Center
        TT_Main.SetToolTip(TXT_Username, "qBittorrent Username")
        ' 
        ' TXT_Password
        ' 
        TXT_Password.Dock = DockStyle.Fill
        TXT_Password.Location = New Point(3, 67)
        TXT_Password.Name = "TXT_Password"
        TXT_Password.PlaceholderText = "Password"
        TXT_Password.Size = New Size(375, 23)
        TXT_Password.TabIndex = 5
        TXT_Password.TextAlign = HorizontalAlignment.Center
        TT_Main.SetToolTip(TXT_Password, "qBittorrent Password")
        TXT_Password.UseSystemPasswordChar = True
        ' 
        ' STS_Main
        ' 
        STS_Main.Items.AddRange(New ToolStripItem() {TSSL_Main})
        STS_Main.Location = New Point(0, 368)
        STS_Main.Name = "STS_Main"
        STS_Main.Size = New Size(413, 22)
        STS_Main.SizingGrip = False
        STS_Main.TabIndex = 4
        STS_Main.Text = "StatusStrip1"
        ' 
        ' TSSL_Main
        ' 
        TSSL_Main.AutoToolTip = True
        TSSL_Main.Name = "TSSL_Main"
        TSSL_Main.Size = New Size(398, 17)
        TSSL_Main.Spring = True
        ' 
        ' NI_Main
        ' 
        NI_Main.Icon = CType(resources.GetObject("NI_Main.Icon"), Icon)
        NI_Main.Text = "Quantum"
        NI_Main.Visible = True
        ' 
        ' TAB_Main
        ' 
        TAB_Main.Alignment = TabAlignment.Bottom
        TAB_Main.Controls.Add(TP_Settings)
        TAB_Main.Controls.Add(TP_Logs)
        TAB_Main.Controls.Add(TP_About)
        TAB_Main.Dock = DockStyle.Fill
        TAB_Main.Location = New Point(3, 3)
        TAB_Main.Name = "TAB_Main"
        TAB_Main.SelectedIndex = 0
        TAB_Main.Size = New Size(407, 339)
        TAB_Main.TabIndex = 7
        ' 
        ' TP_Settings
        ' 
        TP_Settings.Controls.Add(TLP_SubMain)
        TP_Settings.Location = New Point(4, 4)
        TP_Settings.Name = "TP_Settings"
        TP_Settings.Padding = New Padding(3)
        TP_Settings.Size = New Size(399, 311)
        TP_Settings.TabIndex = 0
        TP_Settings.Text = "Settings"
        TP_Settings.UseVisualStyleBackColor = True
        ' 
        ' TLP_SubMain
        ' 
        TLP_SubMain.ColumnCount = 1
        TLP_SubMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLP_SubMain.Controls.Add(GroupBox1, 0, 0)
        TLP_SubMain.Controls.Add(GB_qBittorrentConfig, 0, 1)
        TLP_SubMain.Controls.Add(GB_Action, 0, 2)
        TLP_SubMain.Dock = DockStyle.Fill
        TLP_SubMain.Location = New Point(3, 3)
        TLP_SubMain.Name = "TLP_SubMain"
        TLP_SubMain.RowCount = 4
        TLP_SubMain.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLP_SubMain.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLP_SubMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 54F))
        TLP_SubMain.RowStyles.Add(New RowStyle())
        TLP_SubMain.Size = New Size(393, 305)
        TLP_SubMain.TabIndex = 14
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TLP_MainSubQuantum)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Location = New Point(3, 3)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(387, 119)
        GroupBox1.TabIndex = 12
        GroupBox1.TabStop = False
        GroupBox1.Text = "Quantum Configuration"
        ' 
        ' TLP_MainSubQuantum
        ' 
        TLP_MainSubQuantum.ColumnCount = 1
        TLP_MainSubQuantum.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLP_MainSubQuantum.Controls.Add(TBE_Startup, 0, 0)
        TLP_MainSubQuantum.Controls.Add(TBE_LogFile, 0, 1)
        TLP_MainSubQuantum.Controls.Add(BTN_LogFile, 0, 2)
        TLP_MainSubQuantum.Dock = DockStyle.Fill
        TLP_MainSubQuantum.Location = New Point(3, 19)
        TLP_MainSubQuantum.Name = "TLP_MainSubQuantum"
        TLP_MainSubQuantum.RowCount = 4
        TLP_MainSubQuantum.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        TLP_MainSubQuantum.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        TLP_MainSubQuantum.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        TLP_MainSubQuantum.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TLP_MainSubQuantum.Size = New Size(381, 97)
        TLP_MainSubQuantum.TabIndex = 0
        ' 
        ' GB_qBittorrentConfig
        ' 
        GB_qBittorrentConfig.Controls.Add(TLP_MainSubqBittorrent)
        GB_qBittorrentConfig.Dock = DockStyle.Fill
        GB_qBittorrentConfig.Location = New Point(3, 128)
        GB_qBittorrentConfig.Name = "GB_qBittorrentConfig"
        GB_qBittorrentConfig.Size = New Size(387, 119)
        GB_qBittorrentConfig.TabIndex = 13
        GB_qBittorrentConfig.TabStop = False
        GB_qBittorrentConfig.Text = "qBittorrent WebUI Configuration"
        ' 
        ' TLP_MainSubqBittorrent
        ' 
        TLP_MainSubqBittorrent.ColumnCount = 1
        TLP_MainSubqBittorrent.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLP_MainSubqBittorrent.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TLP_MainSubqBittorrent.Controls.Add(TXT_Host, 0, 0)
        TLP_MainSubqBittorrent.Controls.Add(TXT_Username, 0, 1)
        TLP_MainSubqBittorrent.Controls.Add(TXT_Password, 0, 2)
        TLP_MainSubqBittorrent.Dock = DockStyle.Fill
        TLP_MainSubqBittorrent.Location = New Point(3, 19)
        TLP_MainSubqBittorrent.Name = "TLP_MainSubqBittorrent"
        TLP_MainSubqBittorrent.RowCount = 4
        TLP_MainSubqBittorrent.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        TLP_MainSubqBittorrent.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        TLP_MainSubqBittorrent.RowStyles.Add(New RowStyle(SizeType.Absolute, 32F))
        TLP_MainSubqBittorrent.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TLP_MainSubqBittorrent.Size = New Size(381, 97)
        TLP_MainSubqBittorrent.TabIndex = 0
        ' 
        ' GB_Action
        ' 
        GB_Action.Controls.Add(BTN_TestSaveUpdate)
        GB_Action.Dock = DockStyle.Fill
        GB_Action.Location = New Point(3, 253)
        GB_Action.Name = "GB_Action"
        GB_Action.Size = New Size(387, 48)
        GB_Action.TabIndex = 14
        GB_Action.TabStop = False
        GB_Action.Text = "Action"
        ' 
        ' TP_Logs
        ' 
        TP_Logs.Controls.Add(TLP_Logs)
        TP_Logs.Location = New Point(4, 4)
        TP_Logs.Name = "TP_Logs"
        TP_Logs.Size = New Size(399, 311)
        TP_Logs.TabIndex = 1
        TP_Logs.Text = "Logs"
        TP_Logs.UseVisualStyleBackColor = True
        ' 
        ' TLP_Logs
        ' 
        TLP_Logs.ColumnCount = 1
        TLP_Logs.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLP_Logs.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        TLP_Logs.Controls.Add(GB_ProtonLog, 0, 0)
        TLP_Logs.Controls.Add(GB_QuantumLog, 0, 1)
        TLP_Logs.Dock = DockStyle.Fill
        TLP_Logs.Location = New Point(0, 0)
        TLP_Logs.Name = "TLP_Logs"
        TLP_Logs.RowCount = 2
        TLP_Logs.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLP_Logs.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TLP_Logs.Size = New Size(399, 311)
        TLP_Logs.TabIndex = 3
        ' 
        ' GB_ProtonLog
        ' 
        GB_ProtonLog.Controls.Add(LV_VPNLogFile)
        GB_ProtonLog.Dock = DockStyle.Fill
        GB_ProtonLog.Location = New Point(3, 3)
        GB_ProtonLog.Name = "GB_ProtonLog"
        GB_ProtonLog.Size = New Size(393, 149)
        GB_ProtonLog.TabIndex = 1
        GB_ProtonLog.TabStop = False
        GB_ProtonLog.Text = "ProtonVPN Log File Output (Parsed)"
        ' 
        ' GB_QuantumLog
        ' 
        GB_QuantumLog.Controls.Add(LV_QLog)
        GB_QuantumLog.Dock = DockStyle.Fill
        GB_QuantumLog.Location = New Point(3, 158)
        GB_QuantumLog.Name = "GB_QuantumLog"
        GB_QuantumLog.Size = New Size(393, 150)
        GB_QuantumLog.TabIndex = 2
        GB_QuantumLog.TabStop = False
        GB_QuantumLog.Text = "Quantum Event Log"
        ' 
        ' LV_QLog
        ' 
        LV_QLog.BorderStyle = BorderStyle.FixedSingle
        LV_QLog.Columns.AddRange(New ColumnHeader() {CH_QDateTime, CH_QEvent})
        LV_QLog.Dock = DockStyle.Fill
        LV_QLog.FullRowSelect = True
        LV_QLog.GridLines = True
        LV_QLog.HeaderStyle = ColumnHeaderStyle.Nonclickable
        LV_QLog.Location = New Point(3, 19)
        LV_QLog.MultiSelect = False
        LV_QLog.Name = "LV_QLog"
        LV_QLog.Size = New Size(387, 128)
        LV_QLog.TabIndex = 2
        TT_Main.SetToolTip(LV_QLog, "Double click to see the event")
        LV_QLog.UseCompatibleStateImageBehavior = False
        LV_QLog.View = View.Details
        ' 
        ' CH_QDateTime
        ' 
        CH_QDateTime.Text = "Date/Time"
        CH_QDateTime.Width = 100
        ' 
        ' CH_QEvent
        ' 
        CH_QEvent.Text = "Event"
        CH_QEvent.Width = 237
        ' 
        ' TP_About
        ' 
        TP_About.Controls.Add(TLP_About)
        TP_About.Location = New Point(4, 4)
        TP_About.Name = "TP_About"
        TP_About.Size = New Size(399, 311)
        TP_About.TabIndex = 2
        TP_About.Text = "About"
        TP_About.UseVisualStyleBackColor = True
        ' 
        ' TLP_About
        ' 
        TLP_About.ColumnCount = 3
        TLP_About.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 18.75117F))
        TLP_About.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 62.4976578F))
        TLP_About.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 18.7511711F))
        TLP_About.Controls.Add(PIC_About, 1, 2)
        TLP_About.Controls.Add(LNK_About, 0, 1)
        TLP_About.Controls.Add(LNK_AboutProtonVPN, 0, 3)
        TLP_About.Controls.Add(LBL_Author, 1, 0)
        TLP_About.Dock = DockStyle.Fill
        TLP_About.Location = New Point(0, 0)
        TLP_About.Name = "TLP_About"
        TLP_About.RowCount = 4
        TLP_About.RowStyles.Add(New RowStyle(SizeType.Percent, 6.723586F))
        TLP_About.RowStyles.Add(New RowStyle(SizeType.Percent, 6.723586F))
        TLP_About.RowStyles.Add(New RowStyle(SizeType.Percent, 73.10566F))
        TLP_About.RowStyles.Add(New RowStyle(SizeType.Percent, 13.4471722F))
        TLP_About.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        TLP_About.Size = New Size(399, 311)
        TLP_About.TabIndex = 0
        ' 
        ' PIC_About
        ' 
        PIC_About.BackColor = Color.Transparent
        PIC_About.Dock = DockStyle.Fill
        PIC_About.Image = CType(resources.GetObject("PIC_About.Image"), Image)
        PIC_About.Location = New Point(77, 43)
        PIC_About.Name = "PIC_About"
        PIC_About.Size = New Size(243, 221)
        PIC_About.SizeMode = PictureBoxSizeMode.Zoom
        PIC_About.TabIndex = 0
        PIC_About.TabStop = False
        ' 
        ' LNK_About
        ' 
        LNK_About.AutoSize = True
        TLP_About.SetColumnSpan(LNK_About, 3)
        LNK_About.Dock = DockStyle.Fill
        LNK_About.LinkArea = New LinkArea(0, 42)
        LNK_About.Location = New Point(3, 20)
        LNK_About.Name = "LNK_About"
        LNK_About.Size = New Size(393, 20)
        LNK_About.TabIndex = 2
        LNK_About.TabStop = True
        LNK_About.Text = "https://github.com/UHAXM1/Quantum/releases"
        LNK_About.TextAlign = ContentAlignment.TopCenter
        ' 
        ' LNK_AboutProtonVPN
        ' 
        LNK_AboutProtonVPN.AutoSize = True
        TLP_About.SetColumnSpan(LNK_AboutProtonVPN, 3)
        LNK_AboutProtonVPN.Dock = DockStyle.Fill
        LNK_AboutProtonVPN.LinkArea = New LinkArea(54, 18)
        LNK_AboutProtonVPN.Location = New Point(3, 267)
        LNK_AboutProtonVPN.Name = "LNK_AboutProtonVPN"
        LNK_AboutProtonVPN.Size = New Size(393, 44)
        LNK_AboutProtonVPN.TabIndex = 4
        LNK_AboutProtonVPN.TabStop = True
        LNK_AboutProtonVPN.Text = "This app is not affiliated in any way with Proton AG (https://proton.me/), use at your own risk."
        LNK_AboutProtonVPN.TextAlign = ContentAlignment.MiddleCenter
        LNK_AboutProtonVPN.UseCompatibleTextRendering = True
        ' 
        ' LBL_Author
        ' 
        LBL_Author.AutoSize = True
        LBL_Author.Dock = DockStyle.Fill
        LBL_Author.Location = New Point(77, 0)
        LBL_Author.Name = "LBL_Author"
        LBL_Author.Size = New Size(243, 20)
        LBL_Author.TabIndex = 1
        LBL_Author.Text = "By UHAX"
        LBL_Author.TextAlign = ContentAlignment.TopCenter
        ' 
        ' CMS_Main
        ' 
        CMS_Main.Items.AddRange(New ToolStripItem() {TSMI_ShowHide, TSMI_UpdateNow, TSMI_Exit})
        CMS_Main.Name = "ContextMenuStrip"
        CMS_Main.Size = New Size(166, 70)
        ' 
        ' TSMI_ShowHide
        ' 
        TSMI_ShowHide.Name = "TSMI_ShowHide"
        TSMI_ShowHide.Size = New Size(165, 22)
        TSMI_ShowHide.Text = "Show/Hide"
        ' 
        ' TSMI_UpdateNow
        ' 
        TSMI_UpdateNow.Name = "TSMI_UpdateNow"
        TSMI_UpdateNow.Size = New Size(165, 22)
        TSMI_UpdateNow.Text = "Update Port Now"
        ' 
        ' TSMI_Exit
        ' 
        TSMI_Exit.Name = "TSMI_Exit"
        TSMI_Exit.Size = New Size(165, 22)
        TSMI_Exit.Text = "Exit"
        ' 
        ' TLP_Main
        ' 
        TLP_Main.ColumnCount = 1
        TLP_Main.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TLP_Main.Controls.Add(TAB_Main, 0, 0)
        TLP_Main.Controls.Add(PRG_Main, 0, 1)
        TLP_Main.Dock = DockStyle.Fill
        TLP_Main.Location = New Point(0, 0)
        TLP_Main.Name = "TLP_Main"
        TLP_Main.RowCount = 2
        TLP_Main.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TLP_Main.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        TLP_Main.Size = New Size(413, 368)
        TLP_Main.TabIndex = 9
        ' 
        ' PRG_Main
        ' 
        PRG_Main.Dock = DockStyle.Fill
        PRG_Main.Location = New Point(3, 348)
        PRG_Main.Maximum = 60
        PRG_Main.Name = "PRG_Main"
        PRG_Main.Size = New Size(407, 17)
        PRG_Main.Step = 1
        PRG_Main.TabIndex = 10
        ' 
        ' Main
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(413, 390)
        Controls.Add(TLP_Main)
        Controls.Add(STS_Main)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Main"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Quantum"
        WindowState = FormWindowState.Minimized
        STS_Main.ResumeLayout(False)
        STS_Main.PerformLayout()
        TAB_Main.ResumeLayout(False)
        TP_Settings.ResumeLayout(False)
        TLP_SubMain.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        TLP_MainSubQuantum.ResumeLayout(False)
        GB_qBittorrentConfig.ResumeLayout(False)
        TLP_MainSubqBittorrent.ResumeLayout(False)
        TLP_MainSubqBittorrent.PerformLayout()
        GB_Action.ResumeLayout(False)
        TP_Logs.ResumeLayout(False)
        TLP_Logs.ResumeLayout(False)
        GB_ProtonLog.ResumeLayout(False)
        GB_QuantumLog.ResumeLayout(False)
        TP_About.ResumeLayout(False)
        TLP_About.ResumeLayout(False)
        TLP_About.PerformLayout()
        CType(PIC_About, ComponentModel.ISupportInitialize).EndInit()
        CMS_Main.ResumeLayout(False)
        TLP_Main.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents BTN_TestSaveUpdate As Button
    Friend WithEvents TMR_Main As Timer
    Friend WithEvents LV_VPNLogFile As ListView
    Friend WithEvents CH_VPNDateTime As ColumnHeader
    Friend WithEvents CH_VPNPort As ColumnHeader
    Friend WithEvents STS_Main As StatusStrip
    Friend WithEvents TSSL_Main As ToolStripStatusLabel
    Friend WithEvents NI_Main As NotifyIcon
    Friend WithEvents TAB_Main As TabControl
    Friend WithEvents TP_Settings As TabPage
    Friend WithEvents TP_Logs As TabPage
    Friend WithEvents LV_QLog As ListView
    Friend WithEvents CH_QDateTime As ColumnHeader
    Friend WithEvents CH_QEvent As ColumnHeader
    Friend WithEvents TP_About As TabPage
    Friend WithEvents TLP_About As TableLayoutPanel
    Friend WithEvents PIC_About As PictureBox
    Friend WithEvents CMS_Main As ContextMenuStrip
    Friend WithEvents TSMI_Exit As ToolStripMenuItem
    Friend WithEvents TSMI_ShowHide As ToolStripMenuItem
    Friend WithEvents TSMI_UpdateNow As ToolStripMenuItem
    Friend WithEvents TLP_Main As TableLayoutPanel
    Friend WithEvents LNK_About As LinkLabel
    Friend WithEvents LNK_AboutProtonVPN As LinkLabel
    Friend WithEvents TT_Main As ToolTip
    Friend WithEvents CH_VPNValid As ColumnHeader
    Friend WithEvents BTN_LogFile As Button
    Friend WithEvents LBL_Author As Label
    Friend WithEvents TBE_Startup As ToggleButtonEx
    Friend WithEvents TBE_LogFile As ToggleButtonEx
    Friend WithEvents TXT_Host As TextBox
    Friend WithEvents TXT_Username As TextBox
    Friend WithEvents TXT_Password As TextBox
    Friend WithEvents GroupBox1 As GroupBoxEx
    Friend WithEvents TLP_MainSubQuantum As TableLayoutPanel
    Friend WithEvents GB_qBittorrentConfig As GroupBoxEx
    Friend WithEvents TLP_MainSubqBittorrent As TableLayoutPanel
    Friend WithEvents TLP_Logs As TableLayoutPanel
    Friend WithEvents GB_ProtonLog As GroupBoxEx
    Friend WithEvents GB_QuantumLog As GroupBoxEx
    Friend WithEvents PRG_Main As ProgressBarEx
    Friend WithEvents TLP_SubMain As TableLayoutPanel
    Friend WithEvents GB_Action As GroupBoxEx

End Class
