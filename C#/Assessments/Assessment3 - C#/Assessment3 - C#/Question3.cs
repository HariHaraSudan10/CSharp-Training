using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    public class MobilePhone
    {
        public delegate void RingEventHandler();

        public event RingEventHandler OnRing;

        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");
            OnRing?.Invoke();
        }
    }

    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }

    class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }

    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }
    internal class Question3
    {
        static void Main(string[] args) 
        {
            MobilePhone phone = new MobilePhone();
            
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;
            Console.WriteLine("---------------------------");
            Console.WriteLine("Simulating incoming call...");
            Console.WriteLine("---------------------------");
            phone.ReceiveCall();
            Console.Read();
        }
    }
}
