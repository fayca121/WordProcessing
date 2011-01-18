/*
 * Crée par SharpDevelop.
 * Utilisateur: Bououza
 * Date: 16/01/2011
 * Heure: 09:30
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace WordProcessing
{
	/// <summary>
	/// Description of WordUtils.
	/// </summary>
	public class WordUtils
	{
		public static string Capitalize(string input)
		{
			return Capitalize(input, null);
		}
		
		public static string Capitalize(string input, char[] delimiters)
		{
			int delimLen = (delimiters == null) ? -1 : delimiters.Length;
			if (string.IsNullOrEmpty(input) || delimLen == 0)
			{
				return input;
			}
			
			int strLen = input.Length;
			StringBuilder buffer = new StringBuilder(strLen);
			bool capitalizeNext = true;
			for (int i = 0; i < strLen; i++)
			{
				char ch = input[i];

				if (IsDelimiter(ch, delimiters))
				{
					buffer.Append(ch);
					capitalizeNext = true;
				}
				else if (capitalizeNext)
				{
					buffer.Append(char.ToUpper(ch));
					capitalizeNext = false;
				}
				else
				{
					buffer.Append(ch);
				}
			}
			
			return buffer.ToString();
		}
		
		public static string CapitalizeFully(string str)
		{
			return CapitalizeFully(str, null);
		}
		
		public static string CapitalizeFully(string input, char[] delimiters)
		{
			int delimLen = (delimiters == null) ? -1 : delimiters.Length;
			if (string.IsNullOrEmpty(input) || delimLen == 0)
				return input;
			input = input.ToLower();
			return Capitalize(input, delimiters);
		}
		
		public static string Uncapitalize(string input)
		{
			return Uncapitalize(input, null);
		}
		
		public static string Uncapitalize(string input, char[] delimiters)
		{
			int delimLen = (delimiters == null) ? -1 : delimiters.Length;
			if (string.IsNullOrEmpty(input) || delimLen == 0)
				return input;
			
			int strLen = input.Length;
			StringBuilder buffer = new StringBuilder(strLen);
			bool uncapitalizeNext = true;
			for (int i = 0; i < strLen; i++)
			{
				char ch = input[i];
				if (IsDelimiter(ch, delimiters))
				{
					buffer.Append(ch);
					uncapitalizeNext = true;
				}
				else if (uncapitalizeNext)
				{
					buffer.Append(char.ToLower(ch));
					uncapitalizeNext = false;
				}
				else
				{
					buffer.Append(ch);
				}
			}
			
			return buffer.ToString();
		}
		
		public static string SwapCases(string input)
		{
			//Validate input
			if(input==null)
				return null;
			if (input.Equals(string.Empty))
				return string.Empty;
			
			int strLen = input.Length;
			
			StringBuilder buffer = new StringBuilder(strLen);
			
			char ch, tmp;
			for (int i = 0; i < strLen; i++)
			{
				ch = input[i];
				if (char.IsUpper(ch))
				{
					tmp = char.ToLower(ch);
				}
				else if (char.IsLower(ch))
				{
					tmp = char.ToUpper(ch);
				}
				else
				{
					tmp = ch;
				}
				
				buffer.Append(tmp);
			}
			
			return buffer.ToString();
		}
		
		public static string GetInitials(string input, bool capitalizeInitials, 
		                                 bool preserveSpaces, bool includePeriod)
		{
			//Verify input
			if(input==null)
				return null;
			
			if (input.Equals(string.Empty))
				return string.Empty;

			string[] words = input.Split(' ');

			for (int i = 0; i < words.Length; i++)
			{
				if (words[i].Length > 0)
				{
					if (capitalizeInitials)
						words[i] = char.ToUpper(words[i][0]).ToString(); //only keep the first letter
					else
						words[i] = words[i][0].ToString(); //only keep the first letter

					if (includePeriod)
						words[i] += ".";
				}
			}

			if (preserveSpaces)
				return string.Join(" ", words);
			else
				return string.Join("", words);
		}

		public static string GetInitials(string input, string separator, bool capitalizeInitials, 
		                                 bool preserveSeparator, bool includePeriod)
		{
			//Verify input
			if (string.IsNullOrEmpty(input))
				return string.Empty;

			string[] words = input.Split(separator.ToCharArray());

			for (int i = 0; i < words.Length; i++)
			{
				if (words[i].Length > 0)
				{
					if (capitalizeInitials)
						words[i] = char.ToUpper(words[i][0]).ToString(); //only keep the first letter
					else
						words[i] = words[i][0].ToString(); //only keep the first letter

					if (includePeriod)
						words[i] += ".";
				}
			}

			if (preserveSeparator)
				return string.Join(separator, words);
			else
				return string.Join("", words);	
		}
		
		public static string RemoveVowels(string input)
		{
			//Validate input
			if (string.IsNullOrEmpty(input))
				return string.Empty;

			List<char> outputChars = new List<char>(input.ToCharArray());

			//Iterate backwards to avoid problems from removing characters
			for (int i = outputChars.Count - 1; i >= 0; i--)
			{
				if (outputChars[i] == 'a' || outputChars[i] == 'A' ||
				    outputChars[i] == 'e' || outputChars[i] == 'E' ||
				    outputChars[i] == 'i' || outputChars[i] == 'I' ||
				    outputChars[i] == 'o' || outputChars[i] == 'O' ||
				    outputChars[i] == 'u' || outputChars[i] == 'U')
					
					//not a vowel, remove it
					outputChars.RemoveAt(i);
			}

			return new string(outputChars.ToArray());
		}

		public static string KeepVowels(string input)
		{
			//Validate input
			if (string.IsNullOrEmpty(input))
				return string.Empty;

			List<char> outputChars = new List<char>(input.ToCharArray());

			//Iterate backwards to avoid problems from removing characters
			for (int i = outputChars.Count - 1; i >= 0; i--)
			{
				if (!(outputChars[i] == 'a' || outputChars[i] == 'A' ||
				      outputChars[i] == 'e' || outputChars[i] == 'E' ||
				      outputChars[i] == 'i' || outputChars[i] == 'I' ||
				      outputChars[i] == 'o' || outputChars[i] == 'O' ||
				      outputChars[i] == 'u' || outputChars[i] == 'U'))
					
					//a vowel, remove it
					outputChars.RemoveAt(i);
			}

			return new string(outputChars.ToArray());
		}
		
		public static bool HasVowels(string input)
		{
			//Verify input
			if (string.IsNullOrEmpty(input)) return false;

			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == 'a' || input[i] == 'A' ||
				    input[i] == 'e' || input[i] == 'E' ||
				    input[i] == 'i' || input[i] == 'I' ||
				    input[i] == 'o' || input[i] == 'O' ||
				    input[i] == 'u' || input[i] == 'U')
					return true; //a single vowel makes function true
			}

			return false;
		}
		
		public static string Abbreviate(string input, int lower, int upper, string appendToEnd)
		{
			//initial parameter checks
			if (input==null) 
				return null;
			
			if (input.Equals(string.Empty))
				return string.Empty;

			//if the upper value is -1 (i.e. no limit) or is greater
			//than the length of the string, set to the length of the string
			if (upper == -1 || upper > input.Length)
			{
				upper = input.Length;
			}
			
			//if upper is less than lower, raise it to lower
			if (upper < lower) 
				upper = lower;

			StringBuilder result = new StringBuilder();
			int index = input.IndexOf(" ", lower);
			if (index == -1)
			{
				result.Append(input.Substring(0, upper));
				
				//only if abbreviation has occured do we append the appendToEnd value
				if (upper != input.Length)
				{
					result.Append(StringUtils.DefaultString(appendToEnd));
				}
			}
			else if (index > upper)
			{
				result.Append(input.Substring(0, upper));
				result.Append(StringUtils.DefaultString(appendToEnd));
			}
			else
			{
				result.Append(input.Substring(0, index));
				result.Append(StringUtils.DefaultString(appendToEnd));
			}
			
			return result.ToString();
		}
		
		private static bool IsDelimiter(char ch, char[] delimiters)
		{
			if (delimiters == null)
			{
				return Char.IsWhiteSpace(ch);
			}
			
			for (int i = 0, isize = delimiters.Length; i < isize; i++)
			{
				if (ch == delimiters[i])
				{
					return true;
				}
			}
			
			return false;
		}
		
		public static bool IsCapitalized(string input)
		{
			//Verify input
			if (string.IsNullOrEmpty(input)) 
				return false;

			return char.IsUpper(input[0]);
		}
	}
}
