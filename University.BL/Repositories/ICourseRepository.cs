using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
