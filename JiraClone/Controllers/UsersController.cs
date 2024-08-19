
using Application.Repositories;
using Application.Utility.Hashing;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;


namespace JiraClone.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserDal _userDal;

        public UsersController(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [HttpPost]
        public async Task<IActionResult> add([FromBody] AddUser adduser)
        {
            byte[] passwordHash, passwordSalt;
            HashHelper.CreateHash(adduser.password, out passwordHash, out passwordSalt);
            User user = new User
            {
                FirstName = adduser.name,
                LastName = adduser.lastname,
                Email = adduser.email,
                IsActive = true,
                CreatedDate = DateTimeOffset.UtcNow,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            var result = await _userDal.Add(user);
            await _userDal.SaveAsync();
            return Ok(result);
        }

        public record AddUser(string name, string email, string lastname, string password);
    }
}
