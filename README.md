# Automatic qBittorent Port Updater for ProtonVPN

This application will monitor the Windows ProtonVPN client log files for port changes and pass them via the qBittorrent WebUI

Uses the qBittorrent-net-client library found here
https://github.com/fedarovich/qbittorrent-net-client

Tested with ProtonVPN version 3.2.12

Requires.Net 8

Simply install and provide connection information to qBittorrent, Quantum will automatically try to find the ProtonVPN log directory

Quantum will check the logs files once every minute

Detailed setup steps:

qBittorrent Setup

	Open qBittorrent:
		Launch qBittorrent on your computer.
 
	Access Preferences:
		Go to Tools > Options or press Alt + O to open the preferences window.

	Enable WebUI:
		In the preferences window, select the Web UI section.
		Check the box for Enable Web User Interface (Remote control).
		You can leave the default IP address (usually 127.0.0.1 for local access) and Port (default is 8080), or change them if needed.

	Set Authentication:
		Under Authentication, check the box for Use a username and password.
		Enter a Username (default is admin).
		Enter and confirm a Password.
		Optionally you can enable Bypass authentication for clients on localhost, if you just set this you can leave the username and password blank.

	Configure IP and Port:
		If you want to access the WebUI from other devices on your network, you may need to change the IP address to 0.0.0.0 to allow access from all network interfaces.
		Make sure the port you are using is not blocked by your firewall.

	Security Options:
		Optionally, you can set up an IP filter to restrict which IP addresses can access the WebUI.
		You can also enable HTTPS to secure the connection by providing an SSL certificate and key.

	Apply and Save:
		Click Apply and then OK to save your settings.

	Access the WebUI:
		Open a web browser and go to http://: (e.g., http://127.0.0.1:8080 for local access).
		Log in with the username and password you set.
	
Quantum setup

	Open Quantum:
		Launch Quantum on your computer, if this is your first time running Quantum it will popup on screen, if it does not appear check the system tray and double-click the icon.
		
	Startup:
		Enable or Disable Quantum from running when the user logs into the computer, this is account specific.
		
	Log File Location:
		Quantum will try to find the ProtonVPN log file automatically, however if it cannot click the Log File Button to select manually select a location.
		
	qBittorrent Configuration:
		Host: this should be 'http://127.0.0.1:8080' by default, if you are not using the default port or want to connect to a remote instance change the ip and port number here, if you are using SSL you need to change http to https.
		Username and Password: Input the username and password you setup in the Qbittorrent setup above, if you have enabled Bypass authentication for client on localhost and are local you can leave this blank.
		
	Test/Save:
		Click this button to Test then save the current configuration, you will get a popup telling you if the connection is a successful.
		
	Force Port Update Now:
		Click this button to force Quantum to do a port update right away. Only needs to be used if you cant be bothered waiting for the next poll.
		
Setup should now be complete, you can close Quantum by click the close window button (it will minimize to the system tray).