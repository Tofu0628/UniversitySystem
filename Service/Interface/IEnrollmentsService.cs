namespace UniSys.Service.Interface
{
    public interface IEnrollmentsService
    {
        Task<int> CreateEnrollment(int Student_ID, int Subject_ID);
        Task<IEnumerable<Enrollment>> GetAllEnrollments();
        Enrollment GetEnrollmentByID(int id);
        Task<int> UpdateEnrollment(int id, int Student_ID, int Subject_ID);

        Task<int> GetRemainingEnrollmentSlots(int id);

    }
}