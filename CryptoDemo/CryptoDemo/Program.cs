using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            //CryptoStream cs = new CryptoStream()

            String keys = "yuliangKeyr5";
            byte[] Key = Encoding.Unicode.GetBytes(keys);

            String strIV = "HXIV";
            byte[] IV = Encoding.Unicode.GetBytes(strIV);

            //String data = "I am yuliang";
            //String strFileName = "EncryptFile.byte";

            //EncryptTextToFile(data, strFileName, Key, IV);


            //byte[] bytes = File.ReadAllBytes("skill.bytes");

            //EncryptTextToFile(bytes, strFileName, Key, IV);

            // 加载加密的文件.
            //byte[] EncryptedData = File.ReadAllBytes("EncryptFile.byte");

            DecryptTextFromFile("EncryptFile.byte", Key, IV);



            Console.WriteLine("Here");

            //WriteToFile(data, strFileName);
            
        }

        public static string DecryptTextFromFile(String FileName, byte[] Key, byte[] IV)
        {
            try
            {
                // Create or open the specified file. 
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),CryptoStreamMode.Read);

                BinaryReader sBinaryReader = new BinaryReader(cStream);
                //sBinaryReader.read

                byte[] DecryptedData = sBinaryReader.ReadBytes(Convert.ToInt32(fStream.Length));

                //// Create a StreamReader using the CryptoStream.
                //StreamReader sReader = new StreamReader(cStream);

                //// Read the data from the stream 
                //// to decrypt it.
                //string val = sReader.ReadLine();

                // Close the streams and
                // close the file.

                sBinaryReader.Close();
                cStream.Close();
                fStream.Close();

                // 写出文件.
                File.WriteAllBytes("DecryptedData.bytes", DecryptedData);


                // Return the string. 
                return string.Empty;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file access error occurred: {0}", e.Message);
                return null;
            }
        }

        private static void WriteToFile(byte[] Data, String FileName)
        {
            
        }

        private static void WriteToFile(string data, string strFileName)
        {
            FileStream fs = new FileStream(strFileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(data);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

        public static void EncryptTextToFile(byte[] Data, String FileName, byte[] Key, byte[] IV)
        {
            try
            {
                // Create or open the specified file.
                FileStream fStream = File.Open(FileName, FileMode.OpenOrCreate);

                // Create a CryptoStream using the FileStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream,
                    new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                BinaryWriter sBinaryWriter = new BinaryWriter(cStream);
                sBinaryWriter.Write(Data);

                //// Create a StreamWriter using the CryptoStream.
                //StreamWriter sWriter = new StreamWriter(cStream);

                //// Write the data to the stream 
                //// to encrypt it.
                //sWriter.WriteLine(Data);

                //sWriter.WriteLine(Key);

                // Close the streams and
                // close the file.
                sBinaryWriter.Close();
                cStream.Close();
                fStream.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file access error occurred: {0}", e.Message);
            }

        }
    }
}
