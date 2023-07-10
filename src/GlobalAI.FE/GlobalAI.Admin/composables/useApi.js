import axios from "axios";
import { useUserStorage } from "~~/stores/user";
import { useApiRefreshToken } from "./useApiAuth";

const instance = axios.create();

/**
 * INTERCEPT VÀO REQUEST CALL API
 */
instance.interceptors.request.use((config) => {
  const env = useRuntimeConfig();
  const userStorage = useUserStorage();

  const baseURL = env.public.apiEndpoint || "";

  config.baseURL = baseURL;
  config.headers.Authorization = `Bearer ${userStorage.accessToken}`;

  return config;
});

/**
 * INTERCEPT VÀO RESPONSE TRẢ VỀ
 */
instance.interceptors.response.use(
  (response) => {
    // Any status code within the range of 2xx cause this function to trigger
    // Do something with response data
    if (
      response.status === 200 &&
      response.data.code !== 200 &&
      response?.data?.message
    ) {
      return response;
    }

    return response;
  },
  async (error) => {
    const originalRequest = error.config;
    const userStorage = useUserStorage();

    // Xử lý lấy access token mới
    if (
      error.response.status === 401 &&
      !originalRequest._retry &&
      userStorage.refreshToken
    ) {

      originalRequest._retry = true;

      const refreshToken = userStorage.refreshToken;
      await useApiRefreshToken(refreshToken);
      await getPermissions();
      originalRequest.headers.Authorization = `Bearer ${
        useUserStorage().accessToken
      }`;
      instance.defaults.headers = {
        Authorization: `Bearer ${useUserStorage().accessToken}`,
      };

      return instance(originalRequest);
    }

    // Xử lý lỗi 401 do api validate các trường dữ liệu
    const deepError = error?.response?.data;
    console.log(error.response.status, deepError.errors, Object.keys(deepError.errors).length);
    if (
      error.response.status === 400 &&
      deepError.errors &&
      Object.keys(deepError.errors).length > 0
    ) {
      const msg = deepError.errors[Object.keys(deepError.errors)[0]][0];
      const { $toast } = useNuxtApp();
      $toast.error(msg);
      return Promise.resolve({ status: -1 });
    }

    return Promise.reject(error);
  }
);

export default instance;
