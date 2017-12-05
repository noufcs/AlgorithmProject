using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dijkstra_AlgorithmProject
{
    public class Dijkstra
    {
        public IDictionary<string,double> ApplyDijkstra(Graph graph , string startVertex)
        {
            if (!graph.Vertices.Any(k => k.Key == startVertex))
                throw new ArgumentException("The start vertex not found in the graph");
            LoadGraph(graph, startVertex);
            CalculateDijkstra(graph, startVertex);
            return RetrieveDistances(graph);

        }

        private void LoadGraph(Graph graph, string startVertex)
        {
            foreach(Vertex v in graph.Vertices.Values)
            {
                v.DistanceFromStart = double.PositiveInfinity;
            }
            graph.Vertices[startVertex].DistanceFromStart = 0;
        }

        private IDictionary<string,double> RetrieveDistances(Graph graph)
        {
            return graph.Vertices.ToDictionary(k => k.Key, v => v.Value.DistanceFromStart); 
        }
        private void CalculateDijkstra(Graph graph , string startVertex)
        {
            bool status = false;
            var queue = graph.Vertices.Values.ToList();
            while (!status)
            {
                Vertex nextVertex = queue.OrderBy(d => d.DistanceFromStart).FirstOrDefault(i => !double.IsPositiveInfinity(i.DistanceFromStart));
                if(nextVertex ==null)
                {
                    status = true;
                }
                else
                {
                    var edges = nextVertex.Edges.Where((i => queue.Contains(i.Target)));
                    foreach (var e in edges)
                    {
                        double distance = nextVertex.DistanceFromStart + e.Distance;
                        if (distance < e.Target.DistanceFromStart)
                        {
                            e.Target.DistanceFromStart = distance;
                            e.Target.AdjecentVertex = nextVertex.Name;
                        }
                    }
                    queue.Remove(nextVertex);
                }
            }
        }
       
    }
}
