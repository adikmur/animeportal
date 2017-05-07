using System;
using System.IO;

namespace AnimePortal
{
    class Logger
    {
        private const string _file = "../../Data/log.txt";

        public static void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(_file, true))
            {
                sw.WriteLine($"{DateTime.Now} - {message}");
            }
        }
    }
}
