export const API_ENDPOINT = {
    login: 'connect/token',
    refreshToken: 'connect/token',
    getAllDichVu: 'api/dich-vu/get-all',
    addDichVu: 'api/sinh-vien/yeu-cau-dich-vu/add',
    uploadMultiFile: 'api/file/upload-mutiple',
    getAllYeuCau: maDichVu => `api/yeu-cau-dich-vu/get-yeu-cau-dich-vu?maDichVu=${maDichVu}`,
    getListCanBoByDichVu: maDichVu => `api/can-bo/get-can-bo-dich-vu?MaDichVu=${maDichVu}`,
    getListCanBoPhongBanByMaDichVu: maDichVu => `api/can-bo/can-bo-phong-ban-dich-vu?MaDichVu=${maDichVu}`,
    postMotCuaDaNhan: `api/yeu-cau-dich-vu/xac-nhan-mot-cua`,
    postCapNhatTrangThaiYeuCau: `api/can-bo/phan-hoi-yeu-cau/cap-nhat-trang-thai-yeu-cau`,
    postCanBoPhanHoi: `api/can-bo/phan-hoi-yeu-cau/cb-phan-hoi-yeu-cau`,
    putPhongBanDangXuLy: `api/yeu-cau-dich-vu/phong-ban/dang-xu-ly`,
    putPhongBanCapNhatTrangThai: `api/can-bo/phan-hoi-yeu-cau/phong-ban/trang-thai`,
    getChiTietYeuCau: idYeuCauDichVu => `api/yeu-cau-dich-vu/chi-tiet-yeu-cau-dich-vu?idYeuCauDichVu=${idYeuCauDichVu}`,
    getLogByYeuCau: idYeuCauDichVu => `api/log/yeu-cau-dich-vu/${idYeuCauDichVu}`,
    getMyPermissions: `api/user/permissions`,
    getListProductCategoryOne : `api/product/sanpham/danh-muc/1`,
    getListProductCategoryTwo : `api/product/sanpham/danh-muc/2`

}