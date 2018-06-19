using DatabaseRelationGraph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRelationGraph.ViewModels
{
    public class VMTable : VMBase<MTable>
    {
        public VMTable(MTable model)
            : base(model)
        {
        }

        public string Name => Model.Text;
    }
}
