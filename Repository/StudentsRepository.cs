using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace UniSys.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        // EFCore之執行原生SQL語句
        // https://blog.csdn.net/hbzhlt/article/details/125480470

        private readonly UniSysContext _context;

        public StudentsRepository(UniSysContext context) => _context = context;

        public async Task<int> CreateStudent(Student student)
        {
            SqlParameter[] param = new[]
            {
                new SqlParameter("@Name",student.Name),
                new SqlParameter("@Gender",student.Gender),
                new SqlParameter("@PhoneNumber",student.PhoneNumber as object ?? DBNull.Value),
                new SqlParameter("@Email", student.Email as object ?? DBNull.Value),
                new SqlParameter("@IsDelete",student.IsDelete),
            };

            int request = await _context.Database.ExecuteSqlRawAsync("spCreateStudent @Name,@Gender,@PhoneNumber,@Email, @IsDelete", param);
            return request;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            List<Student> request = await _context.Student
                .FromSqlRaw($"EXEC spGetAllStudents")
                .ToListAsync();

            return request;
        }

        public Student GetStudentByID(int id)
        {
            Student? request = _context.Student
                .FromSqlRaw($"EXEC spGetStudentByID {id}")
                .AsEnumerable()
                .FirstOrDefault()!;

            return request;
        }

        public async Task<int> UpdateStudent(int id, Student student)
        {
            SqlParameter[] param = new[]
            {
                    new SqlParameter("@Student_ID",student.Student_ID),
                    new SqlParameter("@Name",student.Name),
                    new SqlParameter("@Gender",student.Gender),
                    new SqlParameter("@PhoneNumber",student.PhoneNumber as object ?? DBNull.Value),
                    new SqlParameter("@Email",student.Email as object ?? DBNull.Value),
                };
            int result = await _context.Database.ExecuteSqlRawAsync(
                $"EXEC spUpdateStudent @Student_ID, @Name, @Gender, @PhoneNumber, @Email", param);

            return result;
        }

        public async Task<int> SoftDeleteStudent(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC spSoftDelStudent {id}");
            return 0;
        }
    }
}
