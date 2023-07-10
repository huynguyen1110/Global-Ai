<template>
  <div class="flex flex-col relative min-h-[100vh] py-4">
    <div class="mb-[40px]">
      <h1 class="text-[24px] sm:pl-0 pl-4 font-bold ml-4 uppercase">{{ props ? props.category.tenDanhMuc : titleCategory}}</h1>
      <card-list-product :products="products" />
    </div>
    <div class="flex absolute bottom-0 w-full items-center justify-center">
      <card-pagination
      :pageNumber="pageNumber"
      :total-pages="totalPages" :next-page="nextPage" :prev-page="prevPage"
      v-on:click-page="handlePageClick"
      ></card-pagination>
    </div>
  </div>
</template>

<script setup>
import CardListProduct from "../../../components/Cards/CardListProduct.vue";
import CardPagination from "~~/components/Cards/CardPagination.vue";
// import { defineProps } from "vue";
import { ref } from "vue";
import { PAGINATION } from "~~/lib/danhMuc";
import { useRouter } from "vue-router";

const router = useRouter();
const products = ref([]);
const totalPages = ref(1);
const pageSize = 10;
const pageNumber = ref(1);
const skip = ref(0);
const titleCategory = ref('')
const categoryId = ref('');

const updateProducts = (categoryId) => {
  getSanPhamDanhMucPhanTrang(categoryId, pageSize, pageNumber.value, skip.value)
    .then((res) => {
      console.log(res);
      products.value = res?.data?.data.items;
      console.log(products.value);
    })
    .catch(() => {
      products.value = [];
    });
};
const getTongSanPham = (categoryId) => {
  getFullSanPham(categoryId)
   .then((res) => {
      console.log(res);
      totalPages.value = Math.floor(res?.data?.data.items.length/pageSize) + 1;
      console.log(totalPages.value);
    })
   .catch((error) => {
    console.log(error)
   });
}

watchEffect(() => {
  console.log(props);
  categoryId.value = props.category.id ? props.category.id : router.currentRoute.value.params.id;
  updateProducts(categoryId.value);
  getTongSanPham(categoryId.value)
});

// const displayedItems = computed(() => {
//   const startIndex = (currentPage.value - 1) * itemsPerPage;
//   const endIndex = startIndex + itemsPerPage;
//   return products.value.slice(startIndex, endIndex);
// });

watchEffect(() => {
    if(router.currentRoute.value.params.id == '1'){
      titleCategory.value = 'Đồng Hồ'
      console.log(titleCategory.value);
    }
    else if(router.currentRoute.value.params.id == '4'){
      titleCategory.value = 'Thời Trang Nam'
    }
})


const nextPage = ()=> {
     pageNumber.value++;
     skip.value = (pageNumber.value - 1) * pageSize;
}

const handlePageClick = (page) =>{
  pageNumber.value = page;
  skip.value = (pageNumber.value - 1) * pageSize;
}

const prevPage =() =>{
  pageNumber.value--;
  console.log(123);
  skip.value = (pageNumber.value - 1) * pageSize;
}
const props = defineProps({
  category: {
    type: Object,
    required: true,
  },
});

definePageMeta({
  layout: "layout-default",
  name:'Category'
})
</script>
