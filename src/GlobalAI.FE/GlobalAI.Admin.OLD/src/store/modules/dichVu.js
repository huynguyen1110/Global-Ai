import { DICH_VU_MUTATIONS } from "../types/dichVu.types";


export default {
    state: {
        listDichVu: [],
        dichVuHienTai: {
            tenDichVu: '',
            maDichVu: '',
            id: null,
        }
    },
    getters: {
        tenDichVuHienTai: (state) => state.dichVuHienTai.tenDichVu,
        listDichVu: (state) => state.listDichVu,
        tenDichVuByMa: state => maDichVu => {
            return state.listDichVu.find(item => item.maDichVu === maDichVu)?.tenDichVu || ''
        },
        dichVuByMa: state => maDichVu => {
            return state.listDichVu.find(item => item.maDichVu === maDichVu)
        },
    },
    mutations: {
        [DICH_VU_MUTATIONS.UPDATE_TEN_HIEN_TAI]: (state, payload) => {
            state.dichVuHienTai = {...payload};
        },
        [DICH_VU_MUTATIONS.UPDATE_LIST_DICH_VU]: (state, payload) => {
            console.log({ payload });
            state.listDichVu = [...payload];
        },
    }
}
