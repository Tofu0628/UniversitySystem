using Microsoft.EntityFrameworkCore;

namespace UniSys.Data
{
    public class UniSysContext : DbContext
    {
        public UniSysContext (DbContextOptions<UniSysContext> options)
            : base(options)
        { }

        public DbSet<Student> Student { get; set; }
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<ExamResult> ExamResult { get; set; }

        // TODO: solve add more tutor to subject relation

        //public DbSet<SubjectTutor> SubjectTutor { get; set; }
    }
}
