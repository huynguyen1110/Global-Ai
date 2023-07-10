<template>
  <the-card class="!max-w-full mt-3 hover:bg-white">
    <h5 class="mb-5 text-2xl font-bold">Thêm mới sản phẩm</h5>
    <tabs v-model="activeTab" class="p-5 w-full">
      <tab name="san-pham" title="Thông tin">
        <div class="grid gap-6 mb-6 md:grid-cols-2">
          <div class="col-span-1">
            <label for="maSanPham" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Mã sản phẩm
            </label>
            <Field v-model="maSanPham" name="maSanPham" type="text" placeholder="Mã sản phẩm..."
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="maSanPham" class="text-red-500" />
          </div>
          <div class="col-span-1">
            <label for="tenSanPham" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Tên sản phẩm
            </label>
            <Field v-model="tenSanPham" name="tenSanPham" type="text" placeholder="Tên sản phẩm..."
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="tenSanPham" class="text-red-500" />
          </div>
          <div class="col-span-1">
            <label for="idDanhMuc" class="block uppercase text-slate-600 text-xs font-bold mb-2">Danh mục</label>
            <select v-model="idDanhMuc" id="idDanhMuc"
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
            <select v-model="idDanhMucThuocTinh" id="idDanhMucThuocTinh" @change="onChangeDanhMucThuocTinh"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
              required>
              <option value="">-- Lựa chọn danh mục thuộc tính --</option>
              <option v-for="(danhmuc, idx) in listDanhMucThuocTinh" :value="danhmuc.id" :key="idx">
                {{ danhmuc.ten }}
              </option>
            </select>
          </div>
          <div class="col-span-1">
            <label for="giaBan" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Giá bán
            </label>
            <Field v-model.number="giaBan" name="giaBan" type="number"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="giaBan" class="text-red-500" />
          </div>
          <div class="col-span-1">
            <label for="giaChietKhau" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Giá chiết khấu
            </label>
            <Field v-model.number="giaChietKhau" name="giaChietKhau" type="number"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="giaChietKhau" class="text-red-500" />
          </div>
          <div class="col-span-1">
            <label for="giaToiThieu" class="block uppercase text-slate-600 text-xs font-bold mb-2">
              Giá tối thiểu
            </label>
            <Field v-model.number="giaToiThieu" name="giaToiThieu" type="number"
              class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
            <error-message name="giaToiThieu" class="text-red-500" />
          </div>
          <div class="">
            <label for="image" class="block uppercase text-slate-600 text-xs font-bold mb-2">Hình ảnh</label>
            <div class="flex items-center justify-between relative">
              <input type="file" id="image"
                class="border placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                required @change="uploadImage" />
              <!-- <img alt="Product Image" class="w-[50px] h-[50px] border absolute right-0 rounded"
              :src="getImageUrl(thumbnail)" /> -->
            </div>
          </div>
        </div>

        <!--  -->
        <div class="flex flex-col">
          <div class="mb-6">
            <label for="moTa" class="block uppercase text-slate-600 text-xs font-bold mb-2">Mô tả</label>
            <div class="w-full h-[185px]">
              <TextEditor v-model="moTa" />
            </div>
          </div>
        </div>
      </tab>
      <tab name="chi-tiet" title="Chi tiết">
        <div class="flex flex-row justify-end">
          <button class="btn btn-outline" type="button" @click="addRowChiTietSp">Thêm chi tiết sản phẩm</button>
        </div>
        <!-- SAN PHAM CHI TIET -->
        <div class="card bg-base-100 shadow-xl mt-2" v-for="(chiTiet, idx) in listChiTietSp" :key="idx">
          <div class="card-body">
            <!-- LIST SP -->
            <div>
              <div class="grid gap-6 mb-6 md:grid-cols-2">
                <div class="col-span-1">
                  <label for="maSanPham" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                    Mã sản phẩm
                  </label>
                  <Field v-model="chiTiet.maSanPhamChiTiet" name="maSanPham" type="text" placeholder="Mã sản phẩm..."
                    class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                  <error-message name="maSanPham" class="text-red-500" />
                </div>
                <div class="">
                  <label for="image" class="block uppercase text-slate-600 text-xs font-bold mb-2">Hình ảnh</label>
                  <div class="flex items-center justify-between relative">
                    <input type="file" id="image"
                      class="border placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                      required @change="$event => uploadImage($event, chiTiet.thumbnail)" />
                    <!-- <img alt="Product Image" class="w-[50px] h-[50px] border absolute right-0 rounded"
                    :src="getImageUrl(chiTiet.thumbnail)" /> -->
                  </div>
                </div>
                <div class="col-span-1">
                  <label for="giaBan" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                    Giá bán
                  </label>
                  <Field v-model.number="chiTiet.giaBan" name="giaBan" type="number"
                    class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                  <error-message name="giaBan" class="text-red-500" />
                </div>
                <div class="col-span-1">
                  <label for="giaChietKhau" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                    Giá chiết khấu
                  </label>
                  <Field v-model.number="chiTiet.giaChietKhau" name="giaChietKhau" type="number"
                    class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                  <error-message name="giaChietKhau" class="text-red-500" />
                </div>
                <div class="col-span-1">
                  <label for="giaToiThieu" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                    Giá tối thiểu
                  </label>
                  <Field v-model.number="chiTiet.giaToiThieu" name="giaToiThieu" type="number"
                    class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                  <error-message name="giaToiThieu" class="text-red-500" />
                </div>
                <div class="col-span-1">
                  <label for="soLuong" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                    Số lượng
                  </label>
                  <Field v-model.number="chiTiet.soLuong" name="soLuong" type="number"
                    class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                  <error-message name="soLuong" class="text-red-500" />
                </div>
              </div>
              <h5 class="text-bold uppercase text-lg mb-2">Thuộc tính</h5>
              <div class="grid gap-6 mb-6 md:grid-cols-2">
                <div v-for="(thuocTinh, index) in listThuocTinh" :key="index" class="col-span-1">
                  <label for="idGiaTri" class="block uppercase text-slate-600 text-xs font-bold mb-2">{{
                    thuocTinh.tenThuocTinh }}</label>
                  <select id="idGiaTri" v-model="chiTiet.listIdThuocTinhGiaTri[index]"
                    class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                    required>
                    <option value="">-- Thuộc tính --</option>
                    <option v-for="giaTri in thuocTinh.listGiaTri" :value="giaTri.id" :key="giaTri.id">
                      {{ giaTri.giaTri }}
                    </option>
                  </select>
                </div>
              </div>
            </div>
          </div>
        </div>
      </tab>
    </tabs>
    <div class="flex justify-end gap-5 mt-3">
      <button type="submit" class="btn btn-primary" @click="handlePostProduct">
        Thêm sản phẩm
      </button>
      <button class="btn btn-outline btn-success">Duyệt sản phẩm</button>
      <button @click="router.push('/admin/product')" class="btn btn-outline btn-error">
        <span class="flex">Quay về</span>
      </button>
    </div>
  </the-card>
