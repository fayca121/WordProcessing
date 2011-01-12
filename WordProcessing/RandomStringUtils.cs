/*
 * Crée par SharpDevelop.
 * Utilisateur: Bououza
 * Date: 12/01/2011
 * Heure: 09:51
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace WordUtils
{
	/// <summary>
	/// Description of RandomStringUtils.
	/// </summary>
	public class RandomStringUtils
	{
		private const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
        private const string NUMBERS = "0123456789";
        private const string SYMBOLS = @"~`!@#$%^&*()-_=+<>?:,./\[]{}|'";
        private static Random RANDOM = new Random();
        
        public static string RandomAlphabetic(int length) 
        {
        	return NextString(length,true,true,false,false);
        }
        
        public static string RandomAlphanumeric(int length)
        {
        	return NextString(length,true,true,true,false);
        }
        
        public static string NextString(int length, bool lowerCase, bool upperCase, bool numbers, bool symbols)
        {
            char[] charArray = new char[length];
            string charPool = string.Empty;

            //Build character pool
            if (lowerCase)
                charPool += LOWERCASE;

            if (upperCase)
                charPool += UPPERCASE;

            if (numbers)
                charPool += NUMBERS;

            if (symbols)
                charPool += SYMBOLS;

            //Build the output character array
            for (int i = 0; i < charArray.Length; i++)
            {
                //Pick a random integer in the character pool
                int index = RANDOM.Next(0, charPool.Length);

                //Set it to the output character array
                charArray[i] = charPool[index];
            }

            return new string(charArray);
        }
		
	}
}
