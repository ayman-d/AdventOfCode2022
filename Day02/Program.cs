namespace Day02
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
        int score = 0;
        var games = input.Split(Environment.NewLine);

        foreach (var game in games)
        {
          int opponentPlay = game.Split(" ")[0] switch
          {
            "A" => 1,
            "B" => 2,
            "C" => 3,
            _ => 0
          };

          int myPlay = game.Split(" ")[1] switch
          {
            "X" => 1,
            "Y" => 2,
            "Z" => 3,
            _ => 0
          };

          score +=
            myPlay == opponentPlay ? myPlay + 3 :
            myPlay - opponentPlay == 1 || (myPlay == 1 && opponentPlay == 3) ? myPlay + 6 :
            myPlay;
        }

        //11841
        Console.WriteLine(score);
      }

      void SolveProblemB()
      {
        int score = 0;
        var games = input.Split(Environment.NewLine);

        foreach (var game in games)
        {
          int opponentPlay = game.Split(" ")[0] switch
          {
            "A" => 1,
            "B" => 2,
            "C" => 3,
            _ => 0
          };

          int myPlay = game.Split(" ")[1] switch
          {
            "X" => opponentPlay == 1 ? 3 : opponentPlay - 1,
            "Y" => opponentPlay,
            "Z" => opponentPlay == 3 ? 1 : opponentPlay + 1,
            _ => 0
          };

          score +=
            myPlay == opponentPlay ? myPlay + 3 :
            myPlay - opponentPlay == 1 || (myPlay == 1 && opponentPlay == 3) ? myPlay + 6 :
            myPlay;
        }

        //13022
        Console.WriteLine(score);
      }
    }
  }
}