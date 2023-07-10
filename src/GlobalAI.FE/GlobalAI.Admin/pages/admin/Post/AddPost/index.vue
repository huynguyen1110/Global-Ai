<template>
  <div class="mt-4 relative bg-white rounded">
    <form @submit.prevent="handlePostPost" :validationSchema="postFormBody" class="m-auto shadow-2xl p-12">
      <div class="grid gap-6 mb-6 md:grid-cols-2">
        <div class="col-span-1">
          <label for="tieuDe" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Tiêu đề
          </label>
          <Field v-model="tieuDe" name="tieuDe" type="text" placeholder="Tiêu đề..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
            required />
          <error-message name="tieuDe" class="text-red-500" />
        </div>
        <!-- <div class="col-span-1">
          <label
            for="parrentId"
            class="block uppercase text-slate-600 text-xs font-bold mb-2"
            >Danh mục</label
          >
          <select
            v-model="idDanhMuc"
            id="idDanhMuc"
            class="block px-3 py-3 w-full p-2 mb-6 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
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
        </div> -->
        <div class="col-span-1">
          <label for="idDanhMuc" class="block uppercase text-slate-600 text-xs font-bold mb-2">Danh mục</label>
          <select v-model="idDanhMuc" id="idDanhMuc"
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
            required>
            <option value="">-- Lựa chọn danh mục --</option>
            <optgroup class="font-bold" label="Danh mục sản phẩm">
              <option v-for="danhmuc in danhmucsp" :value="danhmuc.id" :key="danhmuc.id">
                {{ danhmuc.tenDanhMuc }}
              </option>
            </optgroup>
            <optgroup class="font-bold" label="Danh mục khác">
              <option value="1">Option 1</option>
              <option value="2">Option 2</option>
              <option value="3">Option 3</option>
            </optgroup>
          </select>
        </div>

        <div class="col-span-1">
          <label for="image" class="block uppercase text-slate-600 text-xs font-bold mb-2">Hình ảnh</label>
          <div class="flex items-center justify-between relative">
            <Field type="file" id="image"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
              required @change="uploadImage" />
            <img alt="Product Image" class="w-[50px] h-[50px] border absolute right-0 rounded"
              :src="getImageUrl(thumbnail)" />
          </div>
        </div>
        <div class="col-span-1">
          <label for="moTa" class="block uppercase text-slate-600 text-xs font-bold mb-2">
            Mô tả
          </label>
          <Field v-model="moTa" name="moTa" type="text" placeholder="Mô tả ..."
            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
          <error-message name="tieuDe" class="text-red-500" />
        </div>
      </div>
      <div class="flex flex-col">
        <div class="col-span-1">
          <label for="noiDung" class="block uppercase text-slate-600 text-xs font-bold mb-2">Nội dung</label>
          <div class="w-full h-[300px]">
            <div class="min-h-screen">
              <TextEditor v-model="noiDung" />
            </div>
          </div>
        </div>
        <div class="flex justify-end gap-5">
          <button type="submit" class="btn btn-outline">Thêm bài tin</button>
          <button @click="router.push('/admin/post')" class="btn btn-outline btn-error">
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
import { postPost, getAllDanhMucBaiTin } from "~~/composables/useApiPost";
import { ref } from "vue";
import NumberInput from "~~/components/Input/NumberInput.vue";

import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { useRouter } from "vue-router";
import TextEditor from "~~/components/TextEditor/TextEditor.vue";

definePageMeta({
  layout: "admin",
});
const idDanhMuc = ref(0);
const tieuDe = ref("");
const noiDung = ref("");
const thumbnail = ref("");
const moTa = ref("");
const danhmucsp = ref([]);
const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

const uploadImage = (event) => {

  postImage(event.target.files[0], 'image')
    .then((response) => {
      thumbnail.value = response.data;
    })
    .catch((error) => {
      console.log(error);
    });

}

// Hàm này sẽ lấy đường dẫn của ảnh từ server và bind vào thuộc tính src của thẻ
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

function ConvertSlug(str) {
  //Đổi chữ hoa thành chữ thường
  // str = title.toLowerCase();

  //Đổi ký tự có dấu thành không dấu
  str = str.replace(/á|à|ả|ạ|ã|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ/gi, "a");
  str = str.replace(/é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ/gi, "e");
  str = str.replace(/i|í|ì|ỉ|ĩ|ị/gi, "i");
  str = str.replace(/ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ/gi, "o");
  str = str.replace(/ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự/gi, "u");
  str = str.replace(/ý|ỳ|ỷ|ỹ|ỵ/gi, "y");
  str = str.replace(/đ/gi, "d");
  //Xóa các ký tự đặt biệt
  str = str.replace(
    /\`|\~|\!|\@|\#|\||\$|\%|\^|\&|\*|\(|\)|\+|\=|\,|\.|\/|\?|\>|\<|\'|\"|\:|\;|_/gi,
    ""
  );
  //Đổi khoảng trắng thành ký tự gạch ngang
  str = str.replace(/ /gi, "-");
  //Đổi nhiều ký tự gạch ngang liên tiếp thành 1 ký tự gạch ngang
  //Phòng trường hợp người nhập vào quá nhiều ký tự trắng
  str = str.replace(/\-\-\-\-\-/gi, "-");
  str = str.replace(/\-\-\-\-/gi, "-");
  str = str.replace(/\-\-\-/gi, "-");
  str = str.replace(/\-\-/gi, "-");
  //Xóa các ký tự gạch ngang ở đầu và cuối
  str = "@" + str + "@";
  str = str.replace(/\@\-|\-\@|\@/gi, "");
  return str;
}

function handlePostPost() {
  const postData = {
    idDanhMuc: idDanhMuc.value,
    tieuDe: tieuDe.value,
    noiDung: noiDung.value,
    thumbnail: thumbnail.value,
    moTa: moTa.value,
    slug: ConvertSlug(tieuDe.value),
  };

  console.log(postData);

  postPost(postData)
    .then((response) => {
      console.log("res", response);
      toast.success("Thêm bài tin thành công");
      router.push("/admin/post");
    })
    .catch((error) => {
      console.error(error);
      toast.error("Thêm bài tin thất bại. Vui lòng thử lại!");
    });
}

//Lấy danh mục của bài tin
const pageSize = 15;
const pageNumber = ref(1);
const skip = ref(0);

onMounted(() => {
  getAllPostCategoryPhanTran(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      danhmucsp.value = response.data.items;
    })
    .catch((error) => {
      console.log(error);
    });

  getAllPostCategoryTree()
    .then((response) => {
      danhmucsp.value = flattenData(response.data);
      console.log('danhmuc', danhmucsp.value)
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

<style>
/* since nested groupes are not supported we have to use 
         regular css for the nested dropdowns
      */
li>ul {
  transform: translatex(100%) scale(0);
}

li:hover>ul {
  transform: translatex(101%) scale(1);
}

li>button svg {
  transform: rotate(-90deg);
}

li:hover>button svg {
  transform: rotate(-270deg);
}
</style>
