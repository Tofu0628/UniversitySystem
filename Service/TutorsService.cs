using UniSys.Repository;
using UniSys.Service.Interface;

namespace UniSys.Service
{
    public class TutorsService : ITutorsService
    {
        private readonly ITutorsRepository _tutorsrepository;
        public TutorsService(ITutorsRepository turorsrepository)
        {
            _tutorsrepository = turorsrepository;
        }
        public async Task<int> CreateTutor(Tutor tutor)
        {
            return await _tutorsrepository.CreateTutor(tutor);
        }

        public async Task<IEnumerable<Tutor>> GetAllTutors()
        {
            return await _tutorsrepository.GetAllTutors();
        }

        public Tutor GetTutorByID(int id)
        {
            return _tutorsrepository.GetTutorByID(id);
        }

        public async Task<int> UpdateTutor(Tutor tutor)
        {
            return await _tutorsrepository.UpdateTutor(tutor);
        }
        public async Task<int> SoftDeleteTutor(int id)
        {
            return await _tutorsrepository.SoftDeleteTutor(id);
        }  
    }
}
