using System;
using System.Net;
using System.Threading;

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
            Thread.Sleep(1000);

            string localIPv4, localhostName;

            localhostName = Dns.GetHostName();
            IPHostEntry iPHostEntry;
            iPHostEntry = Dns.GetHostEntry(localhostName);

            // This part checks for IPv4 and gets it into string localIPv4

            if (iPHostEntry.AddressList != null) {
                Console.WriteLine("----- IPv4 -----");
                foreach (IPAddress address in iPHostEntry.AddressList) {
                    if (address.AddressFamily.ToString().Equals("InterNetwork")) {
                        Thread.Sleep(100);
                        localIPv4 = address.ToString();
                        Console.WriteLine("Host: " + localhostName + " --> IPv4: " + localIPv4);
                    }
                }
            }




        }
    }
}
