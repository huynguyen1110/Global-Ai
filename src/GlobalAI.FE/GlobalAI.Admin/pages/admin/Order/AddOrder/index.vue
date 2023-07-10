<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto shadow-2xl p-12 h-[670px]">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="maDonHang"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã đơn hàng
          </label>
          <Field
            v-model="maDonHang"
            name="maDonHang"
            type="text"
            placeholder="Mã đơn hàng..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="maDonHang" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label
            for="ngayHoanThanh"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Ngày hoàn thành
          </label>
          <Field
            v-model="ngayHoanThanh"
            name="ngayHoanThanh"
            type="date"
            placeholder="Ngày hoàn thành..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="ngayHoanThanh" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label
            for="idGStore"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã G-Store
          </label>
          <Field
            v-model="idGStore"
            name="idGStore"
            type="number"
            placeholder="Mã G-Ctore..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="idGStore" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label
            for="idNguoiMua"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã người mua
          </label>
          <Field
            v-model="idNguoiMua"
            name="idNguoiMua"
            type="number"
            placeholder="Mã người mua..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="idNguoiMua" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label
            for="soTien"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Số tiền
          </label>
          <Field
            v-model="soTien"
            name="soTien"
            type="number"
            placeholder="Số tiền..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="soTien" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label
            for="diaChi"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Địa chỉ
          </label>
          <Field
            v-model="diaChi"
            name="diaChi"
            type="text"
            placeholder="Địa chỉ..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="diaChi" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label
            for="hinhThucThanhToan"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Hình thức thanh toán
          </label>
          <Field
            v-model="hinhThucThanhToan"
            name="hinhThucThanhToan"
            type="text"
            placeholder="Hình thức thanh toán..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="hinhThucThanhToan" class="text-red-500" />
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button @click="handleOrder" class="btn btn-outline">
          Thêm đơn hàng
        </button>
        <button
          @click="router.push('/admin/order')"
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
import { postPostCategory } from "~~/composables/useApiPostCategory";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();
definePageMeta({
  layout: "admin",
});

const router = useRouter();

const maDonHang = ref("");
const ngayHoanThanh = ref("");
const idGStore = ref(0);
const idNguoiMua = ref(0);
const soTien = ref(0);
const hinhThucThanhToan = ref("");
const diaChi = ref("");

function handleOrder() {
  // const ordersData = {
  //   maDonHang: maDonHang.value,
  //   ngayHoanThanh: ngayHoanThanh.value,
  //   idGStore: idGStore.value,
  //   idNguoiMua: idNguoiMua.value,
  //   soTien: soTien.value,
  //   hinhThucThanhToan: hinhThucThanhToan.value,
  //   diaChi: diaChi.value,
  // };
  // const body = {
  //   ...ordersData,
  // };

  // console.log(body);

  postOrders(
    maDonHang.value,
    ngayHoanThanh.value,
    idGStore.value,
    idNguoiMua.value,
    soTien.value,
    hinhThucThanhToan.value,
    diaChi.value
  )
    .then((response) => {
      console.log("Cuongthem", response);
      router.push("/admin/order");
      $toast.success("Thêm đơn hàng thành công");
    })
    .catch((error) => {
      console.error(error);
      $toast.error("Thêm đơn hàng thất bại. Vui lòng thử lại!");
    });
}
</script>
