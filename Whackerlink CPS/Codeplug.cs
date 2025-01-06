/*
* WhackerLink - WhackerLink-CPS
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
* 
* Copyright (C) 2024 Caleb, K4PHP
* 
*/

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
            public ModelMode BaseMode { get; set; } = ModelMode.FIVEMRADIO;
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
    }
}