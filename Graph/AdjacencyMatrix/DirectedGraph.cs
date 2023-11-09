using static Graph.AdjacencyMatrix.DirectedGraph.GraphHelper;

namespace Graph.AdjacencyMatrix
{
    /// <summary>
    /// Adjacency Matrix representation of an unweighted directed graph
    /// </summary>
    public class DirectedGraph
    {
        int v; // number of vertices
        int e; // number of edges

        bool[,] adj; // Adjacency Matrix for the graph

        Vertex[] vertexList;

        private static int time;

        public DirectedGraph()
        {
            vertexList = new Vertex[MAX_VERTICES];
            adj = new bool[MAX_VERTICES, MAX_VERTICES];
        }

        /// <summary>
        /// Returns number of vertices
        /// </summary>
        /// <returns></returns>
        public int Vertices()
        {
            return v;
        }

        /// <summary>
        /// returns number of edges
        /// </summary>
        /// <returns></returns>
        public int Edges()
        {
            return e;
        }


        /// <summary>
        /// Display the adjacency matrix
        /// </summary>
        public void Display()
        {
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    if (adj[i, j])
                        Console.Write("1 ");
                    else
                        Console.Write("0 ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Insert a vertex
        /// </summary>
        /// <param name="name"></param>
        public void InsertVertex(string name)
        {
            vertexList[v++] = new Vertex(name);
        }


        private int GetIndex(string vertexName)
        {
            for (int i = 0; i < v; i++)
            {
                if (vertexList[i].name.Equals(vertexName, StringComparison.OrdinalIgnoreCase))
                    return i;
            }

            throw new InvalidDataException("Invalid Vertex");
        }

        /// <summary>
        /// returns true if there an edge between vertex1 and vertex2
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <returns></returns>
        public bool EdgeExits(string vertex1, string vertex2)
        {
            return IsAdjacent(GetIndex(vertex1), GetIndex(vertex2));
        }

        /// <summary>
        /// returns true if v1 and v2 are adjacent vertex
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        private bool IsAdjacent(int v1, int v2)
        {
            return adj[v1, v2];
        }

        /// <summary>
        /// Insert an edge in Directed graph
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void InsertEdge(string vertex1, string vertex2)
        {
            int u = GetIndex(vertex1);
            int v = GetIndex(vertex2);

            // case 1 : when u and v are equal 
            if (u == v)
                throw new InvalidOperationException("Not a valid edge");

            // case 2: when edge already exits 
            if (adj[u, v])
                Console.WriteLine("Edge already exists");
            else
            {
                // case 3: Insert the edge
                adj[u, v] = true;
                e++;
            }
        }

        /// <summary>
        /// Delete an edge in a Directed graph
        /// </summary>
        /// <param name="vertex1"></param>
        /// <param name="vertex2"></param>
        public void DeleteEdge(string vertex1, string vertex2)
        {
            int u = GetIndex(vertex1);
            int v = GetIndex(vertex2);

            // case 1 : when u and v are equal 
            if (u == v)
                throw new InvalidOperationException("Not a valid edge");

            if (!adj[u, v])
            {
                Console.WriteLine("Edge not present in the graph");
            }
            else
            {
                adj[u, v] = false;
                e--;
            }
        }

        /// <summary>
        /// return out degree of a vertex in a directed graph
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public int OutDegree(string vertex)
        {
            int u = GetIndex(vertex);

            int outDegree = 0;

            for (int v = 0; v < u; v++)
            {
                if (adj[u, v])
                    outDegree++;
            }

            return outDegree;
        }


        /// <summary>
        /// return in degree of a vertex in a directed graph
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public int InDegree(string vertex)
        {
            int u = GetIndex(vertex);

            int inDegree = 0;

            for (int v = 0; v < u; v++)
            {
                if (adj[v, u])
                    inDegree++;
            }
            return inDegree;
        }


        public void FindPathMatrix()
        {
            int[,] x = new int[v, v];
            int[,] adjp = new int[v, v];
            int[,] temp = new int[v, v];

            // initialize x and adjp
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    x[i, j] = adjp[i, j] = adj[i, j] ? 1 : 0;
                }
            }

            // X = A + A^2 + A^3 + .... + A^v
            // We will start from 2

            for (int power = 2; power <= v; power++)
            {
                // multiply adjp and adj
                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        temp[i, j] = 0;
                        for (int k = 0; k < v; k++)
                        {
                            temp[i, j] = temp[i, j] + adjp[i, k] * (adj[k, j] ? 1 : 0);
                        }
                    }
                }

                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        adjp[i, j] = temp[i, j];
                    }
                }


                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        x[i, j] = x[i, j] + adjp[i, j];
                    }
                }
            }

            // Display X

            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    Console.Write($"{x[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            bool[,] path = new bool[v, v];
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    path[i, j] = x[i, j] == 0 ? false : true;
                }
            }


            // Display path Matrix
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    if (path[i, j])
                        Console.Write($"{1} ");
                    else
                        Console.Write($"{0} ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // BFS

        /// <summary>
        /// Graph traversal using BSF, This method will only visit those vertex which are reachable from starting vertex
        /// </summary>
        /// <param name="startVertex"></param>
        public void BFS(string startVertex)
        {
            for (int vertexIndex = 0; vertexIndex < v; vertexIndex++)
            {
                vertexList[vertexIndex].state = STATE.INITIAL;
            }

            int indexOfStartVertex = GetIndex(startVertex);
            BFS(indexOfStartVertex);
        }

        /// <summary>
        /// Graph traversal using BSF, This method will  visit those vertex which are not reachable from starting vertex
        /// </summary>
        /// <param name="startVertex"></param>
        public void BFS_ALL(string startVertex)
        {

            for (int vertexIndex = 0; vertexIndex < v; vertexIndex++)
            {
                vertexList[vertexIndex].state = STATE.INITIAL;
            }

            int indexOfStartVertex = GetIndex(startVertex);
            BFS(indexOfStartVertex);

            for (int vertexIndex = 0; vertexIndex < v; vertexIndex++)
            {
                // if a vertex left un-visited
                if (vertexList[vertexIndex].state == STATE.INITIAL)
                {
                    BFS(vertexIndex);
                }
            }
        }

        /// <summary>
        /// Graph traversal BFS 
        /// </summary>
        /// <param name="indexOfStartVertex"></param>
        private void BFS(int indexOfStartVertex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(indexOfStartVertex);
            vertexList[indexOfStartVertex].state = STATE.WAITING;

            while (queue.Count > 0)
            {
                v = queue.Dequeue();
                Console.Write(vertexList[v].name + " ");
                vertexList[v].state = STATE.VISITED;

                for (int i = 0; i < v; i++)
                {
                    if (IsAdjacent(v, i) && vertexList[i].state == STATE.INITIAL)
                    {
                        queue.Enqueue(i);
                        vertexList[i].state = STATE.WAITING;
                    }
                }
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Shortest distance between start vertex to any vertex
        /// </summary>
        /// <param name="vertex"></param>
        public void BFSShortedDistance(string startVertex)
        {
            for (int i = 0; i < v; i++)
            {
                vertexList[i].state = STATE.INITIAL;
                vertexList[i].predecessor = NIL;
                vertexList[i].distance = INFINITY;
            }

            int indexOfStartVertex = GetIndex(startVertex);
            BFS_1(indexOfStartVertex);

            for (int vertex = 0; vertex < v; vertex++)
            {
                if (vertexList[vertex].distance == INFINITY)
                {
                    Console.WriteLine($"No Path from vertex {startVertex} to vertex {vertexList[vertex].name}");
                }
                else
                {

                    int shortestDistance = vertexList[vertex].distance;
                    Console.WriteLine($"Shortest distance from vertex {startVertex} to vertex {vertexList[vertex].name} is : {shortestDistance} ");

                    int[] path = new int[shortestDistance];
                    int currentVertex = vertex;
                    int count = 0;
                    while (currentVertex != NIL)
                    {
                        path[count++] = currentVertex;
                        currentVertex = vertexList[currentVertex].predecessor;
                    }

                    Console.Write("Shortest Path : ");

                    for (int i = count; i >= 0; i--)
                    {
                        Console.Write($"{vertexList[path[i]].name} >> ");
                    }
                    Console.WriteLine();
                }
            }
        }


        public void BFSTreeEdges(string startVertex)
        {
            for (int i = 0; i < v; i++)
            {
                vertexList[i].state = STATE.INITIAL;
            }

            int indexOfStartVertex = GetIndex(startVertex);
            BFSTree(indexOfStartVertex);

            for (int i = 0; i < v; i++)
            {
                if (vertexList[i].state == STATE.INITIAL)
                    BFSTree(i);
            }

        }

        private void BFSTree(int indexOfStartVertex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(indexOfStartVertex);
            vertexList[indexOfStartVertex].state = STATE.WAITING;

            while (queue.Count > 0)
            {
                v = queue.Dequeue();
                vertexList[v].state = STATE.VISITED;

                for (int i = 0; i < v; i++)
                {
                    if (IsAdjacent(v, i) && vertexList[i].state == STATE.INITIAL)
                    {
                        queue.Enqueue(i);
                        vertexList[i].state = STATE.WAITING;
                        Console.WriteLine($"Tree Edge : ( { vertexList[v].name }, { vertexList[i].name } )");
                    }
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Modified DFS with distance and predecessor 
        /// </summary>
        /// <param name="indexOfStartVertex"></param>
        private void BFS_1(int indexOfStartVertex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(indexOfStartVertex);
            vertexList[indexOfStartVertex].state = STATE.WAITING;
            vertexList[indexOfStartVertex].distance = 0;
            vertexList[indexOfStartVertex].predecessor = NIL;

            while (queue.Count > 0)
            {
                v = queue.Dequeue();
                vertexList[v].state = STATE.VISITED;

                for (int i = 0; i < v; i++)
                {
                    if (IsAdjacent(v, i) && vertexList[i].state == STATE.INITIAL)
                    {
                        queue.Enqueue(i);
                        vertexList[i].state = STATE.WAITING;
                        vertexList[i].distance = vertexList[v].distance + 1;
                        vertexList[i].predecessor = v;
                    }
                }
            }
        }

        // DFS

        /// <summary>
        /// Traverse a graph using DFS Traversal methods
        /// </summary>
        /// <param name="startVertex"></param>
        public void DFS(string startVertex)
        {
            for (int vertex = 0; vertex < v; vertex++)
            {
                vertexList[vertex].state = STATE.INITIAL;
            }

            int indexOfStartVertex = GetIndex(startVertex);
            DFS(indexOfStartVertex);
        }


        public void DFS_ALL(string startVertex)
        {

            for (int vertex = 0; vertex < v; vertex++)
            {
                vertexList[vertex].state = STATE.INITIAL;
            }

            int indexOfStartVertex = GetIndex(startVertex);
            DFS(indexOfStartVertex);

            for (int vertex = 0; vertex < v; vertex++)
            {
                if (vertexList[vertex].state == STATE.INITIAL)
                {
                    DFS(vertex);
                }
            }
        }

        /// <summary>
        /// DFS Spanning tree
        /// </summary>
        /// <param name="startVertex"></param>
        public void DFSTreeEdges(string startVertex)
        {
            for (int vertex = 0; vertex < v; vertex++)
            {
                vertexList[vertex].state = STATE.INITIAL;
                vertexList[vertex].predecessor = NIL;
            }

            int indexOfStartVertex = GetIndex(startVertex);
            DFS_1(indexOfStartVertex);

            for (int vertex = 0; vertex < v; vertex++)
            {
                if (vertexList[vertex].state == STATE.INITIAL)
                {
                    DFS_1(vertex);
                }
            }
        }

        private void DFS(int vertex)
        {
           Stack<int> stack = new Stack<int>();
           stack.Push(vertex);

            while(stack.Count > 0)
            {
                vertex = stack.Pop();
                if (vertexList[vertex].state == STATE.INITIAL)
                {
                    Console.Write($"{vertexList[vertex].name} ");
                    vertexList[vertex].state = STATE.VISITED;
                }

                for(int i = v-1; i >= 0; i--)
                {
                    if(IsAdjacent(vertex, i) && vertexList[i].state == STATE.INITIAL)
                    {
                        stack.Push(i);
                    }
                }
            }

            Console.WriteLine();
        }

        private void DFS_1(int vertex)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(vertex);

            while (stack.Count > 0)
            {
                vertex = stack.Pop();
                if (vertexList[vertex].state == STATE.INITIAL)
                {
                    Console.Write($"{vertexList[vertex].name} ");
                    vertexList[vertex].state = STATE.VISITED;
                }

                for (int i = v - 1; i >= 0; i--)
                {
                    if (IsAdjacent(vertex, i) && vertexList[i].state == STATE.INITIAL)
                    {
                        stack.Push(i);
                        vertexList[i].predecessor = vertex;
                    }
                }
            }

            Console.WriteLine();
        }

        private void DFS_Rec(int vertex)
        {
            Console.Write($"{vertex} ");
            for (int i = 0; i < v; i++)
            {
                if(IsAdjacent(vertex, i) && vertexList[i].state == STATE.INITIAL)
                {
                    DFS_Rec(i);
                }
            }
            vertexList[vertex].state = STATE.FINISHED;
        }


        #region
        /// <summary>
        /// Represents vertex of a graph
        /// </summary>
        public class Vertex
        {
            public string name;
            public STATE state;

            public int predecessor;
            public int distance;

            public Vertex(string name)
            {
                this.name = name;
            }

            public override string ToString()
            {
                return name;
            }
        }

        // Helper class for Graph
        public class GraphHelper
        {
            public static readonly int MAX_VERTICES = 30;

            public enum STATE
            {
                INITIAL, WAITING, VISITED, FINISHED
            };

            public static readonly int NIL = -1;
            public static readonly int INFINITY = int.MaxValue;
        }
        #endregion
    }

}
