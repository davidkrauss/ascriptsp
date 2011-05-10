using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace nothinbutdotnetprep.CodeKata
{
    public class PrettyDumpFolder
    {
        /// <summary>
        /// Actually the same algorithm I used years ago on mainframe for IMS DB since
        /// recursion in COBOL could blow up.
        /// </summary>
        /// <param name="root"></param>
        public static void WalkDirectoryTree(string root)
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
