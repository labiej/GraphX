using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRelationGraph.DataAccess
{
    public class Key
    {
        public Key()
            : this(string.Empty, string.Empty)
        {
        }

        public Key(string from, string to)
        {
            To = to;
            From = from;
        }

        public string To { get; set; }
        public string From { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Key k)
            {
                return k.From == this.From && k.To == this.To;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = 23 * hash + (To?.GetHashCode() ?? 0);
            hash = 23 * hash + (From?.GetHashCode() ?? 0);
            return hash;
        }
    }
}
