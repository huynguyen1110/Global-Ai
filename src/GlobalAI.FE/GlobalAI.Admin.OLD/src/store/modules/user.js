import { USER_MUTATIONS } from "../types/user.types";

export default {
    state: {
        accessToken: null,
        refreshToken: null,
        permissions: [],
    },
    getters: {
        accessToken: (state) => state.accessToken,
        refreshToken: (state) => state.refreshToken,
        permissions: (state) => state.permissions,
    },
    mutations: {
        [USER_MUTATIONS.LOGIN]: (state, payload) => {
            const { accessToken, refreshToken } = payload;

            state.accessToken = accessToken;
            state.refreshToken = refreshToken;
        },
        [USER_MUTATIONS.UPDATE_PERMISSIONS]: (state, payload) => state.permissions = Array.isArray(payload) ? payload : [],
        [USER_MUTATIONS.LOGOUT]: (state) => {
            Object.keys(state).forEach(key => {
                state[key] = null;
            })
        },
    }
}
