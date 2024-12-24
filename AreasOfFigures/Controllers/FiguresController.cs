using FiguresCalculator;
using Microsoft.AspNetCore.Mvc;

namespace AreasOfFigures.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FiguresController : ControllerBase
{
    private readonly ILogger<FiguresController> _logger;

    public FiguresController(ILogger<FiguresController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCircleArea")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetCircleArea(double radius)
    {
        try
        {
            Circle circle = new(radius);
            _logger.LogInformation("Calculate the area of {0}", circle.ToString());
            return Ok(circle.GetArea());
        }
        catch (Exception ex)
        {
            _logger.LogError("Could not calculate the circle area, radius = {0}, error = {1}", radius, ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet(Name = "GetTriangleArea")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetTriangleArea(double a, double b, double c)
    {
        try
        {
            Triangle triangle = new(a, b, c);
            _logger.LogInformation("Calculate the area of {0}", triangle.ToString());
            return Ok(triangle.GetArea());
        }
        catch (Exception ex)
        {
            _logger.LogError("Could not calculate the triangle area, sides = {0}, {1}, {2}, error = {3}", a, b, c, ex.Message);
            return BadRequest(ex.Message);
        }
    }
}