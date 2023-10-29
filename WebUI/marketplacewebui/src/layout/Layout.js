import React, { useEffect, useState } from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import { useLocation } from 'react-router-dom';
import useLayout from 'hooks/useLayout';
import Footer from 'layout/footer/Footer';
import Nav from 'layout/nav/Nav';
import SidebarMenu from 'layout/nav/sidebar-menu/SidebarMenu';
import { useSelector, useDispatch } from 'react-redux';
import { baseUrlRequest } from 'Services/baseUrlRequest';
import { userService } from 'Services/userService';
import { setIsLogin, setCurrentUser, setAuthCompany, setAuthWorkplace } from 'auth/authSlice';
import { changeLang } from 'lang/langSlice';
import { langHelper } from 'Helper/langHelper';
import CustomBreadcrumb from 'components/breadcrumb/CustomBreadcrumb';
import { menuHelper } from 'Helper/menuHelper';
import SelectedCompanies from 'components/selectedCompanies/SelectedCompanies';
import { rolePermissionService } from 'Services/rolePermissionService';
import { localization } from 'lang/localization';
import { enumHelper } from 'Helper/enum';
import SelectedWorkplace from 'components/selectedCompanies/SelectedWorkplace';

import { menuChangeName } from './nav/main-menu/menuDataSlice';





const Layout = ({ children }) => {
  useLayout();
  const dispatch = useDispatch();

  const { pathname } = useLocation();
  const { isLogin, currentUser, authCompany } = useSelector((state) => state.auth);
  const { menuData,menuDataAll } = useSelector((state) => state.menuData);

  const [breadcrumbs, setBreadcrumbs] = useState([]);
  const [menuName, setMenuName] = useState([]);

  const getAuthCompanies = () => {
    rolePermissionService.getCompanyByUserId().then((res) => {
      if (res.status === 200) {
        dispatch(setAuthCompany(res.data));
      }
    });
  }

  const getWorkplaces = () => {
    rolePermissionService.getWorkplaces().then((res) => {
      if (res.status === 200) {
        dispatch(setAuthWorkplace(res.data));
      }
    });
  }



  useEffect(() => {
    if (currentUser.mail === undefined || currentUser.mail === null) {
      userService.getUserInfo().then((res) => {
        if (res.statusCode === 401) {
          dispatch(setIsLogin(false));
        }
        else {
          const dto = {
            id: -99,
            email: res.data.mail,
            thumb: res.data.photoUrl,
            role: res.data.userRole,
            name: res.data.fullName,
            selectedLanguage: res.data.selectedLanguage,
            selectedShop: res.data.selectedShop,
            selectedCompany: res.data.selectedCompany,
          };

          dispatch(setCurrentUser(dto));
          langHelper.setLanguageCookie(res.data.selectedLanguage);
          dispatch(changeLang(res.data.selectedLanguage));

          if (res.data.userRole === enumHelper.roleType.superAdmin) {
            getAuthCompanies();
          }
          getWorkplaces();
        }
      });
    }

    const activeLogin = baseUrlRequest.activeLogin();
    dispatch(setIsLogin(activeLogin));
  }, []);


  useEffect(() => {
    document.documentElement.click();
    window.scrollTo(0, 0);
    const displayName = "";
    // eslint-disable-next-line
    dispatch(menuChangeName(""));

    const dtos = [];

    if (menuData.length > 0) {
      const formatedMenus = menuHelper.getMenu(menuDataAll);
      const menus = formatedMenus.filter(item => item.path === pathname);
      if (menus.length > 0) {
        const menu = menus[0];
        const dtoMain = { to: "", text: localization.strings().dashboard };
        dtos.push(dtoMain);
        if (pathname !== "/") {
          if(menu.isHide === true) {
            dtos.push({ to: menu.parentUrl.replace('/', ''), text: menu.parentName });
          }
          const dto = { to: menu.path.replace('/', ''), text: menu.label };
          dtos.push(dto);
        }

        setMenuName(menu.label);
      }
    }

    setBreadcrumbs(dtos);

  }, [pathname, menuData]);

  return (
    <>
      <Nav />
      <main>
        <Container>
          <Row className="h-100">
            <SidebarMenu />
            <Col className="h-100" id="contentArea">
              <Row className='mb-5'>
                <Col xs="12" lg="4">
                  <CustomBreadcrumb breadcrumbslist={breadcrumbs} menuName={menuName} />
                </Col>
                <Col xs="12" lg="4" >
                  <SelectedCompanies />
                </Col>

                <Col xs="12" lg="4">
                  <SelectedWorkplace />
                </Col>
              </Row>
              {children}
            </Col>
          </Row>
        </Container>
      </main>
      <Footer />
      {/*   <RightButtons /> */}
    </>
  );
};

export default React.memo(Layout);
