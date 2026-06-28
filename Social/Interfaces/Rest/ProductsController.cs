using Microsoft.AspNetCore.Mvc;
using MonitoNet.Backend.Social.Application.QueryServices;

namespace MonitoNet.Backend.Social.Interfaces.Rest;

[ApiController]
[Route("api/v1/products")]
public sealed class ProductsController : ControllerBase
{
    private readonly IProductQueryService _products;

    public ProductsController(IProductQueryService products)
    {
        _products = products;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _products.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var product = await _products.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }
}
