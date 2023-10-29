/* eslint-disable */
import { lazy } from 'react';
import { USER_ROLE } from 'constants.js';
import { DEFAULT_PATHS } from 'config.js';

const dashboards = {
  index: lazy(() => import('views/dashboards/Dashboards')),
  default: lazy(() => import('views/dashboards/DashboardsDefault')),
  visual: lazy(() => import('views/dashboards/DashboardsVisual')),
  analytic: lazy(() => import('views/dashboards/DashboardsAnalytic')),
};
const apps = {
  index: lazy(() => import('views/apps/Apps')),
  calendar: lazy(() => import('views/apps/calendar/Calendar')),
};
const pages = {
  index: lazy(() => import('views/pages/Pages')),
  authentication: {
    index: lazy(() => import('views/pages/authentication/Authentication')),
    login: lazy(() => import('views/pages/authentication/Login')),
    register: lazy(() => import('views/pages/authentication/Register')),
    forgotPassword: lazy(() => import('views/pages/authentication/ForgotPassword')),
    resetPassword: lazy(() => import('views/pages/authentication/ResetPassword')),
  },
  miscellaneous: {
    index: lazy(() => import('views/pages/miscellaneous/Miscellaneous')),
    faq: lazy(() => import('views/pages/miscellaneous/Faq')),
    knowledgeBase: lazy(() => import('views/pages/miscellaneous/KnowledgeBase')),
    error: lazy(() => import('views/pages/miscellaneous/Error')),
    comingSoon: lazy(() => import('views/pages/miscellaneous/ComingSoon')),
    pricing: lazy(() => import('views/pages/miscellaneous/Pricing')),
    search: lazy(() => import('views/pages/miscellaneous/Search')),
    mailing: lazy(() => import('views/pages/miscellaneous/Mailing')),
    empty: lazy(() => import('views/pages/miscellaneous/Empty')),
  },
  profile: {
    index: lazy(() => import('views/pages/profile/Profile')),
    standard: lazy(() => import('views/pages/profile/ProfileStandard')),
    settings: lazy(() => import('views/pages/profile/ProfileSettings')),
  },
};
const blocks = {
  index: lazy(() => import('views/blocks/Blocks')),
  cta: lazy(() => import('views/blocks/cta/Cta')),
  details: lazy(() => import('views/blocks/details/Details')),
  images: lazy(() => import('views/blocks/images/Images')),
  list: lazy(() => import('views/blocks/list/List')),
  stats: lazy(() => import('views/blocks/stats/Stats')),
  steps: lazy(() => import('views/blocks/steps/Steps')),
  tabularData: lazy(() => import('views/blocks/tabulardata/TabularData')),
  thumbnails: lazy(() => import('views/blocks/thumbnails/Thumbnails')),
};
const interfaces = {
  index: lazy(() => import('views/interface/Interface')),
  components: {
    index: lazy(() => import('views/interface/components/Components')),
    accordion: lazy(() => import('views/interface/components/Accordion')),
    alerts: lazy(() => import('views/interface/components/Alerts')),
    badge: lazy(() => import('views/interface/components/Badge')),
    breadcrumb: lazy(() => import('views/interface/components/Breadcrumb')),
    buttons: lazy(() => import('views/interface/components/Buttons')),
    buttonGroup: lazy(() => import('views/interface/components/ButtonGroup')),
    card: lazy(() => import('views/interface/components/Card')),
    closeButton: lazy(() => import('views/interface/components/CloseButton')),
    collapse: lazy(() => import('views/interface/components/Collapse')),
    dropdowns: lazy(() => import('views/interface/components/Dropdowns')),
    listGroup: lazy(() => import('views/interface/components/ListGroup')),
    modal: lazy(() => import('views/interface/components/Modal')),
    navs: lazy(() => import('views/interface/components/Navs')),
    offcanvas: lazy(() => import('views/interface/components/Offcanvas')),
    pagination: lazy(() => import('views/interface/components/Pagination')),
    popovers: lazy(() => import('views/interface/components/Popovers')),
    progress: lazy(() => import('views/interface/components/Progress')),
    spinners: lazy(() => import('views/interface/components/Spinners')),
    toasts: lazy(() => import('views/interface/components/Toasts')),
    tooltips: lazy(() => import('views/interface/components/Tooltips')),
  },
  forms: {
    index: lazy(() => import('views/interface/forms/Forms')),
    layouts: lazy(() => import('views/interface/forms/layouts/Layouts')),
    validation: lazy(() => import('views/interface/forms/validation/Validation')),
    inputGroup: lazy(() => import('views/interface/forms/input-group/InputGroup')),
    inputMask: lazy(() => import('views/interface/forms/input-mask/InputMask')),
    genericForms: lazy(() => import('views/interface/forms/generic-forms/GenericForms')),
    controls: {
      index: lazy(() => import('views/interface/forms/controls/Controls')),
      autocomplete: lazy(() => import('views/interface/forms/controls/autocomplete/Autocomplete')),
      checkboxRadio: lazy(() => import('views/interface/forms/controls/checkbox-radio/CheckboxRadio')),
      datePicker: lazy(() => import('views/interface/forms/controls/datepicker/Datepicker')),
      dropzone: lazy(() => import('views/interface/forms/controls/dropzone/Dropzone')),
      editor: lazy(() => import('views/interface/forms/controls/editor/Editor')),
      inputSpinner: lazy(() => import('views/interface/forms/controls/input-spinner/InputSpinner')),
      rating: lazy(() => import('views/interface/forms/controls/rating/Rating')),
      select: lazy(() => import('views/interface/forms/controls/select/Select')),
      tags: lazy(() => import('views/interface/forms/controls/tags/Tags')),
    },
  },
  plugins: {
    index: lazy(() => import('views/interface/plugins/Plugins')),
    carousel: lazy(() => import('views/interface/plugins/carousel/Carousel')),
    clamp: lazy(() => import('views/interface/plugins/clamp/Clamp')),
    contextMenu: lazy(() => import('views/interface/plugins/context-menu/ContextMenu')),
    datatables: {
      index: lazy(() => import('views/interface/plugins/datatables/Datatables')),
      editableRows: lazy(() => import('views/interface/plugins/datatables/EditableRows/EditableRows')),
      editableBoxed: lazy(() => import('views/interface/plugins/datatables/EditableBoxed/EditableBoxed')),
      serverSide: lazy(() => import('views/interface/plugins/datatables/ServerSide/ServerSide')),
      boxedVariations: lazy(() => import('views/interface/plugins/datatables/BoxedVariations/BoxedVariations')),
    },
    maps: lazy(() => import('views/interface/plugins/maps/Maps')),
    notification: lazy(() => import('views/interface/plugins/notification/Notification')),
    players: lazy(() => import('views/interface/plugins/player/Player')),
    progress: lazy(() => import('views/interface/plugins/progress/Progress')),
    scrollbar: lazy(() => import('views/interface/plugins/scrollbar/Scrollbar')),
    shortcuts: lazy(() => import('views/interface/plugins/shortcut/Shortcut')),
    sortable: lazy(() => import('views/interface/plugins/sortable/Sortable')),
  },
  content: {
    index: lazy(() => import('views/interface/content/Content')),
    icons: {
      index: lazy(() => import('views/interface/content/icons/Icons')),
      csLineIcons: lazy(() => import('views/interface/content/icons/CsLineIcons')),
      csInterfaceIcons: lazy(() => import('views/interface/content/icons/CsInterfaceIcons')),
      bootstrapIcons: lazy(() => import('views/interface/content/icons/BootstrapIcons')),
    },
    images: lazy(() => import('views/interface/content/Images')),
    tables: lazy(() => import('views/interface/content/Tables')),
    typography: lazy(() => import('views/interface/content/Typography')),
    menu: {
      index: lazy(() => import('views/interface/content/menu/Menu')),
      horizontal: lazy(() => import('views/interface/content/menu/Horizontal')),
      vertical: lazy(() => import('views/interface/content/menu/Vertical')),
      verticalHidden: lazy(() => import('views/interface/content/menu/VerticalHidden')),
      verticalNoHidden: lazy(() => import('views/interface/content/menu/VerticalNoHidden')),
      mobileOnly: lazy(() => import('views/interface/content/menu/MobileOnly')),
      sidebar: lazy(() => import('views/interface/content/menu/Sidebar')),
    },
  },
};



