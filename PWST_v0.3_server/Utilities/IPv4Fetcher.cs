using System;
using System.Net;
using System.Threading;

namespace PWST_v0._3_server.Utilities {
    public class IPv4Fetcher {

        private static string _hostName;

        public static string FetchHostName() {
            Console.WriteLine("Getting Hostname ...");
            _hostName = Dns.GetHostName();
            return _hostName;
        }

        public static string FetchIPv4() {
            Console.WriteLine("Getting IPv4 Address ...");
            string outIPv4Address = null;

            IPHostEntry iPHostEntry;
            iPHostEntry = Dns.GetHostEntry(_hostName);

            if (iPHostEntry.AddressList != null) {
                foreach (IPAddress address in iPHostEntry.AddressList) {
                    if (address.AddressFamily.ToString().Equals("InterNetwork")) {
                        Thread.Sleep(100);
                        outIPv4Address = address.ToString();
                    }
                }
            }

            return outIPv4Address;
        }

        

    }
}
