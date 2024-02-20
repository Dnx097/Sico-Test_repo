using StudentCourseAPI.Data.Repositories;
using StudentCourseAPI.Data.StudentCourseAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourseAPI.Services.Services
{
    internal class EstudianteService
    {
        private readonly EstudianteRepository _estudianteRepository;


        public EstudianteService(EstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public IEnumerable<Estudiante> ObtenerTodos()
        {
            return _estudianteRepository.ObtenerTodos();
        }

    }
}
