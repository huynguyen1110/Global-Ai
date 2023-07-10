<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto overflow-y-auto shadow-2xl p-12 max-h-screen">
      <div class="flex flex-col gap-5">
        <div class="font-medium">
          <label class="label font-medium">
            <span class="label-text text-base uppercase"
              >Mã danh mục sản phẩm</span
            >
          </label>
          <input
            v-model="categoryAttData.ma"
            type="text"
            placeholder="Mã danh mục sản phẩm..."
            class="input text-sm shadow-sm input-bordered w-full max-w-xs hover:opacity-75"
          />
        </div>
        <div class="font-medium">
          <label class="label font-medium">
            <span class="label-text text-base uppercase"
              >Tên danh mục sản phẩm</span
            >
          </label>
          <input
            v-model="categoryAttData.ten"
            type="text"
            placeholder="Tên danh mục sản phẩm..."
            class="input text-sm shadow-sm input-bordered w-full max-w-xs hover:opacity-75"
          />
        </div>
        <div
          v-for="(listThuocTinh, index) in categoryAttData.listThuocTinh"
          :key="index"
        >
          <div class="border shadow-md border-base-300 bg-base-100 rounded-box">
            <div class="flex justify-between items-center">
              <div class="text-xl flex flex-col gap-3 font-medium m-5">
                <div>
                  <label class="label">
                    <span class="label-text uppercase">Thuộc tính</span>
                  </label>
                  <input
                    v-model="listThuocTinh.tenThuocTinh"
                    type="text"
                    placeholder="Tên thuộc tính..."
                    class="input shadow-sm input-bordered input-md w-full max-w-xs hover:opacity-75"
                  />
                </div>
                <div
                  v-for="(listGiaTri, index) in listThuocTinh.listGiaTri"
                  :key="index"
                  class="ml-5"
                >
                  <div>
                    <label class="label">
                      <span class="label-text uppercase">Giá trị</span>
                    </label>
                  </div>
                  <div class="flex gap-3 items-center justify-between">
                    <input
                      v-model="listGiaTri.giaTri"
                      type="text"
                      placeholder="Giá trị"
                      class="input shadow-sm input-bordered input-sm w-full max-w-xs hover:opacity-75"
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="flex justify-end gap-5 mt-5">
        <button @click="handleUpdate" class="btn btn-outline">
          Cập nhật danh mục thuộc tính sản phẩm
        </button>
        <button
          @click="router.push('/admin/categoryattribute')"
          class="btn btn-outline btn-error"
        >
          <span class="flex">Quay về</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
definePageMeta({
  layout: "admin",
  name: "categoryattribute",
});
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();
import {
  getDanhMucThuocTinhSanPhamById,
  updateDanhMucThuocTinhSanPham,
} from "~~/composables/useApiCategoryAttribute";

const router = useRouter();
const categoryAttId = ref(0);
const categoryAttData = ref([]);

onMounted(() => {
  categoryAttId.value = router.currentRoute.value.params.id;
  watchEffect(async () => {
    try {
      const data = await getDanhMucThuocTinhSanPhamById(categoryAttId.value);
      categoryAttData.value = data.data;
    } catch (error) {
      console.log(error);
    }
  });
});

function handleUpdate() {
  const data = {
    id: categoryAttData.value.id,
    ma: categoryAttData.value.ma,
    ten: categoryAttData.value.ten,
    listThuocTinh: categoryAttData.value.listThuocTinh.map((tt) => ({
      ...tt,
      listGiaTri: tt.listGiaTri.map((gt) => ({ ...gt })),
    })),
  };
  console.log(data);

  updateDanhMucThuocTinhSanPham(data)
    .then((response) => {
      console.log(response);
      $toast.success("Cập nhật danh mục thuộc tính sản phẩm thành công");
      router.push("/admin/categoryattribute");
    })
    .catch((error) => {
      console.log(error);
      $toast.error(
        "Cập nhật danh mục thuộc tính sản phẩm thất bại. Vui lòng thử lại!"
      );
    });
}
</script>
