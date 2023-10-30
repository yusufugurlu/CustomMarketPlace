import React, { useEffect } from 'react';
import { NavLink, useHistory } from 'react-router-dom';
import { Button, Form } from 'react-bootstrap';
import * as Yup from 'yup';
import { useFormik } from 'formik';
import LayoutFullpage from 'layout/LayoutFullpage';
import CsLineIcons from 'cs-line-icons/CsLineIcons';
import HtmlHead from 'components/html-head/HtmlHead';
import { userPasswordRecoveryService } from 'Services/userPasswordRecoveryService';
import { customSweet } from 'customCompanents/swal';
import { accountService } from 'Services/accountService';

const ResetPassword = () => {
  const history = useHistory();
  const [guid, setGuid] = React.useState("");
  const [password, setPassword] = React.useState("");
  const [passwordVerify, setPasswordVerify] = React.useState("");
  useEffect(() => {
    const urlParams = new URLSearchParams(window.location.search);
    const guid1 = urlParams.get('Guid');
    if (guid1) {
      userPasswordRecoveryService.checkGuid(guid1).then((result) => {
        if (result.status !== 200) {
          customSweet.customSweetAlert(result.message, "error", 2000);
          history.push("/login");
        }
        setGuid(guid1);
      });
    }
    else {
      history.push("/login");
    }
  }, []);

  const title = 'Reset Password';
  const description = 'Reset Password Page';
  const validationSchema = Yup.object().shape({
    password: Yup.string().min(6, 'Must be at least 6 chars!').required('Password is required'),
    passwordConfirm: Yup.string()
      .required('Password Confirm is required')
      .oneOf([Yup.ref('password'), null], 'Must be same with password!'),
  });
  const initialValues = { password: '', passwordConfirm: '' };
  const onSubmit = (values) => {
    const dto = {
      guidKey: guid,
      password: values.password,
      passwordConfirm: values.passwordConfirm
    }

    accountService.changePassword(dto).then((result) => {
      if (result.status === 200) {
        customSweet.customSweetAlert(result.message, "success", 2000);
        history.push("/login");
      }
      else {
        customSweet.customSweetAlert(result.message, "error", 2000);
      }
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
          <h2 className="cta-1 mb-0 text-primary">Password trouble?</h2>
          <h2 className="cta-1 text-primary">Renew it here!</h2>
        </div>
        <div className="mb-5">
          <p className="h6">Please use below form to reset your password.</p>
          <p className="h6">
            If you are a member, please <NavLink to="/login">login</NavLink>.
          </p>
        </div>
        <div>
          <form id="resetForm" className="tooltip-end-bottom" onSubmit={handleSubmit}>
            <div className="mb-3 filled">
              <CsLineIcons icon="lock-off" />
              <Form.Control type="password" name="password" onChange={handleChange} value={values.password} placeholder="Password" />
              {errors.password && touched.password && <div className="d-block invalid-tooltip">{errors.password}</div>}
            </div>
            <div className="mb-3 filled">
              <CsLineIcons icon="lock-on" />
              <Form.Control type="password" name="passwordConfirm" onChange={handleChange} value={values.passwordConfirm} placeholder="Verify Password" />
              {errors.passwordConfirm && touched.passwordConfirm && <div className="d-block invalid-tooltip">{errors.passwordConfirm}</div>}
            </div>
            <Button size="lg" type="submit">
              Reset Password
            </Button>
          </form>
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

export default ResetPassword;
