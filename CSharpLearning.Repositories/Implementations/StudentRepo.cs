using CSharpLearning.Entities;
using CSharpLearning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Repositories.Implementations
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext _context;

        public StudentRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Edit(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.Include(a=>a.StudentSkills).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveData(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task Save(Student student)
        {
           await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }
}
