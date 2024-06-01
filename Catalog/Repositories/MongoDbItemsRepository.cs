using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories;

public class MongoDbItemsRepository : IItemsRepository
{
    private const string DatabaseName = "catalog"; 
    private const string CollectionName = "items"; 
    private readonly IMongoCollection<Item> _itemsCollection;
    private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;
    
    public MongoDbItemsRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
        _itemsCollection = database.GetCollection<Item>(CollectionName);
    }

    public void CreateItemAsync(Item item)
    {
        _itemsCollection.InsertOne(item);
    }
    
    public Item GetItemAsync(Guid id)
    {
        var filter = _filterBuilder.Eq(item => item.Id, id);
        return _itemsCollection.Find(filter).SingleOrDefault();
    }

    public IEnumerable<Item> GetItemsAsync()
    {
        return _itemsCollection.Find(new BsonDocument()).ToList();
    }

    public void UpdateItemAsync(Item item)
    {
        var filter = _filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
        _itemsCollection.ReplaceOne(filter, item);
    }

    public void DeleteItemAsync(Guid id)
    {
        var filter = _filterBuilder.Eq(item => item.Id, id);
        _itemsCollection.DeleteOne(filter);
    }
}