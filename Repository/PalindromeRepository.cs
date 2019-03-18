using CancerInstitute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CancerInstitute.Repository
{
    public interface IPalindromeRepository
    {
        List<Palindrome> GetPalindromes();
        bool AddPalindrome(Palindrome palindrome);
    }
    public class PalindromeRepository : IPalindromeRepository
    {
        public bool AddPalindrome(Palindrome palindrome)
        {
            using (var context = new CancerDBContext())
            {
                context.Palindromes.Add(palindrome);
                context.SaveChanges();
            }
            return true;
        }

        public List<Palindrome> GetPalindromes()
        {
            using (var context = new CancerDBContext())
            {
                return context.Palindromes.ToList();
            }
             
        }
    }
}
