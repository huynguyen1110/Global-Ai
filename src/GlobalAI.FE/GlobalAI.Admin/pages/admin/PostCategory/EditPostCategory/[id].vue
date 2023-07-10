<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto shadow-2xl p-12">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label for="maDanhMuc" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Mã danh mục
          </label>
          <Field name="maDanhMuc" type="text" v-model="maDanhMuc" placeholder="Mã danh mục..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="maDanhMuc" class="text-red-500" />
        </div>

        <div class="col-span-1">
          <label for="tenDanhMuc" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Tên danh mục
          </label>
          <Field name="tenDanhMuc" type="text" v-model="tenDanhMuc" placeholder="Tên danh mục..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="tenDanhMuc" class="text-red-500" />
        </div>
        <div class="col-span-1">
          <label for="parrentId" class="block uppercase text-slate-600 text-xs font-bold mb-2">Danh mục cha</label>
          <select v-model="parentId" id="parentId"
            class="block w-full p-2 mb-6 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required>
            <option value="">-- Lựa chọn danh mục --</option>
            <option v-for="danhmuc in danhmucsp" :value="danhmuc.id" :key="danhmuc.id">
              <span v-if="danhmuc.parentId !== null">--</span>
              {{ danhmuc.tenDanhMuc }}
            </option>
          </select>
        </div>
        <div class="">
          <label for="thumbnail" class="block uppercase text-slate-600 text-xs font-bold mb-2">Hình ảnh</label>
          <div class="flex items-center justify-between relative">
            <input type="file" id="image"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
              @change.prevent="uploadImage" />
            <img alt="Product Image" :src="getImageUrl(thumbnailNew)"
              class="w-[50px] h-[50px] border absolute right-0 rounded" />
          </div>
        </div>
      </div>
      <div class="flex flex-col">
        <div class="flex justify-end gap-5">
          <button @click="submitForm" class="btn btn-outline float-right">
            Cập nhật danh mục bài tin
          </button>
          <button @click="this.$router.push('/admin/postcategory')" class="btn btn-outline btn-error">
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
// import { updateProduct, getProductById } from "~~/composables/useApiProduct.js";
import {
  getPostCategoryById,
  updatePostCategory,
} from "~~/composables/useApiPostCategory.js";
import { postImage } from "~~/composables/useApiImage";
import { Form, Field, ErrorMessage } from "vee-validate";
import { ref, watchEffect } from "vue";
definePageMeta({
  layout: "admin",
  name: "PostCategory",
});

const postCategoryId = ref(0);
const maDanhMuc = ref("");
const tenDanhMuc = ref("");
const parentId = ref("");
const thumbnailNew = ref("");

const danhmucsp = ref("");



const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

function flattenData(data) {
  let flattenedData = [];
  let level = 0;
  data.forEach((item) => {
    flattenedData.push(item);
    if (item.children && item.children.length > 0) {
      const children = flattenData(item.children);
      flattenedData = flattenedData.concat(children);
    }
  });

  return flattenedData;
}

const uploadImage = (event) => {

  postImage(event.target.files[0], 'image')
    .then((response) => {
      thumbnailNew.value = response.data;
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
  postCategoryId.value = router.currentRoute.value.params.id;

  getAllPostCategoryTree()
    .then((response) => {
      danhmucsp.value = flattenData(response.data);
      console.log('danhmuc', danhmucsp.value)
    })
    .catch((error) => {
      console.log(error);
    });


  watchEffect(async () => {
    try {
      const data = await getPostCategoryById(postCategoryId.value);
      maDanhMuc.value = data.data.maDanhMuc;
      tenDanhMuc.value = data.data.tenDanhMuc;
      parentId.value = data.data.parentId;
      thumbnailNew.value = data.data.thumbnail;

      console.log(maDanhMuc.value);
    } catch (error) {
      console.log(error);
    }
  });
});
const submitForm = () => {
  const formData = {
    id: Number(postCategoryId.value),
    maDanhMuc: maDanhMuc.value,
    tenDanhMuc: tenDanhMuc.value,
    parentId: parentId.value,
    thumbnail: thumbnailNew.value,

  };
  const body = {
    ...formData,
  };

  console.log(body);
  updatePostCategory(body)
    .then((data) => {
      console.log(data);
      toast.success("Cập nhật danh mục bài tin thành công");
      router.push("/admin/postcategory");
    })
    .catch((error) => {
      console.log(error);
      toast.error("Cập nhật danh mục bài tin thất bại. Vui lòng thử lại!");
    });
};
</script>
