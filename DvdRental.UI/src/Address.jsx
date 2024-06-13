import { Form, Row, Col } from 'react-bootstrap';
import { useEffect, useState } from 'react';
import City from './City';

export default function Address({ addressFromParent }) {
    const [address, setAddress] = useState(null);

    useEffect(() => {
        setAddress(addressFromParent);
    }, [addressFromParent]);

    const handleChange = (event) => {

    }

    return address && (
        <>
            <Row>
                <Form.Group as={Col} controlId='formGridAddress1'>
                    <Form.Label>Address1</Form.Label>
                    <Form.Control placeholder='Address1' onChange={handleChange} value={address.address1} />                    
                </Form.Group>
                <Form.Group as={Col} controlId='formGridAddress2'>
                    <Form.Label>Address2</Form.Label>
                    <Form.Control placeholder='Address2' onChange={handleChange} value={address.address2} />
                </Form.Group>                
            </Row>            
            <Row>                
                <Form.Group as={Col} controlId='formGridDistrict'>
                    <Form.Label>District</Form.Label>
                    <Form.Control placeholder='District' onChange={handleChange} value={address.district} />
                </Form.Group>
                <Form.Group as={Col} controlId='formGridPostCode'>
                    <Form.Label>Post Code</Form.Label>
                    <Form.Control placeholder='Post Code' onChange={handleChange} value={address.postalCode} />
                </Form.Group>                
                <Form.Group as={Col} controlId='formGridPhone'>
                    <Form.Label>Phone</Form.Label>
                    <Form.Control placeholder='Phone' onChange={handleChange} value={address.phone} />
                </Form.Group>
            </Row>
            <Row>
                <Form.Group as={Col} controlId='formGridCity'>
                    {
                        address.city && <City cityFromParent={address.city} />
                    }
                </Form.Group>                
            </Row>
        </>
    );
}