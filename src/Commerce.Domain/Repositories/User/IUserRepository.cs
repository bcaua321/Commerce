using Entities;

public interface IUserRepository 
{
    public Task<User> Create(User user);
    public Task<User> Update(User user);
    public Task<List<User>> GetAlls();
    public Task<User> GetById(int id);
    public Task<bool> ExistsWithId(int id);
}