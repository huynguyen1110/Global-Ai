<template>
    <div :class="containerClass">
        <label :for="props.name" class="block mb-2 text-sm font-medium text-gray-900 dark:text-white">
            {{ props.label }}</label>
        <vue-number :name="props.name" v-model="props.modelValue" v-bind="options" @keyup="$event => onChange($event)"
            class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></vue-number>
    </div>
</template>

<script setup>
const props = defineProps({
    label: {
        type: String,
        required: true,
    },
    name: String,
    modelValue: {
        type: String,
        required: true,
    },
    containerClass: String,
    options: {
        type: Object,
        default: () => ({
            decimal: '.',
            separator: ',',
            prefix: '',
            suffix: ' VNĐ',
            precision: 2,
            nullValue: 0,
            masked: false,
        })
    }
});
const emits = defineEmits(['update:modelValue']);

const onChange = ($event) => {
    emits('update:modelValue', $event.target.value);
}

</script>