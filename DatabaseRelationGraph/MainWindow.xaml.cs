using DatabaseRelationGraph.Models;
using DatabaseRelationGraph.ViewModels;
using DatabaseRelationGraph.Views;
using GraphX.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseRelationGraph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DrawGraph();
        }
        private MDatabaseGraph graph;
        private void Initialize()
        {
            graph = graph ?? MDatabaseGraph.CreateExample();
            Area.LogicCore = GXDatabaseLogicCore.GetLogicCore(graph);
        }

        private void DrawGraph()
        {
            Area.GenerateGraph(true, true);

            /* 
             * After graph generation is finished you can apply some additional settings for newly created visual vertex and edge controls
             * (VertexControl and EdgeControl classes).
             * 
             */

            //This method sets the dash style for edges. It is applied to all edges in Area.EdgesList. You can also set dash property for
            //each edge individually using EdgeControl.DashStyle property.
            //For ex.: Area.EdgesList[0].DashStyle = GraphX.EdgeDashStyle.Dash;
            Area.SetEdgesDashStyle(EdgeDashStyle.Dot);

            //This method sets edges arrows visibility. It is also applied to all edges in Area.EdgesList. You can also set property for
            //each edge individually using property, for ex: Area.EdgesList[0].ShowArrows = true;
            Area.ShowAllEdgesArrows(true);

            //This method sets edges labels visibility. It is also applied to all edges in Area.EdgesList. You can also set property for
            //each edge individually using property, for ex: Area.EdgesList[0].ShowLabel = true;
            Area.ShowAllEdgesLabels(true);

            zoomViewer.ZoomToFill();
        }

        private void VertexLabelControl_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void VertexLabelControl_MouseLeave(object sender, MouseEventArgs e)
        {

        }
        private VRelationPopup relations;
        private void VertexControl_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is VertexControl vertex)
            {
                MTable table = vertex.GetDataVertex<MTable>();
                IEnumerable<MForeignKey> references = graph.Edges.Where(fk => fk.Source == table);
                IEnumerable<MForeignKey> referencedBy = graph.Edges.Where(fk => fk.Target == table);
                VMRelationList vm = new VMRelationList()
                {
                    Source = new VMTable(table),
                    References = new System.Collections.ObjectModel.ObservableCollection<VMForeignKey>(references.Select(m => new VMForeignKey(m))),
                    ReferencedBy = new System.Collections.ObjectModel.ObservableCollection<VMForeignKey>(referencedBy.Select(m => new VMForeignKey(m)))
                };

                relations = new VRelationPopup
                {
                    DataContext = vm
                };
                relations.ShowDialog();
                relations = null;

                vm.ReferencedBy.Clear();
                vm.References.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                List<KeyValuePair<MTable, VertexControl>> pairs = Area.VertexList.Where(kvp => kvp.Key.Text.ToUpperInvariant().Contains(SearchBox.Text.ToUpperInvariant())).ToList();
                List<VertexControl> vertices = pairs.Select(kvp => kvp.Value).ToList();

                if (vertices.Count() == 0)
                    return;

                Rect boundingRect = CalculateRect(vertices[0]);
                for(int i = 1; i < vertices.Count; i++)
                {
                    boundingRect.Union(CalculateRect(vertices[i]));
                }

                VertexControl exactMatch = pairs.FirstOrDefault(kvp => kvp.Key.Text.ToUpperInvariant() == SearchBox.Text.ToUpperInvariant()).Value;
                if (exactMatch != null)
                {
                    exactMatch.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }

                zoomViewer.ZoomToContent(boundingRect);
            }
        }

        private Rect CalculateRect(VertexControl vertex)
        {
            Point center = vertex.GetCenterPosition();
            center.Offset(-vertex.ActualWidth / 2, -vertex.ActualHeight / 2);
            Rect vertexRect = new Rect(center, new Size(vertex.ActualWidth * 1.1, vertex.ActualHeight * 1.1));
            return vertexRect;
        }
    }
}
