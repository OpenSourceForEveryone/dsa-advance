// See https://aka.ms/new-console-template for more information
using Graph.AdjacencyMatrix;
using Graph.AdjacencyList;


//DirectedGraph graph = new DirectedGraph();
//graph.InsertVertex("Zero");
//graph.InsertVertex("One");
//graph.InsertVertex("Two");

//graph.InsertEdge("One", "Two");
//graph.InsertEdge("Two", "Zero");

//graph.Display();

//Console.WriteLine($"Vertices = {graph.Vertices()} || Edges = {graph.Edges()}");



LinkedDigraph digraph = new LinkedDigraph();

digraph.InsertVertex("1");
digraph.InsertVertex("2");
digraph.InsertVertex("3");
digraph.InsertVertex("4");

digraph.InsertEdges("1", "2");
digraph.InsertEdges("1", "3");
digraph.InsertEdges("2", "3");
digraph.InsertEdges("2", "4");

digraph.Display();


