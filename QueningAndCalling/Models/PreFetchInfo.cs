using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GJJCallingSys.Models
{
    class PreFetchInfo
    {
        readonly string name;
        public string Name { get { return name; } }

        readonly string idcard;
        public string Idcard { get { return idcard; } }

        readonly DateTime auditime;
        public DateTime Auditime { get { return auditime; } }

        readonly string responsnum;
        public string ResponsNum { get { return responsnum; } }

        public PreFetchInfo(string name, string idcard, DateTime auditime, string responsnum)
        {
            this.name = name;
            this.idcard = Idcard;
            this.auditime = auditime;
            this.responsnum = responsnum;

        }

    }
}
