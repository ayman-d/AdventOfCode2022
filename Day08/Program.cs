namespace Day08
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
        int visibleTreesNum = 0;

        var lines = input.Split(Environment.NewLine);

        for (int i = 1; i < lines.Length - 1; i++)
        {
          var trees = lines[i].ToCharArray();
          for (int j = 1; j < trees.Length - 1; j++)
          {
            var currentTree = trees[j];
            var leftTrees = lines[i].Take(j).ToList();
            var rightTrees = lines[i].Skip(j + 1);
            var topTrees = lines.Take(i).Select(l => l[j]).ToList();
            var bottomTrees = lines.Skip(i + 1).Select(l => l[j]).ToList();

            if (
              leftTrees.All(t => int.Parse(t.ToString()) < int.Parse(currentTree.ToString())) ||
              rightTrees.All(t => int.Parse(t.ToString()) < int.Parse(currentTree.ToString())) ||
              topTrees.All(t => int.Parse(t.ToString()) < int.Parse(currentTree.ToString())) ||
              bottomTrees.All(t => int.Parse(t.ToString()) < int.Parse(currentTree.ToString()))
              )
            {
              visibleTreesNum++;
            }
          }
        }

        int outerRimTreesNum = lines[0].Length + lines[lines.Length - 1].Length + (lines.Length * 2 - 4);

        //1854
        Console.WriteLine(visibleTreesNum + outerRimTreesNum);
      }

      void SolveProblemB()
      {
        var lines = input.Split(Environment.NewLine);

        int bestScenicScore = 0;

        for (int i = 1; i < lines.Length - 1; i++)
        {
          var trees = lines[i].ToCharArray();
          for (int j = 1; j < trees.Length - 1; j++)
          {
            var currentTree = trees[j];
            var leftTrees = lines[i].Take(j).ToList();
            var rightTrees = lines[i].Skip(j + 1).ToList();
            var topTrees = lines.Take(i).Select(l => l[j]).ToList();
            var bottomTrees = lines.Skip(i + 1).Select(l => l[j]).ToList();

            int leftScore = 0;
            int rightScore = 0;
            int topScore = 0;
            int bottomScore = 0;

            for (int l = leftTrees.Count - 1; l > -1; l--)
            {
              bool found = false;
              if (int.Parse(leftTrees[l].ToString()) >= int.Parse(currentTree.ToString()))
              {
                leftScore = j - l;
                found = true;
                break;
              }
              if (!found)
              {
                leftScore = leftTrees.Count;
              }
            }

            for (int t = topTrees.Count - 1; t > -1; t--)
            {
              bool found = false;
              if (int.Parse(topTrees[t].ToString()) >= int.Parse(currentTree.ToString()))
              {
                topScore = i - t;
                found = true;
                break;
              } if(!found)
              {
                topScore = topTrees.Count;
              }
            }

            for (int r = 0; r < rightTrees.Count; r++)
            {
              bool found = false;
              if (int.Parse(rightTrees[r].ToString()) >= int.Parse(currentTree.ToString()))
              {
                rightScore = j + r;
                found = true;
                break;
              }
              if (!found)
              {
                rightScore = rightTrees.Count;
              }
            }

            for (int b = 0; b < bottomTrees.Count; b++)
            {
              bool found = false;
              if (int.Parse(bottomTrees[b].ToString()) >= int.Parse(currentTree.ToString()))
              {
                bottomScore = i + b;
                found= true;
                break;
              }
              if (!found)
              {
                bottomScore = bottomTrees.Count;
              }
            }

            int totalTreeScore = topScore * rightScore * bottomScore * leftScore;

            bestScenicScore = (totalTreeScore > bestScenicScore) ? totalTreeScore : bestScenicScore;

            //if (
            //  leftTrees.All(t => int.Parse(t.ToString()) < int.Parse(currentTree.ToString())) ||
            //  rightTrees.All(t => int.Parse(t.ToString()) < int.Parse(currentTree.ToString())) ||
            //  topTrees.All(t => int.Parse(t.ToString()) < int.Parse(currentTree.ToString())) ||
            //  bottomTrees.All(t => int.Parse(t.ToString()) < int.Parse(currentTree.ToString()))
            //  )
            //{
            //  visibleTreesNum++;
            //}
          }
        }

        //1854
        Console.WriteLine(bestScenicScore);
      }
    }
  }
}