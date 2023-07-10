<template lang="">
  <div class="w-full mt-[100px] border-[1px] flex bg-white min-h-[100vh]">
  <SidebarChatAdmin/>
    <div class="flex-1 pt-[15px] flex items-center justify-center">
      <h1>Tích cực chat , săn quà khủng !!!</h1>
    </div>
  </div>
</template>
<script setup>
import SidebarChatAdmin from "~~/components/Sidebar/SidebarChatAdmin.vue";
definePageMeta({
  layout: "admin",
  name: "BoxChatAdmin",
});
</script>