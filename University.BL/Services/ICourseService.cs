using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Services
{
    public interface ICourseService : IGenericService<Course>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
