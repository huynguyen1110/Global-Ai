import { useUserStorage } from '~~/stores/user';
import http from './useApi';
import { API_ENDPOINT } from '~~/api/api.endpoint';

/**
 * ĐĂNG KÝ TÀI KHOẢN
 * @param {} body 
 * @returns 
 */
export const registerUser = async (body) => {
    const res = await http.post(API_ENDPOINT.userRegister, body);
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

/**
 * LẤY QUYỀN CHO USER HIỆN TẠI
 * @returns 
 */
export const getPermissions = async () => {
    const res = await http.get(API_ENDPOINT.getPermission);
    try {
        
        if (res.data.data && Array.isArray(res.data.data)) {
            const userStorage = useUserStorage();
            userStorage.updatePermissions(res.data.data);    
        }
        
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};
