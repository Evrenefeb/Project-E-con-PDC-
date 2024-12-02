using System;

namespace PWST_v0._3_server {
    internal class Program {
        static void Main(string[] args) {

            Console.WriteLine("Server\n\n\n\n");

            LocalServer localServer;
            while (true) {
                Console.Write("Do you want to Start Local Server (y/n) : ");
                string answer = Console.ReadLine();
                if (answer.Equals("y")) {

                    Console.Write("Enter server port if do not want to use default port(9900) : ");
                    string answerPort = Console.ReadLine();
                    int serverPort;

                    if (int.TryParse(answerPort, out serverPort)) { 
                        localServer = new LocalServer(serverPort);
                    }
                    else {
                        localServer = new LocalServer();
                    }

                    Console.WriteLine("\n\n\nStarting Server ... \n");

                    localServer.StartServer();
                    break;
                }
                else if (answer.Equals("n")) {
                    Console.WriteLine("Server did not started.");
                    break;
                }
            }


            Console.ReadKey();

        }
    }
}
