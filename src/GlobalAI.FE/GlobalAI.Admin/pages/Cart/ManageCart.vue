<template>
  <div class="mt-[20px] h-[100vh]">
    <div
      class="flex items-center gap-[10px] cursor-pointer px-1"
      @click="handleBack"
    >
      <div class="float-left flex items-center gap-2">
        <font-awesome-icon
          class="text-black text-[18px]"
          :icon="['fas', 'angle-left']"
        />
      </div>
      <a href="/gsaler/home" class="text-[18px] text-[#cc3366]">Trở lại</a>
    </div>
    <div class="flex w-full gap-[30px] lg:flex-row flex-col">
      <div class="lg:w-[65%] mt-[20px] rounded-md overflow-hidden">
        <div class="flex gap-[20px] items-center px-[20px] py-[10px] bg-white">
          <input type="checkbox" v-model="checkAll" @change="checkAllGioHang" />
          <span>Chọn tất cả</span>
        </div>
        <div
          class="mt-[20px] py-[15px] px-[20px] w-full flex flex-col rounded-md overflow-y-auto bg-white"
        >
          <div
            v-for="(sanpham, index) in products"
            :key="index"
            class="flex w-full items-start gap-[10px] mb-[30px]"
          >
            <div class="flex items-center gap-[20px]">
              <input
                :id="sanpham.id"
                :value="sanpham.id"
                v-model="selectedProducts"
                type="checkbox"
              />
              <div
                class="flex flex-col mt-[20px] w-[102px] h-[102px] items-center justify-center"
              >
                <img
                :src="getImageUrl(sanpham.thumbnail)"
                  class="mt-1 rounded-md object-cover"
                  alt=""
                />
                <span class="mt-[10px] text-[16px] text-[#6c757d]"
                  >SL : {{ getCartItemQuantity(sanpham.id) }}</span
                >
              </div>
            </div>
            <div class="ml-[18px] flex flex-col w-full gap-[3px]">
              <h2 class="text-[16px] font-bold uppercase text-[#384059]">
                {{ sanpham.tenSanPham }}
              </h2>
              <span class="text-[14px] text-[#6C757D]">Phân loại : Trắng</span>

              <span class="text-left text-[#cc3366] text-[16px] font-[400]"
                >Tổng giá :
                {{
                  formatMoneyAll(
                    getPrice(getCartItemQuantity(sanpham.id), sanpham.giaBan)
                  )
                }}
              </span>
              <div class="flex justify-between items-center">
                <p
                  @click="
                    handleUpdateProduct(
                      sanpham.id,
                      getCartItemQuantity(sanpham.id),
                      sanpham.giaBan
                    )
                  "
                  class="cursor-pointer text-[16px] mt-0 font-[600] text-[#3478f6]"
                >
                  Sửa
                </p>
                <button
                  class="flex items-center text-[#3478f6]"
                  @click="handleModalDelete(sanpham.id)"
                >
                  <svg
                    class="w-8 h-8 rounded-full p-1"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                    xmlns="http://www.w3.org/2000/svg"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"
                    ></path>
                  </svg>
                  Xóa sản phẩm
                </button>
              </div>
            </div>
            <div
              v-if="isShowModelCart == sanpham.id"
              class="ModalUpdateCart z-50 fixed lg:w-[512px] lg:py-[20px] px-[10px] h-[630px] bg-white top-[50%] rounded-2xl shadow-2xl left-[50%] translate-x-[-50%] translate-y-[-50%]"
            >
              <div class="float-right">
                <button @click="handleCloseModalData" class="text-[24px]">
                  <font-awesome-icon :icon="['fas', 'circle-xmark']" />
                </button>
              </div>
              <div class="px-[35px] mt-[40px]">
                <div class="flex gap-[20px]">
                  <div class="w-[72px] h-[72px] rounded-xl overflow-hidden">
                    <img
                      src="https://media.sellycdn.net/files/sm_2022_08_13_03_19_20_0700_xJPPQPefAX.jpg"
                      class="object-cover"
                      alt=""
                    />
                  </div>
                  <div>
                    <h1 class="text-[18px] uppercase text-[#384059] font-bold">
                      {{ sanpham.tenSanPham }}
                    </h1>
                    <div class="flex gap-[20px]">
                      <h2 class="text-[16px]">Màu sắc</h2>
                      <span>Trắng</span>
                    </div>
                  </div>
                </div>
                <div
                  class="mt-[20x] py-[20px] text-[16px] leading-[25px] gap-[15px] flex items-center"
                >
                  <svg
                    width="24"
                    height="24"
                    viewBox="0 0 24 24"
                    fill="none"
                    class="flex-shrink-0"
                  >
                    <path
                      d="M12 23C18.0751 23 23 18.0751 23 12C23 5.92487 18.0751 1 12 1C5.92487 1 1 5.92487 1 12C1 18.0751 5.92487 23 12 23Z"
                      stroke="currentColor"
                      stroke-width="2"
                      stroke-miterlimit="10"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                    ></path>
                    <path
                      d="M12 11V17"
                      stroke="currentColor"
                      stroke-width="2"
                      stroke-miterlimit="10"
                      stroke-linecap="round"
                      stroke-linejoin="round"
                    ></path>
                    <path
                      d="M12 8C12.5523 8 13 7.55228 13 7C13 6.44772 12.5523 6 12 6C11.4477 6 11 6.44772 11 7C11 7.55228 11.4477 8 12 8Z"
                      fill="currentColor"
                    ></path>
                  </svg>
                  <p>
                    Sản phẩm đang được khuyến mãi với nhiều ưu đãi đặc biệt quý
                    khách không nên bỏ qua nhé
                  </p>
                </div>
                <div class="flex justify-between items-center mt-[20px]">
                  <h2 class="font-bold text-[18px] text-[#384059]">Số lượng</h2>
                  <div
                    class="px-[10px] flex justify-between items-center py-[8px] rounded-xl border-coolGray-500 border-[1px]"
                  >
                    <button
                      @click="decrement(sanpham.id)"
                      class="w-[20px] h-[20px] flex items-center font-medium justify-center rounded-[50%] bg-black text-white"
                    >
                      -
                    </button>
                    <input
                      class="bg-white w-[100px] text-[16px] text-[#384059] font-bold flex pl-[40px] border-none outline-none"
                      type="number"
                      :value="soLuongUpdate"
                    />
                    <button
                      @click="increment(sanpham.id)"
                      class="w-[20px] h-[20px] flex items-center font-medium justify-center rounded-[50%] bg-black text-white"
                    >
                      +
                    </button>
                  </div>
                </div>
                <div class="flex justify-between items-center mt-[40px]">
                  <h2 class="font-bold text-[18px] text-[#384059]">Giá</h2>
                  <div
                    class="px-[10px] py-[8px] w-[165px] rounded-xl border-[1px] border-coolGray-500"
                  >
                    <p class="float-right font-medium">{{ giaBan }}</p>
                  </div>
                </div>
                <div class="flex justify-between items-center mt-[40px]">
                  <h2 class="font-bold text-[18px] text-[#384059]">Tổng giá</h2>
                  <p class="float-right text-[#23c6c8] text-[18px] font-medium">
                    {{ formatMoneyAll(getPriceUpdate()) }}
                  </p>
                </div>
                <div class="w-full mt-[40px] flex items-center justify-center">
                  <div>
                    <button
                      @click="handleUpdateNewProductCart(sanpham.id)"
                      class="w-[335px] py-[12px] rounded-xl px-[20px] flex justify-center text-[18px] items-center bg-[#cc3366] text-white font-bold"
                    >
                      Cập Nhật
                    </button>
                    <button
                      @click="handleModalDelete(sanpham.id)"
                      class="w-[335px] mt-[20px] py-[12px] rounded-xl px-[20px] flex justify-center text-[18px] items-center bg-white border-[1px] border-[#cc3366] text-[#cc3366] font-bold"
                    >
                      Xóa Sản Phẩm
                    </button>
                  </div>
                </div>
              </div>
            </div>
            <div
              v-if="isShowModalOpacity == true"
              @click="isShowModelCart = false"
              class="fixed top-0 lef-0 right-0 w-full h-full bg-black opacity-25 z-20"
            ></div>
            <div
              v-if="isshowModalDelete"
              class="ModalUpdateCart z-50 fixed overflow-hidden bg-white top-[50%] translate-x-[-50%] rounded-2xl shadow-2xl left-[50%] translate-y-[-50%]"
            >
              <div class="float-right pr-[20px] pt-[10px]">
                <button @click="handleCloseModalData" class="text-[24px]">
                  <font-awesome-icon :icon="['fas', 'circle-xmark']" />
                </button>
              </div>
              <div class="flex items-center justify-center mt-[60px]">
                <svg width="91" height="90" viewBox="0 0 91 90" fill="none">
                  <circle
                    opacity="0.1"
                    cx="45.5"
                    cy="45"
                    r="45"
                    fill="#CC3366"
                  ></circle>
                  <circle cx="45.5" cy="45" r="30" fill="#CC3366"></circle>
                  <path
                    d="M50.5549 53.603L50.2489 54.857C49.2109 55.266 45.6149 56.982 43.5409 55.156C42.9229 54.613 42.6139 53.923 42.6139 53.087C42.6139 51.52 43.1299 50.154 44.0559 46.874C44.2189 46.255 44.4189 45.45 44.4189 44.812C44.4189 43.712 44.0019 43.419 42.8689 43.419C42.3159 43.419 41.7039 43.616 41.1499 43.823L41.4569 42.569C42.6919 42.067 44.2429 41.455 45.5719 41.455C47.5649 41.455 49.0299 42.449 49.0299 44.339C49.0299 44.884 48.9359 45.838 48.7379 46.498L47.5919 50.552C47.3559 51.372 46.9259 53.178 47.5899 53.714C48.2449 54.243 49.7919 53.963 50.5549 53.603Z"
                    fill="white"
                  ></path>
                  <path
                    d="M48.5 39C49.8807 39 51 37.8807 51 36.5C51 35.1193 49.8807 34 48.5 34C47.1193 34 46 35.1193 46 36.5C46 37.8807 47.1193 39 48.5 39Z"
                    fill="white"
                  ></path>
                </svg>
              </div>
              <div
                class="flex flex-col mt-[40px] text-center justify-center px-[20px]"
              >
                <h1 class="text-[22px] font-bold">Bỏ sản phẩm</h1>
                <p class="text-[18px] font-[600]">
                  Bạn có chắc muốn bỏ sản phẩm này chứ
                </p>
              </div>
              <div class="flex w-full mt-[30px]">
                <button
                  @click="hadleReturnModelCart"
                  class="hover:bg-[#ad2b57] w-[50%] py-[18px] px-[18px] text-[18px] text-white bg-[#CC3366] border-r-[1px]"
                >
                  Không
                </button>
                <button
                  class="hover:bg-[#ad2b57] flex-1 text-[18px] text-white bg-[#CC3366] py-[18px] px-[18px]"
                  @click="handleDelete"
                >
                  Tiếp Tục
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="flex-1 bg-white mt-[20px] rounded-md px-[20px] py-[15px]">
        <div class="w-full">
          <div class="w-full flex justify-between mb-[15px]">
            <h2 class="text-[18px] font-bold">Địa chỉ</h2>
            <span class="text-blue-500 underline">Thay đổi</span>
          </div>
          <div class="mb-[10px]">
            <p>Văn Phòng 369 Chương Định , Giáp Bát , Hà Nội</p>
          </div>
        </div>
        <div>
          <div>
            <div class="mb-2 flex justify-between">
              <p class="text-gray-700">Giá bán</p>
              <p class="text-gray-700">{{ formatMoneyAll(totalPrice.sum) }}</p>
            </div>
            <div class="flex justify-between">
              <p class="text-gray-700">Giá chiết khấu</p>
              <p class="text-gray-700">
                {{ formatMoneyAll(totalPrice.chietKhau) }}
              </p>
            </div>
          </div>
          <h1 class="text-[18px] font-bold mt-[15px]">Hình thức thanh toán</h1>
          <div>
            <label class="flex items-center">
              <input
                type="radio"
                class="form-radio"
                name="payment-type"
                value="cash"
                v-model="selectedPaymentType"
              />
              <span class="ml-2">Tiền mặt</span>
            </label>
            <label class="flex items-center">
              <input
                type="radio"
                class="form-radio"
                name="payment-type"
                value="transfer"
                v-model="selectedPaymentType"
              />
              <span class="ml-2">Chuyển khoản</span>
            </label>
            <div class="flex items-center justify-end mt-3">
              <button
                class="bg-blue-500 hover:bg-blue-600 ml-3 focus:ring-offset-2 transition ease-in-out rounded text-white px-6 py-1 text-sm"
              >
                Ảnh bill chuyển khoản
              </button>
            </div>
            <div
              class="h-[50px] relative order-first md:order-last lg:h-1 md:h-auto flex justify-center items-center border border-dashed border-gray-400 col-span-2 mt-6 rounded-lg bg-no-repeat bg-center bg-origin-padding bg-cover"
            >
              <span class="text-gray-400 opacity-75">
                <svg
                  class="w-14 h-14"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 24 24"
                  stroke-width="0.7"
                  stroke="currentColor"
                >
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    d="M2.25 15.75l5.159-5.159a2.25 2.25 0 013.182 0l5.159 5.159m-1.5-1.5l1.409-1.409a2.25 2.25 0 013.182 0l2.909 2.909m-18 3.75h16.5a1.5 1.5 0 001.5-1.5V6a1.5 1.5 0 00-1.5-1.5H3.75A1.5 1.5 0 002.25 6v12a1.5 1.5 0 001.5 1.5zm10.5-11.25h.008v.008h-.008V8.25zm.375 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z"
                  />
                </svg>
              </span>
            </div>
          </div>
          <div class="flex items-center justify-center">
            <label class="label cursor-pointer mt-10">
              <input type="checkbox" checked="checked" class="checkbox" />
              <span class="label-text mr-3">&nbsp;Đồng ý điều khoản</span>
            </label>
          </div>
          <div class="flex mt-[20px] justify-between flex-col">
            <div class="flex flex-row items-center justify-between">
              <h1 class="mt-2 text-[18px] font-bold">Tổng Thanh Toán</h1>
              <p class="text-lg text-[18px] font-bold text-[#cc3366]">
                <!-- {{ totalPrice.chietKhau }} -->
                {{ formatMoneyAll(totalPrice.tongThanhToan) }}
              </p>
            </div>
            <div class="mt-5 float-right">
              <label for="my-modal" class="btn btn-outline w-full"
                >Tạo đơn</label
              >

              <!-- Put this part before </body> tag -->
              <input type="checkbox" id="my-modal" class="modal-toggle" />
              <div class="modal">
                <div class="modal-box">
                  <div class="modal-action">
                    <label
                      for="my-modal"
                      class="btn btn-sm btn-circle absolute right-2 top-2"
                      >✕</label
                    >
                  </div>
                  <h3 class="font-bold text-lg">Bạn vừa tạo đơn hàng</h3>
                  <p class="py-4">Bạn có muốn xác nhận đơn hàng chứ ?</p>
                  <div class="modal-action">
                    <label @click="checkOut" for="my-modal" class="btn"
                      >Đồng ý</label
                    >
                  </div>
                </div>
              </div>
            </div>
            <!-- <button
                @click="checkOut"
                :class="
                  selectedProducts.length > 0
                    ? 'mt-[40px] w-full py-[15px] text-white bg-[#cc3366] rounded-xl '
                    : 'mt-[40px] w-full py-[15px] text-white bg-[#9b9fac] rounded-xl '
                "
              >
                Tạo Đơn
              </button> -->
          </div>
          <!-- <div class="flex justify-between mt-[15px]">
                <p class="text-sm text-[16px] text-gray-700">
                Tiết kiệm:
              </p>
              <p> {{ totalPrice.tongThanhToan }}</p>
              </div> -->
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { getGioHang } from "~~/composables/useApiProduct";
import { useCartStorage } from "~~/stores/giohang";
import { toast } from "vue3-toastify";
// const router = useRouter();
definePageMeta({
  layout: "layout-default",
  name: "ManageCart",
});
const products = ref([]);
const datas = ref([]);
const isShowModelCart = ref("");
const selectedProducts = ref([]);
const soLuongUpdate = ref(0);
const giaBan = ref(0);
const useCart = useCartStorage();
const isshowModalDelete = ref(false);
const isShowModalOpacity = ref(false);
const idDelete = ref("");
//body call api tạo đơn hàng full

