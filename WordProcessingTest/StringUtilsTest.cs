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
    }
}
