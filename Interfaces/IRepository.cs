namespace Interdisciplinar2023.Interfaces;

public interface IRepository<T>
{
    bool Add(T entity);

    bool Update(T entity);

    bool Delete(T entity);

    bool Save();
}
