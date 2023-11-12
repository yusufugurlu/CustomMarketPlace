import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { NavLink } from 'react-router-dom';
import { Dropdown } from 'react-bootstrap';
import classNames from 'classnames';
import { OverlayScrollbarsComponent } from 'overlayscrollbars-react';
import { MENU_PLACEMENT } from 'constants.js';
import CsLineIcons from 'cs-line-icons/CsLineIcons';
import { layoutShowingNavMenu } from 'layout/layoutSlice';
import { notificationService } from 'Services/notificationService';
import { notificationsIsChange, notificationsitems } from './notificationSlice';




let doesHasNorification = false;
const MENU_NAME = 'Notifications';

let NotificationsDropdownMenu = React.memo(
  React.forwardRef(({ style, className, labeledBy, items }, ref) => {
    return (
      <div ref={ref} style={style} className={classNames('wide notification-dropdown scroll-out', className)} aria-labelledby={labeledBy}>
        <OverlayScrollbarsComponent
          options={{
            scrollbars: { autoHide: 'leave', autoHideDelay: 600 },
            overflowBehavior: { x: 'hidden', y: 'scroll' },
          }}
          className="scroll"
        >
          <ul className="list-unstyled border-last-none">
            {items.map((item, itemIndex) => (
              <NotificationItem key={`notificationItem.${itemIndex}`} detail={item.detail} link={item.link} title={item.title} />
            ))}
          </ul>
        </OverlayScrollbarsComponent>
      </div>
    );
  })
);

NotificationsDropdownMenu.displayName = 'NotificationsDropdownMenu';


const NotificationItem = ({ title = '', link = '', detail = '' }) => (
  <li className="mb-3 pb-3 border-bottom border-separator-light d-flex">
    <div className="align-self-center">
      <NavLink to={link} activeClassName="">
        <strong>{title}</strong>

        <div className='text-muted'>
          {detail}
        </div>
      </NavLink>
    </div>
  </li>
);


const NotificationsDropdownToggle = React.memo(
  React.forwardRef(({ onClick, expanded = false }, ref) => (
    <a
      ref={ref}
      href="#/"
      className="notification-button"
      data-toggle="dropdown"
      aria-expanded={expanded}
      onClick={(e) => {
        e.preventDefault();
        e.stopPropagation();
        onClick(e);
      }}
    >
      <div className="position-relative d-inline-flex">
        <CsLineIcons icon="bell" size="18" />
        <span className={doesHasNorification ? "position-absolute notification-dot rounded-xl" : "position-absolute notification-dot rounded-xl"} />

      </div>
    </a>
  ))
);


const Notifications = () => {
  const dispatch = useDispatch();



  const [notificationData, setNotificationData] = useState([]);

  const { isChangeNotification } = useSelector((state) => state.notification);
  const { data } = useSelector((state) => state.signalRData);

  const {
    placementStatus: { view: placement },
    behaviourStatus: { behaviourHtmlData },
    attrMobile,
    attrMenuAnimate,
  } = useSelector((state) => state.menu);
  const { color } = useSelector((state) => state.settings);
  const { showingNavMenu } = useSelector((state) => state.layout);

  const getNotificationForTopMenuByUserId = () => {
    notificationService.getNotificationForTopMenuByUserId().then((res) => {
      if (res.status === 200) {
        setNotificationData(res.data);
        dispatch(notificationsIsChange(true));
        dispatch(notificationsitems(res.data));

        NotificationsDropdownMenu = React.memo(
          React.forwardRef(({ style, className, labeledBy, items }, ref) => {
            return (
              <div ref={ref} style={style} className={classNames('wide notification-dropdown scroll-out', className)} aria-labelledby={labeledBy}>
                <OverlayScrollbarsComponent
                  options={{
                    scrollbars: { autoHide: 'leave', autoHideDelay: 600 },
                    overflowBehavior: { x: 'hidden', y: 'scroll' },
                  }}
                  className="scroll"
                >
                  <ul className="list-unstyled border-last-none">
                    {items.map((item, itemIndex) => (
                      <NotificationItem key={`notificationItem.${itemIndex}`} detail={item.detail} link={item.link} title={item.title} />
                    ))}
                  </ul>
                </OverlayScrollbarsComponent>
              </div>
            );
          })
        );
      }
    });
  }

  useEffect(() => {
    getNotificationForTopMenuByUserId();
    doesHasNorification = isChangeNotification;
  }, [isChangeNotification, data]);

  const onToggle = (status, event) => {
    if (event && event.stopPropagation) event.stopPropagation();
    else if (event && event.originalEvent && event.originalEvent.stopPropagation) event.originalEvent.stopPropagation();
    dispatch(layoutShowingNavMenu(status ? MENU_NAME : ''));
  };

  useEffect(() => {
    dispatch(layoutShowingNavMenu(''));
    // eslint-disable-next-line
  }, [attrMenuAnimate, behaviourHtmlData, attrMobile, color]);

  if (notificationData && notificationData.length > 0) {
    return (
      <Dropdown
        as="li"
        bsPrefix="list-inline-item"
        onToggle={onToggle}
        show={showingNavMenu === MENU_NAME}
        align={placement === MENU_PLACEMENT.Horizontal ? 'end' : 'start'}
      >
        <Dropdown.Toggle as={NotificationsDropdownToggle} />
        <Dropdown.Menu
          as={NotificationsDropdownMenu}
          items={notificationData}
          popperConfig={{
            modifiers: [
              {
                name: 'offset',
                options: {
                  offset: () => {
                    if (placement === MENU_PLACEMENT.Horizontal) {
                      return [0, 7];
                    }
                    if (window.innerWidth < 768) {
                      return [-168, 7];
                    }
                    return [-162, 7];
                  },
                },
              },
            ],
          }}
        />
      </Dropdown>
    );
  }
  return <></>;
};
export default React.memo(Notifications);
