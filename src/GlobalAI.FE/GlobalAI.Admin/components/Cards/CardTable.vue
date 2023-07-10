<template>
  <div>
    <div class="overflow-x-auto relative w-full">
      <table class="table w-full">
        <!-- head -->
        <thead>
          <tr>
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <th>Mã sản phẩm</th>
            <th>Tên sản phẩm</th>
            <th>Giá bán</th>
            <th>Giá chiết khấu</th>
            <th>Mã danh mục</th>
            <th>Mã GStore</th>
            <th>Ngày đăng ký</th>
            <td>Mô tả</td>
            <th>Trạng thái sản phẩm</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr
            class="text-sm hover:bg-gray-100"
            v-for="product in products"
            :key="product.id"
          >
            <th>
              <label>
                <input type="checkbox" class="checkbox" />
              </label>
            </th>
            <td>{{ product.id }}</td>
            <td>
              <div class="flex items-center space-x-3">
                <div class="avatar">
                  <div class="mask mask-squircle w-12 h-12">
                    <img
                      :src="getImageUrl(product.thumbnail)"
                      alt="Avatar Tailwind CSS Component"
                    />
                  </div>
                </div>
                <div>
                  <div class="font-bold">
                    {{
                      product.tenSanPham.length > 20
                        ? product.tenSanPham.slice(0, 20) + "..."
                        : product.tenSanPham
                    }}
                  </div>
                </div>
              </div>
            </td>
            <td>
              {{
                product.giaBan.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })
              }}
            </td>
            <td>
              {{
                product.giaChietKhau.toLocaleString("vi-VN", {
                  style: "currency",
                  currency: "VND",
                })
              }}
            </td>
            <td>{{ product.idDanhMuc }}</td>
            <td>{{ product.idGStore }}</td>
            <td>
              {{
                product.ngayDangKi
                  ? $moment(product.ngayDangKi).format("DD/MM/YYYY")
                  : ""
              }}
            </td>
            <td class="">
              <div v-if="product.moTa && product.moTa.length > 20">
                <template v-if="!showMore[product.id]">
                  {{ product.moTa.slice(0, 20) }}...
                  <span
                    @click="showMore[product.id] = true"
                    class="font-bold cursor-pointer"
                    >Xem thêm</span
                  >
                </template>
                <template v-else>
                  {{ product.moTa }}
                  <span
                    @click="showMore[product.id] = false"
                    class="font-bold cursor-pointer"
                    >Thu gọn</span
                  >
                </template>
              </div>
              <div v-else>{{ product.moTa }}</div>
            </td>
            <td>Đã duyệt</td>
            <td
              class="border-t-0 px-5 align-middle border-l-0 border-r-0 text-xs whitespace-nowrap relative"
            >
              <button
                @click="toggleAction(product.id)"
                class="btn btn-ghost btn-xs"
              >
                ...
              </button>
              <div
                class="absolute top-full right-0 z-50 w-48"
                v-if="showAction[product.id]"
              >
                <div
                  class="bg-white flex flex-col shadow-2xl border px-4 py-2 rounded-lg overflow-hidden"
                >
                  <button
                    @click="onEditButtonClick(product.id)"
                    class="text-black items-center justify-center w-full font-bold py-2 flex rounded hover:bg-slate-800 hover:text-white"
                  >
                    Sửa
                  </button>
                  <hr />
                  <button
                    @click="onDeleteButtonClick(product.id)"
                    class="text-black items-center justify-center w-full font-bold py-2 flex rounded hover:bg-slate-800 hover:text-white"
                  >
                    Xoá
                  </button>
                  <hr />
                  <button
                    class="text-black items-center justify-center w-full font-bold py-2 flex rounded hover:bg-slate-800 hover:text-white"
                  >
                    Duyệt
                  </button>
                  <hr />
                </div>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="flex justify-end mt-2">
      <button
        @click="router.push('/admin/product/addproduct')"
        class="btn btn-outline"
      >
        Thêm sản phẩm
      </button>
    </div>
    <div class="btn-group float-right mt-2">
      <button @click="previousPage" class="btn">«</button>
      <button @click="nextPage" class="btn">»</button>
    </div>
  </div>
</template>
<script>
import TableDropdown from "../Dropdowns/TableDropdown.vue";

import bootstrap from "../../assets/img/bootstrap.jpg";
import angular from "../../assets/img/angular.jpg";
import sketch from "../../assets/img/sketch.jpg";
import react from "../../assets/img/react.jpg";
import vue from "../../assets/img/react.jpg";

import team1 from "../../assets/img/team-1-800x800.jpg";
import team2 from "../../assets/img/team-2-800x800.jpg";
import team3 from "../../assets/img/team-3-800x800.jpg";
import team4 from "../../assets/img/team-4-470x470.png";
import { toast } from "vue3-toastify";

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
import { ref, watchEffect } from "vue";
import { useRouter } from "vue-router";
import {
  getAllProducts,
  deleteProduct,
  getProductById,
} from "~~/composables/useApiProduct.js";

const { $moment } = useNuxtApp();

const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

// Khởi tạo giá trị mặc định phân trang 5 1 0
const pageSize = 5;
const pageNumber = ref(1);
const skip = ref(0);

// Sử dụng biến ref() để tạo các biến reactive
const products = ref([]);
const deletedProduct = ref(null);
const showAction = ref({});
const showMore = ref({});

function formatGia(gia) {
  return gia.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
}

const giaBanFormatted = computed(() => formatGia(giaBan.value));

// Lấy tất cả sản phẩm
const fetchData = async () => {
  getAllProducts(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      // Gán giá trị mới vào biến reactive
      products.value = response.data.items;
      console.log(products.value);
    })
    .catch((err) => {
      console.error(err);
    });
};
// Hàm này sẽ lấy đường dẫn của ảnh từ server và bind vào thuộc tính src của thẻ img
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

const previousPage = () => {
  if (pageNumber.value === 1) {
    // Kiểm tra xem đã đạt trang đầu tiên hay chưa
    return;
  }
  pageNumber.value -= 1;
};

const nextPage = () => {
  console.log(1);
  if (products.value.length < pageSize) {
    // Kiểm tra xem có đủ sản phẩm để hiển thị trên trang tiếp theo hay không
    return;
  }
  pageNumber.value += 1;
};
// Gọi hàm xóa sản phẩm khi người dùng click vào nút Xóa
const onDeleteButtonClick = (id) => {
  deleteProduct(id)
    .then((res) => {
      // Gán giá trị mới vào biến reactive
      deletedProduct.value = res;
      toast.success("Xoá sản phẩm thành công.");
    })
    .catch((err) => {
      console.error(err);
      toast.error("Xoá sản phẩm thất bại. Vui lòng thử lại!");
    });
};

// Gọi hàm sửa bắn dữ liệu và form
const onEditButtonClick = (id) => {
  router.push({ name: "Product", params: { id: id } });
  getProductById(id)
    .then((res) => {
      res.data;
    })
    .catch((err) => {
      console.error(err);
    });
};

watchEffect(() => {
  //Lấy tất cả sản phẩm
  fetchData();
  if (deletedProduct.value !== null) {
    // Nếu sản phẩm đã được xóa thành công, gọi lại hàm getAllProducts() để cập nhật danh sách sản phẩm
    getAllProducts();
    // Đặt lại giá trị cho biến deletedProduct
    deletedProduct.value = null;
  }
});

// Show Action Sửa và xoá
const toggleAction = (id) => {
  showAction.value[id] = !showAction.value[id];
};
</script>
