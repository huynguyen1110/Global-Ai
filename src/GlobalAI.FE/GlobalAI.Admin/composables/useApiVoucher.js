import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

// Lấy tất cả voucher và phân trang
export const getAllVoucherPhanTrang = async (pageSize, pageNumber, skip) => {
  try {
    const response = await http.get(
      API_ENDPOINT.getAllVoucherPhanTrang(pageSize, pageNumber, skip)
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Xoá bài tin dựa theo id
export const deleteVoucher = async (id) => {
  console.log(API_ENDPOINT.deleteVoucher(id));
  try {
    const response = await http.delete(API_ENDPOINT.deleteVoucher(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Lấy bài tin dựa theo ID
export const getVoucherById = async (id) => {
  try {
    const response = await http.get(API_ENDPOINT.getVoucherById(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Thêm voucher
export const postVoucher = async (voucherData) => {
  try {
    const res = await http.post(API_ENDPOINT.postVouchers, voucherData);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const updateVoucher = async (voucherData) => {
  try {
    const res = await http.put(API_ENDPOINT.putVoucher, voucherData);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
