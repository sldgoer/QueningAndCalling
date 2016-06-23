using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJCallingSys.Models
{
    class Confg
    {
        public string Name { get; private set; }
        public string CfgType { get; private set; }
        public Dictionary<string, string> Configurations { get; private set; }
        
        public Confg() {}

        public Confg(string name, string cfgType,Dictionary<string,string> configurations)
        {
            this.Name = name;
            this.CfgType = cfgType;
            this.Configurations = configurations;
        }

        public string GetConfigValue(string configName)
        {
            return Configurations[configName].ToString();
        }
    }
}
