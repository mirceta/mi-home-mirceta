using System;

namespace MiHomeLib.Devices
{
    public class MiHomeDevice
    {
        public string Sid { get; }
        public string Name { get; set; }
        public string Type { get; }

        protected MiHomeDevice(string sid, string type)
        {
            Sid = sid;
            Type = type;
        }

        public void ParseData(string command) {
            
            Console.WriteLine(this.GetType().ToString() + ": " + command);
        }
    }
}