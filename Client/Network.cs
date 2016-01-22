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
            while (true)
            {
                try {
                    serverStream = clientSocket.GetStream();
                    int buffSize = 255;
                    byte[] inStream = new byte[10025];
                    buffSize = clientSocket.ReceiveBufferSize;
                    // serverStream.Read(inStream, 0, buffSize);
                    var count = serverStream.Read(inStream, 0, inStream.Length);
                    string returndata = Encoding.ASCII.GetString(inStream, 0, count);
                    // string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    readData = "" + returndata;
                    if (!checkIfCommand()) break;
                    msg();
                }
                catch
                {

                }
            }
            serverStream.Close();
            clientSocket.Close();
        }

        private bool checkIfCommand()
        {
            switch (readData)
            {
                case "ERR_ALREADY_USED":
                    readData = "Server closed connection due to Player Nickname duplication";
                    msg();
                    Preferences.Chat.connected = false;
                    return false;
                case "BYE":
                    readData = "Server closed connection";
                    msg();
                    Preferences.Chat.connected = false;
                    return false;
                case "/@/YourTurn":
                    Program.playground.setCanDraw(true);
                    return true;
                case "/@/TurnEnds30Sec":
                    readData = "Your turn ends in 30 seconds! Hurry Up!";
                    return true;
                case "/@/TurnEnd":
                    readData = "Your turn has been finished";
                    return true;
                default:
                    return true;
            }
        }
        private void msg()
        {
            Program.chat_main.Msg(readData);
        }
    }
}
