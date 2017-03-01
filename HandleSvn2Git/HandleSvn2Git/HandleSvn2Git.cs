using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleSvn2Git
{
    class HandleSvn2Git
    {
        public string m_svnPath = string.Empty;             // svn目录路径.
        public string m_gitPath = string.Empty;             // git目录路径.
        public string m_gitBranchName = string.Empty;       // git分支名称.
        public string m_compareName = string.Empty;         // BeyondCompare Session Name.

        public void Run(string[] strParams)
        {
            //Console.WriteLine(strParams[1]);
            //Console.WriteLine(strParams[2]);

            //Console.WriteLine("Here");
            m_svnPath = strParams[1];
            m_gitPath = strParams[2];
            m_gitBranchName = strParams[3];
            m_compareName = strParams[4];

            Console.WriteLine(m_svnPath);
            Console.WriteLine(m_gitPath);
            Console.WriteLine(m_gitBranchName);
            Console.WriteLine(m_compareName);

            HandleSvnPath(m_svnPath);
        }

        private void HandleSvnPath(string strSvnPath)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;            //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;       //接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;      //由调用程序获取输出信息
            p.StartInfo.CreateNoWindow = true;              //不显示程序窗口
            p.Start();                                      //启动程序


            string strRevert = string.Format("svn revert -R {0}", strSvnPath);
            p.StandardInput.WriteLine("{0} ",strRevert);

            string strCleanUp = string.Format("svn cleanup --remove-unversioned --remove-ignored {0}", strSvnPath);
            p.StandardInput.WriteLine("{0} ", strCleanUp);

            string strUpdate = string.Format("svn update {0}", strSvnPath);
            p.StandardInput.WriteLine("{0} ", strUpdate);


            p.StandardInput.WriteLine("exit");
            p.StandardInput.AutoFlush = true;

            string output = p.StandardOutput.ReadToEnd();

            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();

            Console.WriteLine(output);
        }
    }
}
