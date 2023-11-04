import React from 'react';
import { Row, Col, Card } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
import CsLineIcons from 'cs-line-icons/CsLineIcons';
import { localization } from 'lang/localization';

const PagesPage = () => {
  const title = 'Pages';
  const description = 'Layouts that are focused on different project needs. Contains html blocks and specific plugins that are fit for the context.';

  const breadcrumbs = [{ to: '', text: 'Home' }];

  return (
    <>

      {/* List Items Start */}
      <Row xs="1" sm="2" xl="3" className="g-2">
        <Col>
          <Card className="h-100">
            <Card.Body className="row gx-4">
              <Col xs="auto">
                <CsLineIcons icon="lock-on" className="text-primary" />
              </Col>
              <Col>
                <NavLink to="/adminCompanies" className="heading stretched-link d-block">
                  {localization.strings().companyDefinition}
                </NavLink>
                <div className="text-muted">User verification, registration and recovery pages.</div>
              </Col>
            </Card.Body>
          </Card>
        </Col>
        <Col>
          <Card className="h-100">
            <Card.Body className="row gx-4">
              <Col xs="auto">
                <CsLineIcons icon="content" className="text-primary" />
              </Col>
              <Col>
                <NavLink to="/adminWorkplaces" className="heading stretched-link d-block">
                  {localization.strings().shopDefinition}
                </NavLink>
                <div className="text-muted">Multiple blog pages for home, detail and listing layouts.</div>
              </Col>
            </Card.Body>
          </Card>
        </Col>
        <Col>
          <Card className="h-100">
            <Card.Body className="row gx-4">
              <Col xs="auto">
                <CsLineIcons icon="layout-1" className="text-primary" />
              </Col>
              <Col>
                <NavLink to="/integrationManagment" className="heading stretched-link d-block">
                  {localization.strings().integrationManagment}
                </NavLink>
                <div className="text-muted">Various pages fit to use for error, faq, pricing and so on.</div>
              </Col>
            </Card.Body>
          </Card>
        </Col>

        <Col>
          <Card className="h-100">
            <Card.Body className="row gx-4">
              <Col xs="auto">
                <CsLineIcons icon="layout-1" className="text-primary" />
              </Col>
              <Col>
                <NavLink to="/adminUsers" className="heading stretched-link d-block">
                  {localization.strings().userDefinitions}
                </NavLink>
                <div className="text-muted">Various pages fit to use for error, faq, pricing and so on.</div>
              </Col>
            </Card.Body>
          </Card>
        </Col>
        <Col>
          <Card className="h-100">
            <Card.Body className="row gx-4">
              <Col xs="auto">
                <CsLineIcons icon="suitcase" className="text-primary" />
              </Col>
              <Col>
                <NavLink to="/cacheManagment" className="heading stretched-link d-block">
                  {localization.strings().cacheManagement}
                </NavLink>
                <div className="text-muted">Collection of thumbnails and detail page to showcase work.</div>
              </Col>
            </Card.Body>
          </Card>
        </Col>
      </Row>
      {/* List Items End */}
    </>
  );
};

export default PagesPage;
