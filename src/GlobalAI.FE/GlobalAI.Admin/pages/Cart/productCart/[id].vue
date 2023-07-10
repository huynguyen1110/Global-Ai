<template>
  <div class="mt-[20px] h-[100vh]">
    <div class="flex items-center gap-[10px] cursor-pointer px-1">
      <div class="float-left flex items-center gap-2">
        <font-awesome-icon
          class="text-black text-[18px]"
          :icon="['fas', 'angle-left']"
        />
      </div>
      <a @click="handleBack" class="text-[18px] text-[#cc3366]">Trở lại</a>
    </div>
    <div class="flex w-full gap-[30px] lg:flex-row flex-col">
      <div class="lg:w-[65%] mt-[20px] rounded-md overflow-hidden">
        <div
          class="mt-[20px] py-[15px] px-[20px] w-full flex flex-col rounded-md overflow-y-auto bg-white"
        >
          <div class="flex w-full items-start gap-[10px] mb-[30px]">
            <div class="flex items-center gap-[20px]">
              <!-- <input v-model="selectedProducts" type="checkbox" /> -->
              <div
                class="flex flex-col mt-[20px] w-[102px] h-[102px] items-center justify-center"
              >
                <img
                  :src="getImageUrl(product.thumbnail)"
                  class="mt-1 rounded-md object-cover"
                  alt="Hình Ảnh"
                />
                <span class="mt-[10px] text-[16px] text-[#6c757d]"
                  >SL : {{ giohang.soLuong }}
                </span>
              </div>
            </div>
            <div class="ml-[18px] flex flex-col w-full gap-[3px]">
              <h2 class="text-[16px] font-bold uppercase text-[#384059]"></h2>
              <span class="text-[14px] text-[#6C757D]">Phân loại : Trắng</span>
              <span class="text-left text-[#cc3366] text-[16px] font-[400]"
                >Tổng giá :
                {{ formatMoneyAll(getPrice(giohang.soLuong, product.giaBan)) }}
              </span>
              <div class="flex justify-between items-center">
                <p
                  class="cursor-pointer text-[16px] mt-0 font-[600] text-[#3478f6]"
                >
                  Sửa
                </p>
                <button class="flex items-center text-[#3478f6]" @click="handleDelete(product.id)">
                  <svg
                    class="w-8 h-8 rounded-full p-1"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"
                    ></path>
                  </svg>
                  Xóa sản phẩm
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div
        class="flex-1 bg-white mt-[20px] rounded-md h-[550px] px-[20px] py-[15px]"
      >
        <div class="w-full">
          <div class="w-full flex justify-between mb-[15px]">
            <h2 class="text-[18px] font-bold">Địa chỉ</h2>
          </div>
          <div class="mb-[10px]">
            <input
              type="text"
              v-model="diaChi"
              class="border-b border-[#ccc]"
            />
          </div>
        </div>
        <div>
          <div>
            <div class="mb-2 flex justify-between">
              <p class="text-gray-700">Giá bán</p>
              <p class="text-gray-700"></p>
            </div>
            <div class="flex justify-between">
              <p class="text-gray-700">Giá chiết khấu</p>
              <p class="text-gray-700"></p>
            </div>
          </div>
          <h1 class="text-[18px] font-bold mt-[15px]">Hình thức thanh toán</h1>
          <div>
            <label class="flex items-center">
              <input
                type="radio"
                class="form-radio"
                name="payment-type"
                value="cash"
                v-model="selectedPaymentType"
              />
              <span class="ml-2">Tiền mặt</span>
            </label>
            <label class="flex items-center">
              <input
                type="radio"
                class="form-radio"
                name="payment-type"
                value="transfer"
                v-model="selectedPaymentType"
              />
              <span class="ml-2">Chuyển khoản</span>
            </label>
            <div class="flex items-center justify-end mt-3">
              <button
                class="bg-blue-500 hover:bg-blue-600 ml-3 focus:ring-offset-2 transition ease-in-out rounded text-white px-6 py-1 text-sm"
              >
                Ảnh bill chuyển khoản
              </button>
            </div>
            <div
              class="h-[50px] relative order-first md:order-last lg:h-1 md:h-auto flex justify-center items-center border border-dashed border-gray-400 col-span-2 mt-6 rounded-lg bg-no-repeat bg-center bg-origin-padding bg-cover"
            >
              <span class="text-gray-400 opacity-75">
                <svg
                  class="w-14 h-14"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="0.7"
                  stroke="currentColor"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M2.25 15.75l5.159-5.159a2.25 2.25 0 013.182 0l5.159 5.159m-1.5-1.5l1.409-1.409a2.25 2.25 0 013.182 0l2.909 2.909m-18 3.75h16.5a1.5 1.5 0 001.5-1.5V6a1.5 1.5 0 00-1.5-1.5H3.75A1.5 1.5 0 002.25 6v12a1.5 1.5 0 001.5 1.5zm10.5-11.25h.008v.008h-.008V8.25zm.375 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z"
                  />
                </svg>
              </span>
            </div>
          </div>
          <div class="flex items-center justify-center">
            <label class="label cursor-pointer mt-10">
              <input type="checkbox" checked="checked" class="checkbox" />
              <span class="label-text mr-3">&nbsp;Đồng ý điều khoản</span>
            </label>
          </div>
          <div class="flex mt-[20px] justify-between flex-col">
            <div class="flex flex-row items-center justify-between">
              <h1 class="mt-2 text-[18px] font-bold">Tổng Thanh Toán</h1>
              <p class="text-lg text-[18px] font-bold text-[#cc3366]">
                <!--  -->
              </p>
            </div>
            <div class="mt-5 float-right">
              <label for="my-modal" class="btn btn-outline w-full"
                >Tạo đơn</label
              >

              <!-- Put this part before </body> tag -->
              <input type="checkbox" id="my-modal" class="modal-toggle" />
              <div class="modal">
                <div class="modal-box">
                  <div class="modal-action">
                    <label
                      for="my-modal"
                      class="btn btn-sm btn-circle absolute right-2 top-2"
                      >✕</label
                    >
                  </div>
                  <h3 class="font-bold text-lg">Bạn vừa tạo đơn hàng</h3>
                  <p class="py-4">Bạn có muốn xác nhận đơn hàng chứ ?</p>
                  <div class="modal-action">
                    <label @click="checkOut" for="my-modal" class="btn"
                      >Đồng ý</label
                    >
                  </div>
                </div>
              </div>
            </div>
           
          </div>
     
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { getGioHangByIdSanPham } from "~/composables/useApiProduct";
import { useRouter } from "vue-router";
import vueNumberFormat from "~~/plugins/vue-number-format";
import { toast } from "vue3-toastify";
import { useUserStorage } from "~~/stores/user";
import jwtDecode from "jwt-decode";
definePageMeta({
  layout: "layout-default",
  name: "ProductCart",
});
const product = ref([]);
const giohang = ref([]);
const selectedProducts = ref([]);
const diaChi = ref("Trương Định, Hà Nội");
const userStorage = useUserStorage();
const token = userStorage.getAccessToken;

