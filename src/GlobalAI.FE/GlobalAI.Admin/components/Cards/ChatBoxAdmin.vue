<template lang="">
  <div class="w-[550px] bg-white">
    <div class="flex justify-between pb-2 items-start">
      <!-- Thông tin User and Sản phẩm -->
      <div class="flex gap-[15px]">
        <div class="w-[40px] h-[40px] rounded-[50%] overflow-hidden">
          <img
            src="https://scontent.fhan5-10.fna.fbcdn.net/v/t39.30808-6/330156445_726528278941325_8030089236208389329_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=V4DOfDkHjaQAX8dA8Bz&_nc_ht=scontent.fhan5-10.fna&oh=00_AfA382npOeV7nW78Mw9qfYt3m-KKIyhx3JbhivH7ozXgYw&oe=644A7BE5"
            alt=""
            class="object-cover"
          />
        </div>
        <h2 class="text-[18px] leading-4">Nguyễn Tiến Dũng</h2>
      </div>
      <div class="flex text-[22px] gap-3 text-blue-500" @click="closeBox">
        <font-awesome-icon
          :icon="['fas', 'circle-xmark']"
          class="cursor-pointer"
        />
      </div>
    </div>
    <div class="border-[1px] border-[#ccc] py-4 px-4 rounded-md">
      <div
        class="flex items-start gap-[15px] py-2 border-b-[1px] border-[#ccc]"
      >
        <div class="w-[50px] h-[50px] rounded-md overflow-hidden">
          <img
            :src="getImageUrl(products.thumbnail)"
            alt=""
            class="object-cover"
          />
        </div>
        <div class="desc flex flex-col gap-1">
          <h2 class="text-[14px] font-bold uppercase">
            {{ product.tenSanPham }}
          </h2>
          <div class="flex items-center">
            <span class="text-[#cc3366] text-[14px] mr-1">Giá Bán :</span>
            <span class="text-[12px] text-[#cc3366] font-bold"
              >{{ formatMoneyAll(product.giaBan) }}
            </span>
          </div>
        </div>
      </div>
    </div>
    <!-- Container chat -->
    <div ref="containerbox" class="w-full overflow-y-auto max-h-[200px]">
      <div
        v-for="price in boxprice"
        ::key="price"
        :class="
          price.loaiTraGia == 1
            ? 'gsaler float-right rounded-md  w-[70%] mt-[20px] px-2 py-2 border-[1px] bg-[#f4f4f4] flex items-center gap-[10px]'
            : 'gstore float-left rounded-md  w-[70%] mt-[20px] px-2 py-2 border-[1px] bg-[#fff4d6] flex items-center gap-[10px]'
        "
      >
        <div class="flex gap-[10px]">
          <div class="w-[50px] h-[50px] rounded-[md] overflow-hidden">
            <img
              :src="getImageUrl(products.thumbnail)"
              alt=""
              class="object-cover"
            />
          </div>
          <div>
            <span v-if="price.loaiTraGia === 1"
              >Trả giá :{{ formatMoneyAll(price.giaTien) }}</span
            >
            <span v-else-if="price.loaiTraGia === 2"
              >Yêu cầu :{{ formatMoneyAll(price.giaTien) }}</span
            >
          </div>
        </div>
        <button
          v-if="price.loaiTraGia === 1"
          class="px-1 py-1 border-[1px] bg-blue-100 rounded-md"
        >
          Chỉnh Sửa
        </button>
        <button
          v-else-if="price.loaiTraGia === 2"
          class="px-1 py-1 border-[1px] bg-blue-100 rounded-md"
        >
          Đồng ý
        </button>
      </div>
    </div>
    <form
      @submit.prevent="handlePriceChat"
      class="mt-4 border-[1px] border-[#ccc] flex items-center rounded-md pr-2"
    >
      <input
        type="number"
        v-model="priceChat"
        placeholder="Giá Thương Lượng "
        class="outline-none bg-transparent rounded-md px-2 w-[95%] py-1"
      />
    </form>
  </div>
</template>
<script setup>
import { defineEmits } from "vue";
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
const product = ref({});
const boxprice = ref([]);
const priceChat = ref();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
onMounted(() => {
  getSanPhamById(props.products.idSanPham)
    .then((res) => {
      product.value = res?.data?.data;
      getDetailedPayment(props.products.id)
        .then((res) => {
          console.log(res?.data?.data.chiTietTraGias);
          boxprice.value = res?.data?.data.chiTietTraGias;
          // Sắp xếp theo thời gian đăng
          boxprice.value.sort((a, b) => {
            return new Date(a.createdDate) - new Date(b.createdDate);
          });
        })
        .catch((err) => {
          console.log(err);
        });
    })
    .catch((err) => {
      console.log(err);
    });
});

const emits = defineEmits("close-box");
const closeBox = () => {
  emits("close-box");
};

const formatMoneyAll = (money) => {
  money = Number(money);
  return money.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
};
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

const handlePriceChat = async () => {
  const formData = {
    idTraGia: props.products.id,
    loaiTraGia: 2,
    giaTien: priceChat.value,
  };
  console.log(formData);
  postTragiaDetail(formData)
    .then((res) => {
      console.log(res.data.data);
      toast.success("Trả giá thành công!");
      priceChat.value =''
      getDetailedPayment(res.data.data.idTraGia)
        .then((res) => {
          console.log(res?.data?.data.chiTietTraGias);
          boxprice.value = boxprice.value.concat(
            res?.data?.data.chiTietTraGias
          );
          boxprice.value.sort((a, b) => {
            return new Date(a.createdDate) - new Date(b.createdDate);
          });
        })
        .catch((err) => console.log(err));
    })
    .catch((err) => console.log(err));
};

const props = defineProps({
  products: {
    type: Object,
  },
});
</script>
<style lang="css" scoped>
.box-pricebid {
  animation: fadeIn ease-in-out 0.5s;
}

@keyframes fadeIn {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
</style>
