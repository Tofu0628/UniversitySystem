using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace UniSys.Repository
{
    public class ExamResultsRepository : IExamResultsRepository
    {
        private readonly UniSysContext _context;

        public ExamResultsRepository(UniSysContext context)
        {
            _context = context;
        }
        public async Task<int> CreateExamResult(int Student_ID, int Subject_ID, decimal mark, DateTime examDate)
        {
            SqlParameter[] param = new[]
            {
            new SqlParameter("@Student_ID", Student_ID),
            new SqlParameter("@Subject_ID", Subject_ID),
            new SqlParameter("@Mark", mark),
            new SqlParameter("@ExamDate", examDate),
            new SqlParameter("@IsDelete", false),
            new SqlParameter("@Status", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                }
            };

            await _context.Database.ExecuteSqlRawAsync("EXEC spCreateExamResult @Student_ID, @Subject_ID, @Mark, @ExamDate, @IsDelete, @Status OUTPUT",
               param);

            int status = (int)param[5].Value;

            return status;
        }

        public async Task<IEnumerable<ExamResult>> GetAllExamResults()
        {
            List<ExamResult> request = await _context.ExamResult
            .FromSqlRaw($"EXEC spGetAllExamResults")
            .ToListAsync();

            foreach (ExamResult? examResult in request)
            {
                var enrollmentInfo = await _context.Enrollment
                    .Where(e => e.Enrollment_ID == examResult.Enrollment_ID)
                    .Select(e => new
                    {
                        e.Student_ID,
                        e.Subject_ID,
                        e.Student!.Name,
                        e.Subject!.Title
                    })
                    .FirstOrDefaultAsync();

                    examResult.Student_ID = enrollmentInfo!.Student_ID;
                    examResult.Subject_ID = enrollmentInfo!.Subject_ID;
                    examResult.Name = enrollmentInfo.Name;
                    examResult.Title = enrollmentInfo.Title;
            }
            return request;
        }

        public ExamResult GetExamResultByID(int id)
        {
            ExamResult? request = _context.ExamResult
                .FromSqlRaw($"EXEC spGetExamResultByID {id}")
                .AsEnumerable()
                .FirstOrDefault()!;

            var enrollmentInfo = _context.Enrollment
                .Where(e => e.Enrollment_ID == request.Enrollment_ID)
                .Select(e => new
                {
                    e.Student_ID,
                    e.Subject_ID,
                    e.Student!.Name,
                    e.Subject!.Title
                })
                .FirstOrDefault();

                request.Student_ID = enrollmentInfo!.Student_ID;
                request.Subject_ID = enrollmentInfo!.Subject_ID;
                request.Name = enrollmentInfo.Name;
                request.Title = enrollmentInfo.Title;

            return request;
        }
        public async Task<int> UpdateExamResult(int id, decimal mark, DateTime examDate)
        {
            SqlParameter[] param = new[]
            {
                new SqlParameter("@Exam_ID",id),
                new SqlParameter("@Mark",mark),
                new SqlParameter("@ExamDate",examDate)
            };
            int request = await _context.Database.ExecuteSqlRawAsync($"EXEC spUpdateExamResult @Exam_ID, @Mark, @ExamDate", param);
            return request;
        }

        public async Task<int> SoftDeleteExamResult(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC spSoftDelExamResult {id}");
            return 0;
        }
    }
}
