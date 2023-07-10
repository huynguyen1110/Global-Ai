import axios from "axios";
import { API_ENDPOINT } from "~~/api/api.endpoint";
import { useUserStorage } from "~~/stores/user";

/**
 * LOGIN
 * @param {*} param0
 * @returns
 */
export const useApiLogin = ({ username = "", password = "" }) => {
  const env = useRuntimeConfig();

  const baseURL = env.public.authEndpoit || "";
  const grantTypeLogin = env.public.apiGrantType || "";
  const scope = env.public.apiAuthScope || "";
  const tokenEndpoint = `${baseURL}/${API_ENDPOINT.login}`;

  const config = {
    headers: {
      "Content-Type": "application/x-www-form-urlencoded",
    },
  };

  const params = new URLSearchParams();
  params.append("grant_type", grantTypeLogin);
  params.append("username", username);
  params.append("password", password);
  params.append("scope", scope);

  return axios.post(tokenEndpoint, params, config);
};

/**
 * REFRESH TOKEN
 * @param {*} refreshToken
 */
export const useApiRefreshToken = async (refreshToken = "") => {
  const env = useRuntimeConfig();
  const baseURL = env.public.authEndpoit || "";

  const config = {
    headers: {
      "Content-Type": "application/x-www-form-urlencoded",
    },
  };

  const params = new URLSearchParams();

  params.append("grant_type", "refresh_token");
  params.append("refresh_token", refreshToken);

  const tokenEndpoint = `${baseURL}/${API_ENDPOINT.refreshToken}`;
  const userStorage = useUserStorage();
  try {
    const res = await axios.post(tokenEndpoint, params, config);
    const userStorage = useUserStorage();
    if (res.status === 200) {
      const userStorage = useUserStorage();

      userStorage.login({
        accessToken: res.data.access_token,
        refreshToken: res.data.refresh_token,
      });

    } else {
      userStorage.logout();
      // store.commit(USER_MUTATIONS.LOGOUT);
      window.location.href = "/auth/login";
    }
  } catch (error) {
    // store.commit(USER_MUTATIONS.LOGOUT);
    console.error("REFRESH TOKEN => ", error);

    userStorage.logout();
    window.location.href = "/auth/login";
  }
};
