// App.js
import React, { useState, useEffect } from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import StudentList from './Components/StudentList';
import CourseModal from './Components/CourseModal';

const App = () => {
  const [students, setStudents] = useState([]);
  const [selectedStudent, setSelectedStudent] = useState(null);
  const [courses, setCourses] = useState([]);
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    // Obtener lista de estudiantes desde la API
    fetch('https://localhost:7016/api/Estudiante/ListadoTotal')
      .then(response => response.json())
      .then(data => setStudents(data))
      .catch(error => console.error('Error al obtener estudiantes:', error));

    // Obtener lista de cursos desde la API
    fetch('https://localhost:7016/api/Curso/ListadoCursos')
      .then(response => response.json())
      .then(data => setCourses(data))
      .catch(error => console.error('Error al obtener cursos:', error));
  }, []);

  const openModal = (student) => {

    const studentResponse = fetch(`https://localhost:7016/api/EstudianteXCurso/BuscarPorEstudianteXCurso?nombre=${student.nombresEstudiante}`)
      .then(response => response.json())
      .then(data => student.estudianteXCursos = studentResponse.map(item => item.idCurso))
      .catch(error => console.error('Error al obtener información del estudiante:', error));


    // student.estudianteXCursos = studentResponse.map(item => item.idCurso);

    console.log(studentResponse, 'ST')


    setSelectedStudent(student);
    setModalIsOpen(true);

  };
  const closeModal = () => {
    setSelectedStudent(null);
    setModalIsOpen(false);
  };

  const addCourseToStudent = (courseId) => {
    const requestBody = {
      "idEstudiante": selectedStudent.idEstudiante,
      "idCurso": courseId
    };

    fetch('https://localhost:7016/api/EstudianteXCurso/CrearEstudianteXCurso', {
      method: 'PUT',
      body: JSON.stringify(requestBody), 
    })
      .then(response => response.json())
      .then(data => alert(data))
      .catch(error => console.error('Error al realizar la solicitud PUT:', error));

  };



  const handleSearch = (term) => {
    setSearchTerm(term);
  };

  return (
    <Container>
      <Row>
        <Col>
          <h1>Lista de Estudiantes</h1>
          <StudentList
            students={students}
            openModal={openModal}
            searchTerm={searchTerm}
            handleSearch={handleSearch}
          />
        </Col>
      </Row>
      <CourseModal
        isOpen={modalIsOpen}
        closeModal={closeModal}
        selectedStudent={selectedStudent}
        courses={courses}
        addCourseToStudent={addCourseToStudent}
      />
    </Container>
  );
};

export default App;
