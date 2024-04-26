
using QLCuDan.BLL.Dto;
using QLCuDan.DAL.Model;
using QLCuDan.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CitizenService : ICitizenService
{
    private readonly UnitOfWork _unitOfWork;


    public CitizenService(UnitOfWork unitOfWork)
    {
        unitOfWork = unitOfWork;
    }

    public async Task<List<CitizenDto>> GetAllCitizensAsync()
    {
        var citizens = await _unitOfWork.CitizenRepository.GetAllAsync();
        return citizens.Select(c => new CitizenDto
        {
            CitizenId = c.Id,
            Name = c.Name,
            PhoneNumber = c.PhoneNumber,
            Email = c.Email,
            DOB = c.DOB
        }).ToList();
    }

    public async Task<CitizenDto> GetCitizenByIdAsync(int id)
    {
        var citizen = await _unitOfWork.CitizenRepository.GetByIdAsync(id);
        if (citizen == null)
            return null;

        return new CitizenDto
        {
            CitizenId = citizen.Id,
            Name = citizen.Name,
            PhoneNumber = citizen.PhoneNumber,
            Email = citizen.Email,
            DOB = citizen.DOB
        };
    }

    public async Task<CitizenDto> CreateCitizenAsync(CitizenDto citizenDto)
    {
        var citizen = new Citizen
        {
            Name = citizenDto.Name,
            PhoneNumber = citizenDto.PhoneNumber,
            Email = citizenDto.Email,
            DOB = citizenDto.DOB
        };

        await _unitOfWork.CitizenRepository.AddAsync(citizen);

        citizenDto.CitizenId = citizen.Id;
        return citizenDto;
    }

    public async Task<bool> UpdateCitizenAsync(int id, CitizenDto citizenDto)
    {
        var citizen = await _unitOfWork.CitizenRepository.GetByIdAsync(id);
        if (citizen == null)
            return false;

        citizen.Name = citizenDto.Name;
        citizen.PhoneNumber = citizenDto.PhoneNumber;
        citizen.Email = citizenDto.Email;
        citizen.DOB = citizenDto.DOB;

        await _unitOfWork.CitizenRepository.UpdateAsync(citizen);
        return true;
    }

    public async Task<bool> DeleteCitizenAsync(int id)
    {
        var citizen = await _unitOfWork.CitizenRepository.GetByIdAsync(id);
        if (citizen == null)
            return false;

        await _unitOfWork.CitizenRepository.DeleteAsync(citizen);
        return true;
    }
}
