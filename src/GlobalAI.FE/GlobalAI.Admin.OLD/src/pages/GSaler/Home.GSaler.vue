<template>
  <div>
    <div class="flex flex-wrap">
      <card-list-product-short title="sản phẩm mới" :products="products1" />
      <card-list-product-short title="sản phẩm bán chạy" :products="products2" />
    </div>
  </div>
</template>
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

const products2 = [{
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
