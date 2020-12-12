using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteFinder.Graphs
{
    public class Vertex
    {
        // List of adjacent Vertices for a given vertex
        public List<Vertex> AdjacencyList { get; set; } = new List<Vertex>();

        public Vertex()
        {

        }
        public Vertex(string name, int dist, bool visit)
        {
            string VName = name;
            int Distance = dist;
            bool Visited = visit;
        }

        /// <summary>
        /// helps keep track of the previous vertex to travel to this vertex
        /// Once we hit the goal vertex, we can simply run through vertex.prev
        /// until we hit the starting vertex which will have a .prev == null
        /// </summary>
        public Vertex Prev { get; set; }

        /// <summary>
        /// boolean used with BFS to keep track of vertices explored in the graph
        /// </summary>
        public bool Visited { get; set; }

        /// <summary>
        /// string representing the name
        /// </summary>
        public string VName { get; set; }

        /// <summary>
        /// integer representing how far from the starting vertex this vertex is.
        /// Starting is distance == 0, then all adjacent are distance += 1 and so on.
        /// </summary>
        public int Distance { get; set; }

    }
}
