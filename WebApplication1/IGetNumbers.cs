using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SearchNumbers.Repository
{
    public interface IGetNumbers
    {

        Task<string> GetAllNumbers();
        
    }
}
