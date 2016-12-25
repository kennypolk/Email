using System.Collections.Generic;
using Dapper;
using Email.Repository.Interfaces;

namespace Email.Repository
{
    public class Repository<T> : RepositoryBase, IRepository<T>
    {
        public Repository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }

        public T Get(int id)
        {
            return Get(connection => connection.Get<T>(id));
        }

        public List<T> Get()
        {
            return Get(connection => connection.GetList<T>());
        }

        public List<T> Get(object whereConditions)
        {
            return Get(connection => connection.GetList<T>(whereConditions));
        }

        public List<T> Get(string conditions, object parameters = null)
        {
            return Get(connection => connection.GetList<T>(conditions, parameters));
        }

        public int? Insert(T item)
        {
            return Execute(connection => connection.Insert(item));
        }

        public int Update(T item)
        {
            return Execute(connection => connection.Update(item));
        }

        public int Delete(T item)
        {
            return Execute(connection => connection.Delete(item));
        }

        public int Delete(int id)
        {
            return Execute(connection => connection.Delete<T>(id));
        }

        public int DeleteList(object whereConditions)
        {
            return Execute(connection => connection.DeleteList<T>(whereConditions));
        }

        public int DeleteList(string conditions, object parameters = null)
        {
            return Execute(connection => connection.DeleteList<T>(conditions, parameters));
        }

        public int RecordCount(string conditions = "", object paramerters = null)
        {
            return Execute(connection => connection.RecordCount<T>(conditions, paramerters));
        }
    }
}
