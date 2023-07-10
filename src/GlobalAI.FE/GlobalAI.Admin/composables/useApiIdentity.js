import axios from 'axios';
import store from '../store';
// import { apiRefreshToken } from './useApiAuth';

const env = useRuntimeConfig();

const baseURL = env.public.apiEndpoint || '';

const instance = axios.create({
    baseURL,
    headers: {
        Authorization: `Bearer ${store.getters.accessToken}`
    }
});

instance.interceptors.response.use(function (response) {
    // Any status code within the range of 2xx cause this function to trigger
    // Do something with response data
    return response;
}, async function (error) {
    const originalRequest = error.config;
    if (error.response.status === 401 && !originalRequest._retry && store.getters.refreshToken) {
        originalRequest._retry = true;

        const refreshToken = store.getters.refreshToken;
        // await apiRefreshToken(refreshToken);

        // originalRequest.headers.Authorization = `Bearer ${store.getters.accessToken}`;
        // instance.defaults.headers = {
        //     Authorization: `Bearer ${store.getters.accessToken}`
        // };

        return instance(originalRequest);
    }
    return Promise.reject(error);
});

export default instance;