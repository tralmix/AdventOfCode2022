namespace AdventOfCode2022.Day_07
{
    public class Day07
    {
        private static readonly string FileName = "Inputs/Day07.txt";

        public static async Task Run()
        {
            Console.WriteLine("Day 7");

            var part1Answer = await Part1(FileName);
            Console.WriteLine($"The directories under max size are {part1Answer}.");

            var part2Answer = await Part2(FileName);
            Console.WriteLine($"The top containers are {part2Answer}.");

            Console.WriteLine();
        }
        public static async Task<int> Part1(string fileName)
        {
            const int maxSize = 100000;
            var root = await ParseFile(fileName);

            var dictories = GetDirectoriesUnderMax(maxSize, root);

            return dictories.Sum(d=>d.Size);
        }

        public static async Task<int> Part2(string fileName)
        {
            var file = await ParseFile(fileName);
            return int.MinValue;
        }

        public static async Task<Directory_AoC> ParseFile(string fileName)
        {
            var linesOfInput = await File.ReadAllLinesAsync(fileName);

            var inputs = linesOfInput.Select(ParseLine);

            var root = new Directory_AoC("/");
            var active = root;

            foreach(var input in inputs){
                if(input is Command)
                {
                    var command = (Command)input;
                    if(command.Name.Equals("cd"))
                        if(command.Args?.Equals("..") ?? false)
                            active = active?.Parent;
                        else if(command.Args?.Equals("/") ?? false)
                            active = root;
                        else
                            active = active?.SubDirectories.First(x=>x.Name.Equals(command.Args));
                    continue;
                }

                if(input is Directory_AoC)
                {
                    var sub = (Directory_AoC)input;
                    sub.Parent = active;
                    active?.SubDirectories.Add(sub);
                    continue;
                }

                active?.Files.Add((File_AoC)input);
            }
            
            return root;
        }

        public static Input ParseLine(string line)
        {
            if(line.StartsWith("$"))
                return ParseCommand(line);

            return ParseText(line);
        }

        public static Input ParseCommand(string line)
        {
            var parts = line.Split(' ');

            var command = new Command(parts[1])
            {
                Args = parts.ElementAtOrDefault(2)
            };

            return command;
        }

        public static Input ParseText(string line)
        {
            var parts = line.Split(' ');

            if(parts[0].Equals("dir"))
                return new Directory_AoC(parts[1]);

            return new File_AoC(parts[1])
            {
                Size = int.Parse(parts[0])
            };
        }

        public static IEnumerable<Directory_AoC> GetDirectoriesUnderMax(int max, params Directory_AoC[] toSearch)
        {
            var under = new List<Directory_AoC>();
            foreach(var directory in toSearch)
            {
                if(directory.Size <= max)
                    under.Add(directory);
                under.AddRange(GetDirectoriesUnderMax(max, directory.SubDirectories.ToArray()));
            }
            return under;
        }
    }

    public abstract class Input
    {}

    public class Command:Input
    {
        public Command(string name)
        {
            Name = name;
        }
        public string Name {get;init;}
        public string? Args {get;set;}
    }

    public class Directory_AoC : Input
    {
        public Directory_AoC(string name)
        {
            Name = name;
        }
        public string Name {get;init;}
        public List<Directory_AoC> SubDirectories {get;} = new List<Directory_AoC>();
        public List<File_AoC> Files {get;} = new List<File_AoC>();
        public Directory_AoC? Parent {get;set;}
        public int Size => SubDirectories.Sum(d=>d.Size) + Files.Sum(f=>f.Size);
    }

    public class File_AoC : Input
    {
        public File_AoC(string name)
        {
            Name = name;
        }
        public string Name {get;init;}
        public int Size {get;set;}
    }
}
