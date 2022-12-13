public interface IUserRepository 
{
    public Task<User> CreateUser(User user);
    public Task<User> UpdateUser(User user);
    public Task<List<User>> GetAllUsers();
    public Task<User> GetUserById(int id);
    public Tsk<bool> ExistsUserWithId(int id);
}