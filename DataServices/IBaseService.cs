using System.Threading.Tasks;

namespace DataServices
{
    public interface IBaseService<T>
    {
        ValueTask<T> GetById(int id);
    }
}