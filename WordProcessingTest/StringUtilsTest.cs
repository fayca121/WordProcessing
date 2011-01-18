/*
 * Crée par SharpDevelop.
 * Utilisateur: Bououza
 * Date: 17/01/2011
 * Heure: 10:01
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */

using System;
using NUnit.Framework;
using WordProcessing;

namespace WordProcessingTest
{
	[TestFixture]
	public class StringUtilsTest
	{
		[Test]
		public void IsLettersCheck()
		{
			Assert.False(StringUtils.IsLetters(null));
			Assert.False(StringUtils.IsLetters(""));
			Assert.False(StringUtils.IsLetters(" "));
			Assert.True(StringUtils.IsLetters("a"));
			Assert.True(StringUtils.IsLetters("A"));
			Assert.True(StringUtils.IsLetters("kgKgKgKgkgkGkjkjlJlOKLgHdGdHgl"));
			Assert.False(StringUtils.IsLetters("ham kso"));
			Assert.False(StringUtils.IsLetters("1"));
			Assert.False(StringUtils.IsLetters("hkHKHik6iUGHKJgU7tUJgKJGI87GIkug"));
			Assert.False(StringUtils.IsLetters("_"));
			Assert.False(StringUtils.IsLetters("hkHKHik*khbkuh"));
		}

		[Test]
		public void IsAlphaNumbericCheck()
		{
			Assert.False(StringUtils.IsAlphaNumberic(null));
			Assert.False(StringUtils.IsAlphaNumberic(""));
			Assert.False(StringUtils.IsAlphaNumberic(" "));
			Assert.True(StringUtils.IsAlphaNumberic("a"));
			Assert.True(StringUtils.IsAlphaNumberic("A"));
			Assert.True(StringUtils.IsAlphaNumberic("kgKgKgKgkgkGkjkjlJlOKLgHdGdHgl"));
			Assert.False(StringUtils.IsAlphaNumberic("ham kso"));
			Assert.True(StringUtils.IsAlphaNumberic("1"));
			Assert.True(StringUtils.IsAlphaNumberic("hkHKHik6iUGHKJgU7tUJgKJGI87GIkug"));
			Assert.False(StringUtils.IsAlphaNumberic("_"));
			Assert.False(StringUtils.IsAlphaNumberic("hkHKHik*khbkuh"));
		}

		[Test]
		public void IsNumericCheck()
		{
			Assert.False(StringUtils.IsNumeric(null));
			Assert.False(StringUtils.IsNumeric(""));
			Assert.False(StringUtils.IsNumeric(" "));
			Assert.False(StringUtils.IsNumeric("a"));
			Assert.False(StringUtils.IsNumeric("A"));
			Assert.False(StringUtils.IsNumeric("kgKgKgKgkgkGkjkjlJlOKLgHdGdHgl"));
			Assert.False(StringUtils.IsNumeric("ham kso"));
			Assert.True(StringUtils.IsNumeric("1"));
			Assert.True(StringUtils.IsNumeric("1000"));
			Assert.False(StringUtils.IsNumeric("2.3"));
			Assert.False(StringUtils.IsNumeric("10 00"));
			Assert.False(StringUtils.IsNumeric("hkHKHik6iUGHKJgU7tUJgKJGI87GIkug"));
			Assert.False(StringUtils.IsNumeric("_"));
			Assert.False(StringUtils.IsNumeric("hkHKHik*khbkuh"));
		}
		
		[Test]
		public void IsNumericSpace()
		{
			Assert.False(StringUtils.IsNumericSpace(null));
			Assert.True(StringUtils.IsNumericSpace(""));
			Assert.True(StringUtils.IsNumericSpace(" "));
			Assert.False(StringUtils.IsNumericSpace("a"));
			Assert.False(StringUtils.IsNumericSpace("A"));
			Assert.False(StringUtils.IsNumericSpace("kgKgKgKgkgkGkjkjlJlOKLgHdGdHgl"));
			Assert.False(StringUtils.IsNumericSpace("ham kso"));
			Assert.True(StringUtils.IsNumericSpace("1"));
			Assert.True(StringUtils.IsNumericSpace("1000"));
			Assert.False(StringUtils.IsNumericSpace("2.3"));
			Assert.True(StringUtils.IsNumericSpace("10 00"));
			Assert.False(StringUtils.IsNumericSpace("hkHKHik6iUGHKJgU7tUJgKJGI87GIkug"));
			Assert.False(StringUtils.IsNumericSpace("_"));
			Assert.False(StringUtils.IsNumericSpace("hkHKHik*khbkuh"));
		}

