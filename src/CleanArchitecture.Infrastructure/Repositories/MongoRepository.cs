using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Repositories;
using MongoDB.Driver;

namespace CleanArchitecture.Infrastructure.Repositories;
public class MongoRepository<T, TKey> : IMongoRepository<T, TKey>
{
    private readonly IMongoCollection<T> _collection;
    public MongoRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }
    public IQueryable<T> Query => _collection.AsQueryable();

    public async Task<T?> GetByIdAsync(TKey id)
    {
        var filter = Builders<T>.Filter.Eq("_id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression)
    {
        var results = await _collection.Find(expression).ToListAsync();
        return results.AsQueryable();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        var id = entity?.GetType().GetProperty("Id")?.GetValue(entity);
        var filter = Builders<T>.Filter.Eq("_id", id);
        await _collection.ReplaceOneAsync(filter, entity);
        return entity;
    }

    public async Task RemoveAsync(T entity)
    {
        var id = entity?.GetType().GetProperty("Id")?.GetValue(entity);
        var filter = Builders<T>.Filter.Eq("_id", id);
        await _collection.DeleteOneAsync(filter);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _collection.InsertManyAsync(entities);
    }

    public async Task RemoteRangeAsync(IEnumerable<T> entities)
    {
        var ids = entities
               .Select(e => e?.GetType().GetProperty("Id")?.GetValue(e))
               .ToList();
        var filter = Builders<T>.Filter.In("_id", ids);
        await _collection.DeleteManyAsync(filter);
    }

    void IMongoRepository<T, TKey>.Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }
}
