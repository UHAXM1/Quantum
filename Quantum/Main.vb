Imports System.ComponentModel
Imports System.IO
Imports Microsoft.VisualBasic.Logging
Imports Microsoft.Win32
Imports QBittorrent.Client

Public Class Main

    Private LastValidPort As Integer = -1

    Private Async Function CheckConnection() As Task

        Try

            VPNLogFile.Items.Clear()

            Dim client = New QBittorrentClient(New Uri(My.Settings.Host))

            Await client.LoginAsync(My.Settings.Username, My.Settings.Password)

            Dim prefs = New Preferences()

            prefs = Await client.GetPreferencesAsync()

            LastValidPort = prefs.ListenPort

            CheckForChange()

        Catch ex As Exception

            LogOutput("qBittorrent error: " & ex.Message, True, True)

        Finally

            MainTimer.Enabled = True

        End Try

    End Function

    Private Async Function TestSaveSettings() As Task

        Try

            Dim client = New QBittorrentClient(New Uri(HostTextBox.Text))

            Await client.LoginAsync(UsernameTextBox.Text, PasswordTextBox.Text)

            Dim prefs = New Preferences()

            prefs = Await client.GetPreferencesAsync()

            LastValidPort = prefs.ListenPort

            My.Settings.Host = HostTextBox.Text

            My.Settings.Username = UsernameTextBox.Text

            My.Settings.Password = PasswordTextBox.Text

            My.Settings.Save()

            LogOutput("Connected to qBittorrent, settings saved!", True, False)

            Dim result As DialogResult = MessageBox.Show("Connected to qBittorrent, settings saved!")

            CheckForChange()

        Catch ex As Exception

            LogOutput("qBittorrent error: " & ex.Message, True, True)

            MessageBox.Show("qBittorrent error: " & ex.Message)

        End Try

    End Function

    Private Async Function UpdatePort(ByVal pPort As Integer) As Task

        Try

            Dim client = New QBittorrentClient(New Uri(My.Settings.Host))

            Await client.LoginAsync(My.Settings.Username, My.Settings.Password)

            Dim prefs = New Preferences()

            prefs = Await client.GetPreferencesAsync()

            prefs.ListenPort = pPort

            Await client.SetPreferencesAsync(prefs)

            LastValidPort = pPort

            LogOutput("Updated qBittorrent port to " & LastValidPort, True, False)

        Catch ex As Exception

            LogOutput("qBittorrent error: " & ex.Message, True, True)

        End Try

    End Function

    Private Sub CheckForChange()

        Try

            MainTimer.Enabled = False

            TestSaveButton.Enabled = False

            UpdateButton.Text = "Reading log file..."

            UpdateButton.Enabled = False

            LogOutput("Reading log file...", False, False)

            VPNLogFile.Items.Clear()

            Dim HeaderItem As New ListViewItem(VPNLogFile.Columns.Item(0).Text)

            HeaderItem.SubItems.Add(VPNLogFile.Columns.Item(1).Text)

            HeaderItem.SubItems.Add(VPNLogFile.Columns.Item(2).Text)

            HeaderItem.SubItems.Add(VPNLogFile.Columns.Item(3).Text)

            VPNLogFile.Items.Add(HeaderItem)

            Dim TempValidPort As Integer = -1

            Dim ArchivedPathDirectory As String = Path.GetDirectoryName(My.Settings.FilePath)

            Dim ArchivedFilePath As String = ArchivedPathDirectory & "\service-logs.1.txt"

            If File.Exists(ArchivedFilePath) Then

                Dim ArchivedLogTempPort As Integer = ReadFile(ArchivedFilePath)

                If ArchivedLogTempPort >= 0 Then

                    TempValidPort = ArchivedLogTempPort

                Else

                    'No port data found

                End If

            Else

                If System.Diagnostics.Debugger.IsAttached Then

                    MessageBox.Show("Archived Log File Not Found")

                End If

            End If

            If File.Exists(My.Settings.FilePath) Then

                Dim PrimaryLogTempPort As Integer = ReadFile(My.Settings.FilePath)

                If PrimaryLogTempPort >= 0 Then

                    TempValidPort = PrimaryLogTempPort

                Else

                    'No port data found

                End If

            Else

                If System.Diagnostics.Debugger.IsAttached Then

                    MessageBox.Show("Primary Log File Not Found")

                End If

            End If

            VPNLogFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

            VPNLogFile.Items.RemoveAt(0)

            VPNLogFile.Items(VPNLogFile.Items.Count - 1).EnsureVisible()

            If TempValidPort >= 0 Then

                If LastValidPort <> TempValidPort Then

                    Dim Task = UpdatePort(TempValidPort)

                Else

                    LogOutput("Connected to qBittorrent, no changes to port detected", True, False)

                End If

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        Finally

            TestSaveButton.Enabled = True

            UpdateButton.Text = "Force Port Update Now"

            UpdateButton.Enabled = True

            MainTimer.Enabled = True

        End Try

    End Sub

    Private Function ReadFile(ByVal pPath As String) As Integer

        Try

            Dim TempPort As Integer = -1

            Dim LogFileSteam As New FileStream(pPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

            Dim LogFileStreamReader As New StreamReader(LogFileSteam)

            Dim Line As String = LogFileStreamReader.ReadLine

            Dim Lines As String() = {""}

            Dim Items As New List(Of ListViewItem)

            While Line IsNot Nothing

                If Line.Contains("Port pair") Then

                    'Get Date / Time

                    Dim LineArray1 As String() = Line.Split(" | ")

                    Dim First As String = LineArray1(0)

                    'End Get Date / Time

                    Dim LineArray2 As String() = Line.Split("Port pair")

                    Dim Secound As String = LineArray2(1)

                    Dim LineArray3 As String() = Secound.Split("->")

                    Dim Third As String = LineArray3(1)

                    Dim LineArray4 As String() = Third.Split(",")

                    Dim Fourth As String = LineArray4(0)

                    ReDim Preserve Lines(Lines.Length)

                    Lines(Lines.Length - 1) = (First & " | " & Fourth & " | " & Fourth.Count)

                    Dim NewItem As New ListViewItem(First)

                    NewItem.Tag = Line

                    NewItem.SubItems.Add(Fourth)

                    Dim IsParsed As Boolean = False

                    Dim CheckTempPort As Integer = -1

                    If Integer.TryParse(Fourth, CheckTempPort) Then

                        'Conversion succeeded

                        If CheckTempPort >= 0 Then

                            If CheckTempPort <= 65535 Then

                                IsParsed = True

                                TempPort = CheckTempPort

                            End If

                        End If

                    End If

                    NewItem.SubItems.Add(Fourth.Count)

                    NewItem.SubItems.Add(IsParsed)

                    Items.Add(NewItem)

                    'VPNLogFile.Items.Add(NewItem)

                End If

                Line = LogFileStreamReader.ReadLine

            End While

            VPNLogFile.Items.AddRange(Items.ToArray)

            LogFileStreamReader.Close()

            LogFileSteam.Close()

            Return TempPort

        Catch ex As Exception

            Return -1

        End Try

    End Function

    Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick

        Dim Task = CheckConnection()

    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)

        Dim org As FormWindowState = Me.WindowState

        MyBase.WndProc(m)

        If Me.WindowState <> org Then Me.OnFormWindowStateChanged(EventArgs.Empty)

    End Sub

    Protected Overridable Sub OnFormWindowStateChanged(ByVal e As EventArgs)

        If Me.WindowState = FormWindowState.Normal Then

            Me.ShowInTaskbar = True

            Me.Show()

            Me.BringToFront()

        Else

            Me.ShowInTaskbar = False

            Me.Hide()

        End If
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = New Size(400, 356)

        MainTabControl.SelectedIndex = 0

        NotifyIcon.ContextMenuStrip = TrayContextMenuStrip

        If My.Settings.FirstRun = True Then

            MessageBox.Show(AboutLabelProtonVPN.Text, "Disclaimer!")

            My.Settings.FirstRun = False

            My.Settings.Save()

            AddStartupEntry()

            Me.WindowState = FormWindowState.Normal

        End If

        If Not File.Exists(My.Settings.FilePath) Then

            Dim InstallLocationKeyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Proton VPN_is1"

            Using InstallLocationKey As RegistryKey = Registry.LocalMachine.OpenSubKey(InstallLocationKeyPath, False)

                If InstallLocationKey IsNot Nothing Then

                    Dim InstallLocationObject As Object = InstallLocationKey.GetValue("InstallLocation")

                    If InstallLocationObject IsNot Nothing AndAlso TypeOf InstallLocationObject Is String Then

                        Using VersionKey As RegistryKey = Registry.LocalMachine.OpenSubKey(InstallLocationKeyPath, False)

                            Dim VersionObject As Object = InstallLocationKey.GetValue("DisplayVersion")

                            If VersionObject IsNot Nothing AndAlso TypeOf VersionObject Is String Then

                                Dim LogFileLocation As String = InstallLocationObject & "v" & VersionObject & "\ServiceData\Logs\service-logs.txt"

                                If File.Exists(LogFileLocation) Then

                                    My.Settings.FilePath = LogFileLocation

                                    My.Settings.Save()

                                End If

                            End If

                        End Using

                    End If

                End If

            End Using

        End If

        If Not File.Exists(My.Settings.FilePath) Then

            SelectLogFileManually()

        End If

        If File.Exists(My.Settings.FilePath) Then

            LogFileSelectButton.Text = "ProtonVPN Log File Found!   (...)"

        End If

        HostTextBox.Text = My.Settings.Host

        UsernameTextBox.Text = My.Settings.Username

        PasswordTextBox.Text = My.Settings.Password

        Dim keyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run\"

        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(keyPath, False)

            If key IsNot Nothing Then

                Dim valueObject As Object = key.GetValue("Quantum")

                If valueObject IsNot Nothing Then

                    StartUpCheckBox.Checked = True

                End If

            End If

        End Using

        LogOutput("Quantum Started!", True, False)

        Dim Task = CheckConnection()

    End Sub

    Private Sub TestSaveButton_Click(sender As Object, e As EventArgs) Handles TestSaveButton.Click

        Dim Task = TestSaveSettings()

    End Sub

    Private Sub SelectLogFileManually()

        Try

            Dim LogicLocation As Boolean = False

            Dim LogicFileLocation As String = ""

            Dim InstallLocationKeyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Proton VPN_is1"

            Using InstallLocationKey As RegistryKey = Registry.LocalMachine.OpenSubKey(InstallLocationKeyPath, False)

                If InstallLocationKey IsNot Nothing Then

                    Dim InstallLocationObject As Object = InstallLocationKey.GetValue("InstallLocation")

                    If InstallLocationObject IsNot Nothing AndAlso TypeOf InstallLocationObject Is String Then

                        Using VersionKey As RegistryKey = Registry.LocalMachine.OpenSubKey(InstallLocationKeyPath, False)

                            Dim VersionObject As Object = InstallLocationKey.GetValue("DisplayVersion")

                            If VersionObject IsNot Nothing AndAlso TypeOf VersionObject Is String Then

                                LogicFileLocation = InstallLocationObject & "v" & VersionObject & "\ServiceData\Logs\service-logs.txt"

                                LogicLocation = True

                            End If

                        End Using

                    End If

                End If

            End Using

            Dim result As DialogResult

            If LogicLocation Then

                result = MessageBox.Show("Do you want to select a diffrent ProtonVPN log file location? Here is an example location of where you can find it: " & vbCrLf & LogicFileLocation, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Else

                result = MessageBox.Show("Do you want to select a diffrent ProtonVPN log file location? Here is an example location of where you can find it: " & vbCrLf & "C:\Program Files\Proton\VPN\v3.2.12\ServiceData\Logs\service-logs.txt", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            End If

            If result = DialogResult.Yes Then

                Dim LogFileOpenFileDialog As New OpenFileDialog()

                If LogicLocation Then

                    If File.Exists(LogicFileLocation) Then

                        LogFileOpenFileDialog.InitialDirectory = Path.GetDirectoryName(LogicFileLocation)

                    End If

                End If

                LogFileOpenFileDialog.Title = "Select the ProtonVPN log file"

                LogFileOpenFileDialog.Filter = "service-logs.txt | service-logs.txt"

                LogFileOpenFileDialog.Multiselect = False

                If LogFileOpenFileDialog.ShowDialog() = DialogResult.OK Then

                    My.Settings.FilePath = LogFileOpenFileDialog.FileName

                    My.Settings.Save()

                End If

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub
    Private Sub LogFileSelectButton_Click(sender As Object, e As EventArgs) Handles LogFileSelectButton.Click

        SelectLogFileManually()

    End Sub

    Private Sub LogOutput(ByVal pString As String, ByVal pLog As Boolean, ByVal pError As Boolean)

        Try

            If pLog = True Then

                Dim Ignore As Boolean = False

                If QLogFile.Items.Count > 0 Then

                    If QLogFile.Items.Item(QLogFile.Items.Count - 1).SubItems.Item(1).Text = pString Then

                        QLogFile.Items.Item(QLogFile.Items.Count - 1).SubItems.Item(0).Text = DateAndTime.Now.ToString

                        Ignore = True

                    End If

                End If

                If Not Ignore Then

                    Dim HeaderItem As New ListViewItem(DateAndTime.Now.ToString)

                    HeaderItem.SubItems.Add(pString)

                    QLogFile.Items.Add(HeaderItem)

                End If

                QLogFile.Items(QLogFile.Items.Count - 1).EnsureVisible()

                If QLogFile.Items.Count > 100 Then

                    QLogFile.Items.RemoveAt(0)

                End If

            End If

            If pError = True Then

                ToolStripStatusLabel.Text = "Error, check logs for more information - " & DateTime.Now.ToShortTimeString

            Else

                ToolStripStatusLabel.Text = pString & " - " & DateTime.Now.ToShortTimeString

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Main_Closing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.Closing

        If e.CloseReason <> CloseReason.WindowsShutDown Then

            e.Cancel = True

            Me.WindowState = FormWindowState.Minimized

        End If

    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.MouseDoubleClick

        If Me.WindowState = FormWindowState.Normal Then

            Me.Hide()

            Me.WindowState = FormWindowState.Minimized

        Else

            Me.Show()

            Me.WindowState = FormWindowState.Normal

        End If

    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click

        Try

            Dim Task = CheckConnection()

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        Finally

        End Try

    End Sub

    Private Sub VPNLogFile_DoubleClick(sender As Object, e As EventArgs) Handles VPNLogFile.DoubleClick

        Try

            If VPNLogFile.SelectedItems.Count > 0 Then

                MessageBox.Show(VPNLogFile.SelectedItems(0).Tag.ToString, "ProtonVPN Log File Entry")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PQLogFile_DoubleClick(sender As Object, e As EventArgs) Handles QLogFile.DoubleClick

        Try

            If QLogFile.SelectedItems.Count > 0 Then

                MessageBox.Show(QLogFile.SelectedItems(0).SubItems.Item(1).Text, "Quantum Log Entry - " & QLogFile.SelectedItems(0).SubItems.Item(0).Text)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub AddStartupEntry()

        Try

            Dim keyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(keyPath, True)

                If key IsNot Nothing Then

                    key.SetValue(Application.ProductName, Application.ExecutablePath)

                End If

            End Using

        Catch ex As Exception

            LogOutput(ex.Message, True, False)

        End Try

    End Sub

    Private Sub DeleteStartupEntry()

        Try

            Dim keyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(keyPath, True)

                If key IsNot Nothing Then

                    key.DeleteValue(Application.ProductName, False)

                End If

            End Using

        Catch ex As Exception

            LogOutput(ex.Message, True, False)

        End Try

    End Sub

    Private Sub StartUpCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles StartUpCheckBox.CheckedChanged

        If StartUpCheckBox.Checked Then

            AddStartupEntry()

        Else

            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the startup entry?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then

                DeleteStartupEntry()

            Else

                StartUpCheckBox.Checked = True

            End If

        End If

    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click

        Me.WindowState = FormWindowState.Normal

        Me.Show()

        Me.BringToFront()

        Me.ShowInTaskbar = True

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        Application.Exit()

    End Sub

    Private LogScalingSet As Boolean = False

    Private Sub Main_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

        If Not LogScalingSet Then

            If Me.Visible Then

                Dim HeaderItem As New ListViewItem(DateTime.Now.ToString)

                HeaderItem.SubItems.Add(QLogFile.Columns.Item(1).Text)

                QLogFile.Items.Add(HeaderItem)

                QLogFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

                QLogFile.Items.RemoveAt(0)

                QEvent.Width = QLogFile.ClientSize.Width - QDateTime.Width - SystemInformation.VerticalScrollBarWidth - 2

                LogScalingSet = True

            End If

        End If

    End Sub

End Class
