import { defineStore } from "pinia";

export const useCartStorage = defineStore("cart", {
  state: () => ({
    cartItems: [],
  }),
  getters: {
    getItemById: (state) => (id) =>
      state.cartItems.find((item) => item.id === id),
    getTotalPrice: (state) =>
      state.cartItems.reduce((total, item) => total + item.price, 0),
    getFullSanPham: (state) => state.cartItems
  },
  mutations:{
    toggleCheckBox: (state, id) => {
      const item = state.cartItems.find(item => item.id === id)
      item.checked = !item.checked;
    }
  },
  actions: {
    async getGioHang(){
      try {
        const response = await getSanPhamByNguoiMua();
        console.log(response);
        this.cartItems = response?.data?.data || [];
      } catch (error) {
        console.log(error);
      }
    },
  },
});
