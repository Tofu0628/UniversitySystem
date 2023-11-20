namespace UniSys.Service.Interface
{
    public interface ITutorsService
    {
        Task<int> CreateTutor(Tutor tutor);
        Task<IEnumerable<Tutor>> GetAllTutors();
        Tutor GetTutorByID(int id);
        Task<int> UpdateTutor(Tutor tutor);
        Task<int> SoftDeleteTutor(int id);
    }
}
