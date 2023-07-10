<template lang="">
  <div class="w-full border-[1px] flex bg-white min-h-[100vh]">
  <SidebarChat/>
    <div class="flex-1 pt-[15px] flex items-center justify-center">
      <h1>Tích cực chat , săn quà khủng !!!</h1>
    </div>
  </div>
</template>
<script setup>
import SidebarChat from "~~/components/Sidebar/SidebarChat.vue";

definePageMeta({
  layout: "layout-default",
  name: "BoxChat",
});
</script>