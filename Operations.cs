using System;
using System.Globalization;
using System.IO;

namespace videosInFolder
{
    public class Operations
    {
        public static int fileNum;

        public static void PlaceFile(FileInfo file, string folderPath)
        {
            if (fileNum == 0)
            {
                GetFileNum(folderPath);
            }
            
            var finalPath = folderPath + "\\video" + (fileNum + 1).ToString() + file.Extension;
            fileNum++;
            file.CopyTo(finalPath);
            file.Delete();
        }

        private static void GetFileNum(string folderPath)
        {
            foreach (var filename in Directory.GetFiles(folderPath))
            {
                var file = new FileInfo(filename);
                
                if (!file.Name.StartsWith("video")) continue;
                var nfileNum = int.Parse(file.Name.Replace("video", "").Replace(file.Extension, ""));
                
                if (nfileNum > fileNum)
                {
                    fileNum = nfileNum;
                }
            }
        }
    }
}