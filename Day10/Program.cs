namespace Day10
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
        var commands = input.Split(Environment.NewLine);

        int xRegister = 1;
        int cycle = 0;

        List<int> cycleBreakpoints = new() { 20, 60, 100, 140, 180, 220 };
        List<int> signalStrengths = new();

        for (int i = 0; i < commands.Length; i++)
        {
          if (commands[i].Split(" ")[0] == "addx")
          {
            for (int j = 1; j < 3; j++)
            {
              cycle++;

              if (cycleBreakpoints.Contains(cycle))
              {
                signalStrengths.Add(xRegister * cycle);
              }
            }
            xRegister += int.Parse(commands[i].Split(" ")[1]);
          } else
          {
            cycle++;

            if (cycleBreakpoints.Contains(cycle))
            {
              signalStrengths.Add(xRegister * cycle);
            }
          }
        }

        //11960
        Console.WriteLine(signalStrengths.Sum());
      }

      void SolveProblemB()
      {
        Console.WriteLine("hi B");
      }
    }
  }
}