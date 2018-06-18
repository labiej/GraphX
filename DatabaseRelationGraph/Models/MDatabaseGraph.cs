
namespace DatabaseRelationGraph.Models
{
    using DatabaseRelationGraph.DataAccess;
    using QuickGraph;
    using System.Collections.Generic;
    using System.Linq;

    public class MDatabaseGraph : BidirectionalGraph<MTable, MForeignKey>
    {
        public static MDatabaseGraph CreateExample()
        {
            DatabaseInfo database = CSVParser.ParseToDTO(@"E:\temp\relations.csv", false);

            MDatabaseGraph graph = new MDatabaseGraph();
            Dictionary<string, MTable> tableMap = new Dictionary<string, MTable>();
            foreach (var table in database.TableNames)
            {
                MTable tableVertex = new MTable(table);
                graph.AddVertex(tableVertex);
                tableMap.Add(table, tableVertex);
            }
                
            foreach(var keySet in database.ForeignKeys.Values)
            {
                foreach(var key in keySet)
                {
                    MTable source = tableMap[key.From];
                    MTable target = tableMap[key.To];
                    graph.AddEdge(new MForeignKey(source, target) { Text = $"FK{source.Text}{target.Text}" });
                }
            }

            

            return graph;
        }
    }
}
