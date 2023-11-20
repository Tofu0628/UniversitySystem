using UniSys.Repository;
using UniSys.Service.Interface;

namespace UniSys.Service
{
    public class ExamResultsService : IExamResultsService
    {
        private readonly IExamResultsRepository _examResultsRepository;

        public ExamResultsService(IExamResultsRepository examResultsRepository)
        {
            _examResultsRepository = examResultsRepository;
        }
        public async Task<int> CreateExamResult(int Student_ID, int Subject_ID, decimal mark, DateTime examDate)
        {
            return await _examResultsRepository.CreateExamResult(Student_ID, Subject_ID, mark, examDate);
        }

        public ExamResult GetExamResultByID(int id)
        {
            return _examResultsRepository.GetExamResultByID(id);
        }

        public async Task<IEnumerable<ExamResult>> GetAllExamResults()
        {
            return await _examResultsRepository.GetAllExamResults();
        }

        public async Task<int> UpdateExamResult(int id, decimal mark, DateTime ExamDate)
        {
            return await _examResultsRepository.UpdateExamResult(id, mark, ExamDate);
        }

        public async Task<int> SoftDeleteExamResult(int id)
        {
            return await _examResultsRepository.SoftDeleteExamResult(id);
        }

        
    }
}
