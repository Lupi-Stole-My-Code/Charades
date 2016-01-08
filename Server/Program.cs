using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        #region Page Event Setup
        enum ConsoleCtrlHandlerCode : uint
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
        delegate bool ConsoleCtrlHandlerDelegate(ConsoleCtrlHandlerCode eventCode);
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleCtrlHandler(ConsoleCtrlHandlerDelegate handlerProc, bool add);
        static ConsoleCtrlHandlerDelegate _consoleHandler;
        #endregion

        public static Hashtable clientsList = new Hashtable();
        public static Hashtable clientsObjList = new Hashtable();

        public static TcpListener serverSocket;
        public static TcpClient clientSocket;
        public static readonly int port = 5678;
        public static int counter = 0;

        static void Main(string[] args)
        {
            _consoleHandler = new ConsoleCtrlHandlerDelegate(ConsoleEventHandler);
            SetConsoleCtrlHandler(_consoleHandler, true);

            init();
            serverSocket.Start();
            Console.WriteLine("Server started ....");
            counter = 0;
            while (true)
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Client incoming!");
                byte[] bytesFrom = new byte[10025];
                string dataFromClient = null;

                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                if (clientsList.ContainsKey(dataFromClient))
                {
                    Byte[] broadcastBytes = Encoding.ASCII.GetBytes("ERR_ALREADY_USED");
                    NetworkStream broadcastStream = clientSocket.GetStream();
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();

                    networkStream.Close();
                    clientSocket.Close();
                    counter -= 1;
                    Console.WriteLine("Client disconnected due to nickname replication");
                    continue;
                }
                clientsList.Add(dataFromClient, clientSocket);

                broadcast(dataFromClient + " Joined ", dataFromClient, false);

                Console.WriteLine(dataFromClient + " Joined ");
                Client client = new Client();
                client.startClient(clientSocket, dataFromClient, clientsList);
                clientsObjList.Add(dataFromClient, client);
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine("exit");
            Console.ReadLine();
        }

        public static void broadcast(string msg, string uName, bool flag)
        {
            foreach (DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;

                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(msg);
                }

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }

        private static void init()
        {
            serverSocket = new TcpListener(IPAddress.Any, 5678);
            clientSocket = default(TcpClient);
            counter = 0;
        }

        #region Page Events
        private static bool ConsoleEventHandler(ConsoleCtrlHandlerCode eventCode)
        {
            // Handle close event here...
            switch (eventCode)
            {
                case ConsoleCtrlHandlerCode.CTRL_CLOSE_EVENT:
                case ConsoleCtrlHandlerCode.CTRL_BREAK_EVENT:
                case ConsoleCtrlHandlerCode.CTRL_LOGOFF_EVENT:
                case ConsoleCtrlHandlerCode.CTRL_SHUTDOWN_EVENT:
                    cleanUp();
                    Environment.Exit(0);
                    break;
            }

            return (false);
        }
        #endregion

        private static void cleanUp()
        {

            Console.WriteLine("Cleaning Up");
            foreach (DictionaryEntry Item in clientsList)
            {
                try
                {
                    TcpClient broadcastSocket = (TcpClient)Item.Value;
                    if (isConnected(broadcastSocket))
                    {

                        NetworkStream broadcastStream = broadcastSocket.GetStream();

                        Byte[] broadcastBytes = Encoding.ASCII.GetBytes("BYE");
                        broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                        broadcastStream.Flush();
                       // broadcastStream.Close();
                    }
                    try
                    {
                        (clientsObjList[Item.Key] as Client).stopClient();
                    }
                    catch (ThreadAbortException ex)
                    {
                        //This is an expected exception. The thread is being aborted
                    }
                    broadcastSocket.Close();

                }
                catch
                {
                    Console.WriteLine("Clean-Up : Error | " + Item.Key);
                }
            }

        }

        private static bool isConnected(TcpClient broadcastSocket)
        {
            try
            {
                if (broadcastSocket != null && broadcastSocket.Client != null && broadcastSocket.Client.Connected)
                {

                    if (broadcastSocket.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (broadcastSocket.Client.Receive(buff, SocketFlags.Peek) == 0)
                        {
                            // Client disconnected
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
