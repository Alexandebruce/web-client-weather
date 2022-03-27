using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Dao.Interfaces
{
    interface IHttpClient
    {
        Task<string> Get(string address);
    }
}
