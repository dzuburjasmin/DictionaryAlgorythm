var input = new List<Dictionary<int, int>>();
Console.WriteLine("Enter dictionaries in format 'id,value id,value...'. Press enter to execute when done:");

string line = Console.ReadLine();
if (string.IsNullOrWhiteSpace(line))
{
    Console.Write("Invalid input");
    return;
}
else
{
    var entries = line.Split(' ');
    foreach (var entry in entries)
    {
        var parts = entry.Split(',');
        if (parts.Length != 2 || !int.TryParse(parts[0], out int id) || !int.TryParse(parts[1], out int value))
        {
            Console.WriteLine("Invalid input. Please enter in format 'id,value id,value...'.");
            return;
        }

        input.Add(new Dictionary<int, int> { { id, value } });
    }
}
//ids and values from dictionaries
var ids = input.SelectMany(d => d.Keys);
var values = input.SelectMany(d => d.Values);

//finding id
int newId = 1;
while (ids.Contains(newId))
{
    newId++;
}

//finding duplicates
var duplicates = values
    .GroupBy(n => n)
    .Where(n => n.Count() >= 2)
    .Select(n => n.Key)
    .ToList();

//if there are duplicates, find an integer larger than the smallest duplicate
if (duplicates.Count > 0)
{
    int minDuplicate = duplicates.Min();
    int minPositive = minDuplicate;
    while (values.Contains(minPositive))
    {
        minPositive++;
    }
    var newDictionary = new Dictionary<int, int>
        {
            { newId, minPositive }
        };

//write result
    Console.WriteLine("Result:");
    foreach (var kvp in newDictionary)
    {
        Console.WriteLine($"ID: {kvp.Key}, Value: {kvp.Value}");
    }
}

//no duplicates - no new dictionary
else
{
    Console.WriteLine("No duplicates !");
}

