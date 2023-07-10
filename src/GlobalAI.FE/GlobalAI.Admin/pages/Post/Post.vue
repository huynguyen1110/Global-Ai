<template>
  <HeaderDefault />
  <div class="flex flex-col">
    <div class="flex w-full justify-center bg-green-600">
      <div class="flex justify-between gap-0 h-[50px] bg-slate-500">
        <div
          class="hover:bg-green-500 bg-green-600 text-white"
          v-for="(dm, index) in danhMuc"
          :key="index"
          @click="selectCategory(dm.id)"
        >
          <div
            class="text-[18px] px-[20px] cursor-pointer h-full flex items-center font-semibold p-3"
          >
            {{ dm.tenDanhMuc }}
          </div>
        </div>
      </div>
    </div>
    <navbar />
    <main class="profile-page">
      <section class="relative block">
        <div
          class="top-auto bottom-0 left-0 right-0 w-full absolute pointer-events-none overflow-hidden h-70-px"
          style="transform: translateZ(0)"
        ></div>
      </section>

      <!-- component -->
      <div class="text-gray-900 pt-12 pr-0 pb-14 pl-0 bg-white">
        <div
          class="w-full pt-4 pr-5 pb-6 pl-5 mt-0 mr-auto mb-0 ml-auto space-y-5 sm:py-8 md:py-12 sm:space-y-8 md:space-y-16 max-w-7xl"
        >
          <div class="flex flex-col items-center sm:px-5 md:flex-row">
            <div
              class="flex flex-col items-start justify-center w-full h-full pt-6 pr-0 pb-6 pl-0 mb-6 md:mb-0 md:w-1/2"
            >
              <div
                class="flex flex-col items-start justify-center h-full space-y-3 transform md:pr-10 lg:pr-16 md:space-y-5"
              >
                <div
                  class="bg-green-500 flex items-center leading-none rounded-full text-gray-50 pt-1.5 pr-3 pb-1.5 pl-2 uppercase inline-block"
                >
                  <p class="inline text-xs font-medium">Mới nhất Nè</p>
                </div>
                <a
                  @click="handleClick"
                  class="text-4xl font-bold leading-none lg:text-5xl xl:text-6xl"
                  >Hoa quả tươi ? Có tốt cho sức khỏe</a
                >
                <div class="pt-2 pr-0 pb-0 pl-0">
                  <p class="text-sm font-medium inline">Tác giả:</p>
                  <a
                    class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1 underline"
                    >Hidden</a
                  >
                  <p class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1">
                    · 31/03/2023 ·
                  </p>
                  <p
                    class="text-gray-200 text-sm font-medium inline mt-0 mr-1 mb-0 ml-1"
                  >
                    1h 20p
                  </p>
                </div>
              </div>
            </div>
            <div class="w-full md:w-1/2">
              <div class="block">
                <img
                  src="https://images.unsplash.com/photo-1626314928277-1d373ddb6428?ixlib=rb-1.2.1&amp;ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8Mzd8fHxlbnwwfHx8fA%3D%3D&amp;auto=format&amp;fit=crop&amp;w=500&amp;q=60"
                  class="object-cover rounded-lg max-h-64 sm:max-h-96 btn- w-full h-full"
                />
              </div>
            </div>
          </div>
          <div class="grid grid-cols-12 sm:px-5 gap-x-8 gap-y-16">
            <div
              v-for="baitin in datas"
              class="flex flex-col items-start col-span-12 space-y-3 sm:col-span-6 xl:col-span-4"
              @click="handleClick(baitin.slug)"
            >
              <img
                src="https://images.unsplash.com/photo-1626318305863-bb23d0297c0b?ixlib=rb-1.2.1&amp;ixid=MnwxMjA3fDB8MHxleHBsb3JlLWZlZWR8MXx8fGVufDB8fHx8&amp;auto=format&amp;fit=crop&amp;w=500&amp;q=60"
                class="object-cover w-full mb-2 overflow-hidden rounded-lg shadow-sm max-h-56 btn-"
              />
              <p
                class="bg-green-500 flex items-center leading-none text-sm font-medium text-gray-50 pt-1.5 pr-3 pb-1.5 pl-3 rounded-full uppercase inline-block"
              >
                {{ baitin.slug }}
              </p>
              <a class="text-lg font-bold sm:text-xl md:text-2xl">{{
                baitin.tieuDe
              }}</a>
              <p class="text-sm text-black">
                Tin tức mới nhất về Liverpool: Thông tin, hình ảnh, sự kiện và
                video nổi bật liên quan Liverpool được cập nhật nhanh và liên
                tục.
              </p>
              <div class="pt-2 pr-0 pb-0 pl-0">
                <p class="text-sm font-medium inline">Tác giả:</p>
                <a
                  class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1 underline"
                  >{{ baitin.createdBy }}</a
                >
                <p class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1">
                  · {{ baitin.createdDate }} ·
                </p>
                <p
                  class="text-gray-200 text-sm font-medium inline mt-0 mr-1 mb-0 ml-1"
                >
                  1h 20p
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </main>
    <footer-component />
  </div>
</template>
<script setup>
import { useRouter } from "vue-router";
import HeaderDefault from "~~/components/Headers/HeaderDefault.vue";
const router = useRouter();
const datas = ref([]);
const newBaiTin = ref({});

const danhMuc = ref([]);
const selectedDanhMuc = ref(0);
definePageMeta({
  name: "Post",
});
onMounted(() => {
  getBaiTinPhanTrang()
    .then((res) => {
      datas.value = res?.data?.data?.items;
      console.log(datas.value);
    })
    .catch(() => {});
  getAllDanhMucBaiTin()
    .then((res) => {
      danhMuc.value = res?.data?.data?.items;
    })
    .catch(() => {});
});
const selectCategory = (idDanhMucBaiTin) => {
  console.log("push");
  router.push({ name: "PostDanhMuc", params: { id: idDanhMucBaiTin } });
};
const handleClick = (slug) => {
  console.log("click");

  router.push({ name: "PostDetail", params: { slug: slug } });
};
</script>
