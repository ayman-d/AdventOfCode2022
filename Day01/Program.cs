namespace Day01
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string input = File.ReadAllText("../../../input.txt");

      SolveProblemA();
      SolveProblemB();

      void SolveProblemA()
      {
        var solution1 = input.Split(Environment.NewLine+Environment.NewLine)
          .Select(group => group.Split(Environment.NewLine).Select(calory => int.Parse(calory)).Sum()).Max();

        //72017
        Console.WriteLine(solution1);
      }

      void SolveProblemB()
      {
        var solution2 = input.Split(Environment.NewLine+Environment.NewLine)
          .Select(group => group.Split(Environment.NewLine).Select(calory => int.Parse(calory)).Sum()).OrderByDescending(calory => calory).Take(3).Sum();

        //212520
        Console.WriteLine(solution2);
      }
    }
  }
}