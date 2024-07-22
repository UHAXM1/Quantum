# Automatic qBittorent Port Updater for ProtonVPN

This application will monitor the Windows ProtonVPN client log files for port changes and pass them via the qBittorrent WebUI

Uses the qBittorrent-net-client library found here
https://github.com/fedarovich/qbittorrent-net-client

Tested with ProtonVPN version 3.2.12

Requires .Net 8

Simply install and provide connection information to qBittorrent, Quantum will automatically try to find the ProtonVPN log directory

Quantum will check the logs files once every miniute