namespace Graph.AdjacencyList
{
    /// <summary>
    /// Adjacency List representation of an unweighted directed graph
    /// </summary>
    public class LinkedDigraph
    {
        VertexNode start; // points to first vertex of the Graph
        int v; // number of vertex
        int e; // number of edge

        public LinkedDigraph()
        {
            this.start = null;
        }

        /// <summary>
        /// return number of vertex in the digraph
        /// </summary>
        /// <returns></returns>
        public int Vertices()
        {
            return v;
        }

        /// <summary>
        /// return number of edges in the digraph
        /// </summary>
        /// <returns></returns>
        public int Edges()
        {
            return e;
        }

        /// <summary>
        /// Insert a vertex in Digraph
        /// </summary>
        /// <param name="vertexName"></param>
        public void InsertVertex(string vertexName)
        {
            VertexNode vertex = new VertexNode(vertexName);

            if (start == null)
            {
                start = vertex;
                return;
            }

            VertexNode curr = start;
            while (curr.nextVertex != null)
            {
                if (curr.name.Equals(vertexName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Vertex already present");
                    return;
                }

                curr = curr.nextVertex;
            }

            // we are at last vertex
            // check the vertex name
            if (curr.name.Equals(vertexName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Vertex already present");
                return;
            }

            curr.nextVertex = vertex;

            v++;
        }

        public void DeleteVertex(string vertexName)
        {
            DeleteFromEdgeList(vertexName);
            DeleteFromVertexList(vertexName);
        }

        /// <summary>
        /// Insert an edge between vertex 1 and 2
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        public void InsertEdges(string vertex1, string vertex2)
        {
            if (vertex1 == vertex2)
            {
                Console.WriteLine("Invalid edge : Start and end vertices are same");
                return;
            }

            VertexNode u = FindVertex(vertex1);
            VertexNode v = FindVertex(vertex2);

            if (u == null || v == null)
            {
                Console.WriteLine($"Either {vertex1} or {vertex2} not present in the graph ");
                return;
            }

            EdgeNode temp = new EdgeNode(u);

            if (u.firstEdge == null)
            {
                u.firstEdge = temp;
                e++;
                return;
            }

            EdgeNode edge = u.firstEdge;

            while (edge.nextEdge != null)
            {
                if (edge.endVertex.name.Equals(vertex2, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Edge present");
                    return;
                }

                edge = edge.nextEdge;
            }

            if (edge.endVertex.name.Equals(vertex2, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Edge present");
                return;
            }

            edge.nextEdge = temp;
            e++;
        }


        /// <summary>
        /// Delete the edge from the Graph
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        public void DeleteEdge(string vertex1, string vertex2)
        {

            VertexNode u = FindVertex(vertex2);

            if (u == null)
            {
                Console.WriteLine("Start vertex is not present");
                return;
            }

            if (u.firstEdge == null)
            {
                Console.WriteLine("Edge not present");
            }


            if (u.firstEdge.endVertex.name.Equals(vertex2, StringComparison.OrdinalIgnoreCase))
            {
                u.firstEdge = u.firstEdge.nextEdge;
                e--;
                return;
            }


            EdgeNode edge = u.firstEdge;

            while (edge.nextEdge != null)
            {
                if (edge.nextEdge.endVertex.name.Equals(vertex2, StringComparison.OrdinalIgnoreCase))
                {
                    edge.nextEdge = edge.nextEdge.nextEdge;
                    e--;
                    return;
                }

                edge = edge.nextEdge;
            }
        }


        /// <summary>
        /// Display the Linked Directed Graph
        /// </summary>
        public void Display()
        {
            for (VertexNode vertex = start; vertex != null; vertex = vertex.nextVertex)
            {
                Console.Write($"{vertex.name} ->");

                for (EdgeNode edge = start.firstEdge; edge != null; edge = edge.nextEdge)
                {
                    Console.Write($" {edge.endVertex.name}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// calculate out degree of a vertex in a linked direct graph
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int OutDegree(string vertex)
        {

            VertexNode u = FindVertex(vertex);

            if (u == null)
            {
                throw new InvalidOperationException($"{vertex} doesn't exist in the graph");
            }

            int outDegree = 0;

            EdgeNode edge = u.firstEdge;

            while (edge != null)
            {
                edge = edge.nextEdge;

                outDegree++;
            }
            return outDegree;
        }

        /// <summary>
        /// calculate in degree of a vertex in a linked direct graph
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int InDegree(string vertex)
        {
            VertexNode u = FindVertex(vertex);

            if (u == null)
            {
                throw new InvalidOperationException($"{vertex} doesn't exist in the graph");
            }

            int inDegree = 0;

            for(VertexNode ver = start; ver != null; ver = ver.nextVertex)
            {
                for(EdgeNode edge = ver.firstEdge; edge != null; edge = edge.nextEdge)
                {
                    if(edge.endVertex.name.Equals(vertex))
                        inDegree++;
                }
            }

            return inDegree;
        }


        /// <summary>
        /// Check if an edge exists with vertex1 and vertex2
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns></returns>
        public bool EdgeExits(string vertex1, string vertex2)
        {
            VertexNode u = FindVertex(vertex1);

            if (u == null)
                return false;

            EdgeNode edge = u.firstEdge;

            while (edge != null)
            {
                if (edge.endVertex.name.Equals(vertex2, StringComparison.OrdinalIgnoreCase))
                    return true;

                edge = edge.nextEdge;
            }

            return false;
        }

        /// <summary>
        /// Find the vertex in the graph
        /// </summary>
        /// <param name="vertexName"></param>
        /// <returns></returns>
        private VertexNode FindVertex(string vertexName)
        {
            VertexNode curr = start;

            while (curr != null)
            {
                if (curr.name.Equals(vertexName))
                    return curr;

                curr = curr.nextVertex;
            }

            return null;
        }

        private void DeleteFromEdgeList(string vertexName)
        {
            for (VertexNode curr = start; curr != null; curr = curr.nextVertex)
            {
                if (curr.firstEdge == null) // there is not edge list
                    continue;

                if (curr.firstEdge.endVertex.name.Equals(vertexName, StringComparison.OrdinalIgnoreCase)) // 
                    curr.firstEdge = curr.firstEdge.nextEdge;
                else
                {
                    EdgeNode edge = curr.firstEdge;

                    while (edge.nextEdge != null)
                    {
                        if (edge.nextEdge.endVertex.name.Equals(vertexName, StringComparison.OrdinalIgnoreCase))
                        {
                            edge.nextEdge = edge.nextEdge.nextEdge;
                            e--;
                            break;
                        }

                        edge = edge.nextEdge;
                    }
                }
            }
        }

        private void DeleteFromVertexList(string vertexName)
        {
            if (start == null)
            {
                Console.WriteLine("There is not vertex to be deleted");
                return;
            }

            // vertex to be deleted is the first vertex of list
            if (start.name.Equals(vertexName, StringComparison.OrdinalIgnoreCase))
            {
                for (EdgeNode edge = start.firstEdge; edge != null; edge = edge.nextEdge)
                    e--; // maintain the count of edge

                start = start.nextVertex;
                v--; // reducing the vertex count
            }
            else
            {
                VertexNode curr = start;
                while (curr.nextVertex != null)
                {
                    if (curr.nextVertex.name.Equals(vertexName, StringComparison.OrdinalIgnoreCase))
                        break;

                    curr = curr.nextVertex;
                }


                if (curr.nextVertex == null)
                {
                    Console.WriteLine("Vertex Not found");
                }
                else
                {
                    for (EdgeNode edge = curr.nextVertex.firstEdge; edge != null; edge = edge.nextEdge)
                        e--; // reduce the edge count

                    curr.nextVertex = curr.nextVertex.nextVertex;
                    v--; // reduce the vertex count
                }
            }
        }

        #region
        public class VertexNode
        {
            public string name; // Name of the vertex
            public VertexNode nextVertex; // reference to next Vertex
            public EdgeNode firstEdge;

            public VertexNode(string vertexName)
            {
                this.name = vertexName;
            }

            public override string ToString()
            {
                return name;
            }
        }

        public class EdgeNode
        {
            public VertexNode endVertex; // reference to vertex
            public EdgeNode nextEdge;

            public EdgeNode(VertexNode vertex)
            {
                endVertex = vertex;
            }
        }
        #endregion
    }
}
