using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace PWST_v0._3_server {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("Server\n\n\n\n");

            Thread.Sleep(1000);
            StartLocal();

            Console.ReadKey();

        }


        private static void StartLocal() {
            Console.WriteLine("Getting IPv4 Address ...");
            //Thread.Sleep(1000);

            string localIPv4, localhostName;

            localhostName = Dns.GetHostName();
            IPHostEntry iPHostEntry;
            iPHostEntry = Dns.GetHostEntry(localhostName);

            // This part checks for IPv4 and gets it into string localIPv4

            if (iPHostEntry.AddressList != null) {
                Console.WriteLine("----- IPv4 -----");
                foreach (IPAddress address in iPHostEntry.AddressList) {
                    if (address.AddressFamily.ToString().Equals("InterNetwork")) {
                        //Thread.Sleep(100);
                        localIPv4 = address.ToString();
                        Console.WriteLine("Host: " + localhostName + " --> IPv4: " + localIPv4);
                    }
                }
            }

            // This part checks for IPv4 and gets it into string localIPv4

            //Thread.Sleep(1000);
            Console.WriteLine("\n\n\n");

            string URL = "localhost";
            string port = "9900";
            string server = "ws://" + URL + ":" + port;
            Console.WriteLine("Server starting at " + server);
            

            WebSocketServer localWebSocketServer = new WebSocketServer(server);

            // This part insert server behaviors
            const string STR_ECHO = "/echo", STR_ECHOALL = "/echo-all";
            localWebSocketServer.AddWebSocketService<Echo>(STR_ECHO);
            localWebSocketServer.AddWebSocketService<EchoAll>(STR_ECHOALL);

            Console.WriteLine("Available Behaviours: " + STR_ECHO + " " + STR_ECHOALL);

            localWebSocketServer.Start();


            Console.WriteLine("\n\n\nPress any key to Stop Server ...");
            Console.ReadKey();
            localWebSocketServer.Stop();


            //const string URL = "ws://jbgasdxaxa.duckdns.org:9900";
            //WebSocketServer webSocketServer = new WebSocketServer(URL);

            //WebSocketState webSocketServerState;
            //webSocketServerState = WebSocketState.Closed;

            //Console.WriteLine("Server State: " + webSocketServerState.ToString());

            //// WebSocketServices added here
            //const string STR_ECHO = "/echo", STR_ECHOALL = "/echo-all";
            //webSocketServer.AddWebSocketService<Echo>(STR_ECHO);
            //webSocketServer.AddWebSocketService<EchoAll>(STR_ECHOALL);
            //// WebSocketServices added             

            //Console.WriteLine("Starting Server . . .");
            //webSocketServer.Start();
            //webSocketServerState = WebSocketState.Open;
            //Console.WriteLine("Server State --> " + webSocketServerState.ToString());

            //Console.ReadKey();
            //webSocketServer.Stop();



        }


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
