using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FindRefsMulti
{
    public class FindRefWithMulti
    {
        private string m_assetPath;
        private string m_filePath;

        // 设置一个内存锁.
        private readonly object locker = new object();
        private List<Thread> lstThreads = new List<Thread>();

        public List<string> listResults = new List<string>();


        public FindRefWithMulti(string strAssetPath, string strFilePath)
        {
            m_assetPath = strAssetPath;
            m_filePath = strFilePath;
        }

        // 这里设计出一个类结构来保存线程处理的数据和线程的信息.
        public class ThreadHandleInfo
        {
            public string threadName = string.Empty;
            public Dictionary<string, string> inputData = new Dictionary<string, string>(); // 进行任务分配.
            public List<string> outputData; // 共用的一份地址 需要加锁处理
            public int nWaitTime;
        }


        public void TheadEachRun(object obj)
        {
            // Console.WriteLine("SetInfo1 Start");

            // 进行拆箱.
            ThreadHandleInfo threadHandleInfo = obj as ThreadHandleInfo;
            Console.WriteLine("threadHandleInfo Name = " + threadHandleInfo.threadName);


            Thread.Sleep(threadHandleInfo.nWaitTime);

            // 把结果写入.
            lock (locker)
            {
                // 加锁来处理 其他线程会阻塞住等待.

            }

            string strShow = string.Format("Thread {0} Done", threadHandleInfo.threadName);
            Console.WriteLine(strShow);

        }

        public void Run()
        {
            // 开辟线程.
            // 为不同线程分配不同任务.
            // 如何判断其他线程执行完毕.

            // 自定义线程个数 12-24个 测试花费时间.
            int nThreadNum = 12;
            for (int i = 0; i < nThreadNum; i++)
            {
                Thread eachThread = new Thread(new ParameterizedThreadStart(TheadEachRun));
                lstThreads.Add(eachThread);
                ThreadHandleInfo threadHandleInfo = new ThreadHandleInfo();
                threadHandleInfo.threadName = "threadID-" + i.ToString();
                threadHandleInfo.nWaitTime = 1000 * i;
                eachThread.Start(threadHandleInfo);

            }



            for (int i = 0; i < nThreadNum; i++)
            {
                lstThreads[i].Join();
            }


            Console.WriteLine("所有线程结束 打印出结果.");


            // Thread t1;
            // Thread t2;
            //
            // t1 = new Thread(new ParameterizedThreadStart(SetInfo1));
            // ThreadHandleInfo threadHandleInfo1 = new ThreadHandleInfo();
            // threadHandleInfo1.threadName = "t1";
            // threadHandleInfo1.nWaitTime = 5000;
            // t1.Start(threadHandleInfo1);
            //
            //
            // t2 = new Thread(new ParameterizedThreadStart(SetInfo1));
            // ThreadHandleInfo threadHandleInfo2 = new ThreadHandleInfo();
            // threadHandleInfo2.threadName = "t2";
            // threadHandleInfo2.nWaitTime = 3000;
            // t2.Start(threadHandleInfo2);
            //
            //
            // t1.Join();
            // t2.Join();
            //
            // Console.WriteLine("所有线程结束 打印出结果.");



        }



    }
}
