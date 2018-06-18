using GraphX.PCL.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRelationGraph.Models
{
    public class MTable : VertexBase
    {
        /// <summary>
        /// Used for serialization
        /// </summary>
        public MTable()
            : this(string.Empty)
        {

        }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="text"></param>
        public MTable(string text = "")
        {
            Text = text;
        }
        
        public string Text { get; private set; }

        public override string ToString()
        {
            return Text;
        }

    }
}
