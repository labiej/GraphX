using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRelationGraph.DataAccess
{
    public class DatabaseInfo
    {
        public DatabaseInfo()
        {
            TableNames = new HashSet<string>();
            ForeignKeys = new Dictionary<string, HashSet<Key>>();
        }

        public HashSet<string> TableNames { get; set; }

        public Dictionary<string, HashSet<Key>> ForeignKeys { get; set; }
    }
}
