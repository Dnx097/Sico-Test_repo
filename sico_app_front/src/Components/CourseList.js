// CourseList.js
import React from 'react';
import { ListGroup, Button } from 'react-bootstrap';

export default function CourseList ({ courses, addCourseToStudent, removeCourseFromStudent }) {
  return (
    <ListGroup>
      {courses.map(course => (
        <ListGroup.Item key={course.id}>
          {course.name}
          <Button variant="success" onClick={() => addCourseToStudent(course.id)}>Agregar</Button>
          <Button variant="danger" onClick={() => removeCourseFromStudent(course.id)}>Quitar</Button>
        </ListGroup.Item>
      ))}
    </ListGroup>
  );
};

