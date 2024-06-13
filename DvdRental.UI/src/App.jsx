import { useState, useRef } from 'react'
import './App.css'
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import InputGroup from 'react-bootstrap/InputGroup';
import Spinner from 'react-bootstrap/Spinner';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import Alert from 'react-bootstrap/Alert';
import { ApplicationApi } from './applicationApi';
import { useEffect } from 'react';
import { ButtonGroup } from 'react-bootstrap';
import Accordion from 'react-bootstrap/Accordion';
import AccordionBody from 'react-bootstrap/esm/AccordionBody';
import Table from 'react-bootstrap/Table';
import TableContainer from 'react-bootstrap/TabContainer';
import Customer from './Customer';
import RentalDetailModal from './RentalDetailModal';

function App() {  
  const [inputs, setInputs] = useState({ firstName: '', lastName: '', email: ''});
  const [customers, setCustomers] = useState([]);
  const [customer, setCustomer] = useState(null);
  const [rental, setRental] = useState(null);
  const [error, setError] = useState(false);
  const [validated, setValidated] = useState(false);
  const [isLoading, setLoading] = useState(false);
  const [modalShow, setModalShow] = useState(false);
  const calcFormRef = useRef(null);

  const handleChange = (event) => {
    const name = event.target.name;
    const value = event.target.value;
    setInputs(values => ({ ...values, [name]: value }));
  }

  useEffect(() => {
    const debounce = setTimeout(() => {
        populateCustomers();

    }, 1000)
    return () => clearTimeout(debounce);
  }, [inputs.firstName, inputs.lastName, inputs.email]);

  const handleCustomerChange = (event) => {    
    const customerId = event.target.value;
    
    if (customerId > 0) {
      setLoading(true);

      ApplicationApi.gerRentalsByCustomer(customerId)
      .then((json) => {
        setCustomer(null);
        setCustomer(json);                
      })
      .catch((error) => {
        console.log("error", error);
        setError(true);
      }).finally(() => {
        setLoading(false);
      });      
    } else {
      setCustomer(null);
    }
    
  }

  const handleScroll = (event) => {
    console.log(event);
  }

  const populateCustomers = () => {
    
    ApplicationApi.getCustomers(inputs.firstName, inputs.lastName, inputs.email)
        .then((json) => {
            json ? setCustomers(json) : []
            setCustomer(null);
        })
        .catch(() => { 
          setCustomers([]);
          setCustomer(null);
        });    
  }

  const handleButtonClick = (rentalId) => {
    if (rentalId > 0) {
      setLoading(true);

      ApplicationApi.getFilmByRental(rentalId)
      .then((json) => {
        setRental(null);
        setRental(json);

        // show RentalDetailModal
        setModalShow(true)
      })
      .catch((error) => {
        console.log("error", error);
        setError(true);
      }).finally(() => {
        setLoading(false);
      });      
    } else {
      setRental(null);
    }
  }

  return (
    <Tabs defaultActiveKey="coverage" id="uncontrolled-tab-example" className="mb-3">
      <Tab eventKey="Customer" title="Customer">
        {error &&
          <Row>
            <Col>
              <Alert variant='danger' onClose={() => setError(false)} dismissible>
                An error has occured.
              </Alert>
            </Col>
          </Row>
        }
        <Form noValidate validated={validated} ref={calcFormRef}>
          <Row>
            <Col lg="16">
              <InputGroup>
                
                <Form.Group as={Col} lg="2" controlId="validationCustom01">
                  <Form.Control
                    type="text"
                    name="firstName"
                    placeholder="First Name"
                    value={inputs.firstName || ''}
                    onChange={handleChange}                                      
                  />
                  <Form.Control.Feedback type="invalid">
                    Please enter first name.
                  </Form.Control.Feedback>
                </Form.Group>
                
                <Form.Group as={Col} lg="2" controlId="validationCustom02">
                  <Form.Control
                    type="text"
                    name="lastName"
                    placeholder="Last Name"
                    value={inputs.lastName || ''}
                    onChange={handleChange}                                      
                  />
                  <Form.Control.Feedback type="invalid">
                    Please enter last name.
                  </Form.Control.Feedback>
                </Form.Group>
                
                <Form.Group as={Col} lg="3" controlId="validationCustom03">
                  <Form.Control
                    type="text"
                    name="email"
                    placeholder="Email"
                    value={inputs.email || ''}
                    onChange={handleChange}                                      
                  />
                  <Form.Control.Feedback type="invalid">
                    Please enter email.
                  </Form.Control.Feedback>                                  
                </Form.Group>
                
                <Form.Group as={Col} lg="5" controlId="validationCustom04">
                  <Form.Select
                      as="select"
                      name="customers"
                      placeholder="Customer"
                      value={customer ? customer.customerId : 0}
                      onChange={handleCustomerChange}
                      onScrollCapture={handleScroll}
                      disabled={customers.length === 0}                      
                  >
                      <option value="0" key="0">Select Customer</option>
                      {customers && customers.map((c, i) => <option key={i + 1} value={c.customerId}>{c.firstName} {c.lastName} - {c.email}</option>)}
                  </Form.Select>
                  
                </Form.Group>
              </InputGroup>
            </Col>
            
          </Row>

        </Form>
        <br />
        <Accordion defaultActiveKey="2" alwaysOpen="true" hidden={customer === null}>
          <Accordion.Item eventKey="Customer">
            <Accordion.Header>Customer</Accordion.Header>
            <AccordionBody>
              <TableContainer>                
                {                  
                  customer && <Customer customerFromParent={customer} />
                }
              </TableContainer>
            </AccordionBody>
          </Accordion.Item>
        </Accordion>
        <Accordion defaultActiveKey="2" alwaysOpen="true" hidden={customer === null || customer.rentals === null || customer.rentals.length == 0}>
          <Accordion.Item eventKey="RentalItems">
            <Accordion.Header>Rental Items</Accordion.Header>
            <AccordionBody>
              <TableContainer>
              <Table as="table" striped bordered hover responsive size="sm">
                <thead>
                    <tr>
                      <th></th>
                      <th>Rental Date</th>
                      <th>Return Date</th>
                      <th>Payment</th>
                      <th>Payment Date</th>
                    </tr>
                </thead>
                <tbody>                  
                  {
                    customer != null && customer.rentals != null && 
                    customer.rentals.map(r => 
                      <tr key={r.rentalId}>
                        <td>
                          <Button type="button" disabled={isLoading} onClick={() => handleButtonClick(r.rentalId)}>View Details</Button>
                        </td>
                        <td>
                          {r.rentalDate}
                        </td>
                        <td>{r.returnDate}</td>
                        <td>
                          { 
                            customer.payments.find(x => x.rentalId === r.rentalId) ? customer.payments.find(x => x.rentalId === r.rentalId).amount : ''
                          }
                        </td>
                        <td>
                          { 
                            customer.payments.find(x => x.rentalId === r.rentalId) ? customer.payments.find(x => x.rentalId === r.rentalId).paymentDate : ''
                          }
                        </td>
                      </tr>
                    )
                  }
                </tbody>
            </Table>
              </TableContainer>
            </AccordionBody>
          </Accordion.Item>
        </Accordion>
        
        <RentalDetailModal rentalfromparent={rental} show={modalShow} onHide={() => rental && setModalShow(false)} />
      </Tab>      

      <Tab eventKey="Film" title="Film">
                
      </Tab>
    </Tabs>
  )
}

export default App
