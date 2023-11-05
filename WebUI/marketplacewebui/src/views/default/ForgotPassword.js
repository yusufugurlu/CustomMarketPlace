import React, { useState } from 'react';
import { NavLink, useHistory } from 'react-router-dom';
import { Button, Form } from 'react-bootstrap';
import * as Yup from 'yup';
import { useFormik } from 'formik';
import LayoutFullpage from 'layout/LayoutFullpage';
import CsLineIcons from 'cs-line-icons/CsLineIcons';
import HtmlHead from 'components/html-head/HtmlHead';
import { useSelector } from 'react-redux';
import { accountService } from 'Services/accountService';
import { customSweet } from 'customCompanents/swal';

const ForgotPassword = () => {
  const title = 'Forgot Password';
  const description = 'Forgot Password Page';
  
  const history = useHistory();


  const { isLogin, currentUser } = useSelector((state) => state.auth);
  const { languages, currentLang } = useSelector((state) => state.lang);

  const [isButtonDisabled, setIsButtonDisabled] = useState(false);

  const validationSchema = Yup.object().shape({
    email: Yup.string().email().required('Email is required'),
  });
  const initialValues = { email: '' };
  const onSubmit = (values) => {
    const data = {
      email: values.email,
      lang: currentLang.code,
    };
    setIsButtonDisabled(true);
    accountService.checkHasEmail(data).then((res) => {
      if (res.success) {
        customSweet.customSweetAlert(res.message, 'success', 2000);
        history.push("/");

      }
      else {
        customSweet.customSweetAlert(res.message, 'warning', 2000);
      }
      setIsButtonDisabled(false);
    });
  };

  const formik = useFormik({ initialValues, validationSchema, onSubmit });
  const { handleSubmit, handleChange, values, touched, errors } = formik;

  const leftSide = (
    <div className="min-h-100 d-flex align-items-center">
      <div className="w-100 w-lg-75 w-xxl-50">
        <div>
          <div className="mb-5">
            <h1 className="display-3 text-white">Multiple Niches</h1>
            <h1 className="display-3 text-white">Ready for Your Project</h1>
          </div>
          <p className="h6 text-white lh-1-5 mb-5">
            Dynamically target high-payoff intellectual capital for customized technologies. Objectively integrate emerging core competencies before
            process-centric communities...
          </p>
          <div className="mb-5">
            <Button size="lg" variant="outline-white" href="/">
              Learn More
            </Button>
          </div>
        </div>
      </div>
    </div>
  );

  const rightSide = (
    <div className="sw-lg-70 min-h-100 bg-foreground d-flex justify-content-center align-items-center shadow-deep py-5 full-page-content-right-border">
      <div className="sw-lg-50 px-5">
        <div className="sh-11">
          <NavLink to="/">
            <div className="logo-default" />
          </NavLink>
        </div>
        <div className="mb-5">
          <h2 className="cta-1 mb-0 text-primary">Password is gone?</h2>
          <h2 className="cta-1 text-primary">Let's reset it!</h2>
        </div>
        <div className="mb-5">
          <p className="h6">Please enter your email to receive a link to reset your password.</p>
          <p className="h6">
            If you are a member, please <NavLink to="/login">login</NavLink>.
          </p>
        </div>
        <div>
          <form id="forgotPasswordForm" className="tooltip-end-bottom" onSubmit={handleSubmit}>
            <div className="mb-3 filled form-group tooltip-end-top">
              <CsLineIcons icon="email" />
              <Form.Control type="text" name="email" placeholder="Email" value={values.email} onChange={handleChange} />
              {errors.email && touched.email && <div className="d-block invalid-tooltip">{errors.email}</div>}
            </div>
            <Button size="lg" type="submit" disabled={isButtonDisabled}>
              Send Reset Email
            </Button>
            
          </form>
          <p className="h6 mt-3">
  If you remember your password, please <NavLink to="/login">click here</NavLink> to return to the login page.
</p>
        </div>
      </div>
    </div>
  );

  return (
    <>
      <HtmlHead title={title} description={description} />
      <LayoutFullpage left={leftSide} right={rightSide} />
    </>
  );
};

export default ForgotPassword;
