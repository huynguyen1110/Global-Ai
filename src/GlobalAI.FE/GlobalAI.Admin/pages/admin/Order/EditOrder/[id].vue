<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto shadow-2xl p-12">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="maDonHang"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã đơn hàng
          </label>
          <Field
            name="maDonHang"
            type="text"
            v-model="maDonHang"
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
            name="ngayHoanThanh"
            type="date"
            v-model="ngayHoanThanh"
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
            name="idGStore"
            type="number"
            v-model="idGStore"
            placeholder="Mã G-Store..."
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
            name="idNguoiMua"
            type="number"
            v-model="idNguoiMua"
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
            name="soTien"
            type="number"
            v-model="soTien"
            placeholder="Số tiền..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="soTien" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label
            for="hinhThucThanhToan"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Hình thức thanh toán
          </label>
          <Field
            name="hinhThucThanhToan"
            type="text"
            v-model="hinhThucThanhToan"
            placeholder="Hình thức thanh toán..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="hinhThucThanhToan" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label
            for="diaChi"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Địa chỉ
          </label>
          <Field
            name="diaChi"
            type="text"
            v-model="diaChi"
            placeholder="Địa chỉ..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="diaChi" class="text-red-500" />
        </div>
      </div>
      <div class="flex flex-col">
        <div class="flex justify-end gap-5">
          <button @click="submitForm" class="btn btn-outline float-right">
            Cập nhật danh mục bài tin
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
  </div>
</template>

<script setup>
import axios from "axios";
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter } from "vue-router";
import { getOrderById, updateOrder } from "~~/composables/useApiOrder";
import { postImage } from "~~/composables/useApiImage";
import { Form, Field, ErrorMessage } from "vee-validate";
import { ref, watchEffect } from "vue";
definePageMeta({
  layout: "admin",
  name: "Order",
});

const postOrderId = ref(0);
const maDonHang = ref("");
const ngayHoanThanh = ref("");
const idGStore = ref(0);
const idNguoiMua = ref(0);
const soTien = ref(0);
const hinhThucThanhToan = ref("");
const diaChi = ref("");

const router = useRouter();

onMounted(() => {
  postOrderId.value = router.currentRoute.value.params.id;
  watchEffect(async () => {
    try {
      const data = await getOrderById(postOrderId.value);
      maDonHang.value = data.data.maDonHang;
      ngayHoanThanh.value = data.data.ngayHoanThanh;
      idGStore.value = data.data.idGStore;
      idNguoiMua.value = data.data.idNguoiMua;
      soTien.value = data.data.soTien;
      hinhThucThanhToan.value = data.data.hinhThucThanhToan;
      diaChi.value = data.data.diaChi;
    } catch (error) {
      console.log(error);
    }
  });
});

const submitForm = () => {
  const formData = {
    maDonHang: maDonHang.value,
    ngayHoanThanh: ngayHoanThanh.value,
    idGStore: idGStore.value,
    idNguoiMua: idNguoiMua.value,
    soTien: soTien.value,
    hinhThucThanhToan: hinhThucThanhToan.value,
    diaChi: diaChi.value,
  };
  updateOrder(postOrderId.value, formData)
    .then((data) => {
      console.log(data);
      toast.success("Cập đơn hàng phẩm thành công");
      router.push("/admin/order");
    })
    .catch((error) => {
      console.log(error);
      toast.error("Cập nhật đơn hàng thất bại. Vui lòng thử lại!");
    });
};
</script>
