import { defineStore } from "pinia";

export const useSanPhamStorage = defineStore("sanPham", {
  state: () => ({
    idSanPham: 0,
  }),
  getters: {
    getIdSanPham: (state) => state.idSanPham,
  },
  actions: {
    changeShowSideBar(payload) {
      this.idSanPham = payload;
    },
  },
});
