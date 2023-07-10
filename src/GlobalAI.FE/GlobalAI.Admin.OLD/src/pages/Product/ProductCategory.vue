<template>
  <div>
    <div class="flex flex-wrap">
      <card-list-product title="sản phẩm mới" :products="products1" />
    </div>
    <div class="flex justify-center">
                <nav aria-label="Page navigation example ">
                <ul class="inline-flex items-center -space-x-px">
                    <li>
                    <a href="#" class="block px-3 py-2 ml-0 leading-tight text-gray-500 bg-white border border-gray-300 rounded-l-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">
                        <span class="sr-only">Previous</span>
                        <svg aria-hidden="true" class="w-5 h-5" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M12.707 5.293a1 1 0 010 1.414L9.414 10l3.293 3.293a1 1 0 01-1.414 1.414l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 0z" clip-rule="evenodd"></path></svg>
                    </a>
                    </li>
                    <li>
                    <a href="#" class="px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">1</a>
                    </li>
                    <li>
                    <a href="#" class="px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">2</a>
                    </li>
                    <li>
                    <a href="#" aria-current="page" class="z-10 px-3 py-2 leading-tight text-blue-600 border border-blue-300 bg-blue-50 hover:bg-blue-100 hover:text-blue-700 dark:border-gray-700 dark:bg-gray-700 dark:text-white">3</a>
                    </li>
                    <li>
                    <a href="#" class="px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">4</a>
                    </li>
                    <li>
                    <a href="#" class="px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">5</a>
                    </li>
                    <li>
                    <a href="#" class="block px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 rounded-r-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white">
                        <span class="sr-only">Next</span>
                        <svg aria-hidden="true" class="w-5 h-5" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd"></path></svg>
                    </a>
                    </li>
                </ul>
                </nav>
      </div>
    
  </div>
</template>
<script setup>
import CardListProduct from '../../components/Cards/CardListProduct.vue';
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
},{
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
},{
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
