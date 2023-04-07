using Hotel.IRepositories;
using Hotel.Models;

namespace Hotel.Repostories;

internal class UserRepository : IUserRepository
{
    private List<User> users = new();

    public User Create(User user)
    {
        user.Id = users.Count + 1;
        users.Add(user);
        return user;
    }


    public bool Delete(int id)
    {
        var user = users.Find(p => p.Id == id);

        if (user == null)
            return false;

        users.Remove(user);
        return true;

    }

    public List<User>? GetAll() => users;


    public User? Get(int id) => users.Find(p => p.Id == id);

    public User Update(User user, int id)
    {
        var myUser = users.Find(p => p.Id == id);

        if (myUser == null)
            return null;

        user.Id = id;

        users.Remove(myUser);

        users.Add(user);
        return myUser;
    }
}

