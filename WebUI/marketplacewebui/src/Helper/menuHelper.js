import { localization } from "lang/localization";
import { routes } from "routes";

function convertMenu(data) {
    const tmpMenu = [];
    tmpMenu.push({
        icon: "home",
        label: localization.strings().dashboard,
        path: "/",
        isHide: false,
    });

    data.forEach((item) => {
        const menu = {
            icon: item.icon,
            label: item.name,
            path: item.path,
            isHide: item.isHide,
        }


        if (item.subMenus.length > 0) {
            menu.subs = [];
            item.subMenus.forEach((subItem) => {
                if (subItem.isHide === false) {
                    menu.subs.push({
                        /*  icon: subItem.icon, */
                        label: subItem.name,
                        path: subItem.path,
                        isHide: subItem.isHide,
                    });
                }
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
            isHide: item.isHide,
            parentName: item.parentName,
            parentUrl: item.parentUrl,
        }

        tmpMenu.push(menu);

        if (item.subs && item.subs.length > 0) {
            menu.subs = [];
            item.subs.forEach((subItem) => {
                tmpMenu.push({
                    label: subItem.label,
                    path: subItem.path,
                    isHide: subItem.isHide,
                    parentName: subItem.parentName,
                    parentUrl: subItem.parentUrl,
                });
            });
        }

    });

    const menus = tmpMenu;
    return menus;
}


function convertMenuAll(data) {
    const tmpMenu = [];
    tmpMenu.push({
        icon: "home",
        label: localization.strings().dashboard,
        path: "/",
        isHide: false,
    });

    data.forEach((item) => {
        const menu = {
            icon: item.icon,
            label: item.name,
            path: item.path,
            isHide: item.isHide,
        }


        if (item.subMenus.length > 0) {
            menu.subs = [];
            item.subMenus.forEach((subItem) => {
                menu.subs.push({
                    /*  icon: subItem.icon, */
                    label: subItem.name,
                    path: subItem.path,
                    isHide: subItem.isHide,
                    parentName: subItem.parentName,
                    parentUrl: subItem.parentUrl,
                });
            });
        }
        tmpMenu.push(menu);
    });

    const menus = tmpMenu;
    return menus;
}
export const menuHelper = {
    convertMenu,
    getMenu,
    convertMenuAll,
};