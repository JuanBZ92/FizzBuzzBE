using FizzBuzz.Models;

namespace FizzBuzz.Services
{
    public interface IFizzBuzzService
    {
        FizzBuzzResponse CreateFizzBuzzList(FizzBuzzRequest request);

        Task CreateFizzBuzzFile(FizzBuzzResponse fizzBuzzResponse);
        
        string CreateFolderAndPath(FizzBuzzResponse fizzBuzzResponse);
    }
}
