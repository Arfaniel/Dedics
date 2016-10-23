using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dedics
{
    class User
    {
        public string ip { get; set; }
        public string login { get; set; }
        public string pass { get; set; }
        public string city { get; set; }

        public override string ToString()
        {
            return ip + ' ' + login + ' ' + pass;
        }
    }
}
