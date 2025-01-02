public class DictionaryAlgorythmForTesting
{
    public string DictionaryAlgorythm(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return "Invalid input";
        }

        var inputDic = new List<Dictionary<int, int>>();
        var entries = input.Split(' ');
        foreach (var entry in entries)
        {
            var parts = entry.Split(',');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int id) || !int.TryParse(parts[1], out int value))
            {
                return "Invalid input. Please enter in format 'id,value id,value...'.";
            }

            inputDic.Add(new Dictionary<int, int> { { id, value } });
        }

        var ids = inputDic.SelectMany(d => d.Keys);
        var values = inputDic.SelectMany(d => d.Values);

        int newId = 1;
        while (ids.Contains(newId))
        {
            newId++;
        }

        var duplicates = values
            .GroupBy(n => n)
            .Where(n => n.Count() >= 2)
            .Select(n => n.Key)
            .ToList();

        if (duplicates.Count > 0)
        {
            int minDuplicate = duplicates.Min();
            int minPositive = minDuplicate;
            while (values.Contains(minPositive))
            {
                minPositive++;
            }

            return $"Result: ID: {newId}, Value: {minPositive}";
        }

        return "No duplicates!";
    }
}