		[Test]
		public void IsSpacesCheck()
		{
			Assert.False(StringUtils.IsSpaces(null));
			Assert.True(StringUtils.IsSpaces(""));
			Assert.True(StringUtils.IsSpaces(" "));
			Assert.True(StringUtils.IsSpaces("\t \n \t"));
			Assert.False(StringUtils.IsSpaces("\t aa\n \t"));
			Assert.True(StringUtils.IsSpaces(" "));
			Assert.False(StringUtils.IsSpaces(" a "));
			Assert.False(StringUtils.IsSpaces("a  "));
			Assert.False(StringUtils.IsSpaces("  a"));
			Assert.False(StringUtils.IsSpaces("aba"));
		}

		[Test]
		public void TrimCheck()
		{
			Assert.AreEqual("foo", StringUtils.Trim("foo" + "  "));
			Assert.AreEqual("foo", StringUtils.Trim(" " + "foo" + "  "));
			Assert.AreEqual("foo", StringUtils.Trim(" " + "foo"));
			Assert.AreEqual("foo", StringUtils.Trim("foo" + ""));
			Assert.IsEmpty("", StringUtils.Trim(" \t\r\n\b "));
			Assert.IsEmpty(StringUtils.Trim(""));
			Assert.Null(StringUtils.Trim(null));
		}

		[Test]
		public void TrimToNullCheck()
		{
			Assert.AreEqual("foo", StringUtils.TrimToNull("foo" + "  "));
			Assert.AreEqual("foo", StringUtils.TrimToNull(" " + "foo" + "  "));
			Assert.AreEqual("foo", StringUtils.TrimToNull(" " + "foo"));
			Assert.AreEqual("foo", StringUtils.TrimToNull("foo" + ""));
			Assert.Null(StringUtils.TrimToNull(" \t\r\n "));
			Assert.Null(StringUtils.TrimToNull(""));
			Assert.Null(StringUtils.TrimToNull(null));
		}

		[Test]
		public void TrimToEmptyCheck()
		{
			Assert.AreEqual("foo", StringUtils.TrimToEmpty("foo" + "  "));
			Assert.AreEqual("foo", StringUtils.TrimToEmpty(" " + "foo" + "  "));
			Assert.AreEqual("foo", StringUtils.TrimToEmpty(" " + "foo"));
			Assert.AreEqual("foo", StringUtils.TrimToEmpty("foo" + ""));
			Assert.AreEqual("", StringUtils.TrimToEmpty(" \t\r\n "));
			Assert.AreEqual("", StringUtils.TrimToEmpty(""));
			Assert.AreEqual("", StringUtils.TrimToEmpty(null));
		}

		[Test]
		public void EqualsIgnoreCaseCheck()
		{
			Assert.True(StringUtils.EqualsIgnoreCase(null, null));
			Assert.True(StringUtils.EqualsIgnoreCase("foo", "foo"));
			Assert.True(StringUtils.EqualsIgnoreCase("foo", new String(new char[] { 'f', 'o', 'o' })));
			Assert.True(StringUtils.EqualsIgnoreCase("foo", new String(new char[] { 'f', 'O', 'O' })));
			Assert.False(StringUtils.EqualsIgnoreCase("foo", "bal"));
			Assert.False(StringUtils.EqualsIgnoreCase("foo", null));
			Assert.False(StringUtils.EqualsIgnoreCase(null, "foo"));
		}

		[Test]
		public void ReverseCheck()
		{
			Assert.Null(StringUtils.Reverse(null));
			Assert.IsEmpty(StringUtils.Reverse(""));
			Assert.AreEqual(" ", StringUtils.Reverse(" "));
			Assert.AreEqual("a", StringUtils.Reverse("a"));
			Assert.AreEqual("oof", StringUtils.Reverse("foo"));
			Assert.AreEqual("lab", StringUtils.Reverse("bal"));
			Assert.AreEqual("oof lab", StringUtils.Reverse("bal foo"));
		}
		
		[Test]
		public void ReverseDelimitedCheck()
		{
			Assert.Null(StringUtils.ReverseDelimited(null, ".") );
			Assert.IsEmpty( StringUtils.ReverseDelimited("", ".") );
			Assert.AreEqual("c.b.a", StringUtils.ReverseDelimited("a.b.c", ".") );
			Assert.AreEqual("a b c", StringUtils.ReverseDelimited("a b c", ".") );
			Assert.AreEqual("", StringUtils.ReverseDelimited("", ".") );
		}
		
