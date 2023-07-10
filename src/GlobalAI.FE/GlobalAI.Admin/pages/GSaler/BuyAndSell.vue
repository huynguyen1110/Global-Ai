<template >
    <div class="w-full">
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[20px] mt-[40px]"
        >
          Mua gì bán đấy
        </h1>
        <div class="sm:flex gap-[20px]">
          <div class="sm:w-[50%]">
            <div class="sm:px-0 px-4 cursor-pointer grid grid-cols-1">
              <img
                :src="ImgTramDonDonHe"
                class="h-[195px] w-full rounded-2xl object-cover"
                alt=""
              />
            </div>
            <div
              class="grid grid-cols-1 cursor-pointer sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2 mt-[20px]"
            >
              <div>
                <img
                  :src="imgChamSocSacDep"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  :src="imgChamSocSacDep"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
            </div>
          </div>
          <div class="sm:flex-1 cursor-pointer sm:mt-0 mt-[20px]">
            <div
              class="grid grid-cols-1 gap-5 sm:px-0 px-4 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2"
            >
              <div>
                <img
                  :src="imgChamSocSacDep"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  :src="imgChamSocSacDep"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                :src="imgChamSocSacDep"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  :src="imgChamSocSacDep"
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
import ImgTramDonDonHe from "~~/assets/img/Home/thang-5-tram-don-don-he.jpg"
import imgChamSocSacDep from "~~/assets/img/Home/cham-soc-sac-dep.jpg"
</script>
<style >
    
</style>