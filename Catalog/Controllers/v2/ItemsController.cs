using Asp.Versioning;
using Catalog.Dtos;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers.v2;

[ApiVersion("2.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]/")]
public class ItemsController : ControllerBase
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
        var items = (await _repository.GetItemsAsync())
            .Select(item => item.AsDto());
        return items;
    }
}
    