using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly RepositoryContext _context; 
        private readonly Lazy<ICourseRepository> _courseRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _courseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(_context));
        }

        public ICourseRepository Course=> _courseRepository.Value;

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
