using System;
using Cielo.Extensions;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void ToNumbers_ShouldReturnOnlyNumbersInGivenString()
        {
            string test = "A1B6C6DE9FG";
            test.ToNumbers().Should().Be("1669");
        }

        [Test]
        public void ToMaxLength_ShouldCutStringByGivenLength()
        {
            string test = "abcdefghijklmopqrstuvxyz";
            test.ToMaxLength(7).Should().Be("abcdefg");
        }

        [Test]
        public void RegexReplace_ShouldReplaceValueByGivenRegexPatten()
        {
            string test = "A1B6C6DE9FG";
            test.RegexReplace("[0-9]*", String.Empty ).Should().Be("ABCDEFG");
        }
    }
}
