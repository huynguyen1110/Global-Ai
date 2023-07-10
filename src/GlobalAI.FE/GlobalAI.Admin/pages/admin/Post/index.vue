<template>
  <div class="flex mt-4">
    <div class="w-full">
      <card-post></card-post>
    </div>
  </div>
</template>

<script setup>
import CardPost from "~~/components/Cards/CardPost.vue";
definePageMeta({
  layout: "admin",
});
</script>
