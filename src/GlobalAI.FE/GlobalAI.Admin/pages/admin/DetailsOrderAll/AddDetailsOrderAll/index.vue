<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto shadow-2xl p-12 h-[670px]">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="idSanPham"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã sản phẩm
          </label>
          <Field
            v-model="idSanPham"
            name="idSanPham"
            type="text"
            placeholder="Giá trị..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="idSanPham" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label
            for="soLuong"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Số lượng
          </label>
          <Field
            v-model="soLuong"
            name="soLuong"
            type="text"
            placeholder="Giá trị..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="soLuong" class="text-red-500" />
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button @click="handleDetailsOrderAll" class="btn btn-outline">
          Thêm chi tiết đơn hàng
        </button>
        <button
          @click="router.push('/admin/detailsorderall')"
          class="btn btn-outline btn-error"
        >
          <span class="flex">Quay về</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import axios from "axios";
import { ref } from "vue";
import NumberInput from "~~/components/Input/NumberInput.vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { postDetailsOrderAll } from "~~/composables/useApiDetailsOrderAll";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();
definePageMeta({
  layout: "admin",
});

const router = useRouter();

const idSanPham = ref(0);
const soLuong = ref(0);

function handleDetailsOrderAll() {
  const detailsOrderAllData = {
    idSanPham: idSanPham.value,
    soLuong: soLuong.value,
  };
  const body = {
    ...detailsOrderAllData,
  };

  postDetailsOrderAll(body)
    .then((response) => {
      console.log(response);
      router.push("/admin/detailsorderall");
      $toast.success("Thêm chi tiết đơn hàng thành công");
    })
    .catch((error) => {
      console.error(error);
      $toast.error("Thêm chi tiết đơn hàng thất bại. Vui lòng thử lại!");
    });
}
</script>
