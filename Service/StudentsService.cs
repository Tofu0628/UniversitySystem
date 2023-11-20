using UniSys.Repository;
using UniSys.Service.Interface;

namespace UniSys.Service
{
    // refernce source
    // https://dev.to/scorpio69/how-to-web-api-net-core-basics-to-advanced-part-4-service-layer-31gk
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;
        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public async Task<int> CreateStudent(Student student)
        {
            return await _studentsRepository.CreateStudent(student);
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _studentsRepository.GetAllStudents();
        }
        public Student GetStudentByID(int id)
        {
            return _studentsRepository.GetStudentByID(id);
        }
        public async Task<int> UpdateStudent(int id, Student student)
        {
            return await _studentsRepository.UpdateStudent(id,student);
        }

        public async Task<int> SoftDeleteStudent(int id)
        {
            return await _studentsRepository.SoftDeleteStudent(id);
        }


        
    }
}
