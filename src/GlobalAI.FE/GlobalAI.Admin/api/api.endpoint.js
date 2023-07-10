// const config = useRuntimeConfig();
// const baseUrl = config.public.apiEndpoint;
export const API_ENDPOINT = {
    login: "connect/token",
    refreshToken: "connect/token",
    userRegister: "api/core/user/register",
    getPermission: "api/core/permission",
    getSanPhamDanhMuc: (id) =>
        `api/product/sanpham/danh-muc/${id}?pageSize=10&pageNumber=1&Skip=0`,
    getSanPhamDanhMucPhanTrang: (categoryId, pageSize, pageNumber, Skip) =>
        `api/product/sanpham/danh-muc/${categoryId}?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${Skip}`,
    getFullSanPham: (id) =>
        `api/product/sanpham/danh-muc/${id}?pageSize=-1&pageNumber=1&Skip=0`,
    getDanhMucSanPham: `/api/product/sanpham/danh-muc?pageSize=-1&pageNumber=1&Skip=0`,

    // Get sản phẩm mới nhất
    getSanPhamTrangHome: (SortBy, SortOrder) =>
        `/api/product/sanpham/home-page?SortBy=${SortBy}&SortOrder%20=${SortOrder}&pageSize=15&pageNumber=1&Skip=0`,
    getSanPhamByIdGStore: (pageSize, pageNumber, skip) =>
        `api/product/sanpham/get-sanpham-gstore?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,
    getThuocTinhSanPham: (id) => `/api/product/sanpham/san-pham-ct/${id}`,
    //Image
    postImages: "api/filFe/upload?folder=image",
    postFile: (folder) => `api/file/upload?folder=${folder}`,
    // Quản lý đơn hàng
    getAllOrder: (pageSize, pageNumber, skip) =>
        `/api/product/donhang?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,
    postProducts: `api/product/sanpham`,
    putProduct: (id) => `api/product/sanpham/${id}`,
    getSanPhamIdGStore: (id) => `/api/product/sanpham/get-idGstore/${id}`,
    // API Giỏ Hàng
    getGioHang: "api/product/giohang",
    getGioHangByIdSanPham: (id) =>
        `api/product/giohang/giohangByIdSanPham/${id}`,
    getSanPhamById: (id) => `api/product/sanpham/${id}`,
    getSanPhamByNguoiMua: "api/product/giohang/sanpham-giohang",
    createGioHangbyIdSanPham: "api/product/giohang",
    editGioHang: (id) => `api/product/giohang/${id}`,
    deleteGioHang: (id) => `api/product/giohang/${id}`,
    createDonHangFull: "api/product/donhang/full",
    getAllProducts: (pageSize, pageNumber, skip) =>
        `api/product/sanpham?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,
    deleteProduct: (id) => `api/product/sanpham/${id}`,
    getProductById: (id) => `api/product/sanpham/${id}`,

    postProducts: `api/product/sanpham`,
    putProduct: (id) => `api/product/sanpham/${id}`,
    //Image
    postImages: "api/filFe/upload?folder=image",
    // Quản lý đơn hàng
    getAllOrder: (pageSize, pageNumber, skip) =>
        `/api/product/donhang?pageSize=${pageSize}&pageNumber=${pageNumber}&skip=${skip}`,

    postOrder: `/api/product/donhang`,
    postOrders: (
        maDonHang,
        ngayHoanThanh,
        idGStore,
        idNguoiMua,
        soTien,
        hinhThucThanhToan,
        diaChi
    ) =>
        `/api/product/donhang?MaDonHang=${maDonHang}&NgayHoanThanh=${ngayHoanThanh}&IdGStore=${idGStore}&IdNguoiMua=${idNguoiMua}&SoTien=${soTien}&HinhThucThanhToan=${hinhThucThanhToan}&DiaChi=${diaChi}`,

    deleteOrder: (id) => `/api/product/donhang/${id}`,

    // getOrderById: (id) => `api/product/donhang/${id}`,
    getOrderById: (id) => `/api/product/donhang/${id}`,

    putOrder: (id) => `/api/product/donhang/${id}`,

    getDetailsOrder: (id) => `/api/product/donhang/full?maDonHang=${id}`,

    // Api Bài đăng
    getPostById: (id) => `/api/product/bai-tin/${id}`,
    getBaiTinBySlug: (slug) => `/api/product/bai-tin/find/slug/${slug}`,
    getBaiTinPhanTrang: (pageSize, pageNumber, skip) =>
        `/api/product/bai-tin/find-all?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    getAllPostPhanTrang: (pageSize, pageNumber, skip) =>
        `/api/product/bai-tin/find-all?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    getBaiTinTheoDanhMuc: (id, pageSize, pageNumber, skip) =>
        `/api/product/bai-tin/find-all?idDanhMuc=${id}&pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    deletePost: (id) => `/api/product/bai-tin?id=${id}`,

    postPosts: `/api/product/bai-tin`,

    putPost: `/api/product/bai-tin`,

    //Image
    postImage: `/api/file/upload?folder=image`,

    // Voucher
    getAllVoucherPhanTrang: (pageSize, pageNumber, skip) =>
        `/api/product/voucher/find-all?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    deleteVoucher: (id) => `/api/product/voucher?id=${id}`,

    getVoucherById: (id) => `/api/product/voucher/${id}`,

    postVouchers: `/api/product/voucher`,

    putVoucher: `/api/product/voucher/update`,

    // Danh mục bài tin
    getAllPostCategoryPhanTran: (pageSize, pageNumber, skip) =>
        `/api/product/danh-muc-bai-tin/find-all?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,

    getDanhBaiTinMucNoiBat: () =>
        `/api/product/danh-muc-bai-tin/find-all?isParent=true&pageSize=-1`,

    getAllPostCategoryTree: () =>
        `/api/product/danh-muc-bai-tin/find-all-trees`,

    getPostCategoryById: (id) => `/api/product/danh-muc-bai-tin/${id}`,

    deletePostCategory: (id) => `/api/product/danh-muc-bai-tin?id=${id}`,

    postPostCategory: `/api/product/danh-muc-bai-tin`,

    putPostCategory: `/api/product/danh-muc-bai-tin`,

    // Danh mục sản phẩm
    getAllCategoryProductPhanTrang: (pageSize, pageNumber, skip) =>
        `/api/product/sanpham/danh-muc?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,
    postCategoryProduct: `/api/product/sanpham/danh-muc`,
    deleteCategoryProduct: (id) => `/api/product/sanpham/danh-muc?id=${id}`,
    getCategoryProductById: (id) => `/api/product/sanpham/danhmuc-id/${id}`,
    putCategoryProduct: (id) => `/api/product/sanpham/edit-danhmuc/${id}`,

    // Chi tiết đơn hàng
    getAllDetailsOrderAll: `/api/product/ct-donhang`,
    postDetailsOrderAll: `/api/product/ct-donhang`,
    getDetailsOrderAllById: (id) => `/api/product/ct-donhang/${id}`,
    deleteDetailsOrderAll: (id) => `/api/product/ct-donhang/${id}`,
    putDetailsOrderAll: (id) => `/api/product/ct-donhang/${id}`,
    getDetailOrderByCodeOrders: (id) =>
        `/api/product/donhang/full?maDonHang=${id}`,

    // API trả giá
    postProductBid: `/api/product/tra-gia`,
    postTragiaDetail: `/api/product/tra-gia/add-detail`,
    getDetailedPayment: (idTraGia) => `/api/product/tra-gia/${idTraGia}`,
    getAllChatUser: `/api/product/tra-gia/find-all?pageSize=-1&pageNumber=1&Skip=0`,
    getProductBidUser: (
        IdSanPham,
        GiaTien,
        status,
        pageSize,
        pageNumber,
        Skip
    ) =>
        `/api/product/tra-gia/find-all?IdSanPham=${IdSanPham}&GiaTien=${GiaTien}&status=${status}&pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${Skip}`,
    getIDPayment: (idSanPham) =>
        `/api/product/tra-gia/FindTraGiaBySanPham?idSanPham=${idSanPham}`,
    getDanhMucThuocTinhById: (id) => `api/product/danh-muc-thuoc-tinh/${id}`,
    getListDanhMucThuocTinh:
        "api/product/danh-muc-thuoc-tinh?pageSize=100&pageNumber=1",
    getSanPhamAdminById: (id) => `api/product/sanpham/admin/${id}`,
    addSanPhamChiTiet: `api/product/san-pham-chi-tiet`,
    updateSanPhamChiTiet: `api/product/san-pham-chi-tiet`,
    deleteSanPhamChiTiet: (id) => `api/product/san-pham-chi-tiet/${id}`,
    // Danh mục thuộc tính sản phẩm
    getAllDanhMucThuocTinhSanPham: (pageSize, pageNumber, skip) =>
        `/api/product/danh-muc-thuoc-tinh?pageSize=${pageSize}&pageNumber=${pageNumber}&Skip=${skip}`,
    getDanhMucThuocTinhSanPhamById: (id) =>
        `/api/product/danh-muc-thuoc-tinh/${id}`,
    postDanhMucThuocTinhSanPham: `/api/product/danh-muc-thuoc-tinh`,
    deleteDanhMucThuocTinhSanPham: (id) =>
        `/api/product/danh-muc-thuoc-tinh/${id}`,
    //Lấy ra id Sản phẩm chi tiết từ id sản phẩm + list thuộc tính
    getIdSanPhamCtByIdSanPhamAndTTGT: (idSanPham, gttt) =>
        `api/product/san-pham-chi-tiet/ct-ttgt?IdSanPham=${idSanPham}&Gttt=${gttt}`,
};
