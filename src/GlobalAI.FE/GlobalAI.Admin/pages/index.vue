<template>
  <div>
    <index-navbar />
    <section
      class="header relative pt-16 items-center flex h-screen max-h-860-px"
    >
      <div class="container mx-auto items-center flex flex-wrap">
        <div class="w-full md:w-8/12 lg:w-6/12 xl:w-6/12 px-4">
          <div class="pt-32 sm:pt-0">
            <h2 class="font-semibold text-4xl text-slate-600">
              Global AI - Sàn thương mại điện tử.
            </h2>
            <p class="mt-4 text-lg leading-relaxed text-slate-500">
              Sàn thương mại điện tử Global AI là một nền tảng trực tuyến kết
              nối các nhà cung cấp và các nhà phân phối với nhau, cho phép các
              nhà cung cấp và các nhà phân phối mua bán hàng hóa và dịch vụ với
              số lượng lớn và giá chiết khấu cao. 
            </p>
            <div class="mt-12" v-if="!isLoggedIn">
              <nuxt-link
                to="/auth/registermaster"
                class="github-star ml-1 text-white font-bold px-6 py-4 rounded outline-none focus:outline-none mr-1 mb-1 bg-slate-700 active:bg-slate-600 uppercase text-sm shadow hover:shadow-lg ease-linear transition-all duration-150"
              >
                Đăng ký
              </nuxt-link>
              <nuxt-link
                to="/auth/login"
                class="get-started text-white font-bold px-6 py-4 rounded outline-none focus:outline-none mr-1 mb-1 bg-emerald-500 active:bg-emerald-600 uppercase text-sm shadow hover:shadow-lg ease-linear transition-all duration-150"
              >
                Đăng nhập
              </nuxt-link>
            </div>
            <div v-else>
            <div class="py-10 flex flex-row justify-center w-full">
              <nuxt-link
                to="/gsaler/firstpage"
                class="get-started text-white font-bold px-6 py-4 rounded outline-none focus:outline-none mr-1 mb-1 bg-[#3192cd] hover:bg-emerald-600 uppercase text-sm shadow hover:shadow-lg ease-linear transition-all duration-150"
              >
               Xem Thêm >>>
              </nuxt-link>
            </div>
          </div>
          </div>
        </div>
      </div>

      <img
        class="absolute top-0 b-auto right-0 pt-16 sm:w-6/12 -mt-48 sm:mt-0 w-10/12 max-h-860-px"
        :src="patternVue"
        alt="..."
      />
    </section>
    <!-- tại sao chọn -->
    <section class="pb-20 relative block bg-slate-800">
      <div
        class="bottom-auto top-0 left-0 right-0 w-full absolute pointer-events-none overflow-hidden -mt-20 h-20"
        style="transform: translateZ(0)"
      >
        <svg
          class="absolute bottom-0 overflow-hidden"
          xmlns="http://www.w3.org/2000/svg"
          preserveAspectRatio="none"
          version="1.1"
          viewBox="0 0 2560 100"
          x="0"
          y="0"
        >
          <polygon
            class="text-slate-800 fill-current"
            points="2560 0 2560 100 0 100"
          ></polygon>
        </svg>
      </div>

      <div class="container mx-auto px-4 lg:pt-24 lg:pb-20 bg-state-800">
        <div class="flex flex-wrap text-center justify-center">
          <div class="w-full lg:w-6/12 px-4">
            <h2
              class="max-[768px]:text-4xl md:text-5xl font-semibold text-white"
            >
              Tại sao chọn Global-AI
            </h2>
            <p class="text-lg leading-relaxed mt-4 mb-4 text-slate-400">
              Sàn thương mại điện tử Global AI giúp tăng tính chuyên nghiệp và
              uy tín của nhà cung cấp, giúp nhà phân phối cảm thấy tin tưởng khi
              giao dịch trực tuyến.
            </p>
          </div>
        </div>
        <div class="flex flex-wrap mt-12 justify-center">
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class="hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center"
            >
              <img :src="imgUyTin" />
            </div>
            <h6 class="text-xl mt-5 font-semibold text-white">Uy tín</h6>
            <p class="mt-2 mb-4 text-slate-400">
              Nhiều thương hiệu lớn tin chọn
            </p>
          </div>
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class="hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center"
            >
              <img :src="imgMoRongThiTruong" />
            </div>
            <h6 class="text-xl mt-5 font-semibold text-white">
              Mở rộng thị trường
            </h6>
            <p class="mt-2 mb-4 text-slate-400">
              Tăng doanh số bán hàng, tạo ra nhiều cơ hội kinh doanh mới
            </p>
          </div>
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class="hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center"
            >
              <img :src="imgChiPhiThap" />
            </div>
            <h6 class="text-xl mt-5 font-semibold text-white">Chi phí thấp</h6>
            <p class="mt-2 mb-4 text-slate-400">
              Tiết kiệm chi phí khởi nghiệp và chi phí vận hành
            </p>
          </div>
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class="hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center"
            >
              <img :src="imgDeDangQuanLy" />
            </div>
            <h6 class="text-xl mt-5 font-semibold text-white">
              Dễ dàng quản lý
            </h6>
            <p class="mt-2 mb-4 text-slate-400">
              Quản lý sản phẩm, đơn hàng và thanh toán dễ dàng và thuận tiện
            </p>
          </div>
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class="hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center"
            >
              <img :src="imgTangTinhCanhTranh" />
            </div>
            <h5 class="text-xl mt-5 font-semibold text-white">
              Tăng tính cạnh tranh
            </h5>
            <p class="mt-2 mb-4 text-slate-400">
              Cung cấp sản phẩm với giá cả cạnh tranh
            </p>
          </div>
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class="hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center"
            >
              <img :src="imgTietKiem" />
            </div>
            <h5 class="text-xl mt-5 font-semibold text-white">Tiết kiệm</h5>
            <p class="mt-2 mb-4 text-slate-400">
              Tối ưu hoá thời gian tìm kiếm khách hàng
            </p>
          </div>
        </div>
      </div>
    </section>
    <section>
      <section>
        <div
          class="container mx-auto px-4 lg:pt-24 bg-state-800 flex flex-wrap"
        >
          <div class="lg:w-6/12 px-4 py-2.5 float-right">
            <nuxt-link to="/gsaler/home">
              <img class="mx-auto" :src="imgShopping" alt="free shoping" />
            </nuxt-link>
          </div>
          <div class="w-full lg:w-6/12 px-4 py-2.5 flex flex-col">
            <h2 class="sm:text-4xl lg:text-6xl font-bold my-4">
              Global AI mang lại những gì cho người dùng?
            </h2>
            <p class="font-medium my-2">
              <span></span>
              Cung cấp cho người dùng các thông tin về nhà cung cấp và các sản
              phẩm, giúp họ đánh giá tính đáng tin cậy của nhà cung cấp và sản
              phẩm trước khi quyết định mua hàng.
            </p>
            <p class="font-medium my-2">
              Giúp các nhà cung cấp mở rộng thị trường bán hàng và tìm kiếm
              khách hàng mới trên khắp mọi nơi.
            </p>
            <div class="py-10 flex flex-row justify-center w-full">
              <nuxt-link
                to="/gsaler/home"
                class="get-started text-white font-bold px-6 py-4 rounded outline-none focus:outline-none mr-1 mb-1 bg-[#3192cd] hover:bg-emerald-600 uppercase text-sm shadow hover:shadow-lg ease-linear transition-all duration-150"
              >
                Đi đến trang mua bán >>>
              </nuxt-link>
            </div>
          </div>
        </div>
      </section>
    </section>
    <!-- Blog -->
    <section>
      <div class="bg-slate-100 py-24 sm:py-14">
        <div class="mx-auto max-w-7xl px-6 lg:px-8">
          <div class="mx-auto max-w-2xl lg:mx-0">
            <a href="/post/postdanhmuc/1">
              <h2
                class="text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl"
              >
                Blog
              </h2>
            </a>
            <p class="mt-2 text-lg leading-8 text-gray-600">
              Làm thế nào để kinh doanh hiệu quả?
            </p>
          </div>
          <div
            class="mx-auto mt-5 grid max-w-2xl grid-cols-1 gap-y-16 gap-x-8 border-t border-gray-200 pt-10 sm:pt-16 lg:mx-0 lg:max-w-none lg:grid-cols-3"
          >
            <article
              v-for="(item, index) in baitin"
              :key="index"
              class="flex max-w-xl flex-col items-start justify-between"
            >
              <div class="flex items-center gap-x-4 text-xs">
                <time datetime="2020-03-16" class="text-gray-500"
                  >Mar 16, 2023</time
                >
                <a
                  href="#"
                  class="relative z-10 rounded-full bg-gray-50 py-1.5 px-3 font-medium text-gray-600 hover:bg-gray-100"
                  >Marketing</a
                >
              </div>
              <div class="group relative">
                <h3
                  class="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600"
                >
                  <a :href="`/post/postdetail/${item.slug}`">
                    <span class="absolute inset-0"></span>
                    {{ item.tieuDe }}
                  </a>
                </h3>
                <p class="mt-5 text-sm leading-6 text-gray-600 line-clamp-3">
                  {{ item.moTa }}
                </p>
              </div>
              <div class="relative mt-8 flex items-center gap-x-4">
                <img
                  :src="adminMale"
                  alt=""
                  class="h-10 w-10 rounded-full bg-gray-50"
                />
                <div class="text-sm leading-6">
                  <p class="font-semibold text-gray-900">
                    <a href="#">
                      <span class="absolute inset-0"></span>
                      Admin
                    </a>
                  </p>
                  <p class="text-gray-600">Creator</p>
                </div>
              </div>
            </article>

            <!-- More posts... -->
          </div>
        </div>
      </div>
    </section>
    <!-- Lĩnh vực nổi bật -->
    <section class="mb-32">
      <div class="justify-center text-center flex flex-wrap mt-24">
        <div class="w-full md:w-6/12 px-12 md:px-4">
          <h2 class="font-semibold text-4xl">Lĩnh vực nổi bật</h2>
        </div>
      </div>
    </section>

    <!-- Thêm click vào đây -->
    <section class="block relative z-1 bg-slate-600">
      <div class="container mx-auto">
        <div class="justify-center flex flex-wrap">
          <div class="w-full lg:w-12/12 px-4 -mt-24">
            <div class="flex flex-wrap">
              <div
                v-for="(item, index) in danhmucbaitin"
                class="w-full lg:w-4/12 px-4"
                :key="index"
              >
                <nuxt-link :to="`/post/postdanhmuc/${item.id}`">
                  <h5 class="text-xl font-semibold pb-4 text-center">
                    {{ item.tenDanhMuc }}
                  </h5>
                  <div
                    class="hover:-mt-4 relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-lg rounded-lg ease-linear transition-all duration-150"
                  >
                    <img
                      alt="..."
                      class="align-middle border-none max-w-full h-[320px] shadow-md rounded-lg w-full"
                      :src="`${baseUrl}/${item.thumbnail}`"
                    />
                  </div>
                </nuxt-link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <!-- Đối tác  -->
    <section>
      <div class="bg-white py-24 sm:py-28">
        <div class="mx-auto max-w-7xl px-6 lg:px-8">
          <h2 class="text-center text-lg font-bold leading-8 text-gray-900">
            ĐƯỢC SỰ TIN TƯỞNG CỦA CÁC DOANH NGHIỆP
          </h2>
          <div
            class="mx-auto mt-10 grid max-w-lg grid-cols-4 items-center gap-x-8 gap-y-10 sm:max-w-xl sm:grid-cols-6 sm:gap-x-10 lg:mx-0 lg:max-w-none lg:grid-cols-5"
          >
            <img
              class="col-span-2 max-h-12 w-full object-contain lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/transistor-logo-gray-900.svg"
              alt="Transistor"
              width="158"
              height="48"
            />
            <img
              class="col-span-2 max-h-12 w-full object-contain lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/reform-logo-gray-900.svg"
              alt="Reform"
              width="158"
              height="48"
            />
            <img
              class="col-span-2 max-h-12 w-full object-contain lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/tuple-logo-gray-900.svg"
              alt="Tuple"
              width="158"
              height="48"
            />
            <img
              class="col-span-2 max-h-12 w-full object-contain sm:col-start-2 lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/savvycal-logo-gray-900.svg"
              alt="SavvyCal"
              width="158"
              height="48"
            />
            <img
              class="col-span-2 col-start-2 max-h-12 w-full object-contain sm:col-start-auto lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/statamic-logo-gray-900.svg"
              alt="Statamic"
              width="158"
              height="48"
            />
          </div>
        </div>
      </div>
    </section>
    <footer-component />
  </div>
