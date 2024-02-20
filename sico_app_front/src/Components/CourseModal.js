// CourseModal.js
import React from 'react';
import { Modal, Button } from 'react-bootstrap';
import CourseList from './CourseList';

export default function CourseModal ({ isOpen, closeModal, selectedStudent, courses, addCourseToStudent, removeCourseFromStudent }) {
  return (
    <Modal show={isOpen} onHide={closeModal}>
      <Modal.Header closeButton>
        <Modal.Title>{selectedStudent ? `Cursos de ${selectedStudent.name}` : ''}</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <CourseList
          courses={courses}
          addCourseToStudent={addCourseToStudent}
          removeCourseFromStudent={removeCourseFromStudent}
        />
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={closeModal}>Cerrar</Button>
      </Modal.Footer>
    </Modal>
  );
};

