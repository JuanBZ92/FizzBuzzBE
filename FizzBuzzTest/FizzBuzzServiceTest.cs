using FizzBuzz.Models;
using FizzBuzz.Services;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework.Internal;

namespace FizzBuzzTest
{
    [TestFixture]
    public class FizzBuzzTest
    {

        private IFizzBuzzService _fizzBuzzService = null!;
        private Mock<ILogger<FizzBuzzService>> _logger = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _logger = new Mock<ILogger<FizzBuzzService>>();
        }

        [SetUp]
        public void Setup()
        {
            _fizzBuzzService = new FizzBuzzService(_logger.Object);
        }

        [Test]
        public void CreateFizzBuzzListTest()
        {
            FizzBuzzRequest request = new FizzBuzzRequest()
            {
                FirstNumber = 10,
                Limit = 15
            };

            var result = _fizzBuzzService.CreateFizzBuzzList(request);

            var fizzBuzzList = new List<string>()
            {
                "Buzz",
                "11",
                "Fizz",
                "13",
                "14",
                "FizzBuzze"
            };

            var expectedResult = new FizzBuzzResponse(request, fizzBuzzList);
            expectedResult.DateTimeSignature = result.DateTimeSignature;
            expectedResult.RandomNumber = result.RandomNumber;

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void CreateFizzBuzzFile()
        {
            FizzBuzzRequest request = new FizzBuzzRequest()
            {
                FirstNumber = 10,
                Limit = 15
            };

            var fizzBuzzList = new List<string>()
            {
                "Buzz",
                "11",
                "Fizz",
                "13",
                "14",
                "FizzBuzz"
            };
            var expectedResult = new FizzBuzzResponse(request, fizzBuzzList);

            string path = _fizzBuzzService.CreateFolderAndPath(expectedResult);

            _fizzBuzzService.CreateFizzBuzzFile(expectedResult);

            Assert.IsTrue(File.Exists(path));

            File.Delete(path);
        }
    }
}
