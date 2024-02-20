using System;
using System.Collections.Generic;

namespace StudentCourseAPI.Data.StudentCourseAPI.Data.Models;

public partial class EstudianteXCurso
{
    public int IdEstudianteXCurso { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdCurso { get; set; }

    public virtual Curso? IdCursoNavigation { get; set; }

    public virtual Estudiante? IdEstudianteNavigation { get; set; }
}
