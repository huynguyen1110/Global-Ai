/**
 * ĐỊNH NGHĨA TOÀN BỘ ROUTE TRONG APP
 */
export const ROUTES = {
    HOME: "/gsaler/home",
    TRANGCHU: '/',
    LOGIN: "/auth/login",
    ERROR_FORBIDDEN: '/error/403',
    ADMIN_DASHBOARD: '/admin/dashboard',
    ADMIN_PRODUCT: '/admin/product',
    ADMIN_PRODUCT_ADD: '/admin/product/addproduct',
    ADMIN_PRODUCT_EDIT: '/admin/product/editproduct/:id',
    ADMIN_ORDER: '/admin/order',
    ADMIN_ORDER_ADD: '/admin/order/addorder',
    ADMIN_ORDER_EDIT: '/admin/order/editorder/:id',
    ADMIN_ORDER_DETAILS: '/admin/order/orderdetails',
    GSALER_HOME: '/gsaler/home',
    GSALER_ADVISEMENT: '/gsaler/advisement',
    GSALER_PROFILE: '/gsaler/profile',
    GSALER_SLIDER_NCC: '/gsaler/sliderncc',
    MANAGE_CART: '/cart/managecart',
    PROFILE: '/profile',
};

/**
 * ROUTE KHÔNG CẦN LOGIN VẪN VÀO ĐƯỢC
 */
export const NOT_REQUIRED_LOGIN = [
    "/",
    "/landing",
    ROUTES.LOGIN,
    "/auth/register",
    "/auth/registermaster",
    "/auth/registergsaler",
    "/post/postdetail/:slug",
    "/post/postdanhmuc/:id",
    ROUTES.ERROR_FORBIDDEN
];
