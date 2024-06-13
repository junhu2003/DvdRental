import React, { useState, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Container from 'react-bootstrap/Container';
import Modal from 'react-bootstrap/Modal';
import Row from 'react-bootstrap/Row';
import Film from './Film';

function RentalDetailModal(props) {
  const [rental, setRental] = useState(null);

  useEffect(() => {
    setRental(props.rentalfromparent);
  }, [props.rentalfromparent]);

  return (
    <Modal {...props} size="lg" aria-labelledby="contained-modal-title-vcenter" centered dialogClassName="modal-70vw">
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
        Rental Details
        </Modal.Title>
      </Modal.Header>
      <Modal.Body className="grid-example">
        <Container>
          <Row hidden={rental === null || rental.inventory === null || rental.inventory.film === null}>
            {
              rental && rental.inventory && rental.inventory.film && <Film filmFromParent={rental.inventory.film} />
            }
          </Row>
        </Container>
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={props.onHide}>Close</Button>
      </Modal.Footer>
    </Modal>
  );
}

export default RentalDetailModal;