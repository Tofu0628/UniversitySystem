namespace UniSys.Service.Interface
{
    public interface IStudentsService
    {
        Task<int> CreateStudent(Student student);
        Task<IEnumerable<Student>> GetAllStudents();
        Student GetStudentByID(int id);
        Task<int> UpdateStudent(int id, Student student);
        Task<int> SoftDeleteStudent(int id);
    }
}