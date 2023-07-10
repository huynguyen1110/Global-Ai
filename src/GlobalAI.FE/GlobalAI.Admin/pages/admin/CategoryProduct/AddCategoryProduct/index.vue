<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto shadow-2xl p-12 h-[670px]">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="idDanhMuc"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Id danh mục
          </label>
          <Field
            v-model="idDanhMuc"
            name="idDanhMuc"
            type="text"
            placeholder="Id danh mục..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="idDanhMuc" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label
            for="tenDanhMuc"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Tên danh mục
          </label>
          <Field
            v-model="tenDanhMuc"
            name="tenDanhMuc"
            type="text"
            placeholder="Tên danh mục..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="tenDanhMuc" class="text-red-500" />
        </div>
      </div>
      <div class="flex justify-end gap-5">
        <button @click="handleCategoryProduct" class="btn btn-outline">
          Thêm danh mục sản phẩm
        </button>
        <button
          @click="router.push('/admin/categoryproduct')"
          class="btn btn-outline btn-error"
        >
          <span class="flex">Quay về</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from "vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { postCategoryProduct } from "~~/composables/useApiCategoryProduct";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();
definePageMeta({
  layout: "admin",
});

const router = useRouter();

const idDanhMuc = ref("");
const tenDanhMuc = ref("");

function handleCategoryProduct() {
  const categoryProductData = {
    idDanhMuc: idDanhMuc.value,
    tenDanhMuc: tenDanhMuc.value,
  };
  const body = {
    ...categoryProductData,
  };

  postCategoryProduct(body)
    .then((response) => {
      console.log(response);
      router.push("/admin/categoryproduct");
      $toast.success("Thêm danh mục sản phẩm thành công");
    })
    .catch((error) => {
      console.error(error);
      $toast.error("Thêm danh mục sản phẩm thất bại. Vui lòng thử lại!");
    });
}
</script>
