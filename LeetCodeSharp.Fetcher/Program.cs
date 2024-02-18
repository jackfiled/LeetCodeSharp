using LeetCodeSharp.Fetcher;

var directories = Directory.EnumerateDirectories(Environment.CurrentDirectory);

if (!directories.Any(d => d.Contains("Problems")))
{
    Console.WriteLine("Please run in correct directory!");
    return;
}

var problemDirectory = Path.Combine(Environment.CurrentDirectory, "Problems");
var fetcher = new Fetcher();

var problem = await fetcher.GetProblem(uint.Parse(args[0]));
var problemFilename = Path.Combine(problemDirectory, problem.GetFilename());

await using var writer = new StreamWriter(problemFilename);
await writer.WriteAsync(problem.GetFileContent());