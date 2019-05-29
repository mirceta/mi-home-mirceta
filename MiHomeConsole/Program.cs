using System;
using System.Threading.Tasks;
using MiHomeLib;


using System.Collections.Generic;
using MiHomeLib.Devices;

namespace MiHomeConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // pwd of your gateway (optional, needed only to send commands to your devices) 
            // and sid of your gateway (optional, use only when you have 2 gateways in your LAN)
            using (var miHome = new MiHome("m04dz82dp4pl5770"))
            {
                Task.Delay(5000).Wait();

                IReadOnlyCollection<MiHomeDevice> some = miHome.GetDevices();
                foreach (var miHomeDevice in some)
                {
                    if (miHomeDevice.GetType() == typeof(Switch))
                    {
                        Console.WriteLine($"{miHomeDevice.Sid}, {miHomeDevice.GetType()}, {miHomeDevice}"); // all discovered devices
                        miHomeDevice.ParseData("{ \"status\": \"click\"}");
                    }

                }

                var gateway = miHome.GetGateway();

                Console.WriteLine(gateway); // Sample output --> Rgb: 0, Illumination: 997, ProtoVersion: 1.0.9

                gateway?.EnableLight(); // "white" light by default

                Console.ReadLine();
            }
        }
    }
}
