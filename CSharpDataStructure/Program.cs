// List of in build data structure

// Stack LIFO
using System.Text;

Stack<int> stack = new Stack<int>();
// push
stack.Push(0);
// pop 
int stackPopValue = stack.Pop();  
// Peek
int stackPeekValue = stack.Peek();
// Stack Length 
int stackLen = stack.Count;
// check if Stack is empty 
bool isEmptyStack = false;
isEmptyStack = stack.Any();
isEmptyStack = stack.Count == 0;

// Queue FIFO 
Queue<int> queue = new Queue<int>();
// Enqueue or Add
queue.Enqueue(0);
// Dequeue or remove 
int queueDequeuValue = queue.Dequeue();
// Peek
int queuePeekValue = queue.Peek();

// Linked list 
LinkedList<int> linkedList = new LinkedList<int>();
// Add First
linkedList.AddFirst(0);
// Add last
linkedList.AddLast(1);

bool isEmptyList = false;
isEmptyList = linkedList.Count == 0;
isEmptyList = linkedList.Any();

// String Builder

StringBuilder sb = new StringBuilder();
Console.WriteLine(sb + "a");
Console.WriteLine(String.IsNullOrWhiteSpace(""));

Dictionary<char, int> map = new Dictionary<char, int>(){
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000},
    };


