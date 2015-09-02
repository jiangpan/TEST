using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text;

namespace TestMsgRoute
{
    public class MessageLogger : IObserver
    {

        private static StreamWriter sw = null;

        private string strTempFilePath = string.Empty;



        public MessageLogger()
        {

            string strTempFilePath = base.FilePath + "\\" + DateTime.Now.ToString("MMddyyyy");

            if (!Directory.Exists(strTempFilePath.Trim()))

                Directory.CreateDirectory(strTempFilePath.Trim());

            FilePath = strTempFilePath + "\\MessageLog.txt";

        }



        public override void ProcessMessage(string strMessage)
        {

            lock (this)
            {

                sw = new StreamWriter(base.FilePath, true);

                sw.WriteLine("[" + DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToLongTimeString() + "] " +

                    "Message        : " + strMessage.Trim());

                sw.Flush();

                sw.Close();

            }

        }



    }
}
