using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WS_Core.Data.Interfaces
{
    public interface IDatabase<T> where T : class, new()
    {
        Task<List<T>> GetAsync(Expression<Func<T, bool>> expression);

        IMongoQueryable<T> Query { get; set; }

        Task<List<T>> GetAllAsync();

        T GetOne(Expression<Func<T, bool>> expression);

        T FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option);

        void UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);

        Task ReplaceOneAsync(Expression<Func<T, bool>> expression, T item);

        void ReplaceOne(Expression<Func<T, bool>> expression, T update);

        void DeleteOne(Expression<Func<T, bool>> expression);

        Task DeleteOneAsync(Expression<Func<T, bool>> expression);

        void InsertMany(IEnumerable<T> items);

        void InsertOne(T item);

        Task InsertOneAsync(T item);
    }
}
