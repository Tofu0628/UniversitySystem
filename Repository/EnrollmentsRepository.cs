using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UniSys.Models;
using UniSys.Repository.Interface;

namespace UniSys.Repository
{
    public class EnrollmentsRepository : IEnrollmentsRepository
    {
        private readonly UniSysContext _context;
        public EnrollmentsRepository(UniSysContext context) => _context = context;

        public async Task<int> CreateEnrollment(int Student_ID, int Subject_ID)
        {
            
            
            SqlParameter[] param = new[]
            {
                new SqlParameter("@Student_ID", Student_ID),
                new SqlParameter("@Subject_ID", Subject_ID)
            };
            int request = await _context.Database.ExecuteSqlRawAsync("exec spCreateEnrollment @Student_ID, @Subject_ID", param);
            return request;
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            List<Enrollment>? request = await _context.Enrollment
                .FromSqlRaw($"EXEC spGetAllEnrollments")
                .ToListAsync();
            foreach (Enrollment enrollment in request)
            {
                Student? student = _context.Set<Student>()
                    .FirstOrDefault(s => s.Student_ID == enrollment.Student_ID);
                enrollment.Name = student!.Name;

                Subject? subject = _context.Set<Subject>()
                    .FirstOrDefault(s => s.Subject_ID == enrollment.Subject_ID);
                enrollment.Title = subject!.Title;         
            }
            return request;
        }

        public Enrollment GetEnrollmentByID(int id)
        {
            Enrollment? request = _context.Enrollment
                .FromSqlRaw($"EXEC spGetEnrollmentByID {id}")
                .AsEnumerable()
                .FirstOrDefault()!;

            Student? student = _context.Set<Student>()
                    .FirstOrDefault(s => s.Student_ID == request.Student_ID);
            request.Name = student!.Name;

            Subject? subject = _context.Set<Subject>()
                    .FirstOrDefault(s => s.Subject_ID == request.Subject_ID);
            request.Title = subject!.Title;

            return request;
        }

        public async Task<int> UpdateEnrollment(int id,int Student_ID, int Subject_ID)
        {

            SqlParameter outputParam = new()
            {
                ParameterName = "@StatusCode",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            await _context.Database.
                ExecuteSqlRawAsync("EXEC spUpdateEnrollment @Enrollment_ID, @Student_ID, @Subject_ID, @StatusCode OUTPUT",
                new SqlParameter("@Enrollment_ID", id),
                new SqlParameter("@Student_ID", Student_ID),
                new SqlParameter("@Subject_ID", Subject_ID),
            outputParam);

            int result = (int)outputParam.Value;
            return result;
        }

        public async Task<int> GetRemainingEnrollmentSlots(int id)
        {
            SqlParameter outputParam = new()
            {
                ParameterName = "@RemainingSlots",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            await _context.Database
                .ExecuteSqlRawAsync("EXEC spGetRemainingEnrollmentSlots @Student_ID, @RemainingSlots OUTPUT",
                    new SqlParameter("@Student_ID", id),
                    outputParam);

            int remainingSlots = (int)outputParam.Value;
            return remainingSlots;

        }
        
    }
}
