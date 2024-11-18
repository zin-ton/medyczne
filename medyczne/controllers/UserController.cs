using medyczne.Models;
using medyczne.Services;
using Microsoft.AspNetCore.Mvc;

namespace medyczne.controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(IConfiguration _configuration)
    {
        _userService = new UserService(_configuration);
    }

    [HttpPost("loginAsPatient")]
    public IActionResult loginAsPatient(string login, string password)
    {
        Patient? patient = _userService.LoginAsPatient(login, password);
        if (patient != null) return Ok(patient);
        return BadRequest();
    }
    
    [HttpPost("loginAsDoctor")]
    public IActionResult loginAsDoctor(string login, string password)
    {
        Doctor? doctor = _userService.LoginAsDoctor(login, password);
        if (doctor != null) return Ok(doctor);
        return BadRequest();
    }

    [HttpPost("registerAsPatient")]
    public IActionResult registerAsPatient(Patient patient)
    {
        Patient? registered = _userService.AddNewPatient(patient);
        if (registered != null) return Ok(registered);
        return BadRequest();
    }
    
    [HttpPost("registerAsDoctor")]
    public IActionResult registerAsDoctor(Doctor doctor)
    {
        Doctor? registered = _userService.AddNewDoctor(doctor);
        if (registered != null) return Ok(registered);
        return BadRequest();
    }
}