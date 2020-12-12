using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouteFinder.Graphs
{
    public static class GraphHelper
    {

        /// <summary>
        /// Method to add a vertex object to the graph objects
        /// list of vertices
        /// </summary>
        public static void AddVertex(Vertex v, Graph g)
        {
            g.GraphVerts.Add(v);
        }


        /// <summary>
        /// Add a unidirectinal edge from a vertex to another vertex.
        /// Essentially this is creating a given vertice's adjacency list.
        /// </summary>
        public static void AddUniEdge(Vertex fromVertex, Vertex toVertex)
        {
            fromVertex.AdjacencyList.Add(toVertex);
        }


        /// <summary>
        /// Add a BIDIRECTIONAL edge between two vertices
        /// Effectively adding each vertex to the others adjacency list.
        /// </summary>
        public static void AddBiDirEdge(Vertex fromVertex, Vertex toVertex)
        {
            fromVertex.AdjacencyList.Add(toVertex);
            toVertex.AdjacencyList.Add(fromVertex);
        }


        /// <summary>
        /// Takes in the Destination node
        /// </summary>
        public static List<string> GetPath(Vertex destVertex)
        {
            List<string> path = new List<string>();
            while (destVertex.Prev != null)
            {
                path.Add(destVertex.VName);
                destVertex = destVertex.Prev;
            }
            path.Add(destVertex.VName);
            path.Reverse();  // reverse to format: USA -> ... ->
            return path;
        }


        /// <summary>
        /// This method Creates specifically North Americas graph
        /// Could end up adding new Graphs like South America
        /// </summary>
        public static bool CreateNAGraph(Graph g, string ident)
        {
            // Create our Vertices to add to the NaGraph
            Vertex usa = new Vertex();
            Vertex canada = new Vertex();
            Vertex mexico = new Vertex();
            Vertex belize = new Vertex();
            Vertex guatemala = new Vertex();
            Vertex honduras = new Vertex();
            Vertex elsalvador = new Vertex();
            Vertex nicuragua = new Vertex();
            Vertex costarica = new Vertex();
            Vertex panama = new Vertex();

            // check if the identifier is empty
            if (ident == "")
            {
                return false;
            }
            string code = ident.ToUpper(); // handle ident: pan vs PAN

            // Creating our vertices and adding their 
            // edges, then adding to the graph.
            usa.VName = "USA";
            canada.VName = "CAN";
            mexico.VName = "MEX";
            belize.VName = "BLZ";
            guatemala.VName = "GTM";
            elsalvador.VName = "SLV";
            honduras.VName = "HND";
            nicuragua.VName = "NIC";
            costarica.VName = "CRI";
            panama.VName = "PAN";

            // Add vertices to the graph
            AddVertex(usa, g);
            AddVertex(canada, g);
            AddVertex(mexico, g);
            AddVertex(belize, g);
            AddVertex(guatemala, g);
            AddVertex(elsalvador, g);
            AddVertex(honduras, g);
            AddVertex(nicuragua, g);
            AddVertex(costarica, g);
            AddVertex(panama, g);

            // Add the edges between vertices
            AddBiDirEdge(usa, canada);
            AddBiDirEdge(usa, mexico);
            AddBiDirEdge(mexico, belize);
            AddBiDirEdge(mexico, guatemala);
            AddBiDirEdge(guatemala, elsalvador);
            AddBiDirEdge(guatemala, honduras);
            AddBiDirEdge(nicuragua, honduras);
            AddBiDirEdge(nicuragua, costarica);
            AddBiDirEdge(panama, costarica);

            g.GraphSize = 10; // graph size not used now
            g.Source = usa;  // USA is always the start
            usa.Visited = true; // mark start as visited
            usa.Distance = 0;

            // Here we want to check if the Vertex even exists
            // in the graph. Could do checks for full names?
            foreach (Vertex v in g.GraphVerts)
            {
                if (v.VName == code)
                {
                    g.Dest = v;
                    return true;
                }
            }
            return false;

        }
    }
}