//body call api tạo đơn hàng full
const bodyData = ref({
  donHang: {
    maDonHang: "",
    ngayHoanThanh: "",
    idGStore: 0,
    idNguoiMua: 0,
    soTien: 0,
    hinhThucThanhToan: "",
  },
  chiTietDonHangFullDtos: [],
});
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const router = useRouter();
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};
//biến lưu giá trị hình thức thanh toán

onMounted(() => {
  const idSanPham = router.currentRoute.value.params.id;
  getGioHangByIdSanPham(idSanPham)
    .then((res) => {
      console.log(res.data.data);
      giohang.value = res?.data?.data;
      console.log(giohang.value);
      getSanPhamById(idSanPham).then((res) => {
        product.value = res?.data?.data;
        console.log(product.value);
      });
    })
    .catch(() => {});
});
const getUserId = () => {
  console.log(token);
  return jwtDecode(token);
}
const getPrice = (soLuong, giaBan) => {
  console.log(soLuong, giaBan);
  return giaBan * soLuong;
};
const formatMoneyAll = (money) => {
  console.log(money);
  money = Number(money);
  return money.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
};
// Handle Delete gio hang 
const handleDelete = () => {
  console.log(giohang.value.id);
  deleteGioHang(giohang.value.id)
    .then((res) => {
      console.log(res.data);
      toast.success("Xóa giỏ hàng thành công");
      router.back();
    })
    .catch(() => {});
};
const handleBack = () => {
  router.back()
}
const checkOut = () => {
  
  console.log(getUserId());
  console.log(product.value.id);
  router.push({name:"ManageCart",query: {checkedItem: product.value.id}, params: {id: getUserId().user_id}})
};
</script>
<style lang="css">
input[type="number"]::-webkit-inner-spin-button,
input[type="number"]::-webkit-outer-spin-button {
  -webkit-appearance: none;
  margin: 0;
}
input[type="number"] {
  -moz-appearance: textfield;
}
.ModalUpdateCart {
  animation: FadeIn ease-in-out 0.3s;
}
@keyframes FadeIn {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
</style>
