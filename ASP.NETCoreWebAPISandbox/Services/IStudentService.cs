using ASP.NETCoreWebAPISandbox.DTO;

namespace ASP.NETCoreWebAPISandbox.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO?> GetStudentByIdAsync(int id);
        Task<StudentDTO> AddStudentAsync(StudentDTO studentDTO);
        Task<StudentDTO?> UpdateStudentAsync(int id, StudentDTO studentDTO);
        Task<bool> DeleteStudentAsync(int id);
    }
}
