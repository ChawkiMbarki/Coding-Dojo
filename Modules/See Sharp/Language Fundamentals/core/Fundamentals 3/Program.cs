Console.WriteLine("\n===========================================================================");
Console.WriteLine("1");
Console.WriteLine("-------------");

static void PrintList(List<string> MyList)
{
  foreach (string item in MyList)
  {
    Console.WriteLine(item);
  }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);

Console.WriteLine("\n===========================================================================");
Console.WriteLine("2");
Console.WriteLine("-------------");

static void SumOfNumbers(List<int> IntList)
{
  int Sum = 0;
  foreach (int Num in IntList)
  {
    Sum += Num;
  }
  Console.WriteLine($"The Sum is: {Sum}");
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
SumOfNumbers(TestIntList);

Console.WriteLine("\n===========================================================================");
Console.WriteLine("3");
Console.WriteLine("-------------");

static int FindMax(List<int> IntList)
{
  int Max = IntList[0];
  for (int i = 1; i < IntList.Count; i++)
  {
    if (IntList[i] > Max)
    {
      Max = IntList[i];
    }
  }
  return Max;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
Console.WriteLine(FindMax(TestIntList2));

Console.WriteLine("\n===========================================================================");
Console.WriteLine("4");
Console.WriteLine("-------------");

static List<int> SquareValues(List<int> IntList)
{
  for( int i = 0; i < IntList.Count; i++ )
  {
    IntList[i] *= IntList[i];
  }
  return IntList;
}

List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
// You should get back [1,4,9,16,25], think about how you will show that this worked
TestIntList3 = SquareValues(TestIntList3);
Console.Write('[');
Console.Write(string.Join(", ", TestIntList3));
Console.Write(']');

Console.WriteLine("\n===========================================================================");
Console.WriteLine("5");
Console.WriteLine("-------------");

static int[] NonNegatives(int[] IntArray)
{
  for (int i = 0; i < IntArray.Length; i++)
  {
    if (IntArray[i] < 0)
    {
      IntArray[i] = 0;
    }
  }
  return IntArray;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
// You should get back [0,2,3,0,5], think about how you will show that this worked
TestIntArray = NonNegatives(TestIntArray);
Console.Write('[');
Console.Write(string.Join(", ", TestIntArray));
Console.Write(']');

Console.WriteLine("\n===========================================================================");
Console.WriteLine("6");
Console.WriteLine("-------------");

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
  foreach (KeyValuePair<string, string> entry in MyDictionary)
  {
    Console.WriteLine($"{entry.Key} :{entry.Value}");
  }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

Console.WriteLine("\n===========================================================================");
Console.WriteLine("7");
Console.WriteLine("-------------");

static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
  return MyDictionary.ContainsKey(SearchTerm);
}

// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));

Console.WriteLine("\n===========================================================================");
Console.WriteLine("8");
Console.WriteLine("-------------");

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
  Dictionary<string, int> NewDict = new Dictionary<string,int>();
  for (int i = 0; i < Names.Count; i++)
  {
    NewDict.Add(Names[i], Numbers[i]);
  }
  return NewDict;
}

List<string> TestList = new List<string>() {"Julie", "Harold", "James", "Monica"};
List<int> TestNums = new List<int>() {6,12,7,10};

Dictionary<string, int> NewDict = GenerateDictionary(TestList, TestNums);

foreach (KeyValuePair<string, int> entry in NewDict)
{
  Console.WriteLine($"{entry.Key} :{entry.Value}");
}
