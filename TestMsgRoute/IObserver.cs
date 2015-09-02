using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMsgRoute
{
    public abstract class IObserver
    {
        public string FilePath;
        public abstract void ProcessMessage(string strMessage);

    }
}
