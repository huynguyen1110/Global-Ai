import { PERMISSIONS_ROUTE_CONFIG } from "~~/lib/permissions";
import { NOT_REQUIRED_LOGIN, ROUTES } from "~~/lib/routeConfig";
import { useUserStorage } from "~~/stores/user";

export default defineNuxtRouteMiddleware(async (to, from) => {
    if (process.server) return;

    const userStorage = useUserStorage();
    const { $toast } = useNuxtApp();

    console.log("hihi => ", to);
    const matchedPath = to.matched[0]?.path?.toLowerCase();
    console.log('match', matchedPath)
    if (matchedPath) {
        if (
            !userStorage.isLoggedIn &&
            !NOT_REQUIRED_LOGIN.includes(matchedPath)
        ) {
            return navigateTo(ROUTES.TRANGCHU);
        } else if (userStorage.isLoggedIn && matchedPath === ROUTES.LOGIN) {
            return navigateTo(ROUTES.HOME);
        } 
        //  else if (userStorage.isLoggedIn && !NOT_REQUIRED_LOGIN.includes(matchedPath)) {
        //     let allowNavigate = false;
    
        //     if (!PERMISSIONS_ROUTE_CONFIG[matchedPath]) {
        //         allowNavigate = false;
        //     } else {
        //         const userPermission = userStorage.permissions;
        //         const permissionRoute = PERMISSIONS_ROUTE_CONFIG[matchedPath];
        //     if (!PERMISSIONS_ROUTE_CONFIG[matchedPath]) {
        //         allowNavigate = false;
        //     } 
        //     else {
        //         const userPermission = userStorage.permissions;
        //         const permissionRoute = PERMISSIONS_ROUTE_CONFIG[matchedPath];
                
        //         if (userPermission && Array.isArray(userPermission)) {
        //             let count = 0;
        //             permissionRoute.forEach(per => {
        //                 if (userPermission.includes(per)) {
        //                     count++;
        //                 }
        //             });
        //         if (userPermission && Array.isArray(userPermission)) {
        //             let count = 0;
        //             permissionRoute.forEach(per => {
        //                 if (userPermission.includes(per)) {
        //                     count++;
        //                 }
        //             });
    
        //             allowNavigate = count === permissionRoute.length;
        //         }
        //             allowNavigate = count === permissionRoute.length;
        //         }
    
        //     }
        //     }
    
        //     if (!allowNavigate) {
        //         $toast.warn("Bạn không có quyền truy cập trang này");
        //         return navigateTo(ROUTES.ERROR_FORBIDDEN);
        //     }
        // }   
    }

    
 
});
