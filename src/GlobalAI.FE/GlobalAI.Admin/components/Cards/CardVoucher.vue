<template>
  <div>
    <div class="overflow-x-auto relative w-full">
      <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
        <div class="flex flex-wrap items-center">
          <div
            class="relative w-full px-4 max-w-full flex justify-between items-center"
          >
            <h3 class="font-semibold text-lg text-slate-800 uppercase">
              Danh sách Voucher
            </h3>
            <button
              @click="router.push('/admin/voucher/addvoucher')"
              class="btn btn-outline"
            >
              Thêm Voucher
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
            <th>Tên</th>
            <th>Hình ảnh</th>
            <th>Giá trị</th>
            <th>Số lượng</th>
            <th>Ngày hết hạn</th>
            <th>Mô tả</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr class="text-sm" v-for="voucher in vouchers" :key="voucher.id">
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <td>{{ voucher.id }}</td>

            <td>
              {{ voucher.name }}
            </td>
            <td>
              <div class="avatar">
                <div class="mask mask-squircle w-12 h-12">
                  <img :src="getImageUrl(voucher.avatar)" alt="Avatar" />
                </div>
              </div>
            </td>
            <td>
              {{ voucher.giaTri }}
            </td>

            <td>
              {{ voucher.soLuong }}
            </td>

            <td>
              {{ voucher.ngayHetHan }}
            </td>
            <td>
              {{ voucher.moTa }}
            </td>
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
                  <li @click="onEditButtonClick(voucher.id)"><a>Sửa</a></li>
                  <li @click="onDeleteButtonClick(voucher.id)"><a>Xoá</a></li>
                </ul>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="btn-group flex justify-center mt-2">
      <button @click="previousPage" class="btn">«</button>
      <button class="btn">Trang {{ pageNumber }}</button>
      <button @click="nextPage" class="btn">»</button>
    </div>
  </div>
</template>
<script>
import TableDropdown from "@/components/Dropdowns/TableDropdown.vue";

import bootstrap from "@/assets/img/bootstrap.jpg";
import angular from "@/assets/img/angular.jpg";
import sketch from "@/assets/img/sketch.jpg";
import react from "@/assets/img/react.jpg";
import vue from "@/assets/img/react.jpg";

import team1 from "@/assets/img/team-1-800x800.jpg";
import team2 from "@/assets/img/team-2-800x800.jpg";
import team3 from "@/assets/img/team-3-800x800.jpg";
import team4 from "@/assets/img/team-4-470x470.png";

export default {
  data() {
    return {
      bootstrap,
      angular,
      sketch,
      react,
      vue,
      team1,
      team2,
      team3,
      team4,
    };
  },
  components: {
    TableDropdown,
  },
  props: {
    color: {
      default: "light",
      validator: function (value) {
        // The value must match one of these strings
        return ["light", "dark"].indexOf(value) !== -1;
      },
    },
  },
};
</script>

<script setup>
import {
  getAllVoucherPhanTrang,
  deleteVoucher,
  getVoucherById,
} from "~~/composables/useApiVoucher";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();

const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

// Khởi tạo giá trị mặc định phân trang 5 1 0
const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

// Sử dụng biến ref() để tạo các biến reactive
const vouchers = ref([]);
const deletedVoucher = ref(null);
const showAction = ref({});

const previousPage = () => {
  if (pageNumber.value === 1) {
    return;
  }
  pageNumber.value -= 1;
};

const nextPage = () => {
  console.log(1);
  if (vouchers.value.length < pageSize) {
    return;
  }
  pageNumber.value += 1;
};

const fetchData = async () => {
  getAllVoucherPhanTrang(pageSize, pageNumber.value, skip.value)
    .then((res) => {
      vouchers.value = res.data.items;
      console.log(vouchers.value);
    })
    .catch((err) => console.error(err));
};

// Hàm này sẽ lấy đường dẫn của ảnh từ server và bind vào thuộc tính src của thẻ img
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

// // Gọi hàm xóa sản phẩm khi người dùng click vào nút Xóa
const onDeleteButtonClick = (id) => {
  deleteVoucher(id)
    .then((res) => {
      // Gán giá trị mới vào biến reactive
      deletedVoucher.value = res;
      $toast.success("Xoá Voucher thành công.");
    })
    .catch((err) => {
      console.error(err);
      $toast.error("Xoá Voucher thất bại. Vui lòng thử lại!");
    });
};

// Gọi hàm sửa bắn dữ liệu và form
const onEditButtonClick = (id) => {
  router.push({ name: "Voucher", params: { id: id } });
  getVoucherById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

watchEffect(() => {
  fetchData();

  if (deletedVoucher.value !== null) {
    getAllOrder();
    deletedVoucher.value = null;
  }
});
// Show Action Sửa và xoá
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
