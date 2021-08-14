using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
	class Processor
	{
		public List<Instruction> instructions = new List<Instruction>();
		public List<int> prevRun = new List<int>();
		public int pointer = 0;
		public int accumulator = 0;
		public bool avoidLoop = true;
		public bool nextStepRepeat { get { return prevRun.Contains(pointer); } }

		public Processor(string[] instRaw)
		{
			instRaw.ToList().ForEach(x => { instructions.Add(new Instruction(x)); });
		}

		public void Reset()
		{
			prevRun.Clear();
			pointer = 0;
			accumulator = 0;
		}

		public void Step(int numSteps = 1)
		{
			if (avoidLoop && prevRun.Contains(pointer)) return;
			prevRun.Add(pointer);

			Instruction current = instructions.ElementAt(pointer);
			
			switch (current.type) {
				case Instruction.InstructionType.acc:
					accumulator += current.value;
					pointer++;
					break;
				case Instruction.InstructionType.jmp:
					pointer += current.value;
					break;
				case Instruction.InstructionType.nop:
					pointer++;
					break;
				default:
					break;
			}
		}

		public int Run()
		{
			while (true)
			{
				Step();
				if (pointer == instructions.Count) return accumulator;
				if (nextStepRepeat) return -1;
			}
		}

		public struct Instruction
		{
			public InstructionType type;
			public int value;

			public Instruction(string s)
			{
				string[] split = s.Split(' ');
				Enum.TryParse<InstructionType>(split[0], out type);
				int.TryParse(split[1], out value);
			}
			public enum InstructionType
			{
				acc = 0,
				jmp,
				nop
			}
		}
	}


}
