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
import { setIsLogin, setCurrentUser } from 'auth/authSlice';
import { changeLang } from 'lang/langSlice';
import { langHelper } from 'Helper/langHelper';
import CustomBreadcrumb from 'components/breadcrumb/CustomBreadcrumb';
import { menuHelper } from 'Helper/menuHelper';
import { menuChangeMenu, menuChangeName } from './nav/main-menu/menuDataSlice';




const Layout = ({ children }) => {
  useLayout();
  const dispatch = useDispatch();

  const { pathname } = useLocation();
  const { isLogin, currentUser } = useSelector((state) => state.auth);
  const { menuData } = useSelector((state) => state.menuData);

  const [breadcrumbs, setBreadcrumbs] = useState([]);
  const [menuName, setMenuName] = useState([]);

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
          }
          dispatch(setCurrentUser(dto));
          langHelper.setLanguageCookie(res.data.selectedLanguage);
          dispatch(changeLang(res.data.selectedLanguage));
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
      const formatedMenus = menuHelper.getMenu(menuData);
      const menus = formatedMenus.filter(item => item.path === pathname);
      if (menus.length > 0) {
        const menu = menus[0];
        const dto = { to: menu.path.replace('/', ''), text: menu.label };
        setMenuName(menu.label);
        dtos.push(dto);
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
              <CustomBreadcrumb breadcrumbslist={breadcrumbs} menuName={menuName} />
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
