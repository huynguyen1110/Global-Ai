import { defineStore } from 'pinia'

export const useUserStorage = defineStore('user', {
    state: () => ({
        accessToken: null,
        refreshToken: null,
        permissions: [],
    }),
    getters: {
        getAccessToken: (state) => state.accessToken,
        getRefreshToken: (state) => state.refreshToken,
        getPpermissions: (state) => state.permissions,
        isLoggedIn: state => !!state.accessToken,
    },
    actions: {
        login(payload) {
            const { accessToken, refreshToken } = payload;

            this.accessToken = accessToken;
            this.refreshToken = refreshToken;
        },
        updatePermissions(payload) {
            this.permissions = Array.isArray(payload) ? payload : []
        },
        logout() {
            this.accessToken = null;
            this.refreshToken = null;
            this.permissions = null;
        },
    },
    persist: true, 
});