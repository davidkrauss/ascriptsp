using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace nothinbutdotnetprep.CodeKata
{
    public class PrettyDumpFolder
    {

        public PrettyDumpFolder(String path)
        {
            TraverseTree(path);

        }



        public static void TraverseTree(string root)
        {
            Stack<string> dirs = new Stack<string>(20);
            if (!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException(root + " invalid");
            }
            dirs.Push(root);
            int depth = 0;
            while (dirs.Count > 0)
            {
                depth++;
                var currentDir = dirs.Pop();
                Console.WriteLine(" ".PadLeft(depth) + "{0}", currentDir);
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                catch (Exception)
                {
                    throw;
                }

                string[] files = null;
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (Exception)
                {
                    throw;
                }

                foreach (var file in files)
                {
                    try
                    {
                        Console.WriteLine(" ".PadLeft(depth) + "{0}", file);
                    }
                    catch (Exception)
                    {
                    }
                }

                foreach (var str in subDirs)
                    dirs.Push(str);
            }
        }


    }


}
