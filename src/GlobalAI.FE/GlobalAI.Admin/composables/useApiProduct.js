import { faShareAltSquare } from "@fortawesome/free-solid-svg-icons";
import http from "./useApi";
import { API_ENDPOINT } from "~~/api/api.endpoint";
export const getSanPhamDanhMucPhanTrang = async (
    categoryId,
    pageSize,
    pageNumber,
    Skip
) => {
    const res = await http.get(
        API_ENDPOINT.getSanPhamDanhMucPhanTrang(
            categoryId,
            pageSize,
            pageNumber,
            Skip
        )
    );
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};
export const getSanPhamDanhMuc = async (id) => {
    console.log(id);
    const res = await http.get(API_ENDPOINT.getSanPhamDanhMuc(id));
    console.log(res);
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};
// Lấy sản phẩm dựa theo ID
export const getFullSanPham = async (id) => {
    const res = await http.get(API_ENDPOINT.getFullSanPham(id));
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getDanhMucSanPham = async () => {
    const res = await http.get(API_ENDPOINT.getDanhMucSanPham);
    try {
        return Promise.resolve(res);
    } catch (error) {
        return Promise.reject(error);
    }
};
export const getSanPhamByIdGStore = async (pageSize, pageNumber, skip) => {
    try {
        const response = await http.get(
            API_ENDPOINT.getSanPhamByIdGStore(pageSize, pageNumber, skip)
        );
        return Promise.resolve(response.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getSanPhamHome = async (SortBy, SortOrder) => {
    try {
        const response = await http.get(
            API_ENDPOINT.getSanPhamTrangHome(SortBy, SortOrder)
        );
        return Promise.resolve(response.data);
    } catch (error) {
        return Promise.reject(error);
    }
};

export const getProductAttributes = async (id) => {
    try {
        const response = await http.get(API_ENDPOINT.getThuocTinhSanPham(id));
        return Promise.resolve(response.data);
    } catch (error) {
        return Promise.reject(error);
    }
};

// Cương code

// Lấy tất cả sản phẩm và phân trang
// Xoá sản phẩm dựa theo ID

export const getGioHang = async () => {
    const res = await http.get(API_ENDPOINT.getGioHang);
    try {
        return Promise.resolve(res.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getSanPhamById = async (id) => {
    const res = await http.get(API_ENDPOINT.getSanPhamById(id));
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getSanPhamByNguoiMua = async () => {
    const res = await http.get(API_ENDPOINT.getSanPhamByNguoiMua);
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(res);
    }
};

export const createGioHang = async (body) => {
    const res = await http.post(API_ENDPOINT.createGioHangbyIdSanPham, body);
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(res);
    }
};

export const editGioHang = async (id, body) => {
    const res = await http.put(API_ENDPOINT.editGioHang(id), body);
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(res);
    }
};

export const deleteGioHang = async (id) => {
    const res = await http.delete(API_ENDPOINT.deleteGioHang(id));
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(res);
    }
};

export const createFullDonHang = async (body) => {
    const res = await http.post(API_ENDPOINT.createDonHangFull, body);
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(res);
    }
};

export const getPhanTrangSanPham = async (pageSize, pageNumber, Skip) => {
    console.log(pageSize, pageNumber, Skip);
    const res = await http.get(
        API_ENDPOINT.getPhanTrangSanPham(pageSize, pageNumber, Skip)
    );
    try {
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};
export const updateProduct = async (id, product) => {
    try {
        const res = await http.put(API_ENDPOINT.putProduct(id), product);
        return Promise.resolve(res.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

// Cương code

// Lấy tất cả sản phẩm và phân trang
export const getAllProducts = async (pageSize, pageNumber, skip) => {
    try {
        const response = await http.get(
            API_ENDPOINT.getAllProducts(pageSize, pageNumber, skip)
        );
        return Promise.resolve(response.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

// Xoá sản phẩm dựa theo ID
export const deleteProduct = async (id) => {
    try {
        const response = await http.delete(API_ENDPOINT.deleteProduct(id));
        return Promise.resolve(response.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

// Lấy sản phẩm dựa theo ID
export const getProductById = async (id) => {
    try {
        const response = await http.get(API_ENDPOINT.getProductById(id));
        return Promise.resolve(response.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

// Thêm sản phẩm
export const postProduct = async (productData) => {
    try {
        const res = await http.post(API_ENDPOINT.postProducts, productData);
        return Promise.resolve(res.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

//Get Image
export const getImage = async () => {
    const res = await http.get(API_ENDPOINT.getImage);
    try {
        Promise.resolve(res);
    } catch (err) {
        Promise.reject(err);
    }
};

export const postImage = async (formData) => {
    try {
        const res = await http.post(API_ENDPOINT.postImage, formData);
        return Promise.resolve(res.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getPostById = async (id) => {
    try {
        const res = await http.get(API_ENDPOINT.getPostById(id));
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getBaiTinByLSlug = async (slug) => {
    try {
        const res = await http.get(API_ENDPOINT.getBaiTinBySlug(slug));
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getGioHangByIdSanPham = async (id) => {
    try {
        const res = await http.get(API_ENDPOINT.getGioHangByIdSanPham(id));
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getAllDanhMucBaiTin = async () => {
    try {
        const res = await http.get(API_ENDPOINT.getAllDanhMucBaiTin());
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

/**
 * LẤY DANH MỤC THUỘC TÍNH THEO ID
 * @param {*} id
 * @returns
 */
export const getDanhMucThuocTinhById = async (id) => {
    try {
        const res = await http.get(API_ENDPOINT.getDanhMucThuocTinhById(id));
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

/**
 * LẤY LIST DANH MỤC THUỘC TÍNH
 * @param {*} id
 * @returns
 */
export const getListDanhMucThuocTinh = async () => {
    try {
        const res = await http.get(API_ENDPOINT.getListDanhMucThuocTinh);
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

/**
 * LẤY CHI TIẾT SẢN PHẨM CHO ADMIN
 * @param {*} id
 * @returns
 */
export const getSanPhamAdminById = async (id) => {
    try {
        const res = await http.get(API_ENDPOINT.getSanPhamAdminById(id));
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

/**
 * THÊM SẢN PHẨM CHI TIẾT VÀO SẢN PHẨM
 * @param {*} body
 * @returns
 */
export const useApiAddSanPhamChiTiet = async (body) => {
    try {
        const res = await http.post(API_ENDPOINT.addSanPhamChiTiet, body);
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

/**
 * CẬP NHẬT SẢN PHẨM CHI TIẾT
 * @param {*} body
 * @returns
 */
export const useApiUpdateSanPhamChiTiet = async (body) => {
    try {
        const res = await http.put(API_ENDPOINT.updateSanPhamChiTiet, body);
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

/**
 * XÓA SẢN PHẨM CHI TIẾT
 * @param {*} body
 * @returns
 */
export const useApiDeleteSanPhamChiTiet = async (id) => {
    try {
        const res = await http.delete(API_ENDPOINT.deleteSanPhamChiTiet(id));
        return Promise.resolve(res);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const getIdSanPhamCtByIdSanPhamAndTTGT = async (idSanPham, gttt) => {
    try {
        const response = await http.get(
            API_ENDPOINT.getIdSanPhamCtByIdSanPhamAndTTGT(idSanPham, gttt)
        );
        return Promise.resolve(response.data);
    } catch (error) {
        return Promise.reject(error);
    }
};
