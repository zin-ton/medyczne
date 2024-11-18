using medyczne.Models;
using medyczne.Repositories;

namespace medyczne.Services;

public class UserService
{
    private readonly UserRepository _userRepository;

    public UserService(IConfiguration configuration)
    {
        _userRepository = new UserRepository(configuration);
    }

    public Patient? AddNewPatient(Patient patient)
    {
        if (_userRepository.GetPatientByLogin(patient.Login) == null)
        {
            Patient newPatient = new Patient();
            newPatient.Login = patient.Login;
            newPatient.Name = patient.Name;
            newPatient.Surname = patient.Surname;
            newPatient.Id = patient.Id;
            newPatient.Password = Sha256Hasher.HashString(patient.Password);
            return _userRepository.AddNewPatient(newPatient);
        }

        return null;
    }
    
    public Doctor? AddNewDoctor(Doctor doctor)
    {
        if (_userRepository.GetDoctorByLogin(doctor.Login) == null)
        {
            Doctor newDoctor = new Doctor();
            newDoctor.Login = doctor.Login;
            newDoctor.Name = doctor.Name;
            newDoctor.Surname = doctor.Surname;
            newDoctor.Id = doctor.Id;
            newDoctor.Password = Sha256Hasher.HashString(doctor.Password);
            newDoctor.Type = doctor.Type;
            newDoctor.Starttime = doctor.Starttime;
            newDoctor.Endtime = doctor.Endtime;
            return _userRepository.AddNewDoctor(newDoctor);
        }
        return null;
    }

    public Patient? LoginAsPatient(string login, string password)
    {
        var patient = _userRepository.GetPatientByLogin(login);

        if (patient != null && patient.Password == Sha256Hasher.HashString(password))
        {
            return patient;
        }

        return null;
    }
    
    public Doctor? LoginAsDoctor(string login, string password)
    {
        var doctor = _userRepository.GetDoctorByLogin(login);

        if (doctor != null && doctor.Password == Sha256Hasher.HashString(password))
        {
            return doctor;
        }

        return null;
    }
    
}