using medyczne.Models;
using medyczne.Services;
using Microsoft.AspNetCore.Cors;
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

    [HttpGet("getDoctorById")]
    public IActionResult getDoctorById(int doctorId)
    {
        var result =  _userService.GetDoctorById(doctorId);
        if (result != null) return Ok(result);
        return BadRequest();
    }

    [HttpGet("GetPatientById")]
    public IActionResult getPatinetById(int patientId)
    {
        var result = _userService.GetPatientById(patientId);
        if (result != null) return Ok(result);
        return BadRequest();
    }
    
    [HttpGet("getDoctorByLogin")]
    public IActionResult getDoctorByLogin(String login)
    {
        var result =  _userService.GetDoctorBylogin(login);
        if (result != null) return Ok(result);
        return BadRequest();
    }

    [HttpGet("GetPatientByLogin")]
    public IActionResult getPatinetByLogin(String login)
    {
        var result = _userService.GetPatientByLogin(login);
        if (result != null) return Ok(result);
        return BadRequest();
    }

    [HttpGet("GetAllDoctors")]
    public IActionResult GetAllDoctors()
    {
        List <Doctor> result = _userService.GetAllDoctors();
        return Ok(result);
    }

    
}