		[Test]
		public void IsAsciiPrintableCheck()
		{
			Assert.False(StringUtils.IsAsciiPrintable(null));
			Assert.True(StringUtils.IsAsciiPrintable(""));
			Assert.True(StringUtils.IsAsciiPrintable(" "));
			Assert.True(StringUtils.IsAsciiPrintable("a"));
			Assert.True(StringUtils.IsAsciiPrintable("A"));
			Assert.True(StringUtils.IsAsciiPrintable("1"));
			Assert.True(StringUtils.IsAsciiPrintable("Ceki"));
			Assert.True(StringUtils.IsAsciiPrintable("!ab2c~"));
			Assert.True(StringUtils.IsAsciiPrintable("1000"));
			Assert.True(StringUtils.IsAsciiPrintable("10 00"));
			Assert.False(StringUtils.IsAsciiPrintable("10\t00"));
			Assert.True(StringUtils.IsAsciiPrintable("10.00"));
			Assert.True(StringUtils.IsAsciiPrintable("10,00"));
			Assert.True(StringUtils.IsAsciiPrintable("!ab-c~"));
			Assert.True(StringUtils.IsAsciiPrintable("hkHK=Hik6i?UGH_KJgU7.tUJgKJ*GI87GI,kug"));
			Assert.True(StringUtils.IsAsciiPrintable("\u0020"));
			Assert.True(StringUtils.IsAsciiPrintable("\u0021"));
			Assert.True(StringUtils.IsAsciiPrintable("\u007e"));
			Assert.False(StringUtils.IsAsciiPrintable("\u007f"));
			Assert.True(StringUtils.IsAsciiPrintable("G?lc?"));
			Assert.True(StringUtils.IsAsciiPrintable("=?iso-8859-1?Q?G=FClc=FC?="));
			Assert.False(StringUtils.IsAsciiPrintable("G\u00fclc\u00fc"));
			
		}
		
		[Test]
		public void IndexOfDifference2Check()
		{
			Assert.AreEqual(-1, StringUtils.IndexOfDifference(null, null));
			Assert.AreEqual(0, StringUtils.IndexOfDifference(null, "i am a robot"));
			Assert.AreEqual(-1, StringUtils.IndexOfDifference("", ""));
			Assert.AreEqual(0, StringUtils.IndexOfDifference("", "abc"));
			Assert.AreEqual(0, StringUtils.IndexOfDifference("abc", ""));
			Assert.AreEqual(0, StringUtils.IndexOfDifference("i am a machine", null));
			Assert.AreEqual(7, StringUtils.IndexOfDifference("i am a machine", "i am a robot"));
			Assert.AreEqual(-1, StringUtils.IndexOfDifference("foo", "foo"));
			Assert.AreEqual(0, StringUtils.IndexOfDifference("i am a robot", "you are a robot"));
		}
		
