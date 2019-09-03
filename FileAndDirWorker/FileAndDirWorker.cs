using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileAndDirWorker
{
    public class FileAndDirWorker
    {

        /// <summary>
        /// Копирует каталоги
        /// </summary>
        /// <param name="sourceDir"></param>
        /// <param name="destDir"></param>
        static public void CopyDir(string sourceDir, string destDir)
        {
            string[] dirs = Directory.GetDirectories(sourceDir);
            string[] files = Directory.GetFiles(sourceDir);
            string newDestiny = destDir;
            string newFileName = "new.new";
            DirectoryInfo dirInfo;
            FileInfo fileInfo;
            foreach (string directory in dirs)
            {
                dirInfo = new DirectoryInfo(directory);
                newDestiny = System.IO.Path.Combine(destDir, dirInfo.Name);
                CopyDir(directory, newDestiny);
                foreach (string file in files)
                {
                    fileInfo = new FileInfo(file);
                    newFileName = System.IO.Path.Combine(file, dirInfo.Name);
                    File.Copy(file, newFileName);
                }
            }
        }
        /// <summary>
        ///метод выдаёт все файлы с картинками, находящиеся по указанным путям 
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="result_list"></param>
        public static void GetAllImageFiles(string[] paths, List<string> result_list)
        {
            foreach (string path in paths)
            {
                string extension = "";
                if (Directory.Exists(path))
                {
                    string[] files = Directory.GetFiles(path);
                    GetAllImageFiles(files, result_list);
                    string[] dirs = Directory.GetDirectories(path);
                    GetAllImageFiles(dirs, result_list);
                }
                else
                    if (File.Exists(path))
                        extension = System.IO.Path.GetExtension(path).ToLower();
                   
                if (CheckImageExtension( extension)) result_list.Add(path);
            }

        }

        /// <summary>
        /// Проверяет допустимые расширения для изображений
        /// </summary>
        /// <param name="filename">расширение файла</param>
        static private bool CheckImageExtension(string extension)
        {
            var extensionList = new List<string>();
            extensionList.Add(".jpeg");
            extensionList.Add(".png");
            extensionList.Add(".bmp");
            extensionList.Add(".jpg");

            return
                extensionList
                    .Where(x => x == extension)
                    .Select(x => x)
                    .Count() > 0 ?
                    true : false;
        }


    }
}