</template>

<script setup>
import { Tabs, Tab } from 'flowbite-vue';
import { postProduct } from "~~/composables/useApiProduct";
import NumberInput from "~~/components/Input/NumberInput.vue";
import TextEditor from "~~/components/TextEditor/TextEditor.vue";
import { Form, Field, ErrorMessage } from "vee-validate";
import * as yup from "yup";
import { TheCard } from 'flowbite-vue'
definePageMeta({
  layout: "admin-management",
});

const activeTab = ref('san-pham');
const maSanPham = ref("");
const tenSanPham = ref("");
const moTa = ref("");
const giaBan = ref(0);
const giaChietKhau = ref(0);
const giaToiThieu = ref(0);
const idDanhMucThuocTinh = ref(0);
const idDanhMuc = ref("");
const thumbnail = ref("");
const danhmucsp = ref([]);
const listDanhMucThuocTinh = ref([]);
const listThuocTinh = ref([]);
const listChiTietSp = ref([{
  idSanPham: 0,
  listIdThuocTinhGiaTri: [
    0
  ],
  idDanhMucThuocTinh: 0,
  maSanPhamChiTiet: '',
  soLuong: 0,
  moTa: '',
  giaBan: 0,
  giaChietKhau: 0,
  giaToiThieu: 0,
  thumbnail: ''
}]);

const router = useRouter();
const config = useRuntimeConfig();
const { $toast } = useNuxtApp();
const baseUrl = config.public.apiEndpoint;

//Lấy danh mục sản phẩm
const pageSize = 15;
const pageNumber = ref(1);
const skip = ref(0);

onMounted(() => {
  getAllCategoryProductPhanTrang(pageSize, pageNumber.value, skip.value)
    .then((response) => {
      danhmucsp.value = response.data.items;
    })
    .catch((error) => {
      console.log(error);
    });

  getListDanhMucThuocTinh().then(res => {
    listDanhMucThuocTinh.value = res.data.data.items;
  });
});

const onChangeDanhMucThuocTinh = ($event) => {
  listChiTietSp.value.forEach(item => {
    item.listIdThuocTinhGiaTri = [];
  });
  getDanhMucThuocTinhById($event.target.value).then(res => listThuocTinh.value = res.data?.data.listThuocTinh);
};

const addRowChiTietSp = () => {
  listChiTietSp.value.push({
    listIdThuocTinhGiaTri: [
      0
    ],
    maSanPhamChiTiet: '',
    soLuong: 0,
    moTa: '',
    giaBan: 0,
    giaChietKhau: 0,
    giaToiThieu: 0,
    thumbnail: ''
  });
}

const uploadImage = (event, obj) => {
  postFile(event.target.files[0], 'image')
    .then((response) => {
      if (obj) {
        obj = response.data;
      } else {
        thumbnail.value = response.data;
      }
    })
    .catch((error) => {
      console.log(error);
    });
}

// const getImageUrl = (imageUrl) => {
//   if (!imageUrl) {
//     return "https://placehold.it/50x50";
//   }
//   const url = `${baseUrl}/api/file/get?folder=image&file=${encodeURIComponent(
//     imageUrl
//   )}&download=false`;
//   return url;
// };

const handlePostProduct = () => {
  const listChiTiet = listChiTietSp.value.map(item => ({
    ...item,
    listIdThuocTinhGiaTri: item.listIdThuocTinhGiaTri.filter(x => x > 0),
  }));
  const productData = {
    maSanPham: maSanPham.value,
    tenSanPham: tenSanPham.value,
    giaBan: giaBan.value,
    giaChietKhau: giaChietKhau.value,
    giaToiThieu: giaToiThieu.value,
    moTa: moTa.value,
    idDanhMuc: `${idDanhMuc.value}`,
    idDanhMucThuocTinh: idDanhMucThuocTinh.value,
    thumbnail: thumbnail.value,
    listChiTiet: listChiTiet
  };

  postProduct(productData)
    .then((res) => {
      if (res?.code === 200) {
        $toast.success("Thêm sản phẩm thành công");
        router.push('/admin/product');
      }
    })
    .catch((err) => {
      const msg =
        err?.response?.data?.message || "Có sự cố xảy ra khi thêm sản phẩm";
      $toast.error(msg);
    });
}



</script>
