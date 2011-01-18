using System;
using System.Collections.Generic;

namespace WordProcessing
{
	public class StringUtils
	{
		
		public static string DefaultString(string input)
		{
			return string.IsNullOrEmpty(input) ? string.Empty : input;
		}
		
		public static string Reverse(string input)
		{
			//Validate input
			if (input == null)
				return null;
			if(input.Equals(string.Empty))
				return string.Empty;

			char[] outputChars = input.ToCharArray();

			//Reverse
			Array.Reverse(outputChars);
			
			//build a string from the processed characters and return it
			return new string(outputChars);
		}
		
		public static string ReverseDelimited(string input, string separatorChar)
		{
			if (input == null)
				return null;
			// could implement manually, but simple way is to reuse other,
			// probably slower, methods.
			string[] strs = input.Split(separatorChar.ToCharArray());
			Array.Reverse(strs);
			return string.Join(separatorChar,strs);
		}

		public static string InsertSeparator(string input, string separator)
		{
			//Validate string
			if (string.IsNullOrEmpty(input))
				return string.Empty;

			List<char> outputChars = new List<char>(input.ToCharArray());
			char[] separatorChars = separator.ToCharArray();

			int i = 1;
			while (i < outputChars.Count)
			{
				if (i != outputChars.Count) //don't add separator to the end of string
					outputChars.InsertRange(i, separatorChars);

				i += 1 + separator.Length; //go up the interval amount plus separator
			}

			return new string(outputChars.ToArray());
		}

		public static string InsertSeparator(string input, string separator, int interval)
		{
			//Validate string
			if (string.IsNullOrEmpty(input))
				return string.Empty;

			List<char> outputChars = new List<char>(input.ToCharArray());
			char[] separatorChars = separator.ToCharArray();

			int i = interval;
			while (i < outputChars.Count)
			{
				if (i != outputChars.Count) //don't add separator to the end of string
					outputChars.InsertRange(i, separatorChars);

				i += interval + separator.Length; //go up the interval amount plus separator
			}

			return new string(outputChars.ToArray());
		}

		public static string SubstringEnd(string input, int start, int end)
		{
			//Verify input
			if (string.IsNullOrEmpty(input) || start == end)
				return string.Empty;

			if (start < 0)
				throw new IndexOutOfRangeException("start index cannot be less than zero.");

			if (start >= input.Length)
				throw new IndexOutOfRangeException("start index cannot be greater than the length of the string.");

			if (end < 0)
				throw new IndexOutOfRangeException("end index cannot be less than zero.");

			if (end >= input.Length)
				throw new IndexOutOfRangeException("end index cannot be greater than the length of the string.");

			if (end > start)
				throw new IndexOutOfRangeException("end index cannot be greater than the start index.");

			return input.Substring(start, end - start);
		}

		public static char CharRight(string input, int index)
		{
			//Verify input
			if (string.IsNullOrEmpty(input))
				return new char();

			if (input.Length - index - 1 >= input.Length)
				throw new IndexOutOfRangeException("Index cannot be less than zero.");

			if (input.Length - index - 1 < 0)
				throw new IndexOutOfRangeException("Index cannot be larger than the length of the string");

			return input[input.Length - index - 1];
		}

		public static char CharMid(string input, int startingIndex, int count)
		{
			//Verify input
			if (string.IsNullOrEmpty(input))
				return new char();

			if (startingIndex < 0)
				throw new IndexOutOfRangeException("startingIndex cannot be less than zero.");

			if (startingIndex >= input.Length)
				throw new IndexOutOfRangeException("startingIndex cannot be greater than the length of the string.");

			if (startingIndex + count < 0)
				throw new IndexOutOfRangeException("startingIndex + count cannot be less than zero.");

			if (startingIndex + count >= input.Length)
				throw new IndexOutOfRangeException("startingIndex + count cannot be greater than the length of the string.");

			return input[startingIndex + count];
		}

