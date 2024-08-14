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
        TestSaveButton = New Button()
        MainTimer = New Timer(components)
        VPNLogFile = New ListView()
        VPNDateTime = New ColumnHeader()
        VPNPort = New ColumnHeader()
        VPNPortLength = New ColumnHeader()
        VPNValid = New ColumnHeader()
        HostTextBoxLabel = New TextBox()
        HostTextBox = New TextBox()
        qBittorrentLabel = New Label()
        UsernameTextBoxLabel = New TextBox()
        PasswordTextBoxLabel = New TextBox()
        UsernameTextBox = New TextBox()
        PasswordTextBox = New TextBox()
        SettingsTableLayoutPanel = New TableLayoutPanel()
        LogFileSelectButton = New Button()
        UpdateButton = New Button()
        StartUpCheckBox = New CheckBox()
        VPNLogFileLabel = New Label()
        StatusStrip = New StatusStrip()
        ToolStripStatusLabel = New ToolStripStatusLabel()
        NotifyIcon = New NotifyIcon(components)
        MainTabControl = New TabControl()
        TabPageSettings = New TabPage()
        TabPageLogs = New TabPage()
        LogsTableLayoutPanel = New TableLayoutPanel()
        QLogFile = New ListView()
        QDateTime = New ColumnHeader()
        QEvent = New ColumnHeader()
        QLogLabel = New Label()
        TabPageAbout = New TabPage()
        AboutTableLayoutPanel = New TableLayoutPanel()
        AboutPictureBox = New PictureBox()
        AuthorLabel = New Label()
        AboutLabelProtonVPN = New Label()
        TrayContextMenuStrip = New ContextMenuStrip(components)
        ShowToolStripMenuItem = New ToolStripMenuItem()
        UpdateNowToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        SettingsTableLayoutPanel.SuspendLayout()
        StatusStrip.SuspendLayout()
        MainTabControl.SuspendLayout()
        TabPageSettings.SuspendLayout()
        TabPageLogs.SuspendLayout()
        LogsTableLayoutPanel.SuspendLayout()
        TabPageAbout.SuspendLayout()
        AboutTableLayoutPanel.SuspendLayout()
        CType(AboutPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        TrayContextMenuStrip.SuspendLayout()
        SuspendLayout()
        ' 
        ' TestSaveButton
        ' 
        SettingsTableLayoutPanel.SetColumnSpan(TestSaveButton, 2)
        TestSaveButton.Dock = DockStyle.Fill
        TestSaveButton.Location = New Point(3, 167)
        TestSaveButton.Name = "TestSaveButton"
        TestSaveButton.Size = New Size(360, 40)
        TestSaveButton.TabIndex = 6
        TestSaveButton.Text = "Test/Save Settings"
        TestSaveButton.UseVisualStyleBackColor = True
        ' 
        ' MainTimer
        ' 
        MainTimer.Interval = 60000
        ' 
        ' VPNLogFile
        ' 
        VPNLogFile.Columns.AddRange(New ColumnHeader() {VPNDateTime, VPNPort, VPNPortLength, VPNValid})
        LogsTableLayoutPanel.SetColumnSpan(VPNLogFile, 2)
        VPNLogFile.Dock = DockStyle.Fill
        VPNLogFile.FullRowSelect = True
        VPNLogFile.GridLines = True
        VPNLogFile.HeaderStyle = ColumnHeaderStyle.Nonclickable
        VPNLogFile.Location = New Point(3, 26)
        VPNLogFile.MultiSelect = False
        VPNLogFile.Name = "VPNLogFile"
        VPNLogFile.Size = New Size(360, 99)
        VPNLogFile.TabIndex = 1
        VPNLogFile.UseCompatibleStateImageBehavior = False
        VPNLogFile.View = View.Details
        ' 
        ' VPNDateTime
        ' 
        VPNDateTime.Text = "Date/Time"
        VPNDateTime.Width = 100
        ' 
        ' VPNPort
        ' 
        VPNPort.Text = "Port Number"
        VPNPort.Width = 100
        ' 
        ' VPNPortLength
        ' 
        VPNPortLength.Text = "Port Length"
        VPNPortLength.Width = 100
        ' 
        ' VPNValid
        ' 
        VPNValid.Text = "Valid"
        VPNValid.Width = 37
        ' 
        ' HostTextBoxLabel
        ' 
        HostTextBoxLabel.Dock = DockStyle.Fill
        HostTextBoxLabel.Enabled = False
        HostTextBoxLabel.Location = New Point(3, 98)
        HostTextBoxLabel.Name = "HostTextBoxLabel"
        HostTextBoxLabel.Size = New Size(64, 23)
        HostTextBoxLabel.TabIndex = 4
        HostTextBoxLabel.TabStop = False
        HostTextBoxLabel.Text = "Host:"
        ' 
        ' HostTextBox
        ' 
        HostTextBox.Dock = DockStyle.Fill
        HostTextBox.Location = New Point(73, 98)
        HostTextBox.Name = "HostTextBox"
        HostTextBox.Size = New Size(290, 23)
        HostTextBox.TabIndex = 3
        ' 
        ' qBittorrentLabel
        ' 
        qBittorrentLabel.AutoSize = True
        SettingsTableLayoutPanel.SetColumnSpan(qBittorrentLabel, 2)
        qBittorrentLabel.Dock = DockStyle.Fill
        qBittorrentLabel.Location = New Point(3, 72)
        qBittorrentLabel.Name = "qBittorrentLabel"
        qBittorrentLabel.Size = New Size(360, 23)
        qBittorrentLabel.TabIndex = 5
        qBittorrentLabel.Text = "qBittorrent Configuration"
        qBittorrentLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' UsernameTextBoxLabel
        ' 
        UsernameTextBoxLabel.Dock = DockStyle.Fill
        UsernameTextBoxLabel.Enabled = False
        UsernameTextBoxLabel.Location = New Point(3, 121)
        UsernameTextBoxLabel.Name = "UsernameTextBoxLabel"
        UsernameTextBoxLabel.Size = New Size(64, 23)
        UsernameTextBoxLabel.TabIndex = 6
        UsernameTextBoxLabel.TabStop = False
        UsernameTextBoxLabel.Text = "Username:"
        ' 
        ' PasswordTextBoxLabel
        ' 
        PasswordTextBoxLabel.Dock = DockStyle.Fill
        PasswordTextBoxLabel.Enabled = False
        PasswordTextBoxLabel.Location = New Point(3, 144)
        PasswordTextBoxLabel.Name = "PasswordTextBoxLabel"
        PasswordTextBoxLabel.Size = New Size(64, 23)
        PasswordTextBoxLabel.TabIndex = 7
        PasswordTextBoxLabel.TabStop = False
        PasswordTextBoxLabel.Text = "Password:"
        ' 
        ' UsernameTextBox
        ' 
        UsernameTextBox.Dock = DockStyle.Fill
        UsernameTextBox.Location = New Point(73, 121)
        UsernameTextBox.Name = "UsernameTextBox"
        UsernameTextBox.Size = New Size(290, 23)
        UsernameTextBox.TabIndex = 4
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Dock = DockStyle.Fill
        PasswordTextBox.Location = New Point(73, 144)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.Size = New Size(290, 23)
        PasswordTextBox.TabIndex = 5
        PasswordTextBox.UseSystemPasswordChar = True
        ' 
        ' SettingsTableLayoutPanel
        ' 
        SettingsTableLayoutPanel.ColumnCount = 2
        SettingsTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 70F))
        SettingsTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        SettingsTableLayoutPanel.Controls.Add(TestSaveButton, 0, 6)
        SettingsTableLayoutPanel.Controls.Add(qBittorrentLabel, 0, 2)
        SettingsTableLayoutPanel.Controls.Add(HostTextBox, 1, 3)
        SettingsTableLayoutPanel.Controls.Add(PasswordTextBox, 1, 5)
        SettingsTableLayoutPanel.Controls.Add(PasswordTextBoxLabel, 0, 5)
        SettingsTableLayoutPanel.Controls.Add(UsernameTextBoxLabel, 0, 4)
        SettingsTableLayoutPanel.Controls.Add(UsernameTextBox, 1, 4)
        SettingsTableLayoutPanel.Controls.Add(HostTextBoxLabel, 0, 3)
        SettingsTableLayoutPanel.Controls.Add(LogFileSelectButton, 0, 1)
        SettingsTableLayoutPanel.Controls.Add(UpdateButton, 0, 7)
        SettingsTableLayoutPanel.Controls.Add(StartUpCheckBox, 0, 0)
        SettingsTableLayoutPanel.Dock = DockStyle.Fill
        SettingsTableLayoutPanel.Location = New Point(3, 3)
        SettingsTableLayoutPanel.Name = "SettingsTableLayoutPanel"
        SettingsTableLayoutPanel.RowCount = 9
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 26F))
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 46F))
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 46F))
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 46F))
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        SettingsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        SettingsTableLayoutPanel.Size = New Size(366, 257)
        SettingsTableLayoutPanel.TabIndex = 5
        ' 
        ' LogFileSelectButton
        ' 
        SettingsTableLayoutPanel.SetColumnSpan(LogFileSelectButton, 2)
        LogFileSelectButton.Dock = DockStyle.Fill
        LogFileSelectButton.Location = New Point(3, 29)
        LogFileSelectButton.Name = "LogFileSelectButton"
        LogFileSelectButton.Size = New Size(360, 40)
        LogFileSelectButton.TabIndex = 2
        LogFileSelectButton.Text = "Select ProtonVPN Log File   (...)"
        LogFileSelectButton.UseVisualStyleBackColor = True
        ' 
        ' UpdateButton
        ' 
        SettingsTableLayoutPanel.SetColumnSpan(UpdateButton, 2)
        UpdateButton.Dock = DockStyle.Fill
        UpdateButton.Location = New Point(3, 213)
        UpdateButton.Name = "UpdateButton"
        UpdateButton.Size = New Size(360, 40)
        UpdateButton.TabIndex = 7
        UpdateButton.Text = "Update Port Now"
        UpdateButton.UseVisualStyleBackColor = True
        ' 
        ' StartUpCheckBox
        ' 
        StartUpCheckBox.AutoSize = True
        SettingsTableLayoutPanel.SetColumnSpan(StartUpCheckBox, 2)
        StartUpCheckBox.Dock = DockStyle.Fill
        StartUpCheckBox.Location = New Point(3, 3)
        StartUpCheckBox.Name = "StartUpCheckBox"
        StartUpCheckBox.Size = New Size(360, 20)
        StartUpCheckBox.TabIndex = 1
        StartUpCheckBox.Text = "Launch Quantum at Startup"
        StartUpCheckBox.TextAlign = ContentAlignment.MiddleCenter
        StartUpCheckBox.UseVisualStyleBackColor = True
        ' 
        ' VPNLogFileLabel
        ' 
        VPNLogFileLabel.AutoSize = True
        LogsTableLayoutPanel.SetColumnSpan(VPNLogFileLabel, 2)
        VPNLogFileLabel.Dock = DockStyle.Fill
        VPNLogFileLabel.Location = New Point(3, 0)
        VPNLogFileLabel.Name = "VPNLogFileLabel"
        VPNLogFileLabel.Size = New Size(360, 23)
        VPNLogFileLabel.TabIndex = 3
        VPNLogFileLabel.Text = "ProtonVPN Log File Output (Parsed)"
        VPNLogFileLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' StatusStrip
        ' 
        StatusStrip.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel})
        StatusStrip.Location = New Point(0, 291)
        StatusStrip.Name = "StatusStrip"
        StatusStrip.Size = New Size(380, 22)
        StatusStrip.SizingGrip = False
        StatusStrip.TabIndex = 4
        StatusStrip.Text = "StatusStrip1"
        ' 
        ' ToolStripStatusLabel
        ' 
        ToolStripStatusLabel.AutoToolTip = True
        ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        ToolStripStatusLabel.Size = New Size(365, 17)
        ToolStripStatusLabel.Spring = True
        ' 
        ' NotifyIcon
        ' 
        NotifyIcon.Icon = CType(resources.GetObject("NotifyIcon.Icon"), Icon)
        NotifyIcon.Text = "Quantum"
        NotifyIcon.Visible = True
        ' 
        ' MainTabControl
        ' 
        MainTabControl.Alignment = TabAlignment.Bottom
        MainTabControl.Controls.Add(TabPageSettings)
        MainTabControl.Controls.Add(TabPageLogs)
        MainTabControl.Controls.Add(TabPageAbout)
        MainTabControl.Dock = DockStyle.Fill
        MainTabControl.Location = New Point(0, 0)
        MainTabControl.Name = "MainTabControl"
        MainTabControl.SelectedIndex = 0
        MainTabControl.Size = New Size(380, 291)
        MainTabControl.TabIndex = 8
        ' 
        ' TabPageSettings
        ' 
        TabPageSettings.Controls.Add(SettingsTableLayoutPanel)
        TabPageSettings.Location = New Point(4, 4)
        TabPageSettings.Name = "TabPageSettings"
        TabPageSettings.Padding = New Padding(3)
        TabPageSettings.Size = New Size(372, 263)
        TabPageSettings.TabIndex = 0
        TabPageSettings.Text = "Settings"
        TabPageSettings.UseVisualStyleBackColor = True
        ' 
        ' TabPageLogs
        ' 
        TabPageLogs.Controls.Add(LogsTableLayoutPanel)
        TabPageLogs.Location = New Point(4, 4)
        TabPageLogs.Name = "TabPageLogs"
        TabPageLogs.Padding = New Padding(3)
        TabPageLogs.Size = New Size(372, 263)
        TabPageLogs.TabIndex = 1
        TabPageLogs.Text = "Logs"
        TabPageLogs.UseVisualStyleBackColor = True
        ' 
        ' LogsTableLayoutPanel
        ' 
        LogsTableLayoutPanel.ColumnCount = 2
        LogsTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        LogsTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        LogsTableLayoutPanel.Controls.Add(QLogFile, 0, 3)
        LogsTableLayoutPanel.Controls.Add(VPNLogFileLabel, 0, 0)
        LogsTableLayoutPanel.Controls.Add(VPNLogFile, 0, 1)
        LogsTableLayoutPanel.Controls.Add(QLogLabel, 0, 2)
        LogsTableLayoutPanel.Dock = DockStyle.Fill
        LogsTableLayoutPanel.Location = New Point(3, 3)
        LogsTableLayoutPanel.Name = "LogsTableLayoutPanel"
        LogsTableLayoutPanel.RowCount = 4
        LogsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        LogsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        LogsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 23F))
        LogsTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        LogsTableLayoutPanel.Size = New Size(366, 257)
        LogsTableLayoutPanel.TabIndex = 0
        ' 
        ' QLogFile
        ' 
        QLogFile.Columns.AddRange(New ColumnHeader() {QDateTime, QEvent})
        LogsTableLayoutPanel.SetColumnSpan(QLogFile, 2)
        QLogFile.Dock = DockStyle.Fill
        QLogFile.FullRowSelect = True
        QLogFile.GridLines = True
        QLogFile.HeaderStyle = ColumnHeaderStyle.Nonclickable
        QLogFile.Location = New Point(3, 154)
        QLogFile.MultiSelect = False
        QLogFile.Name = "QLogFile"
        QLogFile.Size = New Size(360, 100)
        QLogFile.TabIndex = 2
        QLogFile.UseCompatibleStateImageBehavior = False
        QLogFile.View = View.Details
        ' 
        ' QDateTime
        ' 
        QDateTime.Text = "Date/Time"
        QDateTime.Width = 100
        ' 
        ' QEvent
        ' 
        QEvent.Text = "Event"
        QEvent.Width = 237
        ' 
        ' QLogLabel
        ' 
        QLogLabel.AutoSize = True
        LogsTableLayoutPanel.SetColumnSpan(QLogLabel, 2)
        QLogLabel.Dock = DockStyle.Fill
        QLogLabel.Location = New Point(3, 128)
        QLogLabel.Name = "QLogLabel"
        QLogLabel.Size = New Size(360, 23)
        QLogLabel.TabIndex = 6
        QLogLabel.Text = "Quantum Log Output"
        QLogLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TabPageAbout
        ' 
        TabPageAbout.Controls.Add(AboutTableLayoutPanel)
        TabPageAbout.Location = New Point(4, 4)
        TabPageAbout.Name = "TabPageAbout"
        TabPageAbout.Size = New Size(372, 263)
        TabPageAbout.TabIndex = 2
        TabPageAbout.Text = "About"
        TabPageAbout.UseVisualStyleBackColor = True
        ' 
        ' AboutTableLayoutPanel
        ' 
        AboutTableLayoutPanel.ColumnCount = 3
        AboutTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 18.7511711F))
        AboutTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 62.4976578F))
        AboutTableLayoutPanel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 18.7511711F))
        AboutTableLayoutPanel.Controls.Add(AboutPictureBox, 1, 1)
        AboutTableLayoutPanel.Controls.Add(AuthorLabel, 1, 0)
        AboutTableLayoutPanel.Controls.Add(AboutLabelProtonVPN, 0, 2)
        AboutTableLayoutPanel.Dock = DockStyle.Fill
        AboutTableLayoutPanel.Location = New Point(0, 0)
        AboutTableLayoutPanel.Name = "AboutTableLayoutPanel"
        AboutTableLayoutPanel.RowCount = 3
        AboutTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 18.75F))
        AboutTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 62.5F))
        AboutTableLayoutPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 18.75F))
        AboutTableLayoutPanel.Size = New Size(372, 263)
        AboutTableLayoutPanel.TabIndex = 0
        ' 
        ' AboutPictureBox
        ' 
        AboutPictureBox.BackColor = Color.Black
        AboutPictureBox.Dock = DockStyle.Fill
        AboutPictureBox.Image = My.Resources.Resources.UHAX
        AboutPictureBox.Location = New Point(72, 52)
        AboutPictureBox.Name = "AboutPictureBox"
        AboutPictureBox.Size = New Size(226, 158)
        AboutPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        AboutPictureBox.TabIndex = 0
        AboutPictureBox.TabStop = False
        ' 
        ' AuthorLabel
        ' 
        AuthorLabel.AutoSize = True
        AuthorLabel.Dock = DockStyle.Fill
        AuthorLabel.Location = New Point(72, 0)
        AuthorLabel.Name = "AuthorLabel"
        AuthorLabel.Size = New Size(226, 49)
        AuthorLabel.TabIndex = 1
        AuthorLabel.Text = "By UHAX"
        AuthorLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' AboutLabelProtonVPN
        ' 
        AboutLabelProtonVPN.AutoSize = True
        AboutTableLayoutPanel.SetColumnSpan(AboutLabelProtonVPN, 3)
        AboutLabelProtonVPN.Dock = DockStyle.Fill
        AboutLabelProtonVPN.Location = New Point(3, 213)
        AboutLabelProtonVPN.Name = "AboutLabelProtonVPN"
        AboutLabelProtonVPN.Size = New Size(366, 50)
        AboutLabelProtonVPN.TabIndex = 2
        AboutLabelProtonVPN.Text = "This app is not affiliated in any way with Proton AG (https://proton.me/), use at your own risk."
        AboutLabelProtonVPN.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TrayContextMenuStrip
        ' 
        TrayContextMenuStrip.Items.AddRange(New ToolStripItem() {ShowToolStripMenuItem, UpdateNowToolStripMenuItem, ExitToolStripMenuItem})
        TrayContextMenuStrip.Name = "ContextMenuStrip"
        TrayContextMenuStrip.Size = New Size(166, 70)
        ' 
        ' ShowToolStripMenuItem
        ' 
        ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        ShowToolStripMenuItem.Size = New Size(165, 22)
        ShowToolStripMenuItem.Text = "Show"
        ' 
        ' UpdateNowToolStripMenuItem
        ' 
        UpdateNowToolStripMenuItem.Name = "UpdateNowToolStripMenuItem"
        UpdateNowToolStripMenuItem.Size = New Size(165, 22)
        UpdateNowToolStripMenuItem.Text = "Update Port Now"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(165, 22)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' Main
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(380, 313)
        Controls.Add(MainTabControl)
        Controls.Add(StatusStrip)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Main"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Quantum"
        WindowState = FormWindowState.Minimized
        SettingsTableLayoutPanel.ResumeLayout(False)
        SettingsTableLayoutPanel.PerformLayout()
        StatusStrip.ResumeLayout(False)
        StatusStrip.PerformLayout()
        MainTabControl.ResumeLayout(False)
        TabPageSettings.ResumeLayout(False)
        TabPageLogs.ResumeLayout(False)
        LogsTableLayoutPanel.ResumeLayout(False)
        LogsTableLayoutPanel.PerformLayout()
        TabPageAbout.ResumeLayout(False)
        AboutTableLayoutPanel.ResumeLayout(False)
        AboutTableLayoutPanel.PerformLayout()
        CType(AboutPictureBox, ComponentModel.ISupportInitialize).EndInit()
        TrayContextMenuStrip.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TestSaveButton As Button
    Friend WithEvents MainTimer As Timer
    Friend WithEvents VPNLogFile As ListView
    Friend WithEvents VPNDateTime As ColumnHeader
    Friend WithEvents VPNPort As ColumnHeader
    Friend WithEvents VPNPortLength As ColumnHeader
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStripStatusLabel As ToolStripStatusLabel
    Friend WithEvents HostTextBox As TextBox
    Friend WithEvents HostTextBoxLabel As TextBox
    Friend WithEvents qBittorrentLabel As Label
    Friend WithEvents UsernameTextBoxLabel As TextBox
    Friend WithEvents PasswordTextBoxLabel As TextBox
    Friend WithEvents SettingsTableLayoutPanel As TableLayoutPanel
    Friend WithEvents VPNLogFileLabel As Label
    Friend WithEvents UsernameTextBox As TextBox
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents LogFileSelectButton As Button
    Friend WithEvents NotifyIcon As NotifyIcon
    Friend WithEvents VPNValid As ColumnHeader
    Friend WithEvents UpdateButton As Button
    Friend WithEvents MainTabControl As TabControl
    Friend WithEvents TabPageSettings As TabPage
    Friend WithEvents TabPageLogs As TabPage
    Friend WithEvents LogsTableLayoutPanel As TableLayoutPanel
    Friend WithEvents QLogFile As ListView
    Friend WithEvents QLogLabel As Label
    Friend WithEvents QDateTime As ColumnHeader
    Friend WithEvents QEvent As ColumnHeader
    Friend WithEvents TabPageAbout As TabPage
    Friend WithEvents AboutTableLayoutPanel As TableLayoutPanel
    Friend WithEvents AboutPictureBox As PictureBox
    Friend WithEvents AuthorLabel As Label
    Friend WithEvents AboutLabelProtonVPN As Label
    Friend WithEvents StartUpCheckBox As CheckBox
    Friend WithEvents TrayContextMenuStrip As ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateNowToolStripMenuItem As ToolStripMenuItem

End Class
