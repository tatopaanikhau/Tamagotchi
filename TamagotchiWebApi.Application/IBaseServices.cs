namespace TamagotchiWebApi.Application;

public interface IBaseServices<T> where T : class
{
    T GetById(int id);
    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);
}