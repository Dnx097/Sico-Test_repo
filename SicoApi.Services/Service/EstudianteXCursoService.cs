using Microsoft.EntityFrameworkCore;
using SicoApi.Data.BD_Context;
using SicoApi.Data.Repositories;
using SicoApi.Services.Interface;
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
        private readonly IGenericRepository<Estudiante> _EstudianteRepo;
        private readonly IGenericRepository<Curso> _CursoRepo;
        public EstudianteXCursoService(IGenericRepository<EstudianteXCurso> EstudianteXCursoRepo,
            IGenericRepository<Estudiante> EstudianteRepo,
            IGenericRepository<Curso> CursoRepo)
        {
            _EstudianteXCursoRepo = EstudianteXCursoRepo;
            _EstudianteRepo = EstudianteRepo;
            _CursoRepo = CursoRepo;
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

        public async Task<IQueryable<EstudianteXCurso>> Obtener(int? id, string nombre, string nombreCurso)
        {
            IQueryable<EstudianteXCurso> ListEstudianteXCurso = await _EstudianteXCursoRepo.ObtenerTodos().ConfigureAwait(false);

                
                
            if (!id.HasValue && string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(nombreCurso))
                return null;

            IQueryable<EstudianteXCurso> EstudianteXCurso = ListEstudianteXCurso.Where(x => x.IdEstudiante == (!id.HasValue ? null : id!.Value)
            || x.IdEstudianteNavigation.NombresEstudiante!.ToUpper().Trim().Equals((string.IsNullOrEmpty(nombre) ? null : nombre.ToUpper().Trim()))
            || x.IdCursoNavigation.NombreCurso!.ToUpper().Trim().Equals((string.IsNullOrEmpty(nombreCurso) ? null : nombreCurso.ToUpper().Trim()))
            );

            return EstudianteXCurso;
        }

        public async Task<IQueryable<EstudianteXCurso>> ObtenerTodos()
        {
            return await _EstudianteXCursoRepo.ObtenerTodos();
        }

    }
}
