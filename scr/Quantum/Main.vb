Imports System.IO
Imports Microsoft.Win32
Imports QBittorrent.Client
Imports GitHubUpdate

Public Class Main

    ' Counter for the timer
    Private TimerCount As Integer = 0

    ' Last valid port captured port from logs or qBittorrent
    Private LastValidPort As Integer = -1

    ' UI Scaling adjustment
    Private LogScalingSet As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ' Test connection to qBittorrent
    Private Async Function CheckConnection() As Task

        Try

            ' Clear the log display
            LV_VPNLogFile.Items.Clear()

            ' Open a new connection to qBittorrnet
            Dim Client = New QBittorrentClient(New Uri(My.Settings.Host))

            ' Pass user/pass if needed
            Await Client.LoginAsync(My.Settings.Username, My.Settings.Password)

            ' Get current preferences
            Dim Prefs = New Preferences()
            Prefs = Await Client.GetPreferencesAsync()

            ' Read current qBittorrent port
            LastValidPort = Prefs.ListenPort

            ' Check logs for updated port
            CheckForChange()

        Catch ex As Exception

            LogOutput("qBittorrent error: " & ex.Message, True, True)

        Finally

            ' Ensure timer is enabled
            TMR_Main.Enabled = True

        End Try

    End Function

    ' Test host, user and pass, save if valid, CheckForChange will start the timer
    Private Async Function TestSaveSettings() As Task

        Try

            ' Open a new connection to qBittorrnet
            Dim Client = New QBittorrentClient(New Uri(TXT_Host.Text))

            ' Pass user/pass if needed
            Await Client.LoginAsync(TXT_Username.Text, TXT_Password.Text)

            ' Get current preferences
            Dim Prefs = New Preferences()
            Prefs = Await Client.GetPreferencesAsync()

            ' Read current qBittorrent port
            LastValidPort = Prefs.ListenPort

            ' If connection doesnt throw an exception then the configuration if good, save settings
            My.Settings.Host = TXT_Host.Text
            My.Settings.Username = TXT_Username.Text
            My.Settings.Password = TXT_Password.Text
            My.Settings.Save()

            LogOutput("Connected to qBittorrent, settings saved!", True, False)

            ' Let the user know connection is successful
            Dim Result As DialogResult = MessageBox.Show("Connected to qBittorrent, settings saved!")

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
            Dim Client = New QBittorrentClient(New Uri(My.Settings.Host))

            ' Pass user/pass if needed
            Await Client.LoginAsync(My.Settings.Username, My.Settings.Password)

            ' Get current preferences
            Dim Prefs = New Preferences()
            Prefs = Await Client.GetPreferencesAsync()

            ' Update qBittorrent port with passed param
            Prefs.ListenPort = pPort

            ' Push settings to qBittorrnet
            Await Client.SetPreferencesAsync(Prefs)

            ' If no exception then save the port
            LastValidPort = pPort

            LogOutput("Updated qBittorrent port to " & LastValidPort, True, False)

        Catch ex As Exception

            LogOutput("qBittorrent error: " & ex.Message, True, True)

        End Try

    End Function

    Private Sub CheckForChange()

        Try

            ' Disable the test/save/update button
            BTN_TestSaveUpdate.Enabled = False

            ' Ensure timer is disabled
            TMR_Main.Enabled = False

            ' Reset the counter
            TimerCount = 0

            ' Reset the progressbar
            PRG_Main.Value = 0

            ' Update UI
            BTN_TestSaveUpdate.Enabled = False
            BTN_TestSaveUpdate.Text = "Reading log file..."

            LogOutput("Reading log file...", False, False)

            ' Clear all exisitng log entries
            LV_VPNLogFile.Items.Clear()

            ' Add dummy entries for column sizing

            ' Date/Time
            Dim HeaderItem As New ListViewItem(LV_VPNLogFile.Columns.Item(0).Text)

            ' Port number
            HeaderItem.SubItems.Add(LV_VPNLogFile.Columns.Item(1).Text)

            ' Valid
            HeaderItem.SubItems.Add(LV_VPNLogFile.Columns.Item(2).Text)

            LV_VPNLogFile.Items.Add(HeaderItem)

            ' Temp port as negative value
            Dim TempValidPort As Integer = -1

            ' Are we locating the log file automaticlly?
            If My.Settings.AutoFindLog = True Then

                SetAutoLogFileLocation()

            End If

            ' Get the log file directory from the filepath, if it exisits process
            If File.Exists(My.Settings.FilePath) Then

                ' Read log
                Dim PrimaryLogTempPort As Integer = ReadLogFile(My.Settings.FilePath)

                ' If valid port then update temp
                If PrimaryLogTempPort >= 0 Then

                    TempValidPort = PrimaryLogTempPort

                Else

                    ' No port data found

                    ' Get the log file directory from the filepath
                    Dim ArchivedPathDirectory As String = Path.GetDirectoryName(My.Settings.FilePath)

                    ' Get the oldest log file first, this is allways service-logs.1.txt if it exisits
                    Dim ArchivedFilePath As String = ArchivedPathDirectory & "\service-logs.1.txt"

                    ' If log exisits start to process
                    If File.Exists(ArchivedFilePath) Then

                        ' Read log
                        Dim ArchivedLogTempPort As Integer = ReadLogFile(ArchivedFilePath)

                        ' If valid port then update temp
                        If ArchivedLogTempPort >= 0 Then

                            TempValidPort = ArchivedLogTempPort

                        Else

                            ' No port data found

                        End If

                    End If

                End If

                ' Adjust column size
                LV_VPNLogFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

                ' Remove headers
                LV_VPNLogFile.Items.RemoveAt(0)

                ' Ensures last row is visible
                If (LV_VPNLogFile.Items.Count) > 0 Then

                    LV_VPNLogFile.Items(LV_VPNLogFile.Items.Count - 1).EnsureVisible()

                End If

                ' Do checks on port validity
                If TempValidPort >= 0 Then

                    If LastValidPort <> TempValidPort Then

                        ' Call task to push port update
                        Dim DoTask As Task = UpdatePort(TempValidPort)

                    Else

                        LogOutput("Connected to qBittorrent, no changes to port detected", True, False)

                    End If

                Else

                    LogOutput("No valid port information found in logs", True, False)

                End If

                GB_ProtonLog.Text = "ProtonVPN Log Files Output (Parsed) " & DateTime.Now

            Else

                ' ProtonVPN log files not found
                LogOutput("Cannot locate ProtonVPN log files", True, False)
                GB_ProtonLog.Text = "ProtonVPN Log Files Output (Parsed)"

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        Finally

            ' Update UI
            UpdateSelectButton()
            BTN_TestSaveUpdate.Enabled = True
            UpdateConnectionUI()

            ' Ensure timer is enabled
            TMR_Main.Enabled = True

        End Try

    End Sub

    Private Function ReadLogFile(ByVal pPath As String) As Integer

        Try

            ' Temp port as negative value
            Dim TempPort As Integer = -1

            ' Open file stream as read only
            Dim LogFileSteam As New FileStream(pPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

            Dim LogFileStreamReader As New StreamReader(LogFileSteam)

            ' List to store the lines
            Dim Lines As New List(Of String)()

            ' Read first line
            Dim Line As String = LogFileStreamReader.ReadLine

            ' If we still have a valid line
            While Line IsNot Nothing

                ' Add the line to the array
                Lines.Add(Line)

                ' Read the next line
                Line = LogFileStreamReader.ReadLine

            End While

            ' Close access to log file
            LogFileStreamReader.Close()
            LogFileSteam.Close()

            ' Setup list/array
            Dim Items As New List(Of ListViewItem)

            For i As Integer = Lines.Count - 1 To 0 Step -1

                Line = (Lines(i))

                ' Check for the string "Port pair", this is the primary flag
                If Line.Contains("Port pair") Then

                    ' Check for the string " | "
                    If Line.Contains(" | ") Then

                        'Get Date / Time, read as item to the left of the slip
                        Dim DateTimeArray As String() = Line.Split(" | ")
                        Dim DateTime As String = DateTimeArray(0)

                        ' Get string to the right of the "Port pair", we have already checked that this string exists in the code above (primary flag)
                        Dim PortPairArray As String() = Line.Split("Port pair")
                        Dim PortPair As String = PortPairArray(1)

                        ' Check for the string "->"
                        If PortPair.Contains("->") Then

                            ' Get string to the right of "->"
                            Dim ForwardArray As String() = PortPair.Split("->")
                            Dim Forward As String = ForwardArray(1)

                            ' Check for the string ","
                            If Forward.Contains(","c) Then

                                ' Get string to the left of ",", this value is the port number as a string
                                Dim PortStringArray As String() = Forward.Split(",")
                                Dim PortString As String = PortStringArray(0)

                                ' Create new listviewitem
                                ' Add the line to the listviewitem tag, used for double click on listviewitem, displays full line
                                Dim NewItem As New ListViewItem(DateTime) With {
                                    .Tag = Line
                                }

                                ' Set port string so subitem
                                NewItem.SubItems.Add(PortString)

                                ' Validate the port string
                                Dim CheckTempPort As Integer = -1
                                Dim ValidPort As Boolean = False

                                If Integer.TryParse(PortString, CheckTempPort) Then

                                    'Conversion succeeded

                                    ' Minimum port value
                                    If CheckTempPort >= 0 Then

                                        'Highest port value
                                        If CheckTempPort <= 65535 Then

                                            'Port is valid
                                            TempPort = CheckTempPort
                                            ValidPort = True

                                        End If

                                    End If

                                End If

                                ' Set validport to subitem
                                NewItem.SubItems.Add(ValidPort)

                                ' Add to items
                                Items.Add(NewItem)

                                If ValidPort Then

                                    ' We have a valid port, exit the loop
                                    Exit For

                                End If

                            End If

                        End If

                    End If

                End If

            Next

            ' Add items to listview
            LV_VPNLogFile.Items.AddRange(Items.ToArray)

            ' Return the port number
            Return TempPort

        Catch ex As Exception

            ' Return invalid port number
            Return -1

        End Try

    End Function

    Private Sub TMR_Main_Tick(sender As Object, e As EventArgs) Handles TMR_Main.Tick

        Try

            ' Increment the counter
            TimerCount += 1

            ' 60 ticks is 1 min
            If TimerCount = 60 Then

                ' Process task
                Dim DoTask As Task = CheckConnection()

            End If

            ' At 61 we reset the counter
            If TimerCount >= 61 Then

                ' Reset the counter
                TimerCount = 0

            End If

            ' Update the progressbar
            PRG_Main.Value = TimerCount

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' Extra WndProc funcationality
    Protected Overrides Sub WndProc(ByRef m As Message)

        Try

            ' Raise window event
            Dim State As FormWindowState = Me.WindowState
            MyBase.WndProc(m)
            If Me.WindowState <> State Then Me.OnFormWindowStateChanged(EventArgs.Empty)

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' Makes sure the problem minimizes to/from the system tray
    Protected Overridable Sub OnFormWindowStateChanged(ByVal e As EventArgs)

        Try

            ' Check the window state
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

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' Runs at program startup
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            ' Are we upgrading from an older version of Quantum?
            If My.Settings.UpgradeRequired Then

                ' Copy settings from previous version
                My.Settings.Upgrade()
                My.Settings.UpgradeRequired = False

                My.Settings.Save()

            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        Try

            ' Set tooltip for custom checkbox
            TBE_Startup.SetToolTip(TT_Main)
            TBE_LogFile.SetToolTip(TT_Main)

            ' Set the main form title with version number
            Me.Text = My.Application.Info.AssemblyName & " - v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build

            ' Set the main form size
            Me.Size = New Size(433, 433)

            ' Make sure the first tab is selected
            TAB_Main.SelectedIndex = 0

            ' Set the systemtray right click menu
            NI_Main.ContextMenuStrip = CMS_Main

            ' If this is the first time the problem has been run
            If My.Settings.FirstRun = True Then

                ' Show program disclaimer
                MessageBox.Show(LNK_AboutProtonVPN.Text, "Disclaimer!")

                ' Update settings so this message is not shown again
                My.Settings.FirstRun = False
                My.Settings.Save()

                ' Add the program to autorun
                AddStartupEntry()

                ' Popup on screen
                Me.WindowState = FormWindowState.Normal
                Me.Show()

            Else

                Me.Close()

            End If

            ' Are we locating the ProtonVPN log files automaticlly?
            If My.Settings.AutoFindLog = True Then

                TBE_LogFile.Checked = True

                SetAutoLogFileLocation()

            End If

            ' If log file still does not exist
            If Not File.Exists(My.Settings.FilePath) Then

                ' If Quantum is not trying to find the log file automaticlly
                If My.Settings.AutoFindLog = False Then

                    ' Prompt the user to locate the log file
                    SelectLogFileManually(True)

                End If

            End If

            ' Update the select button UI
            UpdateSelectButton()

            ' Update UI with saved host/user/pass
            TXT_Host.Text = My.Settings.Host
            TXT_Username.Text = My.Settings.Username
            TXT_Password.Text = My.Settings.Password

            ' Check registry for autorun and update UI
            Dim KeyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run\"

            Using Key As RegistryKey = Registry.CurrentUser.OpenSubKey(KeyPath, False)

                If Key IsNot Nothing Then

                    Dim ValueObject As Object = Key.GetValue("Quantum")

                    If ValueObject IsNot Nothing Then

                        ' Program is set to autorun
                        TBE_Startup.Checked = True

                    End If

                End If

            End Using

            UpdateConnectionUI()

            LogOutput("Quantum Started!", True, False)

            ' Call task to check for a qBittorrent connection
            Dim DoTask As Task = CheckConnection()

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    Private Sub SetAutoLogFileLocation()

        Try

            ' This is the registry folder used by ProtonVPN to store install information
            Dim InstallLocationKeyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Proton VPN_is1"

            Using InstallLocationKey As RegistryKey = Registry.LocalMachine.OpenSubKey(InstallLocationKeyPath, False)

                If InstallLocationKey IsNot Nothing Then

                    ' Get the install location
                    Dim InstallLocationObject As Object = InstallLocationKey.GetValue("InstallLocation")

                    If InstallLocationObject IsNot Nothing AndAlso TypeOf InstallLocationObject Is String Then

                        Using VersionKey As RegistryKey = Registry.LocalMachine.OpenSubKey(InstallLocationKeyPath, False)

                            ' Get the current PrtonVPN vesion
                            Dim VersionObject As Object = InstallLocationKey.GetValue("DisplayVersion")

                            If VersionObject IsNot Nothing AndAlso TypeOf VersionObject Is String Then

                                ' Combine found information into file path
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

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' Sets the label for the LogFile button
    Private Sub UpdateSelectButton()

        Try

            If File.Exists(My.Settings.FilePath) Then

                If My.Settings.AutoFindLog = True Then

                    ' If log file found update the UI
                    BTN_LogFile.Text = "ProtonVPN Log Files Found!"

                    BTN_LogFile.Enabled = False

                    ' Update the tooltips
                    TT_Main.SetToolTip(TBE_LogFile, My.Settings.FilePath)
                    TT_Main.SetToolTip(BTN_LogFile, "")

                Else

                    ' If log file found update the UI
                    BTN_LogFile.Text = "ProtonVPN Log Files Found!   (...)"

                    BTN_LogFile.Enabled = True

                    ' Update the tooltips
                    TT_Main.SetToolTip(TBE_LogFile, "Enabling this setting is recommended")
                    TT_Main.SetToolTip(BTN_LogFile, My.Settings.FilePath)

                End If

            Else

                If My.Settings.AutoFindLog = True Then

                    ' If log file not found update the UI
                    BTN_LogFile.Text = "Unable to locate ProtonVPN Logs File"

                    BTN_LogFile.Enabled = False

                    ' Update the tooltips
                    TT_Main.SetToolTip(TBE_LogFile, My.Settings.FilePath)
                    TT_Main.SetToolTip(BTN_LogFile, "")

                Else

                    ' If log file not found update the UI
                    BTN_LogFile.Text = "Unable to locate ProtonVPN Log Files   (...)"

                    BTN_LogFile.Enabled = True

                    ' Update the tooltips
                    TT_Main.SetToolTip(TBE_LogFile, "Enabling this setting is recommended")
                    TT_Main.SetToolTip(BTN_LogFile, My.Settings.FilePath)

                End If

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' User clicked Test/Save button
    Private Sub BTN_TestSaveUpdate_Click(sender As Object, e As EventArgs) Handles BTN_TestSaveUpdate.Click

        Try

            If BTN_TestSaveUpdate.Text = "Update Port Now" Then

                Dim DoTaskUpdate As Task = CheckConnection()

            Else

                ' Call task to test then save settings
                Dim DoTaskTestSave As Task = TestSaveSettings()

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' Pormpts the user to find the ProtonVPN log file
    Private Sub SelectLogFileManually(ByVal Optional pForced As Boolean = False)

        Try

            ' See if we can get any information from the registry so we can provide default dir and path example
            Dim LogicLocation As Boolean = False

            Dim LogicFileLocation As String = ""

            Dim InstallLocationKeyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Proton VPN_is1"

            Using InstallLocationKey As RegistryKey = Registry.LocalMachine.OpenSubKey(InstallLocationKeyPath, False)

                If InstallLocationKey IsNot Nothing Then

                    ' Get the install location
                    Dim InstallLocationObject As Object = InstallLocationKey.GetValue("InstallLocation")

                    If InstallLocationObject IsNot Nothing AndAlso TypeOf InstallLocationObject Is String Then

                        Using VersionKey As RegistryKey = Registry.LocalMachine.OpenSubKey(InstallLocationKeyPath, False)

                            'Get the ProtonVPN version
                            Dim VersionObject As Object = InstallLocationKey.GetValue("DisplayVersion")

                            If VersionObject IsNot Nothing AndAlso TypeOf VersionObject Is String Then

                                ' Combine found information into file path
                                LogicFileLocation = InstallLocationObject & "v" & VersionObject & "\ServiceData\Logs\service-logs.txt"

                                ' We found some infromation we can use
                                LogicLocation = True

                            End If

                        End Using

                    End If

                End If

            End Using

            ' If no valid file log exists use the forced dialog text
            If pForced = False Then

                If Not File.Exists(My.Settings.FilePath) Then

                    pForced = True

                End If

            End If

            Dim Result As DialogResult

            If LogicLocation Then

                If pForced = False Then

                    ' Show a yes/no dialog with a logic path example
                    Result = MessageBox.Show("Do you want to select a diffrent ProtonVPN log file location? Here is an example location of where you can find it: " & vbCrLf & LogicFileLocation, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                Else

                    ' Show a forced dialog with a logic path example
                    Result = MessageBox.Show("Quantum is unable to locate the ProtonVPN log file, you must select a log file in the next screen, here is an example location of where you can find it: " & vbCrLf & LogicFileLocation, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question)

                End If

            Else

                If pForced = False Then

                    ' Show a yes/no dialog with a static path example 
                    Result = MessageBox.Show("Do you want to select a diffrent ProtonVPN log file location? Here is an example location of where you can find it: " & vbCrLf & "C:\Program Files\Proton\VPN\v3.3.0\ServiceData\Logs\service-logs.txt", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                Else

                    ' Show a focred dialog with a static path example 
                    Result = MessageBox.Show("Quantum is unable to locate the ProtonVPN log file, you must select a log file in the next screen, here is an example location of where you can find it: " & vbCrLf & "C:\Program Files\Proton\VPN\v3.3.0\ServiceData\Logs\service-logs.txt", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question)

                End If

            End If

            If Result = DialogResult.Yes Or Result = DialogResult.OK Then

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

                Else

                    ' Show warning if no currect valid log file selecetd
                    If Not File.Exists(My.Settings.FilePath) Then

                        ' Popup on desktop
                        Me.Show()
                        Me.WindowState = FormWindowState.Normal
                        Me.BringToFront()

                        MessageBox.Show("Quantum cannot run properly without a valid log file!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If

                End If

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' Quantum log filter
    Private Sub LogOutput(ByVal pString As String, ByVal pLog As Boolean, ByVal pError As Boolean)

        Try

            ' Do we want to log this information?
            If pLog = True Then

                Dim Ignore As Boolean = False

                If LV_QLog.Items.Count > 0 Then

                    If LV_QLog.Items.Item(LV_QLog.Items.Count - 1).SubItems.Item(1).Text = pString Then

                        ' Event is the same as the last log entry, update the existing entrys date/time
                        LV_QLog.Items.Item(LV_QLog.Items.Count - 1).SubItems.Item(0).Text = DateAndTime.Now.ToString
                        Ignore = True

                    End If

                End If

                If Not Ignore Then

                    ' New event
                    Dim HeaderItem As New ListViewItem(DateAndTime.Now.ToString)
                    HeaderItem.SubItems.Add(pString)
                    LV_QLog.Items.Add(HeaderItem)

                End If

                ' Ensures last row is visible
                LV_QLog.Items(LV_QLog.Items.Count - 1).EnsureVisible()

                ' Dont show more then 100 entries
                If LV_QLog.Items.Count > 100 Then

                    LV_QLog.Items.RemoveAt(0)

                End If

            End If

            ' Are we logging an error?
            If pError = True Then

                ' Update toolstrip
                TSSL_Main.Text = "Error, check logs for more information - " & DateTime.Now.ToShortTimeString

            Else

                ' Update toolstrip
                TSSL_Main.Text = pString & " - " & DateTime.Now.ToShortTimeString

            End If

        Catch ex As Exception

        End Try

    End Sub

    ' User closed window or application is shutting down
    Private Sub Main_Closing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.Closing

        Try

            ' If we are not logging off, or shutting down
            If e.CloseReason <> CloseReason.WindowsShutDown Then

                ' Cancel closing the applcation and minimize to tray
                e.Cancel = True
                Me.WindowState = FormWindowState.Minimized
                Me.Hide()

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' User double clicked the Quantum icon in the system tray
    Private Sub NI_Main_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NI_Main.MouseDoubleClick

        Try

            ' If we are currently on screen
            If Me.WindowState = FormWindowState.Normal Then

                ' Hide to system tray
                Me.Close()

            Else

                ' Currently in the system tray, popup on desktop
                Me.Show()
                Me.WindowState = FormWindowState.Normal
                Me.BringToFront()

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' User clicks a log entry for the ProtonVPN log
    Private Sub LV_VPNLogFile_DoubleClick(sender As Object, e As EventArgs) Handles LV_VPNLogFile.DoubleClick

        Try

            If LV_VPNLogFile.SelectedItems.Count > 0 Then

                ' Display the full unparsed line
                MessageBox.Show(LV_VPNLogFile.SelectedItems(0).Tag.ToString, "ProtonVPN Log File Entry")

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' User clicks a log entry for the Quantum log
    Private Sub LV_QLog_DoubleClick(sender As Object, e As EventArgs) Handles LV_QLog.DoubleClick

        Try

            If LV_QLog.SelectedItems.Count > 0 Then

                ' Display the log entry
                MessageBox.Show(LV_QLog.SelectedItems(0).SubItems.Item(1).Text, "Quantum Log Event - " & LV_QLog.SelectedItems(0).SubItems.Item(0).Text)

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' Add Quantum to the autorun registry
    Private Sub AddStartupEntry()

        Try

            Dim KeyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

            Using Key As RegistryKey = Registry.CurrentUser.OpenSubKey(KeyPath, True)

                ' If key exists, add applcation to autorun
                Key?.SetValue(Application.ProductName, Application.ExecutablePath)

            End Using

        Catch ex As Exception

            LogOutput(ex.Message, True, False)

        End Try

    End Sub

    ' Removes Quantum from the autorun registry
    Private Sub DeleteStartupEntry()

        Try

            Dim KeyPath As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

            Using Key As RegistryKey = Registry.CurrentUser.OpenSubKey(KeyPath, True)

                ' If key exists, remove applcation from autorun
                Key?.DeleteValue(Application.ProductName, False)

            End Using

        Catch ex As Exception

            LogOutput(ex.Message, True, False)

        End Try

    End Sub

    ' User selected to exit applcation
    Private Sub TSMI_Exit_Click(sender As Object, e As EventArgs) Handles TSMI_Exit.Click

        Try

            ' Shutdown Quantum
            Application.Exit()

        Catch ex As Exception

        End Try

    End Sub

    ' Runs when the form is visiable, adjusts columns for better fit
    Private Sub Main_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

        Try

            ' Have we already done this?
            If Not LogScalingSet Then

                ' Make sure the form is visible, need to be on screen to work correctly
                If Me.Visible Then

                    Dim HeaderItem As New ListViewItem(DateTime.Now.ToString)
                    HeaderItem.SubItems.Add(LV_QLog.Columns.Item(1).Text)

                    ' Add dummy item to listview
                    LV_QLog.Items.Add(HeaderItem)

                    ' Auto resize columns
                    LV_QLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

                    ' Remove dummy
                    LV_QLog.Items.RemoveAt(0)

                    ' Adjust for scrollbar
                    CH_QEvent.Width = (LV_QLog.ClientSize.Width - CH_QDateTime.Width - SystemInformation.VerticalScrollBarWidth) - 7

                    ' Completed, doesnt need to be done again
                    LogScalingSet = True

                End If

            End If

            If Me.Visible = True Then

                'Change the label to 'Hide'
                TSMI_ShowHide.Text = "Hide"

            Else

                'Change the label to 'Show'
                TSMI_ShowHide.Text = "Show"

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' User clicks hide/show in the system tray
    Private Sub TSMI_ShowHide_Click(sender As Object, e As EventArgs) Handles TSMI_ShowHide.Click

        Try

            If Me.Visible = True Then

                ' Close the window
                Me.Close()

            Else

                ' Popup on desktop
                Me.Show()
                Me.WindowState = FormWindowState.Normal
                Me.BringToFront()

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' User clicks 'Update Port Now' in the system tray
    Private Sub TSMI_UpdateNow_Click(sender As Object, e As EventArgs) Handles TSMI_UpdateNow.Click

        Try

            ' Call task to test connection, this allways checks for an updated port
            Dim DoTask As Task = CheckConnection()

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' Opens the default webbrowser to the Quantum GitHub page
    Private Sub LNK_About_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LNK_About.LinkClicked

        Try

            ' Define URL
            Dim GitURL As String = "https://github.com/UHAXM1/Quantum/releases"

            ' Launch the webbrowser
            Process.Start(New ProcessStartInfo(GitURL) With {.UseShellExecute = True})

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' Opens the default webbrowser to the Proton homepage
    Private Sub LNK_AboutProtonVPN_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LNK_AboutProtonVPN.LinkClicked

        Try

            ' Define URL
            Dim ProtonURL As String = "https://proton.me/"

            ' Launch the webbrowser
            Process.Start(New ProcessStartInfo(ProtonURL) With {.UseShellExecute = True})

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' User clicked set manual or automatic log file location
    Private Sub TBE_LogFile_CheckedChanged(sender As Object, e As EventArgs) Handles TBE_LogFile.CheckedChanged

        Try

            If TBE_LogFile.Checked Then

                ' User enabled automaic log file location
                My.Settings.AutoFindLog = True

            Else

                ' Prompt the user is sure they want to remove autorun
                Dim Result As DialogResult = MessageBox.Show("Are you sure you want to disable automatic log file location?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If Result = DialogResult.Yes Then

                    ' User disabled automatic log file location
                    My.Settings.AutoFindLog = False

                Else

                    ' User selected not to disable auto location, add the checkmark back
                    TBE_LogFile.Checked = True

                    My.Settings.AutoFindLog = True

                End If

            End If

            ' Save settings
            My.Settings.Save()

            ' Update UI
            UpdateSelectButton()

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    ' User clicked log file selcect button
    Private Sub BTN_LogFile_Click(sender As Object, e As EventArgs) Handles BTN_LogFile.Click

        Try

            ' Show prompt
            SelectLogFileManually()

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try

    End Sub

    Private Sub TBE_Startup_CheckedChanged(sender As Object, e As EventArgs) Handles TBE_Startup.CheckedChanged

        Try

            ' User enable autorun
            If TBE_Startup.Checked Then

                ' Add to registry
                AddStartupEntry()

            Else

                ' Prompt the user is sure they want to remove autorun
                Dim Result As DialogResult = MessageBox.Show("Are you sure you want to delete the startup entry?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If Result = DialogResult.Yes Then

                    ' Delete from registry
                    DeleteStartupEntry()

                Else

                    ' User selected not to remove from registry, add the checkmark back
                    TBE_Startup.Checked = True

                End If

            End If

        Catch ex As Exception

            LogOutput(ex.Message, True, True)

        End Try


    End Sub

    Private Sub UpdateConnectionUI()

        Dim Update As Boolean = False

        Dim TempHost As String = TXT_Host.Text
        If TempHost = TXT_Host.Tag Then
            TempHost = ""
        End If

        Dim TempUser As String = TXT_Username.Text
        If TempUser = TXT_Username.Tag Then
            TempUser = ""
        End If

        Dim TempPass As String = TXT_Password.Text
        If TempPass = TXT_Password.Tag Then
            TempPass = ""
        End If

        If TempHost = My.Settings.Host Then

            If TempUser = My.Settings.Username Then

                If TempPass = My.Settings.Password Then

                    Update = True

                End If

            End If

        End If

        If Update = True Then

            BTN_TestSaveUpdate.Text = "Update Port Now"

        Else

            BTN_TestSaveUpdate.Text = "Test/Save Settings"

        End If

    End Sub

    Private Sub TXT_Host_TextChanged(sender As Object, e As EventArgs) Handles TXT_Host.TextChanged

        UpdateConnectionUI()

    End Sub

    Private Sub TXT_Username_TextChanged(sender As Object, e As EventArgs) Handles TXT_Username.TextChanged

        UpdateConnectionUI()

    End Sub

    Private Sub TXT_Password_TextChanged(sender As Object, e As EventArgs)

        UpdateConnectionUI()

    End Sub

End Class
