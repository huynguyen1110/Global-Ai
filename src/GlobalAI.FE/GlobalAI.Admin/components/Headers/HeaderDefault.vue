<template>
  <div>
  
    <!-- Header -->
    <div>
      <div class="sticky top-0 bg-white z-20 shadow lg:hidden ">
        <div class="container mx-auto px-4">
          <div class="flex justify-between items-center">
            <a
              href="/"
              class="text-slate-700 text-xl font-bold leading-relaxed"
            >
            <img
                      alt="..."
                      class="align-middle border-none max-w-full py-1 w-[120px] rounded-lg"
                      :src="logo"
                    />
            </a>
            <button class="block lg:hidden focus:outline-none">
              <FontAwesomeIcon icon="fas fa-bars" />
            </button>
          </div>
        </div>
      </div>
      <div
        class="sticky hidden lg:block relative top-0 border-y-2 bg-white z-20 shadow px-4"
      >
        <div class="px-4 container flex flex-nowrap md:px-6 mx-auto w-full">
          <div
            class="flex-auto text-xl flex flex-col-reverse justify-center font-bold"
          >
            <a
              aria-current="page"
              href="/"
              class="router-link-active router-link-exact-active"
            >
              <div class="w-[150px]">
                <a
                  class="text-slate-700 text-xl font-bold leading-relaxed inline-block mr-4 whitespace-nowrap"
                  href="/"
                >
                <img
                      alt="..."
                      class="align-middle border-none max-w-full py-1 rounded-lg w-full"
                      :src="logo"
                    />
                
                </a>
              </div>
            </a>
            <button
              class="hidden lg:block cursor-pointer text-xl leading-none px-3 py-1 border border-solid border-transparent rounded bg-transparent outline-none focus:outline-none"
              type="button"
            >
              <i class="fas fa-bars"></i>
            </button>
          </div>

          <div class="flex flex-wrap">
            <DefaultNavbar></DefaultNavbar>
          </div>
        </div>
      </div>
      
    </div>
  </div>
</template>

<script setup>
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import CardStats from "../../components/Cards/CardStats.vue";
import DefaultNavbar from "../Navbars/DefaultNavbar.vue";
import logo from "~~/assets/img/Text_2_3_logo.png";
</script>
