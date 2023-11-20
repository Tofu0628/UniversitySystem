using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace UniSys.Repository
{
    public class SubjectsRepository : ISubjectsRepository
    {
        private readonly UniSysContext _context;

        public SubjectsRepository(UniSysContext context) => _context = context;

        public async Task<int> CreateSubject(string Title, int Tutor_ID)
        {
            SqlParameter[] param = new[]
            {
                new SqlParameter("@Title",Title),
                new SqlParameter("@Tutor_ID",Tutor_ID),
                new SqlParameter("@IsDelete",false),
            };
            int request = await _context.Database.ExecuteSqlRawAsync("spCreateSubject @Title,@Tutor_ID,@IsDelete",param);
            return request;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            List<Subject> request = await _context.Subject
                .FromSqlRaw($"EXEC spGetAllSubjects")
                .ToListAsync();

            return request;
        }

        public Subject GetSubjectById(int id)
        {
            Subject? request = _context.Subject
                .FromSqlRaw($"EXEC spGetSubjectByID {id}")
                .AsEnumerable()
                .FirstOrDefault()!;

            return request;
        }
        public async Task<int> UpdateSubject(int id, string Title, int Tutor_ID)
        {
            SqlParameter[] param = new[]
            {
                new SqlParameter("@Subject_ID",id),
                new SqlParameter("@Title",Title.ToString()),
                new SqlParameter("@Tutor_ID",Tutor_ID),
            };
            int request = await _context.Database.ExecuteSqlRawAsync(
                $"EXEC spUpdateSubject @Subject_ID, @Title, @Tutor_ID", param);
            return request;
        }

        public async Task<int> SoftDeleteSubject(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC spSoftDelSubject {id}");
            return 0;
        }

        public IEnumerable<Subject> GetSubjectsForStudent(int id)
        {
            return _context.Subject
                .FromSqlRaw("EXEC spGetSubjectsForStudent @Student_ID", 
                    new SqlParameter("@Student_ID", id))
                .ToList();
        }
        public async Task<IEnumerable<Subject>> GetAvailableSubject(int id)
        {
            return await _context.Subject
                .FromSqlRaw("EXEC spGetAvailableSubject @Student_ID", new SqlParameter("@Student_ID", id))
                .ToListAsync();
        }
    }
}
