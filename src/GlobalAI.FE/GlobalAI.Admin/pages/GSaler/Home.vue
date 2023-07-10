<template>
  <div class="m-h-[100vh] relative pb-[40px]">
    <div class="flex flex-wrap relative">
      <Advisement />
      <div>
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[40px] mt-[40px]"
        >
          Nhà Cung Cấp Nổi Bật
        </h1>
        <Sliderncc />
      </div>
      <card-list-product-home
        category="Sản phẩm mới nhất"
        :products="products"
      />
      <card-list-product-home
        category="Sản phẩm bán chạy"
        :products="productsSeller"
      />
      <!-- Mua gì bán đấy -->
      <BuyAndSell />
      <Community />
      <!-- Lãi cao bán tốt -->
      <HighProfitSale />
      <!-- Lựa chọn dễ bán -->
      <EasySell />
      <NavItemCategory />
    </div>
  </div>
</template>

<script setup>
import { getSanPhamHome } from "~~/composables/useApiProduct";
import EasySell from "./EasySell.vue";
import BuyAndSell from "./BuyAndSell.vue";
import NavItemCategory from "./NavItemCategory.vue";
import Community from "./Community.vue";
import HighProfitSale from "./HighProfitSale.vue";
import CardListProductHome from "~~/components/Cards/CardListProductHome.vue";
import Sliderncc from "./Sliderncc.vue";
import Advisement from "./Advisement.vue";
import toast from "vue3-toastify";
import { ref } from "vue";

const products = ref([]);
const productsSeller = ref([]);
const hotProducts = ref({CreatedDate:'CreatedDate' , desc:'desc'})
const newProducts = ref({LuotBan :'LuotBan' , desc:'desc'})

// Lấy sản phẩm bán chạy và sản phẩm mới nhất
onMounted(() => {
  console.log(123);
  getSanPhamHome(hotProducts.value.CreatedDate , hotProducts.value.desc)
  .then((res) => {
    console.log(res.data.items);
    products.value = res.data.items;
    return getSanPhamHome(newProducts.value.LuotBan , newProducts.value.desc)
  })
  .then((res) => {
    console.log(res.data.items);
    productsSeller.value =  res.data.items;
  })
})

definePageMeta({
  layout: "layout-default",
});
</script>
