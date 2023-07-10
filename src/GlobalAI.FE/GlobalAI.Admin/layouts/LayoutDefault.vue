<template lang="">
    <div :class="showColor ? '#f2f1f2' : 'bg-slate-100'">
        <header-default />
        <sidebar
            v-if="useSideBar.getShowSideBar"
            v-on:category-clicked="handleCategoryClick"
        />
        <div
            :class="
                checkContainer ? 'container mx-auto lg:px-[185px]' : 'container'
            "
        >
            <div class="flex-1 lg:px-1 flex-col">
                <!-- Slot tượng trưng cho từng layout trong trang web -->
                <NuxtPage :category="selectedCategory" />
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
import HeaderDefault from "~~/components/Headers/HeaderDefault.vue";
import FooterAdmin from "../components/Footers/FooterAdmin.vue";
import { useSideBarStorage } from "~~/stores/sideBar";
const router = useRouter();
const useSideBar = useSideBarStorage();
const selectedCategory = ref("");
const showColor = ref(false);
const checkContainer = ref(true);
const changeSideBarShow = () => {
  if (
    router.currentRoute.value.name !== "ManageCart" &&
    router.currentRoute.value.name !== "ProductDetail" && router.currentRoute.value.name !== "BoxChat" && router.currentRoute.value.name !== "BoxChatID" && router.currentRoute.value.name !== "SupplierPage"
    && router.currentRoute.value.name !== "OrderLayout" && router.currentRoute.value.name !== "FirstPage"
  ) {
    console.log(1);
    console.log(router.currentRoute.value.name);
    useSideBar.changeShowSideBar(true);
  } else {
    useSideBar.changeShowSideBar(false);
  }
};

const changeWidthContainer = () => {
  if(router.currentRoute.value.name !== "SupplierPage" && router.currentRoute.value.name !== "OrderLayout"){
    checkContainer.value = true;
  } else {
    checkContainer.value = false;
  }
};

watchEffect(() => {
    changeSideBarShow();
    changeWidthContainer();
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
