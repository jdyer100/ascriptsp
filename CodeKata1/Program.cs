using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeKata1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryTree directoryTree = new DirectoryTree(@"c:\nbdn");
            directoryTree.PrintTree();
            Console.Read();
        }
    }
}
