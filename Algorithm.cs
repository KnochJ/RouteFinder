using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteFinder
{
    public class Algorithm
    {
        /// <summary>
        /// Performs breadth-first-search on the given graph.
        /// Here we only search until we find the destination
        /// vertex and then we break out and return this vertex.
        /// Uses the Vertex attribute .prev to keep track of the 
        /// previous vertex which tells how we traveled to the
        /// current vertex.
        /// </summary>
        public static Vertex FindBFS(Graph g)
        {
            // implemented BFS using a queue
            Queue<Vertex> vertQueue = new Queue<Vertex>();
            // Queue up the first node (USA), not always?
            vertQueue.Enqueue(g.source);

            // continue to run while we have vertices in the queue
            while (vertQueue != null)
            {
                // This checks for if the end result in the path
                // cannot be found. So we break and return null.
                if (vertQueue.Count == 0)
                {
                    break;
                }
                // Get the vertex in the start of the queue
                // and begin checking if it's the destination
                // otherwise we run through its adjacent vertices
                Vertex u = vertQueue.Dequeue();
                if (u.vName == g.dest.vName)
                {
                    return u; // we found the destination
                }
                foreach (Vertex v in u.adjacencyList)
                {
                    if (v.visited == false)
                    {
                        // set visit as discovered, increment the distance,
                        // set the prev to the vertex we traveled from
                        // add this v to the queue
                        v.distance = u.distance + 1;
                        v.prev = u;
                        v.visited = true;
                        vertQueue.Enqueue(v);
                    }
                }
            }
            // return null only if we don't find the dest!
            return null;
        }
    }
}
