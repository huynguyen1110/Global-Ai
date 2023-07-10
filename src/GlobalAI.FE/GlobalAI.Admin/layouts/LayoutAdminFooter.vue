<template>
  <div>
    <!-- <sidebar /> -->
    <div class="relative md:ml-0 bg-slate-100">
      <admin-navbar />
      <header-stats />
      <div class="px-4 md:px-1 mx-auto max-h-screen w-full -m-24">
        <slot></slot>
        <!-- <footer-admin /> -->
      </div>
    </div>
  </div>
</template>
<script setup>
import AdminNavbar from "../components/Navbars/AdminNavbar.vue";
import Sidebar from "../components/Sidebar/Sidebar.vue";
import HeaderStats from "../components/Headers/HeaderStats.vue";
import FooterAdmin from "../components/Footers/FooterAdmin.vue";
</script>
