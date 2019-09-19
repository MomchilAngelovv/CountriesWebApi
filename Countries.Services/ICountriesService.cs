using System.Collections.Generic;

namespace Countries.Services
{
    public interface ICountriesService
    {
        IEnumerable<T> GetAll<T>();
    }
}