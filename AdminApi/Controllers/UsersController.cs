using Microsoft.AspNetCore.Mvc;
using AdminApi.DataContracts;
using AdminApi.Entities;
using AdminApi.Messaging;

namespace AdminApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppConfig _appConfig;
    private readonly IDbContext _context;
    private readonly IEventHelper _eventHelper;

    public UsersController(AppConfig appConfig, IDbContext context, IEventHelper eventHelper)
    {
        _appConfig = appConfig;
        _context = context;
        _eventHelper = eventHelper;
    }

    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        return _context.Users.ToList();
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _context.Users.FirstOrDefault(t => t.Id == id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public IActionResult AddUser([FromBody]AddEditUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User(request);

        _context.Users.Add(user);
        _context.SaveChanges();

        _eventHelper.Raise(user, UserEvent.State.Added);

        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult EditUser(int id, [FromBody]AddEditUserRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = _context.Users.FirstOrDefault(t => t.Id == id);
        if (user == null)
            return NotFound();
        
        user.Update(request);

        _context.SaveChanges();

        _eventHelper.Raise(user, UserEvent.State.Modified);

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(t => t.Id == id);
        if (user == null)
            return NotFound();
        
        _context.Users.Remove(user);
        _context.SaveChanges();

        _eventHelper.Raise(user, UserEvent.State.Deleted);

        return NoContent();
    }
}