		public static string Trim(string input)
		{
			return input == null ? null : input.Trim();
		}

		public static string TrimToNull(string input)
		{
			string ts = Trim(input);
			return ts == string.Empty ? null : ts;
		}

		public static string TrimToEmpty(string input)
		{
			return input == null ? string.Empty : input.Trim();
		}

		public static bool EqualsIgnoreCase(string str1, string str2)
		{
			return str1 == null ? str2 == null : (str2 == null) ? false : str1.ToLower().Equals(str2.ToLower());
		}

		public static bool IsAlternateCases(string input)
		{
			//Verify input
			if (string.IsNullOrEmpty(input) || input.Length == 1) return false;

			bool isLastUpper = char.IsUpper(input[0]);

			for (int i = 1; i < input.Length; i++)
			{
				if (isLastUpper)
				{
					if (char.IsUpper(input[i]))
						return false; //two upper-cases in a row
				}
				else
				{
					if (char.IsLower(input[i]))
						return false; //two lower-cases in a row
				}

				isLastUpper = !isLastUpper; //alternate
			}

			return true;
		}

		public static bool IsLowerCase(string input)
		{
			//Verify input
			if (string.IsNullOrEmpty(input)) return false;

			for (int i = 0; i < input.Length; i++)
			{
				//A single non-lower case character makes function false,
				//unless it is a chracter other than a letter
				if (!char.IsLower(input[i]) && char.IsLetter(input[i]))
					return false;
			}
			
			return true;
		}

		public static bool IsUpperCase(string input)
		{
			//Verify input
			if (string.IsNullOrEmpty(input))
				return false;

			for (int i = 0; i < input.Length; i++)
			{
				//A single non-upper case character makes function false,
				//unless it is a chracter other than a letter
				if (!char.IsUpper(input[i]) && char.IsLetter(input[i]))
					return false;
			}
			
			return true;
		}

		public static bool IsSpaces(string input)
		{
			if (input == null)
				return false;
			for (int i = 0; i < input.Length; i++)
			{
				if (!char.IsWhiteSpace(input[i]))
					return false;
			}
			
			return true;
		}

		public static bool IsRepeatedChar(string input)
		{
			return string.IsNullOrEmpty(input) || input.Replace(input[0].ToString(), "").Length == 0;
		}

		public static bool IsNumeric(string input)
		{
			//Verify input
			if (string.IsNullOrEmpty(input))
				return false;

			for (int i = 0; i < input.Length; i++)
			{
				if (!char.IsNumber(input[i]))
					return false; //single non-numeric integer makes function false
			}
			
			return true;
		}
		
		public static bool IsNumericSpace(string input)
		{
			if (input == null)
				return false;
			
			for (int i = 0; i < input.Length; i++)
			{
				if (!char.IsDigit(input[i])&& !char.IsWhiteSpace(input[i]))
					return false;
			}
			return true;
		}
		
