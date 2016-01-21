using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class Game
    {
        private int playerName;
        private List<string> players;

        public void start()
        {
            players = Program.clientsObjList.Keys.OfType<string>().ToList();
            Console.WriteLine(string.Join(", ", players));
        }

        private void sendImage()
        {

        }


    }
}
