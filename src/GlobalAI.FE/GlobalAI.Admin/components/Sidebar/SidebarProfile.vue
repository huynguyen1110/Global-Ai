<template>
    <aside 
        class="transition-transform lg:translate-x-0"
        :class="props.showMenu" 
    >
        <div class="h-full px-3 py-4 overflow-y-auto bg-gray-50 dark:bg-gray-800">
            <div class="flex justify-end lg:hidden">
                <button 
                    class="text-2xl"
                    @click="handleClose"
                >
                <font-awesome-icon :icon="['fass', 'xmark']" />
                </button>
            </div>
            <ul class="space-y-2 font-medium text-[14px]">
                <li>
                    <a href="#" class="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700">
                    <div class="pl-3 pr-8">
                        <font-awesome-icon :icon="['fass', 'pen-to-square']" />
                    </div>
                        Sửa thông tin 
                    </a>
                </li>
                <li>
                    <a href="#" class="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700">
                    <div class="pl-3 pr-8 text-green-500">
                        <font-awesome-icon :icon="['fass', 'circle-info']" />
                    </div>
                        Cập nhật mật khẩu
                    </a>
                </li>
                <li>
                    <a href="#" class="flex items-center p-2 text-gray-900 rounded-lg dark:text-white hover:bg-gray-100 dark:hover:bg-gray-700">
                    <div class="pl-3 pr-8 text-red-500" >
                        <font-awesome-icon :icon="['fass', 'trash']" />
                    </div>
                        Xóa tài khoản
                    </a>
                </li>
            </ul>
        </div>
    </aside>
</template>
<script setup>
import image from "@/assets/img/team-1-800x800.jpg";
import {ref, toRef } from "vue"
import { boolean, string } from "yup";
const showMenu = ref("")
const props = defineProps({
    showMenu:{
        type:String,
        default: '-translate-x-full'
    }
})

const emits= defineEmits(['handleClose'])

const handleClose = () => {
    emits('handleClose')
}
</script>
  