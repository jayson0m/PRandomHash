using Microsoft.AspNetCore.Mvc;
using PRandomHash.Models;

namespace PRandomHash.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string word1, string word2, int limit = 10)
        {
            
            PRHash HashCode = new PRHash();
            HashCode = HashCode.GetHash(word1, word2, limit);
            
            
            // return the hash as tempdata 
            TempData["hash"] = HashCode.output;

            // dev reasons
            TempData["word1"] = word1;
            TempData["word2"] = word2;
            TempData["dev"] = HashCode.devword1; 
            TempData["dev1"] = HashCode.devword2;
            TempData["devout"] = HashCode.devoutput;
            
            return View(); 
        }

    }
}