<template>
    <div>
        <div class="w-full">
        <h1
          class="sm:px-0 px-4 uppercase text-[16px] sm:text-[24px] text-[#384059] font-bold mb-[20px] mt-[40px]"
        >
          Lựa chọn dễ bán
        </h1>
        <div class="grid grid-cols-1 sm:grid-cols-2 gap-[20px]">
          <div class="">
            <div class="sm:px-0 px-4 cursor-pointer grid grid-cols-1">
              <img
                :src="imgThoiTrangNu"
                class="h-[195px] w-full rounded-2xl object-cover"
                alt=""
              />
            </div>
            <div
              class="grid grid-cols-1 cursor-pointer sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2 mt-[20px]"
            >
              <div>
                <img
                  :src="imgThoiTrangNam"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  :src="imgTraHat"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
            </div>
          </div>
          <div class="flex-1">
            <div class="sm:px-0 px-4 cursor-pointer grid grid-cols-1">
              <img
                :src="imgAnVatDacSan"
                class="h-[195px] w-full rounded-2xl object-cover"
                alt=""
              />
            </div>
            <div
              class="grid grid-cols-1 cursor-pointer sm:px-0 px-4 gap-5 lg:grid-cols-2 md:grid-cols-2 sm:grid-cols-2 mt-[20px]"
            >
              <div>
                <img
                  :src="imgTinhDauNen"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
              <div>
                <img
                  :src="imgMyPhamChinhHang"
                  class="object-cover rounded-2xl"
                  alt=""
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
</template>
<script setup>
import imgThoiTrangNu from "~~/assets/img/Home/thoi-trang-nu.jpg"
import imgAnVatDacSan from "~~/assets/img/Home/an-vat-dac-san.jpg"
import imgThoiTrangNam from "~~/assets/img/Home/thoi-trang-nam.jpg"
import imgTraHat from "~~/assets/img/Home/tra-hat.jpg"
import imgMyPhamChinhHang from "~~/assets/img/Home/my-pham-chinh-hang.jpg"
import imgTinhDauNen from "~~/assets/img/Home/tinh-dau-nen.png"
</script>
<style lang="">
    
</style>