<template>
  <div class="flex mt-4">
    <div class="w-full">
      <card-voucher />
    </div>
  </div>
</template>

<script setup>
import CardVoucher from "~~/components/Cards/CardVoucher.vue";
definePageMeta({
  layout: "admin",
});
</script>
