﻿using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        var products = _repository.GetAll();
        return Ok(products);
    }

    [HttpGet("{id:int}", Name= "GetProductById")]
    public ActionResult<Product> Get(int id)
    {
        var product = _repository.Get(p => p.ProductId == id);

        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet("products/{id:int}")]
    public ActionResult<Product> GetProductsByCategory(int id)
    {
        var products = _repository.GetProductsByCategory(id);

        if (products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }


    [HttpPost]
    public ActionResult Post(Product product)
    {
        if (product is null)
            return BadRequest();

        var productCreated = _repository.Create(product);
        return new CreatedAtRouteResult("GetProductById", new { id = productCreated.ProductId }, productCreated);

    }

    [HttpPut("{id:int}")]
    public  ActionResult Put(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }
        var updatedProduct = _repository.Update(product);
        return Ok(updatedProduct);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var product = _repository.Get(p => p.ProductId == id);
        return product is null ? NotFound() : Ok(_repository.Delete(product));
    }
}
