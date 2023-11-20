﻿namespace UniSys.Service.Interface
{
    public interface ISubjectsService
    {
        Task<int> CreateSubject(string Title, int Tutor_ID);
        Task<IEnumerable<Subject>> GetAllSubjects();
        Subject GetSubjectByID(int id);
        Task<int> UpdateSubject(int id, string Title, int Tutor_ID);
        Task<int> SoftDeleteSubject(int id);

        IEnumerable<Subject> GetSubjectsForStudent(int id);
        Task<IEnumerable<Subject>> GetAvailableSubject(int id);
    }
}
