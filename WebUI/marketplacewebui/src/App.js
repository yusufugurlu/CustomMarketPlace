import React, { useEffect, useMemo, useState } from 'react';

// import redux for auth guard
import { useSelector,useDispatch } from 'react-redux';

// import layout
import Layout from 'layout/Layout';

import { Redirect } from 'react-router-dom';


// import routing modules
import RouteIdentifier from 'routing/components/RouteIdentifier';
import { getRoutes } from 'routing/helper';
import { routes } from 'routes.js';
import Loading from 'components/loading/Loading';
import { baseUrlRequest } from 'Services/baseUrlRequest';
import { menuService } from 'Services/menuService';
import { menuHelper } from 'Helper/menuHelper';
import { menuChangeData } from 'layout/nav/main-menu/menuSlice';


const App = () => {
  const { currentUser, isLogin } = useSelector((state) => state.auth);
  const [isLoggedIn, setIsLoggedIn] = useState(baseUrlRequest.activeLogin);


  const routes1 = useMemo(() => getRoutes({ data: routes.routesAndMenuItems, isLogin, userRole: currentUser.role }), [isLogin, currentUser]);

  if (routes1) {
    return (
      <Layout>
        <RouteIdentifier isLoggedIn={isLoggedIn} routes={routes1} fallback={<Loading />} />
      </Layout>
    );
  }
  return <>
  </>;
};

export default App;
