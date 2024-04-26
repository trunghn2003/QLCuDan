using System.ComponentModel.DataAnnotations;
namespace QLCuDan.DAL.Model


{
    public class Citizen
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }

        public ICollection<CitizenApartment> ? CitizenApartments { get; set; }
    }
}
