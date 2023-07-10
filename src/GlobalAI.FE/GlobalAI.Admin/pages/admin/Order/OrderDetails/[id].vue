<template>
  <div
    class="relative flex py-5 flex-col min-w-0 break-words w-full mb-6 shadow-lg rounded bg-white"
  >
    <div class="w-[95%] m-auto">
      <div class="rounded-t mb-0 py-3 border-0">
        <div class="flex flex-wrap items-center">
          <div class="relative w-full max-w-full flex-grow flex-1">
            <div class="flex justify-between">
              <h3
                class="py-1 text-base font-medium border-b uppercase"
                :class="[
                  color === 'light' ? 'text-blueGray-700' : 'text-white',
                ]"
              >
                Quản lý đơn hàng
              </h3>
              <div
                class="py-1 text-base font-medium uppercase"
                :class="[
                  color === 'light' ? 'text-blueGray-700' : 'text-white',
                ]"
              >
                <button
                  v-if="isStatus == 1"
                  @click="ConfirmOrder"
                  class="btn btn-outline"
                >
                  Xác Nhận Đơn Hàng
                </button>
                <button
                  v-if="isStatus == 2"
                  class="btn btn-success"
                  @click="
                    toast.success('Đơn hàng đã được chuyển giao vận chuyển')
                  "
                >
                  Hoàn Thành
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="block w-full overflow-x-auto">
        <!-- Projects table -->
        <div class="items-center w-full bg-transparent border-collapse">
          <div class="flex justify-between gap-3">
            <div
              class="w-1/3 border flex flex-col shadow-md bg-[#F8FAFC] rounded"
            >
              <span
                class="p-2 block py-1 text-sm font-medium border-b uppercase"
                >Thông tin đơn hàng</span
              >
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Mã</span>
                <p>AWS</p>
              </div>
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Ngày tạo</span>
                <p>16/06/2002</p>
              </div>
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Trạng thái đơn hàng</span>
                <p class="text-blue-400">Đang xử lý</p>
              </div>
            </div>
            <div
              class="w-1/3 border flex flex-col shadow-md bg-[#F8FAFC] rounded"
            >
              <span
                class="p-2 block py-1 text-sm font-medium border-b uppercase"
                >Thanh toán</span
              >
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Thanh toán chuyển khoản</span>
                <p>...</p>
              </div>
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Trạng thái thanh toán</span>
                <p class="text-blue-400">Chưa thanh toán</p>
              </div>
            </div>
            <div
              class="w-1/3 border flex flex-col shadow-md bg-[#F8FAFC] rounded"
            >
              <span
                class="p-2 block py-1 text-sm font-medium border-b uppercase"
                >Giao hàng</span
              >
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Hình thức lấy hàng</span>
                <p>Nhận hàng tại cửa hàng</p>
              </div>
              <div class="flex justify-between px-2 py-1 text-sm font-medium">
                <span>Trạng thái giao hàng</span>
                <p class="text-orange-400">Chưa giao hàng</p>
              </div>
            </div>
          </div>
          <div class="flex gap-10 mt-10">
            <div class="w-4/5 flex flex-col">
              <div>
                <div>
                  <span class="p-2 text-base font-medium border-b block"
                    >Thông tin đơn hàng</span
                  >
                  <hr class="m-auto" />
                  <table
                    class="items-center w-full bg-transparent border-collapse mt-4"
                  >
                    <thead>
                      <tr>
                        <th
                          class="px-6 py-3 text-xs font-semibold text-left uppercase whitespace-nowrap align-middle border-b border-gray-200"
                        >
                          Ảnh
                        </th>
                        <th
                          class="px-6 py-3 text-xs font-semibold text-left uppercase whitespace-nowrap align-middle border-b border-gray-200"
                        >
                          Tên sản phẩm
                        </th>
                        <th
                          class="px-6 py-3 text-xs font-semibold text-left uppercase whitespace-nowrap align-middle border-b border-gray-200"
                        >
                          Số lượng
                        </th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr
                        v-for="(item, index) in InforOrder"
                        :key="index"
                        class="hover:bg-gray-100 border-b cursor-pointer"
                      >
                        <td
                          class="px-6 py-4 align-middle border-t border-gray-200 border-l-0 border-r-0 text-xs"
                        >
                          <div class="avatar">
                            <div
                              class="w-10 rounded-full ring ring-primary ring-offset-base-100 ring-offset-2"
                            >
                              <img :src="getImageUrl(item.sanPham.thumbnail)" />
                            </div>
                          </div>
                        </td>
                        <td
                          class="px-6 py-4 align-middle border-t border-gray-200 border-l-0 border-r-0 text-xs"
                        >
                          {{ item.sanPham.tenSanPham }}
                        </td>
                        <td
                          class="px-6 py-4 align-middle border-t border-gray-200 border-l-0 border-r-0 text-xs"
                        >
                          {{ item.soLuong }}
                        </td>
                      </tr>
                    </tbody>
                  </table>
                  <div class="flex flex-col float-right w-full mt-10">
                    <div class="w-1/2 ml-auto">
                      <div class="flex justify-between gap-20 py-1">
                        <span class="px-12 text-sm uppercase font-normal"
                          >Tổng tiền hàng</span
                        >
                        <p class="text-sm">{{ priceOrder }}</p>
                      </div>
                      <div class="flex justify-between gap-20 py-1">
                        <span class="px-12 text-sm uppercase font-normal"
                          >Phí vận chuyển</span
                        >
                        <p class="text-sm">0đ</p>
                      </div>
                      <div class="flex justify-between gap-20 py-1">
                        <span class="px-12 text-sm uppercase font-normal"
                          >Giảm giá</span
                        >
                        <p class="text-sm">0đ</p>
                      </div>
                      <div class="flex justify-between gap-20 py-1">
                        <span class="px-12 text-sm uppercase font-normal"
                          >VAT(0%)</span
                        >
                        <p class="text-sm">0đ</p>
                      </div>
                      <div class="flex justify-between gap-20 py-1">
                        <span class="px-12 text-sm uppercase font-normal"
                          >Sử dụng tiền thưởng</span
                        >
                        <p class="text-sm">0đ</p>
                      </div>
                      <div class="flex justify-between gap-20 py-1">
                        <span class="px-12 text-sm uppercase font-normal"
                          >Thanh toán khi giao hàng(COD)</span
                        >
                        <p class="text-sm">0đ</p>
                      </div>
                      <div class="flex justify-between gap-20 py-1">
                        <span class="px-12 text-sm uppercase font-normal"
                          >Tổng giá trị đơn hàng</span
                        >
                        <p class="text-sm">{{ priceOrder }}</p>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="w-full mt-auto">
                <span class="block py-2 px-4 text-base font-medium border-b"
                  >Trả lời nhanh</span
                >
                <hr class="my-0" />
                <div class="flex px-4 gap-5 py-2 mt-5">
                  <input
                    type="text"
                    class="w-[86%] border border-gray-300 py-2 px-4 rounded"
                    placeholder="Nội dung"
                  />
                  <button
                    class="bg-blue-500 w-[14%] hover:bg-blue-600 text-white py-2 px-4 rounded"
                  >
                    Trả lời
                  </button>
                </div>
              </div>
            </div>
            <div class="w-1/5 flex flex-col gap-8">
              <div
                class="w-full border p-5 flex flex-col gap-2 bg-[#F8FAFC] rounded shadow-md"
              >
                <h3 class="py-1 text-sm font-medium border-b uppercase">
                  Kho xuất hàng
                </h3>
                <select class="outline-none border w-full">
                  <option value="">Hà Nội</option>
                  <option value="">Hà Nam</option>
                  <option value="">Hồ Chí Minh</option>
                  <option value="">Hưng Yên</option>
                  <option value="">Hải Phòng</option>
                </select>
              </div>

              <div
                class="w-full border p-5 flex flex-col gap-2 bg-[#F8FAFC] rounded shadow-md"
              >
                <h3 class="py-1 text-sm font-medium border-b uppercase">
                  Địa chỉ lấy hàng
                </h3>
                <span class="text-sm">
                  <p>Cửa hàng: 196 Nguyễn Đình Chiểu</p>
                  <p>
                    Địa chỉ: 196 Nguyễn Đình Chiểu, Phường Võ Thị Sáu, Quận 3,
                    Hồ Chí Minh
                  </p>
                </span>
              </div>

              <div
                class="w-full border p-5 flex flex-col gap-2 bg-[#F8FAFC] rounded shadow-md"
              >
                <h3 class="py-1 text-sm font-medium border-b uppercase">
                  Ghi chú đơn hàng
                </h3>
                <textarea
                  class="outline-none border"
                  name=""
                  id=""
                  cols="30"
                  rows="5"
                ></textarea>
                <button
                  class="mt-3 px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
                >
                  Cập nhật
                </button>
              </div>

              <div
                class="w-full border p-5 flex flex-col gap-2 bg-[#F8FAFC] rounded shadow-md"
              >
                <h3 class="py-1 text-sm font-medium border-b uppercase">
                  Thông tin người mua
                </h3>
                <span class="text-sm">
                  <p>Họ và tên: Thiều Trần Cương</p>
                  <p>Số điện thoại: 0329834563</p>
                </span>
              </div>

              <div
                class="w-full border p-5 flex flex-col gap-2 bg-[#F8FAFC] rounded"
              >
                <h3 class="py-1 text-sm font-medium border-b uppercase">
                  Thông tin giao hàng
                </h3>
                <p class="text-sm">
                  Số nhà – Tên Hẻm (Nếu có) – Tên đường – Tên phường (xã) – Tên
                  quận (huyện) – Tên thành phố (thị xã) – Tên Tỉnh (thành phố
                  trực thuộc TW)
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
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
import { toast } from "vue3-toastify";
const router = useRouter();
const priceOrder = ref();
const InforOrder = ref([]);
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
definePageMeta({
  layout: "admin",
  name: "orderdetails",
});
const isStatus = ref(1);

