List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions


IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
/* PrintEach(stratovolcanoEruptions, "Stratovolcano Eruptions."); */

IEnumerable<Eruption> ChileEruptions = eruptions.Where(c => c.Location == "Chile");
/* PrintEach(ChileEruptions, "Chile Eruptions."); */

Eruption? FirstHawaiianEruption = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is");
/* if (FirstHawaiianEruption is null)
{
    Console.WriteLine("No Hawaiian Is Eruption found");
}
else
{
    Console.WriteLine("First Hawaiian Eruptions.");
    Console.WriteLine(FirstHawaiianEruption.ToString());
} */

Eruption? FirstGreenlandEruption = eruptions.FirstOrDefault(c => c.Location == "Greenland");
/* if (FirstGreenlandEruption is null)
{
    Console.WriteLine("No Greenland Eruption found");
}
else
{
    Console.WriteLine("First Hawaiian Eruptions.");
    Console.WriteLine(FirstGreenlandEruption.ToString());
} */

Eruption? NewZealandEruption = eruptions.Where(c => c.Year > 1900).FirstOrDefault(c => c.Location == "New Zealand");
/* Console.WriteLine(NewZealandEruption.ToString()); */

IEnumerable<Eruption> EruptionOver2000 = eruptions.Where(c => c.ElevationInMeters > 2000);
/* PrintEach(EruptionOver2000, "eruptions where the volcano's elevation is over 2000m"); */

IEnumerable<Eruption> LEruptions = eruptions.Where(c => c.Volcano.StartsWith("L"));
/* PrintEach(LEruptions, "all eruptions where the volcano's name starts with 'L'");
Console.WriteLine($"Number of eruptions found: {LEruptions.Count()}"); */

int MaxElevation = eruptions.Max(c => c.ElevationInMeters);
/* Console.WriteLine(MaxElevation); */

Eruption MaxEruption = eruptions.First(c => c.ElevationInMeters == MaxElevation);
/* Console.WriteLine(MaxEruption.Volcano); */

IEnumerable<Eruption> OrderedEruptions = eruptions.OrderBy(c => c.Volcano);
/* foreach (Eruption x in OrderedEruptions)
{
    Console.WriteLine(x.Volcano);
} */

int EruptionsElevationsSum = eruptions.Sum(c => c.ElevationInMeters);
/* Console.WriteLine(EruptionsElevationsSum); */

bool EruptedIn2000 = eruptions.Any(c => c.Year == 2000);
/* if (EruptedIn2000)
{
    Console.WriteLine("volcanoes erupted in the year 2000");
}
else
{
    Console.WriteLine("No volcanoes have erupted in the year 2000");
} */

IEnumerable<Eruption> First3StratovolcanoEruptions = stratovolcanoEruptions.Take(3);
/* PrintEach(First3StratovolcanoEruptions, "the first three stratovolcanoes"); */

IEnumerable<Eruption> SortedEruptions = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
/* PrintEach(SortedEruptions, "all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name"); */

IEnumerable<string> volcanoNames = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano);
/* foreach (string item in volcanoNames)
{
    Console.WriteLine(item);
} */


// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
