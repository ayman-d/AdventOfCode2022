namespace Day03
{
  internal class Program
  {
    private const int GROUP_SIZE = 3;
    private const int CAPS_SUBTRACTOR = 38;
    private const int NON_CAPS_SUBTRACTOR = 96;

    static void Main()
    {
      string input = File.ReadAllText("../../../input.txt");

      SolveProblemA();
      SolveProblemB();

      void SolveProblemA()
      {
        string[] rucksacks = input.Split(Environment.NewLine);
        List<int> duplicatePriorities = new();
        List<char> duplicateChars = new();

        foreach (var rucksack in rucksacks)
        {
          var compartment1 = rucksack.Take(rucksack.Length / 2);
          var compartment2 = rucksack.Skip(rucksack.Length / 2);

          char duplicate = compartment1.Where(x => compartment2.Contains(x)).FirstOrDefault();
          int priority = duplicate - (char.IsUpper(duplicate) ? CAPS_SUBTRACTOR : NON_CAPS_SUBTRACTOR);

          duplicateChars.Add(duplicate);
          duplicatePriorities.Add(priority);
        }

        //8233
        Console.WriteLine(duplicatePriorities.Sum());
      }

      void SolveProblemB()
      {
        string[] rucksacks = input.Split(Environment.NewLine);
        List<int> duplicatePriorities = new();
        List<char> duplicateChars = new();

        for (int i = 0; i < rucksacks.Length; i += GROUP_SIZE)
        {
          char duplicate = rucksacks[i]
                              .Where(x => rucksacks[i + 1].Contains(x) && rucksacks[i + 2].Contains(x))
                              .FirstOrDefault();
          int priority = duplicate - (char.IsUpper(duplicate) ? CAPS_SUBTRACTOR : NON_CAPS_SUBTRACTOR);

          duplicateChars.Add(duplicate);
          duplicatePriorities.Add(priority);
        }

        //2821
        Console.WriteLine(duplicatePriorities.Sum());
      }
    }
  }
}