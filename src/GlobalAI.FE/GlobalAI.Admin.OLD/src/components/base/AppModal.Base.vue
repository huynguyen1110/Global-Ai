<style lang="scss" scoped>
    @import url('app-modal-base.css');
</style>
<template>
    <vue-final-modal v-model="show" :name="props.name" classes="modal-container m-auto md:my-3" content-class="modal-content w-full md:w-96" :click-to-close="false">
        <button class="modal__close" @click="$vfm.hide(props.name)">
            <font-awesome-icon icon="fa-solid fa-close" />
        </button>
        <span class="modal__title">{{ props.title }}</span>
        <hr class="my-2 h-px bg-gray-200 border-0 dark:bg-gray-700">
        <div class="modal__content overflow-y-scroll">
            <slot name="content" />
        </div>
    </vue-final-modal>
</template>
<script setup>
import { ref, defineProps } from 'vue';
import { $vfm, VueFinalModal } from 'vue-final-modal';
    let show = ref(false);
    const props = defineProps({
        name: String,
        title: String,
    });
</script>
