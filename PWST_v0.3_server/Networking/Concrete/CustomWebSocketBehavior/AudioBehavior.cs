using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace PWST_v0._3_server.Networking.Concrete.CustomWebSocketBehavior {
    public class AudioBehavior : WebSocketBehavior{
        protected override void OnOpen() {
            Console.WriteLine("[   Server   ] Client Connected: Behavior = Audio");
        }
        protected override void OnMessage(MessageEventArgs e) {
            Console.WriteLine("[   Server   ] Message Received: " + e.RawData);
            // TODO: Send to other clients besides the one that sent the message
            // Currently Sending everyone including the sender
            Sessions.Broadcast(e.RawData);
        }

    }
}
