Imports System.IO
Imports Microsoft.Win32
Imports QBittorrent.Client

Public Class Main

    ' Last valid port captured port from logs or qBittorrent
    Private LastValidPort As Integer = -1

    ' Test connection to qBittorrent
    Private Async Function CheckConnection() As Task

        Try

            ' Clear the log display
            VPNLogFile.Items.Clear()

            ' Open a new connection to qBittorrnet
            Dim client = New QBittorrentClient(New Uri(My.Settings.Host))

            ' Pass user/pass if needed
            Await client.LoginAsync(My.Settings.Username, My.Settings.Password)

            ' Get current preferences
            Dim prefs = New Preferences()
            prefs = Await client.GetPreferencesAsync()

            ' Read current qBittorrent port
            LastValidPort = prefs.ListenPort

            ' Check logs for updated port
            CheckForChange()

        Catch ex As Exception

            LogOutput("qBittorrent error: " & ex.Message, True, True)

        Finally

            ' Ensure timer is running
            MainTimer.Enabled = True

        End Try

    End Function

    ' Test host, user and pass, save if valid
    Private Async Function TestSaveSettings() As Task

        Try

            ' Open a new connection to qBittorrnet
            Dim client = New QBittorrentClient(New Uri(HostTextBox.Text))

            ' Pass user/pass if needed
            Await client.LoginAsync(UsernameTextBox.Text, PasswordTextBox.Text)

            ' Get current preferences
            Dim prefs = New Preferences()
            prefs = Await client.GetPreferencesAsync()

            ' Read current qBittorrent port
            LastValidPort = prefs.ListenPort

            ' If connection doesnt throw an exception then the configuration if good, save settings
            My.Settings.Host = HostTextBox.Text
            My.Settings.Username = UsernameTextBox.Text
            My.Settings.Password = PasswordTextBox.Text
            My.Settings.Save()

            LogOutput("Connected to qBittorrent, settings saved!", True, False)

            ' Let the user know connection is successful
            Dim result As DialogResult = MessageBox.Show("Connected to qBittorrent, settings saved!")

            ' Check logs for updated port, this will also start the timer
            CheckForChange()

        Catch ex As Exception

            LogOutput("qBittorrent error: " & ex.Message, True, True)

            MessageBox.Show("qBittorrent error: " & ex.Message)

        End Try

    End Function

    ' Pass the pPort param to qBittorrent
    Private Async Function UpdatePort(ByVal pPort As Integer) As Task

        Try

            ' Open a new connection to qBittorrnet
            Dim client = New QBittorrentClient(New Uri(My.Settings.Host))

            ' Pass user/pass if needed
            Await client.LoginAsync(My.Settings.Username, My.Settings.Password)

            ' Get current preferences
            Dim prefs = New Preferences()
            prefs = Await client.GetPreferencesAsync()

            ' Update qBittorrent port with passed param
            prefs.ListenPort = pPort

            ' Push settings to qBittorrnet
            Await client.SetPreferencesAsync(prefs)

            ' If no exception then save the port
            LastValidPort = pPort

            LogOutput("Updated qBittorrent port to " & LastValidPort, True, False)

        Catch ex As Exception

            LogOutput("qBittorrent error: " & ex.Message, True, True)

        End Try

    End Function

    Private Sub CheckForChange()

        Try

            ' Ensure timer is running
            MainTimer.Enabled = False

            ' Update UI
            TestSaveButton.Enabled = False
            UpdateButton.Text = "Reading log file..."
            UpdateButton.Enabled = False

            LogOutput("Reading log file...", False, False)

            ' Clear all exisitng log entries
            VPNLogFile.Items.Clear()

            ' Add dummy entries for column sizing

            ' Date/Time
            Dim HeaderItem As New ListViewItem(VPNLogFile.Columns.Item(0).Text)

            ' Port number
            HeaderItem.SubItems.Add(VPNLogFile.Columns.Item(1).Text)

            ' Port length
            HeaderItem.SubItems.Add(VPNLogFile.Columns.Item(2).Text)

            ' Valid
            HeaderItem.SubItems.Add(VPNLogFile.Columns.Item(3).Text)

            VPNLogFile.Items.Add(HeaderItem)

            ' Temp port as negative value
            Dim TempValidPort As Integer = -1

            ' Get the log file directory from the filepath
            Dim ArchivedPathDirectory As String = Path.GetDirectoryName(My.Settings.FilePath)

            ' Get the oldest log file first, this is allways service-logs.1.txt if it exisits
            Dim ArchivedFilePath As String = ArchivedPathDirectory & "\service-logs.1.txt"

            ' If log exisits start to process
            If File.Exists(ArchivedFilePath) Then

                ' Read log
                Dim ArchivedLogTempPort As Integer = ReadFile(ArchivedFilePath)

                ' If valid port then update temp
                If ArchivedLogTempPort >= 0 Then

                    TempValidPort = ArchivedLogTempPort

                Else

                    ' No port data found

                End If

            Else

                ' Here for debugging
                If System.Diagnostics.Debugger.IsAttached Then

                    MessageBox.Show("Archived Log File Not Found")

                End If

            End If

            ' Get the log file directory from the filepath, if it exisits process
            If File.Exists(My.Settings.FilePath) Then

                ' Read log
                Dim PrimaryLogTempPort As Integer = ReadFile(My.Settings.FilePath)

                ' If valid port then update temp
                If PrimaryLogTempPort >= 0 Then

                    TempValidPort = PrimaryLogTempPort

                Else

                    ' No port data found

                End If

            Else

                ' Here for debugging
                If System.Diagnostics.Debugger.IsAttached Then

                    MessageBox.Show("Primary Log File Not Found")

                End If

            End If

            ' Adjust column size
            VPNLogFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

            ' Remove headers
            VPNLogFile.Items.RemoveAt(0)

            ' Highlists bottom row
            If (VPNLogFile.Items.Count) > 0 Then

                VPNLogFile.Items(VPNLogFile.Items.Count - 1).EnsureVisible()

            End If

            ' Do checks on port validity
            If TempValidPort >= 0 Then

                If LastValidPort <> TempValidPort Then

                    ' Call task to push port update
                    Dim Task = UpdatePort(TempValidPort)

                Else

                    LogOutput("Connected to qBittorrent, no changes to port detected", True, False)

                End If

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        Finally

            ' Update UI
            TestSaveButton.Enabled = True
            UpdateButton.Text = "Force Port Update Now"
            UpdateButton.Enabled = True

            ' Ensure timer is running
            MainTimer.Enabled = True

        End Try

    End Sub

    Private Function ReadFile(ByVal pPath As String) As Integer

        Try

            ' Temp port as negative value
            Dim TempPort As Integer = -1

            ' Open file stream as read only
            Dim LogFileSteam As New FileStream(pPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

            Dim LogFileStreamReader As New StreamReader(LogFileSteam)

            ' Read first line
            Dim Line As String = LogFileStreamReader.ReadLine

            ' Setup arrays
            Dim Lines As String() = {""}
            Dim Items As New List(Of ListViewItem)

            ' If we still have a valid line
            While Line IsNot Nothing

                ' Check for the string "Port pair"
                If Line.Contains("Port pair") Then

                    'Get Date / Time, read as item to the left of the slip
                    Dim DateTimeArray As String() = Line.Split(" | ")
                    Dim DateTime As String = DateTimeArray(0)

                    ' Get string to the right of the "Port pair"
                    Dim PortPairArray As String() = Line.Split("Port pair")
                    Dim PortPair As String = PortPairArray(1)

                    ' Get string to the right of "->"
                    Dim ForwardArray As String() = PortPair.Split("->")
                    Dim Forward As String = ForwardArray(1)

                    ' Get string to the left of ",", this value is the port number as a string
                    Dim PortStringArray As String() = Forward.Split(",")
                    Dim PortString As String = PortStringArray(0)

                    ' Redim the array
                    ReDim Preserve Lines(Lines.Length)

                    ' Add to array
                    Lines(Lines.Length - 1) = (DateTime & " | " & PortString & " | " & PortString.Count)

                    ' Create new listviewitem
                    Dim NewItem As New ListViewItem(DateTime)

                    ' Add the line to the listviewitem tag, used for double click on listviewitem, displays full line
                    NewItem.Tag = Line

                    ' Set port string so subitem
                    NewItem.SubItems.Add(PortString)

                    ' Validate the port string
                    Dim IsParsed As Boolean = False
                    Dim CheckTempPort As Integer = -1

                    If Integer.TryParse(PortString, CheckTempPort) Then

                        'Conversion succeeded

                        If CheckTempPort >= 0 Then

                            If CheckTempPort <= 65535 Then

                                'Port is valid
                                IsParsed = True
                                TempPort = CheckTempPort

                            End If

                        End If

                    End If

                    ' Add subitems
                    NewItem.SubItems.Add(PortString.Count)
                    NewItem.SubItems.Add(IsParsed)

                    ' Add to items
                    Items.Add(NewItem)

                End If

                Line = LogFileStreamReader.ReadLine

            End While

            ' Add items to listview
            VPNLogFile.Items.AddRange(Items.ToArray)

            ' Close access to log file
            LogFileStreamReader.Close()
            LogFileSteam.Close()

            ' Return the port number
            Return TempPort

        Catch ex As Exception

            ' Return invalid port number
            Return -1

        End Try

    End Function

    Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick

        ' Process task
        Dim Task = CheckConnection()

    End Sub

    ' Extra WndProc funcationality
    Protected Overrides Sub WndProc(ByRef m As Message)

        Dim org As FormWindowState = Me.WindowState
        MyBase.WndProc(m)
        If Me.WindowState <> org Then Me.OnFormWindowStateChanged(EventArgs.Empty)

    End Sub

    ' Makes sure the problem minimizes to/from the system tray
    Protected Overridable Sub OnFormWindowStateChanged(ByVal e As EventArgs)

        If Me.WindowState = FormWindowState.Normal Then

            ' Show the main program window
            Me.ShowInTaskbar = True
            Me.Show()
            Me.BringToFront()

        Else

            ' Hide to the system tray
            Me.ShowInTaskbar = False
            Me.Hide()

        End If
    End Sub

    'Runs as prgoram startup
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the main form size
        Me.Size = New Size(400, 356)

        ' Make sure the first tab is selected
        MainTabControl.SelectedIndex = 0

        ' Set the systemtray right click menu
        NotifyIcon.ContextMenuStrip = TrayContextMenuStrip

        ' If this is the first time the problem has been run
        If My.Settings.FirstRun = True Then

            ' Show program disclaimer
            MessageBox.Show(AboutLabelProtonVPN.Text, "Disclaimer!")

            ' Update settings so this message is not shown again
            My.Settings.FirstRun = False
            My.Settings.Save()

            ' Add the program to autorun
            AddStartupEntry()

        End If

        ' If no log file can be found search the registry to find it
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

                                ' If log file found via registry
                                If File.Exists(LogFileLocation) Then

                                    ' Update settings and save
                                    My.Settings.FilePath = LogFileLocation
                                    My.Settings.Save()

                                End If

                            End If

                        End Using

                    End If

                End If

            End Using

        End If

        ' If log file still does not exist
        If Not File.Exists(My.Settings.FilePath) Then

            ' Prompt the user to locate the log file
            SelectLogFileManually()

        End If

        If File.Exists(My.Settings.FilePath) Then

            ' If log file found update the UI
            LogFileSelectButton.Text = "ProtonVPN Log File Found!   (...)"

        End If

        ' Update UI with saved host/user/pass
        HostTextBox.Text = My.Settings.Host
        UsernameTextBox.Text = My.Settings.Username
        PasswordTextBox.Text = My.Settings.Password

        ' Check registry for autorun and update UI
        Dim keyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run\"

        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(keyPath, False)

            If key IsNot Nothing Then

                Dim valueObject As Object = key.GetValue("Quantum")

                If valueObject IsNot Nothing Then

                    ' Program is set to autorun
                    StartUpCheckBox.Checked = True

                End If

            End If

        End Using

        LogOutput("Quantum Started!", True, False)

        ' Call task to check for a qBittorrent connection
        Dim Task = CheckConnection()

    End Sub

    ' User clicked Test/Save button
    Private Sub TestSaveButton_Click(sender As Object, e As EventArgs) Handles TestSaveButton.Click

        ' Call task to test then save settings
        Dim Task = TestSaveSettings()

    End Sub

    ' Pormpts the user to find the ProtonVPN log file
    Private Sub SelectLogFileManually()

        Try


            ' See if we can get any information from the registry so we can provide default dir and path example
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

                                ' We found some infromation we can use
                                LogicLocation = True

                            End If

                        End Using

                    End If

                End If

            End Using

            Dim result As DialogResult

            If LogicLocation Then

                ' Show a yes/no dialog with a logic path example
                result = MessageBox.Show("Do you want to select a diffrent ProtonVPN log file location? Here is an example location of where you can find it: " & vbCrLf & LogicFileLocation, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Else

                ' Show a yes/no dialog with a static path example 
                result = MessageBox.Show("Do you want to select a diffrent ProtonVPN log file location? Here is an example location of where you can find it: " & vbCrLf & "C:\Program Files\Proton\VPN\v3.2.12\ServiceData\Logs\service-logs.txt", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            End If

            If result = DialogResult.Yes Then

                ' User wants to locate log file
                Dim LogFileOpenFileDialog As New OpenFileDialog()

                If LogicLocation Then

                    If File.Exists(LogicFileLocation) Then

                        ' Set the inital dir if we have logic
                        LogFileOpenFileDialog.InitialDirectory = Path.GetDirectoryName(LogicFileLocation)

                    End If

                End If

                ' Setup file select dialog settings
                LogFileOpenFileDialog.Title = "Select the ProtonVPN log file"
                LogFileOpenFileDialog.Filter = "service-logs.txt | service-logs.txt"
                LogFileOpenFileDialog.Multiselect = False

                ' Show file select prompt
                If LogFileOpenFileDialog.ShowDialog() = DialogResult.OK Then

                    ' User has selected valid log file
                    My.Settings.FilePath = LogFileOpenFileDialog.FileName
                    My.Settings.Save()

                End If

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' User clicked log file selcect button
    Private Sub LogFileSelectButton_Click(sender As Object, e As EventArgs) Handles LogFileSelectButton.Click

        ' Show prompt
        SelectLogFileManually()

    End Sub

    ' Quantum log filter
    Private Sub LogOutput(ByVal pString As String, ByVal pLog As Boolean, ByVal pError As Boolean)

        Try

            ' Do we want to log this information?
            If pLog = True Then

                Dim Ignore As Boolean = False

                If QLogFile.Items.Count > 0 Then

                    If QLogFile.Items.Item(QLogFile.Items.Count - 1).SubItems.Item(1).Text = pString Then

                        ' Event is the same as the last log entry, update the existing entrys date/time
                        QLogFile.Items.Item(QLogFile.Items.Count - 1).SubItems.Item(0).Text = DateAndTime.Now.ToString
                        Ignore = True

                    End If

                End If

                If Not Ignore Then

                    ' New event
                    Dim HeaderItem As New ListViewItem(DateAndTime.Now.ToString)
                    HeaderItem.SubItems.Add(pString)
                    QLogFile.Items.Add(HeaderItem)

                End If

                ' Select the bottom entry
                QLogFile.Items(QLogFile.Items.Count - 1).EnsureVisible()

                ' Dont show more then 100 entries
                If QLogFile.Items.Count > 100 Then

                    QLogFile.Items.RemoveAt(0)

                End If

            End If

            ' Are we logging an error?
            If pError = True Then

                ' Update toolstrip
                ToolStripStatusLabel.Text = "Error, check logs for more information - " & DateTime.Now.ToShortTimeString

            Else

                ' Update toolstrip
                ToolStripStatusLabel.Text = pString & " - " & DateTime.Now.ToShortTimeString

            End If

        Catch ex As Exception

        End Try

    End Sub

    ' User closed window or application is shutting down
    Private Sub Main_Closing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.Closing

        ' If we are not logging off, or shutting down
        If e.CloseReason <> CloseReason.WindowsShutDown Then

            ' Cancel closing the applcation and minimize to tray
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized

        End If

    End Sub

    ' User double clicked the Quantum icon in the system tray
    Private Sub NotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.MouseDoubleClick

        ' If we are currently on screen
        If Me.WindowState = FormWindowState.Normal Then

            ' Hide to system tray
            Me.Hide()
            Me.WindowState = FormWindowState.Minimized

        Else

            ' Currently in the system tray, popup on desktop
            Me.Show()
            Me.WindowState = FormWindowState.Normal

        End If

    End Sub

    ' User clicked Update button
    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click

        Try

            ' Call task to test connection, this allways checks for an updated port
            Dim Task = CheckConnection()

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        Finally

        End Try

    End Sub

    ' User clicks a log entry for the ProtonVPN log
    Private Sub VPNLogFile_DoubleClick(sender As Object, e As EventArgs) Handles VPNLogFile.DoubleClick

        Try

            If VPNLogFile.SelectedItems.Count > 0 Then

                ' Display the full unparsed line
                MessageBox.Show(VPNLogFile.SelectedItems(0).Tag.ToString, "ProtonVPN Log File Entry")

            End If

        Catch ex As Exception

        End Try

    End Sub

    ' User clicks a log entry for the Quantum log
    Private Sub PQLogFile_DoubleClick(sender As Object, e As EventArgs) Handles QLogFile.DoubleClick

        Try

            If QLogFile.SelectedItems.Count > 0 Then

                ' Display the log entry
                MessageBox.Show(QLogFile.SelectedItems(0).SubItems.Item(1).Text, "Quantum Log Entry - " & QLogFile.SelectedItems(0).SubItems.Item(0).Text)

            End If

        Catch ex As Exception

        End Try

    End Sub

    ' Add Quantum to the autorun registry
    Private Sub AddStartupEntry()

        Try

            Dim keyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(keyPath, True)

                ' If run exists
                If key IsNot Nothing Then

                    ' Add applcation to autorun
                    key.SetValue(Application.ProductName, Application.ExecutablePath)

                End If

            End Using

        Catch ex As Exception

            LogOutput(ex.Message, True, False)

        End Try

    End Sub

    ' Removes Quantum from the autorun registry
    Private Sub DeleteStartupEntry()

        Try

            Dim keyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(keyPath, True)

                ' If run exists
                If key IsNot Nothing Then

                    ' Remove applcation from autorun
                    key.DeleteValue(Application.ProductName, False)

                End If

            End Using

        Catch ex As Exception

            LogOutput(ex.Message, True, False)

        End Try

    End Sub

    ' User clicked autorun at startup checkbox
    Private Sub StartUpCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles StartUpCheckBox.CheckedChanged

        ' User enable autorun
        If StartUpCheckBox.Checked Then

            ' Add to registry
            AddStartupEntry()

        Else

            ' Prompt the user is sure they want to remove autorun
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the startup entry?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then

                ' Delete from registry
                DeleteStartupEntry()

            Else

                ' User selected not to remove from registry, add the checkmark back
                StartUpCheckBox.Checked = True

            End If

        End If

    End Sub

    ' User selected to exit applcation
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        ' Shutdown Quantum
        Application.Exit()

    End Sub

    ' UI Scaling adjustment
    Private LogScalingSet As Boolean = False

    ' Runs when the form is visiable, adjusts columns for better fit
    Private Sub Main_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

        ' Have we already done this?
        If Not LogScalingSet Then

            ' Make sure the form is visible, need to be on screen to work correctly
            If Me.Visible Then

                Dim HeaderItem As New ListViewItem(DateTime.Now.ToString)
                HeaderItem.SubItems.Add(QLogFile.Columns.Item(1).Text)

                ' Add dummy item to listview
                QLogFile.Items.Add(HeaderItem)

                ' Auto resize columns
                QLogFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

                ' Remove dummy
                QLogFile.Items.RemoveAt(0)

                ' Adjust for scrollbar
                QEvent.Width = QLogFile.ClientSize.Width - QDateTime.Width - SystemInformation.VerticalScrollBarWidth - 2

                ' Completed, doesnt need to be done again
                LogScalingSet = True

            End If

        End If

    End Sub

End Class