		public static bool IsAsciiPrintable(string input)
		{
			if (input == null)
				return false;
			
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] < 32 || input[i] >=127 )
					return false;
				
			}
			return true;
		}

		public static bool HasNumberic(string input)
		{
			//Verify input
			if (string.IsNullOrEmpty(input))
				return false;

			for (int i = 0; i < input.Length; i++)
			{
				if (char.IsNumber(input[i]))
					return true; //single numeric integer makes function true
			}
			
			return false;
		}

		public static bool IsAlphaNumberic(string input)
		{
			//Verify input
			if (string.IsNullOrEmpty(input)) return false;

			for (int i = 0; i < input.Length; i++)
			{
				if (!char.IsLetter(input[i]) && !char.IsNumber(input[i]))
					return false;
			}
			
			return true;
		}

		public static bool IsLetters(string input)
		{
			//Verify input
			if (string.IsNullOrEmpty(input))
				return false;

			for (int i = 0; i < input.Length; i++)
			{
				if (!char.IsLetter(input[i]))
				{
					return false;
				}
			}
			
			return true;
		}
		
		public static string GetCommonPrefix(String[] inputs)
		{
			if (inputs == null || inputs.Length == 0)
				return string.Empty;
			
			int smallestIndexOfDiff = IndexOfDifference(inputs);
			
			if (smallestIndexOfDiff == -1)
			{
				// all strings were identical
				if (inputs[0] == null)
					return string.Empty;
				
				return inputs[0];
			}
			else if (smallestIndexOfDiff == 0)
			{
				// there were no common initial characters
				return string.Empty;
			}
			else
			{
				// we found a common initial character sequence
				return inputs[0].Substring(0, smallestIndexOfDiff);
			}
		}

		public static string Difference(string input1,string input2)
		{
			if (input1 == null)
				return input2;
			if (input2 == null)
				return input1;
			int index = IndexOfDifference(input1, input2);
			if (index == -1)
				return string.Empty;
			
			return input2.Substring(index);
		}
		
		public static int IndexOfDifference(string input1, string input2) {
			
			if (input1 == input2)
				return -1;
			
			if (input1 == null || input2 == null)
				return 0;
			
			int index;
			for (index = 0; index < input1.Length && index < input2.Length ; ++index)
			{
				if (input1[index] != input2[index]) {
					break;
				}
			}
			if (index < input2.Length || index < input1.Length)
				return index;
			
			return -1;
		}
		
		public static int IndexOfDifference(string[] inputs)
		{
			if (inputs == null || inputs.Length <= 1)
				return -1;
			bool anyStringNull = false;
			bool allStringsNull = true;
			int shortestStrLen = int.MaxValue;
			int longestStrLen = 0;
			
			for (int i = 0; i < inputs.Length; i++)
			{
				if (inputs[i] == null) {
					anyStringNull = true;
					shortestStrLen = 0;
				}
				else
				{
					allStringsNull = false;
					shortestStrLen = Math.Min(inputs[i].Length, shortestStrLen);
					longestStrLen = Math.Max(inputs[i].Length, longestStrLen);
				}
			}
			// handle lists containing all nulls or all empty strings
			if (allStringsNull || (longestStrLen == 0 && !anyStringNull))
				return -1;
			
			// handle lists containing some nulls or some empty strings
			if (shortestStrLen == 0)
				return 0;
			
			// find the position with the first difference across all strings
			int firstDiff = -1;
			for (int stringPos = 0; stringPos < shortestStrLen; stringPos++)
			{
				char comparisonChar = inputs[0][stringPos];
				
				for (int arrayPos = 1; arrayPos < inputs.Length; arrayPos++)
				{
					if (inputs[arrayPos][stringPos] != comparisonChar)
					{
						firstDiff = stringPos;
						break;
					}
				}
				
				if (firstDiff != -1)
					break;
			}
			if (firstDiff == -1 && shortestStrLen != longestStrLen) {
				// we compared all of the characters up to the length of the
				// shortest string and didn't find a match, but the string lengths
				// vary, so return the length of the shortest string.
				return shortestStrLen;
			}
			
			return firstDiff;
		}
		
		public static int CountString(string input, string sequence, bool ignoreCase)
		{
			//Verify input
			if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(sequence))
				return 0;

			int count = 0;
			string inputSegment = null; //holds the current segment being compared

			for (int i = 0; i < input.Length; i++)
			{
				if (i + sequence.Length > input.Length)
					break; //sequence doesn't fit anymore

				inputSegment = input.Substring(i, sequence.Length);

				if (string.Compare(inputSegment, sequence, ignoreCase) == 0)
					count++; //another match found
			}
			
			return count;
		}

		public static int[] IndexOfAll(string input, string sequence, bool ignoreCase)
		{
			//Verify input
			if (string.IsNullOrEmpty(input))
				return new int[0]; //empty array

			List<int> indices = new List<int>();

			string inputSegment = null; //holds the current segment being compared

			for (int i = 0; i < input.Length; i++)
			{
				if (i + sequence.Length >= input.Length)
					break; //sequence doesn't fit anymore

				inputSegment = input.Substring(i, sequence.Length);

				if (string.Compare(inputSegment, sequence, ignoreCase) == 0)
					indices.Add(i);
			}

			//Copy entries over to an array
			int[] output = indices.ToArray();
			indices.Clear();

			return output;
		}

		public static int[] IndexOfAll(string input, string sequence, int startIndex, bool ignoreCase)
		{
			//Verify input
			if (string.IsNullOrEmpty(input))
				return new int[0]; //empty array

			List<int> indices = new List<int>();

			string inputSegment = null; //holds the current segment being compared

			for (int i = startIndex; i < input.Length; i++)
			{
				if (i + sequence.Length >= input.Length)
					break; //sequence doesn't fit anymore

				inputSegment = input.Substring(i, sequence.Length);

				if (string.Compare(inputSegment, sequence, ignoreCase) == 0)
					indices.Add(i);
			}

			//Copy entries over to an array
			int[] output = indices.ToArray();
			indices.Clear();

			return output;
		}

		public static int[] IndexOfAll(string input, char matchChar, int maxMatches, bool ignoreCase)
		{
			List<int> occurrences = new List<int>();
			int foundPos = -1; // -1 represents not found.
			int numberFound = 0;
			int startPos = 0;
			char tempMatchChar = matchChar;
			string tempSource = input;
			if (!ignoreCase)
			{
				tempMatchChar = char.ToUpper(matchChar);
				tempSource = input.ToUpper();
			}
			
			do
			{
				foundPos = tempSource.IndexOf(matchChar, startPos);
				
				if (foundPos > -1)
				{
					startPos = foundPos + 1;
					numberFound++;
					if (maxMatches > -1 && numberFound > maxMatches)
					{
						break;
					}
					else
					{
						occurrences.Add(foundPos);
					}
				}
			}
			while (foundPos > -1);
			
			return occurrences.ToArray();
		}

		public static int[] IndexOfAll(string input, char matchChar)
		{
			return IndexOfAll(input, matchChar, -1, false);
		}

		public static int[] IndexOfAll(string input, char matchChar, int maxMatches)
		{
			return IndexOfAll(input, matchChar, maxMatches, false);
		}

		public static int[] IndexOfAll(string input, char matchChar, bool ignoreCase)
		{
			return IndexOfAll(input, matchChar, -1, ignoreCase);
		}
		
		public static string RemoveChar(string input, char remove)
		{
			if(input==null)
				return null;
			
			if (input.Equals(string.Empty) || input.IndexOf(remove) == -1)
				return input;
			
			char[] chars = input.ToCharArray();
			int pos = 0;
			
			for (int i = 0; i < chars.Length; i++)
			{
				if (chars[i] != remove) 
					chars[pos++] = chars[i];
			}
			return new string(chars, 0, pos);
		}
		
		public static string RemoveString(string input , string segment)
		{
			if(string.IsNullOrEmpty(input) || string.IsNullOrEmpty(segment))
				return input;
			return input.Replace(segment,"");
		}
		
		public static string RemoveNumeric(string input)
		{
			if(input==null)
				return null;
			char[] chars = input.ToCharArray();
			int pos=0;
			for(int i = 0;i<chars.Length;i++)
			{
				if(!char.IsDigit(chars[i]))
				   chars[pos++] = chars[i];
			}
			return new string(chars,0,pos);
		}
		
		public static string RemoveLetters(string input)
		{
			if(input==null)
				return null;
			char[] chars = input.ToCharArray();
			int pos=0;
			for(int i = 0;i<chars.Length;i++)
			{
				if(!char.IsLetter(chars[i]))
				   chars[pos++] = chars[i];
			}
			return new string(chars,0,pos);
		}
		
		public static bool IsPalaindrom(string input)
		{
			if(input==null)
				return false;
			
			return input.Equals(Reverse(input));
		}
	}
}
