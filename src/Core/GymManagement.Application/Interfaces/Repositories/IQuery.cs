namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}
