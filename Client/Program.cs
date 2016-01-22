using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        public static string PlayerName = "0";
        public static Forms.Chat chat_main;
        public static Network network = new Network();
        public static Forms.Playground playground;
        public static bool turn = false; //to check turn
        public static StartForm startform;
        public static Forms.Logging loggingform;
        public static bool chatRun = false;
        public static bool playgroundRun = false;
        public static bool mainRun = true;
        
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
            Program.network.send("/#/disconnect");
            Music.Stop();
            Application.Exit();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();
    }
}
