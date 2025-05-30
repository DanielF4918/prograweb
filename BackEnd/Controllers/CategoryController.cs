﻿using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            _logger.LogDebug("Obtener todas las categorías");
            return _categoryService.GetCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryDTO Get(int id)
        {
            return _categoryService.GetCategoryById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryDTO category)
        {
            _categoryService.AddCategory(category);

        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public void Put([FromBody] CategoryDTO category)
        {
            try
            {
                _categoryService.UpdateCategory(category);
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
            }


        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}