<template>
    <div class="w-full">
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[20px] mt-[40px]"
        >
          Lãi cao bán tốt
        </h1>
        <div class="grid grid-cols-1 sm:grid-cols-2 gap-[20px]">
          <div class="sm:px-0 px-4 cursor-pointer">
            <img
              :src="imgGiaDungThongMinh"
              alt=""
              class="h-full object-cover rounded-2xl"
            />
          </div>
          <div class="sm:flex-1 mt-[20px] sm:mt-0">
            <div class="sm:px-0 px-4 cursor-pointer grid grid-cols-1">
              <img
                :src="imgDungCuLamDep"
                class="h-[195px] w-full rounded-2xl object-cover"
                alt=""
              />
            </div>
            <div
              class="grid grid-cols-1 cursor-pointer sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2 mt-[20px]"
            >
              <div>
                <img
                  :src="imgNuocHoaChinhHang"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  :src="imgGiayDepNam"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
            </div>
          </div>
        </div>
      </div>
</template>
<script setup>
import imgGiaDungThongMinh from "~~/assets/img/Home/gia-dung-thong-minh.jpg"
import imgDungCuLamDep from "~~/assets/img/Home/dung-cu-lam-dep.jpg"
import imgNuocHoaChinhHang from "~~/assets/img/Home/nuoc-hoa-chinh-hang.jpg"
import imgGiayDepNam from "~~/assets/img/Home/giay-dep-nam.jpg";
</script>
<style>
    
</style>