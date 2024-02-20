using SicoApi.Data.BD_Context;
using SicoApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Services.Service
{
    public class EstudianteService : Interface.IEstudiante
    {
        private readonly IGenericRepository<Estudiante> _EstudianteRepo;
        public EstudianteService(IGenericRepository<Estudiante> EstudianteRepo)
        {
            _EstudianteRepo = EstudianteRepo;
        }
        public async Task<bool> Editar(Estudiante modelo)
        {
            return await _EstudianteRepo.Editar(modelo);
        }

        public async Task<bool> Eliminar(Estudiante modelo)
        {
            return await _EstudianteRepo.Eliminar(modelo);
        }

        public async Task<Estudiante> Obtener(int id)
        {
            return await _EstudianteRepo.Obtener(id);
        }

        public async Task<IQueryable<Estudiante>> ObtenerTodos()
        {
            return await _EstudianteRepo.ObtenerTodos();
        }
    }
}
