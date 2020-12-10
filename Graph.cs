using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteFinder
{
    public class Graph
    {
        // List of Vertices that the graph holds
        public List<Vertex> graphVerts { get; set; } = new List<Vertex>();

        public Graph()
        {

        }
        public Graph(int size, Vertex start, Vertex finish)
        {
            Vertex source = start;
            Vertex dest = finish;
            int graphSize = size;
        }

        /// <summary>
        /// holds the number of vertices in the graph
        /// </summary>
        public int graphSize { get; set; }

        /// <summary>
        /// Vertex object representing the start vertex
        /// </summary>
        public Vertex source { get; set; }

        /// <summary>
        /// Vertex object representing the goal/destination vertex
        /// </summary>
        public Vertex dest { get; set; }

    }
}
