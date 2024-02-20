using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SicoApi.Services.Interface;

namespace SicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("SicoApiRules")]
    public class EstudianteXCursoController : ControllerBase
    {
        private readonly IEstudianteXCurso _ContextEstudianteXCurso;
        public EstudianteXCursoController(IEstudianteXCurso contextEstudianteXCursoController)
        {
            _ContextEstudianteXCurso = contextEstudianteXCursoController;
        }

        [HttpGet]
        [Route("ListadoEstudianteXCurso")]
        public async Task<IActionResult> GetListadoEstudianteXCurso()
        {
            try
            {
                var ListEstudianteXCurso = await _ContextEstudianteXCurso.ObtenerTodos();
                return Ok(ListEstudianteXCurso);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("BuscarPorEstudianteXCurso")]
        public async Task<IActionResult> GetListadoEstudiante(int? id, string? nombre, string? nombreCurso)
        {
            try
            {
                var ListEstudentXCurso = await _ContextEstudianteXCurso.Obtener(id, nombre, nombreCurso);
                return Ok(ListEstudentXCurso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
