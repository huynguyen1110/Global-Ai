import { ROUTES } from "./routeConfig";

const menu = 'menu_';
const tab = 'tab_';
const page = 'page_';
const table = 'table_';
const form = 'formm_';
const buttonAction = 'btn_action_';

const productModule = 'product.';

/**
 * TOÀN BỘ PERMISSION TRONG APP
 */
export const PERMISSIONS = {
    PRODUCT_ADMIN_DASHBOARD: `${productModule}${page}admin_dashboard`,
    PRODUCT_ADMIN_PRODUCT: `${productModule}${page}admin_product`,
    PRODUCT_ADMIN_PRODUCT_ADD: `${productModule}${page}admin_product_add`,
    PRODUCT_ADMIN_PRODUCT_EDIT: `${productModule}${page}admin_product_edit`,
    PRODUCT_ADMIN_ORDER: `${productModule}${page}admin_order`,
    PRODUCT_ADMIN_ORDER_ADD: `${productModule}${page}admin_order_add`,
    PRODUCT_ADMIN_ORDER_EDIT: `${productModule}${page}admin_order_edit`,
    PRODUCT_ADMIN_ORDER_DETAIL: `${productModule}${page}admin_order_detail`,
    PRODUCT_MANAGE_CART: `${productModule}${page}manage_cart`,
    PRODUCT_GSALER_HOME: `${productModule}${page}gsaler_home`,
    PRODUCT_GSALER_ADVISEMENT: `${productModule}${page}gsaler_advisement`,
    PRODUCT_GSALER_PROFILE: `${productModule}${page}gsaler_profile`,
    PRODUCT_GSALER_SLIDERNCC: `${productModule}${page}gsaler_sliderncc`,
    PRODUCT_PROFILE: `${productModule}${page}profile`,
};

/**
 * MAP PERMISSION VÀ ROUTE
 */
export const PERMISSIONS_ROUTE_CONFIG = {
    [ROUTES.ADMIN_DASHBOARD]: [PERMISSIONS.PRODUCT_ADMIN_DASHBOARD],
    [ROUTES.ADMIN_PRODUCT]: [PERMISSIONS.PRODUCT_ADMIN_PRODUCT],
    [ROUTES.ADMIN_PRODUCT_ADD]: [PERMISSIONS.PRODUCT_ADMIN_PRODUCT_ADD],
    [ROUTES.ADMIN_PRODUCT_EDIT]: [PERMISSIONS.PRODUCT_ADMIN_PRODUCT_EDIT],
    [ROUTES.ADMIN_ORDER]: [PERMISSIONS.PRODUCT_ADMIN_ORDER],
    [ROUTES.ADMIN_ORDER_ADD]: [PERMISSIONS.PRODUCT_ADMIN_ORDER_ADD],
    [ROUTES.ADMIN_ORDER_DETAILS]: [PERMISSIONS.PRODUCT_ADMIN_ORDER_DETAIL],
    [ROUTES.ADMIN_ORDER_EDIT]: [PERMISSIONS.PRODUCT_ADMIN_ORDER_EDIT],
    [ROUTES.GSALER_HOME]: [PERMISSIONS.PRODUCT_GSALER_HOME],
    [ROUTES.GSALER_ADVISEMENT]: [PERMISSIONS.PRODUCT_GSALER_ADVISEMENT],
    [ROUTES.GSALER_PROFILE]: [PERMISSIONS.PRODUCT_GSALER_PROFILE],
    [ROUTES.GSALER_SLIDER_NCC]: [PERMISSIONS.GSALER_SLIDER_NCC],
    [ROUTES.MANAGE_CART]: [PERMISSIONS.PRODUCT_MANAGE_CART],
    [ROUTES.PROFILE]: [PERMISSIONS.PRODUCT_PROFILE],
};