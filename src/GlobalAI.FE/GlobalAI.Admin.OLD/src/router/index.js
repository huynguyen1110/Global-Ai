import { createRouter, createWebHistory } from 'vue-router';
import store from '../store';
import { defineAsyncComponent } from 'vue';

// LAYOUTS
const Auth = defineAsyncComponent(() => import('/src/layouts/Auth.vue'));
const Admin = defineAsyncComponent(() => import('/src/layouts/Admin.vue'));
const Layout = defineAsyncComponent(() => import('/src/layouts/LayoutLogin.vue'));



// AUTH
const Login = defineAsyncComponent(() => import('/src/pages/auth/Login.vue'));
const LoginGSaler = defineAsyncComponent(() => import('/src/pages/auth/LoginGSaler.vue'));
const Register = defineAsyncComponent(() => import('/src/pages/auth/Register.vue'));
const RegisterMaster = defineAsyncComponent(() => import('/src/pages/auth/RegisterMaster.vue'));
const RegisterGSaler = defineAsyncComponent(() => import('/src/pages/auth/RegisterGSaler.vue'));

// OTHERS
const Landing = defineAsyncComponent(() => import('/src/pages/Landing.vue'));
const Profile = defineAsyncComponent(() => import('/src/pages/Profile.vue'));
const Layout404 = defineAsyncComponent(() => import('/src/layouts/Layout404.vue'));
const Post = defineAsyncComponent(() => import('/src/pages/Posts.vue'));

// GSALER
const GSalerHome = defineAsyncComponent(() => import('/src/pages/GSaler/Home.GSaler.vue'));
//Gstore
const GstoreProfile = defineAsyncComponent(() => import('/src/pages/Gstore/GstoreProfile.vue'));

//Product
const ProductDetail = defineAsyncComponent(() => import('/src/pages/Product/ProductDetail.vue'));
const ProductCategory = defineAsyncComponent(() => import('/src/pages/Product/ProductCategory.vue'));

//CART
const ManageCart = defineAsyncComponent(() => import('/src/pages/Cart/ManageCart.vue'))

const Form = defineAsyncComponent(() => import('/src/pages/admin/Form.vue'));

// INDEX
const Index = defineAsyncComponent(() => import('/src/pages/Index.vue'));
//Post
const PostDetail = defineAsyncComponent(() => import('/src/pages/Post/PostDetail.vue'));

//ADMIN
const Dashboard = defineAsyncComponent(() => import('/src/pages/admin/Dashboard.vue'));


const routes = [
    // {
    //     path: '/login',
    //     name: 'Login',
    //     component: Login,
    //     meta: {
    //         layout: LayoutLogin,
    //         requiredLogin: false,
    //     }
    // },
    // {
    //     path: '/dich-vu/list',
    //     name: 'ListDichVu',
    //     component: ListDichVu,
    //     meta: {
    //         layout: LayoutDefault,
    //         requiredLogin: true,
    //     }
    // },
    {
        path: '/',
        component: Index,
        // redirect: '/login'
    },
    {
        path: "/auth",
        redirect: "/auth/login",
        component: Auth,
        children: [
            {
                path: "/auth/login",
                component: Login,
            },
            {
                path: "/auth/login/gsaler",
                component: LoginGSaler,
            },
            {
                path: "/auth/register",
                component: Register,
            },
            {
                path: "/auth/register-master",
                component: RegisterMaster,
            },
            {
                path: "/auth/register/gsaler",
                component: RegisterGSaler,
            },
        ],
    },
    {
        path: '/gsaler/home',
        name: 'GSalerHome',
        component: GSalerHome,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
    {
        path: '/admin/form/:id',
        name: 'Form',
        component: Form,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
    {
        path: "/card/manageCart/:id",
        name: 'ManageCart',
        component: ManageCart,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
    {
        path: "/product/detail/:id",
        name: 'ProductDetail',
        component: ProductDetail,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
    {
        path: "/product/category/:id",
        name: 'ProductCategory',
        component: ProductCategory,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
    {
        path: "/post/postDetail/:id",
        name: 'PostDetail',
        component: PostDetail,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
    {
        path: "/post/",
        name: 'Post',
        component: PostDetail,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
    {
        path: "/gstore/profile/:id",
        name: 'GstoreProfile',
        component: GstoreProfile,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
    {
        path: "/post/Posts",
        name: 'Post',
        component: Post,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
    {
        path: "/gstore/profile/:id",
        name: 'GstoreProfile',
        component: GstoreProfile,
        meta: {
            layout: Admin,
            requiredLogin: false,
        },
    },
   
    {
        path: "/landing",
        component: Landing,
    },
    {
        path: "/dashboard",
        component: Dashboard,
    },
    
    {
        path: "/profile",
        component: Profile,
    },
    { path: '/:pathMatch(.*)*', component: Layout404 },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

// navigation guard
// router.beforeEach((to, from, next) => {
//     console.log(to);
//     const accessToken = store.getters.accessToken;

//     if (accessToken && to.fullPath === '/login') {
//         next('/dich-vu/list');
//     }
//     else if (!accessToken && to.fullPath !== '/login' && to.meta.requiredLogin) {
//         next('/login');
//     }
//     else {
//         next();
//     }
// });


export default router