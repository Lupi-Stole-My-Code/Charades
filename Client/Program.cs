using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        public static string PlayerName = "Gosc";
        public static Forms.Chat chat_main;
        public static Network network = new Network();
        public static Forms.Playground playground;
        public static bool turn = false;//to check turn
        public static StartForm startform;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            startform = new StartForm();
            Application.Run(startform);
            
        }

        public static void Exit()
        {
            Music.Stop();
            Application.Exit();
        }
    }
}
