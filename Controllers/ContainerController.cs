using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ContainerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ContainerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetContainers()
    {
        var containers = await _context.Containers.ToListAsync();
        return Ok(containers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContainer(int id)
    {
        var container = await _context.Containers.FindAsync(id);
        if (container == null)
        {
            return NotFound();
        }
        return Ok(container);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContainer([FromBody] Container container)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Containers.Add(container);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetContainer), new { id = container.ContainerId }, container);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContainer(int id, [FromBody] Container container)
    {
        if (id != container.ContainerId)
        {
            return BadRequest();
        }

        var existingContainer = await _context.Containers.FindAsync(id);
        if (existingContainer == null)
        {
            return NotFound();
        }

        existingContainer.ContainerNumber = container.ContainerNumber;
        existingContainer.ChassisNumber = container.ChassisNumber;
        existingContainer.ContainerType = container.ContainerType;
        existingContainer.Capacity = container.Capacity;
        existingContainer.Status = container.Status;

        _context.Entry(existingContainer).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContainer(int id)
    {
        var container = await _context.Containers.FindAsync(id);
        if (container == null)
        {
            return NotFound();
        }

        _context.Containers.Remove(container);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
