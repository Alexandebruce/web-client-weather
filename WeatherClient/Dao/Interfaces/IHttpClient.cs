using System.Threading.Tasks;

namespace WeatherClient.Dao.Interfaces
{
    public interface IHttpClient
    {
        Task<T> Get<T>(string address);
    }
}
