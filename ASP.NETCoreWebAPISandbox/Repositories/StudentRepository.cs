using ASP.NETCoreWebAPISandbox.Data;
using ASP.NETCoreWebAPISandbox.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebAPISandbox.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public async Task<Student> AddAsync(Student student)
        {
            await _studentDbContext.Student.AddAsync(student);
            await _studentDbContext.SaveChangesAsync();

            return student;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _studentDbContext.Student.FindAsync(id);

            if (student == null)
            {
                return false;
            }

            _studentDbContext.Student.Remove(student);
            await _studentDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentDbContext.Student
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentDbContext.Student
                .AsNoTracking()
                .FirstOrDefaultAsync(student => student.Id == id);
        }

        public async Task<Student?> UpdateAsync(Student student)
        {
            var currentStudent = await _studentDbContext.Student.FindAsync(student.Id);

            if(currentStudent == null)
            {
                return null;
            }

            currentStudent.Name = student.Name;
            await _studentDbContext.SaveChangesAsync();

            return currentStudent;
        }
    }
}
