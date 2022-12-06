
using System.ComponentModel.DataAnnotations;

namespace Day05
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
        var rows = input.Split(Environment.NewLine);

        var groupedRows = input.Split(Environment.NewLine + Environment.NewLine);
        var crateRows = groupedRows[0].Split(Environment.NewLine).Take(groupedRows[0].Split(Environment.NewLine).Length - 1).ToArray();
        var instructionRows = groupedRows[1].Split(Environment.NewLine);

        Dictionary<int, List<char>> crateDict = new();

        int numberOfCrateLists = int.Parse(input.Split(Environment.NewLine + Environment.NewLine)[0]
                                     .Split(Environment.NewLine).Last()
                                     .Split("   ").Last().Trim());

        for (int i = 1; i <= numberOfCrateLists; i++)
        {
          crateDict[i] = new List<char> { };
        }

        for (int i = 0; i < crateRows.Length; i++)
        {
          for (int j = 1; j <= numberOfCrateLists; j++)
          {
            var dictValue = crateDict[j];
            var crateValue = crateRows[i][j * 4 - 3];
            if (Char.IsLetter(crateValue))
            {
              dictValue.Insert(0, crateRows[i][j * 4 - 3]);
            }
          }
        }

        var sortedDict = crateDict.OrderBy(x => x.Key);

        foreach (var instruction in instructionRows)
        {
          var orders = instruction.Split(" ");
          var crateNum = int.Parse(orders[1]);
          var from = int.Parse(orders[3]);
          var to = int.Parse(orders[5]);

          var oldCrateList = crateDict[from];

          for (int i = 0; i < crateNum; i++)
          {
            var removedItem = oldCrateList[oldCrateList.Count() - 1];
            oldCrateList.RemoveAt(oldCrateList.Count() - 1);

            var newCrateList = crateDict[to];
            newCrateList.Add(removedItem);
          }
        }

        string result = "";

        foreach (var dict in crateDict.OrderBy(x => x.Key))
        {
          result += dict.Value.Last();
        }

        //RNZLFZSJH
        Console.WriteLine(result);
      }

      void SolveProblemB()
      {
        var rows = input.Split(Environment.NewLine);

        var groupedRows = input.Split(Environment.NewLine + Environment.NewLine);
        var crateRows = groupedRows[0].Split(Environment.NewLine).Take(groupedRows[0].Split(Environment.NewLine).Length - 1).ToArray();
        var instructionRows = groupedRows[1].Split(Environment.NewLine);

        Dictionary<int, List<char>> crateDict = new();

        int numberOfCrateLists = int.Parse(input.Split(Environment.NewLine + Environment.NewLine)[0]
                                     .Split(Environment.NewLine).Last()
                                     .Split("   ").Last().Trim());

        for (int i = 1; i <= numberOfCrateLists; i++)
        {
          crateDict[i] = new List<char> { };
        }

        for (int i = 0; i < crateRows.Length; i++)
        {
          for (int j = 1; j <= numberOfCrateLists; j++)
          {
            var dictValue = crateDict[j];
            var crateValue = crateRows[i][j * 4 - 3];
            if (Char.IsLetter(crateValue))
            {
              dictValue.Insert(0, crateRows[i][j * 4 - 3]);
            }
          }
        }

        var sortedDict = crateDict.OrderBy(x => x.Key);

        foreach (var instruction in instructionRows)
        {
          var orders = instruction.Split(" ");
          var crateNum = int.Parse(orders[1]);
          var from = int.Parse(orders[3]);
          var to = int.Parse(orders[5]);

          var oldCrateList = crateDict[from];
          var removedCrates = oldCrateList.Skip(oldCrateList.Count() - crateNum);
          int startIndex = oldCrateList.Count() - crateNum;
          var newCrateList = crateDict[to];
          newCrateList.AddRange(removedCrates);
          oldCrateList.RemoveRange(startIndex, crateNum);          
        }

        string result = "";

        foreach (var dict in crateDict.OrderBy(x => x.Key))
        {
          result += dict.Value.Last();
        }

        //CNSFCGJSM
        Console.WriteLine(result);
      }
    }
  }
}