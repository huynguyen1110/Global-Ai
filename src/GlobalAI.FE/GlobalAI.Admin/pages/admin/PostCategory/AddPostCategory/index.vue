<template>
  <div class="mt-4 relative bg-white rounded">
    <div class="m-auto shadow-2xl p-12 h-[670px]">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label
            for="maDanhMuc"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
          >
            Mã danh mục
          </label>
          <Field
            v-model="maDanhMuc"
            name="maDanhMuc"
            type="text"
            placeholder="Mã danh mục..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="maDanhMuc" class="text-red-500" />
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
            placeholder="Giá trị..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
          />
          <error-message name="tenDanhMuc" class="text-red-500" />
        </div>
        <div class="col-span-1"> 
          <label
            for="parrentId"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
            >Danh mục cha</label
          >
          <select
            v-model="parentId"
            id="parentId"
            class="block w-full p-2 mb-6 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            required 
          >
            <option value="">-- Lựa chọn danh mục --</option>
            <option
              v-for="danhmuc in danhmucsp"
              :value="danhmuc.id"
              :key="danhmuc.id"
             >
             <span v-if = "danhmuc.parentId !== null" >--</span>
              {{ danhmuc.tenDanhMuc }}
            </option>
          </select>
        </div>
        <div class="">
          <label
            for="thumbnail"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
            >Hình ảnh</label
          >
          <div class="flex items-center justify-between relative">
            <input
              type="file"
              id="thumbnail"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
              @change.prevent="uploadImage"
            />
            <img
              alt="Product Image"
              class="w-[50px] h-[50px] border absolute right-0 rounded"
            />
          </div>
        </div>
      </div>
      
      <div class="flex justify-end gap-5">
        <button @click="handlePostCategory" class="btn btn-outline">
          Thêm danh mục bài tin
        </button>
        <button
          @click="router.push('/admin/postcategory')"
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

const maDanhMuc = ref("");
const tenDanhMuc = ref("");
const parentId = ref(0);
const thumbnailNew = ref("");

const danhmucsp = ref("");

async function uploadImage(event) {
  try {
 
    const file = event.target.files[0];
    console.log('file', file);
    postFile(file)
      .then((response) => {
        console.log(response);
        thumbnailNew.value = response.data;
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  } catch (error) {
    console.error(error);
  }
}

function handlePostCategory() {
  const postCategoryData = {
    maDanhMuc: maDanhMuc.value,
    tenDanhMuc: tenDanhMuc.value,
    parentId: parentId.value,
    thumbNail: thumbnailNew.value

  };
  const body = {
    ...postCategoryData,
  };

  postPostCategory(body)
    .then((response) => {
      console.log(response);
      router.push("/admin/postcategory");
      $toast.success("Thêm danh mục bài tin thành công");
    })
    .catch((error) => {
      console.error(error);
      $toast.error("Thêm danh mục bài tin thất bại. Vui lòng thử lại!");
    });
}
onMounted(() => {
  getAllPostCategoryTree()
    .then((response) => {
      danhmucsp.value = flattenData(response.data);
      console.log('danhmuc',danhmucsp.value)
    })
    .catch((error) => {
      console.log(error);
    });
});
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



</script>
