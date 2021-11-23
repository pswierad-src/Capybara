using Capybara.Api.Models;
using Capybara.Application.Commands;
using Capybara.Application.Dto;
using Capybara.Application.Queries;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capybara.Api.Controllers
{
    [Route("api/books")]
    public class BooksController : BaseController
    {
        public BooksController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
            : base(queryDispatcher, commandDispatcher)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<BookSimpleDto> response = await queryDispatcher.QueryAsync(new GetBooksQuery());

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await queryDispatcher.QueryAsync(new GetBookQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBookRequest request)
        {
            await commandDispatcher.SendAsync(new CreateBookCommand(
                request.Title,
                request.Author,
                request.Price));

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateBookRequest request)
        {
            await commandDispatcher.SendAsync(new UpdateBookCommand(
                id,
                request.Title,
                request.Author,
                request.Price));

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await commandDispatcher.SendAsync(new DeleteBookCommand(id));

            return Ok();
        }
    }
}