const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

const bodyData = ref({
  donHang: {
    maDonHang: "",
    ngayHoanThanh: "",
    idGStore: 0,
    idNguoiMua: 0,
    soTien: 0,
    hinhThucThanhToan: "",
  },
  chiTietDonHangFullDtos: [],
});
//biến lưu giá trị hình thức thanh toán
const selectedPaymentType = ref("cash");
const checkAll = ref(false);
watchEffect(() => {
  getSanPhamByNguoiMua()
    .then((res) => {
      products.value = res?.data?.data
    })
    .catch(() => {});
  getGioHang()
    .then((res) => (datas.value = res?.data?.data.gioHang))
    .catch(() => {});
});
//lấy số lượng theo sản phẩm
const getCartItemQuantity = (id, soLuongNew = 0) => {
  const item = datas.value.find((item) => item.idSanPham === id);
  // return item ? item.soLuong : 0;
  return soLuongNew == 0 ? item?.soLuong : soLuongNew;
};
//tăng số lượng sản phẩm trong giỏ hàng
const increment = (idsp) => {
  const gioHangsanpham = datas.value.find((s) => s.idSanPham == idsp);
  soLuongUpdate.value++;
  const body = {
    idSanPham: idsp,
    soLuong: soLuongUpdate.value,
    status: 1,
  };
  editGioHang(gioHangsanpham.id, body)
    .then((res) => console.log(res))
    .catch(() => {});
};
//giảm số lượng trong giỏ hàng
const decrement = (idsp) => {
  const gioHangsanpham = datas.value.find((s) => s.idSanPham == idsp);
  if (soLuongUpdate.value <= 1) {
    soLuongUpdate.value = 1;
  } else {
    soLuongUpdate.value--;
  }
  const body = {
    idSanPham: idsp,
    soLuong: soLuongUpdate.value,
    status: 1,
  };
  editGioHang(gioHangsanpham.id, body)
    .then((res) => console.log(res))
    .catch(() => {});
};
//lấy ra đơn giá của giỏ hàng
const getPrice = (soLuong, giaBan) => {
  return giaBan * soLuong;
};
const getPriceUpdate = () => {
  return soLuongUpdate.value * giaBan.value;
};
//logic checkbox ở đầu giỏ hàng
const checkAllGioHang = () => {
  if (checkAll.value) {
    products.value.forEach((product) => {
      if (!selectedProducts.value.includes(product.id)) {
        selectedProducts.value.push(product.id);
      }
    });
  } else {
    selectedProducts.value.splice(0, selectedProducts.value.length);
  }
};
//lấy giá bán từ id của sản phẩm
const getGiaBanTuIdSanPham = (idSanPham) => {
  const product = products.value.find((item) => item.id === idSanPham);
  return product ? product.giaBan : 0;
};
//lấy giá chiết khấu từ id sản phẩm
const getGiaChietKhauTuIdSanPham = (idSanPham) => {
  const product = products.value.find((item) => item.id === idSanPham);
  return product ? product.giaChietKhau : 0;
};
//xóa giỏ hàng khi click vào icon thùng rác
const deleteGh = (idsp) => {
  const gioHangsanpham = datas.value.find((s) => s.idSanPham == idsp);
  console.log(gioHangsanpham.id);
  deleteGioHang(gioHangsanpham.id)
    .then((res) => {
      console.log(res.data);
      getSanPhamByNguoiMua()
        .then((res) => (products.value = res?.data?.data))
        .catch(() => {});
      getGioHang()
        .then((res) => (datas.value = res?.data?.data.gioHang))
        .catch(() => {});
    })
    .catch(() => {});
};
//lấy ra tổng tiền thanh toán đơn hàng
const totalPrice = computed(() => {
  let sum = 0;
  let chietKhau = 0;
  let tongThanhToan = 0;
  datas.value.forEach((item) => {
    if (selectedProducts.value.includes(item.idSanPham)) {
      let giaBan = getGiaBanTuIdSanPham(item.idSanPham);
      let giaChietKhau = getGiaChietKhauTuIdSanPham(item.idSanPham);
      sum += getPrice(item.soLuong, giaBan);
      chietKhau += getPrice(item.soLuong, giaChietKhau);
      tongThanhToan = sum - chietKhau;
    }
  });
  return { sum, chietKhau, tongThanhToan };
});
// format tiền
const formatMoney = (soLuong, giaBan) => {
  console.log(products.value);
  return getPrice(soLuong, giaBan).toLocaleString("vi-VN", {
    style: "currency",
    currency: "VND",
  });
};
const formatMoneyAll = (money) => {
  money = Number(money);
  return money.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
};
const removeDuplicates = (arr) => {
  let uniqueArr = arr.filter((item, index) => arr.indexOf(item) === index);
  return uniqueArr;
};
//Lấy id gstore

