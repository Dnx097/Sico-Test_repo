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
    fetch('tu_api_rest/estudiantes')
      .then(response => response.json())
      .then(data => setStudents(data))
      .catch(error => console.error('Error al obtener estudiantes:', error));

    // Obtener lista de cursos desde la API
    fetch('tu_api_rest/cursos')
      .then(response => response.json())
      .then(data => setCourses(data))
      .catch(error => console.error('Error al obtener cursos:', error));
  }, []);

  const openModal = (student) => {
    setSelectedStudent(student);
    setModalIsOpen(true);
  };

  const closeModal = () => {
    setSelectedStudent(null);
    setModalIsOpen(false);
  };

  const addCourseToStudent = (courseId) => {
    // Lógica para agregar un curso al estudiante seleccionado
    // Realiza una solicitud a tu API REST para actualizar la información
    // Puedes usar fetch con el método POST o PUT según tus necesidades
  };

  const removeCourseFromStudent = (courseId) => {
    // Lógica para quitar un curso al estudiante seleccionado
    // Realiza una solicitud a tu API REST para actualizar la información
    // Puedes usar fetch con el método DELETE según tus necesidades
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
        removeCourseFromStudent={removeCourseFromStudent}
      />
    </Container>
  );
};

export default App;
