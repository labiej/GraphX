using GraphX.PCL.Common.Enums;
using GraphX.PCL.Logic.Algorithms.LayoutAlgorithms;
using GraphX.PCL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseRelationGraph.Models
{
    public class GXDatabaseLogicCore : GXLogicCore<MTable, MForeignKey, MDatabaseGraph>
    {
        public static GXDatabaseLogicCore GetLogicCore(MDatabaseGraph graph)
        {
            GXDatabaseLogicCore core = new GXDatabaseLogicCore()
            {
                Graph = graph
            };
            core.DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.Circular;
            core.DefaultLayoutAlgorithmParams = core.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.Circular);
            ((CircularLayoutParameters)core.DefaultLayoutAlgorithmParams).Seed = (int)(DateTime.UtcNow.Ticks % int.MaxValue);

            core.DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA;
            core.DefaultOverlapRemovalAlgorithmParams.HorizontalGap = 500;
            core.DefaultOverlapRemovalAlgorithmParams.VerticalGap = 500;

            core.DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.SimpleER;
            
            core.AsyncAlgorithmCompute = false;

            return core;
        }
    }
}
