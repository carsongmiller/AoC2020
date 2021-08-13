using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

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
				{treeCount += 1;}
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
				else if(!taken[i])
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
						answers[b-97] = true;
					}
				}
				totalCount += answers.Where(c => c).Count();
			}

			Console.WriteLine("Part 1: " + totalCount);


			//Part 2

			totalCount = inputSplit
				.Select(x => x.Split('\n').Aggregate((a, b) => new string(a.Intersect(b).ToArray())))
				.Sum(x => x.Length);

			//the code below works too.  Above is just cooler

			//foreach (string str in inputSplit)
			//{
			//	string[] personSplit = Regex.Split(str, "\n");
			//	bool[] aggregate = Enumerable.Repeat(true, 26).ToArray();

			//	for (int i = 0; i < personSplit.Length; i++)
			//	{
			//		bool[] answers = new bool[26];
			//		foreach (byte b in Encoding.UTF8.GetBytes(personSplit[i].ToCharArray()))
			//		{
			//			answers[b - 97] = true;
			//		}

			//		for (int j = 0; j < 26; j++) { aggregate[j] &= answers[j]; }
			//	}

			//	totalCount += aggregate.Where(c => c).Count();
			//}

			Console.WriteLine("Part 2: " + totalCount);
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
