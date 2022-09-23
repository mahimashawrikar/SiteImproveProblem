using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SearchNumbers.Repository
{
    public class GetNumbersRepository : IGetNumbers
    {

        public IConfiguration _configuration;


        public GetNumbersRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public Task<string> GetAllNumbers()
        {
            //To read from appsettings.json
            string connection = _configuration.GetValue<string>("MatchApi:BaseAdressFile");
            string pattern = _configuration.GetValue<string>("MatchApi:FilePattern");
            //Get all files from the folder
            IEnumerable<string> allfiles = Directory.EnumerateFiles(connection);
            string fileName = string.Empty;
            string numbers = string.Empty;

            try
            {
                var part = Partitioner.Create(0, allfiles.Count());

                Parallel.ForEach(part, range => //To improve performance and utilize multiple cores
                {
                    for (int i = range.Item1; i < range.Item2; i++)
                    {
                        fileName = allfiles.ElementAt(i).Split('\\').Last(); //getting file name for error handling
                        string[] lines =  File.ReadAllLines(allfiles.ElementAt(i)); //Reading by line in each file

                        foreach(var line in lines)
                        {
                            
                            Match lineMatch = Regex.Match(line, pattern, RegexOptions.IgnoreCase); //matching given pattern
                            if (lineMatch.Success)
                            {
                                Match idMatch = Regex.Match(line, @"\d{3,}:");//getting id once pattern is matched
                                numbers += idMatch.Value.Replace(':', ',');//Concating result                           
                            }

                        }
                    }

                });

            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetAllNumbers method for file {0}: {1}", fileName, ex.Message);
            }

            return Task.FromResult(numbers);
        }

    }
}
