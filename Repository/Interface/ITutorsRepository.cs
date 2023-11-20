namespace UniSys.Repository
{
    public interface ITutorsRepository
    {
        Task<int> CreateTutor(Tutor tutor);
        Task<IEnumerable<Tutor>> GetAllTutors();
        Tutor GetTutorByID(int id);
        Task<int> UpdateTutor(Tutor tutor);
        Task<int> SoftDeleteTutor(int id);
    }
}
