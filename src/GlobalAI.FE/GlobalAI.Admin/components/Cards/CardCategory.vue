<template>
  <div class="overflow-x-auto relative w-full">
    <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
      <div class="flex flex-wrap items-center">
        <div
          class="relative w-full px-4 max-w-full flex justify-between items-center"
        >
          <h3 class="font-semibold text-lg text-slate-800 uppercase">
            Danh sách danh mục
          </h3>
          <button
            @click="router.push('/admin/category/addcategory')"
            class="btn btn-outline"
          >
            Thêm danh mục
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
          <th>ID</th>
          <th>Mã danh mục</th>
          <th>Tiêu đề</th>
          <th>Nội dung</th>
          <th>Chức năng</th>
        </tr>
      </thead>
      <tbody>
        <!-- row 1 -->
        <tr v-for="post in posts" :key="post.id" class="text-sm">
          <th>
            <label>
              <input type="checkbox" class="checkbox" />
            </label>
          </th>
          <td>{{ post.id }}</td>
          <td>{{ post.idDanhMuc }}</td>
          <td>
            <div class="flex items-center space-x-3">
              <div class="avatar">
                <div class="mask mask-squircle w-12 h-12">
                  <img
                    :src="getImageUrl(post.thumbnail)"
                    alt="Avatar Tailwind CSS Component"
                  />
                </div>
              </div>
              <div>
                <div class="font-bold">{{ post.tieuDe }}</div>
              </div>
            </div>
          </td>
          <td>{{ post.noiDung }}</td>

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
  getAllPostPhanTrang,
  deletePost,
  getPostById,
} from "~~/composables/useApiPost.js";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();

const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

const posts = ref([]);
const deletedPost = ref(null);
const showAction = ref({});

const fetchData = async () => {
  getAllPostPhanTrang(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      posts.value = response.data.items;
      console.log(posts.value);
    })
    .catch((err) => {
      console.error(err);
    });
};

const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

const previousPage = () => {
  if (pageNumber.value === 1) {
    return;
  }
  pageNumber.value -= 1;
};

const nextPage = () => {
  console.log(1);
  if (posts.value.length < pageSize) {
    return;
  }
  pageNumber.value += 1;
};

const onDeleteButtonClick = (id) => {
  console.log(id);
  deletePost(id)
    .then((res) => {
      deletedPost.value = res;
      $toast.success("Xoá bài tin thành công.");
    })
    .catch((err) => {
      console.error(err);
      $toast.error("Xoá bài tin thất bại. Vui lòng thử lại!");
    });
};

const onEditButtonClick = (id) => {
  router.push({ name: "Post", params: { id: id } });
  getPostById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

watchEffect(() => {
  fetchData();

  if (deletedPost.value !== null) {
    getAllPostPhanTrang();
    deletedPost.value = null;
  }
});

const toggleAction = (id) => {
  showAction.value[id] = !showAction.value[id];
};

const isOpen = ref(false);

const toggleDropdown = () => {
  isOpen.value = !isOpen.value;
};

const closeDropdown = () => {
  isOpen.value = false;
};
</script>

<style></style>
