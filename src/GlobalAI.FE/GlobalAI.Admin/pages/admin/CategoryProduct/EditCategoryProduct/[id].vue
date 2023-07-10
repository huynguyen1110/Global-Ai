<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto shadow-2xl p-12">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="idDanhMuc"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Id danh mục
          </label>
          <Field
            name="idDanhMuc"
            type="text"
            v-model="idDanhMuc"
            placeholder="Mã danh mục..."
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
            name="tenDanhMuc"
            type="text"
            v-model="tenDanhMuc"
            placeholder="Tên danh mục..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="tenDanhMuc" class="text-red-500" />
        </div>
      </div>
      <div class="flex flex-col">
        <div class="flex justify-end gap-5">
          <button @click="submitForm" class="btn btn-outline float-right">
            Cập nhật danh mục sản phẩm
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
  </div>
</template>

<script setup>
import Vue3Toastify, { toast } from "vue3-toastify";
import "vue3-toastify/dist/index.css";
import { useRouter } from "vue-router";
import {
  getCategoryProductById,
  updateCategoryProduct,
} from "~~/composables/useApiCategoryProduct";
import { Form, Field, ErrorMessage } from "vee-validate";
import { ref, watchEffect } from "vue";
definePageMeta({
  layout: "admin",
  name: "CategoryProduct",
});

const categoryProductId = ref(0);
const idDanhMuc = ref("");
const tenDanhMuc = ref("");

const router = useRouter();

onMounted(() => {
  categoryProductId.value = router.currentRoute.value.params.id;
  watchEffect(async () => {
    try {
      const data = await getCategoryProductById(categoryProductId.value);
      idDanhMuc.value = data.data.idDanhMuc;
      tenDanhMuc.value = data.data.tenDanhMuc;

      console.log(idDanhMuc.value);
    } catch (error) {
      console.log(error);
    }
  });
});
const submitForm = () => {
  const formData = {
    id: Number(categoryProductId.value),
    idDanhMuc: idDanhMuc.value,
    tenDanhMuc: tenDanhMuc.value,
  };
  const body = {
    ...formData,
  };

  console.log(body);
  updateCategoryProduct(body)
    .then((data) => {
      console.log("Cuong", data);
      toast.success("Cập nhật danh mục sản phẩm thành công");
      router.push("/admin/categoryproduct");
    })
    .catch((error) => {
      console.log(error);
      toast.error("Cập nhật danh mục sản phẩm thất bại. Vui lòng thử lại!");
    });
};
</script>
