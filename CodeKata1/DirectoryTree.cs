using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeKata1
{
    public class DirectoryTree
    {
        private const string directoryIndicator = @"+ ";
        private const string indentation =        @"  ";

        public DirectoryTree(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }

        public string Indentor { get; set; }

        public void PrintTree()
        {
            Console.WriteLine("Tree for: " + FilePath);

            Indentor = indentation;
            foreach (var directoryName in Directory.EnumerateDirectories(FilePath))
            {
                Console.WriteLine(Indentor + directoryIndicator +
                    directoryName.Substring(directoryName.LastIndexOf('\\') + 1));
                Indentor += indentation;
                DisplayFileNames(directoryName);
                Indentor = Indentor.Substring(0, Indentor.Length - indentation.Length);
            }
        }

        private void DisplayFileNames(string directoryPath)
        {
            foreach (var fileName in Directory.EnumerateFiles(directoryPath))
            {
                Console.WriteLine(Indentor + indentation + fileName.Substring(fileName.LastIndexOf('\\')+1));
            }
        }

    }
}
