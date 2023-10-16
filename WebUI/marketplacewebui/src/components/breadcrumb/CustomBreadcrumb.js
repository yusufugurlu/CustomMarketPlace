
import BreadcrumbList from 'components/breadcrumb-list/BreadcrumbList';
import HtmlHead from 'components/html-head/HtmlHead';
import React from 'react';
import { Card } from 'react-bootstrap';
import { useSelector } from 'react-redux';

const CustomBreadcrumb = ({ breadcrumbslist, menuName }) => {


    return (
        <>
            <HtmlHead title={menuName} description={menuName} />
            {/* Title Start */}
            <div className="page-title-container">
                <h1 className="mb-0 pb-0 display-4">{menuName}</h1>
                <BreadcrumbList items={breadcrumbslist} />
            </div>
            {/* Title End */}
        </>
    );
};

export default CustomBreadcrumb;
