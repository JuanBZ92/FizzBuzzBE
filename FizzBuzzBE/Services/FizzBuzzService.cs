using FizzBuzz.Controllers;
using FizzBuzz.Models;

namespace FizzBuzz.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly ILogger<FizzBuzzService> _logger;

        public FizzBuzzService(ILogger<FizzBuzzService> logger)
        {
            _logger = logger;
        }
        public FizzBuzzResponse CreateFizzBuzzList(FizzBuzzRequest request)
        {

            try
            {
                _logger.LogInformation($"First Number :: {request.FirstNumber}");
                _logger.LogInformation($"Limit :: {request.Limit}");

                var fizzBuzzList = new List<string>();
                for (int number = request.FirstNumber; number <= request.Limit; number++)
                {
                    if (number % 3 == 0 && number % 5 == 0)
                    {
                        fizzBuzzList.Add("FizzBuzz");
                    }
                    else if (number % 3 == 0)
                    {
                        fizzBuzzList.Add("Fizz");
                    }
                    else if (number % 5 == 0)
                    {
                        fizzBuzzList.Add("Buzz");
                    }
                    else
                    {
                        fizzBuzzList.Add(number.ToString());
                    }
                }

                var result = new FizzBuzzResponse(request, fizzBuzzList);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateFizzBuzzFile(FizzBuzzResponse fizzBuzzResponse)
        {
            try
            {
                _logger.LogInformation($"Creating file for fizzBuzzList with {fizzBuzzResponse.FizzBuzzList.Count} rows");

                var filePath = CreateFolderAndPath(fizzBuzzResponse);

                // Write the lines to the file
                await File.WriteAllLinesAsync(filePath, fizzBuzzResponse.FizzBuzzList);

                _logger.LogInformation($"File created");
            }
            catch
            {
                throw;
            }

        }

        private string CreateFolderAndPath(FizzBuzzResponse fizzBuzzResponse)
        {
            string filePath = String.Empty;
            string folderName = "FizzBuzzFiles";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                string macOsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), folderName);
                if (!System.IO.Directory.Exists(macOsPath))
                {
                    System.IO.Directory.CreateDirectory(macOsPath);
                }
                //Random number generated to handle concurrency.
                filePath = $@"{macOsPath}/fizzBuzzList-{fizzBuzzResponse.DateTimeSignature:yyyyMMddhhmmssfff}-{fizzBuzzResponse.RandomNumber}.txt";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (!System.IO.Directory.Exists($"C:\\{folderName}"))
                {
                    System.IO.Directory.CreateDirectory($"C:\\{folderName}");
                }
                //Random number generated to handle concurrency.
                filePath = $@"C:\FizzBuzzFiles\fizzBuzzList-{fizzBuzzResponse.DateTimeSignature:yyyyMMddhhmmssfff}-{fizzBuzzResponse.RandomNumber}.txt";
            }

            return filePath;
        }

    }
}
