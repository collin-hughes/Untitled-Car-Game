using System;
using System.Collections.Generic;

using UntitledCarGame.Exceptions;

using Microsoft.Xna.Framework;

namespace UntitledCarGame.Interface
{
	public enum instructionSet
	{
		add, sub, mul, div, acc, trn,
		brk, madd, msub, mmul, mdiv,
		macc, mtrn, mbrk, mvi, mvo
	};

	public struct Instruction
	{
		public instructionSet? instruction;
		public float? valA;
		public float? valB;
	}

	public struct PlayerData
	{
		public Vector2 moveInput;
		public float brkAmt;
	}

	public class ProgrammingInterface
	{
		List<Instruction> instructionList;
		List<String> rawInstructionList;

		int lineCounter;

		float tempMath;
		float[] memory;

		bool badFile;

		public ProgrammingInterface()
		{
			instructionList = new List<Instruction>();
			memory = new float[8];
			lineCounter = 0;
			tempMath = 0f;
		}

		public void GiveFilepath(string _fileName)
		{
			rawInstructionList = new List<string>(System.IO.File.ReadAllLines(_fileName));

			if(rawInstructionList.Count > 0)
			{
				badFile = false;

				for (int lineNumber = 0; lineNumber < rawInstructionList.Count; lineNumber++)
				{
					instructionList.Add(ExtractInstruction(lineNumber, rawInstructionList[lineNumber]));
				}
			}

			else
			{
				badFile = true;
				Console.WriteLine("No instructions in input file.");
			}
		}

		public Instruction ExtractInstruction(int _lineNumber, string _instructionLine)
		{
			Instruction newInstruction;

			string rawInstruction = "";

			char delimiter = ';';

			int firstDelimiter;
			int secondDelimiter;
			int thirdDelimiter;

			string rawValA = "";
			string rawValB = "";

			newInstruction = new Instruction();

			if((firstDelimiter = _instructionLine.IndexOf(delimiter, 0)) >= 0)
			{
				rawInstruction = _instructionLine.Substring(0, firstDelimiter);
			}

			else
			{
				rawInstruction = null;
			}


			if ((secondDelimiter = _instructionLine.IndexOf(delimiter, firstDelimiter + 1)) >= 0)
			{
				rawValA = _instructionLine.Substring(firstDelimiter + 1, secondDelimiter - firstDelimiter - 1);
			}

			else
			{
				rawInstruction = null;
			}

			if ((thirdDelimiter = _instructionLine.IndexOf(delimiter, secondDelimiter + 1)) >= 0)
			{
				if (thirdDelimiter > secondDelimiter)
				{
					rawValB = _instructionLine.Substring(secondDelimiter + 1, thirdDelimiter - secondDelimiter - 1);
				}
			}

			try
			{
				if (rawInstruction != null && rawInstruction.CompareTo("add") == 0)
				{
					newInstruction.instruction = instructionSet.add;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = float.Parse(rawValB);
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("sub") == 0)
				{
					newInstruction.instruction = instructionSet.sub;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = float.Parse(rawValB);
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("mul") == 0)
				{
					newInstruction.instruction = instructionSet.mul;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = float.Parse(rawValB);
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("div") == 0)
				{
					newInstruction.instruction = instructionSet.div;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = float.Parse(rawValB);

					if (newInstruction.valB == 0f)
					{
						throw new Exception();
					}
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("acc") == 0)
				{
					newInstruction.instruction = instructionSet.acc;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = null;
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("trn") == 0)
				{
					newInstruction.instruction = instructionSet.trn;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = null;
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("brk") == 0)
				{
					newInstruction.instruction = instructionSet.brk;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = null;
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("madd") == 0)
				{
					newInstruction.instruction = instructionSet.madd;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = float.Parse(rawValB);
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("msub") == 0)
				{
					newInstruction.instruction = instructionSet.msub;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = float.Parse(rawValB);
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("mmul") == 0)
				{
					newInstruction.instruction = instructionSet.mmul;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = float.Parse(rawValB);
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("mdiv") == 0)
				{
					newInstruction.instruction = instructionSet.mdiv;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = float.Parse(rawValB);
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("macc") == 0)
				{
					newInstruction.instruction = instructionSet.macc;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = null;
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("mtrn") == 0)
				{
					newInstruction.instruction = instructionSet.mtrn;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = null;
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("mbrk") == 0)
				{
					newInstruction.instruction = instructionSet.mbrk;
					newInstruction.valA = float.Parse(rawValA);
					newInstruction.valB = null;
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("mvi") == 0)
				{
					if (Convert.ToInt32(rawValA) < memory.Length && Convert.ToInt32(rawValA) >= 0)
					{
						newInstruction.instruction = instructionSet.mvi;
						newInstruction.valA = float.Parse(rawValA);
						newInstruction.valB = null;
					}

					else
					{
						throw new InvalidMemoryLocationException(_lineNumber);
					}
				}

				else if (rawInstruction != null && rawInstruction.CompareTo("mvo") == 0)
				{
					if (Convert.ToInt32(rawValA) < memory.Length && Convert.ToInt32(rawValA) >= 0)
					{
						newInstruction.instruction = instructionSet.mvo;
						newInstruction.valA = float.Parse(rawValA);
						newInstruction.valB = null;
					}

					else
					{
						throw new InvalidMemoryLocationException(_lineNumber);
					}
				}

				else
				{
					throw new InvalidInstructionException(_lineNumber);
				}

			}
			
			catch(Exception ex)
			{
				if(!(ex is InvalidInstructionException) && !(ex is InvalidMemoryLocationException))
				{
					Console.WriteLine($"Bad Instruction Detected at Line {_lineNumber + 1}");
				}

				newInstruction.instruction = null;
				newInstruction.valA = null;
				newInstruction.valB = null;
			}

			return newInstruction;
		}



