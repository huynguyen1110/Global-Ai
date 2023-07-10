<template>
  <div class="overflow-x-auto relative w-full">
    <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
      <div class="flex flex-wrap items-center">
        <div
          class="relative w-full px-4 max-w-full flex justify-between items-center"
        >
          <h3 class="font-semibold text-lg text-slate-800 uppercase">
            Danh sách danh mục sản phẩm
          </h3>
          <button
            @click="router.push('/admin/categoryproduct/addcategoryproduct')"
            class="btn btn-outline"
          >
            Thêm danh mục sản phẩm
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
          <th>Id</th>
          <th>Id danh mục</th>
          <th>Tên danh mục</th>
          <th>Ngày khởi tạo</th>
          <th>Người tạo</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <!-- row 1 -->
        <tr v-for="post in categoryProducts" :key="post.id" class="text-sm">
          <th>
            <label>
              <input type="checkbox" class="checkbox" />
            </label>
          </th>
          <td>{{ post.id }}</td>
          <td>{{ post.idDanhMuc }}</td>
          <td>
            {{ post.tenDanhMuc }}
          </td>
          <td>{{ post.createdDate }}</td>
          <td>{{ post.createdBy }}</td>
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
  deleteCategoryProduct,
  getCategoryProductById,
} from "~~/composables/useApiCategoryProduct";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();

const router = useRouter();

const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

const categoryProducts = ref([]);
const deletedCategoryProduct = ref(null);

const fetchData = async () => {
  getAllCategoryProductPhanTrang(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      categoryProducts.value = response.data.items;
      console.log(categoryProducts.value);
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
  if (categoryProducts.value.length < pageSize) {
    return;
  }
  pageNumber.value += 1;
};

const onDeleteButtonClick = (id) => {
  deleteCategoryProduct(id)
    .then((res) => {
      deletedCategoryProduct.value = res;
      $toast.success("Xoá danh mục sản phẩm thành công.");
    })
    .catch((err) => {
      console.error(err);
      $toast.error("Xoá danh mục sản phẩm thất bại. Vui lòng thử lại!");
    });
};

const onEditButtonClick = (id) => {
  router.push({ name: "CategoryProduct", params: { id: id } });
  getCategoryProductById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

watchEffect(() => {
  fetchData();

  if (deletedCategoryProduct.value !== null) {
    deletedCategoryProduct.value = null;
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
