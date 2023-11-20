using UniSys.Repository;
using UniSys.Service.Interface;

namespace UniSys.Service
{
    public class SubjectsService : ISubjectsService
    {
        private readonly ISubjectsRepository _subjectsRepository;

        public SubjectsService(ISubjectsRepository subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
        }
        public async Task<int> CreateSubject(string subject, int Tutor_ID)
        {
            return await _subjectsRepository.CreateSubject(subject, Tutor_ID);
        }
        public Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return _subjectsRepository.GetAllSubjects();
        }

        public Subject GetSubjectByID(int id)
        {
            return _subjectsRepository.GetSubjectById(id);
        }

        public async Task<int> UpdateSubject(int id, string subject, int Tutor_ID)
        {
            return await _subjectsRepository.UpdateSubject(id,subject,Tutor_ID);
        }
        public async Task<int> SoftDeleteSubject(int id)
        {
            return await _subjectsRepository.SoftDeleteSubject(id);
        }

        public IEnumerable<Subject> GetSubjectsForStudent(int id)
        {
            return _subjectsRepository.GetSubjectsForStudent(id);
        }

        public async Task<IEnumerable<Subject>> GetAvailableSubject(int id)
        {
           return await _subjectsRepository.GetAvailableSubject(id);
        }
    }
}
