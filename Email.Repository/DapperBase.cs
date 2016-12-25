using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Email.Repository
{
    public abstract class DapperBase
    {
        protected abstract DbConnection OpenConnection();

        protected T Get<T>(Func<DbConnection, T> queryFunc)
        {
            using (var connection = OpenConnection())
            {
                return queryFunc(connection);
            }
        }

        protected List<T> Get<T>(Func<DbConnection, IEnumerable<T>> queryFunc)
        {
            using (var connection = OpenConnection())
            {
                return queryFunc(connection).ToList();
            }
        }

        protected int Execute(Func<DbConnection, int> queryFunc)
        {
            using (var connection = OpenConnection())
            {
                return queryFunc(connection);
            }
        }

        protected int? Execute(Func<DbConnection, int?> queryFunc)
        {
            using (var connection = OpenConnection())
            {
                return queryFunc(connection);
            }
        }
    }
}
