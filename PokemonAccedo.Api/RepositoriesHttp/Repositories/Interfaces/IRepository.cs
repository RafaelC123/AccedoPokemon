namespace PokemonAccedo.Api.RepositoriesHttp.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetList();
        Task<T> GetFirst(string Id);
    }
}
