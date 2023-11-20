using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace UniSys.Repository
{
    public class TutorsRepository : ITutorsRepository
    {
        private readonly UniSysContext _context;

        public TutorsRepository(UniSysContext context)=> _context = context;

        public async Task<int> CreateTutor(Tutor tutor)
        {
            SqlParameter[] param = new[]
            {
                new SqlParameter("@Name", tutor.Name),
                new SqlParameter("@Position", tutor.Position),
                new SqlParameter("@Gender",tutor.Gender),
                new SqlParameter("@PhoneNumber",tutor.PhoneNumber as object ?? DBNull.Value),
                new SqlParameter("@Email",tutor.Email as object ?? DBNull.Value),
                new SqlParameter("@IsDelete",tutor.IsDelete),
            };

            int request = await _context.Database.ExecuteSqlRawAsync("spCreateTutor @Name, @Position, @Gender, @PhoneNumber, @Email, @IsDelete", param);
            return request;
        }

        public async Task<IEnumerable<Tutor>> GetAllTutors()
        {
            List<Tutor> request = await _context.Tutor
                .FromSqlRaw($"EXEC spGetAllTutors")
                .ToListAsync();
            return request;
        }

        public Tutor GetTutorByID(int id)
        {
            Tutor? request = _context.Tutor
                .FromSqlRaw($"EXEC spGetTutorByID {id}")
                .AsEnumerable()
                .FirstOrDefault()!;
            return request;
        }

        public async Task<int> UpdateTutor(Tutor tutor)
        {
            SqlParameter[] param = new[]
            {
                new SqlParameter("@Tutor_ID",tutor.Tutor_ID),
                new SqlParameter("@Name", tutor.Name),
                new SqlParameter("@Position", tutor.Position),
                new SqlParameter("@Gender",tutor.Gender),
                new SqlParameter("@PhoneNumber",tutor.PhoneNumber as object ?? DBNull.Value),
                new SqlParameter("@Email",tutor.Email as object ?? DBNull.Value),
            };
            int result = await _context.Database.ExecuteSqlRawAsync(
                $"EXEC spUpdateTutor @Tutor_ID, @Name, @Position, @Gender, @PhoneNumber, @Email", param);
            return result;
        }

        public async Task<int> SoftDeleteTutor(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC spSoftDelTutor {id}");
            return 0;
        }

        
    }
}
