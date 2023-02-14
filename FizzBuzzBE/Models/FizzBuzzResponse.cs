namespace FizzBuzz.Models
{
    public class FizzBuzzResponse
    {
        public FizzBuzzResponse(FizzBuzzRequest request, List<string> fizzBuzzList) 
        {
            Random random= new Random();
            FirstNumber = request.FirstNumber;
            Limit= request.Limit;
            FizzBuzzList = fizzBuzzList;
            DateTimeSignature = DateTime.UtcNow;
            RandomNumber = random.Next();
        }

        public int FirstNumber { get; set; }

        public int Limit { get; set; }

        public List<string> FizzBuzzList { get; set; } = new List<string>();

        public DateTime DateTimeSignature { get; set; } = DateTime.UtcNow;

        public long RandomNumber { get; set; }
    }
}
