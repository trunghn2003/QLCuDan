using System.ComponentModel.DataAnnotations;

namespace QLCuDan.DAL.Model
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        public string UnitNumber { get; set; }
        public int Floor { get; set; }
        public double Size { get; set; }

        public ICollection<CitizenApartment> ? CitizenApartments { get; set; }
    }
}
