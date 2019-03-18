using CancerInstitute.Models;
using CancerInstitute.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CancerInstitute.Controllers
{
    [Route("api/[controller]")]
    public class PalindromeController : Controller
    {
        private readonly IPalindromeService _palindromeService;

        public PalindromeController(IPalindromeService palindromeService)
        {
            _palindromeService = palindromeService;
        }

        [HttpGet("[action]")]
        public ApiResult GetPalindromes()
        {
            try
            {
                var palindromes = _palindromeService.GetPalindromes();
                return new ApiResult()
                {
                    data = palindromes,
                    ErrorMessage = "",
                    Success = true
                };
            }
            catch (Exception e)
            {

                return new ApiResult()
                {
                    data = null,
                    ErrorMessage = e.Message,
                    Success = false
                };
            }
        }

        [HttpPost]
        [Route("AddPalindrome")]
        public ApiResult AddPalindrome(Palindrome palindrome)
        {
            try
            {
                var palindromes = _palindromeService.AddPalindrome(palindrome);
                return new ApiResult()
                {
                    data = palindromes,
                    ErrorMessage = "",
                    Success = true
                };
            }
            catch (Exception e)
            {

                return new ApiResult()
                {
                    data = null,
                    ErrorMessage = e.Message,
                    Success = false
                };
            }

        }

    }
}
