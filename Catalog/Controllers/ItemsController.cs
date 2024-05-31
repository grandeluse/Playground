using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("api/v1/items")]
public class ItemsController : ControllerBase
{
    private readonly IItemsRepository _repository;

    public ItemsController(IItemsRepository repository)
    {
        _repository = repository;
    }

    // GET /items
    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {
        var items = _repository.GetItems().Select(item=> item.AsDto());
        return items;
    }

    // GET /items/{id}
    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {
        var item = _repository.GetItem(id);

        if (item is null)
        {
            return NotFound();
        }
        return item.AsDto();
    }
    

}