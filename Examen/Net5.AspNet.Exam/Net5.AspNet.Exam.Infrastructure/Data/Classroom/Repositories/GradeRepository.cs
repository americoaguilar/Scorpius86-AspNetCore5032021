using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Exam.Infrastructure.Data.Base;
using Net5.AspNet.Exam.Infrastructure.Data.Classroom.Contexts;
using Net5.AspNet.Exam.Infrastructure.Data.Classroom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Exam.Infrastructure.Data.Classroom.Repositories
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        private new readonly ClassroomContext _context;
        public GradeRepository(ClassroomContext context) : base(context)
        {
            _context = context;
        }
    }
}
