using NAudio.Wave;
using PWST_v0._3_client.Utilities;
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

            string filePath = null;
            AudioHandler audioHandler = new AudioHandler(filePath);
            audioHandler.PlayAudio();




            StartClient();

            Console.ReadKey();
        }

       


        private static void StartClient() {

            string url = null;

            string addressToConnect;

            Console.Write("Enter server IPv4 to connect : ");
            addressToConnect = Console.ReadLine();



            int portToConnect;

            Console.Write("Enter server port to connect : ");
            string answerPort = Console.ReadLine();
            
            if (int.TryParse(answerPort, out portToConnect)) {
                url = "ws://"+ addressToConnect + ":" + portToConnect + "/echo-all";
            }
            else {
                Console.WriteLine("Could not connected to any server.");
                Console.ReadKey();
            }
            





            WebSocket webSocket = new WebSocket(url);

            webSocket.OnMessage += WebSocket_OnMessage;

            webSocket.Connect();
            Console.WriteLine("Connected to Server..."); //Sending single info to server
            Console.WriteLine("Permentant Chat Mode: ENABLED (To exit type \"ex\") \n\n");

            while (true) {
                Console.Write("> ");
                string message = Console.ReadLine();
                if(message.Equals("ex")) break;

                webSocket.Send("[" + DateTime.Now + "] 'Client' >>> " + message);
            }

            

           
        }

        private static void WebSocket_OnMessage(object sender, MessageEventArgs e) {
            Console.WriteLine("Client recieved data from Server: " + e.Data);
        }
    }
}
