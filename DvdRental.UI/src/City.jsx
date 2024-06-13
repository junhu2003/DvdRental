import { Form, Row, Col } from 'react-bootstrap';
import { useEffect, useState } from 'react';
import Country from './Country';

export default function City({ cityFromParent }) {
    const [city, setCity] = useState(null);

    useEffect(() => {
        setCity(cityFromParent);
    }, [cityFromParent]);

    const handleChange = (event) => {

    }

    return city && (
        <>
            <Row>
                <Form.Group as={Col} controlId='formGridCity'>
                    <Form.Label>City</Form.Label>
                    <Form.Control placeholder='City' onChange={handleChange} value={city.city1} />                    
                </Form.Group>  
                <Form.Group as={Col} controlId='formGridCountry'>
                    {
                        city.country && <Country countryFromParent={city.country} />
                    }
                </Form.Group>              
            </Row>            
        </>
    );
}