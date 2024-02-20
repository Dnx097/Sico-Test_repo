using SicoApi.Data.BD_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicoApi.Services.Interface
{
    public interface IEstudianteXCurso
    {
        Task<bool> Editar(EstudianteXCurso modelo);
        Task<EstudianteXCurso> Obtener(int id);
        Task<IQueryable<EstudianteXCurso>> ObtenerTodos();
        Task<bool> EliminarEstudiante(int idEstudiante, int idCurso);
    }
}
