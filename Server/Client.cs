using System;
using System.Collections;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class Client
    {
        TcpClient clientSocket;
        string clNo;
        Hashtable clientsList;
        Thread ctThread;

        public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            this.clientsList = cList;
            ctThread = new Thread(doChat);
            ctThread.Start();
        }

        public void stopClient()
        {
            ctThread.Abort(0);
        }

        private void doChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            string rCount = null;
            requestCount = 0;

            while (true)
            {
                try
                {

                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
                    rCount = Convert.ToString(requestCount);
                    if(dataFromClient.Contains("/#/") && dataFromClient.IndexOf("/#/") == 0)
                    {
                        command(dataFromClient, clNo);
                        continue;
                    }
                    Program.broadcast(dataFromClient, clNo, true);
                    command(dataFromClient, clNo);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                }
            }
        }

        private void command(string txt, string from)
        {
            switch (txt)
            {
                case "/start":
                    Console.WriteLine("Found command from '" + from + "': '" + txt + "'");
                    Program.game.start();
                    break;
                case "/stop":
                    Console.WriteLine("Found command from '" + from + "': '" + txt + "'");
                    Program.game.stop();
                    break;
                case "/commands":
                    Console.WriteLine("Found command from '" + from + "': '" + txt + "'");
                    Program.game.showCommands();
                    break;
                case "/#/forceNext":
                    Console.WriteLine("Found command from '" + from + "': '" + txt + "'");
                    Program.game.forceNext();
                    break;
                case "/#/disconnect":
                    Program.cleanSession(from);
                    break;
                default:
                    break;
            }
            if(txt.Contains("/#/charade/"))
            {
                int i = "/#/charade/".Length;
                string c = txt.Substring(i);
                Program.game.setCharade(c, from);
            }
        }
    }
}
