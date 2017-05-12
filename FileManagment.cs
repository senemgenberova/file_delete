using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManagment_ns
{

    class FileManagment
    {
        private string dir;
        private string[] allFiles;
        List<string> foundedFiles = new List<string>();

        public FileManagment(string dir)
        {
            this.dir = dir;
        }

        public string[] AllFiles{
            get
            {
                return this.allFiles;
            }
        }

        public void getAllFiles()
        {
            this.allFiles = Directory.GetFiles(this.dir,"*.*",SearchOption.AllDirectories);
            foreach (string file in this.allFiles)
            {
                FileInfo info = new FileInfo(file);
                DateTime now = DateTime.Now;
                DateTime file_date = new DateTime(info.LastAccessTime.Year, info.LastAccessTime.Month, info.LastAccessTime.Day, info.LastAccessTime.Hour, info.LastAccessTime.Minute, info.LastAccessTime.Second);

                double diff = now.Subtract(file_date).TotalDays;
                if (diff > 10)
                {
                    foundedFiles.Add(info.FullName.ToString());
                    Console.WriteLine(diff.ToString() + " " + info.FullName.ToString());
                }
                
            }
        }

        public void deleteAllFiles()
        {
            foreach(string single in this.foundedFiles)
            {
                File.Delete(single);
            }
        }
    }
}
