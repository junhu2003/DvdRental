import { Form, Row, Col } from 'react-bootstrap';
import ListGroup from 'react-bootstrap/ListGroup';
import { useEffect, useState } from 'react';

export default function Film({ filmFromParent }) {
    const [film, setFilm] = useState(null);

    useEffect(() => {
        setFilm(filmFromParent);
    }, [filmFromParent]);

    const handleChange = (event) => {

    }

    return film && (
        <>
            <Row>
                <Form.Group className="mb-3" controlId="formGridTitle">
                    <Form.Label>Title</Form.Label>
                    <Form.Control placeholder="Title" onChange={handleChange} value={film.title} />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formGridDescription">
                    <Form.Label>Description</Form.Label>
                    <Form.Control as="textarea" rows={2} onChange={handleChange} value={film.description} />
                </Form.Group>
            </Row>
            <Row lg={16}>
                <Form.Group as={Col} lg={2} controlId='formGridReleaseYear'>
                    <Form.Label>Release Year</Form.Label>
                    <Form.Control placeholder='Release Year' onChange={handleChange} value={film.releaseYear} />
                </Form.Group>
                <Form.Group as={Col} lg={2} controlId='formGridLanguage'>
                    <Form.Label>Language</Form.Label>
                    <Form.Control placeholder='Language' onChange={handleChange} value={film.language.name} />
                </Form.Group>
                <Form.Group as={Col} lg={2} controlId='formGridRentalDuration'>
                    <Form.Label>Duration</Form.Label>
                    <Form.Control placeholder='Rental Duration' onChange={handleChange} value={film.rentalDuration} />
                </Form.Group>
                <Form.Group as={Col} lg={2} controlId='formGridRentalRate'>
                    <Form.Label>Rental Rate</Form.Label>
                    <Form.Control placeholder='Rental Rate' onChange={handleChange} value={film.rentalRate} />
                </Form.Group>
                <Form.Group as={Col} lg={2} controlId='formGridLength'>
                    <Form.Label>Length</Form.Label>
                    <Form.Control placeholder='Length' onChange={handleChange} value={film.length} />
                </Form.Group>
                <Form.Group as={Col} lg={2} controlId='formGridReplacementCost'>
                    <Form.Label>Replace Cost</Form.Label>
                    <Form.Control placeholder='Replacement Cost' onChange={handleChange} value={film.replacementCost} />
                </Form.Group>
            </Row>
            <Row>
                <Form.Group as={Col} controlId='formGridCategories' hidden={film.filmCategories === null || film.filmCategories.length == 0}>
                    <Form.Label>Film Categories</Form.Label>                    
                        <ListGroup horizontal>
                            {
                                film.filmCategories && film.filmCategories.length > 0 &&
                                (
                                    film.filmCategories.map(c => <ListGroup.Item key={c.categoryId}>{c.category.name}</ListGroup.Item>)
                                )
                            }
                        </ListGroup>                    
                </Form.Group>
            </Row>
            <Row>
                <Form.Group as={Col} controlId='formGridSpecialFeatues' hidden={film.specialFeatures == null || film.specialFeatures.length == 0}>
                    <Form.Label>Special Featues</Form.Label>                    
                        <ListGroup horizontal>
                            {
                                film.specialFeatures && film.specialFeatures.length > 0 &&
                                (
                                    film.specialFeatures.map((s, index) => <ListGroup.Item key={index}>{s}</ListGroup.Item>)
                                )
                            }
                        </ListGroup>                    
                </Form.Group>
            </Row>
            <Row>
                <Form.Group as={Col} controlId='formGridActors' hidden={film.filmActors === null || film.filmActors.length == 0}>
                    <Form.Label>Film Actors</Form.Label>                    
                        <ListGroup horizontal>
                            {
                                film.filmActors && film.filmActors.length > 0 &&
                                (
                                    film.filmActors.map(a => <ListGroup.Item key={a.actorId}>{a.actor.firstName} {a.actor.lastName}</ListGroup.Item>)
                                )
                            }
                        </ListGroup>                    
                </Form.Group>
            </Row>
        </>
    );
}