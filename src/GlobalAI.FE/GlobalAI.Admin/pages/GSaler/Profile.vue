<template>
  <div class="lg:w-4/5 container w-full bg-white">
    <!-- Ảnh đại diện -->
    <div class="bg-green-300 h-40 pr-4">
    </div>
    <div class="lg:-mt-14 -mt-12 flex lg:ml-10 ml-4 items-center lg:gap-x-7 gap-x-4 mb-8">
      <img class="lg:w-24 lg:h-24 w-20 h-20 rounded-full object-cover" :src="image" alt="Avatar">
      <div>
        <h2 class="text-[16px] font-bold text-gray-800 mt-1 mb-3">{{ userinfo.name }}</h2>
        <div class="text-[14px] flex flex-row gap-x-4">
          <span>Người theo dõi: <span class="font-semibold">0</span></span>
          <span>Đang theo dõi: <span class="font-semibold text-[14px]">0</span></span>
        </div>
      </div>
    </div>
    <!-- Thông tin cá nhân -->
    <div class="pb-6 px-14 text-[14px]">
      <ul>
        <li class="mb-4 flex items-center gap-x-4">
          <div class="text-gray-500">
            <font-awesome-icon :icon="['fass', 'envelope']" />
          </div>
          <span class="text-gray-700">{{ userinfo.email }}</span>
        </li>
        <li class="mb-4 flex items-center gap-x-4">
          <div class="text-gray-500">
            <font-awesome-icon :icon="['fass', 'phone']" />
          </div>
          <span class="text-gray-700 ">123-456-789 </span>
        </li>
        <li class="mb-4 flex items-center gap-x-5">
          <div class="text-gray-500">
            <font-awesome-icon :icon="['fass', 'location-dot']" />
          </div>
          <span class="text-gray-700 ">55-Giải Phóng, Đồng Tâm, Hai Bà Trưng, Hà Nội</span>
        </li>
    </ul>
  </div>
</div>
</template>
<script setup>
import team2 from "../../assets/img/team-2-800x800.jpg";
import lewy from "../../assets/img/lewy.png";
import image from "@/assets/img/team-1-800x800.jpg";
import jwt_decode from "jwt-decode";
import { useUserStorage } from "~~/stores/user";
import {ref} from "vue"
import DefaultNavbar from "~~/components/Navbars/DefaultNavbar.vue";
const token = useUserStorage();
const accesstoken = token.accessToken;
const router = useRouter();
const userinfo = ref({});

const getUserInfor = () => {
  const user = jwt_decode(accesstoken);
  userinfo.value = {
    name : user.name,
    email : user.email
  }
};
onMounted(() =>{
  getUserInfor();
})
definePageMeta({
  layout: "layout-profile",
});
</script>


