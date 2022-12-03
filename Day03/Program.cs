namespace Day03
{
  internal class Program
  {
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

        for (int i = 0; i < rucksacks.Length; i++)
        {
          var currentRucksack = rucksacks[i];
          var compartment1 = currentRucksack.Take(currentRucksack.Length / 2);
          var compartment2 = currentRucksack.Skip(currentRucksack.Length / 2);

          char duplicate = compartment1.Where(x => compartment2.Contains(x)).FirstOrDefault();
          int priority = duplicate - (char.IsUpper(duplicate) ? 38 : 96);

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

        for (int i = 0; i < rucksacks.Length; i += 3)
        {
          char duplicate = rucksacks[i]
                            .Where(x => rucksacks[i + 1].Contains(x) && rucksacks[i + 2].Contains(x))
                            .FirstOrDefault();
          int priority = duplicate - (char.IsUpper(duplicate) ? 38 : 96);

          duplicateChars.Add(duplicate);
          duplicatePriorities.Add(priority);
        }

        //2821
        Console.WriteLine(duplicatePriorities.Sum());
      }
    }
  }
}