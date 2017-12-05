using System;
namespace Dijkstra_AlgorithmProject
{
    // this class was used to create a structre for edge and used to build the graph
    public class Edge
    {
        public Vertex Target { get; set; }
        public double Distance { get; set; }

        public Edge(Vertex target,double dst)
        {
            Target = target;
            Distance = dst;
        }
    }
}
