using System.Collections.ObjectModel;

namespace DatabaseRelationGraph.ViewModels
{
    public class VMRelationList : VMBase
    {
        public VMRelationList()
        {
        }

        public VMTable Source { get; set; }
        public ObservableCollection<VMForeignKey> References { get; set; }
        public ObservableCollection<VMForeignKey> ReferencedBy { get; set; }
    }
}
