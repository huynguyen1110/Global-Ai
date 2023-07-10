
  <template>
  <div>
    <sidebar-admin />
    <div class="relative md:ml-64 bg-blueGray-100">
      <admin-navbar  />
      <header-stats v-if="useSideBar.getShowSideBar" />
      <div class="px-4 md:px-10 mx-auto w-full -m-24">
        <slot></slot>
        <footer-admin />
      </div>
    </div>
  </div>
</template>

<script setup>
import AdminNavbar from "../components/Navbars/AdminNavbar.vue";
import HeaderStats from "../components/Headers/HeaderStats.vue";
import FooterAdmin from "../components/Footers/FooterAdmin.vue";
import SidebarAdmin from "~~/components/Sidebar/SidebarAdmin.vue";
import { onBeforeRouteUpdate } from "vue-router";
import { useSideBarStorage } from "~~/stores/sideBar";
import { ref } from "vue";
const router = useRouter();
const selectedCategory = ref("");
const showSideBar = ref(false);
const useSideBar = useSideBarStorage();
const showHeader = ref(true)

const changeSideBarShow = () => {
  if (
    router.currentRoute.value.name !== "ChatDetailAdminId" && router.currentRoute.value.name !== "BoxChatAdmin" && router.currentRoute.value.name !== "BoxChatIDAdmin"
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


onBeforeRouteUpdate((to, from, next) => {
  if (to.path === "/Cart/ManageCart") {
    console.log(to.path);
    showSideBar.value = false;
  }
  next();
});

const handleCategoryClick = (category) => {
  console.log(category);
  selectedCategory.value = category;
  console.log(selectedCategory.value);
};
</script>