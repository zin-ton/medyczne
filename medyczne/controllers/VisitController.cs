using medyczne.Models;
using medyczne.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace medyczne.controllers;

[ApiController]
[Route("[controller]")]
public class VisitController : Controller
{
    private readonly VisitRepository _visitRepository;
    
    [HttpPost("AdVisitAsDoctor")]
    public IActionResult AdVisitAsDoctor(Doctor doctor, int PatientId, DateTime dateTime)
    {
        Visit visit = new Visit();
        visit.PatientId = PatientId;
        visit.DoctorId = doctor.Id;
        visit.Datetime = dateTime;
        visit.Approved = false;
        Visit? result = _visitRepository.AddNewVisit(visit);
        if (result != null) return Ok(result);
        return BadRequest();
    } 
    
    [HttpPost("AdVisitAsPatient")]
    public IActionResult AdVisitAsPatient(Patient patient, int DoctorId, DateTime dateTime)
    {
        Visit visit = null;
        visit.PatientId = patient.Id;
        visit.DoctorId = DoctorId;
        visit.Datetime = dateTime;
        visit.Approved = false;
        Visit? result = _visitRepository.AddNewVisit(visit);
        if (result != null) return Ok(result);
        return BadRequest();
    }

    [HttpGet("GetVisitsAsDoctor")]
    public IActionResult GetVisitsAsDoctor(Doctor doctor)
    {
        List<Visit>? result = _visitRepository.GetVisitsAsDoctor(doctor);
        if (result != null) return Ok(result);
        return BadRequest();
    }
    
    [HttpGet("GetVisitsAsPatient")]
    public IActionResult GetVisitsAsPatient(Patient patient)
    {
        List<Visit>? result = _visitRepository.GetVisitsAsPatient(patient);
        if (result != null) return Ok(result);
        return BadRequest();
    }
    
    [HttpPost("approve")]
    public IActionResult approveVisit(Visit visit, bool approve)
    {
        Visit? result = _visitRepository.Approve(visit, approve);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest();
    }
}