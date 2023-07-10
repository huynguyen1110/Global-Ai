import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

export const getAllOrder = async (pageSize, pageNumber, skip) => {
  try {
    const res = await http.get(
      API_ENDPOINT.getAllOrder(pageSize, pageNumber, skip)
    );
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Thêm đơn hàng
export const postOrders = async (
  maDonHang,
  ngayHoanThanh,
  idGStore,
  idNguoiMua,
  soTien,
  hinhThucThanhToan,
  diaChi
) => {
  try {
    const response = await http.post(
      API_ENDPOINT.postOrders(
        maDonHang,
        ngayHoanThanh,
        idGStore,
        idNguoiMua,
        soTien,
        hinhThucThanhToan,
        diaChi
      )
    );
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Xoá đơn hàng dựa theo id
export const deleteOrder = async (id) => {
  console.log(API_ENDPOINT.deleteOrder(id));
  try {
    const response = await http.delete(API_ENDPOINT.deleteOrder(id));
    return Promise.resolve(response.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Lấy đơn hàng dựa theo id
export const getOrderById = async (id) => {
  try {
    const res = await http.get(API_ENDPOINT.getOrderById(id));
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Cập nhật đơn hàng theo id
export const updateOrder = async (id, order) => {
  try {
    const res = await http.put(API_ENDPOINT.putOrder(id), order);
    return Promise.resolve(res.data);
  } catch (err) {
    return Promise.reject(err);
  }
};

// Lấy chi tiết đơn hàng theo mã đơn hàng 
export const getDetailOrderByCodeOrders = async (id) => {
  try{
    const res = await http.get(API_ENDPOINT.getDetailOrderByCodeOrders(id))
    return Promise.resolve(res.data)
  }catch(err){
    return Promise.reject(err)
  }
}