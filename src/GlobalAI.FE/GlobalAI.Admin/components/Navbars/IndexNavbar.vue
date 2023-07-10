<template>
  <nav
    class="top-0 fixed z-50 w-full flex flex-wrap items-center justify-between px-2 navbar-expand-lg bg-white shadow"
  >
    <div
      class="container px-4 mx-auto flex flex-wrap items-center justify-between"
    >
      <div
        class="w-full relative flex justify-between lg:w-auto lg:static lg:block lg:justify-start"
      >
        <nuxt-link to="/">
         
          <img
                      alt="..."
                      class="align-middle border-none w-[150px] py-1 rounded-lg"
                      :src="logo"
                    />
        </nuxt-link>
        <button
          class="cursor-pointer text-xl leading-none px-3 py-1 border border-solid border-transparent rounded bg-transparent block lg:hidden outline-none focus:outline-none"
          type="button"
          @click="setNavbarOpen"
        >
          <i class="fas fa-bars"></i>
        </button>
      </div>
      <div
        class="lg:flex flex-grow items-center"
        :class="[navbarOpen ? 'block' : 'hidden']"
        id="example-navbar-warning"
      >
        <ul class="flex flex-col lg:flex-row list-none mr-auto">
          <li class="flex items-center">
            <!-- <a
              class="hover:text-slate-500 text-slate-700 px-3 py-2 flex items-center text-xs uppercase font-bold"
              href="#"
            >
              <i
                class="text-slate-400 far fa-file-alt text-lg leading-lg mr-2"
              />
              Tài liệu
            </a> -->
          </li>
        </ul>
        <ul class="flex flex-col lg:flex-row list-none lg:ml-auto">
          <li class="flex items-center">
            <a
              class="hover:text-slate-500 text-slate-700 px-3 py-2 flex items-center text-xs uppercase font-bold"
              href="#"
            >
              <i class="text-slate-400 fab fa-facebook text-lg leading-lg" />
              <img class="w-8" :src="UserSvg" />
            </a>
          </li>

          <li class="flex items-center">
            <a
              class="hover:text-slate-500 text-slate-700 px-3 py-2 flex items-center text-xs uppercase font-bold"
              href="#"
            >
              <i class="text-slate-400 fab fa-twitter text-lg leading-lg" />
              <span class="lg:hidden inline-block ml-2">Tweet</span>
            </a>
          </li>

          <li class="flex items-center">
            <a
              class="hover:text-slate-500 text-slate-700 px-3 py-2 flex items-center text-xs uppercase font-bold"
              href="#"
            >
              <i class="text-slate-400 fab fa-github text-lg leading-lg" />
              <span class="lg:hidden inline-block ml-2">Star</span>
            </a>
          </li>

          <!-- <li class="flex items-center">
            <button
              class="bg-emerald-500 text-white active:bg-emerald-600 text-xs font-bold uppercase px-4 py-2 rounded shadow hover:shadow-lg outline-none focus:outline-none lg:mr-1 lg:mb-0 ml-3 mb-3 ease-linear transition-all duration-150"
              type="button"
            >
              <i class="fas fa-arrow-alt-circle-down"></i> Download
            </button>
          </li> -->
        </ul>
      </div>
    </div>
  </nav>
</template>

<script setup>
import IndexDropdown from "../Dropdowns/IndexDropdown.vue";
import UserSvg from "../../assets/svg/user.svg";
import { ref } from "vue";
import logo from "~~/assets/img/Text_2_3_logo.png";

let navbarOpen = ref(false);

const setNavbarOpen = () => {
  navbarOpen.value = !navbarOpen.value;
};
</script>
