import { localization } from "lang/localization";
import { routes } from "routes";

function convertMenu(data) {
    const tmpMenu = [];
    tmpMenu.push({
        icon: "home",
        label: localization.strings().dashboard,
        path: "/",
    });

    data.forEach((item) => {
        const menu = {
            icon: item.icon,
            label: item.name,
            path: item.path,
        }


        if (item.subMenus.length > 0) {
            menu.subs = [];
            item.subMenus.forEach((subItem) => {
                menu.subs.push({
                    /*  icon: subItem.icon, */
                    label: subItem.name,
                    path: subItem.path,
                });
            });
        }
        tmpMenu.push(menu);
    });

    const menus = tmpMenu;
    return menus;
}

function getMenu(data) {
    const tmpMenu = [];

    data.forEach((item) => {
        const menu = {
            icon: item.icon,
            label: item.label,
            path: item.path,
        }

        tmpMenu.push(menu);
    
        if (item.subs && item.subs.length > 0) {
            menu.subs = [];
            item.subs.forEach((subItem) => {
                tmpMenu.push({
                    label: subItem.label,
                    path: subItem.path,
                });
            });
        }

    });

    const menus = tmpMenu;
    return menus;
}

export const menuHelper = {
    convertMenu,
    getMenu,
};