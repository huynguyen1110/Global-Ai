import { faShareAltSquare } from "@fortawesome/free-solid-svg-icons";
import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";

export const postProductBid = async (body) => {
    try {
        const res = await http.post(API_ENDPOINT.postProductBid, body);
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const postTragiaDetail = async (body) => {
    try {
        const res = await http.post(API_ENDPOINT.postTragiaDetail, body);
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

// Lấy chat trả giá
export const getDetailedPayment = async (idTraGia) => {
    try {
        const res = await http.get(API_ENDPOINT.getDetailedPayment(idTraGia));
        return Promise.resolve(res);
    } catch (error) {
        return Promise.reject(error);
    }
};

export const getIDPaymentNews = async(idSanPham) => {
  console.log(idSanPham);
  try {
    const res = await http.get(API_ENDPOINT.getIDPayment(idSanPham))
    return Promise.resolve(res);
  } catch (error) {
    return Promise.reject(error)
  }
}

// get all trả giá của user
export const getProductBidUser = async(IdSanPham , GiaTien , status , pageSize , pageNumber , Skip) => {
  try{
    const res = await http.get(API_ENDPOINT.getProductBidUser(IdSanPham , GiaTien , status , pageSize , pageNumber , Skip))
    return Promise.resolve(res)
  }catch(error){
    return Promise.reject(error)
  }
}

export const getAllChatUser = async () => {
    try {
        const res = await http.get(API_ENDPOINT.getAllChatUser)
        return Promise.resolve(res)
    }catch(error){
        return Promise.reject(error)
    }
}