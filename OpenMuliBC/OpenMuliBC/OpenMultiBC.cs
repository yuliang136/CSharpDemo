using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMuliBC
{
    class OpenMultiBC
    {

        public void Open(string strInputDir, string strOutDir)
        {
            List<string> ltCommands = new List<string>();

            // 批处理多个文件.
            string[] files = Directory.GetFiles(strInputDir);
            for (int i = 0; i < files.Length; i++)
            {
                HandleEachFile(files[i], strOutDir, ltCommands);
            }

            
            // 在执行文件同目录里生成文件.
            Write2File("batchFile.bat", ltCommands);

            
        }

        private void Write2File(string strBatchFile, List<string> strList)
        {
            FileStream fs = new FileStream(strBatchFile, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            //开始写入
            string strEachLine = string.Empty;
            for (int i = 0; i < strList.Count; i++)
            {
                strEachLine = strList[i];

                if (i == strList.Count - 1)
                {
                    sw.Write(strEachLine);
                }
                else
                {
                    sw.WriteLine(strEachLine);
                }
            }

            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

        private void HandleEachFile(string strInputFilePath, string strOutDir, List<string> ltCommands)
        {
            // 组合出output文件
            FileInfo fi = new FileInfo(strInputFilePath);
            String fileOutPath = string.Format(@"{0}\{1}", strOutDir, fi.Name);

            string strBCCommand = string.Format("BCompare /fv=\"Text Compare\"");

            string strFullCommand = string.Format("{0} {1} {2}",
                                                    strBCCommand,
                                                    strInputFilePath,
                                                    fileOutPath);

            ltCommands.Add(strFullCommand);
        }
    }
}
