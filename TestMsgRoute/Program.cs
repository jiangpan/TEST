
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMsgRoute
{
    class Program
    {
        static void Main(string[] args)
        {

            Router objRouter = Router.Instance;

            objRouter.RegisterObserver(new MessageLogger());

            // To test Asynchrous operationâ€¦we have put in a for loop

            for (int i = 0; i <= 10000; i++)
            {
                objRouter.ProcessMessage("Message" + i.ToString());
            }

        }
    }
}
