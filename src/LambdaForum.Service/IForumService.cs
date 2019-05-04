using System.Collections.Generic;
using System.Threading.Tasks;
using LambdaForum.Domain.Models;

namespace LambdaForum.Service
{
    public interface IForumService
    {
        Task Create(Forum forum);
        Task Delete(int id);
        Task<Forum> Read(int id);
        Task<IEnumerable<Forum>> ReadAll();
        Task<IEnumerable<T>> ReadAll<T>();
        Task Update(Forum forum);
    }
}
