<template>
  <div class="overflow-x-auto relative w-full">
    <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
      <div class="flex flex-wrap items-center">
        <div
          class="relative w-full px-4 max-w-full flex justify-between items-center"
        >
          <h3 class="font-semibold text-lg text-slate-800 uppercase">
            Danh sách danh mục bài tin
          </h3>
          <button
            @click="router.push('/admin/postcategory/addpostcategory')"
            class="btn btn-outline"
          >
            Thêm danh mục bài tin
          </button>
        </div>
      </div>
    </div>
    <table class="table w-full mt-2">
      <!-- head -->
      <thead>
        <tr>
          <th>
            <label>
              <input type="checkbox" class="checkbox" />
            </label>
          </th>
          <th>Mã danh mục</th>
          <th>Tên danh mục</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="post in postCategorys" :key="post.id" class="text-sm">
          <th>
            <label>
              <input type="checkbox" class="checkbox" />
            </label>
          </th>
          <td>{{ post.maDanhMuc }}</td>
          <td>{{ post.tenDanhMuc }}</td>
          <td>
            <div class="dropdown dropdown-left dropdown-end">
              <label
                tabindex="0"
                class="btn m-1 btn-outline"
                @click="toggleDropdown"
                >...</label
              >
              <ul
                tabindex="0"
                class="dropdown-content menu p-2 shadow bg-base-100 rounded-box w-52"
                v-if="isOpen"
                @click="closeDropdown"
              >
                <li @click="onEditButtonClick(post.id)"><a>Sửa</a></li>
                <li @click="onDeleteButtonClick(post.id)"><a>Xoá</a></li>
                <li><a>Duyệt</a></li>
              </ul>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
    <div class="btn-group flex justify-center mt-2">
      <button @click="previousPage" class="btn">«</button>
      <button class="btn">Trang {{ pageNumber }}</button>
      <button @click="nextPage" class="btn">»</button>
    </div>
  </div>
</template>

<script setup>
import { ref, watchEffect } from "vue";
import {
  getAllPostCategoryPhanTran,
  getPostCategoryById,
  deletePostCategory,
} from "~~/composables/useApiPostCategory.js";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();

const router = useRouter();
const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

const postCategorys = ref([]);
const deletedPostCategory = ref(null);
const showAction = ref({});

const fetchData = async () => {
  getAllPostCategoryPhanTran(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      postCategorys.value = response.data.items;
      console.log(postCategorys.value);
    })
    .catch((err) => {
      console.error(err);
    });
};

const previousPage = () => {
  if (pageNumber.value === 1) {
    return;
  }
  pageNumber.value -= 1;
};

const nextPage = () => {
  console.log(1);
  if (postCategorys.value.length < pageSize) {
    return;
  }
  pageNumber.value += 1;
};

const onDeleteButtonClick = (id) => {
  console.log(id);
  deletePostCategory(id)
    .then((res) => {
      deletedPostCategory.value = res;
      $toast.success("Xoá bài tin thành công.");
    })
    .catch((err) => {
      console.error(err);
      $toast.error("Xoá bài tin thất bại. Vui lòng thử lại!");
    });
};

const onEditButtonClick = (id) => {
  router.push({ name: "PostCategory", params: { id: id } });
  getPostCategoryById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

watchEffect(() => {
  fetchData();

  if (deletedPostCategory.value !== null) {
    getAllPostCategoryPhanTran();
    deletedPostCategory.value = null;
  }
});

const isOpen = ref(false);

const toggleDropdown = () => {
  isOpen.value = !isOpen.value;
};

const closeDropdown = () => {
  isOpen.value = false;
};
</script>

<style></style>
