<template>
  <div class="overflow-x-auto relative w-full">
    <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
      <div class="flex flex-wrap items-center">
        <div
          class="relative w-full px-4 max-w-full flex justify-between items-center"
        >
          <h3 class="font-semibold text-lg text-slate-800 uppercase">
            Danh sách chi tiết đơn hàng
          </h3>
          <button
            @click="
              router.push('/admin/detailsorderall/adddetailsorderall')
            "
            class="btn btn-outline"
          >
            Thêm chi tiết đơn hàng
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
          <th>Mã đơn hàng</th>
          <th>Mã sản phẩm</th>
          <th>Số lượng</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="post in postCategorys" :key="post.id" class="text-sm">
          <th>
            <label>
              <input type="checkbox" class="checkbox" />
            </label>
          </th>
          <td>{{ post.idDonHang }}</td>
          <td>{{ post.idSanPham }}</td>
          <td>{{ post.soLuong }}</td>

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
import { useRouter } from "vue-router";
import {
  getAllDetailsOrderAll,
  deleteDetailsOrderAll,
  getDetailsOrderAllById,
} from "~~/composables/useApiDetailsOrderAll";
const { $toast } = useNuxtApp();

const router = useRouter();
const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

const postCategorys = ref([]);
const deletedDetails = ref(null);

const fetchData = async () => {
  getAllDetailsOrderAll()
    .then((response) => {
      console.log(response.data);
      postCategorys.value = response.data;
    })
    .catch((err) => console.error(err));
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
  deleteDetailsOrderAll(id)
    .then((res) => {
      deletedDetails.value = res;
      $toast.success("Xoá chi tiết đơn hàng thành công.");
    })
    .catch((err) => {
      console.error(err);
      $toast.error("Xoá chi tiết đơn hàng thất bại. Vui lòng thử lại!");
    });
};

const onEditButtonClick = (id) => {
  router.push({ name: "CardDetailsOrderAll", params: { id: id } });
  getDetailsOrderAllById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

watchEffect(() => {
  fetchData();

  if (deletedDetails.value !== null) {
    getAllDetailsOrderAll();
    deletedDetails.value = null;
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
