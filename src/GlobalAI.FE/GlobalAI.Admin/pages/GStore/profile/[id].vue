<template lang="">
    <div class="bg-gray-100">
      <section class="text-gray-600 body-font ">
        <div class="container mt-10">
          <div
            class="my-10 bg-white flex mx-auto border-b mb-3 border-gray-200 rounded-lg sm:flex-row flex-col"
          >
            <div
              class=" mr-6 flex-shrink-0"
            >
              <img class="w-full" :src="gstore" />
            </div>
            <div class="flex-grow sm:text-left text-center mt-6 sm:mt-0">
              <h1 class="text-black text-4xl title-font font-bold mb-2">
                Supplier Global
              </h1>

              <div class="mb-2 mt-2">
                <div class="mt-2 flex items-center">
                  <h2 class="text-gray-500 w-12">SĐT</h2>
                  <h1 class="text-base text-gray-900 ml-5 font-semibold">
                    90998765432
                  </h1>
                </div>
                <div class="mt-2 flex items-center">
                  <h2 class="text-gray-500 w-12">Email</h2>
                  <h1 class="text-base text-gray-900 ml-5 font-semibold">
                    global.ai@yahoo.com
                  </h1>
                </div>
                <div class="mt-2 flex items-center">
                  <h2 class="text-gray-500 w-12">Website</h2>
                  <h1 class="text-base text-gray-900 ml-5 font-semibold">
                    global.ai.com
                  </h1>
                </div>
                <div class="mt-2 flex items-center">
                  <h2 class="text-gray-500 w-12">Địa chỉ</h2>
                  <h1 class="text-base text-gray-900 ml-5 font-semibold">
                    Ha Noi, Viet Nam
                  </h1>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>

    <div class="flex-grow">
      <h2
        class="title-font mb-1 text-xl text-md font-medium tracking-wider text-gray-900"
      >
        Giới thiệu
      </h2>
      <p class="font-laonoto leading-relaxed">
        Garnier là thương hiệu làm đẹp từ thiên nhiên số 1 thế giới, chuyên sâu về chăm sóc và bảo vệ sức khỏe làn da. Là sự hòa quyện tuyệt vời giữa từ hơn 90% chiết xuất nguyên liệu từ thiên nhiên và công nghệ khoa học đột phá – Green Labs, được kiểm nghiệm bởi chuyên gia da liễu, Garnier cung cấp những giải pháp có hiệu quả vượt trội đã được chứng minh hoàn toàn lành tính & an toàn, chăm sóc da của bạn khỏe đẹp từ bên trong.
      </p>
    </div>
    <section class="bg-gray-100">
      <cards-card-list-product title="Sản phẩm" :products="products1" />
    </section>
    <card-pagination></card-pagination>
</template>    

<script setup>
// import CardListProductShort from "../../../../components/Cards/CardListProductShort.vue";
import CardListProductShort from "~~/components/Cards/CardListProductShort.vue";
import CardPagination from "~~/components/Cards/CardPagination.vue";
import img1 from "~/assets/img/product/2a058125fdc92cb24ca382fa36107f1d.jpg";
import img2 from "~/assets/img/product/8c37010c4421b7eed56fc3b5e6fbf414.jpg";
import img3 from "~/assets/img/product/a10cacd0a2ec3dd59e1b679b31373256.jpg";
import img4 from "~/assets/img/product/mypham.jpg";
import img5 from "~/assets/img/product/sg-11134201-22120-6odt1fg9y6kve2.jpg";
import img6 from "~/assets/img/product/sg-11134201-22120-75lyidugp7kv06.jpg";
import img8 from "~/assets/img/product/sg-11134201-22120-un5b5kp9xskvd0.jpg";
import img7 from "~/assets/img/product/vn-11134201-23020-tjtl9dace3nv28.jpg";
import img9 from "~/assets/img/product/sg-11134201-22120-ol6w530xclkv13.jpg";
import img10 from "~/assets/img/product/8c37010c4421b7eed56fc3b5e6fbf414.jpg";
import gstore from "~/assets/img/Gstore/z4237084905277_fb92d546d07a25fd2385aaedfc6f31cb.jpg";
// import { defineAsyncComponent } from 'vue';
// const CardListProductShort = defineAsyncComponent('../../components/Cards/CardListProductShort.vue');
definePageMeta({
  layout: 'admin',
});

const products1 = [
  {
    name: "Viên uống bổ sung vitamin C DHC",
    imgUrl: img1,
    price: "170,000",
    discount: "150,000",
  },
  {
    name: "Kính râm phân cực Kateluo",
    imgUrl: img2,
    price: "340,000",
    discount: "300,000",
  },
  {
    name: "Camera ip wifi Ezviz",
    imgUrl: img3,
    price: "1,689,000",
    discount: "1,400,000",
  },
  {
    name: "Nồi inox cao cấp 3 lớp đáy",
    imgUrl: img4,
    price: "645,000",
    discount: "600,000",
  },
  {
    name: "Son kem lì 3CE Cloud lip tint",
    imgUrl: img5,
    price: "363,000",
    discount: "350,000",
  },
  {
    name: "Mũ bảo hiểm nửa đầu",
    imgUrl: img6,
    price: "219,000",
    discount: "250,000",
  },
  {
    name: "Áo khoác Paradox",
    imgUrl: img7,
    price: "379,000",
    discount: "320,000",
  },
  {
    name: "Serum cho da nhờn mụn Garnier",
    imgUrl: img8,
    price: "289,000",
    discount: "250,000",
  },
  {
    name: "Giày chạy bộ Supernova Adidas",
    imgUrl: img9,
    price: "2,400,000",
    discount: "2,000,000",
  },
  {
    name: "Chảo chống dính cao cấp",
    imgUrl: img10,
    price: "209,000",
    discount: "190,000",
  },
];


</script>

