/*
 * Crée par SharpDevelop.
 * Utilisateur: Bououza
 * Date: 17/01/2011
 * Heure: 12:53
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
 
using System;
using NUnit.Framework;
using WordProcessing;

namespace WordProcessingTest
{
	[TestFixture]
	public class WordUtilsTest
	{
		[Test]
		public void CapitalizeCheck()
		{
			Assert.Null(WordUtils.Capitalize(null));
			Assert.AreEqual("", WordUtils.Capitalize(""));
			Assert.AreEqual("  ", WordUtils.Capitalize("  "));
			Assert.AreEqual("I", WordUtils.Capitalize("I") );
			Assert.AreEqual("I", WordUtils.Capitalize("i") );
			Assert.AreEqual("I Am Here 123", WordUtils.Capitalize("i am here 123") );
			Assert.AreEqual("I Am Here 123", WordUtils.Capitalize("I Am Here 123") );
			Assert.AreEqual("I Am HERE 123", WordUtils.Capitalize("i am HERE 123") );
			Assert.AreEqual("I AM HERE 123", WordUtils.Capitalize("I AM HERE 123") );
		}
		
		[Test]
		public void CapitalizeWithDelimitersCheck()
		{
			Assert.Null(WordUtils.Capitalize(null, null));
			Assert.AreEqual("", WordUtils.Capitalize("", new char[0]));
			Assert.AreEqual("  ", WordUtils.Capitalize("  ", new char[0]));
			
			char[] chars = new char[] { '-', '+', ' ', '@' };
			Assert.AreEqual("I", WordUtils.Capitalize("I", chars) );
			Assert.AreEqual("I", WordUtils.Capitalize("i", chars) );
			Assert.AreEqual("I-Am Here+123", WordUtils.Capitalize("i-am here+123", chars) );
			Assert.AreEqual("I Am+Here-123", WordUtils.Capitalize("I Am+Here-123", chars) );
			Assert.AreEqual("I+Am-HERE 123", WordUtils.Capitalize("i+am-HERE 123", chars) );
			Assert.AreEqual("I-AM HERE+123", WordUtils.Capitalize("I-AM HERE+123", chars) );
			chars = new char[] {'.'};
			Assert.AreEqual("I aM.Fine", WordUtils.Capitalize("i aM.fine", chars) );
			Assert.AreEqual("I Am.fine", WordUtils.Capitalize("i am.fine", null) );
		}
		
		[Test]
		public void CapitalizeFullyCheck()
		{
			Assert.Null(WordUtils.CapitalizeFully(null));
			Assert.AreEqual("", WordUtils.CapitalizeFully(""));
			Assert.AreEqual("  ", WordUtils.CapitalizeFully("  "));
			Assert.AreEqual("I", WordUtils.CapitalizeFully("I") );
			Assert.AreEqual("I", WordUtils.CapitalizeFully("i") );
			Assert.AreEqual("I Am Here 123", WordUtils.CapitalizeFully("i am here 123") );
			Assert.AreEqual("I Am Here 123", WordUtils.CapitalizeFully("I Am Here 123") );
			Assert.AreEqual("I Am Here 123", WordUtils.CapitalizeFully("i am HERE 123") );
			Assert.AreEqual("I Am Here 123", WordUtils.CapitalizeFully("I AM HERE 123") );
		}
		
		[Test]
		public void CapitalizeFullyWithDelimitersCheck()
		{
			Assert.Null(WordUtils.CapitalizeFully(null, null));
			Assert.AreEqual("", WordUtils.CapitalizeFully("", new char[0]));
			Assert.AreEqual("  ", WordUtils.CapitalizeFully("  ", new char[0]));
			
			char[] chars = new char[] { '-', '+', ' ', '@' };
			Assert.AreEqual("I", WordUtils.CapitalizeFully("I", chars) );
			Assert.AreEqual("I", WordUtils.CapitalizeFully("i", chars) );
			Assert.AreEqual("I-Am Here+123", WordUtils.CapitalizeFully("i-am here+123", chars) );
			Assert.AreEqual("I Am+Here-123", WordUtils.CapitalizeFully("I Am+Here-123", chars) );
			Assert.AreEqual("I+Am-Here 123", WordUtils.CapitalizeFully("i+am-HERE 123", chars) );
			Assert.AreEqual("I-Am Here+123", WordUtils.CapitalizeFully("I-AM HERE+123", chars) );
			chars = new char[] {'.'};
			Assert.AreEqual("I am.Fine", WordUtils.CapitalizeFully("i aM.fine", chars) );
			Assert.AreEqual("I Am.fine", WordUtils.CapitalizeFully("i am.fine", null) );
		}
		
		[Test]
		public void UncapitalizeCheck()
		{
			Assert.Null(WordUtils.Uncapitalize(null));
			Assert.AreEqual("", WordUtils.Uncapitalize(""));
			Assert.AreEqual("  ", WordUtils.Uncapitalize("  "));
			Assert.AreEqual("i", WordUtils.Uncapitalize("I") );
			Assert.AreEqual("i", WordUtils.Uncapitalize("i") );
			Assert.AreEqual("i am here 123", WordUtils.Uncapitalize("i am here 123") );
			Assert.AreEqual("i am here 123", WordUtils.Uncapitalize("I Am Here 123") );
			Assert.AreEqual("i am hERE 123", WordUtils.Uncapitalize("i am HERE 123") );
			Assert.AreEqual("i aM hERE 123", WordUtils.Uncapitalize("I AM HERE 123") );
		}
		
		[Test]
		public void UncapitalizeWithDelimitersCheck()
		{
			Assert.Null(WordUtils.Uncapitalize(null, null));
			Assert.AreEqual("", WordUtils.Uncapitalize("", new char[0]));
			Assert.AreEqual("  ", WordUtils.Uncapitalize("  ", new char[0]));
			
			char[] chars = new char[] { '-', '+', ' ', '@' };
			Assert.AreEqual("i", WordUtils.Uncapitalize("I", chars) );
			Assert.AreEqual("i", WordUtils.Uncapitalize("i", chars) );
			Assert.AreEqual("i am-here+123", WordUtils.Uncapitalize("i am-here+123", chars) );
			Assert.AreEqual("i+am here-123", WordUtils.Uncapitalize("I+Am Here-123", chars) );
			Assert.AreEqual("i-am+hERE 123", WordUtils.Uncapitalize("i-am+HERE 123", chars) );
			Assert.AreEqual("i aM-hERE+123", WordUtils.Uncapitalize("I AM-HERE+123", chars) );
			chars = new char[] {'.'};
			Assert.AreEqual("i AM.fINE", WordUtils.Uncapitalize("I AM.FINE", chars) );
			Assert.AreEqual("i aM.FINE", WordUtils.Uncapitalize("I AM.FINE", null) );
		}
		
		[Test]
		public void SwapCasesCheck()
		{
			Assert.Null(WordUtils.SwapCases(null));
			Assert.IsEmpty(WordUtils.SwapCases(""));
			Assert.AreEqual("  ", WordUtils.SwapCases("  "));
			Assert.AreEqual("i", WordUtils.SwapCases("I") );
			Assert.AreEqual("I", WordUtils.SwapCases("i") );
			Assert.AreEqual("I AM HERE 123", WordUtils.SwapCases("i am here 123") );
			Assert.AreEqual("i aM hERE 123", WordUtils.SwapCases("I Am Here 123") );
			Assert.AreEqual("I AM here 123", WordUtils.SwapCases("i am HERE 123") );
			Assert.AreEqual("i am here 123", WordUtils.SwapCases("I AM HERE 123") );

			String test = "This String contains a TitleCase character:";
			String expect = "tHIS sTRING CONTAINS A tITLEcASE CHARACTER:";
			Assert.AreEqual(expect, WordUtils.SwapCases(test));
		}
		
		[Test]
		public void GetInitialsCheck()
		{
			Assert.Null(WordUtils.GetInitials(null, false, false, false));
			Assert.AreEqual("", WordUtils.GetInitials("", false, false, false));
			Assert.AreEqual("", WordUtils.GetInitials("", true, true, true));
			Assert.AreEqual("", WordUtils.GetInitials("  ",false, false, false));
			Assert.AreEqual("  ", WordUtils.GetInitials("  ",false, true, false));
			Assert.AreEqual("I", WordUtils.GetInitials("I",true,false,false));
			Assert.AreEqual("i", WordUtils.GetInitials("i",false,false,false));
			Assert.AreEqual("BJL", WordUtils.GetInitials("Ben John Lee",true, false, false));
			Assert.AreEqual("BJL", WordUtils.GetInitials("ben john lee",true, false, false));
			Assert.AreEqual("B J L", WordUtils.GetInitials("Ben John Lee",true,true,false));
			Assert.AreEqual("BJ", WordUtils.GetInitials("Ben J.Lee",true,false,false));
			Assert.AreEqual("BJ.L", WordUtils.GetInitials(" Ben   John  . Lee",false ,false, false));
			Assert.AreEqual("iah1", WordUtils.GetInitials("i am here 123",false,false,false));
		}
		
		[Test]
		[Ignore("problem found in this method")]
		public void AbbreviateCheck()
		{
			// check null and empty are returned respectively
			Assert.Null(WordUtils.Abbreviate(null, 1,-1,""));
			Assert.IsEmpty(WordUtils.Abbreviate("", 1,-1,""));
			
			// test upper limit
			Assert.AreEqual("01234", WordUtils.Abbreviate("0123456789", 0,5,""));
			Assert.AreEqual("01234", WordUtils.Abbreviate("0123456789", 5, 2,""));
			Assert.AreEqual("012", WordUtils.Abbreviate("012 3456789", 2, 5,""));
			Assert.AreEqual("012 3", WordUtils.Abbreviate("012 3456789", 5, 2,""));
			Assert.AreEqual("0123456789", WordUtils.Abbreviate("0123456789", 0,-1,""));

			// test upper limit + append string
			Assert.AreEqual("01234-", WordUtils.Abbreviate("0123456789", 0,5,"-"));
			Assert.AreEqual("01234-", WordUtils.Abbreviate("0123456789", 5, 2,"-"));
			Assert.AreEqual("012", WordUtils.Abbreviate("012 3456789", 2, 5, null));
			Assert.AreEqual("012 3", WordUtils.Abbreviate("012 3456789", 5, 2,""));
			Assert.AreEqual("0123456789", WordUtils.Abbreviate("0123456789", 0,-1,""));

			// test lower value
			Assert.AreEqual("012", WordUtils.Abbreviate("012 3456789", 0,5, null));
			Assert.AreEqual("01234", WordUtils.Abbreviate("01234 56789", 5, 10, null));
			Assert.AreEqual("01 23 45 67", WordUtils.Abbreviate("01 23 45 67 89", 9, -1, null));
			Assert.AreEqual("01 23 45 6", WordUtils.Abbreviate("01 23 45 67 89", 9, 10, null));
			Assert.AreEqual("0123456789", WordUtils.Abbreviate("0123456789", 15, 20, null));

			// test lower value + append
			Assert.AreEqual("012", WordUtils.Abbreviate("012 3456789", 0,5, null));
			Assert.AreEqual("01234-", WordUtils.Abbreviate("01234 56789", 5, 10, "-"));
			Assert.AreEqual("01 23 45 67abc", WordUtils.Abbreviate("01 23 45 67 89", 9, -1, "abc"));
			Assert.AreEqual("01 23 45 6", WordUtils.Abbreviate("01 23 45 67 89", 9, 10, ""));

			// others
			Assert.AreEqual("", WordUtils.Abbreviate("0123456790", 0,0,""));
			Assert.AreEqual("", WordUtils.Abbreviate(" 0123456790", 0,-1,""));
		}
	}
}
