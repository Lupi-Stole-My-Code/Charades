using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Program
    {
        public static TcpListener tcpServ;
        public static Thread connectionLoopThr;
        public static TcpClient clientSocket;
        public static readonly int port = 5678;

        static void Main(string[] args)
        {
            init();
            tcpServ = new TcpListener(IPAddress.Any, port);
            clientSocket = default(TcpClient);
            int counter = 0;
            tcpServ.Start();
            Console.WriteLine(" @ " + "Server Started");

            counter = 0;
            while (true)
            {
                try {
                    counter += 1;
                    clientSocket = tcpServ.AcceptTcpClient();
                    Console.WriteLine(" @ " + "Client No:" + Convert.ToString(counter) + " started!");
                    Client client = new Client();
                    client.startClient(clientSocket, Convert.ToString(counter));
                }
                catch
                {
                    Console.WriteLine("ERROR: @ " + counter);
                }
            }

            clientSocket.Close();
            tcpServ.Stop();
            Console.WriteLine(" >> " + "exit");
            Console.ReadLine();
        }

        private static void init()
        {

        }
    }
}
