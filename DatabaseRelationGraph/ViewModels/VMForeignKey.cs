using DatabaseRelationGraph.Models;

namespace DatabaseRelationGraph.ViewModels
{
    public class VMForeignKey : VMBase<MForeignKey>
    {
        public VMForeignKey(MForeignKey model)
            : base(model)
        {
        }

        public VMTable Source => new VMTable(Model.Source);
        public VMTable Target => new VMTable(Model.Target);
        public string Name => Model.Text;
    }
}