//tạo đơn hàng
const checkOut = () => {
  var arrGstore = [];
  //lấy ra idgstore
  selectedProducts.value.map((idSp) => {
    var chiTiet = products.value.find((p) => p.id == idSp);
    arrGstore.push(chiTiet.idGStore);
  });
  console.log(selectedProducts.value);
  console.log(arrGstore);
  //tạo chi tiet don hang
  const uniqueGstores = [...new Set(arrGstore)];
  uniqueGstores.forEach((idGStore) => {
    const filterdProducts = selectedProducts.value.filter((idsp) => {
      const product = products.value.find((p) => p.id == idsp);
      return product.idGStore == idGStore;
    });
    // create chi tiet don hang for products with matching idGStore
    // create chi tiet don hang for products with matching idGStore
    const chiTietDonHangFullDtos = filterdProducts.map((idSp) => {
      const chiTiet = products.value.find((p) => p.id == idSp);
      return {
        idSanPham: chiTiet.id,
        soLuong: getCartItemQuantity(idSp),
      };
    });
    // create full don hang object
    const sendBody = {
      donHang: {
        maDonHang: `md${Math.floor(Math.random() * 10) + 1}`,
        ngayHoanThanh: new Date(),
        idGStore: idGStore,
        soTien: totalPrice.value.chietKhau,
        hinhThucThanhToan: selectedPaymentType.value,
      },
      chiTietDonHangFullDtos: chiTietDonHangFullDtos,
    };
    console.log(sendBody);
    createFullDonHang(sendBody)
      .then((res) => {
        toast.success("Tạo đơn hàng thành công");
        console.log(res);
      })
      .catch(() => {});
  });
};
const handleUpdateProduct = (id, soLuong, giaBanModal) => {
  isShowModelCart.value = id;
  isShowModalOpacity.value = true;
  soLuongUpdate.value = soLuong;
  giaBan.value = giaBanModal;
  console.log(giaBan.value);
};
const handleUpdateNewProductCart = (id) => {
  console.log(id);
  const item = datas.value.find((item) => item.idSanPham === id);
  isShowModalOpacity.value = false;
  item.soLuong = soLuongUpdate.value;
  isShowModelCart.value = "";
  getPrice(getCartItemQuantity(id, item.soLuong), giaBan.value);
};
const handleModalDelete = (id) => {
  idDelete.value = id;
  isShowModelCart.value = "";
  isshowModalDelete.value = true;
  isShowModalOpacity.value = true;
};
const handleCloseModalData = () => {
  isshowModalDelete.value = false;
  isShowModalOpacity.value = false;
  isShowModelCart.value = "";
};
const hadleReturnModelCart = () => {
  isShowModalOpacity.value = false;
  isshowModalDelete.value = false;
};
const handleDelete = () => {
  isShowModalOpacity.value = false;
  isshowModalDelete.value = false;
  const gioHangsanpham = datas.value.find((s) => s.idSanPham == idDelete.value);
  console.log(gioHangsanpham.id);
  deleteGioHang(gioHangsanpham.id)
    .then((res) => {
      console.log(res.data);
      useCart.removeItembyID(gioHangsanpham.id);
      getSanPhamByNguoiMua()
        .then((res) => (products.value = res?.data?.data))
        .catch(() => {});
      getGioHang()
        .then((res) => (datas.value = res?.data?.data.gioHang))
        .catch(() => {});
    })
    .catch(() => {});
};
</script>
<style lang="css">
input[type="number"]::-webkit-inner-spin-button,
input[type="number"]::-webkit-outer-spin-button {
  -webkit-appearance: none;
  margin: 0;
}
input[type="number"] {
  -moz-appearance: textfield;
}
.ModalUpdateCart {
  animation: FadeIn ease-in-out 0.3s;
}
@keyframes FadeIn {
  from {
    opacity: 0;
  }
  to {
    opacity: 1;
  }
}
</style>
