<template>
    <div :class="showColor ? '#f2f1f2' : 'bg-slate-100'">
      <header-default />
      <div class="container flex-col lg:flex lg:flex-row mx-auto">
        <SidebarProfile :showMenu="showMenu" v-on:handleClose="onCloseMenu" class="w-1/5 hidden lg:block"></SidebarProfile>
        <div class="w-full bg-green-300 lg:hidden ">
            <button 
                type="button" 
                class="inline-flex items-center p-2 mt-2 ml-3 text-sm text-gray-500 rounded-lg hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600"
                @click="onShowMenu"
            >
                <font-awesome-icon :icon="['fass', 'bars']" />
            </button>
        </div>
        <slot></slot>
      </div>
      <div class="">
        <footer-admin />
      </div>
    </div>
</template>

<script setup>
import FooterAdmin from "~~/components/Footers/FooterAdmin.vue";
import DefaultNavbar from "~~/components/Navbars/DefaultNavbar.vue";
import HeaderDefault from "~~/components/Headers/HeaderDefault.vue";
import SidebarProfile from "~~/components/Sidebar/SidebarProfile.vue";
import {ref} from "vue"

const showMenu = ref("-translate-x-full")

const onShowMenu = () => {
    showMenu.value = ""
}
const onCloseMenu = () => {
    showMenu.value = "-translate-x-full"
}

</script>
