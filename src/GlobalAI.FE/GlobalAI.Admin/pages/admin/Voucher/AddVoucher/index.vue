<template>
  <div class="mt-4 relative bg-white rounded">
    <form @submit.prevent="handlePostVoucher" class="m-auto shadow-2xl p-12">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label for="name" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Tên Voucher
          </label>
          <Field v-model="name" name="name" type="text" placeholder="Tên Voucher..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="name" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label for="giaTri" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Giá trị
          </label>
          <Field v-model="giaTri" name="giaTri" type="number" placeholder="Giá trị..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="giaTri" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label for="soLuong" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Số lượng
          </label>
          <Field v-model="soLuong" name="soLuong" type="number" placeholder="Số lượng..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="soLuong" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label for="ngayHetHan" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Ngày hết hạn
          </label>
          <Field v-model="ngayHetHan" name="ngayHetHan" type="date" placeholder="Tiêu đề..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="ngayHetHan" class="text-red-500" />
        </div>
        <div class="">
          <label for="avatar" class="block uppercase text-slate-600 text-xs font-bold mb-2">Hình ảnh</label>
          <div class="flex items-center justify-between relative">
            <input type="file" id="avatar"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
              required @change="uploadImage" />
            <img alt="Product Image" class="w-[50px] h-[50px] border absolute right-0 rounded"
              :src="getImageUrl(avatar)" />
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
          <button @click="router.push('/admin/voucher')" type="submit" class="btn btn-outline">
            Thêm voucher
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
import { ref } from "vue";
import NumberInput from "~~/components/Input/NumberInput.vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import TextEditor from "~~/components/TextEditor/TextEditor.vue";
import { postVoucher } from "~~/composables/useApiVoucher";
const { $toast } = useNuxtApp();
definePageMeta({
  layout: "admin",
});

const name = ref("");
const avatar = ref("");
const moTa = ref("");
const giaTri = ref(0);
const soLuong = ref(0);
const ngayHetHan = ref("");
const voucherChiTiets = ref([]);

const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

const uploadImage = (event) => {
  postFile(event.target.files[0], 'image')
    .then((response) => {
      avatar.value = response.data;
    })
    .catch((error) => {
      console.log(error);
    });
}

const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

function handlePostVoucher() {
  const voucherData = {
    name: name.value,
    avatar: avatar.value,
    moTa: moTa.value,
    giaTri: giaTri.value,
    soLuong: soLuong.value,
    ngayHetHan: ngayHetHan.value,
    voucherChiTiets: voucherChiTiets.value,
  };
  const body = {
    ...voucherData,
  };

  console.log(body);

  postVoucher(body)
    .then((response) => {
      console.log(response);
      $toast.success("Thêm Voucher thành công");
    })
    .catch((error) => {
      console.error(error);
      $toast.error("Thêm Voucher thất bại. Vui lòng thử lại!");
    });
}
</script>
