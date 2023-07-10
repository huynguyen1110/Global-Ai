<template>
  <paginate v-model="page" :page-count="props.pageCount || 0" container-class="flex flex-row text-emerald-500 w-auto"
    page-class="py-2 px-4 border-t border-b border-r bg-white hover:cursor-pointer"
    prev-class="py-2 px-4 bg-white border hover:cursor-pointer"
    next-class="py-2 px-4 bg-white border-b border-t border-r hover:cursor-pointer" active-class="!bg-emerald-500 text-white"
    prev-text="«" next-text="»"
    :click-handler="clickCallback">
  </paginate>
</template>

<style lang="css" scoped>
/* Adopt bootstrap pagination stylesheet. */
/* @import "https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"; */
</style>

<script setup>
import Paginate from "vuejs-paginate-next";

const props = defineProps({
  pageCount: Number,
  modelValue: {
    type: Number,
    default: 1,
  },
});

const emits = defineEmits(["update:modelValue", "page-change"]);
const clickCallback = (pageNum) => {
  emits("update:modelValue", pageNum);
  emits("page-change", pageNum);
}
</script>