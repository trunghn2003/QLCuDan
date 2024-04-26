using QLCuDan.DAL.Model;
using QLCuDan.BLL.Dto;
using QLCuDan.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ApartmentService : IApartmentService
{
    private readonly UnitOfWork _unitOfWork;

    public ApartmentService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ApartmentDto>> GetAllApartmentsAsync()
    {
        var apartments = await _unitOfWork.ApartmentRepository.GetAllAsync();
        return apartments.Select(a => new ApartmentDto
        {
            ApartmentID = a.Id,
            UnitNumber = a.UnitNumber,
            Floor = a.Floor,
            Size = a.Size
        }).ToList();
    }

    public async Task<ApartmentDto> GetApartmentByIdAsync(int id)
    {
        var apartment = await _unitOfWork.ApartmentRepository.GetByIdAsync(id);
        if (apartment == null)
            return null;
        return new ApartmentDto
        {
            ApartmentID = apartment.Id,
            UnitNumber = apartment.UnitNumber,
            Floor = apartment.Floor,
            Size = apartment.Size
        };
    }

    public async Task<ApartmentDto> CreateApartmentAsync(ApartmentDto apartmentDto)
    {
        var apartment = new Apartment
        {
            UnitNumber = apartmentDto.UnitNumber,
            Floor = apartmentDto.Floor,
            Size = apartmentDto.Size
        };
        //await _unitOfWork.ApartmentRepository.Add(apartment);
        apartmentDto.ApartmentID = apartment.Id;
        return apartmentDto;
    }

    public async Task<bool> UpdateApartmentAsync(int id, ApartmentDto apartmentDto)
    {
        var apartment = await _unitOfWork.ApartmentRepository.GetByIdAsync(id);
        if (apartment == null)
            return false;

        apartment.UnitNumber = apartmentDto.UnitNumber;
        apartment.Floor = apartmentDto.Floor;
        apartment.Size = apartmentDto.Size;
        //await _unitOfWork.ApartmentRepository.Update(apartment);
        return true;
    }

    public async Task<bool> DeleteApartmentAsync(int id)
    {
        var apartment = await _unitOfWork.ApartmentRepository.GetByIdAsync(id);
        if (apartment == null)
            return false;

        //await _unitOfWork.ApartmentRepository.DeleteAsync(apartment);
        return true;
    }
}
