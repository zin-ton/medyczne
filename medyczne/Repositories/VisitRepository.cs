using medyczne.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace medyczne.Repositories;

public class VisitRepository
{
    private readonly NeondbContext _dbContext1;

    public VisitRepository(IConfiguration configuration)
    {
        _dbContext1 = new NeondbContext(configuration);
    }
    
    public List<Visit>? GetVisitsAsDoctor(Doctor doctor)
    {
        List<Visit> visits = null;
        var data = _dbContext1.Visits.ToList();
        foreach (var visit in data)
        {
            if(visit.DoctorId == doctor.Id) visits.Add(visit);   
        }

        return visits;
    }

    public List<Visit>? GetVisitsAsPatient(Patient patient)
    {
        List<Visit> visits = null;
        var data = _dbContext1.Visits.ToList();
        foreach (var visit in data)
        {
            if(visit.PatientId == patient.Id) visits.Add(visit);
        }

        return visits;
    }

    public Visit? AddNewVisit(Visit visit)
    {
        var result = _dbContext1.Visits.Add(visit);
        _dbContext1.SaveChanges();
        return result.Entity;
    }

    public Visit? Approve(Visit visit, bool approveState)
    {
        if (approveState = true)
        {
           var result = _dbContext1.Visits.FirstOrDefault(v => v.Id == visit.Id);
            result.Approved = true;
            _dbContext1.Entry(result).State = EntityState.Modified;
            _dbContext1.SaveChanges();   
            return result;
        }
        var result1 = _dbContext1.Visits.Remove(visit);
        _dbContext1.SaveChanges();
        return result1.Entity;
    }
}