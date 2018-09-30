using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchFilghts.Assignment.Providers
{
    /// <summary>
    /// Provider interface use to decouple the provider, hence open for enhancement
    /// </summary>
    public interface IDataProvider
    {
        string GetProviderName();
        char GetProviderFileSeprator();
    }
}