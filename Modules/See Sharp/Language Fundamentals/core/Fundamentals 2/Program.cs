/* ======================================== Three Basic Arrays ======================================== */

int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
string[] names = new string[] { "Tim", "Martin", "Nikki", "Sara" };

bool[] arr1 = new bool[10];
for (int i = 0; i < arr1.Length; i++)
{
  arr1[i] = i % 2 == 0;
}

/* ======================================== List of Flavors ======================================== */

List<string> lst = new List<string>();
lst.Add("flavor 1");
lst.Add("flavor 2");
lst.Add("flavor 3");
lst.Add("flavor 4");
lst.Add("flavor 5");
lst.Add("flavor 6");

Console.WriteLine($"The length of the list is {lst.Count}!");

lst.RemoveAt(2);
Console.WriteLine($"Now The length of the list is {lst.Count}!");

/* ======================================== User Dictionary ======================================== */

Random rand = new Random();

Dictionary<string, string> dict = new Dictionary<string, string>();

foreach (string key in names)
{
  dict.Add(key, lst[rand.Next(0, lst.Count)]);
}

foreach(string key in names)
{
  Console.WriteLine($"{key} likes {dict[key]}");
}
