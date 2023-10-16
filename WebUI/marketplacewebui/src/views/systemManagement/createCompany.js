import React from 'react';
import { Card } from 'react-bootstrap';
import HtmlHead from 'components/html-head/HtmlHead';
import BreadcrumbList from 'components/breadcrumb-list/BreadcrumbList';

const createCompany = () => {
  const title = 'Empty';
  const description = 'Empty';

  const breadcrumbs = [
    { to: '', text: 'Home' },
    { to: 'pages', text: 'Pages' },
    { to: 'pages/miscellaneous', text: 'Miscellaneous' },
  ];

  return (
    <>
      <Card>
        <Card.Body>Content</Card.Body>
      </Card>
    </>
  );
};

export default createCompany;
