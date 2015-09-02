using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestMsgRoute
{
    public class Router
    {

        private static List<IObserver> lstObservers;

        private static object objLock = new object();

        private static Router objRouter = null;



        delegate void RouterDelegate(string strMessage);



        // to ensure no one is creating an object

        private Router()
        {

            lstObservers = new List<IObserver>();

        }



        // the public Instance property everyone uses to access the Router

        public static Router Instance
        {

            get
            {

                // If this is the first time we're referring to the singleton object, the private variable will be null.

                if (objRouter == null)
                {

                    /* for thread safety, lock an object when instantiating the new Router object. This prevents

                     * other threads from performing the same block at the same time.

                     */

                    lock (objLock)
                    {

                        objRouter = new Router();

                    }

                }

                return objRouter;

            }

        }





        public void RegisterObserver(IObserver objObserverImpl)
        {

            if (!lstObservers.Contains(objObserverImpl))
            {

                lstObservers.Add(objObserverImpl);

            }

        }



        public void ProcessMessage(string strMessage)
        {

            RouterDelegate dlgtRouter = new RouterDelegate(this.NotifyMessage);

            dlgtRouter.BeginInvoke(strMessage, null, null);

        }





        private void NotifyMessage(string strMessage)
        {

            foreach (IObserver observer in lstObservers)
            {

                observer.ProcessMessage(strMessage);

            }

        }

    }
}
