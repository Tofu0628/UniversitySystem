namespace UniSys.Service.Interface
{
    public interface IExamResultsService
    {
        Task<int> CreateExamResult(int Student_ID, int Subject_ID, decimal mark, DateTime examDate);
        Task<IEnumerable<ExamResult>> GetAllExamResults();
        ExamResult GetExamResultByID(int id);
        Task<int> UpdateExamResult(int id, decimal mark, DateTime ExamDate);
        Task<int> SoftDeleteExamResult(int id);

        
    }
}
