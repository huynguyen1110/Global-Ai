<template>
  <div class="flex w-full flex-wrap relative">
    <div class="w-full overflow-hidden">
      <div class="slider w-full flex justify-center items-center">
        <button
          class="prev-button w-12 h-12 rounded-full ml-5 flex items-center justify-center"
          @click="prevImage"
        >
          <font-awesome-icon :icon="['fas', 'angle-left']" />
        </button>
        <button
          class="next-button w-12 h-12 rounded-full mr-5 flex items-center justify-center"
          @click="nextImage"
        >
          <font-awesome-icon :icon="['fas', 'angle-right']" />
        </button>
        <div
          class="images-container w-full"
          :style="{
            transform: 'translateX(' + -currentImage * 100 + '%)',
          }"
          ref="imagesContainer"
        >
          <img
            v-for="(image, index) in images"
            :key="index"
            :src="image"
            :class="{ active: currentIndex === index }"
            alt="Slider Image"
            class="w-full rounded-2xl"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed } from "vue";
import imgShopping from "~~/assets/img/Home/banner-slider.jpg";

definePageMeta({
  layout: "layout-default",
});

const images = [
  imgShopping
];

let currentIndex = ref(0);

function nextImage() {
  currentIndex.value++;
  if (currentIndex.value >= images.length) {
    currentIndex.value = 0;
  }
  // Thêm dòng sau để di chuyển đến ảnh mới
  if (imagesContainer.value) {
    imagesContainer.value.style.transform =
    "translateX(" + -currentIndex.value * 100 + "%)";
  }
}

function prevImage() {
  currentIndex.value--;
  if (currentIndex.value < 0) {
    currentIndex.value = images.length - 1;
  }
  // Thêm dòng sau để di chuyển đến ảnh mới
  if (imagesContainer.value) {
    
    imagesContainer.value.style.transform =
    "translateX(" + -currentIndex.value * 100 + "%)";
  }
}
function setCurrentIndex(index) {
  currentIndex.value = index;
  if (imagesContainer.value) {
    
    imagesContainer.value.style.transform =
      "translateX(" + -currentIndex.value * 100 + "%)";
  }
}

const currentImage = computed(() => images[currentIndex.value]);
setInterval(() => {
  setCurrentIndex((currentIndex.value + 1) % images.length);
}, 5000);

// Lấy ra phần tử .images-container vào biến imagesContainer
const slider = ref(null);
const imagesContainer = ref(null);
onMounted(() => {
  console.log(slider.value);
  console.log(imagesContainer.value);
});
watchEffect(() => {
  if (slider.value && imagesContainer.value) {
    imagesContainer.value = slider.value.querySelector(".images-container");
  }
});
</script>
<style scoped>
.slider {
  position: relative;
  width: 100%;
}

.prev-button,
.next-button {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  z-index: 2;
  padding: 10px;
  border: none;
  background-color: rgba(255, 255, 255, 0.5);
  color: black;
  font-size: 20px;
  cursor: pointer;
}

.prev-button {
  left: 0;
}

.next-button {
  right: 0;
}

.images-container {
  width: 100%;
  display: flex;
  transition: all 0.3s ease-in-out;
}

.images-container img {
  width: auto;
  max-width: 100%;
  height: auto;
  max-height: 100%;
  flex-shrink: 0;
  transition: opacity 0.3s ease-in-out;
}

.images-container img.active {
  opacity: 1;
}

button:hover {
  background-color: rgba(255, 255, 255, 0.8);
}

.active {
  width: 100%;
  height: auto;
}
</style>
