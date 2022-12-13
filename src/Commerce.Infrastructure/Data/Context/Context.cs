public class Context : DbContext
{
    public Context(DbOptionsBuilder<Context> options) : base(options)
    {
    }
}