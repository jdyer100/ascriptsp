using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeKata1
{
    public class DirectoryTree
    {
        private string indentation = @" ";
        public DirectoryTree(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }

        public void PrintTree()
        {
            DisplayFileName(FilePath);
        }

        private void DisplayFileName(string directoryPath)
        {
            foreach (var fileName in Directory.EnumerateFiles(directoryPath))
            {
                Console.WriteLine(indentation + fileName);
            }
        }
    }
}
