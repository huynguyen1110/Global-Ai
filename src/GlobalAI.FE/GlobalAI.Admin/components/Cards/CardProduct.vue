<template>
  <div class="w-full">
    <div class="relative w-full overflow-x-auto">
      <div class="mb-0 rounded-md px-4 py-3 bg-[#fff] border-0">
        <div class="flex flex-wrap items-center">
          <div
            class="relative w-full px-4 max-w-full flex justify-between items-center"
          >
            <h3 class="font-semibold text-lg text-slate-800 uppercase">
              Danh sách sản phẩm
            </h3>
            <button
              @click="router.push('/admin/product/addproduct')"
              class="btn btn-outline"
            >
              Thêm sản phẩm
            </button>
          </div>
        </div>
      </div>
      <EasyDataTable
        table-class-name="mc-tbl"
        class="mx-2 md:mx-0 hover:cursor-pointer"
        :headers="headers"
        :hide-footer="true"
        :loading="tblLoading"
        :items="products"
      >
        <template #item-tenSanPham="item">
          <div class="flex items-center space-x-3">
            <div class="avatar">
              <div class="mask mask-squircle w-12 h-12">
                <img
                  :src="getImageUrl(item.thumbnail)"
                  alt="Avatar Tailwind CSS Component"
                />
              </div>
            </div>
            <div>
              <div class="font-bold">
                {{
                  item.tenSanPham.length > 30
                    ? item.tenSanPham.slice(0, 30) + "..."
                    : item.tenSanPham
                }}
              </div>
            </div>
          </div>
        </template>
        <template #item-giaBan="item">
          <span>
            {{
              item?.giaBan.toLocaleString("vi-VN", {
                style: "currency",
                currency: "VND",
              })
            }}
          </span>
        </template>
        <template #item-giaChietKhau="item">
          <span>
            {{
              item?.giaChietKhau.toLocaleString("vi-VN", {
                style: "currency",
                currency: "VND",
              })
            }}
          </span>
        </template>
        <template #item-ngayDangKi="item">
          <span>
            {{
              item?.ngayDangKi
                ? $moment(item.ngayDangKi).format("DD/MM/YYYY")
                : ""
            }}
          </span>
        </template>
        <template #item-action="item">
          <div class="dropdown dropdown-left dropdown-end">
            <label
              tabindex="0"
              class="btn m-1 btn-outline"
              @click="toggleDropdown"
              >...</label
            >
            <ul
              tabindex="0"
              class="dropdown-content menu z-50 p-2 shadow bg-base-100 rounded-box w-52"
              v-if="isOpen"
              @click="closeDropdown"
            >
              <li @click="onEditButtonClick(item.id)"><a>Sửa</a></li>
              <li @click="onDeleteButtonClick(item.id)"><a>Xoá</a></li>
              <li><a>Duyệt</a></li>
            </ul>
          </div>
        </template>
      </EasyDataTable>
    </div>
    <div class="btn-group flex justify-center mt-2">
      <Pagination
        v-model="pageNumber"
        @page-change="fetchData"
        :page-count="pageTotalItems / pageSize"
      />
    </div>
  </div>
</template>

<script setup>
import TableDropdown from "../Dropdowns/TableDropdown.vue";
import Pagination from "../Pagination/Pagination.vue";
import { ref, watchEffect } from "vue";
import { useRouter } from "vue-router";

const { $moment } = useNuxtApp();

const router = useRouter();
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;

// Khởi tạo giá trị mặc định phân trang 5 1 0
const pageSize = 16;
const pageTotalItems = ref(1);
const pageNumber = ref(1);
const skip = ref(0);

// Sử dụng biến ref() để tạo các biến reactive
const products = ref([]);
const deletedProduct = ref(null);
const showAction = ref({});
const showMore = ref({});
let tblLoading = ref(false);

const headers = [
  { text: "MÃ", value: "id" },
  { text: "TÊN SẢN PHẨM", value: "tenSanPham" },
  { text: "GIÁ BÁN", value: "giaBan" },
  { text: "GIÁ CHIẾT KHẤU", value: "giaChietKhau" },
  { text: "MÃ DANH MỤC", value: "idDanhMuc" },
  { text: "MÃ GSTORE", value: "idGStore", sortable: true },
  { text: "NGÀY ĐĂNG KÝ", value: "ngayDangKi", width: 200 },
  { text: "TRẠNG THÁI", value: "status" },
  { text: "", value: "action" },
];

// Lấy tất cả sản phẩm
const fetchData = () => {
  tblLoading.value = true;
  getSanPhamByIdGStore(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      // Gán giá trị mới vào biến reactive
      products.value = response.data.items;
      pageTotalItems.value = response.data.totalItems;
      console.log(products.value);
    })
    .catch((err) => {
      console.error(err);
    })
    .finally(() => {
      tblLoading.value = false;
    });
};

const headerItemClassNameFunction = (header, columnNumber) => {
  return "text-";
};

// Hàm này sẽ lấy đường dẫn của ảnh từ server và bind vào thuộc tính src của thẻ img
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
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
    // getAllProducts();
    // Đặt lại giá trị cho biến deletedProduct
    deletedProduct.value = null;
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
