using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class Game
    {
        private string playerName;
        private List<string> players;
        private bool gameStarted = false;

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

        public void setCharade(string charade, string user)
        {

        }


    }
}
