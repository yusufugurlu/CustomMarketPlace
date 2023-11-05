import React from 'react';
import { Row, Col, Card } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
import CsLineIcons from 'cs-line-icons/CsLineIcons';
import { localization } from 'lang/localization';

const ListSection = ({ icon, to, headingText, descriptionText }) => {
  return (
    <Col>
      <Card className="h-100">
        <Card.Body className="row gx-4">
          <Col xs="auto">
            <CsLineIcons icon={icon} className="text-primary" />
          </Col>
          <Col>
            <NavLink to={to} className="heading stretched-link d-block">
              {headingText}
            </NavLink>
            <div className="text-muted">{descriptionText}</div>
          </Col>
        </Card.Body>
      </Card>
    </Col>
  );
};

const PagesPage = () => {
  const title = 'Pages';
  const description = 'Layouts that are focused on different project needs. Contains html blocks and specific plugins that are fit for the context.';

  const breadcrumbs = [{ to: '', text: 'Home' }];

  return (
    <>

<section className="scroll-section" id="multipleInputs">
  <h2 className="small-title">Multiple Inputs</h2>
  <Row xs="1" sm="2" xl="3" className="g-2">
    <ListSection
      icon="lock-on"
      to="/adminCompanies"
      headingText={localization.strings().companyDefinition}
      descriptionText="User verification, registration and recovery pages."
    />
    <ListSection
      icon="content"
      to="/adminWorkplaces"
      headingText={localization.strings().shopDefinition}
      descriptionText="Multiple blog pages for home, detail and listing layouts."
    />
  </Row>
</section>
<div style={{ height: '50px' }} />
<section className="scroll-section" id="multipleInputs">
  <h2 className="small-title">Multiple Inputs</h2>
  <Row xs="1" sm="2" xl="3" className="g-2">
    <ListSection
      icon="layout-1"
      to="/integrationManagment"
      headingText={localization.strings().integrationManagment}
      descriptionText="Various pages fit to use for error, faq, pricing and so on."
    />
    <ListSection
      icon="layout-1"
      to="/adminUsers"
      headingText={localization.strings().userDefinitions}
      descriptionText="Various pages fit to use for error, faq, pricing and so on."
    />
    <ListSection
      icon="suitcase"
      to="/cacheManagment"
      headingText={localization.strings().cacheManagement}
      descriptionText="Collection of thumbnails and detail page to showcase work."
    />
  </Row>
</section>
      {/* List Items End */}
    </>
  );
};

export default PagesPage;
