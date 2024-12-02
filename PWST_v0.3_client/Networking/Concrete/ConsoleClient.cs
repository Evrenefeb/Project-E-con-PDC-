using System;
using WebSocketSharp;

using PWST_v0._3_client.Networking.Abstract.Classes;


namespace PWST_v0._3_client.Networking.Concrete {
    public class ConsoleClient : BaseClient {

        // Properties

        // Constructors
        public ConsoleClient() : base(){
            
        }
        public ConsoleClient(string username) : base(username) {
            Username = username;
        }

        // Methods
        public override void Connect() {
            string url = null, addressToConnect = null;
            int port = 0;

            Console.Write("Enter server IPv4 to connect : ");
            addressToConnect = Console.ReadLine();

            Console.Write("Enter server port to connect : ");
            string answerPort = Console.ReadLine();


            if (int.TryParse(answerPort, out port)) {
                url = "ws://" + addressToConnect + ":" + port + "/echo-all";
            }
            else {
                Console.WriteLine("Could not connected to any server.");
                Console.ReadKey();
            }


            WebSocket = new WebSocket(url);

            WebSocket.OnMessage += WebSocket_OnMessage;



            WebSocket.Connect();
            if (WebSocket.IsAlive) {
                Console.WriteLine("Connection established.");
            }
            else {
                Console.WriteLine("Connection could not established");
            }


            // TODO: Implement more mods
            ChatMode();
        }

        private void ChatMode() {
            Console.WriteLine("Permentant Chat Mode: ENABLED (To exit type \"dc\") \n\n");

            while (true) {
                Console.Write(Username + " > ");
                string message = Console.ReadLine();
                if (message.Equals("dc")) Disconnect();

                WebSocket.Send("[" + DateTime.Now + "] 'Client' >>> " + message);
            }
        }

        public override void Disconnect() {
            WebSocket?.Close();
        }

        // Event Handlers
        private void WebSocket_OnMessage(object sender, MessageEventArgs e) {
            if(sender != this) {
                //Console.WriteLine("Client recieved data from Server: " + e.Data);
            }
        }
    }
}
