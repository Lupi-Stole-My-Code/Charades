using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace Client
{
    public class Network
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;
        bool canLoop = true;

        public void connect(IPAddress ip, int port = 5678)
        {
            try
            {
                clientSocket.Connect(ip, port);
                serverStream = clientSocket.GetStream();
            }
            catch
            {
                Program.connectionError = true;
                return;
            }
            readData = "Connected to Server!";
            msg();

            send(Program.PlayerName); // PlayerName

            Thread ctThread = new Thread(session);
            ctThread.Start();
        }

        public void send(string text)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void session()
        {
            while (canLoop)
            {
                try
                {
                    serverStream = clientSocket.GetStream();
                    int buffSize = 255;
                    byte[] inStream = new byte[10025];
                    buffSize = clientSocket.ReceiveBufferSize;
                    // serverStream.Read(inStream, 0, buffSize);
                    var count = serverStream.Read(inStream, 0, inStream.Length);
                    string returndata = Encoding.ASCII.GetString(inStream, 0, count);
                    try
                    {
                        byte[] dt = Convert.FromBase64String(returndata);
                        string str = Encoding.UTF8.GetString(dt);
                        if (str.Contains("/#/Charade/"))
                        {
                            processCharade(returndata);
                            continue;
                        }
                    }
                    catch
                    {

                    }
                    readData = "" + returndata;

                    int st = checkIfCommand();
                    if (st == -1)
                    {
                        break;
                    }

                    if (st == 1)
                    {
                        continue;
                    }

                    msg();
                }
                catch
                {

                }
            }
            serverStream.Close();
            clientSocket.Close();
        }

        private void processCharade(string base64)
        {
            byte[] tempo = Convert.FromBase64String(base64);
            var str = Encoding.UTF8.GetString(tempo);
            var command = "/#/Charade/";
            var charadeIndex = str.IndexOf("!#/");
            var charade = str.Substring(command.Length, (charadeIndex - command.Length)); // odpowiedz
            var header = Encoding.UTF8.GetBytes(command + charade + "!#/");
            byte[] image = new byte[tempo.Length - header.Length];
            Array.Copy(tempo, header.Length, image, 0, tempo.Length - header.Length);

            var unzipped = Utils.Unzip(image);

            var img = Convert.FromBase64String(unzipped);
            Bitmap bmp1;
            using (var ms = new MemoryStream(img))
            {
                bmp1 = new Bitmap(ms);
            }

            Program.playground.wait.setCharade(bmp1);
        }

        private int checkIfCommand()
        {
            switch (readData)
            {
                case "ERR_ALREADY_USED":
                    readData = "Server closed connection due to Player Nickname duplication";
                    msg();
                    Preferences.Chat.connected = false;
                    return -1;
                case "BYE":
                    readData = "Server closed connection";
                    msg();
                    Preferences.Chat.connected = false;
                    return -1;
                case "/@/YourTurn":
                    Program.playground.setCanDraw(true);
                    Program.playground.guess.timerSet(180);
                    Program.turn = true;
                    readData = "It's your turn!";
                    return 0;
                case "/@/TurnEnds30Sec":
                    readData = "Your turn ends in 30 seconds! Hurry Up!";
                    if (Program.turn)
                    {
                        Program.playground.guess.timerSet(30);
                    }
                    return 0;
                case "/@/TurnEnd":
                    if (Program.turn)
                    {
                        readData = "Your turn has been finished";
                        Program.playground.setCanDraw(false);
                        Program.playground.clear();
                        Program.turn = false;
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                case "/@/Stop":
                    readData = "Gra zatrzymana";
                    Program.playground.clear();
                    Program.playground.setCanDraw(false);
                    Program.turn = false;
                    return 0;
                default:
                    return 0;
            }
        }
        private void msg()
        {
            Program.chat_main.Msg(readData);
        }
    }
}
