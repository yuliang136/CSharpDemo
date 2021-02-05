using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FindRefsMulti
{
    /// <summary>
    /// 计时通用类.
    /// </summary>
    public static class StopWatchUtils
    {
        public static Stopwatch m_stopWatch = null;     // 提供记时通用方法.
        public static string m_stopWatchShow = string.Empty;

        /// <summary>
        /// WatchStop初始化
        /// </summary>
        public static void WatchStopInit()
        {
            if (null == m_stopWatch)
            {
                m_stopWatch = new Stopwatch();
                m_stopWatch.Start();
            }
            else
            {
                m_stopWatch.Stop();
                m_stopWatch.Start();
            }
        }

        /// <summary>
        /// 结束计时后 马上再次开启.
        /// </summary>
        /// <param name="strInput"></param>
        public static void RecordWatchStop(string strInput)
        {
            m_stopWatch.Stop();
            m_stopWatchShow = string.Format(strInput + " Cost time : " + m_stopWatch.ElapsedMilliseconds / 1000.0f);
            Console.WriteLine(m_stopWatchShow);

            m_stopWatch.Reset();
            m_stopWatch.Start();
        }

        /// <summary>
        /// 结束计时
        /// </summary>
        public static void WatchStopEnd()
        {
            if (m_stopWatch != null)
            {
                m_stopWatch.Stop();
                m_stopWatch = null;
            }

        }

        /// <summary>
        /// 结束计时 输出Log
        /// </summary>
        /// <param name="strInput"></param>
        public static void WatchStopOnceEnd(string strInput)
        {
            m_stopWatch.Stop();
            m_stopWatchShow = string.Format(strInput + " Cost time : " + m_stopWatch.ElapsedMilliseconds / 1000.0f);
            Console.WriteLine(m_stopWatchShow);
            m_stopWatch = null;
        }
    }
}
