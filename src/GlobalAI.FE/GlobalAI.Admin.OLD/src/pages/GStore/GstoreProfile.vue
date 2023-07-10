<template>
  <div class="bg-gray-100">

      <section class="text-gray-600 body-font">
        <div class="container mt-10">
          <h1 class="text-black text-2xl title-font font-bold mb-2">Nhà cung cấp</h1>
          <div
            class="p-5 bg-white flex items-center mx-auto border-b mb-3 border-gray-200 rounded-lg sm:flex-row flex-col">

            <div class="sm:w-32 sm:h-32 h-20 w-20 sm:mr-10 inline-flex items-center justify-center flex-shrink-0">
              <img
                src="https://firebasestorage.googleapis.com/v0/b/thecaffeinecode.appspot.com/o/Tcc_img%2Flogo.png?alt=media&token=5e5738c4-8ffd-44f9-b47a-57d07e0b7939" />
            </div>
            <div class="flex-grow sm:text-left text-center mt-6 sm:mt-0">
              <h1 class="text-black text-2xl title-font font-bold mb-2">Supplier Global</h1>

              <div class="mb-2 mt-2">

                <div class="mt-2 flex items-center">
                  <h2 class="text-gray-500 w-12">SĐT</h2>
                  <h1 class="text-base text-gray-900 ml-5 font-semibold">90998765432</h1>
                </div>
                <div class="mt-2 flex items-center">
                  <h2 class="text-gray-500 w-12">Email</h2>
                  <h1 class="text-base text-gray-900 ml-5 font-semibold">global.ai@yahoo.com</h1>
                </div>
                <div class="mt-2 flex items-center">
                  <h2 class="text-gray-500 w-12">Website</h2>
                  <h1 class="text-base text-gray-900 ml-5 font-semibold">global.ai.com</h1>
                </div>
                <div class="mt-2 flex items-center">
                  <h2 class="text-gray-500 w-12">Địa chỉ</h2>
                  <h1 class="text-base text-gray-900 ml-5 font-semibold">Ha Noi, Viet Nam</h1>
                </div>
              </div>
              <!-- <a class="mt-3 text-indigo-500 inline-flex items-center">Learn More
                            <svg fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" class="w-4 h-4 ml-2" viewBox="0 0 24 24">
                                <path d="M5 12h14M12 5l7 7-7 7"></path>
                            </svg>
                            </a> -->
            </div>
          </div>
        </div>
      </section>

  </div>

  <div class="flex-grow">
    <h2 class="title-font mb-1 text-xl text-md font-medium tracking-wider text-gray-900">Giới thiệu</h2>
    <p class="font-laonoto leading-relaxed">
      Đối với bất kỳ doanh nghiệp nào, cung cấp nguồn nguyên vật liệu hay dịch vụ đóng vai trò vô cùng quan trọng trong
      các hoạt động kinh doanh
    </p>
  </div>
  <section class="bg-gray-100">
    <card-list-product-short title="Sản phẩm" :products="products1"/>
  </section>
  <nav  aria-label="Page navigation" class="flex items-center justify-center">
    <ul class="inline-flex space-x-2">
      <li><button
          class="flex items-center justify-center w-10 h-10 text-indigo-600 transition-colors duration-150 rounded-full focus:shadow-outline hover:bg-indigo-100">
          <svg class="w-4 h-4 fill-current" viewBox="0 0 20 20">
            <path
              d="M12.707 5.293a1 1 0 010 1.414L9.414 10l3.293 3.293a1 1 0 01-1.414 1.414l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 0z"
              clip-rule="evenodd" fill-rule="evenodd"></path>
          </svg></button>
      </li>
      <li><button
          class="w-10 h-10 text-white transition-colors duration-150 bg-indigo-600 border border-r-0 border-indigo-600 rounded-full focus:shadow-outline">1</button>
      </li>
      <li><button
          class="w-10 h-10 text-indigo-600 transition-colors duration-150 rounded-full focus:shadow-outline hover:bg-indigo-100">2</button>
      </li>
      <li><button
          class="w-10 h-10 text-indigo-600 transition-colors duration-150 rounded-full focus:shadow-outline hover:bg-indigo-100">3</button>
      </li>
      <li><button
          class="flex items-center justify-center w-10 h-10 text-indigo-600 transition-colors duration-150 bg-white rounded-full focus:shadow-outline hover:bg-indigo-100">
          <svg class="w-4 h-4 fill-current" viewBox="0 0 20 20">
            <path
              d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z"
              clip-rule="evenodd" fill-rule="evenodd"></path>
          </svg></button>
      </li>
    </ul>
  </nav>
</template>
    
<script>
export default {
  name: "ProductSupplier",
  props: {
    productId: {
      type: Number,
      required: true
    }
  },
  data() {
    return {
      openTab: 1,
      more: false,
    }
  },
  methods: {
    toggleTabs: function (tabNumber) {
      this.openTab = tabNumber
    },

    seeMore: function (event) {
      this.more = event;
    },

  }
}
</script>
    

<script setup>
import CardListProductShort from '../../components/Cards/CardListProductShort.vue';
// import { defineAsyncComponent } from 'vue';
// const CardListProductShort = defineAsyncComponent('../../components/Cards/CardListProductShort.vue');
const products1 = [{
    name: "Viên uống bổ sung vitamin C DHC",
    imgUrl: "../../src/assets/img/product/2a058125fdc92cb24ca382fa36107f1d.jpg",
    price: "170,000",
    discount: "150,000"
},
{
    name: "Kính râm phân cực Kateluo",
    imgUrl: "../../src/assets/img/product/8c37010c4421b7eed56fc3b5e6fbf414.jpg",
    price: "340,000",
    discount: "300,000"
},
{
    name: "Camera ip wifi Ezviz",
    imgUrl: "../../src/assets/img/product/53ef4c442bd8470b27ab983133775eea.jpg",
    price: "1,689,000",
    discount: "1,400,000"
},
{
    name: "Nồi inox cao cấp 3 lớp đáy",
    imgUrl: "../../src/assets/img/product/a10cacd0a2ec3dd59e1b679b31373256.jpg",
    price: "645,000",
    discount: "600,000"
},
{
    name: "Son kem lì 3CE Cloud lip tint",
    imgUrl: "../../src/assets/img/product/mypham.jpg",
    price: "363,000",
    discount: "350,000"
},
{
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: "../../src/assets/img/product/sg-11134201-22120-6odt1fg9y6kve2.jpg",
    price: "219,000",
    discount: "250,000"
},
{
    name: "Áo khoác Paradox",
    imgUrl: "../../src/assets/img/product/sg-11134201-22120-75lyidugp7kv06.jpg",
    price: "379,000",
    discount: "320,000"
},
{
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: "../../src/assets/img/product/vn-11134201-23020-tjtl9dace3nv28.jpg",
    price: "289,000",
    discount: "250,000"
},
{
    name: "Giày chạy bộ Supernova Adidas",
    imgUrl: "../../src/assets/img/product/sg-11134201-22120-un5b5kp9xskvd0.jpg",
    price: "2,400,000",
    discount: "2,000,000"
},
{
    name: "Chảo chống dính cao cấp",
    imgUrl: "../../src/assets/img/product/sg-11134201-22120-ol6w530xclkv13.jpg",
    price: "209,000",
    discount: "190,000"
}]
</script>
