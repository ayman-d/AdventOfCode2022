namespace Day07
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
        int maxLevel = 0;
        int currentLevel = 0;
        List<Folder> folders = new();
        
        var instructions = input.Split(Environment.NewLine);

        for (int i = 0; i < instructions.Length; i++)
        {
          var commandLine = instructions[i].Split(" ");
          if (commandLine[0] == "$" && commandLine[1] == "cd")
          {
            string commandDirection = instructions[i].Split(" ")[2];

            if (commandDirection == "..")
            {
              currentLevel--;
            }
            else
            {
              currentLevel++;

              if (currentLevel > maxLevel)
              {
                maxLevel = currentLevel;
              }

              Folder newFolder = new();
              List<string> strings = new();

              for (int j = i + 2; j < instructions.Length; j++)
              {
                string firstCharInInstruction = instructions[j].Split(" ")[0];
                if (firstCharInInstruction != "$")
                {
                  strings.Add(instructions[j]);
                } else
                {
                  break;
                }
              }

              newFolder.Name = commandDirection;
              newFolder.NestedItems = strings;
              newFolder.level = currentLevel;
              folders.Add(newFolder);
            }
          }
        }

        foreach (var folder in folders)
        {
          long newSize = 0;
          foreach (var nested in folder.NestedItems!)
          {
            if (nested.Split(" ")[0] == "dir")
            {
              folders.Where(x => x.Name == nested.Split(" ")[1]).ToList().ForEach(f => f.Parent = folder.Name);
            } else
            {
              newSize += long.Parse(nested.Split(" ")[0]);
            }
          }
          folder.TotalSize = newSize;
        }

        for (int i = maxLevel; i > 0; i--)
        {
          //folders.Where(f => f.Name == folders[i].Parent).ToList().ForEach(parent => parent.TotalSize += folders[i].TotalSize);
          var parentFolders = folders.Where(pf => pf.level == i).ToList();

          long childFoldersTotalSize = 0;

          foreach (var parentFolder in parentFolders)
          {
            var childFolders = folders.Where(cf => cf.Parent == parentFolder.Name).ToList();
            childFoldersTotalSize = (long)childFolders.Select(cf => cf.TotalSize).Sum()!;
            parentFolder.TotalSize += childFoldersTotalSize;
          }
        }

        long sizeSum = (long)folders.Where(f => f.TotalSize <= 100000).Select(f => f.TotalSize).Sum()!;

        //1094472
        Console.WriteLine(sizeSum);
      }

      void SolveProblemB()
      {

      }
    }
  }
}

internal class Folder
{
  public string? Name { get; set; }
  public string? Parent { get; set; }
  public List<string>? NestedItems { get; set; }
  public long? TotalSize { get; set; }
  public int level { get; set; }
}