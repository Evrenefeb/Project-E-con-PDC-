using System;
using System.IO;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace PWST_v0._3_server.Networking.Concrete.WebSocketBehaviors {
    public class AudioBroadCastBehavior : WebSocketBehavior {
        protected override WebSocketSessionManager GetSessions() {
            return Sessions;
        }

        protected override void OnMessage(MessageEventArgs e, WebSocketSessionManager sessions) {
            try {
                using (var memoryStream = new MemoryStream(e.RawData)) {
                    // Broadcast audio data to all connected clients except the sender
                    foreach (var session in sessions) {
                        if (session != Context.WebSocket) {
                            session.Send(memoryStream.ToArray(), 0, memoryStream.Length);
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Audio broadcast error: {ex.Message}");
            }
        }

        
    }
}
