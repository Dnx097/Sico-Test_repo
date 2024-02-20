using Microsoft.EntityFrameworkCore;
using SicoApi.Data.BD_Context;
using SicoApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Services.Service
{
    public class EstudianteXCursoService : Interface.IEstudianteXCurso
    {
        private readonly IGenericRepository<EstudianteXCurso> _EstudianteXCursoRepo;
        public EstudianteXCursoService(IGenericRepository<EstudianteXCurso> EstudianteXCursoRepo)
        {
            _EstudianteXCursoRepo = EstudianteXCursoRepo;
        }
        public async Task<bool> Editar(EstudianteXCurso modelo)
        {
            return await _EstudianteXCursoRepo.Editar(modelo);
        }

        public async Task<bool> EliminarEstudiante(int idEstudiante, int idCurso)
        {
            try
            {
                IQueryable<EstudianteXCurso> Query = await _EstudianteXCursoRepo.ObtenerTodos();
                EstudianteXCurso estudianteXCurso = Query.FirstOrDefault(x => x.IdEstudiante.Equals(idEstudiante) && x.IdCurso.Equals(idCurso));

                if (estudianteXCurso != null)
                {
                    _EstudianteXCursoRepo.Eliminar(estudianteXCurso);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }

        public async Task<EstudianteXCurso> Obtener(int id)
        {
            return await _EstudianteXCursoRepo.Obtener(id);
        }

        public async Task<IQueryable<EstudianteXCurso>> ObtenerTodos()
        {
            return await _EstudianteXCursoRepo.ObtenerTodos();
        }
    }
}
