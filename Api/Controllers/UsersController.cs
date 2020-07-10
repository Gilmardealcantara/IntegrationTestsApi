using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly ApplicationDbContext _context;

        public UsersController(ILogger<UsersController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Users.ToListAsync());

        [HttpGet("{id}/repos")]
        public async Task<IActionResult> GetGitRepos([FromServices] IGitService service, int id)
        {

            var user = await _context.Users.FindAsync(id);
            if (user == null) return BadRequest("User not found");
            return Ok(await service.GetGitRepos(user.GitUserName));
        }
    }
}
