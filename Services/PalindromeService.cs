using CancerInstitute.Models;
using CancerInstitute.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CancerInstitute.Services
{
    
    public interface IPalindromeService
    {
        List<Palindrome> GetPalindromes();
        bool AddPalindrome(Palindrome palindrome);        
    }
    public class PalindromeService : IPalindromeService
    {
        
        private readonly IPalindromeRepository _callRepo;

        public PalindromeService(IPalindromeRepository callRepo)
        {
            _callRepo = callRepo;
        }

        public bool AddPalindrome(Palindrome palindrome)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");            
            string myString= rgx.Replace(palindrome.PalindromeText, "");
            string first = myString.Substring(0, myString.Length / 2);
            char[] arr = myString.ToCharArray();

            Array.Reverse(arr);

            string temp = new string(arr);
            string second = temp.Substring(0, temp.Length / 2);

            if (first.ToLower().Equals(second.ToLower()))
                return _callRepo.AddPalindrome(palindrome);
            else
                throw new Exception("Not Palindrome");
        }

        public List<Palindrome> GetPalindromes()
        {
            return _callRepo.GetPalindromes();
        }
    }
}
namespace CancerInstitute.Models
{
    public class Palindrome
    {
        public int ID { get; set; }
        public string PalindromeText { get; set; }
    }
    public class ApiResult
    {
        public bool Success { get; set; }

        public object data { get; set; }
        public string ErrorMessage { get; set; }

    }
}
