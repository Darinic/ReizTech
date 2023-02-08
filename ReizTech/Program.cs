using ReizTech.Interfaces;
using ReizTech.Request;
using ReizTech.Services;

namespace ReizTech
{
	class Program
	{
		private static IClockService? _clockService;
		private static readonly Random _random = new Random();
		private static readonly int minDepth = _random.Next(4, 6);
		private const int maxDepth = 6;

		class Branch
		{
			public List<Branch> Branches { get; set; }

			public Branch()
			{
				Branches = new List<Branch>();
			}
		}

		static void Main(string[] args)
		{
			_clockService = new ClockService();
			Console.WriteLine("Angle Calculation between Hours and Minutes Task:");
			var time = _clockService.GetHourAndMinutes();
			double angle = _clockService.CalculateAngleBetweenHourAndMinuteHand(new AngleCalculationRequest(time.Hour, time.Minutes));
			Console.WriteLine("The angle between hour and minute hand is: " + angle + " degrees.");
			Console.ReadKey();

			Console.WriteLine("Branches task:");
			Branch root = new Branch();
			GenerateBranches(root, minDepth, maxDepth);
			Console.WriteLine("Structure depth: " + GetStructureDepth(root, 1));
			Console.ReadKey();

			Console.WriteLine("Displaying Randomly generated tree:");
			DrawTree(root, "", true, 1);
			Console.ReadKey();

		}

		static void GenerateBranches(Branch parent, int minDepth, int maxDepth)
		{
			if (minDepth > 0)
			{
				int branchCount = _random.Next(1, 3);
				for (int i = 0; i < branchCount; i++)
				{
					Branch branch = new Branch();
					parent.Branches.Add(branch);
					GenerateBranches(branch, minDepth - 1, maxDepth - 1);
				}
			}
		}
		static int GetStructureDepth(Branch branch, int depth)
		{
			int maxDepth = depth;
			foreach (Branch child in branch.Branches)
			{
				int childDepth = GetStructureDepth(child, depth + 1);
				if (childDepth > maxDepth)
				{
					maxDepth = childDepth;
				}
			}
			return maxDepth;
		}

		static void DrawTree(Branch branch, string prefix, bool isTail, int depth)
		{
			if (depth > 1)
			{
				Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + "Branch" + depth);
			}
			else
			{
				Console.WriteLine("Branch1");
			}

			for (int i = 0; i < branch.Branches.Count; i++)
			{
				DrawTree(branch.Branches[i], prefix + (isTail ? "    " : "│   "), i == branch.Branches.Count - 1, depth + 1);
			}
		}
	}
}
