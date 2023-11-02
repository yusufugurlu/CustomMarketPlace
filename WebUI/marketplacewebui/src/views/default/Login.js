import React, { useState } from 'react';
import { NavLink, useHistory } from 'react-router-dom';
import { Button, Dropdown, Form } from 'react-bootstrap';
import * as Yup from 'yup';
import { useFormik } from 'formik';
import LayoutFullpage from 'layout/LayoutFullpage';
import CsLineIcons from 'cs-line-icons/CsLineIcons';
import HtmlHead from 'components/html-head/HtmlHead';
import { accountService } from 'Services/accountService';
import { customSweet } from 'customCompanents/swal';
import { useDispatch, useSelector } from 'react-redux';
import { setIsLogin } from 'auth/authSlice';
import { localization } from 'lang/localization';
import classNames from 'classnames';
import { langHelper } from 'Helper/langHelper';
import { changeLang } from 'lang/langSlice';

const Login = () => {
  const title = 'Login';
  const description = 'Login Page';

  const history = useHistory();

  const dispatch = useDispatch();
  const { languages, currentLang } = useSelector((state) => state.lang);

  const [isButtonDisabled, setIsButtonDisabled] = useState(false);
  const [isToggle, setIsToggle] = useState(false);
  const [isLock, setIsLock] = useState(false);

  const validationSchema = Yup.object().shape({
    email: Yup.string().email().required('Email is required'),
    password: Yup.string().min(6, 'Must be at least 6 chars!').required('Password is required'),
  });
  const initialValues = { email: '', password: '' };


  const onSubmit = (values) => {
    const data = {
      mail: values.email,
      password: values.password,
      lang: currentLang.code,
    };
    setIsButtonDisabled(true);
    accountService.signIn(data).then((res) => {
      if (res.success) {
        CustomNotification({mesaj:"test"});
        history.push("/");

      }
      else {
        customSweet.customSweetAlert(res.message, 'warning', 2000);
      }
      setIsButtonDisabled(false);
    });
    dispatch(setIsLogin(true));
  };

  const onSelectLang = (code) => {
    langHelper.setLanguageCookie(code);
    dispatch(changeLang(code));
  }

  const onToggle = (status, event) => {
    setIsToggle(status);
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
          <h2 className="cta-1 mb-0 text-primary">Welcome,</h2>
          <h2 className="cta-1 text-primary">let's get started!</h2>
        </div>
        <div className="mb-5">
          <p className="h6">Please use your credentials to login.</p>
          <p className="h6">
            If you are not a member, please <NavLink to="/register">register</NavLink>.
          </p>
        </div>
        <div>
          <form id="loginForm" className="tooltip-end-bottom" onSubmit={handleSubmit}>
            <div className="mb-3 filled form-group tooltip-end-top">
              <CsLineIcons icon="email" />
              <Form.Control type="text" name="email" placeholder="Email" value={values.email} onChange={handleChange} />
              {errors.email && touched.email && <div className="d-block invalid-tooltip">{errors.email}</div>}
            </div>
            <div className="mb-3 filled form-group tooltip-end-top">
              <CsLineIcons icon={isLock ? "lock-off" : "lock-on"} onClick={() => { setIsLock(!isLock);}} />
              <Form.Control type={isLock ? "text" : "password"} name="password" onChange={handleChange} value={values.password} placeholder="Password" />
              <NavLink className="text-small position-absolute t-3 e-3" to="/forgot-password">
                {localization.strings().forgotPassword}
              </NavLink>
              {errors.password && touched.password && <div className="d-block invalid-tooltip">{errors.password}</div>}
            </div>
            <div className='row justify-content-between'>
              <div className='col-4'>
                <Button size="lg" type="submit" disabled={isButtonDisabled}>
                  {localization.strings().login}
                </Button>
              </div>

              <div className='col-4 offset-md-4'>
                <Dropdown onToggle={onToggle} show={isToggle} align="end">
                  <Dropdown.Toggle
                    variant="primary"
                    className="language-button btn-lg"
                  >
                    {currentLang.code}
                  </Dropdown.Toggle>

                  <Dropdown.Menu
                    popperConfig={{
                      modifiers: [
                        {
                          name: 'offset',
                          options: {
                            offset: () => {
                              if (isToggle) {
                                return [6, 7];
                              }
                              return [0, 7];
                            },
                          },
                        },
                      ],
                    }}
                  >
                    {languages.map((lang) => (
                      <Dropdown.Item key={lang.locale} onClick={() => onSelectLang(lang.code)}>
                        {lang.code}
                      </Dropdown.Item>
                    ))}
                  </Dropdown.Menu>
                </Dropdown>
              </div>
            </div>
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

export default Login;

