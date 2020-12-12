using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteFinder.Graphs
{
    public class Graph
    {
        // List of Vertices that the graph holds
        public List<Vertex> GraphVerts { get; set; } = new List<Vertex>();

        public Graph()
        {

        }
        public Graph(int size, Vertex start, Vertex finish)
        {
            Vertex Source = start;
            Vertex Dest = finish;
            int GraphSize = size;
        }

        /// <summary>
        /// holds the number of vertices in the graph
        /// </summary>
        public int GraphSize { get; set; }

        /// <summary>
        /// Vertex object representing the start vertex
        /// </summary>
        public Vertex Source { get; set; }

        /// <summary>
        /// Vertex object representing the goal/destination vertex
        /// </summary>
        public Vertex Dest { get; set; }

    }
}