		public PlayerData GetInstruction()
		{
			Instruction currentInstruction;
			PlayerData playerData = new PlayerData();

			if(!badFile)
			{
				currentInstruction = instructionList[lineCounter];

				switch (currentInstruction.instruction)
				{
					case instructionSet.add:
						tempMath = (float)(currentInstruction.valA + currentInstruction.valB);
						break;

					case instructionSet.sub:
						tempMath = (float)(currentInstruction.valA - currentInstruction.valB);
						break;

					case instructionSet.mul:
						tempMath = (float)(currentInstruction.valA * currentInstruction.valB);
						break;

					case instructionSet.div:
						tempMath = (float)(currentInstruction.valA / currentInstruction.valB);
						break;

					case instructionSet.acc:
						playerData.moveInput.Y = (float)currentInstruction.valA;
						break;

					case instructionSet.trn:
						playerData.moveInput.X = (float)currentInstruction.valA;
						break;

					case instructionSet.brk:
						playerData.brkAmt = (float)currentInstruction.valA;
						break;

					case instructionSet.madd:
						tempMath = (float)(memory[Convert.ToInt32(currentInstruction.valA)] + memory[Convert.ToInt32(currentInstruction.valB)]);
						break;

					case instructionSet.msub:
						tempMath = (float)(memory[Convert.ToInt32(currentInstruction.valA)] - memory[Convert.ToInt32(currentInstruction.valB)]);
						break;

					case instructionSet.mmul:
						tempMath = (float)(memory[Convert.ToInt32(currentInstruction.valA)] * memory[Convert.ToInt32(currentInstruction.valB)]);
						break;

					case instructionSet.mdiv:
						tempMath = (float)(memory[Convert.ToInt32(currentInstruction.valA)] / memory[Convert.ToInt32(currentInstruction.valB)]);

						if(float.IsInfinity(tempMath))
						{
							tempMath = 0;
						}

						break;

					case instructionSet.macc:
						playerData.moveInput.Y = memory[Convert.ToInt32(currentInstruction.valA)];
						break;

					case instructionSet.mtrn:
						playerData.moveInput.X = memory[Convert.ToInt32(currentInstruction.valA)];
						break;

					case instructionSet.mbrk:
						playerData.brkAmt = memory[Convert.ToInt32(currentInstruction.valA)];
						break;

					case instructionSet.mvi:
						memory[Convert.ToInt32(currentInstruction.valA)] = tempMath;
						break;

					case instructionSet.mvo:
						tempMath = memory[Convert.ToInt32(currentInstruction.valA)];
						break;

					default:
						break;
				}

				lineCounter++;

				if (lineCounter >= instructionList.Count)
				{
					lineCounter = 0;
				}
			}

			else
			{
				UntitiledCarGame.instance.SceneChangeToSetup();
			}

			return playerData;
		}



		public void PrintInstructionData()
		{
			foreach (Instruction currentInstruction in instructionList)
			{
				if (currentInstruction.instruction != null)
				{
					Console.WriteLine(currentInstruction.instruction);
				}

				if (currentInstruction.valA != null)
				{
					Console.WriteLine(currentInstruction.valA);
				}

				if (currentInstruction.valB != null)
				{
					Console.WriteLine(currentInstruction.valB);
				}

				Console.WriteLine();
			}
		}
	}
}

