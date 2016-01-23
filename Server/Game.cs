using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Server
{
    class Game
    {
        private int playerId;
        private List<string> players;
        public bool gameStarted = false;
        private int maxId;
        private string charade;
        private Timer turnTimer;
        private int thrSecs;

        public void start()
        {
            if(gameStarted)
            {
                Program.broadcast("Game is already started", "@", false);
                return;
            }
            players = Program.clientsObjList.Keys.OfType<string>().ToList();
            if(players.Count < 2)
            {
                Program.broadcast("Game cannot be started. Not enough players", "@", false);
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
            if(playerId <= maxId)
            {
                Program.broadcast("/@/YourTurn", "@", false, players[playerId]);
                thrSecs = 180;
                turnTimer = new Timer(turnThreadMain, null, 0, 1000);
            }
            else
            {
                playerId = 0;
                gameTurn();
                return;
            }
            playerId++;
        }

        private void turnThreadMain(Object o)
        {
            if(thrSecs == 30)
            {
                Program.broadcast("/@/TurnEnds30Sec", "@", false, players[playerId]);
            }
            if(thrSecs <= 0)
            {
                Program.broadcast("/@/TurnEnd", "@", false, players[playerId]);
                gameTurn();
                turnTimer.Dispose();
            }
            thrSecs--;
        }
        

        public void stop()
        {
            if (!gameStarted)
            {
                Program.broadcast("Game is not started", "@", false);
                return;
            }
            gameStarted = false;
            Program.broadcast("/@/Stop","@", false);
            turnTimer.Dispose();

        }

        public void showCommands()
        {
            Console.WriteLine("Broadcasting game Commands");
            Program.broadcast("Commands list:\n/start - starts game\n/stop - stops game", "@", false);
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

        public void checkCharade(string input, string player)
        {
            if(charade.ToLower() == input.ToLower())
            {
                Thread.Sleep(100);
                Program.broadcast("WINNER: " + player + "  Charade: " + input.ToLower(), "@", false);
                try
                {
                    turnTimer.Dispose();
                }
                catch { }

                gameTurn();
            }
        }


    }
}
