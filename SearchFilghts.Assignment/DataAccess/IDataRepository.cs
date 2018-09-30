using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SearchFilghts.Assignment.DataAccess
{
    public interface IDataRepository
    {
        DataTable ReadDataFromProvider(string ProviderName, char separater);
    }
}