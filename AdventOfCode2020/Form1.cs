using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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

		private void btnDay12_Click(object sender, EventArgs e)
		{
			string[] input = getInput("input12.txt");
		}
	}

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
}
