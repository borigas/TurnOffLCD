using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading;

namespace PowerSaveOnLock
{
    class PowerSaveOnLock
    {
        static void Main(String[] args)
        {
            PowerSaveOnLock psol = new PowerSaveOnLock();
            
            Thread.Sleep(Timeout.Infinite);
        }

        PowerSaveOnLock()
        {
            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);
        }

        void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                //I left my desk
                LCDPower.LCDPower.TurnOffLCD();
                Thread.Sleep(1000);
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                //I returned to my desk
            }
        }
    }
}
