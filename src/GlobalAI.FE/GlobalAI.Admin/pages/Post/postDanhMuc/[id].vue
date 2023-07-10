<template>
    <div class="flex flex-col">

        <navbar />
        <main class="profile-page">
            <section class="relative block">
                <div class="top-auto bottom-0 left-0 right-0 w-full absolute pointer-events-none overflow-hidden h-70-px"
                    style="transform: translateZ(0)"></div>
            </section>
            <!-- component -->
            <div class="text-gray-900 pt-12 pr-0 pb-14 pl-0 bg-white">
                <div
                    class="w-full pt-4 pr-5 pb-6 pl-5 mt-0 mr-auto mb-0 ml-auto space-y-5 sm:py-8 md:py-12 sm:space-y-8 md:space-y-16 max-w-7xl">
                    <div class="flex flex-col items-center sm:px-5 md:flex-row">
                        <div
                            class="flex flex-col items-start justify-center w-full h-full pt-6 pr-0 pb-6 pl-0 mb-6 md:mb-0 md:w-2/3">
                            <div
                                class="flex flex-col items-start justify-center h-full space-y-3 transform md:pr-10 lg:pr-16 md:space-y-5">
                                <div
                                    class="bg-green-500 flex items-center leading-none rounded-full text-gray-50 pt-1.5 pr-3 pb-1.5 pl-2 uppercase inline-block">
                                    <p class="inline text-xs font-medium">
                                        Danh mục bài viết
                                    </p>
                                </div>
                                <a class="text-4xl font-bold leading-none lg:text-5xl xl:text-6xl">{{ danhMuc.tenDanhMuc }}</a>
                                <div class="pt-2 pr-0 pb-0 pl-0">
                                    <p class="text-sm font-medium inline">
                                        Tác giả: 
                                    </p>
                                    <a class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1 underline">Admin</a>
                                    <p class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1">
                                        · 31/03/2023 ·
                                    </p>
                                    <p class="text-gray-200 text-sm font-medium inline mt-0 mr-1 mb-0 ml-1">
                                    </p>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="grid grid-cols-12 sm:px-5 gap-x-8 gap-y-16">
                        <div v-for="baitin in datas"
                            class="flex flex-col items-start col-span-12 space-y-3 sm:col-span-6 xl:col-span-4"
                            @click="handleClick(baitin.slug)">
                            <img :src="`${baseUrl}/${baitin.thumbnail}`"
                                class="object-cover w-full mb-2 overflow-hidden rounded-lg shadow-sm max-h-56 btn-" />
                            
                            <p
                                class="bg-green-500 flex items-center leading-none text-sm font-medium text-gray-50 pt-1.5 pr-3 pb-1.5 pl-3 rounded-full uppercase inline-block">
                                Blog
                            </p>
                            <div class="flex flex-col h-full items-start justify-between">
                                <div class="">
                            <a :href="`/post/postdetail/${baitin.slug}`" class="text-lg font-bold sm:text-xl md:text-2xl">{{
                                baitin.tieuDe }}</a>
                            </div>
                            <p class="text-sm text-black">
                                    {{ baitin.moTa }}
                                </p>
                            <div class="pt-2 pr-0 pb-0 pl-0">
                                <p class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1">
                                    {{
                                $moment(baitin.cretedDate).format("MMM Do YYYY")
                  
              }}
                                </p>
                                <p class="text-sm font-medium inline">
                                    Tác giả:
                                </p>
                                <a class="inline text-sm font-medium mt-0 mr-1 mb-0 ml-1 underline">{{ baitin.createdBy
                                }}</a>
                                
                                <p class="text-gray-200 text-sm font-medium inline mt-0 mr-1 mb-0 ml-1">

                                </p>
                            </div>
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
const config = useRuntimeConfig();
const baseUrl = config.public.apiEndpoint;
const { $moment } = useNuxtApp();
const datas = ref([]);
const newBaiTin = ref({});
const idDanhMucBaiTin = ref([]);
const danhMuc = ref([]);
const selectedDanhMuc = ref(0);
definePageMeta({
    layout: "layout-blog",
    name: "PostDanhMuc",
});
onMounted(() => {
    console.log(router.currentRoute.value.params.id);
    
    getPostCategoryById(router.currentRoute.value.params.id)
    .then((res) => {
            danhMuc.value = res.data;
            console.log('danhmuc',danhMuc.value)
        })
        .catch(() => { 
        });

    getBaiTinTheoDanhMuc(router.currentRoute.value.params.id, 15, 1,0)
        .then((res) => {
            datas.value = res?.data?.data.items;
            console.log('baitin', datas.value)
        })
        .catch(() => { });
    console.log('sadasdsa')

});

const selectCategory = (idDanhMucBaiTin) => {
    router.push({ name: "PostDanhMuc", params: { id: idDanhMucBaiTin } });
};
const handleClick = (slug) => {
    console.log("click");

    router.push({ name: "PostDetail", params: { slug: slug } });
};
</script>
