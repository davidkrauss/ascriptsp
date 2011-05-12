using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace nothinbutdotnetprep.CodeKata
{
    /// <summary>
    /// Actually the same algorithm I used years ago on mainframe for IMS DB since
    /// recursion in COBOL could blow up.
    /// </summary>
    public class PrettyDumpFolder
    {
        static int spaces;


        public int WalkDirectoryTree(string root, int spaces = 2)
        {
            if (!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException(root + " invalid");
            }
            var directories = new Stack<string>();
            directories.Push(root);
            int count=0;

            while (directories.Count > 0)
            {
                var currentDir = directories.Pop();
                int depth = currentDir.Split('\\').Count() * spaces;
                count++;

                Console.WriteLine(" ".PadLeft(depth) + currentDir);
                var subDirs = Directory.GetDirectories(currentDir);
                string[] files = files = Directory.GetFiles(currentDir);

                foreach (var file in files)
                {
                     Console.WriteLine(" ".PadLeft(depth + spaces) + Path.GetFileName(file));
                }

                foreach (var str in subDirs)
                {
                    directories.Push(str);
                }

            }

            return count;
        }


    }


}
