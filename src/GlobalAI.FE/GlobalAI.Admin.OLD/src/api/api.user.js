import axios from 'axios';
// import store from '../store';
// import { USER_MUTATIONS } from '../store/types/user.types';
import { API_ENDPOINT } from './api.endpoint';

const baseURL = import.meta.env?.VITE_AUTH_ENDPOINT || '';
const tokenEndpoint = `${baseURL}/${API_ENDPOINT.userRegister}`;

export const registerUser = (body) => {

    const config = {
        headers: {
            'Content-Type': 'application/json'
        }
    };

    return axios.post(tokenEndpoint, body, config);
};