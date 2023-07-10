import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

export const postImage = async (formData) => {
  try {
    const res = await http.post(API_ENDPOINT.postImage, formData);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
