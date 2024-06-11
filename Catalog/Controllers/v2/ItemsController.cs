using Asp.Versioning;
using Catalog.Dtos;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers.v2;


[ApiController]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ItemsController //: ControllerBase
{
    private readonly IItemsRepository _repository;

    public ItemsController(IItemsRepository repository)
    {
        _repository = repository;
    }

    // GET /items
    [HttpGet]
    public async Task<IEnumerable<ItemDto>> GetItemsAsync()
    {
        //var items = (await _repository.GetItemsAsync())
        //   .Select(item => item.AsDto());
            var items = new List<ItemDto>()
            {
                new()
                {
                    Id = Guid.NewGuid(), Name = "Grandeluse Potion V2", Price = 1000, CreatedDate = DateTimeOffset.UtcNow
                }
            };
        return items;
    }
}
    