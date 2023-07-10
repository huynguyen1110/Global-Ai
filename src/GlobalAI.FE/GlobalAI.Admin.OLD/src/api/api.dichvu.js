import store from "../store";
import { DICH_VU_MUTATIONS } from "../store/types/dichVu.types";
import { API_ENDPOINT } from "./api.endpoint";
import http from './api';
import httpIdentity from './api.identity';
import { USER_MUTATIONS } from "../store/types/user.types";

export const getListDichVu = async () => {
    const res = await http.get(API_ENDPOINT.getAllDichVu);
    try {
        const listDichVu = res.data?.map(item => ({
            ...item,
            image: new URL('/src/assets/images/giay-xac-nhan.jpg', import.meta.url).href,
            link: `/yeu-cau/${item?.maDichVu}`,
        }));
        store.commit(DICH_VU_MUTATIONS.UPDATE_LIST_DICH_VU, listDichVu);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getMyPermissions = async () => {
    const res = await httpIdentity.get(API_ENDPOINT.getMyPermissions);
    try {
        const listPermissions = res.data;
        store.commit(USER_MUTATIONS.UPDATE_PERMISSIONS, listPermissions);

        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};