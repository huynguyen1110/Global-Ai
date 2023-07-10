<template>
  <!-- Navbar -->
  <nav
    class="z-10 bg-transparent md:flex-row md:flex-nowrap md:justify-start items-center py-4"
  >
    <div
      class="w-full mx-autp items-center flex justify-between md:flex-nowrap flex-wrap gap-5"
    >
      <ul class="flex flex-col lg:flex-row list-none lg:ml-auto">
        <li class="flex items-center">
          <form
            class="md:flex hidden flex-row flex-wrap items-center lg:ml-auto mr-3"
          >
            <div
              class="relative flex w-full flex-wrap border-coolGray-900 items-stretch"
            >
              <span
                class="z-10 h-full leading-snug font-normal absolute text-center text-slate-300 bg-transparent rounded text-base items-center justify-center w-8 pl-3 py-2"
              >
                <font-awesome-icon icon="fas fa-search" />
              </span>
              <input
                type="text"
                placeholder="Search here..."
                class="px-2 py-2 placeholder-slate-300 text-slate-600 relative border-solid border-[1px] border-blueGray-400 rounded text-sm shadow outline-none focus:outline-none focus:ring w-full pl-10"
              />
            </div>
          </form>
        </li>
        <li
          class="flex items-center relative"
          @mouseover="isHovering = true"
          @mouseleave="isHovering = false"
        >
          <a
            class="hover:text-slate-500 text-slate-700 px-3 py-2 flex items-center text-xs uppercase font-bold hover:cursor-pointer"
            @click="NextManageCart"
          >
            <i class="text-slate-400 fab fa-facebook text-lg leading-lg" />
            <img class="w-7" :src="CartSvg" />
            <div
              class="absolute flex items-center justify-center border-2 bg-[#16a249] text-white border-slate-300 top-[-8px] left-[30px] w-[25px] h-[25px] rounded-[50%]"
            >
              {{useCart.getFullSanPham.length }}
            </div>
          </a>
          <div
            v-show="isHovering"
            class="w-[400px] min-h-[200px] max-h-[550px] overflow-y-auto rounded-md  bg-white shadow-2xl py-[20px] absolute top-[42px] right-0"
          >
            <div v-if="useCart.getFullSanPham.length > 0">
              <h2 class="mb-5 ml-[15px] text-[#ccc]">Sản phẩm mới thêm</h2>
              <div
              v-for="quantityProduct in useCart.getFullSanPham"
              :key="quantityProduct"
            >
              <div
                class="flex justify-between py-[10px] px-[15px] cursor-pointer"
                :class="{ 'bg-[#eee]': hoverState[quantityProduct.id] }"
                @mouseover="hoverState[quantityProduct.id] = true"
                @mouseleave="hoverState[quantityProduct.id] = false"
                @click="handleDetail(quantityProduct.id)"
              >
                <div class="flex gap-[10px]">
                  <div class="w-[60px] h-[60px] bg-red-500 rounded-sm overflow-hidden">
                    <img
                      :src="getImageUrl(quantityProduct.thumbnail)"
                      class="object-cover"
                    />
                  </div>
                  <h2 class="text-[14px] leading-[1.3] w-[180px] h-[20.08px] text-ellipsis line-clamp-1 mr-2 ">{{ quantityProduct.tenSanPham }}</h2>
                </div>
                <span class="text-[14px] text-red-500">{{ formatMoneyAll(quantityProduct.giaBan)}}</span>
              </div>
              </div>
              <button
              @click="NextManageCart"
              class="float-right hover:bg-lightBlue-400 px-[20px] py-[8px] mt-[20px] mr-[15px] text-white border bg-[#16a249] rounded-md overflow-hidden border-slate-400"
            >
              Xem giỏ hàng
            </button>
            </div>
            <div v-else class="flex justify-center items-center flex-col">
               <div class="w-[90px] mt-4 h-[90px]">
                <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d5/Emoji_u1f45c.svg/1024px-Emoji_u1f45c.svg.png" alt="" class="object-cover">
               </div>
               <span class="mt-5">Chưa có sản phẩm</span>
            </div>
          </div>
        </li>
      </ul>
      <ul class="flex-col md:flex-row list-none items-center hidden md:flex">
        <user-dropdown />
      </ul>
    </div>
  </nav>
  <!-- End Navbar -->
</template>

<script>
import UserDropdown from "../../components/Dropdowns/UserDropdown.vue";

export default {
  components: {
    UserDropdown,
  },
};
</script>

<script setup>
import CartSvg from "../../assets/svg/shop-cart-svgrepo-com.svg";
import { useRouter } from "vue-router";
import jwt_decode from "jwt-decode";
import { useUserStorage } from "~~/stores/user";
import { useCartStorage } from "~~/stores/giohang";
const token = useUserStorage();
const useCart = useCartStorage();
const accesstoken = token.accessToken;
const quantityProducts = ref([]);
const router = useRouter();
const hoverState = ref({});
const isHovering = ref(false);
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

onMounted(() => {
  useCart.getGioHang()
})

const getUserInfor = () => {
  const userInfor = jwt_decode(accesstoken);
  return userInfor;
};
const formatMoneyAll = (money) => {
  money = Number(money);
  return money.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
};
const NextManageCart = () => {
  const userId = getUserInfor().user_id;
  console.log(userId);
  router.push({ name: "ManageCart", params: { id: userId } });
};
const handleDetail = (id) => {
  isHovering.value = false;
  router.push({ name: "ProductDetail", params: { id } });
};

const handleCartManage = () => {
  const userId = getUserInfor().user_id;
  console.log(userId);
  router.push({name: "ManageCart", params:{id: userId }})
}
</script>
