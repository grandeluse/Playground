using Asp.Versioning;
using Catalog.Api.Dtos;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.v2;


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
                new(Guid.NewGuid(), "Grandeluse Potion V2", Guid.NewGuid().ToString(), 1000, DateTimeOffset.UtcNow)
            };
        return items;
    }
}
    