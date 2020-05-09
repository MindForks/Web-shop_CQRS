using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WS_Core.Data.Interfaces;

namespace WS_Core.Data.Database
{
    public class MongoDatabase<T> : IDatabase<T> where T : class, new()
    {
        private static string connectionString = "mongodb://localhost:27017/web-shop";

        private static IMongoClient server = new MongoClient(connectionString);

        private string collectionName;

        private IMongoDatabase db;

        protected IMongoCollection<T> Collection
        {
            get
            {
                return db.GetCollection<T>(collectionName);
            }
            set
            {
                Collection = value;
            }
        }

        public MongoDatabase(string collectionName)
        {
            this.collectionName = collectionName;
            db = server.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
        }

        public IMongoQueryable<T> Query
        {
            get
            {
                return Collection.AsQueryable<T>();
            }
            set
            {
                Query = value; 
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await GetAsync(_ => true);
        }

        public T GetOne(Expression<Func<T, bool>> expression)
        {
            return Collection.Find(expression).SingleOrDefault();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            var result = await Collection.FindAsync(expression);

            return await result.ToListAsync();
        }

        public T FindOneAndUpdate(Expression<Func<T, bool>> expression, UpdateDefinition<T> update, FindOneAndUpdateOptions<T> option)
        {
            return Collection.FindOneAndUpdate(expression, update, option);
        }

        public void UpdateOne(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
        {
            Collection.UpdateOne(expression, update);
        }

        public async Task ReplaceOneAsync(Expression<Func<T, bool>> expression, T item)
        {
            await Collection.ReplaceOneAsync(expression, item);
        }

        public void ReplaceOne(Expression<Func<T, bool>> expression, T update)
        {
            Collection.ReplaceOne(expression, update);
        }

        public void DeleteOne(Expression<Func<T, bool>> expression)
        {
            Collection.DeleteOne(expression);
        }

        public async Task DeleteOneAsync(Expression<Func<T, bool>> expression)
        {
            await Collection.DeleteOneAsync(expression);
        }

        public void InsertMany(IEnumerable<T> items)
        {
            Collection.InsertMany(items);
        }

        public void InsertOne(T item)
        {
            Collection.InsertOne(item);
        }

        public async Task InsertOneAsync(T item)
        {
            await Collection.InsertOneAsync(item);
        }
    }
}