onMounted(() => {
  console.log(router.currentRoute.value.params.id);
});
watchEffect(() => {
  getDetailOrderByCodeOrders(router.currentRoute.value.params.id)
    .then((res) => {
      priceOrder.value = res.data.donHang.soTien;
      res.data.chiTietDonHangFullDtos.forEach((item) => {
        getSanPhamById(item.idSanPham).then((res) => {
          const singleData = {
            sanPham: res.data.data,
            soLuong: item.soLuong,
          };
          console.log(singleData);
          InforOrder.value.push(singleData);
        });
      });
    })
    .catch((err) => console.log(err));
});
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};

const ConfirmOrder = () => {
  toast.success("Đơn hàng đã được xác nhận");
  isStatus.value = 2;
};

const postOrderId = ref(0);
const maDonHang = ref("");
const ngayHoanThanh = ref("");
const idGStore = ref(0);
const idNguoiMua = ref(0);
const soTien = ref(0);
const hinhThucThanhToan = ref("");
const diaChi = ref("");

onMounted(() => {
  postOrderId.value = router.currentRoute.value.params.id;
  watchEffect(async () => {
    try {
      const data = await getOrderById(postOrderId.value);
      maDonHang.value = data.data.maDonHang;
      ngayHoanThanh.value = data.data.ngayHoanThanh;
      idGStore.value = data.data.idGStore;
      idNguoiMua.value = data.data.idNguoiMua;
      soTien.value = data.data.soTien;
      hinhThucThanhToan.value = data.data.hinhThucThanhToan;
      diaChi.value = data.data.diaChi;
    } catch (error) {
      console.log(error);
    }
  });
});
</script>
