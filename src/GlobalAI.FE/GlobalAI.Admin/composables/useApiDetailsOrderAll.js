import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

export const getAllDetailsOrderAll = async () => {
  try {
    const response = await http.get(API_ENDPOINT.getAllDetailsOrderAll);
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Thêm chi tiết đơn hàng
export const postDetailsOrderAll = async (detailsOrderAllData) => {
  console.log(API_ENDPOINT.postPosts);
  try {
    const res = await http.post(
      API_ENDPOINT.postDetailsOrderAll,
      detailsOrderAllData
    );
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Xoá chi tiết đơn hàng theo id
export const deleteDetailsOrderAll = async (id) => {
  console.log(API_ENDPOINT.deleteDetailsOrderAll(id));
  try {
    const response = await http.delete(API_ENDPOINT.deleteDetailsOrderAll(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Lấy chi tiết đơn hàng theo id
export const getDetailsOrderAllById = async (id) => {
  try {
    const response = await http.get(API_ENDPOINT.getDetailsOrderAllById(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Cập nhật chi tiết đơn hàng
// export const updateDetailsOrderAll = async (id, detailsOrderAllData) => {
//   try {
//     const res = await http.put(
//       API_ENDPOINT.putDetailsOrderAll(id),
//       detailsOrderAllData
//     );
//     console.log("Co data k", res);
//     return Promise.resolve(res.data);
//   } catch (err) {
//     return Promise.reject(err);
//   }
// };

export const updateDetailsOrderAll = async (detailsOrderAllData) => {
  const { id, ...data } = detailsOrderAllData;
  try {
    const res = await http.put(API_ENDPOINT.putDetailsOrderAll(id), data);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
