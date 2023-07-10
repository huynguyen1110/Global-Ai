<template>
  <div class="flex mt-4">
    <div class="w-full">
      <card-order />
    </div>
  </div>
</template>

<script setup>
import CardOrder from "~~/components/Cards/CardOrder.vue";
definePageMeta({
  layout: "admin",
});
</script>
