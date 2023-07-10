<template>
  <the-card class="!max-w-full mt-3 hover:bg-white">

    <h5 class="mb-5 text-2xl font-bold">Cập nhật sản phẩm</h5>
    <tabs v-model="activeTab" class="p-5"> <!-- class appends to content DIV for all tabs -->
      <tab name="san-pham" title="Thông tin">
        <div class="grid gap-6 mb-6 md:grid-cols-2">
          <div class="col-span-1">
            <label for="maSanPham" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Mã sản phẩm
            </label>
            <Field name="maSanPham" type="text" v-model="sanPham.maSanPham" placeholder="Mã sản phẩm..."
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="maSanPham" class="text-red-500" />
          </div>

          <div class="col-span-1">
            <label for="tenSanPham" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Tên sản phẩm
            </label>
            <Field name="tenSanPham" type="text" v-model="sanPham.tenSanPham" placeholder="Tên sản phẩm..."
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="tenSanPham" class="text-red-500" />
          </div>

          <div class="col-span-1">
            <label for="idDanhMuc" class="block uppercase text-slate-600 text-xs font-bold mb-2">Danh mục</label>
            <select v-model="sanPham.idDanhMuc" id="idDanhMuc"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
              required>
              <option value="">-- Lựa chọn danh mục --</option>
              <option v-for="danhmuc in danhmucsp" :value="danhmuc.id" :key="danhmuc.id">
                {{ danhmuc.tenDanhMuc }}
              </option>
            </select>
          </div>
          <div class="col-span-1">
            <label for="idDanhMucThuocTinh" class="block uppercase text-slate-600 text-xs font-bold mb-2">Danh mục thuộc
              tính</label>
            <select v-model="sanPham.idDanhMucThuocTinh" id="idDanhMucThuocTinh" disabled
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
              required>
              <option value="">-- Lựa chọn danh mục --</option>
              <option v-for="danhmuc in listDanhMucThuocTinh" :value="danhmuc.id" :key="danhmuc.id">
                {{ danhmuc.ten }}
              </option>
            </select>
          </div>
          <div class="col-span-1">
            <label for="giaBan" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Giá bán
            </label>
            <Field v-model.number="sanPham.giaBan" name="giaBan" type="number"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="giaBan" class="text-red-500" />
          </div>
          <div class="col-span-1">
            <label for="giaChietKhau" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Giá chiết khấu
            </label>
            <Field v-model.number="sanPham.giaChietKhau" name="giaChietKhau" type="number"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="giaChietKhau" class="text-red-500" />
          </div>
          <div class="col-span-1">
            <label for="giaToiThieu" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Giá tối thiểu
            </label>
            <Field v-model.number="sanPham.giaToiThieu" name="giaToiThieu" type="number"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="giaToiThieu" class="text-red-500" />
          </div>
          <div class="">
            <label for="image" class="block uppercase text-slate-600 text-xs font-bold mb-2">Hình ảnh</label>
            <div class="flex items-center justify-between relative">
              <input type="file" id="image"
                class="border placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                @change.prevent="uploadImage" />
              <img alt="Product Image" class="w-[50px] h-[50px] border absolute right-0 rounded"
                :src="getImageUrl(sanPham.thumbnail)" />
            </div>
          </div>
        </div>
        <div class="mb-6">
          <label for="moTa" class="block uppercase text-slate-600 text-xs font-bold mb-2">Mô tả</label>
          <div class="w-full h-[185px]">
            <TextEditor v-model="sanPham.moTa" />
          </div>
        </div>
        <div class="flex justify-end gap-5 mt-3">
          <button @click="submitForm" class="btn btn-primary float-right">
            Cập nhật sản phẩm
          </button>
          <button class="btn btn-outline btn-success">Duyệt sản phẩm</button>
          <button @click="router.push('/admin/product')" class="btn btn-outline btn-error">
            <span class="flex">Quay về</span>
          </button>
        </div>
      </tab>
      <tab name="chi-tiet" title="Chi Tiết">
        <!-- CHI TIET SAN PHAM -->
        <div class="flex flex-row justify-between mb-3">
          <h2 class="card-title inline-block text-emerald-500">Chi tiết sản phẩm</h2>
          <button class="btn btn-primary" type="button" @click="openAddSpChiTiet">Thêm chi tiết sản phẩm</button>
        </div>
        <div>
          <EasyDataTable table-class-name="mc-tbl" class="mx-2 md:mx-0 hover:cursor-pointer mt-2" :headers="headers"
            :hide-footer="true" :loading="tblLoading" :items="sanPham.listSanPhamChiTiet">
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
            <template #item-giaToiThieu="item">
              <span>
                {{
                  item?.giaToiThieu.toLocaleString("vi-VN", {
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
            <template #item-ngayDuyet="item">
              <span>
                {{
                  item?.ngayDuyet
                  ? $moment(item.ngayDuyet).format("DD/MM/YYYY")
                  : ""
                }}
              </span>
            </template>
            <template #item-action="item">
              <div class="btn-group">
                <button class="btn btn-secondary" @click="openModalUpdate(item)">Sửa</button>
                <button class="btn btn-error" @click="confirmDelete(item)">Xóa</button>
              </div>
            </template>
          </EasyDataTable>
        </div>
      </tab>
    </tabs>
    <ModalAddSanPhamChiTietVue name="modalAddSpChiTiet" :sanPham="sanPham" @on-success="initData" />
    <ModalUpdateSanPhamChiTietVue name="modalUpdateSpChiTiet" :sanPham="sanPham" :sanPhamChiTiet="selectedSpChiTiet"
      @on-success="initData" />
  </the-card>
</template>

<script setup>
import { $vfm } from 'vue-final-modal';
import { useRouter } from "vue-router";
import { TheCard } from 'flowbite-vue'
import { updateProduct, getProductById } from "~~/composables/useApiProduct.js";
import TextEditor from "~~/components/TextEditor/TextEditor.vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import ModalAddSanPhamChiTietVue from "~~/components/SanPham/ModalAddSanPhamChiTiet.vue";
import ModalUpdateSanPhamChiTietVue from "~~/components/SanPham/ModalUpdateSanPhamChiTiet.vue";
import { Tabs, Tab } from 'flowbite-vue';

definePageMeta({
  layout: "admin-management",
  name: "Product",
});

const activeTab = ref('san-pham');
let selectedSpChiTiet = ref({});
const productId = ref([]);
const listDanhMucThuocTinh = ref([]);
const danhmucsp = ref([]);
const sanPham = ref({
  id: 0,
  maSanPham: '',
  tenSanPham: '',
  giaBan: 0,
  giaChietKhau: 0,
  giaToiThieu: 0,
  moTa: '',
  idDanhMuc: '',
  idGStore: 0,
  ngayDangKi: '',
  ngayDuyet: '',
  status: 0,
  thumbnail: '',
  luotXem: 0,
  luotBan: 0,
  idDanhMucThuocTinh: 0,
  listSanPhamChiTiet: [
    {
      id: 0,
      idSanPham: 0,
      maSanPhamChiTiet: '',
      moTa: '',
      giaBan: 0,
      giaChietKhau: 0,
      ngayDangKi: '',
      ngayDuyet: '',
      createdDate: '',
      status: 0,
      giaToiThieu: 0,
      thumbnail: '',
      luotXem: 0,
      luotBan: 0,
      soLuong: 0,
      listThuocTinh: [
        {
          id: 0,
          idThuocTinhGiaTri: 0,
          giaTri: '',
          tenThuocTinh: '',
          idSanPhamChiTiet: 0
        }
      ]
    }
  ]
});
const headers = [
  { text: '#', value: 'id' },
  { text: 'Mã', value: 'maSanPhamChiTiet' },
  { text: 'Giá bán', value: 'giaBan' },
  { text: 'Giá tối thiểu', value: 'giaToiThieu' },
  { text: 'Giá chiết khấu', value: 'giaChietKhau' },
  { text: 'Số lượng', value: 'soLuong' },
  { text: 'Ngày đăng ký', value: 'ngayDangKi' },
  { text: 'Ngày duyệt', value: 'ngayDuyet' },
  { text: 'Lượt xem', value: 'luotXem' },
  { text: 'Lượt bán', value: 'luotBan' },
  { text: '', value: 'action' },
]

const router = useRouter();
const config = useRuntimeConfig();
const { $toast, $swal } = useNuxtApp();
const baseUrl = config.public.apiEndpoint;
//Lấy danh mục sản phẩm
const pageSize = 15;
const pageNumber = ref(1);
const skip = ref(0);
const tblLoading = ref(false);
const isOpen = ref(false);

onMounted(() => {
  productId.value = router.currentRoute.value.params.id;

  initData();
});

const initData = () => {
  tblLoading.value = true;

  getAllCategoryProductPhanTrang(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      danhmucsp.value = response.data.items;
      return getListDanhMucThuocTinh();
    })
    .then(res => {
      listDanhMucThuocTinh.value = res.data?.data.items;
      return getSanPhamAdminById(productId.value);
    })
    .then(res => {
      sanPham.value = res.data?.data
    })
    .catch((error) => {
      console.log(error);
    })
    .finally(() => {
      tblLoading.value = false;
    });
};

const uploadImage = (event) => {
  postFile(event.target.files[0], 'image')
    .then((response) => {
      sanPham.value.thumbnail = response.data;
    })
    .catch((error) => {
      console.log(error);
    });
}

// Hàm này sẽ lấy đường dẫn của ảnh từ server và bind vào thuộc tính src của thẻ img
const getImageUrl = (imageUrl) => {
  console.log(imageUrl);
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

const confirmDelete = (spChiTiet) => {
  $swal.fire({
    title: 'Bạn muốn xóa sản phẩm chi tiết này?',
    showDenyButton: true,
    confirmButtonText: 'Đồng ý',
    denyButtonText: `Hủy`,
  }).then((result) => {
    if (result.isConfirmed) {
      useApiDeleteSanPhamChiTiet(spChiTiet.id).then(res => {
        if (res.data?.code === 200) {
          $toast.success('Xóa sản phẩm thành công chi tiết');
          initData();
        }
      })
        .catch(err => {
          const msg =
            err?.response?.data?.message || "Có sự cố xảy ra khi xoá sản phẩm chi tiết";
          $toast.error(msg);
        })
    }
  })
}

const submitForm = () => {
  const formData = {
    maSanPham: sanPham.value.maSanPham,
    tenSanPham: sanPham.value.tenSanPham,
    moTa: sanPham.value.moTa,
    giaBan: sanPham.value.giaBan,
    giaToiThieu: sanPham.value.giaToiThieu,
    giaChietKhau: sanPham.value.giaChietKhau,
    idDanhMuc: sanPham.value.idDanhMuc,
    idDanhMucThuocTinh: sanPham.value.idDanhMucThuocTinh,
    thumbnail: sanPham.value.thumbnail,
  };
  updateProduct(productId.value, formData)
    .then((res) => {
      console.log(res);
      if (res?.code === 200) {
        $toast.success("Cập nhật sản phẩm thành công");
      }

    })
    .catch((err) => {
      const msg =
        err?.response?.data?.message || "Có sự cố xảy ra khi cập nhật sản phẩm";
      $toast.error(msg);
    });
};

const openAddSpChiTiet = () => {
  $vfm.show('modalAddSpChiTiet');
}

const openModalUpdate = (data) => {
  selectedSpChiTiet.value = { ...data };
  $vfm.show('modalUpdateSpChiTiet');
}

</script>
