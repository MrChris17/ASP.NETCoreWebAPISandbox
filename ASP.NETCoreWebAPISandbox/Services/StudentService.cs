using ASP.NETCoreWebAPISandbox.DTO;
using ASP.NETCoreWebAPISandbox.Repositories;

namespace ASP.NETCoreWebAPISandbox.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDTO> AddStudentAsync(StudentDTO studentDTO)
        {
            var student = _studentRepository.AddAsync(studentDTO);
        }

        public Task<bool> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StudentDTO?> UpdateStudentAsync(int id, StudentDTO studentDTO)
        {
            throw new NotImplementedException();
        }
    }
}
