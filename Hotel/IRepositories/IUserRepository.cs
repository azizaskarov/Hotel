
using Hotel.Models;

namespace Hotel.IRepositories;

internal interface IUserRepository
{
    User Create(User user);
    bool Delete(int id);
    User? Get(int id);
    List<User>? GetAll();
    User Update(User user, int id);
}