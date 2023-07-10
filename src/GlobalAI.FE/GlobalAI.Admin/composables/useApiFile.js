import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

export const postFile = async (file, folder = 'test') => {
  try {
    const api = `${API_ENDPOINT.postFile(folder)}`;

    const formData = new FormData();
    formData.append('file', file, file?.name);
    const res = await http.post(
      api, formData
    );
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
