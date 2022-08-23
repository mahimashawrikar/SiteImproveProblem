using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SearchNumbersWebApplication.Repository
{
    public interface IGetNumbers
    {

        Task<string> GetAllNumbers();
        
    }
}
