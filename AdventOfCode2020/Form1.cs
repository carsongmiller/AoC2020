using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace AdventOfCode2020
{
	public partial class Form1 : Form
	{
		public string inputPath;
		public Form1()
		{
			InitializeComponent();
			inputPath = tbInputPath.Text;
		}

		private void btnApplyFilepath_Click(object sender, EventArgs e)
		{
			inputPath = tbInputPath.Text;
		}

		private string[] getInput(string filename, string[] delimeters = null)
		{
			if (delimeters is null) delimeters = new string[2] { "\n", "\r\n" };

			string input = File.ReadAllText(inputPath + filename);
			return input.Trim().Split(delimeters, StringSplitOptions.None);
		}

		private void btnDay1_Click(object sender, EventArgs e)
		{
			string input = File.ReadAllText(inputPath + "day1.txt");
			string[] inputSplit = input.Split('\n');

			//Part 1
			int i = 0, j = 0;
			int num1 = 0, num2 = 0, sum = 0;
			bool found = false;
			for (i = 0; i < inputSplit.Length; i++)
			{
				for (j = i + 1; j < inputSplit.Length; j++)
				{

					bool num1Success = Int32.TryParse(inputSplit[i], out num1);
					bool num2Success = Int32.TryParse(inputSplit[j], out num2);

					if (num1Success && num2Success)
					{
						sum = num1 + num2;
						if (sum == 2020)
						{
							found = true;
							break;
						}
					}
				}
				if (found) break;
			}

			int prod = num1 * num2;
			Console.WriteLine(prod);


			//Part 2
			found = false;
			int k;
			int num3 = 0;
			for (i = 0; i < inputSplit.Length; i++)
			{
				for (j = i + 1; j < inputSplit.Length; j++)
				{
					for (k = j + 1; k < inputSplit.Length; k++)
					{
						bool num1Success = Int32.TryParse(inputSplit[i], out num1);
						bool num2Success = Int32.TryParse(inputSplit[j], out num2);
						bool num3Success = Int32.TryParse(inputSplit[k], out num3);

						if (num1Success && num2Success && num3Success)
						{
							sum = num1 + num2 + num3;
							if (sum == 2020)
							{
								found = true;
								break;
							}
						}
					}
					if (found) break;
				}
				if (found) break;
			}

			prod = num1 * num2 * num3;
			Console.WriteLine(prod);
		}

		private void btnDay2_Click(object sender, EventArgs e)
		{
			string input = File.ReadAllText(inputPath + "day2.txt");
			string[] inputSplit = input.Split('\n');

			//Part 1

			int validCount = 0;

			foreach (string entry in inputSplit)
			{
				if (entry.Length > 0)
				{
					int findLoc = entry.IndexOf(":");
					string rule = entry.Substring(0, findLoc);
					string password = entry.Substring(findLoc + 2);

					int hyphenLoc = rule.IndexOf("-");
					int spaceLoc = rule.IndexOf(" ");
					int minCount = Int32.Parse(rule.Substring(0, hyphenLoc));
					int maxCount = Int32.Parse(rule.Substring(hyphenLoc + 1, spaceLoc - hyphenLoc - 1));
					char letter = rule.Last();
					int letterCount = 0;
					foreach (char c in password)
					{
						if (c == letter) letterCount += 1;
					}

					if (letterCount >= minCount && letterCount <= maxCount) validCount += 1;
				}
			}

			Console.WriteLine(validCount);


			//Part 2

			validCount = 0;

			foreach (string entry in inputSplit)
			{
				if (entry.Length > 0)
				{
					int findLoc = entry.IndexOf(":");
					string rule = entry.Substring(0, findLoc);
					string password = entry.Substring(findLoc + 2);

					int hyphenLoc = rule.IndexOf("-");
					int spaceLoc = rule.IndexOf(" ");
					int loc1 = Int32.Parse(rule.Substring(0, hyphenLoc)) - 1;
					int loc2 = Int32.Parse(rule.Substring(hyphenLoc + 1, spaceLoc - hyphenLoc - 1)) - 1;
					char letter = rule.Last();

					if (password.ElementAt(loc1) == letter ^ password.ElementAt(loc2) == letter) validCount += 1;
				}
			}

			Console.WriteLine(validCount);
		}

		private void btnDay3_Click(object sender, EventArgs e)
		{
			string input = File.ReadAllText(inputPath + "day3.txt");
			string[] inputSplit = input.Split('\n');

			int lineCount = 0;
			foreach (string line in inputSplit)
			{
				if (line != "") lineCount += 1;
			}

			int width = inputSplit[0].Length;
			int rise = 1;
			int run = 3;

			int x = 0, y = 0;
			int treeCount = 0;
			while (y < lineCount)
			{
				x = x % width;
				char pos = inputSplit[y].ElementAt(x);
				if (pos == '#')
				{
					treeCount += 1;
				}
				x += run;
				y += rise;
			}
			Console.WriteLine(treeCount);


			//Part 2
			long prod = 1;

			rise = 1;
			run = 1;
			x = 0;
			y = 0;
			treeCount = 0;
			while (y < lineCount)
			{
				x = x % width;
				char pos = inputSplit[y].ElementAt(x);
				if (pos == '#')
				{ treeCount += 1; }
				x += run;
				y += rise;
			}
			prod *= treeCount;

			rise = 1;
			run = 3;
			x = 0;
			y = 0;
			treeCount = 0;
			while (y < lineCount)
			{
				x = x % width;
				char pos = inputSplit[y].ElementAt(x);
				if (pos == '#')
				{ treeCount += 1; }
				x += run;
				y += rise;
			}
			prod *= treeCount;

			rise = 1;
			run = 5;
			x = 0;
			y = 0;
			treeCount = 0;
			while (y < lineCount)
			{
				x = x % width;
				char pos = inputSplit[y].ElementAt(x);
				if (pos == '#')
				{ treeCount += 1; }
				x += run;
				y += rise;
			}
			prod *= treeCount;

			rise = 1;
			run = 7;
			x = 0;
			y = 0;
			treeCount = 0;
			while (y < lineCount)
			{
				x = x % width;
				char pos = inputSplit[y].ElementAt(x);
				if (pos == '#')
				{ treeCount += 1; }
				x += run;
				y += rise;
			}
			prod *= treeCount;

			rise = 2;
			run = 1;
			x = 0;
			y = 0;
			treeCount = 0;
			while (y < lineCount)
			{
				x = x % width;
				char pos = inputSplit[y].ElementAt(x);
				if (pos == '#')
				{ treeCount += 1; }
				x += run;
				y += rise;
			}
			prod *= treeCount;

			Console.WriteLine(prod);
		}

		private void btnDay4_Click(object sender, EventArgs e)
		{
			string input = File.ReadAllText(inputPath + "day4.txt");
			string[] inputSplit = Regex.Split(input, "\n\n");


			//Part 1
			int validCount = 0;

			foreach (string str in inputSplit)
			{
				bool hasBYR = false;
				bool hasPID = false;
				bool hasEYR = false;
				bool hasHCL = false;
				bool hasIYR = false;
				bool hasCID = false;
				bool hasHGT = false;
				bool hasECL = false;
				bool valid = false;

				if (str.Contains("byr")) hasBYR = true;
				if (str.Contains("pid")) hasPID = true;
				if (str.Contains("eyr")) hasEYR = true;
				if (str.Contains("hcl")) hasHCL = true;
				if (str.Contains("iyr")) hasIYR = true;
				if (str.Contains("cid")) hasCID = true;
				if (str.Contains("hgt")) hasHGT = true;
				if (str.Contains("ecl")) hasECL = true;

				valid = hasBYR && hasPID && hasEYR && hasHCL && hasIYR && hasHGT && hasECL;
				if (valid) validCount += 1;
			}

			Console.WriteLine("Part 1: " + validCount);

			//Part 2

			validCount = 0;
			foreach (string str in inputSplit)
			{
				Passport pass = new Passport(str);
				if (pass.valid_All) validCount += 1;
			}

			Console.WriteLine("Part 2: " + validCount);
		}

		private void btnDay5_Click(object sender, EventArgs e)
		{
			string input = File.ReadAllText(inputPath + "input5.txt");
			string[] inputSplit = input.Split('\n');

			int ID = -1;
			int maxID = -1;
			bool[] taken = new bool[1024];

			foreach (string str in inputSplit)
			{
				if (str.Length > 0)
				{
					string rowStr = str.Substring(0, 7);
					string colStr = str.Substring(7, 3);
					int rowMin = 0;
					int rowMax = 127;
					int colMin = 0;
					int colMax = 7;

					foreach (char c in rowStr)
					{
						if (c == 'F')
						{
							rowMax = rowMin + (rowMax - rowMin) / 2;
						}
						else
						{
							rowMin = rowMax - (rowMax - rowMin) / 2;
						}
					}

					foreach (char c in colStr)
					{
						if (c == 'L')
						{
							colMax = colMin + (colMax - colMin) / 2;
						}
						else
						{
							colMin = colMax - (colMax - colMin) / 2;
						}
					}

					ID = (rowMin * 8) + colMin;
					maxID = Math.Max(ID, maxID);

					taken[ID] = true;
				}
			}
			Console.WriteLine("Part 1: " + maxID);

			//Part 2
			bool foundFirstTaken = false;
			int mySeat = -1;

			for (int i = 0; i < 1024; i++)
			{
				if (!foundFirstTaken)
				{
					foundFirstTaken = taken[i];
				}
				else if (!taken[i])
				{
					mySeat = i;
					break;
				}
			}
			Console.WriteLine("Part 2: " + mySeat);
		}

		private void btnDay6_Click(object sender, EventArgs e)
		{
			string input = File.ReadAllText(inputPath + "input6.txt");
			string[] inputSplit = input.Trim().Split(new string[] { "\n\n" }, StringSplitOptions.None);
			//Part 1

			int totalCount = 0;

			foreach (string str in inputSplit)
			{
				string[] personSplit = Regex.Split(str, "\n");
				bool[] answers = new bool[26];

				foreach (string person in personSplit)
				{
					foreach (byte b in Encoding.UTF8.GetBytes(person.ToCharArray()))
					{
						answers[b - 97] = true;
					}
				}
				totalCount += answers.Where(c => c).Count();
			}

			Console.WriteLine("Part 1: " + totalCount);


			//Part 2

			totalCount = inputSplit
				.Select(x => x.Split('\n').Aggregate((a, b) => new string(a.Intersect(b).ToArray())))
				.Sum(x => x.Length);

			Console.WriteLine("Part 2: " + totalCount);
		}

		private void btnDay7_Click(object sender, EventArgs e)
		{
			string[] inputSplit = getInput("input7.txt");
			Dictionary<string, List<bagRule>> dict = new Dictionary<string, List<bagRule>>();

			foreach (string line in inputSplit)
			{
				//string newLine = line.Trim('.');
				string[] splitLine = line.Split(new string[] { " bags contain ", " bags, ", " bag, ", "bag.", "bags." }, StringSplitOptions.None);

				List<bagRule> rules = new List<bagRule>();
				if (splitLine[0].Contains("drab tomato"))
				{

				}
				splitLine.ToList().ForEach(x => { if (Regex.Match(x, "\\d").Success) rules.Add(new bagRule(x)); });
				dict.Add(splitLine[0], rules);
				//values with count = 0 are terminal cases
			}


			//Part 1
			int count = 0;
			dict.Keys.ToList().ForEach(x => count += day7CountPart1("shiny gold", x, dict) > 0 ? 1 : 0);

			//sub 1 from count to ignore the key for our gold bag itself
			Console.WriteLine("Part 1: " + (count - 1));

			//Part 2
			count = day7CountPart2("shiny gold", dict);
			Console.WriteLine("Part 2: " + (count - 1));
		}

		#region Day 7 Helpers
		private int day7CountPart1(string target, string current, Dictionary<string, List<bagRule>> dict)
		{
			int localCount = 0;
			if (dict[current].Count == 0) return 0;
			else if (current == target) return 1;
			else
			{
				foreach (bagRule rule in dict[current])
				{
					localCount += day7CountPart1(target, rule.type, dict);
				}
			}
			return localCount;
		}

		/// <summary>
		/// Finds total number of bags contained within (and including) the root bag
		/// </summary>
		/// <param name="root">current root of the tree</param>
		/// <param name="dict">dictionary to traverse</param>
		/// <returns>Bags contained within current bag's subtree, including current bag</returns>
		private int day7CountPart2(string root, Dictionary<string, List<bagRule>> dict)
		{
			int localCount = 0;
			if (dict[root].Count == 0) return 1;
			else
			{
				foreach (bagRule rule in dict[root])
				{
					localCount += rule.quant * day7CountPart2(rule.type, dict);
				}
			}
			return 1 + localCount;
		}

		private struct bagRule
		{
			public string type;
			public int quant;

			public bagRule(string t, int q)
			{
				type = t;
				quant = q;
			}

			public bagRule(string s)
			{
				quant = int.Parse(s.Substring(0, 1));
				type = s.Substring(2).Trim();
			}
		}

		#endregion

		private void btnDay8_Click(object sender, EventArgs e)
		{
			string[] inputSplit = getInput("input8.txt");
			Processor p = new Processor(inputSplit);


			//Part 1
			while (!p.nextStepRepeat)
			{
				p.Step();
			}

			Console.WriteLine("Part 1: " + p.accumulator);

			//Part 2

			int acc = -1;

			for (int i = 0; i < p.instructions.Count; i++)
			{
				p.Reset();
				if (p.instructions[i].type == Processor.Instruction.InstructionType.jmp)
				{
					Processor.Instruction newInst = new Processor.Instruction();
					Processor.Instruction lastInst = p.instructions[i];
					newInst.type = Processor.Instruction.InstructionType.nop;
					newInst.value = p.instructions[i].value;
					p.instructions[i] = newInst;

					acc = p.Run();
					if (acc >= 0)
					{
						break;
					}
					else p.instructions[i] = lastInst; //return the instruction to prev value
				}
				else if (p.instructions[i].type == Processor.Instruction.InstructionType.nop)
				{
					Processor.Instruction newInst = new Processor.Instruction();
					Processor.Instruction lastInst = p.instructions[i];
					newInst.type = Processor.Instruction.InstructionType.jmp;
					newInst.value = p.instructions[i].value;
					p.instructions[i] = newInst;

					acc = p.Run();
					if (acc >= 0)
					{
						break;
					}
					else p.instructions[i] = lastInst;
				}
			}
			Console.WriteLine("Part 2: " + acc);
		}

		private void btnDay9_Click(object sender, EventArgs e)
		{
			string[] inputSplit = getInput("input9.txt");

			//Part 1
			int bad = -1;
			for (int i = 25; i < inputSplit.Length; i++)
			{
				int current = int.Parse(inputSplit[i]);
				var combinations = from item1 in inputSplit.Skip(i - 25).Take(25)
								   from item2 in inputSplit.Skip(i - 25).Take(25)
								   where
								   (int.Parse(item1) + int.Parse(item2) == current) &&
								   (int.Parse(item1) != int.Parse(item2))
								   select Tuple.Create(int.Parse(item1), int.Parse(item2));

				if (combinations.Count() == 0)
				{
					bad = current;
					Console.WriteLine("Part 1: " + current);
					break;
				}
			}

			//Part 2
			long[] list = Array.ConvertAll(inputSplit, s => long.Parse(s));

			bool found = false;
			for (int i = 0; i < list.Length; i++)
			{
				for (int j = 2; j < list.Length - i; j++)
				{
					long[] sublist = list.Skip(i).Take(j).ToArray();
					long sum = sublist.Sum();
					if (sum == bad)
					{
						Console.WriteLine("Part 2: " + (sublist.Max() + sublist.Min()));
						found = true;
						break;
					}
					else if (sum > bad) break;
				}
				if (found) break;
			}
		}

		private void btnDay10_Click(object sender, EventArgs e)
		{
			int[] input = Array.ConvertAll(getInput("input10.txt"), s => int.Parse(s));


			//Part 1
			input = input.Concat(new int[] { 0, input.Max() + 3 }).ToArray();
			Array.Sort(input);
			int oneCount = 0;
			int twoCount = 0;
			int threeCount = 0;
			for (int i = 1; i < input.Length; i++)
			{
				if (input[i] - input[i - 1] == 1) oneCount++;
				else if (input[i] - input[i - 1] == 2) twoCount++;
				else if (input[i] - input[i - 1] == 3) threeCount++;
			}
			Console.WriteLine("Part 1: " + (oneCount * threeCount));


			//Part 2
			List<List<int>> chunks = new List<List<int>>();
			int lastBreak = -1;
			for (int i = 0; i < input.Length - 1; i++)
			{
				if (input[i + 1] - input[i] == 3)
				{
					chunks.Add(input.Skip(lastBreak + 1).Take(i - lastBreak).ToList());
					lastBreak = i;
				}
			}
			chunks.Add(input.Skip(lastBreak + 1).Take(input.Length - 1 - lastBreak).ToList());

			long combos = 1;
			foreach (List<int> chunk in chunks)
			{
				switch (chunk.Count())
				{
					case 5:
						combos *= 7;
						break;
					case 4:
						combos *= 4;
						break;
					case 3:
						combos *= 2;
						break;
					case 2:
					case 1:
					default:
						break;
				}
			}
			Console.WriteLine("Part 2: " + combos);
		}

		private void btnDay11_Click(object sender, EventArgs e)
		{
			int[][] seats = Array.ConvertAll(getInput("input11.txt"), s => { return Array.ConvertAll(s.Replace('.', '0').Replace('L', '1').Replace('#', '2').ToCharArray(), str => { return int.Parse(str.ToString()); }); });
			int[][] lastSeats = new int[seats.GetUpperBound(0)][];

			bool same = false;
			while (!same)
			{
				lastSeats = seats.Clone() as int[][];
				seats = SeatStep(seats);

				same = true;
				for (int i = 0; i < seats.Length; i++)
				{
					for (int j = 0; j < seats[0].Length; j++)
					{
						same = seats[i][j] == lastSeats[i][j];
						if (!same) break;
					}
					if (!same) break;
				}
			}

			Console.WriteLine("Part 1: " + seats.Select(x => x.Prepend(0).Aggregate((sum, current) => sum += current == 2 ? 1 : 0)).Sum());

			//Part 2
			same = false;

			seats = Array.ConvertAll(getInput("input11.txt"), s => { return Array.ConvertAll(s.Replace('.', '0').Replace('L', '1').Replace('#', '2').ToCharArray(), str => { return int.Parse(str.ToString()); }); });

			while (!same)
			{

				//foreach (int[] row in seats)
				//{
				//	foreach (int cell in row)
				//	{
				//		switch (cell)
				//		{
				//			case 0:
				//				Console.Write(".");
				//				break;
				//			case 1:
				//				Console.Write("L");
				//				break;
				//			case 2:
				//				Console.Write("#");
				//				break;
				//		}
				//	}
				//	Console.WriteLine();
				//}
				//Console.WriteLine();


				lastSeats = seats.Clone() as int[][];
				seats = SeatStep_Part2(seats);

				same = true;
				for (int i = 0; i < seats.Length; i++)
				{
					for (int j = 0; j < seats[0].Length; j++)
					{
						same = seats[i][j] == lastSeats[i][j];
						if (!same) break;
					}
					if (!same) break;
				}
			}

			Console.WriteLine("Part 2: " + seats.Select(x => x.Prepend(0).Aggregate((sum, current) => sum += current == 2 ? 1 : 0)).Sum());

		}

		#region Day 11 Helpers
		static T[,] To2D<T>(T[][] source)
		{
			try
			{
				int FirstDim = source.Length;
				int SecondDim = source.GroupBy(row => row.Length).Single().Key; // throws InvalidOperationException if source is not rectangular

				var result = new T[FirstDim, SecondDim];
				for (int i = 0; i < FirstDim; ++i)
					for (int j = 0; j < SecondDim; ++j)
						result[i, j] = source[i][j];

				return result;
			}
			catch (InvalidOperationException)
			{
				throw new InvalidOperationException("The given jagged array is not rectangular.");
			}
		}

		private int[][] SeatStep(in int[][] arr)
		{
			//int[,] newArr = new int[arr.GetUpperBound(0)+1, arr.GetUpperBound(1)+1];

			int[][] newArr = new int[arr.GetUpperBound(0) + 1][];
			for (int i = 0; i < newArr.GetUpperBound(0) + 1; i++)
			{
				newArr[i] = new int[arr[i].GetUpperBound(0) + 1];
			}

			for (int i = 0; i <= arr.GetUpperBound(0); i++)
			{
				for (int j = 0; j <= arr[0].GetUpperBound(0); j++)
				{
					if (arr[i][j] == 0) newArr[i][j] = 0;
					else if (arr[i][j] == 1)
					{
						if (NeighborCount(arr, i, j) == 0) newArr[i][j] = 2;
						else newArr[i][j] = 1;
					}
					else if (arr[i][j] == 2) 
					{ 
						if (NeighborCount(arr, i, j) >= 4) newArr[i][j] = 1;
						else newArr[i][j] = 2; 
					} 
				}
			}

			return newArr;
		}

		private int NeighborCount(in int[][] arr, int i, int j)
		{
			int count = 0;
			count += (i - 1 >= 0) && (j - 1 >= 0) && arr[i - 1][j - 1] == 2 ? 1 : 0;
			count += (i - 1 >= 0) && arr[i - 1][j] == 2 ? 1 : 0;
			count += (i - 1 >= 0) && (j + 1 <= arr[0].GetUpperBound(0)) && arr[i - 1][j + 1] == 2 ? 1 : 0;

			count += (j - 1 >= 0) && arr[i][j - 1] == 2 ? 1 : 0;
			count += (j + 1 <= arr[0].GetUpperBound(0)) && arr[i][j + 1] == 2 ? 1 : 0;

			count += (i + 1 <= arr.GetUpperBound(0)) && (j - 1 >= 0) && arr[i + 1][j - 1] == 2 ? 1 : 0;
			count += (i + 1 <= arr.GetUpperBound(0)) && arr[i + 1][j] == 2 ? 1 : 0;
			count += (i + 1 <= arr.GetUpperBound(0)) && (j + 1 <= arr[0].GetUpperBound(0)) && arr[i + 1][j + 1] == 2 ? 1 : 0;

			return count;
		}

		private int[][] SeatStep_Part2(in int[][] arr)
		{
			//int[,] newArr = new int[arr.GetUpperBound(0)+1, arr.GetUpperBound(1)+1];

			int[][] newArr = new int[arr.GetUpperBound(0) + 1][];
			for (int i = 0; i < newArr.GetUpperBound(0) + 1; i++)
			{
				newArr[i] = new int[arr[i].GetUpperBound(0) + 1];
			}

			for (int i = 0; i <= arr.GetUpperBound(0); i++)
			{
				for (int j = 0; j <= arr[0].GetUpperBound(0); j++)
				{
					if (arr[i][j] == 0) newArr[i][j] = 0;
					else if (arr[i][j] == 1)
					{
						if (NeighborCount_Part2(arr, i, j) == 0) newArr[i][j] = 2;
						else newArr[i][j] = 1;
					}
					else if (arr[i][j] == 2)
					{
						if (NeighborCount_Part2(arr, i, j) >= 5) newArr[i][j] = 1;
						else newArr[i][j] = 2;
					}
				}
			}

			return newArr;
		}

		private int NeighborCount_Part2(in int[][] arr, int i, int j)
		{
			int count = 0;

			for (int r = i - 1; r >= 0; r--) //Top
			{
				if (arr[r][j] == 2)
				{
					count += 1;
					break;
				}
				else if (arr[r][j] == 1) break;
			}

			for (int r = i+1; r <= arr.GetUpperBound(0); r++) //Bottom
			{
				if (arr[r][j] == 2)
				{
					count += 1;
					break;
				}
				else if (arr[r][j] == 1) break;
			}

			for (int c = j - 1; c >= 0; c--) //Left
			{
				if (arr[i][c] == 2)
				{
					count += 1;
					break;
				}
				else if (arr[i][c] == 1) break;
			}

			for (int c = j+1; c <= arr[0].GetUpperBound(0); c++) //Right
			{
				if (arr[i][c] == 2)
				{
					count += 1;
					break;
				}
				else if (arr[i][c] == 1) break;
			}

			for (int x = 1; i - x >= 0 && j - x >= 0; x++) //upper left
			{
				if (arr[i - x][j - x] == 2)
				{
					count += 1;
					break;
				}
				else if (arr[i-x][j-x] == 1) break;
			}

			for (int x = 1; i - x >= 0 && j + x <= arr[0].GetUpperBound(0); x++) //upper right
			{
				if (arr[i - x][j + x] == 2)
				{
					count += 1;
					break;
				}
				else if (arr[i - x][j + x] == 1) break;
			}

			for (int x = 1; i + x <= arr.GetUpperBound(0) && j - x >= 0; x++) //bottom left
			{
				if (arr[i + x][j - x] == 2)
				{
					count += 1;
					break;
				}
				else if (arr[i + x][j - x] == 1) break;
			}

			for (int x = 1; i + x <= arr.GetUpperBound(0) && j + x <= arr[0].GetUpperBound(0); x++) //bottom right
			{
				if (arr[i + x][j + x] == 2)
				{
					count += 1;
					break;
				}
				else if (arr[i + x][j + x] == 1) break;
			}

			return count;
		}

		#endregion

		private void btnDay12_Click(object sender, EventArgs e)
		{
			string[] steps = getInput("input12.txt");
			//string[] steps = new string[5]
			//{
			//	"F10",
			//	"N3",
			//	"F7",
			//	"R90",
			//	"F11"
			//};
			Vector2 pos = new Vector2(0);
			int dir = 1;

			//Part 1:
			foreach (string step in steps)
			{
				char command = step[0];
				int value = int.Parse(step.Substring(1));
				switch (command)
				{
					case 'N':
						pos.Y += value;
						break;
					case 'S':
						pos.Y -= value;
						break;
					case 'E':
						pos.X += value;
						break;
					case 'W':
						pos.X -= value;
						break;
					case 'L':
						dir = (dir + 4 - (value / 90)) % 4;
						break;
					case 'R':
						dir = (dir + (value / 90)) % 4;
						break;
					case 'F':
						switch (dir)
						{
							case 0:
								pos.Y += value;
								break;
							case 1:
								pos.X += value;
								break;
							case 2:
								pos.Y -= value;
								break;
							case 3:
								pos.X -= value;
								break;
							default:
								break;
						}
						break;
					default:
						break;
				}
			}
			Console.WriteLine("Part 1: " + (Math.Abs(pos.X) + Math.Abs(pos.Y)));


			//Part 2
			//steps = new string[5]
			//{
			//	"F10",
			//	"N3",
			//	"F7",
			//	"R90",
			//	"F11"
			//};
			Vector2 waypoint = new Vector2(10, 1);
			pos = Vector2.Zero;
			foreach (string step in steps)
			{
				char command = step[0];
				int value = int.Parse(step.Substring(1));
				switch (command)
				{
					case 'N':
						waypoint.Y += value;
						break;
					case 'S':
						waypoint.Y -= value;
						break;
					case 'E':
						waypoint.X += value;
						break;
					case 'W':
						waypoint.X -= value;
						break;
					case 'L':
						waypoint = Rotate(waypoint, value * Math.PI / 180);
						break;
					case 'R':
						waypoint = Rotate(waypoint, -value * Math.PI / 180);
						break;
					case 'F':
						pos += waypoint * value;
						break;
					default:
						break;
				}
			}
			Console.WriteLine("Part 2: " + (Math.Abs(pos.X) + Math.Abs(pos.Y)));
		}

		#region Day 12 Helpers
		public Vector2 Rotate(Vector2 v, double deg)
		{
			return new Vector2(
				v.X * Convert.ToSingle(Math.Cos(deg)) - v.Y * Convert.ToSingle(Math.Sin(deg)),
				v.X * Convert.ToSingle(Math.Sin(deg)) + v.Y * Convert.ToSingle(Math.Cos(deg))
				);
		}
		#endregion

		private void btnDay13_Click(object sender, EventArgs e)
		{
			//Part 1 single line:
			//Console.WriteLine("Part 1: " + (File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[1].Split(',').Select(s => int.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList().Aggregate((best, next) => best = ((next - (int.Parse(File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[0]) % next)) % next) < ((best - (int.Parse(File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[0]) % best)) % best) ? next : best) * ((File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[1].Split(',').Select(s => int.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList().Aggregate((best, next) => best = ((next - (int.Parse(File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[0]) % next)) % next) < ((best - (int.Parse(File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[0]) % best)) % best) ? next : best) - (int.Parse(File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[0]) % File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[1].Split(',').Select(s => int.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList().Aggregate((best, next) => best = ((next - (int.Parse(File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[0]) % next)) % next) < ((best - (int.Parse(File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[0]) % best)) % best) ? next : best))) % File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[1].Split(',').Select(s => int.TryParse(s, out int n) ? n : (int?)null).Where(n => n.HasValue).Select(n => n.Value).ToList().Aggregate((best, next) => best = ((next - (int.Parse(File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[0]) % next)) % next) < ((best - (int.Parse(File.ReadAllText(inputPath + "input13.txt").Trim().Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.None)[0]) % best)) % best) ? next : best))));

			//Part 1 normal:
			string[] input = getInput("input13.txt");

			int earliest = int.Parse(input[0]);
			List<int> busses = input[1].Split(',')
				.Select(s => int.TryParse(s, out int n) ? n : (int?)null)
				.Where(n => n.HasValue)
				.Select(n => n.Value)
				.ToList();

			int choice = busses.Aggregate((best, next) => best = ((next - (earliest % next)) % next) < ((best - (earliest % best)) % best) ? next : best);
			Console.WriteLine("Part 1: " + (choice * ((choice - (earliest % choice)) % choice)));

			//Part 2:
			List<string> all = input[1].Split(',').ToList();
			int lcm = 0;
			Dictionary<ulong, ulong> constraints = new Dictionary<ulong, ulong>();
			foreach (var bus in all.Select((value, i) => new { i, value }))
			{
				ulong busInterval = 0;
				if (ulong.TryParse(bus.value, out busInterval)) constraints.Add(busInterval, Convert.ToUInt64(bus.i));
			}
			ulong stepSize = constraints.ElementAt(0).Key;
			ulong testTime = stepSize;

			for (int i = 1; i < constraints.Count; i++)
			{
				bool found = false;
				//var currentConstraints = constraints.Take(i + 1).ToArray();
				var nextConstraint = constraints.ElementAt(i);
				
				while (!found)
				{
					testTime += stepSize;
					found = (testTime + nextConstraint.Value) % nextConstraint.Key == 0; //we only need to check last. All others are definitely valid
				}

				stepSize *= nextConstraint.Key;
			}

			Console.WriteLine("Part 2: " + testTime);
		}

		private void btnDay14_Click(object sender, EventArgs e)
		{
			string[] input = getInput("input14.txt");
			ulong mask_and = Convert.ToUInt64(Math.Pow(2, 36) - 1);
			ulong mask_or = 0;
			Dictionary<ulong, ulong> memory = new Dictionary<ulong, ulong>();

			//Part 1:
			foreach (var line in input)
			{
				if (line[1] == 'e') //mem
				{
					ulong loc = ulong.Parse(line.Substring(line.IndexOf('[') + 1, line.IndexOf(']') - line.IndexOf('[') - 1));
					ulong value = ulong.Parse(line.Substring(line.IndexOf('=') + 2));
					if (memory.ContainsKey(loc)) memory[loc] = (value | mask_or) & mask_and;
					else
					{
						memory.Add(loc, (value | mask_or) & mask_and);
					}
				}
				else //mask
				{
					string mask_str = line.Substring(7);
					mask_and = Convert.ToUInt64(Math.Pow(2, 36) - 1);
					mask_or = 0;
					for (int i = 0; i < mask_str.Length; i++) //create and and or masks
					{
						int value;
						if (int.TryParse(mask_str[i].ToString(), out value))
						{
							if (value == 0) //need to modify AND mask
							{
								mask_and = mask_and ^ (Convert.ToUInt64(1) << (35-i));
							}
							else //need to modify OR mask
							{
								mask_or = mask_or | (Convert.ToUInt64(1) << (35-i));
							}
						}
					}
				}
			}
			Console.WriteLine("Part 1: " + memory.Values.Aggregate((sum, next) => sum += next));


			//Part 2: 
			//0 = unchanged
			//1 = change to 1
			//X = change to both 0 and 1 and overwrite both

			List<ulong> floatingMasks = new List<ulong>();
			memory = new Dictionary<ulong, ulong>();

			List<ulong> masks_or = new List<ulong>();
			List<ulong> masks_and = new List<ulong>();

			foreach (var line in input)
			{
				if (line[1] == 'e') //mem
				{
					ulong loc = ulong.Parse(line.Substring(line.IndexOf('[') + 1, line.IndexOf(']') - line.IndexOf('[') - 1));
					ulong value = ulong.Parse(line.Substring(line.IndexOf('=') + 2));

					for (int i = 0; i < masks_or.Count; i++)
					{
						ulong newLoc = loc;
						newLoc |= masks_or[i];
						newLoc &= masks_and[i];

						if (memory.ContainsKey(newLoc)) memory[newLoc] = value;
						else memory.Add(newLoc, value);
					}


				}
				else //mask
				{
					var mask = line.Substring(7);

					//crate mask_or which will always be applied
					mask_or = 0;
					masks_or.Clear();
					masks_and.Clear();

					List<int> xLoc = new List<int>();

					for (int i = 0; i < mask.Length; i++)
					{
						if (mask[i] == '1') mask_or = mask_or | (Convert.ToUInt64(1) << (35 - i));
						if (mask[i] == 'X') xLoc.Add(35 - i);
					}

					//create lists of masks_or and masks_and which will be used as pairs


					//generate all variation masks
					for (int i = 0; i < Math.Pow(2, xLoc.Count); i++) 
					{
						ulong new_mask_or = 0;
						ulong new_mask_and = Convert.ToUInt64(Math.Pow(2, 36)) - 1;

						for (int j = 0; j < xLoc.Count; j++)
						{
							//Take i
							//Shift it over to get a single bit
							//AND it with 1 to remove all other bits
							//Shift it back over to teh position in the mask we want to put it in
							//Insert it into both the OR mask and AND mask
							//OR mask is all 0's with 1's in the places we want to change
							//AND mask is all 1's with 0's in teh places we want to change
							new_mask_or = new_mask_or | (Convert.ToUInt64((i >> (xLoc.Count - j - 1)) & 1) << xLoc[j]);
							new_mask_and = new_mask_and ^ (Convert.ToUInt64(((i >> (xLoc.Count - j - 1)) & 1) ^ 1) << xLoc[j]);
						}
						masks_or.Add(new_mask_or | mask_or);
						masks_and.Add(new_mask_and);
					}
				}
			}
			Console.WriteLine("Part 2: " + memory.Values.Aggregate((sum, next) => sum += next));
		}

		private void btnDay15_Click(object sender, EventArgs e)
		{
			List<int> input = Array.ConvertAll(getInput("input15.txt")[0].Split(','), s => int.Parse(s)).ToList();

			//Part 1:
			while(input.Count < 2020)
			{
				int lastSpoken = input.Last();
				int prevOccurence = -1;
				for(int i = input.Count - 2; i >= 0; i--)
				{
					if (input[i] == lastSpoken)
					{
						prevOccurence = i;
						break;
					}
				}

				if (prevOccurence == -1) input.Add(0);
				else input.Add(input.Count - 1 - prevOccurence);
			}
			Console.WriteLine("Part 1: " + input[2019]);




			//Part 2:
			//keep a dictinary of keys = numbers and values = the index at which they were last spoken

			input = Array.ConvertAll(getInput("input15.txt")[0].Split(','), s => int.Parse(s)).ToList();

			//input = new List<int>{ 0, 3, 6};
			Dictionary<int, int> history = new Dictionary<int, int>();
			int count = 0;
			

			for (int i = 0; i < input.Count() - 1; i++)
			{
				if (!history.ContainsKey(input[i])) history.Add(input[i], i);
				else history[input[i]] = i;
				count++;
			}

			int lastNum = input.Last();

			while (count < 30000000 - 1)
			{
				if (!history.ContainsKey(lastNum))
				{
					int toAdd = lastNum;
					lastNum = 0;
					history.Add(toAdd, count);
				}
				else
				{
					int toAdd = lastNum;
					lastNum = count - history[lastNum];
					history[toAdd] = count;
				}

				
				count++;
			}
			Console.WriteLine("Part 2: " + lastNum);
		}

		private void btnDay16_Click(object sender, EventArgs e)
		{
			var input = getInput("input16.txt", new string[] { "\n\nyour ticket:\n", "\n\nnearby tickets:\n" });

			var myTicket = Array.ConvertAll(input[1].Split(','), s => int.Parse(s));
			//Build dictionary of rules
			var rulesList = input[0].Split('\n');
			Dictionary<string, List<System.Drawing.Point>> rules = new Dictionary<string, List<System.Drawing.Point>>();

			foreach (string rule in rulesList)
			{
				var splitRule = rule.Split(new string[] { ": " }, StringSplitOptions.None);
				string ruleName = splitRule[0];
				var ranges_str = splitRule[1].Split(new string[] { " or " }, StringSplitOptions.None);

				var ranges_int = new List<System.Drawing.Point>();

				foreach(string range in ranges_str)
				{
					var splitRange = range.Split('-');
					int bottom = int.Parse(splitRange[0]);
					int top = int.Parse(splitRange[1]);
					ranges_int.Add(new System.Drawing.Point(bottom, top));
				}

				rules.Add(ruleName, ranges_int);
			}

			var tickets = input[2].Split('\n');
			var validTickets = new List<List<int>>();

			int errorRate = 0;

			foreach (var ticket in tickets)
			{
				var allValid = true;
				var values = Array.ConvertAll(ticket.Split(','), s => int.Parse(s));
				foreach (var value in values)
				{
					bool valid = false;
					foreach (var dictItem in rules)
					{
						foreach (var range in dictItem.Value)
						{
							valid = value >= range.X && value <= range.Y;
							if (valid) break;
						}
						if (valid) break;
					}
					if (!valid)
					{
						errorRate += value;
						allValid = false;
					}
				}
				if (allValid) validTickets.Add(values.ToList());
			}

			Console.WriteLine("Part 1: " + errorRate);


			//Part 2:
			var ruleOrder = new List<List<string>>();

			for (int i = 0; i < validTickets[0].Count(); i++) //the index of the value on the ticket we're looking at
			{
				ruleOrder.Add(new List<string>());
				foreach (var rule in rules) //check if all values in that index for all tickets satisfy each rule
				{
					bool allValid = true; //this index for all tickets works with the current rule
					
					foreach (var ticket in validTickets) //check that index for each ticket
					{
						
						allValid = (ticket[i] >= rule.Value[0].X && ticket[i] <= rule.Value[0].Y) || (ticket[i] >= rule.Value[1].X && ticket[i] <= rule.Value[1].Y);
						if (!allValid) break;
					}
					if (allValid) //this rule works for the current index
					{
						ruleOrder[i].Add(rule.Key);
					}
				}
			}

			//Now we've got a list of lists which say which rules could potentially work for each index
			//Process of elimination to figure out exactly which rule goes to which index

			bool allSingle = false;

			while (!allSingle)
			{
				for (int i = 0; i < ruleOrder.Count(); i++)
				{
					if (ruleOrder[i].Count() == 1)
					{
						var thisName = ruleOrder[i][0];
						for (int j = 0; j < ruleOrder.Count(); j++)
						{
							if (j != i && ruleOrder[j].Contains(thisName))
							{
								ruleOrder[j].Remove(thisName);
							}
						}
					}
				}

				allSingle = true;
				foreach (var index in ruleOrder)
				{
					if (index.Count() > 1)
					{
						allSingle = false;
						break;
					}
				}
			}

			//we've now got a list of exactly what order the rules go in
			ulong product = 1;

			for (int i = 0; i < ruleOrder.Count(); i++)
			{
				if (ruleOrder[i][0].IndexOf("departure") == 0) product *= Convert.ToUInt64(myTicket[i]);
			}

			Console.WriteLine("Part 2: " + product);

		}

		private void btnDay17_Click(object sender, EventArgs e)
		{
			var input = getInput("input17.txt");


			//Part 1:

			//space is just a list of points.  If a point is in the list, it's active.  If not, it's not
			var space3D = new List<(int, int, int)>();
			
			//populate initial space
			for (int x = 0; x < input.Length; x++)
			{
				for (int y = 0; y < input[0].Length; y++)
				{
					if (input[x][y] == '#') space3D.Add((x, y, 0));
				}
			}
			
			//simulate
			for (int step = 1; step <= 6; step++) Step(ref space3D);
			Console.WriteLine("Part 1: " + space3D.Count());



			//Part 2:
			//reinitialize space
			var space4D = new List<(int, int, int, int)>();

			//populate initial space
			for (int x = 0; x < input.Length; x++)
			{
				for (int y = 0; y < input[0].Length; y++)
				{
					if (input[x][y] == '#') space4D.Add((x, y, 0, 0));
				}
			}

			//simulate
			for (int step = 1; step <= 6; step++) Step(ref space4D);
			Console.WriteLine("Part 2: " + space4D.Count());
		}

		#region Day 17 Helpers - 3D
		private int GetActiveNeighbors(List<(int, int, int)> space, (int, int, int) center)
		{
			int count = 0;
			foreach (var point in space) count += (AreNeighbors(center, point) && !(point == center)) ? 1 : 0;
			return count;
		}

		private bool AreNeighbors((int, int, int) a, (int, int, int) b)
		{
			return (Math.Abs(a.Item1 - b.Item1) <= 1) && (Math.Abs(a.Item2 - b.Item2) <= 1) && (Math.Abs(a.Item3 - b.Item3) <= 1);
		}

		private (int, int) GetLimits_X(List<(int, int, int)> space)
		{
			(int, int) limits = (int.MaxValue, int.MinValue);
			foreach (var point in space)
			{
				limits.Item1 = point.Item1 < limits.Item1 ? point.Item1 : limits.Item1;
				limits.Item2 = point.Item1 > limits.Item2 ? point.Item1 : limits.Item2;
			}

			return limits;
		}

		private (int, int) GetLimits_Y(List<(int, int, int)> space)
		{
			(int, int) limits = (int.MaxValue, int.MinValue);
			foreach (var point in space)
			{
				limits.Item1 = point.Item2 < limits.Item1 ? point.Item2 : limits.Item1;
				limits.Item2 = point.Item2 > limits.Item2 ? point.Item2 : limits.Item2;
			}

			return limits;
		}

		private (int, int) GetLimits_Z(List<(int, int, int)> space)
		{
			(int, int) limits = (int.MaxValue, int.MinValue);
			foreach (var point in space)
			{
				limits.Item1 = point.Item3 < limits.Item1 ? point.Item3 : limits.Item1;
				limits.Item2 = point.Item3 > limits.Item2 ? point.Item3 : limits.Item2;
			}

			return limits;
		}

		private void Step(ref List<(int, int, int)> space)
		{
			var lim_x = GetLimits_X(space);
			var lim_y = GetLimits_Y(space);
			var lim_z = GetLimits_Z(space);

			var newSpace = new List<(int, int, int)>();

			for (int z = lim_z.Item1 - 1; z <= lim_z.Item2 + 1; z++)
			{
				for (int x = lim_x.Item1 - 1; x <= lim_x.Item2 + 1; x++)
				{
					for (int y = lim_y.Item1 - 1; y <= lim_y.Item2 + 1; y++)
					{
					
						int activeN = GetActiveNeighbors(space, (x, y, z));

						if (space.Contains((x, y, z))) 
						{
							if (activeN == 2 || activeN == 3) newSpace.Add((x, y, z));
						}
						else
						{
							if (activeN == 3) newSpace.Add((x, y, z));
						}
					}
				}
			}

			space = newSpace;
		}

		private void printSpace(List<(int, int, int)> space)
		{
			var lim_x = GetLimits_X(space);
			var lim_y = GetLimits_Y(space);
			var lim_z = GetLimits_Z(space);

			for (int z = lim_z.Item1; z <= lim_z.Item2; z++)
			{
				Console.WriteLine("\nz=" + z);
				for (int x = lim_x.Item1; x <= lim_x.Item2; x++)
				{
					for (int y = lim_y.Item1; y <= lim_y.Item2; y++)
					{
						if (space.Contains((x, y, z))) Console.Write("#");
						else Console.Write(".");
					}
					Console.WriteLine();
				}
			}
			Console.WriteLine();
		}

		#endregion

		#region Day 17 Helpers - 4D
		private int GetActiveNeighbors(List<(int, int, int, int)> space, (int, int, int, int) center)
		{
			int count = 0;
			foreach (var point in space) count += (AreNeighbors(center, point) && !(point == center)) ? 1 : 0;
			return count;
		}

		private bool AreNeighbors((int, int, int, int) a, (int, int, int, int) b)
		{
			return (Math.Abs(a.Item1 - b.Item1) <= 1) && (Math.Abs(a.Item2 - b.Item2) <= 1) && (Math.Abs(a.Item3 - b.Item3) <= 1) && (Math.Abs(a.Item4 - b.Item4) <= 1);
		}

		private (int, int) GetLimits_X(List<(int, int, int, int)> space)
		{
			(int, int) limits = (int.MaxValue, int.MinValue);
			foreach (var point in space)
			{
				limits.Item1 = point.Item1 < limits.Item1 ? point.Item1 : limits.Item1;
				limits.Item2 = point.Item1 > limits.Item2 ? point.Item1 : limits.Item2;
			}

			return limits;
		}

		private (int, int) GetLimits_Y(List<(int, int, int, int)> space)
		{
			(int, int) limits = (int.MaxValue, int.MinValue);
			foreach (var point in space)
			{
				limits.Item1 = point.Item2 < limits.Item1 ? point.Item2 : limits.Item1;
				limits.Item2 = point.Item2 > limits.Item2 ? point.Item2 : limits.Item2;
			}

			return limits;
		}

		private (int, int) GetLimits_Z(List<(int, int, int, int)> space)
		{
			(int, int) limits = (int.MaxValue, int.MinValue);
			foreach (var point in space)
			{
				limits.Item1 = point.Item3 < limits.Item1 ? point.Item3 : limits.Item1;
				limits.Item2 = point.Item3 > limits.Item2 ? point.Item3 : limits.Item2;
			}

			return limits;
		}

		private (int, int) GetLimits_W(List<(int, int, int, int)> space)
		{
			(int, int) limits = (int.MaxValue, int.MinValue);
			foreach (var point in space)
			{
				limits.Item1 = point.Item4 < limits.Item1 ? point.Item4 : limits.Item1;
				limits.Item2 = point.Item4 > limits.Item2 ? point.Item4 : limits.Item2;
			}

			return limits;
		}

		private void Step(ref List<(int, int, int, int)> space)
		{
			var lim_x = GetLimits_X(space);
			var lim_y = GetLimits_Y(space);
			var lim_z = GetLimits_Z(space);
			var lim_w = GetLimits_W(space);

			var newSpace = new List<(int, int, int, int)>();

			for (int w = lim_w.Item1 - 1; w <= lim_w.Item2 + 1; w++)
			{
				for (int z = lim_z.Item1 - 1; z <= lim_z.Item2 + 1; z++)
				{
					for (int x = lim_x.Item1 - 1; x <= lim_x.Item2 + 1; x++)
					{
						for (int y = lim_y.Item1 - 1; y <= lim_y.Item2 + 1; y++)
						{

							int activeN = GetActiveNeighbors(space, (x, y, z, w));

							if (space.Contains((x, y, z, w)))
							{
								if (activeN == 2 || activeN == 3) newSpace.Add((x, y, z, w));
							}
							else
							{
								if (activeN == 3) newSpace.Add((x, y, z, w));
							}
						}
					}
				}
			}
			

			space = newSpace;
		}

		private void printSpace(List<(int, int, int, int)> space)
		{
			var lim_x = GetLimits_X(space);
			var lim_y = GetLimits_Y(space);
			var lim_z = GetLimits_Z(space);
			var lim_w = GetLimits_W(space);

			for (int w = lim_w.Item1; w <= lim_w.Item2; w++)
			{
				for (int z = lim_z.Item1; z <= lim_z.Item2; z++)
				{
					Console.WriteLine("\nz=" + z);
					for (int x = lim_x.Item1; x <= lim_x.Item2; x++)
					{
						for (int y = lim_y.Item1; y <= lim_y.Item2; y++)
						{
							if (space.Contains((x, y, z, w))) Console.Write("#");
							else Console.Write(".");
						}
						Console.WriteLine();
					}
				}
			}
			Console.WriteLine();

		}

		#endregion

		private void btnDay18_Click(object sender, EventArgs e)
		{
			var input = getInput("input18.txt");

			//Part 1
			ulong sum = 0;
			foreach (var line in input) sum += NewMath_Part1(line);
			Console.WriteLine("Part 1: " + sum);


			//Part 2:
			sum = 0;
			foreach (var line in input) sum += NewMath_Part2(line);
			Console.WriteLine("Part 2: " + sum);
		}

		#region Day 18 Helpers
		private ulong NewMath_Part1(string s)
		{
			s = Regex.Replace(s, "\\s+", ""); //remove all whitespace
			if (s.First() == '(' && s.Last() == ')') //remove outer parentheses if they are a pair
			{
				int parenCount = 1;
				for (int j = 1; j < s.Length; j++)
				{
					if (s[j] == '(') parenCount++;
					else if (s[j] == ')') parenCount--;
					if (parenCount == 0) //we found the end of the opening paren
					{
						if (j == s.Length - 1) s = s.Substring(1, s.Length - 2); //if the paren's enclose the whole statement, trim them off
						break;
					}
				}
			}


			//Terminal case.  input string is just a number
			ulong answer = 0;
			bool isNumeric = ulong.TryParse(s, out answer);
			if (isNumeric) return answer;

			//if contains parentheses, solve those first

			

			//find what the next operation needs to be
			string operand1 = "";
			string operand2 = "";
			string oper = "";

			//find the first operand
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '(') //found a left parentheses.  Now find the closing one
				{
					int parenCount = 1;
					int closeParenLoc = -1;
					for (closeParenLoc = i + 1; closeParenLoc < s.Length; closeParenLoc++)
					{
						if (s[closeParenLoc] == '(') parenCount++;
						else if (s[closeParenLoc] == ')') parenCount--;
						if (parenCount == 0) break;
					}
					operand1 = s.Substring(0, closeParenLoc + 1);
					s = s.Substring(closeParenLoc + 1);
					oper = s.First().ToString();
					s = s.Substring(1);
					break;
				}
				else if (s[i] == '+' || s[i] == '*') //we found an operator
				{
					operand1 = s.Substring(0, i);
					s = s.Substring(i);
					oper = s.First().ToString();
					s = s.Substring(1);
					break;
				}
			}

			//find the second operand
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '(') //found a left parentheses.  Now find the closing one
				{
					int parenCount = 1;
					int closeParenLoc = -1;
					for (closeParenLoc = i + 1; closeParenLoc < s.Length; closeParenLoc++)
					{
						if (s[closeParenLoc] == '(') parenCount++;
						else if (s[closeParenLoc] == ')') parenCount--;
						if (parenCount == 0) break;
					}
					operand2 = s.Substring(0, closeParenLoc + 1);
					s = s.Substring(closeParenLoc + 1);
					break;
				}
				else if (s[i] == '+' || s[i] == '*') //we found an operator.  We want to take everything to the left of it.
				{
					operand2 = s.Substring(0, i);
					s = s.Substring(i);
					break;
				}
				else if (i == s.Length - 1) //we're at the end
				{
					operand2 = s;
					s = "";
					break;
				}
			}

			//we now have 4 strings: operand 1, oper(ator), operand 2, and s (everything left over to the right)

			if (oper == "+") return NewMath_Part1((NewMath_Part1(operand1) + NewMath_Part1(operand2)).ToString() + s);
			else if (oper == "*") return NewMath_Part1((NewMath_Part1(operand1) * NewMath_Part1(operand2)).ToString() + s);

			//we only get here if the string isn't a plan number, doesn't contain (, ), +, or *
			//AKA somehting's malformed or something
			return ulong.MinValue;
		}

		private ulong NewMath_Part2(string s)
		{
			s = Regex.Replace(s, "\\s+", ""); //remove all whitespace
			if (s.First() == '(' && s.Last() == ')') //remove outer parentheses if they are a pair
			{
				int parenCount = 1;
				for (int j = 1; j < s.Length; j++)
				{
					if (s[j] == '(') parenCount++;
					else if (s[j] == ')') parenCount--;
					if (parenCount == 0) //we found the end of the opening paren
					{
						if (j == s.Length - 1) s = s.Substring(1, s.Length - 2); //if the paren's enclose the whole statement, trim them off
						break;
					}
				}
			}

			//Terminal case.  input string is just a number
			ulong answer = 0;
			bool isNumeric = ulong.TryParse(s, out answer);
			if (isNumeric) return answer;


			//find what the next operation needs to be
			string operand1 = "";
			string operand2 = "";
			string oper = "";
			string s_firstHalf = "";
			string s_secondHalf = "";


			//do one pass through the string looking for any parentheses that should be solved first
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '(')
				{
					int parenCount = 1;
					int closeParenLoc;
					for (closeParenLoc = i + 1; closeParenLoc < s.Length; closeParenLoc++)
					{
						if (s[closeParenLoc] == '(') parenCount++;
						else if (s[closeParenLoc] == ')') parenCount--;
						if (parenCount == 0)
						{
							s = s.Substring(0, i) + NewMath_Part2(s.Substring(i, closeParenLoc - i + 1)).ToString() + s.Substring(closeParenLoc + 1).ToString();
							i = 0; //repeat search until no more parens
							break;
						}
					}
				}
			}

			//now we have only + and * operators, no parens

			//do a loop and look for + operators
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '+')
				{
					//once we found a +, look to the left until we either hit the beginning of the string or a * operator
					int operand1Start;
					for (operand1Start = i - 1; operand1Start >= 0; operand1Start--)
					{
						if (s[operand1Start] == '*') break;
					}
					operand1 = s.Substring(operand1Start + 1, i - operand1Start - 1);
					s_firstHalf = s.Substring(0, operand1Start + 1);
					s = s.Substring(i);
					oper = s.First().ToString();
					s = s.Substring(1);
					break;
				}
			}

			//now check for * if we didn't find a +
			if (operand1 == "")
			{
				for (int i = 0; i < s.Length; i++)
				{
					if (s[i] == '*')
					{
						//once we found a *, we know that everything to the left is the first operand
						operand1 = s.Substring(0, i);
						s = s.Substring(i);
						oper = s.First().ToString();
						s = s.Substring(1);
						break;
					}
				}
			}

			//now find operand 2:
			//look for any operator in s.  Everything to the left of it is operand2
			int operand2End;
			for (operand2End = 0; operand2End < s.Length; operand2End++)
			{
				if (s[operand2End] == '*' || s[operand2End] == '+') break;
			}

			//once we found an operator (or hit end of string), we know that everything to the left is the first operand
			operand2 = s.Substring(0, operand2End);
			s_secondHalf = s.Substring(operand2End);
			s = ""; //clear out s, just for cleanliness


			//we now have 4 strings: operand 1, oper(ator), operand 2, and s (everything left over to the right)

			if (oper == "+") return NewMath_Part2(s_firstHalf + (NewMath_Part2(operand1) + NewMath_Part2(operand2)).ToString() + s_secondHalf);
			else if (oper == "*") return NewMath_Part2(s_firstHalf + (NewMath_Part2(operand1) * NewMath_Part2(operand2)).ToString() + s_secondHalf);

			//we only get here if the string isn't a plan number, doesn't contain (, ), +, or *
			//AKA somehting's malformed or something
			return ulong.MinValue;
		}
		#endregion
		private void btnDay19_Click(object sender, EventArgs e)
		{
			//Part 1:
			var input = getInput("input19.txt", new string[] { "\n\n", "\r\n\r\n" });

			var rules_raw = input[0].Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
			var rules = new Dictionary<int, string>();
			var messages = input[1].Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
			foreach (var rawRule in rules_raw) //build rules dictionary
			{
				var split = rawRule.Split(new string[] { ": " }, StringSplitOptions.None);
				int ruleNum = int.Parse(split[0]);
				string conditions = split[1];
				rules.Add(ruleNum, conditions.Trim());
			}

			

			var expanded_Part1_0 = expandRule(ref rules, 0);

			int successCount_Part1 = 0;
			var unmatched = new List<string>();
			foreach (var s in messages)
			{
				//if a message doesn't match the unmodified rules, we'll add it to a list.  These are the only ones we'll care about for part 2
				if (expanded_Part1_0.Contains(s)) successCount_Part1++;
				else unmatched.Add(s);
			}

			Console.WriteLine("Part 1: " + successCount_Part1);


			//Part 2:

			//For part 2, any messages that already matched will still match

			//new 8:
			//8: 42 | 42 8

			//new 11:
			//11: 42 31 | 41 11 31

			

			//expand out rules 42 and 31 so we can check which previously unmatched messages contain repetitions of the new rules 8 or 11
			var expanded_42 = expandRule(ref rules, 42);
			var expanded_31 = expandRule(ref rules, 31);

			var regex_42 = "(";
			foreach (var rule in expanded_42)
			{
				regex_42 += "(";
				foreach (char c in rule) regex_42 += "[" + c + "]";
				regex_42 += ")|";
			}
			regex_42 = regex_42.Trim('|');
			regex_42 += ")";

			var regex_31 = "(";
			foreach (var rule in expanded_31)
			{
				regex_31 += "(";
				foreach (char c in rule) regex_31 += "[" + c + "]";
				regex_31 += ")|";
			}
			regex_31 = regex_31.Trim('|');
			regex_31 += ")";

			var regex_full = "^" + regex_42 + "{2,}" + regex_31 + "+$";

			//rules[8] = "42 | 42 8"; //8 = 42 repeated ANY number of times (e.g. "a | aa | aaa | ... | aaaaaaaaaaaa...")
			//rules[11] = "42 31 | 41 11 31"; //11 = 42 and 32 repeated any EQUAL number of times (e.g. "ab | aabb | aaabbb | ... | ...aaaaaaaaaabbbbbbbbbb...")

			int matchCount = 0;

			foreach (var message in unmatched)
			{
				var matches = Regex.Matches(message, regex_full);
				if (matches.Count > 0)
				{
					var groups = matches[0].Groups;

					//for (int i = 0; i < groups.Count; i++) if (groups[i].Value != "") Console.WriteLine(i + ": " + groups[i].Value);

					int count_42 = 0;
					for (int i = 2; i < expanded_42.Count() + 2; i++)
					{
						count_42 += groups[i].Value != "" ? 1 : 0;
					}

					int count_31 = 0;
					for (int i = expanded_42.Count() + 3; i < groups.Count; i++)
					{
						count_31 += groups[i].Value != "" ? 1 : 0;
					}

					matchCount += count_42 > count_31 ? 1 : 0;
				}
			}

			matchCount++; // nothing to see here ...

			Console.WriteLine("Part 2: " + (successCount_Part1 + matchCount).ToString());
		}

		#region Day 19 Helpers
		/// <summary>
		/// This returns a list of strings which are all "OR" options for the rule that was given to it
		/// </summary>
		/// <param name="ruleDict"></param>
		/// <param name="baseRule"></param>
		/// <returns></returns>
		private List<string> expandRule(ref Dictionary<int, string> ruleDict, int ruleNum)
		{
			var newList = new List<string>();
			string rule = ruleDict[ruleNum];
			rule = rule.Replace("\"", "");

			//terminal case: if a rule has no numbers in it, just return it.
			if (Regex.Match(rule, "^[a-zA-Z]$").Success)
			{
				newList.Add(rule);
				return newList;
			}

			var splitRules = rule.Split('|'); //split the rule at the |'s.  We will then return a list with each of these fully expanded


			//go through each item in our current list of rules, and for each one, expand it and add the expansion to newList
			foreach (var splitRule in splitRules)
			{
				var trimmed = splitRule.Trim();
				var returnedLists = new List<List<string>>(); //a list of the lists returned by each character in this part of the original rule
				var indexList = new List<int>();

				var individualRules = trimmed.Split(' ');

				foreach (var r in individualRules)
				{
					//for each part of this rule, it will return a list of OR's which could each work for it
					//We will then find all combinations of these rules, and create a new list from them.  This is what we'll return
					int parsed;
					bool success = int.TryParse(r, out parsed);
					if (success) returnedLists.Add(expandRule(ref ruleDict, parsed));
					else returnedLists.Add(new List<string>{r});
					indexList.Add(0);
				}

				//now we've got a list of all the "OR" lists for this part of the original rule
				//generate all valid combinations of these now, and add to a master list
				//we will generate these combinations for each of the set of lists returned for each part of the rule, and add them all to the same master list
				bool allGenerated = false;
				while (!allGenerated)
				{
					//generate permutation
					var newComb = "";
					for (int i = 0; i < returnedLists.Count(); i++)
					{
						newComb += returnedLists[i][indexList[i]];
					}
					newList.Add(newComb);

					//increment necessary indices
					for (int i = 0; i < indexList.Count(); i++)
					{
						indexList[i]++;
						if (indexList[i] == returnedLists[i].Count())
						{
							if (i == indexList.Count() - 1)
							{
								allGenerated = true;
								break;
							}
							else indexList[i] = 0;
						}
						else break;
					}
				}
			}

			return newList;
		}
		#endregion

		private void btnDay20_Click(object sender, EventArgs e)
		{
			var input = getInput("input20.txt", new string[] { "\n\n", "\r\n\r\n" });
			var tileDict = new Dictionary<int, bool[,]>();

			var inputTiles = new List<Tile>();

			foreach (var rawTile in input)
			{
				var split = rawTile.Split(new string[] { ":\n" }, StringSplitOptions.None);
				int ID = int.Parse(split[0].Split(' ')[1]);
				var tileLines = split[1].Split('\n');
				var newArr = new bool[tileLines.Length, tileLines[0].Length];
				for (int r = 0; r <= newArr.GetUpperBound(0); r++)
				{
					for (int c = 0; c <= newArr.GetUpperBound(1); c++)
					{
						newArr[r, c] = tileLines[r][c] == '#' ? true : false;
					}
				}

				inputTiles.Add(new Tile(newArr, ID));
			}

			//var arr = new bool[12,12];

			//for (int i = 0; i <= 6; i++)
			//{
			//	for (int j = 0; j <= 6; j++)
			//	{
			//		if ((i + j) % 2 == 0) arr[i, j] = true;
			//	}
			//}
			//printArray(arr);
			//printArray(rotateArray(arr, 0));
			//printArray(rotateArray(arr, 1));
			//printArray(rotateArray(arr, 2));

			var board = new Tile[2, 2];
			BuildBoard(board, new List<Tile>());
			Console.WriteLine(board[0, 0].ID);
		}

		private void printArray(bool[,] arr)
		{
			for (int r = 0; r < arr.GetUpperBound(0) + 1; r++)
			{
				for (int c = 0; c < arr.GetUpperBound(1) + 1; c++)
				{
					Console.Write(arr[r,c] ? "#" : ".");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		private bool[,] rotateArray(bool[,] arr, int deg)
		{
			bool[,] newArr = new bool[arr.GetUpperBound(0) + 1, arr.GetUpperBound(1) + 1];

			switch (deg)
			{
				case 0: //90 deg CW
					for (int r = 0; r <= arr.GetUpperBound(0); r++)
					{
						for (int c = 0; c <= arr.GetUpperBound(1); c++)
						{
							newArr[c, arr.GetUpperBound(1) - r] = arr[r, c];
						}
					}
					break;
				case 1: //180 deg CW
					for (int r = 0; r <= arr.GetUpperBound(0); r++)
					{
						for (int c = 0; c <= arr.GetUpperBound(1); c++)
						{
							newArr[arr.GetUpperBound(0) - r, arr.GetUpperBound(1) - c] = arr[r, c];
						}
					}
					break;
				case 2: //270 deg CW
					for (int r = 0; r <= arr.GetUpperBound(0); r++)
					{
						for (int c = 0; c <= arr.GetUpperBound(1); c++)
						{
							newArr[arr.GetUpperBound(1) - c, r] = arr[r, c];
						}
					}
					break;
				default:
					break;
			}

			return newArr;
		}

		/// <summary>
		/// Flip about horizontal axis
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		private bool[,] flipArrayH(bool[,] arr)
		{
			var newArr = new bool[arr.GetUpperBound(0) + 1, arr.GetUpperBound(1) + 1];
			for (int r = 0; r <= arr.GetUpperBound(0); r++)
			{
				for (int c = 0; c <= arr.GetUpperBound(1); c++)
				{
					newArr[arr.GetUpperBound(0) - r, c] = arr[r, c];
				}
			}
			return newArr;
		}

		/// <summary>
		/// Flip about vertical axis
		/// </summary>
		/// <param name="arr"></param>
		/// <returns></returns>
		private bool[,] flipArrayV(bool[,] arr)
		{
			var newArr = new bool[arr.GetUpperBound(0) + 1, arr.GetUpperBound(1) + 1];
			for (int r = 0; r <= arr.GetUpperBound(0); r++)
			{
				for (int c = 0; c <= arr.GetUpperBound(1); c++)
				{
					newArr[r, arr.GetUpperBound(1) - c] = arr[r, c];
				}
			}
			return newArr;
		}

		public struct Tile
		{
			public bool[,] arr;
			public int ID;

			public Tile(bool[,] a = null, int i = 0)
			{
				arr = a;
				ID = i;
			}
		}

		private void BuildBoard(Tile[,] board, int loc, List<Tile> tilesAvailable)
		{
			int r = loc / (tilesAvailable[0].arr.GetUpperBound(1) + 1);
			int c = loc % (tilesAvailable[0].arr.GetUpperBound(1) + 1);

			//Pop first item from available tiles
			var nextTile = tilesAvailable.First();
			tilesAvailable.RemoveAt(0);

			//try with no rotation
			if (validPlace(nextTile, board, new Point(r, c)))
			{
				board[r, c] = nextTile;
				BuildBoard(board, loc++, tilesAvailable);
				if (board[board.GetUpperBound(0), board.GetUpperBound(1)].arr != null) return;
				else board[r, c] = new Tile();
			}

			//now try with each different rotation
			for (int i = 0; i <= 2; i++)
			{

			}

			//check if it's valid in board at [r,c]
			//if so, insert it, then call recursively (incrementing r and c)
			//if board is full, return
			//else remove it and try the next rotation


		}

		private bool validPlace(Tile test, Tile[,] board, Point loc)
		{
			bool upValid = (loc.Y - 1 >= 0) && getRow(board[loc.X, loc.Y - 1], board[loc.X, loc.Y - 1].arr.GetUpperBound(0)) == getRow(test, 0);
			bool downValid = (loc.Y + 1 <= board.GetUpperBound(0)) && getRow(board[loc.X, loc.Y + 1], 0) == getRow(test, test.arr.GetUpperBound(0));
			bool leftValid = (loc.X - 1 >= 0) && getCol(board[loc.X - 1, loc.Y], board[loc.X - 1, loc.Y].arr.GetUpperBound(1)) == getCol(test, 0);
			bool rightValid = (loc.X + 1 <= board.GetUpperBound(1)) && getCol(board[loc.X - 1, loc.Y], 0) == getCol(test, test.arr.GetUpperBound(1));

			return upValid && downValid && leftValid && rightValid;
		}

		private string getRow(Tile t, int r)
		{
			string str = "";
			for (int c = 0; c < t.arr.GetUpperBound(1); c++)
			{
				str += t.arr[r, c] ? '#' : '.';
			}
			return str;
		}

		private string getCol(Tile t, int c)
		{
			string str = "";
			for (int r = 0; r < t.arr.GetUpperBound(0); r++)
			{
				str += t.arr[r, c] ? '#' : '.';
			}
			return str;
		}

	}

	


	#region Passport Stuff (Day 4)
	public class Passport
	{
		public int BYR = -1;
		public string PID = "";
		public int EYR = -1;
		public string HCL = "";
		public int IYR = -1;
		public int CID = -1;
		public int HGT_CM = -1;
		public int HGT_IN = -1;
		public string ECL = "";

		public bool valid_BYR { get { return BYR >= 1920 && BYR <= 2002; } }
		public bool valid_PID { get { return Regex.Match(PID, "^\\d{9}$").Success; } }
		public bool valid_EYR { get { return EYR >= 2020 && EYR <= 2030; } }
		public bool valid_HCL { get { return Regex.Match(HCL, "\\#(\\d|[a-f]){6}").Success; } }
		public bool valid_IYR { get { return IYR >= 2010 && IYR <= 2020; } }
		public bool valid_CID { get { return true; } }
		public bool valid_HGT { get { return (HGT_CM >= 150 && HGT_CM <= 193) || (HGT_IN >= 59 && HGT_IN <= 76); } }
		public bool valid_ECL { get { return Regex.Match(ECL, "(amb|blu|brn|gry|grn|hzl|oth){1}").Success; } }

		public bool valid_All { get { return 
					valid_BYR && 
					valid_PID && 
					valid_EYR && 
					valid_HCL && 
					valid_IYR && 
					valid_CID && 
					valid_HGT && 
					valid_ECL; } }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str">Raw string from input</param>
		public Passport(string str)
		{
			string[] split = str.Split(new char[] { '\n', ' ' });
			foreach (string entry in split)
			{
				int colonLoc = entry.IndexOf(":");
				string value = entry.Substring(colonLoc + 1);

				if(entry.Contains("byr"))
				{
					BYR = int.Parse(value);
				}
				else if (entry.Contains("pid"))
				{
					PID = value;
				}
				else if (entry.Contains("eyr"))
				{
					EYR = int.Parse(value);
				}
				else if (entry.Contains("hcl"))
				{
					HCL = value;
				}
				else if (entry.Contains("iyr"))
				{
					IYR = int.Parse(value);
				}
				else if (entry.Contains("cid"))
				{
					CID = int.Parse(value);
				}
				else if (entry.Contains("hgt"))
				{
					if (value.Contains("cm"))
					{
						int cmLoc = value.IndexOf("cm");
						value = value.Substring(0, cmLoc);
						HGT_CM = int.Parse(value);
					}
					else if (value.Contains("in"))
					{
						int inLoc = value.IndexOf("in");
						value = value.Substring(0, inLoc);
						HGT_IN = int.Parse(value);
					}
				}
				else if (entry.Contains("ecl"))
				{
					ECL = value;
				}
			}
		}
		
	}
	#endregion
}
