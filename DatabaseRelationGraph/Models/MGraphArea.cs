using GraphX.Controls;

namespace DatabaseRelationGraph.Models
{
    public class MGraphArea : GraphArea<MTable, MForeignKey, MDatabaseGraph>
    {
        public static MGraphArea CreateExampleArea(MDatabaseGraph graph)
        {
            return new MGraphArea
            {
                LogicCore = GXDatabaseLogicCore.GetLogicCore(graph)
            }; ;
        }
    }
}
