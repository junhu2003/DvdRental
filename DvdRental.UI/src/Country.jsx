import { Form, Row, Col } from 'react-bootstrap';
import { useEffect, useState } from 'react';

export default function Country({ countryFromParent }) {
    const [country, setCountry] = useState(null);

    useEffect(() => {
        setCountry(countryFromParent);
    }, [countryFromParent]);

    const handleChange = (event) => {

    }

    return country && (
        <>
            <Row>
                <Form.Group as={Col} controlId='formGridCountry'>
                    <Form.Label>Country</Form.Label>
                    <Form.Control placeholder='Country' onChange={handleChange} value={country.country1} />                    
                </Form.Group>                
            </Row>            
        </>
    );
}