<template>
  <div
    class="flex flex-wrap px-8 mx-auto gap-[10px] mt-[20px] mb-[20px] sm:block"
  >
    <marquee behavior="" direction="" class="py-1"
      >
      <div v-for="(item, idx) in listDanhMuc" :key="idx" class="overflow-hidden inline-flex  ml-2 mt-2 uppercase bg-white rounded-xl">
        <RouterLink
        class="py-[10px] px-[20px] w-full"
        :to="`/product/category/${item.id}`"
        
        :style="{ 'color': colors[idx % colors.length]}"
        :key="idx"
        @click="selectedCategory(item)"
      >
        {{ item.tenDanhMuc }}
      </RouterLink>
      </div>
     </marquee
    >
  </div>
</template>

<script setup>
import { getDanhMucSanPham } from "~~/composables/useApiProduct";
import { ref } from "vue";
import { defineEmits } from "vue";
import { useRouter } from "vue-router";
let collapseShow = ref("hidden");
const  colors = ['#FFC107', '#9C27B0', '#00BCD4', '#4CAF50', '#E91E63']
const listDanhMuc = ref([]);
const router = useRouter();
onMounted(() => {
  getDanhMucSanPham()
   .then((res) =>
      listDanhMuc.value = res?.data?.data?.items
   )
   .catch((error) => console.log(error))
})
const toggleCollapseShow = (classes) => {
  collapseShow.value = classes;
};
const emits = defineEmits("category-clicked");
const selectedCategory = (category) => {
  emits("category-clicked", category);
};
</script>
