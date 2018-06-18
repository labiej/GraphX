using GraphX.PCL.Common.Models;

namespace DatabaseRelationGraph.Models
{
    public class MForeignKey : EdgeBase<MTable>
    {
        public MForeignKey()
            : base(null, null, 1)
        {
        }

        public MForeignKey(MTable source, MTable target, double weight = 1)
            : base(source, target, weight)
        {
        }

        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
