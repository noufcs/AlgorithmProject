using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dijkstra_AlgorithmProject
{
    public class Vertex
    {
        public IList<Edge> edges;
        internal string Name { get; set; }
        internal double DistanceFromStart { get; set;}
        internal string AdjecentVertex { get; set; }

        public Vertex(string name)

        {
            Name = name;
            edges = new List<Edge>();
        }
        internal IEnumerable <Edge> Edges
        {
            get { return edges; }
        }
        internal void AddEdge(Vertex targetVertex, double distance, bool direction)
        {
            if (targetVertex == null)
                throw new ArgumentNullException("Target Vertext is missing!!");
            if (targetVertex == this)
                throw new ArgumentException("Not allowed to connect the vertex with itself!!");
            if (distance <= 0)
                throw new ArgumentException("Distance should not be less than zero!!");
            edges.Add(new Edge(targetVertex,distance));
            if (direction)
                targetVertex.AddEdge(this, distance, false);
        }

    }
}
