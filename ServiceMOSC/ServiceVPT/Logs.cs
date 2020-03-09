using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServiceVPT
{
    class Logs
    {
        public static void CreateLog(string text)
        {
            string path = GlobalSetting.Path + @"\Logs";
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (FileStream fstream = new FileStream($@"{path}\Logs.txt", FileMode.OpenOrCreate))
            {
                fstream.Seek(0, SeekOrigin.End); // минус 5 символов с конца потока
                // преобразуем строку в байты
                byte[] timeLogs = System.Text.Encoding.Default.GetBytes(DateTime.Now.ToString() + " ");
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                byte[] line = System.Text.Encoding.Default.GetBytes("-------------------------------------------------------------\n");
                // запись массива байтов в файл
                fstream.Write(timeLogs, 0, timeLogs.Length);
                fstream.Write(array, 0, array.Length);
                fstream.Write(line, 0, line.Length);
            }
        }
    }
}
