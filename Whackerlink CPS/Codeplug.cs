using System.Collections.Generic;

namespace Whackerlink_CPS
{
    public class Codeplug
    {
        public RadioWideConfiguration RadioWide { get; set; }
        public RadioEgroConfiguration ErgonomicsWide { get; set; }
        public List<System> Systems { get; set; } = new List<System>();
        public List<Zone> Zones { get; set; } = new List<Zone>();

        public class RadioWideConfiguration
        {
            public string HostVersion { get; set; }
            public string CodeplugVersion { get; set; }
            public string RadioAlias { get; set; }
            public string SerialNumber { get; set; }
            public string Model { get; set; }
            public string InCarMode { get; set; }

            public RadioWideConfiguration() { }
        }

        public class RadioEgroConfiguration
        {
            public bool KeepOnTop { get; set; }
            public bool GlobalPttKeybind { get; set; }
            public string PttKeyBind { get; set; }

            public RadioEgroConfiguration() { }
        }

        public class System
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public int Port { get; set; }
            public string Rid { get; set; }
            public Site Site { get; set; }

            public System() { }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Zone
        {
            public string Name { get; set; }
            public List<Channel> Channels { get; set; } = new List<Channel>();

            public Zone() { }
        }

        public class Channel
        {
            public string Name { get; set; }
            public string System { get; set; }
            public string Tgid { get; set; }

            public Channel() { }
        }

        public class Site
        {
            public Site() { }
        }
    }
}