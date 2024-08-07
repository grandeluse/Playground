using Asp.Versioning;
using Catalog.Api.Dtos;
using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class ItemsController : ControllerBase
{
    private readonly IItemsRepository _repository;
    private readonly ILogger<ItemsController> _logger;

    public ItemsController(IItemsRepository repository, ILogger<ItemsController> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    // GET /items
    [HttpGet]
    public async Task<IEnumerable<ItemDto>> GetItemsAsync(string name = null)
    {
        var items = (await _repository.GetItemsAsync())
            .Select(item=> item.AsDto());

        if (!string.IsNullOrWhiteSpace(name))
        {
            items = items.Where(item => item.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
        
        _logger.LogInformation($"Total items: {items.Count()}");
        return items;
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
    {
        var item = await _repository.GetItemAsync(id);

        if (item is null)
        {
            return NotFound();
        }
        return item.AsDto();
    }

    // POST /items
    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
    {
        Item item = new()
        {
            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            Description = itemDto.Description,
            Price = itemDto.Price,
            CreatedDate = DateTimeOffset.UtcNow
        };
        
        await _repository.CreateItemAsync(item);
        return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
    }

    // PUT /items/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
    {
        var existingItem = await _repository.GetItemAsync(id);

        if (existingItem is null)
        {
            return NotFound();
        }

        existingItem.Name = itemDto.Name;
        existingItem.Price = itemDto.Price;

        await _repository.UpdateItemAsync(existingItem);

        return NoContent();
    }

    // DELETE /items/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItemAsync(Guid id)
    {
        var existingItem = await _repository.GetItemAsync(id);

        if (existingItem is null)
        {
            return NotFound();
        }
        
        await _repository.DeleteItemAsync(id);

        return NoContent();
    } 
}