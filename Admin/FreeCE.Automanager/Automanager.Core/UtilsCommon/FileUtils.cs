using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Core.UtilsCommon
{
    public class FileUtils
    {
        /// <summary>
        /// Ghi nội dung vào file
        /// </summary>
        /// <param name="strContent">Nội dung thêm mới</param>
        /// <param name="uploadPath">Đường dẫn</param>
        /// <param name="fileName">Tên file cần sửa</param>
        /// <returns></returns>
        public static bool AppendToTextFile(string strContent, string uploadPath, string fileName)
        {
            var result = true;
            try
            {
                var byteArray = Encoding.UTF8.GetBytes(strContent);
                var stream = new MemoryStream(byteArray);
                var filePath = Path.Combine(uploadPath, fileName);
                var dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (!File.Exists(filePath))
                {
                    var fs = File.Create(filePath);
                    fs.Close();
                }

                var sw = File.AppendText(filePath);
                sw.WriteLine(strContent);
                // Writing a string directly to the file
                sw.Close();
            }
            catch (Exception)
            {
                result = false;
                //ExceptionHandler.Handle(exception, "FileUtility", "AppendToTextFile");
            }
            return result;
        }
        /// <summary>
        /// Ghi nội dung mới vào file đã có nội dung
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="uploadPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool PrependToTextFile(string strContent, string uploadPath, string fileName)
        {
            var result = true;

            try
            {
                var byteArray = Encoding.UTF8.GetBytes(strContent);
                var stream = new MemoryStream(byteArray);
                var filePath = Path.Combine(uploadPath, fileName);
                var dir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                if (!File.Exists(filePath))
                {
                    var fs = File.Create(filePath);
                    fs.Close();
                }

                // đọc nội dung từ file cũ
                var sr = new StreamReader(filePath);
                var oldContent = sr.ReadToEnd();
                sr.Close();

                // ghi nội dung mới
                var sw = File.AppendText(filePath);
                sw.WriteLine(strContent);

                // ghi nội dung cũ
                var gr = new StringReader(oldContent);
                sw.WriteLine(gr.ReadToEnd());

                sw.Close();
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
            
        }
        /// <summary>
        /// Đọc tất cả nội dung trong file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadAllText(string filePath, string fileName)
        {
            var result = string.Empty;
            return result;
        }

        public static void MoveFile(string File_A, string File_B, string Directory_A, string Directory_B)
        {
            //di chuyển file
            if (File.Exists(File_A) && File.Exists(File_B))
            {
                System.IO.File.Move(File_A, File_B);
            }
            // Di chuyển folder
            if (Directory.Exists(Directory_A))
            {
                if (Directory.Exists(Directory_B))
                {
                    Directory.Move(Directory_A, Directory_B);
                }
                else
                {
                    Directory.CreateDirectory(Directory_B);
                    Directory.Move(Directory_A, Directory_B);
                }
            }
        }
        //Đếm số lượng file trong thư mục
        public static int CountFileDirectory(string pathFile)
        {
            string[] parentDirectory = Directory.GetDirectories(pathFile);
            int countFile = parentDirectory.Length;
            return countFile;
        }
        //Xóa 1 loại file được chỉ định trong folder,
        public static void DeleteFile(string pathFile)
        {
            System.IO.File.Delete(pathFile);
        }
        //Xoa folder
        public static void DeleteFolder(string uploadPath)
        {
            try
            {
                if (!Directory.Exists(uploadPath))
                    return;

                var directory = new DirectoryInfo(uploadPath);
                foreach (var file in directory.GetFiles())
                    file.Delete();
                foreach (var file in directory.GetFiles()) file.Delete();
                foreach (var subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
                directory.Delete();
                // delete
                //File.Delete(upload_path);
            }
            catch (Exception ex)
            {
               
            }
        }
        
    }
}
