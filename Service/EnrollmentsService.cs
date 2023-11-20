using UniSys.Repository.Interface;
using UniSys.Service.Interface;

namespace UniSys.Service
{
    public class EnrollmentsService : IEnrollmentsService
    {
        private readonly IEnrollmentsRepository _enrollmentRepository;
        public EnrollmentsService(IEnrollmentsRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<int> CreateEnrollment(int Student_ID, int Subject_ID)
        {
            return await _enrollmentRepository.CreateEnrollment(Student_ID,Subject_ID);
        }

        public Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            return _enrollmentRepository.GetAllEnrollments();
        }

        public Enrollment GetEnrollmentByID(int id)
        {
            return _enrollmentRepository.GetEnrollmentByID(id);
        }

        public async Task<int> UpdateEnrollment(int id, int Student_ID, int Subject_ID)
        {
            return await _enrollmentRepository.UpdateEnrollment(id, Student_ID, Subject_ID);
        }
        public async Task<int> GetRemainingEnrollmentSlots(int id)
        {
            return await _enrollmentRepository.GetRemainingEnrollmentSlots(id);
        }

    }
}