const systemManagment = {
  settings: lazy(() => import('views/systemManagement/index')),
  createUser: lazy(() => import('views/systemManagement/createUser')),
  adminCompanies: lazy(() => import('views/systemManagement/adminCompanies')),
  adminWorkplaces: lazy(() => import('views/systemManagement/adminWorkplaces')),

};
const appRoot = DEFAULT_PATHS.APP.endsWith('/') ? DEFAULT_PATHS.APP.slice(1, DEFAULT_PATHS.APP.length) : DEFAULT_PATHS.APP;

const routesAndMenuItems = {
  mainMenuItems: [
    /*     {
          path: DEFAULT_PATHS.APP,
          exact: true,
          redirect: true,
          to: `${appRoot}/dashboards/default`,
        }, */

    {
      icon: "home",
      label: "menu.dashboards",
      path: "/",
      subs: [],
      component: dashboards.index,
    },
    {
      path: `${appRoot}/systemManagement`,
      label: 'systemManagement',
      icon: 'home',
      subs: [
        { path: '/settings', label: 'settings', component: systemManagment.settings },
        { path: '/createUser', label: 'createCompany', component: systemManagment.createUser },
        { path: '/adminCompanies', label: 'adminCompanies', component: systemManagment.adminCompanies },
        { path: '/adminWorkplaces', label: 'createCompany', component: systemManagment.adminWorkplaces },
      ],
    }
    , {
      path: `${appRoot}/`,
      component: dashboards.analytic,
      label: 'menu.dashboards',
      icon: 'home',
      subs: [
        { path: '/default', label: 'menu.default', component: dashboards.default },
        { path: '/visual', label: 'menu.visual', component: dashboards.visual },
        { path: '/analytic', label: 'menu.analytic', component: dashboards.analytic },
      ],
    },
    {
      path: `${appRoot}/pages`,
      label: 'menu.pages',
      icon: 'notebook-1',
      component: pages.index,
      subs: [
        {
          path: '/authentication',
          label: 'menu.authentication',
          component: pages.authentication.index,
          subs: [
            { path: '/login', label: 'menu.login', component: pages.authentication.login, noLayout: true },
            { path: '/register', label: 'menu.register', component: pages.authentication.register, noLayout: true },
            { path: '/forgot-password', label: 'menu.forgot-password', component: pages.authentication.forgotPassword, noLayout: true },
            { path: '/reset-password', label: 'menu.reset-password', component: pages.authentication.resetPassword, noLayout: true },
          ],
        },
        {
          path: '/miscellaneous',
          label: 'menu.miscellaneous',
          component: pages.miscellaneous.index,
          subs: [
            { path: '/faq', label: 'menu.faq', component: pages.miscellaneous.faq },
            { path: '/knowledge-base', label: 'menu.knowledge-base', component: pages.miscellaneous.knowledgeBase },
            { path: '/error', label: 'menu.error', component: pages.miscellaneous.error, noLayout: true },
            { path: '/coming-soon', label: 'menu.coming-soon', component: pages.miscellaneous.comingSoon, noLayout: true },
            { path: '/pricing', label: 'menu.pricing', component: pages.miscellaneous.pricing },
            { path: '/search', label: 'menu.search', component: pages.miscellaneous.search },
            { path: '/mailing', label: 'menu.mailing', component: pages.miscellaneous.mailing },
            { path: '/empty', label: 'menu.empty', component: pages.miscellaneous.empty },
          ],
        },
        {
          path: '/profile',
          label: 'menu.profile',
          component: pages.profile.index,
          subs: [
            { path: '/standard', label: 'menu.standard', component: pages.profile.standard },
            { path: '/settings', label: 'menu.settings', component: pages.profile.settings },
          ],
        },
      ],
    },
    {
      path: `${appRoot}/blocks`,
      label: 'menu.blocks',
      icon: 'grid-5',
      component: blocks.index,
      subs: [
        { path: '/cta', label: 'menu.cta', component: blocks.cta },
        { path: '/details', label: 'menu.details', component: blocks.details },
        { path: '/gallery', label: 'menu.gallery', component: blocks.gallery },
        { path: '/images', label: 'menu.images', component: blocks.images },
        { path: '/list', label: 'menu.list', component: blocks.list },
        { path: '/stats', label: 'menu.stats', component: blocks.stats },
        { path: '/steps', label: 'menu.steps', component: blocks.steps },
        { path: '/tabular-data', label: 'menu.tabular-data', component: blocks.tabularData },
        { path: '/thumbnails', label: 'menu.thumbnails', component: blocks.thumbnails },
      ],
    },

  ],
  sidebarItems: [
    { path: '#connections', label: 'menu.connections', icon: 'diagram-1', hideInRoute: true },
    { path: '#bookmarks', label: 'menu.bookmarks', icon: 'bookmark', hideInRoute: true },
    { path: '#requests', label: 'menu.requests', icon: 'diagram-2', hideInRoute: true },
    {
      path: '#account',
      label: 'menu.account',
      icon: 'user',
      hideInRoute: true,
      subs: [
        { path: '/settings', label: 'menu.settings', icon: 'gear', hideInRoute: true },
        { path: '/password', label: 'menu.password', icon: 'lock-off', hideInRoute: true },
        { path: '/devices', label: 'menu.devices', icon: 'mobile', hideInRoute: true },
      ],
    },
    {
      path: '#notifications',
      label: 'menu.notifications',
      icon: 'notification',
      hideInRoute: true,
      subs: [
        { path: '/email', label: 'menu.email', icon: 'email', hideInRoute: true },
        { path: '/sms', label: 'menu.sms', icon: 'message', hideInRoute: true },
      ],
    },
    {
      path: '#downloads',
      label: 'menu.downloads',
      icon: 'download',
      hideInRoute: true,
      subs: [
        { path: '/documents', label: 'menu.documents', icon: 'file-text', hideInRoute: true },
        { path: '/images', label: 'menu.images', icon: 'file-image', hideInRoute: true },
        { path: '/videos', label: 'menu.videos', icon: 'file-video', hideInRoute: true },
      ],
    },
  ],
};
export const routes = {
  routesAndMenuItems,
};
