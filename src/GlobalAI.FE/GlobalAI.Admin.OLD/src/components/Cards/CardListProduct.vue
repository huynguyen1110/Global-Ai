<template>
    <div class="relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-lg rounded p-5">
        <!-- SẢN PHẨM MỚI -->
        <div>
            <div class="flex flex-row justify-between items-center">
                <h3 class="uppercase text-2xl font-semibold">{{ props.title }}</h3>
                
            </div>
            <div class="flex flex-wrap">
                <div v-for="(item, idx) in products" :key="idx" class="border lg:w-1/5 mx-0.3 rounded-xl my-1 flex flex-col justify-between">
                    <div class=" w-full rounded-t-xl">
                        <img class="block h-30 w-full object-cover " :src=item.imgUrl alt="" />
                        <p class="mt-3 font-bold px-3">{{item.name}}</p>
                    </div>
                    <div class=" justify-center my-3 px-3">
                        <!-- <p class="mt-3 font-bold">{{item.name}}</p> -->
                        <p class="mt-3 text-sm "><span class="text-red-500 font-bold ">$</span><span class="font-semibold">Giá Bán:</span> <spnan class="italic">{{item.price}}</spnan></p>
                        <p class="mt-3 text-sm "><span class="text-red-500 font-bold ">$</span><span class="font-semibold">Chiết Khấu:</span> <spnan class="italic">{{item.discount}}</spnan></p>
                        <div class="mt-3 flex justify-center">
                            <button @click="detail"
                            class="bg-emerald-600 text-white active:bg-slate-600 text-sm font-semibold px-4 py-2 rounded shadow hover:bg-amber-600 outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
                            type="button"
                        >
                            Chi tiết
                        </button>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { useRouter } from 'vue-router'
const router = useRouter()

const props = defineProps({
    title: {
        type: String,
    },
    products:{
        name: String,
        imgUrl: String,
        price: String,
        discount: String
    }
})
const detail = () => {
    router.push({name: 'ProductDetail',params: { id: '1' }})
}
</script>
  