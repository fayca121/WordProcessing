using System;
using System.Collections.Generic;

namespace WordProcessing
{
    public class StringUtils
    {
        public const string EMPTY = "";

        public const int INDEX_NOT_FOUND = -1;
        
        public static string DefaultString(string input) 
        {
        	return string.IsNullOrEmpty(input) ? string.Empty : input;
        }
        
        public static string Reverse(string input)
        {
            //Validate input
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            char[] outputChars = input.ToCharArray();

            //Reverse
            Array.Reverse(outputChars);

            //build a string from the processed characters and return it
            return new string(outputChars);
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

        public static string Trim(string str)
        {
            return str == null ? null : str.Trim();
        }

        public static string TrimToNull(string str)
        {
            string ts = Trim(str);
            return string.IsNullOrEmpty(str) ? null : ts;
        }

        public static string TrimToEmpty(string str)
        {
            return str == null ? EMPTY : str.Trim();
        }

        public static bool EqualsIgnoreCase(string str1, string str2)
        {
            return str1 == null ? str2 == null : str1.ToLower().Equals(str2.ToLower());
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

        public static bool IsCapitalized(string input)
        {
            //Verify input
            if (string.IsNullOrEmpty(input)) return false;

            return char.IsUpper(input[0]);
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

        public static bool IsSpaces(string input)
        {
            return string.IsNullOrEmpty(input) || input.Replace(" ", "").Length == 0;
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

        public static bool IsEmailAddress(string input)
        {
            //Validate input
            if (string.IsNullOrEmpty(input))
                return false;

            if (input.IndexOf('@') != -1 &&
                input.Length >= 5) //any email address will be at least 5 characters (a@a.a)
            {
                int indexOfDot = input.LastIndexOf('.');
                if (indexOfDot > input.IndexOf('@')) //last period must be after the @ 
                    return true;
            }

            return false;
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
            
            } while (foundPos > -1);
            
            return (occurrences.ToArray());
        }

        public static int[] IndexOfAll(string input, char matchChar)
        {
            return (IndexOfAll(input, matchChar, -1, false));
        }

        public static int[] IndexOfAll(string input, char matchChar, int maxMatches)
        {
            return (IndexOfAll(input, matchChar, maxMatches, false));
        }

        public static int[] IndexOfAll(string input, char matchChar, bool ignoreCase)
        {
            return (IndexOfAll(input, matchChar, -1, ignoreCase));
        }

    }
}
