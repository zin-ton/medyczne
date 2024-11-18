using medyczne.Models;

namespace medyczne.Repositories;

public class UserRepository
{
    private readonly NeondbContext _dbContext;

    public UserRepository(IConfiguration configuration)
    {
        _dbContext = new NeondbContext(configuration);
    }

    public Doctor? AddNewDoctor(Doctor doctor)
    {
        var result = _dbContext.Doctors.Add(doctor);
        return result.Entity;
    }

    public Patient? AddNewPatient(Patient patient)
    {
        var result = _dbContext.Patients.Add(patient);
        return result.Entity;
    }

    public Patient? GetPatientById(Int64 FindId)
    {
        return _dbContext.Patients.FirstOrDefault(patient => patient.Id == FindId);
    }
    
    public Doctor? GetDoctorById(Int64 FindId)
    {
        return _dbContext.Doctors.FirstOrDefault(doctor => doctor.Id == FindId);
    }
    
    public Doctor? GetDoctorByLogin(String login)
    {
        return _dbContext.Doctors.FirstOrDefault(doctor => doctor.Login == login);
    }
    
    public Patient? GetPatientByLogin(String login)
    {
        return _dbContext.Patients.FirstOrDefault(patient => patient.Login == login);
    }
    
    
}