using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.DAL.Interface.Models;

namespace TaskList.DAL.Interface.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
