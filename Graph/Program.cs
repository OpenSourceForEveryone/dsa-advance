// See https://aka.ms/new-console-template for more information
//using Graph.AdjacencyMatrix;
//using Graph.AdjacencyList;


//DirectedGraph graph = new DirectedGraph();
//graph.InsertVertex("Zero");
//graph.InsertVertex("One");
//graph.InsertVertex("Two");

//graph.InsertEdge("One", "Two");
//graph.InsertEdge("Two", "Zero");

//graph.Display();

//Console.WriteLine($"Vertices = {graph.Vertices()} || Edges = {graph.Edges()}");



//LinkedDigraph digraph = new LinkedDigraph();

//digraph.InsertVertex("1");
//digraph.InsertVertex("2");
//digraph.InsertVertex("3");
//digraph.InsertVertex("4");

//digraph.InsertEdges("1", "2");
//digraph.InsertEdges("1", "3");
//digraph.InsertEdges("2", "3");
//digraph.InsertEdges("2", "4");

//digraph.Display();

// HashSet<(int, int)> values = new HashSet<(int, int)> ();
//values.Add((1,3));
//values.Add((1, 4));
//Console.WriteLine(values.Contains((1,3)));

//List<int> res
//  = new List<int> ();
//res.Add(1);
//res.Add(2);
//res.Add(3);
//Console.WriteLine(res[1]);

using Graph.AnujPlayList;
using Graph.LeetcodePractice;

FindJudge problem = new FindJudge();       

Console.WriteLine(problem.FindJudge1(4, new int[][] {
    new int[] {1,3},
    new int[] {1,4},
    new int[] {2,3},
    new int[] {2,4},
    new int[] {4,3},
}));

int[][] array = new int[2][]
{
    new int[] {5,3},
    new int[] {1,3}
};
