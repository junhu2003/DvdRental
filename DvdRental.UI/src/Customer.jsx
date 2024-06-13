import { Form, Row, Col } from 'react-bootstrap';
import { useEffect, useState } from 'react';
import Address from './Address';

export default function Customer({ customerFromParent }) {
    const [customer, setCustomer] = useState(null);

    useEffect(() => {
        setCustomer(customerFromParent);
    }, [customerFromParent]);

    const handleChange = (event) => {

    }

    return customer && (
        <>
            <Row lg={10}>
                <Form.Group as={Col} lg={3} controlId='formGridFirstName'>
                    <Form.Label>First Name</Form.Label>
                    <Form.Control placeholder='First Name' onChange={handleChange} key={customer.firstName} value={customer.firstName} />
                </Form.Group>
                <Form.Group as={Col} lg={3} controlId='formGridLastName'>
                    <Form.Label>Last Name</Form.Label>
                    <Form.Control placeholder='Last Name' onChange={handleChange} value={customer.lastName} />
                </Form.Group>
                <Form.Group as={Col} lg={5} controlId='formGridEmail'>
                    <Form.Label>Email</Form.Label>
                    <Form.Control placeholder='Email' onChange={handleChange} value={customer.email} />
                </Form.Group>
                <Form.Group as={Col} lg={1} controlId='formGridActive'>
                    <Form.Label>Active</Form.Label>
                    <Form.Check placeholder='Active' onChange={handleChange} checked={customer.activebool ? true : false} />
                </Form.Group>
            </Row>
            <Row>
                {
                    customer.address && <Address addressFromParent={customer.address} />
                }
            </Row>
        </>
    );
}