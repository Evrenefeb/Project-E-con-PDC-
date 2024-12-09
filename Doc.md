# Documentation
## 
### NetworkClient.cs
- Creates a Client object.
- Can connect to servers.
- Gets Audio from client's input device.
- Can be muted and unmute input audio.
- Sends byte array data server.

### AudioBroadCastBehavior.cs
- Creates a WebSocketBehavior object.
- Returns byte array to output audio on server message.

### IPv4Fetcher.cs
- Created as utility class.
- Staticly returns machine's Local IPv4 Address as string.

### LocalServer.cs
- Creates a Server object.
- Uses machine's IPv4Fetcher.cs to open server.
- Server port can be change on initialization.
- Has custom websocket behavior called AudioBroadCastBehavior.cs

