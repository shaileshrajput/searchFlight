using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchFilghts.Assignment.Providers
{
    public class DBProvider1 : IDataProvider
    {
        /// <summary>
        /// Provider details where data to be fetch 
        /// </summary>
        /// <returns>Provider details</returns>
        string IDataProvider.GetProviderName()
        {
            return "Provider1.txt";
        }
        /// <summary>
        /// seperator to read the file
        /// </summary>
        /// <returns>character seperator use to extract data</returns>
        char IDataProvider.GetProviderFileSeprator()
        {
            return ',';
        }
    }
}