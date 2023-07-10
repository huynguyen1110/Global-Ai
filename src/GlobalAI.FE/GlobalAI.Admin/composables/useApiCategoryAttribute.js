import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

export const getAllDanhMucThuocTinhSanPham = async (
  pageSize,
  pageNumber,
  skip
) => {
  try {
    const response = await http.get(
      API_ENDPOINT.getAllDanhMucThuocTinhSanPham(pageSize, pageNumber, skip)
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const getDanhMucThuocTinhSanPhamById = async (id) => {
  try {
    const response = await http.get(
      API_ENDPOINT.getDanhMucThuocTinhSanPhamById(id)
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const postDanhMucThuocTinhSanPham = async (dmAttData) => {
  try {
    const res = await http.post(
      API_ENDPOINT.postDanhMucThuocTinhSanPham,
      dmAttData
    );
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const deleteDanhMucThuocTinhSanPham = async (id) => {
  try {
    const response = await http.delete(
      API_ENDPOINT.deleteDanhMucThuocTinhSanPham(id)
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

export const updateDanhMucThuocTinhSanPham = async (dmAttData) => {
  try {
    const res = await http.put(
      API_ENDPOINT.putDanhMucThuocTinhSanPham,
      dmAttData
    );
    console.log(res);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
