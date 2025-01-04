using medyczne.Models;

namespace medyczne.Repositories;

public class UserRepository
{
    private readonly NeondbContext _dbContext1;

    public UserRepository(IConfiguration configuration)
    {
        _dbContext1 = new NeondbContext(configuration);
    }

    public Doctor? AddNewDoctor(Doctor doctor)
    {
        var result = _dbContext1.Doctors.Add(doctor);
        _dbContext1.SaveChanges();
        return result.Entity;
    }

    public Patient? AddNewPatient(Patient patient)
    {
        var result = _dbContext1.Patients.Add(patient);
        _dbContext1.SaveChanges();
        return result.Entity;
    }

    public Patient? GetPatientById(Int64 FindId)
    {
        return _dbContext1.Patients.FirstOrDefault(patient => patient.Id == FindId);
    }
    
    public Doctor? GetDoctorById(Int64 FindId)
    {
        return _dbContext1.Doctors.FirstOrDefault(doctor => doctor.Id == FindId);
    }
    
    public Doctor? GetDoctorByLogin(String login)
    {
        return _dbContext1.Doctors.FirstOrDefault(doctor => doctor.Login == login);
    }
    
    public Patient? GetPatientByLogin(String login)
    {
        return _dbContext1.Patients.FirstOrDefault(patient => patient.Login == login);
    }

    public List<Doctor>? GetAllDoctors()
    {
        return _dbContext1.Doctors.ToList();
    }

    
}