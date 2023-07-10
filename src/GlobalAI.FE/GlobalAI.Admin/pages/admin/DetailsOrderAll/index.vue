<template>
  <div class="flex mt-4">
    <div class="w-full">
      <card-details-order-all></card-details-order-all>
    </div>
  </div>
</template>

<script setup>
import CardDetailsOrderAll from "~~/components/Cards/CardDetailsOrderAll.vue";
definePageMeta({
  layout: "admin",
});
</script>
