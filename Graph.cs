using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dijkstra_AlgorithmProject
{
    public class Graph
    {
        internal IDictionary<string, Vertex> Vertices { get; private set;}

        public Graph()
        {
            Vertices = new Dictionary<string,Vertex>();
        }
        public void AddVertex(string VerName)
        {
            var Vertex = new Vertex(VerName);
            Vertices.Add(VerName,Vertex);
        }
        public void AddEdge(string src,string dst,int distance,bool direction)
        {
            Vertices[src].AddEdge(Vertices[dst], distance, direction);

        }
        public Stack<string> FindShortestPath(string start,string end)
        {
            Stack<string> path = new Stack<string>();
            string last = end;
            Vertex lastVertex = Vertices[last];
            path.Push(last);
            while(last != start)
            {
                lastVertex = Vertices[lastVertex.AdjecentVertex];
                last = lastVertex.Name;
            }
            return path;
        }

    }
}
