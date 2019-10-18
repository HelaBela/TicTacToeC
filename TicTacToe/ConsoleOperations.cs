using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class ConsoleOperations:IConsoleService
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }

        public void Write(string content, string content2, string content3, string content4)
        {
            Console.WriteLine(content, content2, content3, content4);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}