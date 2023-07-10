<template>
  <div class="flex mt-4">
    <div class="w-full">
      <the-card class="!max-w-full">
        <card-product />
      </the-card>
    </div>
  </div>
</template>

<script setup>
import CardProduct from "~~/components/Cards/CardProduct.vue";
import { TheCard } from 'flowbite-vue'
definePageMeta({
  layout: "admin-management",
});
</script>
