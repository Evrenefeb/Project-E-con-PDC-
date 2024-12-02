using NAudio.Wave;
using PWST_v0._3_client.Networking.Concrete;
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

            ConsoleClient client = new ConsoleClient("Evrenefeb");
            client.Connect();
            

            //string filePath = null;
            //AudioHandler audioHandler = new AudioHandler(filePath);
            //audioHandler.RecordAudio();




            //StartClient();

            Console.ReadKey();
        }

    }
}
