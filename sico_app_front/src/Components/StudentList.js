// StudentList.js
import React from 'react';
import { ListGroup, Button, Form } from 'react-bootstrap';

export default function StudentList ({ students, openModal, searchTerm, handleSearch }) {
    const filteredStudents = students.filter(student =>
        student.name.toLowerCase().includes(searchTerm.toLowerCase())
    );

    return (
        <div>
            <Form.Group controlId="search">
                <Form.Label className='mx-2'>Buscar Estudiantes:</Form.Label>
                <Form.Control
                    className='ml-2'
                    type="text"
                    placeholder="Ingrese el nombre del estudiante"
                    value={searchTerm}
                    onChange={(e) => handleSearch(e.target.value)}
                />
            </Form.Group>
            <ListGroup>
                {filteredStudents.map(student => (
                    <ListGroup.Item key={student.id}>
                        {student.name}
                        <Button type='button' variant="primary" onClick={() => openModal(student)}>Administrar Cursos</Button>
                    </ListGroup.Item>
                ))}
            </ListGroup>
        </div>
    );
};

