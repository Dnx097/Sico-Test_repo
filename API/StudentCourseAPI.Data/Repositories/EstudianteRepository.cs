using StudentCourseAPI.Data.StudentCourseAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseAPI.Data.Repositories
{
    public class EstudianteRepository
    {
        private readonly SicoTestContext _sicoTestContext;

        public EstudianteRepository (SicoTestContext sicoTestContext)
        {
            _sicoTestContext = sicoTestContext;
        }

        public IEnumerable<Estudiante> ObtenerTodos()
        {
            return _sicoTestContext.Estudiantes.ToList();
        }



    }
}
