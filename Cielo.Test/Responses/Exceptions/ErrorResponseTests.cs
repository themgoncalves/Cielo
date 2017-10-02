using Cielo.Responses.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test.Responses.Exceptions
{
    [TestFixture]
    public class ErrorResponseTests
    {
        [Test]
        public void ErrorResponse_ShouldNotHaveIdAndMessage()
        {
            var errorResponse = new ErrorResponse("", System.Net.HttpStatusCode.NotFound);

            errorResponse.Should().NotBeNull();
            errorResponse.HttpStatusCode.Should().Equals(System.Net.HttpStatusCode.NotFound);
            errorResponse.Id.Should().BeNullOrEmpty();
            errorResponse.Message.Should().BeNullOrEmpty();
        }

        [Test]
        public void ErrorResponse_ShouldHaveIdAndMessage()
        {
            string jsonContent = @"[{ Code: '001', Message: 'Error Message'}]";

            var errorResponse = new ErrorResponse(jsonContent, System.Net.HttpStatusCode.NotFound);

            errorResponse.Should().NotBeNull();
            errorResponse.HttpStatusCode.Should().Equals(System.Net.HttpStatusCode.NotFound);
            errorResponse.Id.Should().BeOfType(typeof(string)).And.Equals("001");
            errorResponse.Message.Should().BeOfType(typeof(string)).And.Equals("Error Message");
        }
    }
}
