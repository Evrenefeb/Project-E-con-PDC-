using PWST_v0._3_server.Abstract;
using PWST_v0._3_server.Utilities;
using System;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace PWST_v0._3_server {
    public class LocalServer : BaseServer {


        // Properties
        public string LocalIPv4 { get; private set; }
        public string LocalHostName { get; private set; }
        public int Port { get; set; }
        public string ServerAddress { get; private set; }
        public WebSocketServer LocalWebSocketServer { get; private set; }

        // Constructors

        public LocalServer() {            
            Port = 9900;
            Initialize();
        }

        public LocalServer(int Port) {
            this.Port = Port;
            Initialize();
        }

        // Methods

        private void Initialize() {
            LocalHostName = IPv4Fetcher.FetchHostName();
            LocalIPv4 = IPv4Fetcher.FetchIPv4();
            

            ServerAddress = "ws://" + LocalIPv4 + ":" + Port;
        }

        public override void StartServer() {
            Console.WriteLine("Starting server at " + ServerAddress);
            WebSocketServer LocalWebSocketServer = new WebSocketServer(ServerAddress);


            // TODO: Seperation Needed here
            const string STR_ECHO = "/echo", STR_ECHOALL = "/echo-all";
            LocalWebSocketServer.AddWebSocketService<Echo>(STR_ECHO);
            LocalWebSocketServer.AddWebSocketService<EchoAll>(STR_ECHOALL);

            Console.WriteLine("Available Behaviours: " + STR_ECHO + " " + STR_ECHOALL);

            LocalWebSocketServer.Start();


            Console.WriteLine("\n\n\nPress any key to Stop Server ...");
            Console.ReadKey();
            StopServer();
            
        }

        public override void StopServer() {
            LocalWebSocketServer?.Stop();
        }


        // TODO: Seperate them into Util Directory with different classes
        // This part covers WebSocketBehaviors
        protected class Echo : WebSocketBehavior {
            protected override void OnMessage(MessageEventArgs e) {
                Console.WriteLine("Server recieved data from echo client: " + e.Data);
                Send(e.Data);
            }
        }

        protected class EchoAll : WebSocketBehavior {
            protected override void OnMessage(MessageEventArgs e) {
                Console.WriteLine("Server recieved data from echo-all client: " + e.Data);
                Sessions.Broadcast(e.Data);
            }
        }

    }
}
