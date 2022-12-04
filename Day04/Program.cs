namespace Day04
{
  internal class Program
  {
    static void Main()
    {
      string input = File.ReadAllText("../../../input.txt");

      SolveProblemA();
      SolveProblemB();
      AltSolveProblemA();
      AltSolveProblemB();

      void SolveProblemA()
      {
        var assignments = input.Split(Environment.NewLine);

        int counter = 0;

        foreach (var assignment in assignments)
        {
          var left = assignment.Split(",")[0].Split("-").Select(x => int.Parse(x)).ToList();
          var right = assignment.Split(",")[1].Split("-").Select(x => int.Parse(x)).ToList();

          if ((left.First() >= right.First() && left.Last() <= right.Last()) || (right.First() >= left.First() && right.Last() <= left.Last()))
          {
            counter++;
          }
        }

        //602
        Console.WriteLine(counter);
      }

      void SolveProblemB()
      {
        var assignments = input.Split(Environment.NewLine);

        int counter = 0;

        foreach (var assignment in assignments)
        {
          var left = assignment.Split(",")[0].Split("-").Select(x => int.Parse(x)).ToList();
          var right = assignment.Split(",")[1].Split("-").Select(x => int.Parse(x)).ToList();

          if (!(left.First() > right.Last() || left.Last() < right.First()))
          {
            counter++;
          }
        }

        //891
        Console.WriteLine(counter);
      }

      // =============================
      // alternatives (With HashSet<>)
      // =============================

      void AltSolveProblemA()
      {
        var assignments = input.Split(Environment.NewLine);

        int counter = 0;

        foreach (var assignment in assignments)
        {
          var leftFirst = int.Parse(assignment.Split(",")[0].Split("-")[0]);
          var leftSecond = int.Parse(assignment.Split(",")[0].Split("-")[1]);
          var rightFirst = int.Parse(assignment.Split(",")[1].Split("-")[0]);
          var rightSecond = int.Parse(assignment.Split(",")[1].Split("-")[1]);
          HashSet<int> left = new HashSet<int>(Enumerable.Range(leftFirst, leftSecond - leftFirst + 1));
          HashSet<int> right = new HashSet<int>(Enumerable.Range(rightFirst, rightSecond - rightFirst + 1));

          if (left.IsSubsetOf(right) || right.IsSubsetOf(left))
          {
            counter++;
          }
        }

        //602
        Console.WriteLine(counter);
      }

      void AltSolveProblemB()
      {
        var assignments = input.Split(Environment.NewLine);

        int counter = 0;

        foreach (var assignment in assignments)
        {
          var leftFirst = int.Parse(assignment.Split(",")[0].Split("-")[0]);
          var leftSecond = int.Parse(assignment.Split(",")[0].Split("-")[1]);
          var rightFirst = int.Parse(assignment.Split(",")[1].Split("-")[0]);
          var rightSecond = int.Parse(assignment.Split(",")[1].Split("-")[1]);
          HashSet<int> left = new HashSet<int>(Enumerable.Range(leftFirst, leftSecond - leftFirst + 1));
          HashSet<int> right = new HashSet<int>(Enumerable.Range(rightFirst, rightSecond - rightFirst + 1));

          if (left.Intersect(right).Any())
          {
            counter++;
          }
        }

        //891
        Console.WriteLine(counter);
      }
    }
  }
}