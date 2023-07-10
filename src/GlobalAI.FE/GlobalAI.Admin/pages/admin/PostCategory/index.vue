<template>
  <div class="flex mt-4">
    <div class="w-full">
      <card-post-category></card-post-category>
    </div>
  </div>
</template>

<script setup>
import CardPostCategory from "~~/components/Cards/CardPostCategory.vue";
definePageMeta({
  layout: "admin",
});
</script>
