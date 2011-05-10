﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace nothinbutdotnetprep.CodeKata
{
    public class PrettyDumpFolder
    {

        public static void TraverseTree(string root)
        {
            if (!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException(root + " invalid");
            }
            var directories = new Stack<string>();
            directories.Push(root);
            var depth = 0;
            while (directories.Count > 0)
            {
                depth+=2;
                var currentDir = directories.Pop();
                Console.WriteLine(" ".PadLeft(depth) + currentDir);
                var subDirs = Directory.GetDirectories(currentDir);
                string[] files = files = Directory.GetFiles(currentDir);

                foreach (var file in files)
                {
                     Console.WriteLine(" ".PadLeft(depth) + file);
                }

                foreach (var str in subDirs)
                    directories.Push(str);
            }
        }


    }


}
