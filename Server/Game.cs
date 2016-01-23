using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class Game
    {
        private int playerId;
        private List<string> players;
        private bool gameStarted = false;
        private int maxId;
        private string charade;

        public void start()
        {
            if(gameStarted)
            {
                Program.broadcast("Game is already started", "@", false, "server");
                return;
            }
            players = Program.clientsObjList.Keys.OfType<string>().ToList();
            if(players.Count < 2)
            {
                Program.broadcast("Game cannot be started. Not enough players", "@", false, "server");
                return;
            }
            Console.WriteLine("PLAYERS : " + string.Join(", ", players));
            gameStarted = true;
            maxId = players.Count - 1;
            playerId = 0;
            gameTurn();
        }

        public void gameTurn()
        {
            if(playerId < maxId)
            {
                Program.broadcast("/@/YourTurn", "@", false, players[playerId]);
            }
        }

        public void stop()
        {
            if (!gameStarted)
            {
                Program.broadcast("Game is not started", "@", false, "server");
                return;
            }
            gameStarted = false;

        }

        public void showCommands()
        {
            Program.broadcast("Commands list:\n/start - starts game\n/stop - stops game", "@", false, "server");
        }

        public void forceNext()
        {

        }

        private void sendImage()
        {

        }

        public void setCharade(string charade)
        {
            this.charade = charade;
        }

        public void processCharade(string base64)
        {
            byte[] tempo = Convert.FromBase64String(base64);

            var str = Encoding.UTF8.GetString(tempo);
            var command = "/#/Charade/";
            var charadeIndex = str.IndexOf("!#/");
            var charade = str.Substring(command.Length,(charadeIndex - command.Length));
            setCharade(charade);
           // var header = Encoding.UTF8.GetBytes(command + charade + "!#/");

            //byte[] image = new byte[tempo.Length - header.Length];
           // Array.Copy(tempo, header.Length, image, 0, tempo.Length - header.Length);
            
            return;
        }


    }
}
