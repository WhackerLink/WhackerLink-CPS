using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whackerlink_CPS
{
    public class Site
    {
        public string Name { get; set; }
        public string ControlChannel { get; set; }
        public List<string> VoiceChannels { get; set; }
        public Location Location { get; set; }
        public string SiteID { get; set; }
        public string SystemID { get; set; }
        public float Range { get; set; }
    }

    public class Location
    {
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
    }
}
