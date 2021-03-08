using DemoData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public interface IUserRepository
    {
        UserVM GetUser(int id);

        ActionResultVM GetUsers(FilterVM dataTablesParameters);

        UserVM addUser(UserVM userVM);

        UserVM deleteUser(int id);

        UserVM EditUser(int id, UserVM userVM);
    }
}
