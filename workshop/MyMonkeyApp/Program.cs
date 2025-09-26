
using MyMonkeyApp;
using MyMonkeyApp.Models;

var asciiArts = new List<string>
{
	@"  (o\_/o)",
	@" (='.'=)",
	@" (")_(")", // replaced below with escaped version
	@"  (o.o)",
	@"  ( : )",
	@"  (\__/)",
	@"  (='x'=)",
	"  (\"_)_(\")", // properly escaped for C#
	"  (¬‿¬)"
};

void ShowRandomAsciiArt()
{
	var rand = new Random();
	var art = asciiArts[rand.Next(asciiArts.Count)];
	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine(art);
	Console.ResetColor();
}

void ListAllMonkeys()
{
	var monkeys = MonkeyHelper.GetMonkeys();
	Console.WriteLine("\nAvailable Monkeys:");
	Console.WriteLine($"{ "Name",-22} { "Location",-25} { "Population",-10}");
	Console.WriteLine(new string('-', 60));
	foreach (var m in monkeys)
	{
		Console.WriteLine($"{m.Name,-22} {m.Location,-25} {m.Population,-10}");
	}
	Console.WriteLine();
}

void ShowMonkeyDetails()
{
	Console.Write("Enter monkey name: ");
	var name = Console.ReadLine() ?? string.Empty;
	var monkey = MonkeyHelper.GetMonkeyByName(name);
	if (monkey == null)
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine($"Monkey '{name}' not found.\n");
		Console.ResetColor();
		return;
	}
	Console.ForegroundColor = ConsoleColor.Cyan;
	Console.WriteLine($"\nName: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nLatitude: {monkey.Latitude}\nLongitude: {monkey.Longitude}\nImage: {monkey.Image}\n");
	Console.ResetColor();
}

void ShowRandomMonkey()
{
	var monkey = MonkeyHelper.GetRandomMonkey();
	Console.ForegroundColor = ConsoleColor.Green;
	Console.WriteLine($"\nRandom Monkey: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nLatitude: {monkey.Latitude}\nLongitude: {monkey.Longitude}\nImage: {monkey.Image}\n");
	Console.ResetColor();
	Console.WriteLine($"Random monkey accessed {MonkeyHelper.GetRandomMonkeyAccessCount()} times.\n");
}

void ShowMenu()
{
	Console.WriteLine("Monkey App Menu:");
	Console.WriteLine("1. List all monkeys");
	Console.WriteLine("2. Get details for a specific monkey by name");
	Console.WriteLine("3. Get a random monkey");
	Console.WriteLine("4. Exit app");
	Console.Write("Select an option (1-4): ");
}

while (true)
{
	Console.Clear();
	ShowRandomAsciiArt();
	ShowMenu();
	var input = Console.ReadLine();
	Console.WriteLine();
	switch (input)
	{
		case "1":
			ListAllMonkeys();
			break;
		case "2":
			ShowMonkeyDetails();
			break;
		case "3":
			ShowRandomMonkey();
			break;
		case "4":
			Console.WriteLine("Goodbye!");
			return;
		default:
			Console.WriteLine("Invalid option. Please try again.\n");
			break;
	}
	Console.WriteLine("Press Enter to continue...");
	Console.ReadLine();
}
