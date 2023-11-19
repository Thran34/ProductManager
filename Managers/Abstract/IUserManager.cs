using ProductManager.Models;
using ProductManager.Models.Helpers;

namespace ProductManager.Managers.Abstract
{
    internal interface IUserManager
    {
        User SetupUser(string firstName, string lastName, Role role);
        void ManageUser(User user);
    }
}
