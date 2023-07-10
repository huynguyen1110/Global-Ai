<template >
     <!-- Cộng đồng bán hàng -->
     <div class="w-full">
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[20px] mt-[40px]"
        >
          Cộng đồng bán hàng
        </h1>
        <div
          class="cursor-pointer grid grid-cols-1 sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2"
        >
          <div>
            <img
              :src="imgAdvise"
              class="object-cover rounded-2xl"
              alt=""
            />
          </div>
          <div>
            <img
              :src="imgComunity"
              class="object-cover rounded-2xl"
              alt=""
            />
          </div>
        </div>
      </div>
</template>
<script setup>
import imgAdvise from "~~/assets/img/Home/cong-dong-ban-hang.jpg"
import imgComunity from "~~/assets/img/Home/tham-gia-cong-dong.jpg"
</script>
<style >
    
</style>