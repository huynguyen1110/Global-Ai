<template lang="">
  <div :class="showColor ? '#f2f1f2' : 'bg-slate-100'">
    <header-blog />
    <div class="container mx-auto lg:px-[30px]">
      <div class="flex-1 lg:px-1 flex-col">
        <!-- Slot tượng trưng cho từng layout trong trang web -->
        <NuxtPage />
      </div>
    </div>
    <div class="mt-5">
      <footer-admin />
    </div>
  </div>
</template>
<script setup>
import AdminNavbar from "../components/Navbars/AdminNavbar.vue";
import Sidebar from "../components/Sidebar/Sidebar.vue";
import HeaderBlog from "~~/components/Headers/HeaderBlog.vue";
import FooterAdmin from "../components/Footers/FooterAdmin.vue";
import { useSideBarStorage } from "~~/stores/sideBar";
const router = useRouter();
const useSideBar = useSideBarStorage();
const selectedCategory = ref("");
const showColor = ref(false);
const changeSideBarShow = () => {
  if (
    router.currentRoute.value.name !== "ManageCart" &&
    router.currentRoute.value.name !== "ProductDetail" && router.currentRoute.value.name !== "BoxChat"
  ) {
    console.log(1);
    console.log(router.currentRoute.value.name);
    useSideBar.changeShowSideBar(true);
  } else {
    useSideBar.changeShowSideBar(false);
  }
};

watchEffect(() => {
  changeSideBarShow();
});
const handleCategoryClick = (category) => {
  console.log(category);
  selectedCategory.value = category;
  console.log(selectedCategory.value);
};

watchEffect(() => {
  if (router.currentRoute.value.name == "ProductDetail") {
    showColor.value = true;
  } else {
    showColor.value = false;
  }
});
</script>