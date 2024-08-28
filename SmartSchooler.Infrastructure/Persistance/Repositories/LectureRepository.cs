using Microsoft.EntityFrameworkCore;
using SmartSchooler.Domain.Entities;
using SmartSchooler.Domain.Repositories;


namespace SmartSchooler.Infrastructure.Persistance.Repositories
{
    internal sealed class LectureRepository : ILectureRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LectureRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public void Add(Lecture Lecture) => _dbContext.Lectures.Add(Lecture);

        public void Delete(Lecture Lecture) => _dbContext.Lectures.Remove(Lecture);

        public Task<Lecture> EnrollStudent(Student student, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Lecture>> ListAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Lectures.Include(x => x.Subject).Include(m => m.LectureTheatre).ToListAsync(cancellationToken);

        public async Task<Lecture> GetByIdAsync(int Id, CancellationToken cancellationToken = default) =>
            await _dbContext.Lectures.Include(x => x.Subject).Include(m => m.LectureTheatre).FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
    }
}
