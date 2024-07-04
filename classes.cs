using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whackerlink_CPS
{
    public class Codeplug
    {
            public RadioWideConfiguration radioWide { get; set; }
            public List<System> systems { get; set; }
            public List<Zone> zones { get; set; }

            public class RadioWideConfiguration
            {
                public string hostVersion { get; set; }
                public string codeplugVersion { get; set; }
                public string radioAlias { get; set; }
                public string serialNumber { get; set; }
                public int model { get; set; }
            }

            public class System
            {
                public string name { get; set; }
                public string address { get; set; }
                public string port { get; set; }
                public string rid { get; set; }
            }

            public class Zone
            {
                public string name { get; set; }
                public List<Channel> channels { get; set; }
            }

            public class Channel
            {
                public string name { get; set; }
                public string system { get; set; }
                public string tgid { get; set; }
            }

            public System GetSystemForChannel(Channel channel)
            {
                return systems.FirstOrDefault(s => s.name == channel.system);
            }
        }
    }