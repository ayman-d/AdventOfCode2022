namespace Day06
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
        for (int i = 4; i < input.Length; i++)
        {
          string listOfFour = input.Substring(i-3,4);
          var isUnique = listOfFour.ToCharArray().Distinct().Count() == 4;

          if (isUnique)
          {
            //1779
            Console.WriteLine(i+1);
            break;
          }
        }
      }

      void SolveProblemB()
      {
        for (int i = 14; i < input.Length; i++)
        {
          string listOfFour = input.Substring(i - 13, 14);
          var isUnique = listOfFour.ToCharArray().Distinct().Count() == 14;

          if (isUnique)
          {
            //2635
            Console.WriteLine(i + 1);
            break;
          }
        }
      }
    }
  }
}