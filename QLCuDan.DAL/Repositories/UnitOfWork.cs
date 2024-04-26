using QLCuDan.DAL.Data;
using QLCuDan.DAL.Model;


namespace QLCuDan.DAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        public QLCuDanDALContext DbContext { get; }

        public IRepository<Apartment> ApartmentRepository { get; }
        public IRepository<Citizen> CitizenRepository { get; }
        public IRepository<CitizenApartment> CitizenApartmentRepository { get; }

        public UnitOfWork(QLCuDanDALContext context,
             IRepository<Apartment> apartments,
             IRepository<Citizen> citizens,
             IRepository<CitizenApartment> citizenApartments
            )
        {
            DbContext = context;
            ApartmentRepository = apartments;
            ApartmentRepository.DbContext = DbContext;

            CitizenRepository = citizens;
            CitizenRepository.DbContext = DbContext;

            CitizenApartmentRepository = citizenApartments;
            CitizenApartmentRepository.DbContext = DbContext;
        }

        public int SaveChanges()
        {
            var iResult = DbContext.SaveChanges();
            return iResult;
        }

        public async Task<int> SaveChangesAsync()
        {
            var iResult = await DbContext.SaveChangesAsync();
            return iResult;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
