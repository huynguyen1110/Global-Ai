<template>
  <div class="mt-4 relative bg-white rounded">
    <form @submit.prevent="submitForm" class="m-auto shadow-2xl p-12">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label for="name" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Tên Voucher
          </label>
          <Field name="name" type="text" v-model="name" placeholder="Mã sản phẩm..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="name" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label for="giaTri" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Giá trị
          </label>
          <Field name="giaTri" type="number" v-model="giaTri" placeholder="Tên sản phẩm..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="giaTri" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label for="soLuong" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Số lượng
          </label>
          <Field name="soLuong" v-model="soLuong" type="number"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="soLuong" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label for="ngayHetHan" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Ngày hết hạn
          </label>
          <Field name="ngayHetHan" type="date" v-model="ngayHetHan"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="ngayHetHan" class="text-red-500" />
        </div>
        <div class="">
          <label for="avatar" class="block uppercase text-slate-600 text-xs font-bold mb-2">Hình ảnh</label>
          <div class="flex items-center justify-between relative">
            <input type="file" id="avatar"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
              @change.prevent="uploadImage" />
            <img alt="Product Image" class="w-[50px] h-[50px] border absolute right-0 rounded"
              :src="getImageUrl(avatarNew)" />
          </div>
        </div>
      </div>
      <div class="flex flex-col">
        <div class="mb-6">
          <label for="moTa" class="block uppercase text-slate-600 text-xs font-bold mb-2">Mô tả</label>
          <div class="w-full h-[300px]">
            <div class="min-h-screen">
              <TextEditor v-model="moTa" />
            </div>
          </div>
        </div>
        <div class="flex justify-end gap-5">
          <button type="submit" class="btn btn-outline float-right">
            Cập nhật voucher
          </button>
          <button @click="router.push('/admin/voucher')" class="btn btn-outline btn-error">
            <span class="flex">Quay về</span>
          </button>
        </div>
      </div>
    </form>
  </div>
</template>

<script setup>
import axios from "axios";
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter } from "vue-router";
// import { updateProduct, getProductById } from "~~/composables/useApiProduct.js";
import { getVoucherById } from "~~/composables/useApiVoucher";
import { postImage } from "~~/composables/useApiImage";
import { Form, Field, ErrorMessage } from "vee-validate";
import { ref, watchEffect } from "vue";
definePageMeta({
  layout: "admin",
  name: "Voucher",
});

const voucherId = ref(0);
const name = ref("");
const avatarNew = ref("");
const moTa = ref("");
const giaTri = ref(0);
const soLuong = ref(0);
const ngayHetHan = ref("");
const voucherChiTiets = ref([]);

const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

const uploadImage = (event) => {
  postFile(event.target.files[0], formData)
    .then((response) => {
      avatarNew.value = response.data;
    })
    .catch((error) => {
      console.log(error);
    });
}

// Hàm này sẽ lấy đường dẫn của ảnh từ server và bind vào thuộc tính src của thẻ img
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

watchEffect(() => {
  getImageUrl();
});

onMounted(() => {
  voucherId.value = router.currentRoute.value.params.id;
  watchEffect(async () => {
    try {
      const data = await getVoucherById(voucherId.value);
      console.log(data);
      name.value = data.data.name;
      avatarNew.value = data.data.avatar;
      moTa.value = data.data.moTa;
      giaTri.value = data.data.giaTri;
      soLuong.value = data.data.soLuong;
      ngayHetHan.value = data.data.ngayHetHan;
      voucherChiTiets.value = [
        {
          id: 0,
          voucherId: 0,
          ngayGiao: "2023-04-26T15:50:18.998Z",
          ngaySuDung: "2023-04-26T15:50:18.998Z",
          nguoiSuDung: "string",
        },
      ];
    } catch (error) {
      console.log(error);
    }
  });
});
const submitForm = () => {
  const formData = {
    id: Number(voucherId.value),
    name: name.value,
    avatar: avatarNew.value,
    moTa: moTa.value,
    giaTri: giaTri.value,
    soLuong: soLuong.value,
    ngayHetHan: ngayHetHan.value,
    voucherChiTiets: voucherChiTiets.value,
  };
  const body = {
    ...formData,
  };

  console.log(body);
  updateVoucher(body)
    .then((data) => {
      console.log(data);
      toast.success("Cập nhật Voucher thành công");
      router.push("/admin/Voucher");
    })
    .catch((error) => {
      console.log(error);
      toast.error("Cập nhật Voucher thất bại. Vui lòng thử lại!");
    });
};
</script>
