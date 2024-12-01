using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSocketSharp;

namespace PWST_v0._3_client {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("Client\n\n\n\n");

            StartClient();

            Console.ReadKey();
        }

        private static void StartClient() {
            string url = "ws://localhost:9900/echo-all";

            WebSocket webSocket = new WebSocket(url);

            webSocket.OnMessage += WebSocket_OnMessage;

            webSocket.Connect();
            Console.WriteLine("Connected to Server");

            

           
        }

        private static void WebSocket_OnMessage(object sender, MessageEventArgs e) {
            Console.WriteLine("Client recieved data from Server: " + e.Data);
        }
    }
}
