namespace DiariesForPractice.Domain.Services.Users
{
    public interface IUserEditorService
    {
        IReadOnlyCollection<int> AddOrUpdateStudents(IReadOnlyCollection<Student> students, int groupId);
        int AddOrUpdateStudent(Student student, int groupId);
    }
}