using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers
{
    [Route("v1/users")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<List<User>>> GetAction(
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            var users = await context
                .Users
                .AsNoTracking()
                .ToListAsync();
            
            return users;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<UserController>> Post(
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //Força o usuario a ser sempre "funcionario"
                model.Role = "employee";

                context.Users.Add(model);
                await context.SaveChangesAsync();

                //Escionder Senha
                model.Password = "";
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel criar o usuário"});
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            var user = await context.Users
                .AsNoTracking()
                .Where(x => x.UserName == model.UserName && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            //Esconder Senha
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPut]
        [Route("id:int")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<User>> Put(
            int id,
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (id != model.Id)
                return NotFound(new { message = "Usuário não encontrado"});

            try
            {
                context.Entry<User>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {                
                return BadRequest(new { message = "Não foi possivel criar o usuário"});
            }
        }
    }
}