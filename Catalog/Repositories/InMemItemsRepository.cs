using Catalog.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Repositories;

public class InMemItemsRepository : IItemsRepository
{
    private readonly List<Item> _items = new()
    {
        new Item() { Id = Guid.NewGuid(), Name = "Potion", Price = 9 ,CreatedDate = DateTimeOffset.UtcNow},
        new Item() { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20,CreatedDate = DateTimeOffset.UtcNow},
        new Item() { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18 ,CreatedDate = DateTimeOffset.UtcNow},
    };

    public IEnumerable<Item> GetItemsAsync()
    {
        return _items;
    }

    public Item GetItemAsync(Guid id)
    {
        return _items.SingleOrDefault(item => item.Id == id);
    }

    public void CreateItemAsync(Item item)
    {
        _items.Add(item);
    }

    public void UpdateItemAsync(Item item)
    {
        var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
        _items[index] = item;
    }

    public void DeleteItemAsync(Guid id)
    {
        var index = _items.FindIndex(existingItem => existingItem.Id == id);
        _items.RemoveAt(index);
    }
}