using System;
using System.ServiceProcess;
using Microsoft.Win32;
using System.Threading;
using LCDPower;
using System.IO;

namespace MonitorOffOnLock
{
    public partial class MonitorOffOnLock : ServiceBase
    {
        StreamWriter sw;

        public MonitorOffOnLock()
        {
            sw = new StreamWriter(@"D:\Projects\TurnOffLCD\MonOffOutput.txt");

            sw.WriteLine("Initializing");
            sw.Flush();

            InitializeComponent();

            sw.WriteLine("Initialized");
            sw.Flush();
        }

        protected override void OnStart(string[] args)
        {
            StartService();
        }

        public void StartService()
        {
            sw.WriteLine("Starting");
            sw.Flush();

            sw.WriteLine("Turning Off");
            sw.Flush();

            LCDPower.LCDPower.TurnOffLCD(sw);

            sw.WriteLine("Turned Off");
            sw.Flush();
        }

        protected override void OnStop()
        {
            StopService();
        }

        public void StopService()
        {
            sw.WriteLine("Removing Listener");
            sw.Flush();

            //Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            sw.WriteLine("Listener Removed");
            sw.Flush();
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            sw.WriteLine("Event Fired");
            sw.Flush();

            Console.WriteLine("Event Occured");
            if (changeDescription.Reason == SessionChangeReason.SessionLock)
            {
                //I left my desk
                sw.WriteLine("Locked");
                //try
                //{
                    LCDPower.LCDPower.TurnOffLCD(sw);
                //}
                //catch (Exception ex)
                //{
                    //sw.WriteLine("Error Occured");
                    //sw.WriteLine(ex.Message);
                //}
            }
            else if (changeDescription.Reason == SessionChangeReason.SessionUnlock)
            {
                //I returned to my desk
                sw.WriteLine("Unlocked");
            }

            sw.WriteLine("Event Handled");
            sw.Flush();
        }
    }
}