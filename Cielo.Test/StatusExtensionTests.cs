using Cielo.Extensions;
using Cielo.Enums;
using FluentAssertions;
using NUnit.Framework;
namespace Cielo.Test
{
    [TestFixture]
    public class StatusExtensionTests
    {
        [TestCase("0", Status.NotFinished)]
        [TestCase("1", Status.Authorized)]
        [TestCase("2", Status.PaymentConfirmed)]
        [TestCase("3", Status.Denied)]
        [TestCase("10", Status.Voided)]
        [TestCase("11", Status.Refunded)]
        [TestCase("12", Status.Pending)]
        [TestCase("13", Status.Aborted)]
        [TestCase("20", Status.Scheduled)]
        public void GiveAStringCode_ShouldConvertIntoExpectedStatus(string statusCode, Status statusExpected)
        {
            statusCode.ToEnum<Status>().Should().Be(statusExpected);
        }
    }
}
