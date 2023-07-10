<template lang="">
  <div class="mt-[100px] w-full border-[1px] flex bg-white min-h-[100vh]">
    <SidebarChatAdmin />
    <div v-if="chatBid.length > 0" class="flex-1 pt-[15px]">
      <div
        class="flex px-[15px] pb-[15px] border-b-[1px] border-[#f4f4f4] justify-between"
      >
        <div class="flex gap-[10px]">
          <div class="w-[40px] h-[40px] rounded-[50%] overflow-hidden">
            <img
              :src="image"
              alt=""
              class="object-cover"
            />
          </div>
          <h2 class="text-[16px] text-[#000000] font-sm">Nguyễn Tiến Dũng</h2>
        </div>
        <button class="text-[25px]">
          <font-awesome-icon :icon="['fas', 'ellipsis-vertical']" />
        </button>
      </div>
      <div
        class="px-[15px] py-[15px] border-b-[1px] flex gap-[10px] items-start"
      >
        <div class="w-[60px] h-[60px] rounded-md overflow-hidden">
          <img
            :src="getImageUrl(productBid?.thumbnail)"
            alt=""
            class="object-cover"
          />
        </div>
        <div>
          <h2 class="text-[16px] font-bold text-[#000000]">
            {{ productBid?.tenSanPham }}
          </h2>
          <p class="text-red-500 text-[14px] mt-1">{{ productBid?.giaBan }}</p>
        </div>
      </div>
      <div class="h-[480px] px-[15px] overflow-y-auto">
        <div
          v-for="price in chatBid"
          ::key="price"
          :class="
            price.loaiTraGia == 1
              ? 'gsaler float-right rounded-md  w-[70%] mt-[20px] justify-between px-2 py-2 border-[1px] bg-[#f4f4f4] flex items-center gap-[10px]'
              : 'gstore float-left rounded-md  w-[70%] mt-[20px] justify-between px-2 py-2 border-[1px] bg-[#fff4d6] flex items-center gap-[10px]'
          "
        >
          <div class="flex gap-[10px]">
            <div class="w-[50px] h-[50px] rounded-[md] overflow-hidden">
              <img
                :src="getImageUrl(productBid?.thumbnail)"
                alt=""
                class="object-cover"
              />
            </div>
            <div>
              <h2
                class="text-[14px] font-bold leading-[1.3] w-[180px] h-[20.08px] text-ellipsis line-clamp-1 mr-2"
              >
                {{ productBid?.tenSanPham }}
              </h2>
              <span v-if="price.loaiTraGia === 1"
                >Trả giá :{{ formatMoneyAll(price.giaTien) }}</span
              >
              <span v-else-if="price.loaiTraGia === 2"
                >Yêu cầu :{{ formatMoneyAll(price.giaTien) }}</span
              >
            </div>
          </div>
          <button
            v-if="price.loaiTraGia === 2"
            class="px-1 py-1 border-[1px] bg-blue-100 rounded-md"
          >
            Chỉnh Sửa
          </button>
          <button
            v-else-if="price.loaiTraGia === 1"
            @click="handleAgreePrice"
            class="px-1 py-1 border-[1px] bg-blue-100 rounded-md"
          >
            Đồng ý
          </button>
        </div>
      </div>
      <form
        @submit.prevent="handleBidChat"
        class="flex gap-[15px] items-center mt-[20px] px-[15px] py-[15px]"
      >
        <div class="flex w-[10%] gap-[10px] items-center">
          <button class="text-blue-500 text-[20px]">
            <font-awesome-icon :icon="['fas', 'circle-plus']" />
          </button>
          <button class="text-blue-500 text-[20px]">
            <font-awesome-icon :icon="['fass', 'file-image']" />
          </button>
          <button class="text-blue-500 text-[20px]">
            <font-awesome-icon :icon="['fass', 'location-dot']" />
          </button>
        </div>
        <div class="flex-1 rounded-2xl overflow-hidden border-[1px]">
          <input
            v-model="chatValue"
            class="px-[10px] py-[5px] w-full outline-none bg-slate-100"
            type="number"
            placeholder="Nhập giá muốn thương lượng"
          />
        </div>
        <div class="w-10%">
          <button type="submit">
            <font-awesome-icon
              :class="chatValue.length > 0 ? 'text-blue-500' : ''"
              :icon="['fas', 'paper-plane']"
            />
          </button>
        </div>
      </form>
    </div>
    <div v-else class="flex-1 pt-[15px] flex items-center justify-center">
      <h1>Tích cực chat , săn quà khủng !!!</h1>
    </div>
  </div>
</template>
<script setup>
import { toast } from "vue3-toastify";
import SidebarChatAdmin from "~~/components/Sidebar/SidebarChatAdmin.vue";
import image from "@/assets/img/team-1-800x800.jpg";
const router = useRouter();
const chatBid = ref([]);
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const chatValue = ref("");
const productBid = ref({});

watchEffect(() => {
  getDetailedPayment(router.currentRoute.value.params.id)
    .then((res) => {
      chatBid.value = res.data.data.chiTietTraGias;
      chatBid.value.sort((a, b) => {
        return new Date(a.createdDate) - new Date(b.createdDate);
      });
      getSanPhamById(res.data.data.idSanPham)
        .then((res) => {
          productBid.value = res?.data?.data;
        })
        .catch((error) => console.log(error));
    })
    .catch((error) => console.log(error));
});
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};
const formatMoneyAll = (money) => {
  money = Number(money);
  return money.toLocaleString("vi-VN", {
    style: "currency",
    currency: "VND",
  });
};
// Xử lý gửi chat tiếp
const handleBidChat = () => {
  const formData = {
    idTraGia: router.currentRoute.value.params.id,
    loaiTraGia: 2,
    giaTien: chatValue.value,
  };
  postTragiaDetail(formData)
  .then((res) => {
    toast.success("Trả giá thành công");
    chatValue.value = "";
    getDetailedPayment(router.currentRoute.value.params.id).then((res) => {
      console.log(res.data.data.chiTietTraGias);
      chatBid.value = res.data.data.chiTietTraGias;
      chatBid.value.sort((a, b) => {
        return new Date(a.createdDate) - new Date(b.createdDate);
      });
    });
  })
  .catch((error) => console.log(error))
};
// Xử lý chấp nhận giá của người mua
const handleAgreePrice = ()=> {
  toast.success("Đã chấp nhận giá của user , giá sẽ được cập nhật sau ít phút ")
}
definePageMeta({
  layout: "admin",
  name: "BoxChatIDAdmin",
});
</script>
<style lang=""></style>
