<template>
  <div class="flex justify-center">
    <nav aria-label="Page navigation example ">
      <ul class="flex items-center -space-x-px">
        <li>
          <button
          :disabled="pageNumber === 1"
          @click="prevPage"
           class="block px-3 py-2 ml-0 leading-tight text-gray-500 bg-white border border-gray-300 rounded-l-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white" > <img class="w-5 h-5" src="~/assets/Previous.svg" alt="icon" /></button>
        </li>
        <div v-for="pages in totalPages" :key="pages">
          <li>
            <button class="block px-3 py-2 ml-0 leading-tight text-gray-500 bg-white border border-gray-300  hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white" @click="buttonPage(pages)">{{ pages }}</button>
          </li>
        </div>
        <li>
          <button
            class="block px-3 py-2 leading-tight text-gray-500 bg-white border border-gray-300 rounded-r-lg hover:bg-gray-100 hover:text-gray-700 "
            @click="nextPage"
            :disabled="pageNumber === totalPages"
          >
            <span class="sr-only">Next</span>
            <svg
              aria-hidden="true"
              class="w-5 h-5"
              fill="currentColor"
              viewBox="0 0 20 20"
              xmlns="http://www.w3.org/2000/svg"
            >
              <path
                fill-rule="evenodd"
                d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z"
                clip-rule="evenodd"
              ></path>
            </svg>
          </button>
        </li>
      </ul>
    </nav>
  </div>
</template>
<script setup>
import { defineEmits } from "vue";
const props = defineProps({
  pageNumber: {
    type: Number,
    required: true,
  },
  totalPages: {
    type: Number,
    required: true,
  },
  nextPage: {
    type: Function,
    required: true,
  },
  prevPage: {
    type: Function,
    required: true,
  },
});
const emits = defineEmits(["click-page"]);
const buttonPage = (page) => {
  emits("click-page", page);
};
</script>