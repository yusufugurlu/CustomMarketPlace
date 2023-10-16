import React, { useEffect } from 'react';
import { Dropdown } from 'react-bootstrap';
import { useDispatch, useSelector } from 'react-redux';
import classNames from 'classnames';
import { MENU_PLACEMENT } from 'constants.js';
import { changeLang, changeLanguages } from 'lang/langSlice';
import { layoutShowingNavMenu } from 'layout/layoutSlice';
import { userService } from 'Services/userService';
import { langHelper } from 'Helper/langHelper';

const MENU_NAME = 'NavLanguageSwitcher';
const NavLanguageSwitcher = () => {
  const dispatch = useDispatch();

   const languages1 = [
    { code: 'TR', locale: 'tr-TR', direction: 'ltr' },
    { code: 'EN', locale: 'en-US', direction: 'ltr' },
  ];

  const {
    behaviourStatus: { behaviourHtmlData },
    placementStatus: { view: placement },
    attrMobile,
    attrMenuAnimate,
  } = useSelector((state) => state.menu);
  const { color } = useSelector((state) => state.settings);
  const { showingNavMenu } = useSelector((state) => state.layout);
  const { languages, currentLang } = useSelector((state) => state.lang);

  const onSelectLang = (code) => {
    userService.changeLanguage(code).then((res) => {
      if (res.success) {
        langHelper.setLanguageCookie(code);
        dispatch(changeLang(code));
        window.location.reload();
      }
    });
  };
  const onToggle = (status, event) => {
    if (event && event.stopPropagation) event.stopPropagation();
    else if (event && event.originalEvent && event.originalEvent.stopPropagation) event.originalEvent.stopPropagation();
    dispatch(layoutShowingNavMenu(status ? MENU_NAME : ''));
  };

  useEffect(() => {
    dispatch(layoutShowingNavMenu(''));
    // eslint-disable-next-line
  }, [attrMenuAnimate, behaviourHtmlData, attrMobile, color]);


  useEffect(() => {
    dispatch(changeLanguages(languages1));
  }, []);

  return (
    <div className="language-switch-container">
      <Dropdown onToggle={onToggle} show={showingNavMenu === MENU_NAME} align="end">
        <Dropdown.Toggle
          variant="empty"
          className={classNames('language-button', {
            show: showingNavMenu === MENU_NAME,
          })}
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
                    if (placement === MENU_PLACEMENT.Vertical) {
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
  );
};
export default React.memo(NavLanguageSwitcher);
