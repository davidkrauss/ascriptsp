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
        static int spacer;


        public static void WalkDirectoryTree(string root)
        {
            if (!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException(root + " invalid");
            }
            var directories = new Stack<string>();
            directories.Push(root);
            var depth = spacer;

            while (directories.Count > 0)
            {
                var currentDir = directories.Pop();
                depth -= spacer;

                Console.WriteLine(" ".PadLeft(depth) + currentDir);
                var subDirs = Directory.GetDirectories(currentDir);
                string[] files = files = Directory.GetFiles(currentDir);

                foreach (var file in files)
                {
                     Console.WriteLine(" ".PadLeft(depth) + file);
                }

                foreach (var str in subDirs)
                {
                    directories.Push(str);
                }
                depth += spacer;
            }
        }


    }


}
