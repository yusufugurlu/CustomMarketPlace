import React, {  useMemo, useState } from 'react';

// import redux for auth guard
import { useSelector } from 'react-redux';

// import layout
import Layout from 'layout/Layout';



// import routing modules
import RouteIdentifier from 'routing/components/RouteIdentifier';
import { getRoutes } from 'routing/helper';
import { routes } from 'routes.js';
import Loading from 'components/loading/Loading';
import { baseUrlRequest } from 'Services/baseUrlRequest';
import SignalRListener from 'signalR/SignalRListener';


const App = () => {
  const { currentUser, isLogin } = useSelector((state) => state.auth);
  const [isLoggedIn, setIsLoggedIn] = useState(baseUrlRequest.activeLogin);


  const routes1 = useMemo(() => getRoutes({ data: routes.routesAndMenuItems, isLogin, userRole: currentUser.role }), [isLogin, currentUser]);

  if (routes1) {
    return (
      <Layout>
        <SignalRListener />
        <RouteIdentifier isLoggedIn={isLoggedIn} routes={routes1} fallback={<Loading />} />
      </Layout>
    );
  }
  return <>
  </>;
};

export default App;
