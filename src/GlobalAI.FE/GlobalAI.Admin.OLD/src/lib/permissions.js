import store from '../store';

const Web = 'web.';
const Menu = "menu.";
const Tab = "tab.";
const Page = "page.";
const Table = "table.";
const Form = "form.";
const ButtonTable = "btn_table.";
const ButtonForm = "btn_form.";
const ButtonAction = "btn_action.";
const Div = "div.";

const DichVu1 = "dich-vu-1.";

export const PERMISISON_KEYS = {
    /** 1 CỬA */
    DichVu1_BtnXacNhan: 'DichVu1_BtnXacNhan',
    DichVu1_BtnDangXuLy: 'DichVu1_BtnDangXuLy',
    DichVu1_BtnDaXuLy: 'DichVu1_BtnDaXuLy',
    DichVu1_BtnHoanThanh: 'DichVu1_BtnHoanThanh',
    DichVu1_BtnTuChoi: 'DichVu1_BtnTuChoi',
    DichVu1_BtnPhanHoi: 'DichVu1_BtnPhanHoi',
    DichVu1_BtnChiTiet: 'DichVu1_BtnChiTiet',
    DichVu1_BtnPhongBanDangXuLy: 'DichVu1_BtnPhongBanDangXuLy',
    DichVu1_BtnPhongBanDaXuLy: 'DichVu1_BtnPhongBanDaXuLy',
    DichVu1_BtnPhongBanTuChoi: 'DichVu1_BtnPhongBanTuChoi',
    DichVu1_BtnPhongBanPhanHoi: 'DichVu1_BtnPhongBanPhanHoi',
}

export const PERMISSIONS_ALL = {
    [PERMISISON_KEYS.DichVu1_BtnXacNhan]: DichVu1 + ButtonAction + "xac-nhan",
    [PERMISISON_KEYS.DichVu1_BtnDangXuLy]: DichVu1 + ButtonAction + "dang-xu-ly",
    [PERMISISON_KEYS.DichVu1_BtnDaXuLy]: DichVu1 + ButtonAction + "da-xu-ly",
    [PERMISISON_KEYS.DichVu1_BtnHoanThanh]: DichVu1 + ButtonAction + "hoan-thanh",
    [PERMISISON_KEYS.DichVu1_BtnTuChoi]: DichVu1 + ButtonAction + "tu-choi",
    [PERMISISON_KEYS.DichVu1_BtnPhanHoi]: DichVu1 + ButtonAction + "phan-hoi",
    [PERMISISON_KEYS.DichVu1_BtnChiTiet]: DichVu1 + ButtonAction + "chi-tiet",
    [PERMISISON_KEYS.DichVu1_BtnPhongBanDangXuLy]: DichVu1 + ButtonAction + "pb-dang-xu-ly",
    [PERMISISON_KEYS.DichVu1_BtnPhongBanDaXuLy]: DichVu1 + ButtonAction + "pb-da-xu-ly",
    [PERMISISON_KEYS.DichVu1_BtnPhongBanTuChoi]: DichVu1 + ButtonAction + "pb-tu-choi",
    [PERMISISON_KEYS.DichVu1_BtnPhongBanPhanHoi]: DichVu1 + ButtonAction + "pb-phan-hoi",
}

export const PERMISSION_GUARDS = (permissonKey = '') => {
    return store.getters.permissions?.includes(PERMISSIONS_ALL[permissonKey]);
}