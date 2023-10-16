import React from 'react';
import { Row, Col, Card } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
import HtmlHead from 'components/html-head/HtmlHead';
import BreadcrumbList from 'components/breadcrumb-list/BreadcrumbList';
import CsLineIcons from 'cs-line-icons/CsLineIcons';

const DashboardsPage = () => {
  const title = 'Dashboards';
  const description =
    'Dashboard pages contains different layouts to provide stats, graphics, listings, categories, banners and so on. They have various implementations of plugins such as Datatables, Chart.js, Glide.js and Plyr.js with alternative extensions.';
  const breadcrumbs = [{ to: '', text: 'Home' }];

  return (
    <>
      {/* List Items Start */}
      <Row xs="1" sm="2" xl="3" className="g-2">
        <Col>
          <Card className="h-100">
            <Card.Body className="row gx-4">
              <Col xs="auto">
                <CsLineIcons icon="board-1" className="text-primary" />
              </Col>
              <Col>
                <NavLink to="/" className="heading stretched-link d-block">
                  Default
                </NavLink>
                <div className="text-muted">Home screen that contains stats, charts, call to action buttons and various listing elements.</div>
              </Col>
            </Card.Body>
          </Card>
        </Col>
        <Col>
          <Card className="h-100">
            <Card.Body className="row gx-4">
              <Col xs="auto">
                <CsLineIcons icon="board-3" className="text-primary" />
              </Col>
              <Col>
                <NavLink to="/dashboards/visual" className="heading stretched-link d-block">
                  Visual
                </NavLink>
                <div className="text-muted">A dashboard implementation that mainly has visual items such as banners, call to action buttons and stats.</div>
              </Col>
            </Card.Body>
          </Card>
        </Col>
        <Col>
          <Card className="h-100">
            <Card.Body className="row gx-4">
              <Col xs="auto">
                <CsLineIcons icon="board-2" className="text-primary" />
              </Col>
              <Col>
                <NavLink to="/dashboards/analytic" className="heading stretched-link d-block">
                  Analytic
                </NavLink>
                <div className="text-muted">Another dashboard alternative that focused on data, listing and charts.</div>
              </Col>
            </Card.Body>
          </Card>
        </Col>
      </Row>
      {/* List Items End */}
    </>
  );
};

export default DashboardsPage;
