<template>
  <div class="flex justify-center items-center">
    <div class="min-h-screen flex flex-col items-center justify-center">
      <div class="min-h-screen my-auto flex justify-center flex-col">
        <div>
          <h2 class="text-center text-[26px] font-bold ">
            GlobalAI
          </h2>
          <h2 class="font-bold text-[26px] text-center uppercase">
            Cung cấp giải pháp kinh doanh linh hoạt
          </h2>
        </div>
        <div>
          <div class="grid grid-cols-4 gap-8 my-auto p-10">
            <div @click="router.push('/')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110 cursor-pointer"
                :src="trangchu"
                alt=""
              />
            </div>
            <div @click="router.push('/gsaler/home')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110 cursor-pointer"
                :src="dropship"
                alt=""
              />
            </div>
            <div @click="router.push('/post/postdanhmuc/102')">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110 cursor-pointer"
                :src="hocvien"
                alt=""
              />
            </div>
            <div @click="handleRedirect">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110 cursor-pointer"
                :src="affiliate"
                alt=""
              />
            </div>
            <div @click="handleRedirect">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110 cursor-pointer"
                :src="kiemtien"
                alt=""
              />
            </div>
            <div @click="handleRedirect">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110 cursor-pointer"
                :src="gindex"
                alt=""
              />
            </div>
            <div @click="handleRedirect">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110 cursor-pointer"
                :src="forum"
                alt=""
              />
            </div>
            <div @click="handleRedirect">
              <img
                class="border rounded-xl transform transition duration-500 hover:scale-110 cursor-pointer"
                :src="aitool"
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
definePageMeta({
  layout: "layout-default",
  name: "FirstPage",
});

import imgBanChayNhat from "~~/assets/img/Home/ban-chay-nhat.jpg";
import dropship from "~~/assets/img/Home/Redirect-dropship.png";
import trangchu from "~~/assets/img/Home/Redirect-trangchu.png";
import hocvien from "~~/assets/img/Home/Redirect-hocvien.png";
import affiliate from "~~/assets/img/Home/Redirect-affiliate.png";
import forum from "~~/assets/img/Home/Redirect-Forum.png";
import aitool from "~~/assets/img/Home/Redirect-aitool.png";
import gindex from "~~/assets/img/Home/Redirect-gindex.png";
import kiemtien from "~~/assets/img/Home/Redirect-kiemtien.png";


import imgDanhGiaCao from "~~/assets/img/Home/danh-gia-cao.jpg";
import imgMoiThamGia from "~~/assets/img/Home/moi-tham-gia.jpg";
import imgXacThuc from "~~/assets/img/Home/xac-thuc.jpg";
import imgFreeShip from "~~/assets/img/Home/freeship-den-80k.jpg";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();
const router = useRouter();

const handleRedirect = async () => {
  $toast.warn("Chức năng đang được cập nhật");
};
</script>
<style></style>
