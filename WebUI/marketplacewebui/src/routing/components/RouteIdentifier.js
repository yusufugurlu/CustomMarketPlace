import React, { memo, Suspense, useEffect } from 'react';
import { Redirect, Switch, useHistory } from 'react-router-dom';
import { baseUrlRequest } from 'Services/baseUrlRequest';
import { DEFAULT_PATHS } from 'config.js';
import RouteItem from './RouteItem';

const RouteIdentifier = ({ isLoggedIn, routes, fallback = <div className="loading" />, notFoundPath = DEFAULT_PATHS.NOTFOUND }) => {
  const history = useHistory();

  useEffect(() => {
    isLoggedIn = baseUrlRequest.activeLogin();
    if (!isLoggedIn) {
      history.push("/login");
    }
    else if (window.location.pathname === "/login") {
      history.push("/");
    }
  }, []);

  return (
    <Suspense fallback={fallback}>
      <Switch>
        {routes.map((route, rIndex) => (
          <RouteItem key={`r.${rIndex}`} {...route} />
        ))}

        <Redirect to={notFoundPath} />
      </Switch>
    </Suspense>
  );
};

export default memo(RouteIdentifier);
