using Cielo.Responses.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace Cielo.Test.Responses.Exceptions
{
    [TestFixture]
    public class ResponseExceptionTests
    {
        [Test]
        public void ResponseException_ShouldHaveCustomError()
        {
            var errorResponse = new ErrorResponse("", System.Net.HttpStatusCode.NotFound);
            var responseException = new ResponseException(errorResponse);

            responseException.Should().NotBeNull();
            responseException.ResponseError.Should().NotBeNull();
        }

        [Test]
        public void ResponseException_ShouldNotHaveCustomError()
        {
            var responseException = new ResponseException("Response Error Message", new System.Exception());

            responseException.Should().NotBeNull();
            responseException.Message.Should().NotBeNullOrWhiteSpace().And.Should().Equals("Response Error Message");
            responseException.InnerException.Should().NotBeNull();
            responseException.ResponseError.Should().BeNull();
        }
    }
}
