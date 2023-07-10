<template>
  <div>
    <div class="overflow-x-auto relative w-full">
      <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
        <div class="flex flex-wrap items-center">
          <div
            class="relative w-full px-4 max-w-full flex justify-between items-center"
          >
            <h3 class="font-semibold text-lg text-slate-800 uppercase">
              Danh sách danh mục thuộc tính sản phẩm
            </h3>
            <button
              @click="
                router.push('/admin/categoryattribute/addcategoryattribute')
              "
              class="btn btn-outline"
            >
              Thêm danh mục thuộc tính sản phẩm
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
            <th>Mã danh mục thuộc tính sản phẩm</th>
            <th>Tên danh mục thuộc tính sản phẩm</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr
            class="text-sm"
            v-for="categoryAtt in categoryAttributes"
            :key="categoryAtt.id"
          >
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <td>
              {{ categoryAtt.ma }}
            </td>

            <td>
              {{ categoryAtt.ten }}
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
                  <li @click="onEditButtonClick(categoryAtt.id)"><a>Sửa</a></li>
                  <li @click="onDeleteButtonClick(categoryAtt.id)">
                    <a>Xoá</a>
                  </li>
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
  getAllDanhMucThuocTinhSanPham,
  deleteDanhMucThuocTinhSanPham,
  getDanhMucThuocTinhSanPhamById,
} from "~~/composables/useApiCategoryAttribute";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();

const router = useRouter();

// Khởi tạo giá trị mặc định phân trang 5 1 0
const pageSize = ref(5);
const pageNumber = ref(1);
const skip = ref(0);

// Sử dụng biến ref() để tạo các biến reactive
const categoryAttributes = ref([]);
const deletedCategoryAttribute = ref(null);

const previousPage = () => {
  if (pageNumber.value === 1) {
    return;
  }
  pageNumber.value -= 1;
};

const nextPage = () => {
  if (categoryAttributes.value.length < pageSize) {
    return;
  }
  pageNumber.value += 1;
};

const fetchData = async () => {
  getAllDanhMucThuocTinhSanPham(pageSize.value, pageNumber.value, skip.value)
    .then((res) => {
      categoryAttributes.value = res.data.items;
    })
    .catch((err) => console.error(err));
};

// // Gọi hàm xóa sản phẩm khi người dùng click vào nút Xóa
const onDeleteButtonClick = (id) => {
  deleteDanhMucThuocTinhSanPham(id)
    .then((res) => {
      deletedCategoryAttribute.value = res;
      $toast.success("Xoá danh mục thuộc tính sản phẩm thành công thành công.");
    })
    .catch((err) => {
      console.error(err);
      $toast.error(
        "Xoá danh mục thuộc tính sản phẩm thất bại. Vui lòng thử lại!"
      );
    });
};

const onEditButtonClick = (id) => {
  router.push({ name: "categoryattribute", params: { id: id } });
  getDanhMucThuocTinhSanPhamById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

watchEffect(() => {
  fetchData();

  if (deletedCategoryAttribute.value !== null) {
    getAllDanhMucThuocTinhSanPham(pageSize.value, pageNumber.value, skip.value);
    deletedCategoryAttribute.value = null;
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