</template>
<style>
.bg-custom-1 {
  background-color: #f2f1f2;
}
</style>
<script setup>
import IndexNavbar from "../components/Navbars/IndexNavbar.vue";
import FooterComponent from "../components/Footers/Footer.vue";
import patternVue from "../assets/img/Home/san-thuong-mai-dien-tu.png";
import adminMale from "../assets/icons8-administrator-male-40.png";
import imgUyTin from "../assets/img/Home/uy-tin.png";
import imgChiPhiThap from "../assets/img/Home/chi-phi-thap.png";
import imgDeDangQuanLy from "../assets/img/Home/de-dang-quan-ly.png";
import imgTangTinhCanhTranh from "../assets/img/Home/tang-tinh-canh-tranh.png";
import imgTietKiem from "../assets/img/Home/tiet-kiem.png";
import imgMoRongThiTruong from "../assets/img/Home/mo-rong-thi-truong.png";
import imgShopping from "../assets/img/Home/dang-nhap-san-thuong-mai-dien-tu.png";
import { useUserStorage } from "~~/stores/user";

const config = useRuntimeConfig();
const userStorage = useUserStorage();
const baseUrl = config.public.apiEndpoint;

const baitin = ref([]);
const danhmucbaitin = ref([]);
const pageSize = 3;
const pageNumber = 1;
const skip = 0;

const isLoggedIn = computed(() => userStorage.isLoggedIn);

onMounted(() => {
  getBaiTinPhanTrang(pageSize, pageNumber, skip)
    .then((response) => {
      baitin.value = response.data.items;
    })
    .catch((err) => {
      console.error(err);
    });

  getDanhBaiTinMucNoiBat()
    .then((response) => {
      danhmucbaitin.value = response.data.items.reverse();
    })
    .catch((err) => {
      console.error(err);
    });
});
</script>