		[Test]
		public void GetCommonPrefixCheck()
		{
			Assert.IsEmpty( StringUtils.GetCommonPrefix(null));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {}));
			Assert.AreEqual("abc", StringUtils.GetCommonPrefix(new String[] {"abc"}));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {null, null}));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {"", ""}));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {"", null}));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {"abc", null, null}));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {null, null, "abc"}));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {"", "abc"}));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {"abc", ""}));
			Assert.AreEqual("abc", StringUtils.GetCommonPrefix(new String[] {"abc", "abc"}));
			Assert.AreEqual("a", StringUtils.GetCommonPrefix(new String[] {"abc", "a"}));
			Assert.AreEqual("ab", StringUtils.GetCommonPrefix(new String[] {"ab", "abxyz"}));
			Assert.AreEqual("ab", StringUtils.GetCommonPrefix(new String[] {"abcde", "abxyz"}));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {"abcde", "xyz"}));
			Assert.IsEmpty( StringUtils.GetCommonPrefix(new String[] {"xyz", "abcde"}));
			Assert.AreEqual("i am a ", StringUtils.GetCommonPrefix(new String[] {"i am a machine", "i am a robot"}));
		}
		
		[Test]
		public void DifferenceCheck()
		{
			Assert.Null(StringUtils.Difference(null, null));
			Assert.IsEmpty(StringUtils.Difference("", ""));
			Assert.AreEqual("abc", StringUtils.Difference("", "abc"));
			Assert.IsEmpty(StringUtils.Difference("abc", ""));
			Assert.AreEqual("i am a robot", StringUtils.Difference(null, "i am a robot"));
			Assert.AreEqual("i am a machine", StringUtils.Difference("i am a machine", null));
			Assert.AreEqual("robot", StringUtils.Difference("i am a machine", "i am a robot"));
			Assert.IsEmpty(StringUtils.Difference("abc", "abc"));
			Assert.AreEqual("you are a robot", StringUtils.Difference("i am a robot", "you are a robot"));
		}
		
		[Test]
		public void IndexOfDifferenceCheck()
		{
			Assert.AreEqual(-1, StringUtils.IndexOfDifference(null));
			Assert.AreEqual(-1, StringUtils.IndexOfDifference(new String[] {}));
			Assert.AreEqual(-1, StringUtils.IndexOfDifference(new String[] {"abc"}));
			Assert.AreEqual(-1, StringUtils.IndexOfDifference(new String[] {null, null}));
			Assert.AreEqual(-1, StringUtils.IndexOfDifference(new String[] {"", ""}));
			Assert.AreEqual(0, StringUtils.IndexOfDifference(new String[] {"", null}));
			Assert.AreEqual(0, StringUtils.IndexOfDifference(new String[] {"abc", null, null}));
			Assert.AreEqual(0, StringUtils.IndexOfDifference(new String[] {null, null, "abc"}));
			Assert.AreEqual(0, StringUtils.IndexOfDifference(new String[] {"", "abc"}));
			Assert.AreEqual(0, StringUtils.IndexOfDifference(new String[] {"abc", ""}));
			Assert.AreEqual(-1, StringUtils.IndexOfDifference(new String[] {"abc", "abc"}));
			Assert.AreEqual(1, StringUtils.IndexOfDifference(new String[] {"abc", "a"}));
			Assert.AreEqual(2, StringUtils.IndexOfDifference(new String[] {"ab", "abxyz"}));
			Assert.AreEqual(2, StringUtils.IndexOfDifference(new String[] {"abcde", "abxyz"}));
			Assert.AreEqual(0, StringUtils.IndexOfDifference(new String[] {"abcde", "xyz"}));
			Assert.AreEqual(0, StringUtils.IndexOfDifference(new String[] {"xyz", "abcde"}));
			Assert.AreEqual(7, StringUtils.IndexOfDifference(new String[] {"i am a machine", "i am a robot"}));
		}
		
		[Test]
		public void RemoveCharCheck()
		{
			Assert.Null(StringUtils.RemoveChar(null, 'a'));
			Assert.Null(StringUtils.RemoveChar(null, 'a'));
			Assert.Null(StringUtils.RemoveChar(null, 'a'));
			
			// StringUtils.Remove("", *)          = ""
			Assert.IsEmpty(StringUtils.RemoveChar("", 'a'));
			Assert.IsEmpty(StringUtils.RemoveChar("", 'a'));
			Assert.IsEmpty(StringUtils.RemoveChar("", 'a'));
			
			// StringUtils.Remove("queued", 'u') = "qeed"
			Assert.AreEqual("qeed", StringUtils.RemoveChar("queued", 'u'));
			
			// StringUtils.Remove("queued", 'z') = "queued"
			Assert.AreEqual("queued", StringUtils.RemoveChar("queued", 'z'));
		}
		
		[Test]
		public void RemoveStringCheck()
		{
			Assert.Null(StringUtils.RemoveString(null, null));
			Assert.Null(StringUtils.RemoveString(null, ""));
			Assert.Null(StringUtils.RemoveString(null, "a"));
			Assert.IsEmpty(StringUtils.RemoveString("", null));
			Assert.IsEmpty(StringUtils.RemoveString("", ""));
			Assert.IsEmpty(StringUtils.RemoveString("", "a"));
			Assert.AreEqual("a", StringUtils.RemoveString("a", null));
			Assert.AreEqual("a", StringUtils.RemoveString("a", ""));
			Assert.AreEqual("qd", StringUtils.RemoveString("queued", "ue"));
			Assert.AreEqual("queued", StringUtils.RemoveString("queued", "zz"));
		}
		
		[Test]
		public void RemoveNumericCheck()
		{
			Assert.Null(StringUtils.RemoveNumeric(null));
			Assert.IsEmpty(StringUtils.RemoveNumeric(""));
			Assert.IsEmpty(StringUtils.RemoveNumeric("124"));
			Assert.AreEqual("abc",StringUtils.RemoveNumeric("1a2b4c"));
			Assert.AreEqual("abc",StringUtils.RemoveNumeric("abc"));
			Assert.AreEqual("*_*",StringUtils.RemoveNumeric("*_*"));
		}
		
		[Test]
		public void RemoveLettersCheck()
		{
			Assert.Null(StringUtils.RemoveLetters(null));
			Assert.IsEmpty(StringUtils.RemoveLetters(""));
			Assert.AreEqual("124",StringUtils.RemoveLetters("124"));
			Assert.AreEqual("124",StringUtils.RemoveLetters("1a2b4c"));
			Assert.IsEmpty(StringUtils.RemoveLetters("abc"));
			Assert.AreEqual("*_*",StringUtils.RemoveLetters("*_*"));
		}
		
		[Test]
		public void IsPalaindromCheck()
		{
			Assert.False(StringUtils.IsPalaindrom(null));
			Assert.True(StringUtils.IsPalaindrom(""));
			Assert.True(StringUtils.IsPalaindrom("a"));
			Assert.True(StringUtils.IsPalaindrom("aaa"));
			Assert.True(StringUtils.IsPalaindrom("abba"));
			Assert.True(StringUtils.IsPalaindrom("abcba"));
			Assert.True(StringUtils.IsPalaindrom("a a"));
			Assert.False(StringUtils.IsPalaindrom("ab"));
			Assert.False(StringUtils.IsPalaindrom("123 1"));
		}
	}
}
