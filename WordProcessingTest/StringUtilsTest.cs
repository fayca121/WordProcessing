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
		
		
	}
}
