import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

//Get all danh mục sản phẩm phân trang
export const getAllCategoryProductPhanTrang = async (
  pageSize,
  pageNumber,
  skip
) => {
  try {
    const response = await http.get(
      API_ENDPOINT.getAllCategoryProductPhanTrang(pageSize, pageNumber, skip)
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Thêm danh mục sản phẩm
export const postCategoryProduct = async (categoryProductData) => {
  try {
    const res = await http.post(
      API_ENDPOINT.postCategoryProduct,
      categoryProductData
    );
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Xoá danh mục sản phẩm theo id
export const deleteCategoryProduct = async (id) => {
  try {
    const response = await http.delete(API_ENDPOINT.deleteCategoryProduct(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Get danh mục sản phẩm theo id
export const getCategoryProductById = async (id) => {
  try {
    const response = await http.get(API_ENDPOINT.getCategoryProductById(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Cập nhật danh mục sản phẩm
export const updateCategoryProduct = async (categoryProductData) => {
  const { id, ...data } = categoryProductData;
  try {
    const res = await http.put(API_ENDPOINT.putCategoryProduct(id), data);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};
