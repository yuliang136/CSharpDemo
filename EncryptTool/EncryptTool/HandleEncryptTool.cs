using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptTool
{
    class HandleEncryptTool
    {
        public string m_InputPath = string.Empty;               // 输入目录路径.
        public string m_OutputPath = string.Empty;              // 输出目录路径.


        public void Run(string[] strParams)
        {
            m_InputPath = strParams[1];
            m_OutputPath = strParams[2];

            //Console.WriteLine(m_InputPath);
            //Console.WriteLine(m_OutputPath);

            EncryptDir(m_InputPath, m_OutputPath);

            Console.WriteLine("Handle Done!");
        }

        private void EncryptDir(string strInputPath, string strOutputPath)
        {
            if(!Directory.Exists(strOutputPath))
            {
                Directory.CreateDirectory(strOutputPath);
            }

            // 只考虑一层目录.
            string destPath = string.Empty;
            DirectoryInfo diSource = new DirectoryInfo(strInputPath);
            FileInfo[] sourceFileInfos = diSource.GetFiles("*", SearchOption.TopDirectoryOnly);

            foreach (var eachFileInfo in sourceFileInfos)
            {
                //
                destPath = Path.Combine(strOutputPath, eachFileInfo.Name);
                EncryptFile(eachFileInfo.FullName, destPath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="destPath">目标路径</param>
        private void EncryptFile(string sourcePath, string destPath)
        {
            String keys = "hx12345Keyr5";
            byte[] Key = Encoding.Unicode.GetBytes(keys);

            String strIV = "HQSH";
            byte[] IV = Encoding.Unicode.GetBytes(strIV);

            Console.WriteLine("Handle " + sourcePath);
            //Console.WriteLine(destPath);

            // 读取源数据
            byte[] sourceData = File.ReadAllBytes(sourcePath);

            // 写出加密文件.
            FileStream fStream = File.Open(destPath, FileMode.OpenOrCreate);
            CryptoStream cStream = new CryptoStream(fStream,
                new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                CryptoStreamMode.Write);

            BinaryWriter sBinaryWriter = new BinaryWriter(cStream);
            sBinaryWriter.Write(sourceData);

            sBinaryWriter.Close();
            cStream.Close();
            fStream.Close();
        }
    }
}
