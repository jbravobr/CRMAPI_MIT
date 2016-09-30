using System.Collections.Generic;
using System.Threading.Tasks;

namespace MITCRMApp
{
    public interface IServicesBase<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
