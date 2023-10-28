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
    const subMenus = [];
    const processSubs = (subs) => {


        subs.forEach((subItem) => {
            const subMenu = {
                label: subItem.label,
                path: subItem.path,
                isHide: subItem.isHide,
                parentName: subItem.parentName,
                parentUrl: subItem.parentUrl,
            };
            if (subItem.subs && subItem.subs.length > 0) {
                processSubs(subItem.subs); // Recursive call
                subMenus.push(subMenu);
            }
            else {
                subMenus.push(subMenu);
            }
        });

        return subMenus;
    };

    const tmpMenu = [];

    data.forEach((item) => {
        const menu = {
            icon: item.icon,
            label: item.label,
            path: item.path,
            isHide: item.isHide,
            parentName: item.parentName,
            parentUrl: item.parentUrl,
        };
        tmpMenu.push(menu);

        if (item.subs && item.subs.length > 0) {
             processSubs(item.subs);
        }
    });

    subMenus.forEach((subItem) => {
        tmpMenu.push(subItem);
    });
    return tmpMenu;
}



function convertMenuAll(data) {
    const convertSubMenu = (subMenus) => {
        const subMenuDtos = [];

        subMenus.forEach((subItem) => {
            const subMenuDto = {
                // Convert the properties of subItem as needed
                label: subItem.name,
                path: subItem.path,
                isHide: subItem.isHide,
                parentName: subItem.parentName,
                parentUrl: subItem.parentUrl,
            };

            if (subItem.subMenus.length > 0) {
                subMenuDto.subs = convertSubMenu(subItem.subMenus); // Recursive call
            }

            subMenuDtos.push(subMenuDto);
        });

        return subMenuDtos;
    };

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
            parentName: item.parentName,
            parentUrl: item.parentUrl,
        };

        if (item.subMenus.length > 0) {
            menu.subs = convertSubMenu(item.subMenus); // Recursive call
        }

        tmpMenu.push(menu);
    });

    return tmpMenu;
}
export const menuHelper = {
    convertMenu,
    getMenu,
    convertMenuAll,
};