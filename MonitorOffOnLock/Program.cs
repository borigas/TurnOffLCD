using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace MonitorOffOnLock
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
    				new MonitorOffOnLock() 
			    };
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                using (MonitorOffOnLock s = new MonitorOffOnLock())
                {
                    s.StartService();

                    Console.WriteLine("press enter to exit");
                    Console.ReadLine();

                    s.StopService();
                }
            }
        }
    }
}
