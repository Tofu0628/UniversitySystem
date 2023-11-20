namespace UniSys.Repository.Interface
{
    public interface IEnrollmentsRepository
    {
        Task<int> CreateEnrollment(int Student_ID, int Subject_ID);
        Task<IEnumerable<Enrollment>> GetAllEnrollments();
        Enrollment GetEnrollmentByID(int id);
        Task<int> UpdateEnrollment(int id, int Student_ID, int Subject_ID);

        Task<int> GetRemainingEnrollmentSlots(int id);
    }
}