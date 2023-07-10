<template>
  <div class="flex mt-4">
    <div class="w-full">
      <card-category-product></card-category-product>
    </div>
  </div>
</template>

<script setup>
import CardCategoryProduct from "~~/components/Cards/CardCategoryProduct.vue";
definePageMeta({
  layout: "admin",
});
</script>
