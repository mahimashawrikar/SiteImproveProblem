using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SearchNumbers.Repository;
using System.Diagnostics;

namespace SearchNumbers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetNumbers : Controller
    {
        private IGetNumbers _mo;

        public GetNumbers(IGetNumbers mo)
        {
            _mo = mo;

        }



        [HttpGet("GetAllNumbers")]
        public async Task<IActionResult> GetAllNumbers()
        {
            try
            {
                

                string allNumbers = string.Empty;
                //calling Method from respository
                allNumbers = await _mo.GetAllNumbers();
                              
                if (String.IsNullOrWhiteSpace(allNumbers))
                    ViewBag.AllNumbers = "No Number Found for given pattern";
                else
                    ViewBag.AllNumbers = allNumbers.TrimEnd(new char[] { ',' }); //removing last ',' from number


                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred with a message: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }


    }
}
