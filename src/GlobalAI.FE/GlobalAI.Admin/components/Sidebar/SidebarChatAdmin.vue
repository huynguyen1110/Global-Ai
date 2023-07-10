<template lang="">
  <div class="w-[40%] py-[15px] border-r-[1px]">
    <div class="header flex justify-between px-[10px] items-center">
      <h1 class="text-[24px] font-bold">Chat</h1>
      <div class="flex gap-[15px]">
        <select name="" id="" class="border rounded-md px-2 py-2 outline-none">
          <option value="">Tất cả</option>
          <option value="">Mới Mua</option>
          <option value="">Trò Chuyện</option>
        </select>
        <button class="text-[22px]">
          <font-awesome-icon :icon="['fass', 'gear']" />
        </button>
      </div>
    </div>
    <div class="max-h-[600px] mt-[15px] overflow-y-auto">
      <router-link
        :to="`/admin/Chat/ChatDetailId/${data.idTraGia}`"
        v-for="data in contentChat"
        :key="data"
        class="px-[15px] cursor-pointer hover:bg-[#f4f4f4] flex items-center gap-[15px] border-b-[1px] py-[10px]"
      >
        <div class="w-[48px] h-[48px] rounded-[50%] border overflow-hidden">
          <img
            :src="image"
            alt=""
            class="object-cover"
          />
        </div>
        <div class="flex-1 flex gap-[6px] flex-col font-[400]">
          <h3 class="text-[16px] text-[#000000]">
            {{ data.sanPham.tenSanPham }}
          </h3>
          <p
            class="text-[12px] leading-[1.2] h-[14.4px] whitespace-normal text-ellipsis line-clamp-1 text-[#9B9B9B] font-[500]"
          >
            {{ data.sanPham.tenSanPham }}
          </p>
          <p
            class="text-[12px] text-[#9B9B9B] font-[400] leading-[1.2] h-[14.4px] whitespace-normal text-ellipsis line-clamp-1"
          >
            {{ data.sanPham.giaBan }}
          </p>
        </div>
        <div class="w-[65px] h-[65px] rounded-md overflow-hidden">
          <img
            :src="getImageUrl(data.sanPham.thumbnail)"
            alt=""
            class="object-cover"
          />
        </div>
      </router-link>
    </div>
  </div>
</template>
<script setup>
import image from "@/assets/img/team-1-800x800.jpg";
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const contentChat = ref([]);
onMounted(() => {
  getAllChatUser()
    .then((res) => {
      console.log(res.data.data);
      res.data.data.items.forEach((item) => {
        getSanPhamById(item.idSanPham).then((res) => {
          const singleData = {
            sanPham: res.data.data,
            idTraGia: item.id,
          };
          console.log(singleData);
          contentChat.value.push(singleData);
        });
      });
    })
    .catch((error) => {
      console.error(error);
      toast.error("Đã xảy ra lỗi trong quá trình get sản phẩm");
    });
});
const getImageUrl = (imageUrl) => {
  if (!imageUrl) {
    return "https://placehold.it/50x50";
  }
  const url = `${baseUrl}/${imageUrl}`;
  return url;
};
</script>
<style lang=""></style>
