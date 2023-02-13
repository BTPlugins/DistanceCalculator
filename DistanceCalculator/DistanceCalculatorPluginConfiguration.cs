using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DistanceCalculatorPlugin
{
    public class DistanceCalculatorPluginConfiguration : IRocketPluginConfiguration
    {
        public bool DebugMode { get; set; }
        public void LoadDefaults()
        {
            DebugMode = false;
        }
    }
}
