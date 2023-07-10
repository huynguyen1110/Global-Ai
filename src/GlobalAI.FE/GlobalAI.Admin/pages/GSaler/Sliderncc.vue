<template>
  <div class="w-full overflow-hidden">
    <div class="slider w-full flex justify-center items-center">
      <button
        class="hover:bg-[rgba(255, 255, 255, 0.8)] sm:w-12 sm:h-12 w-[30px] h-[30px] prev-button rounded-full ml-5 mt-5 flex items-center justify-center"
        @click="prevImage"
      >
        <font-awesome-icon :icon="['fas', 'angle-left']" />
      </button>
      <button
        class="next-button w-12 h-12 sm:w-12 sm:h-12 w-[30px] h-[30px] rounded-full mr-5 mt-5 flex items-center justify-center"
        @click="nextImage"
      >
        <font-awesome-icon :icon="['fas', 'angle-right']" />
      </button>
      <div
        class="images-container w-full flex justify-between"
        :style="{
          transform:
            'translateX(' + -currentIndex * (100 / slidesToShow) + '%)',
        }"
        ref="imagesContainer"
      >
        <div
          class="cursor-pointer hover:bg-[rgba(255, 255, 255, 0.8)] w-[25%] px-[12px] max-h-full flex-shrink-0 opacity-2 ease-in-out"
          v-for="(image, index) in images"
          :key="index"
          @click="goToSupplierPage"
        >
          <img
            :src="image"
            :class="{ active: currentIndex === index }"
            alt="Slider Image"
            class="w-full rounded-2xl object-cover"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import imgBanChayNhat from "~~/assets/img/Home/ban-chay-nhat.jpg";
import imgDanhGiaCao from "~~/assets/img/Home/danh-gia-cao.jpg";
import imgMoiThamGia from "~~/assets/img/Home/moi-tham-gia.jpg";
import imgXacThuc from "~~/assets/img/Home/xac-thuc.jpg";
import imgFreeShip from "~~/assets/img/Home/freeship-den-80k.jpg";
import { useRouter } from "vue-router";



const images = [
imgBanChayNhat,
imgDanhGiaCao,
imgMoiThamGia,
imgXacThuc,
imgFreeShip
];

const slidesToShow = 4;
const slidesToScroll = 1;
const router = useRouter();
let currentIndex = ref(0);

function nextImage() {
  currentIndex.value += slidesToScroll;
  if (currentIndex.value + slidesToShow >= images.length + 1) {
    console.log("Reset");
    console.log(currentIndex.value, images.length);
    currentIndex.value = 0;
  }
  
  // Thêm dòng sau để di chuyển đến ảnh mới
  imagesContainer.value.style.transform =
    "translateX(" + -currentIndex.value * (100 / slidesToShow) + "%)";
}

function prevImage() {
  currentIndex.value -= slidesToScroll;
  if (currentIndex.value - slidesToShow < 0) {
    currentIndex.value = images.length - 4;
  }
  // Thêm dòng sau để di chuyển đến ảnh mới
  imagesContainer.value.style.transform =
    "translateX(" + -currentIndex.value * (100 / slidesToShow) + "%)";
}

const currentImage = computed(() => images[currentIndex.value]);

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

const goToSupplierPage = () => {
    router.push({
      name:"SupplierPage",
      query:{collectionId : '1'}
    })
}

</script>

<style>
.slider {
  position: relative;
}

.prev-button,
.next-button {
  position: absolute;
  top: 50%;
  transform: translateY(-100%);
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
  width: calc((100% / 6) * 12);
  margin: 0 -12px;
  display: flex;
  transition: all 0.3s ease-in-out;
}

/* .images-container div {
      width: 25%;
      padding: 0 12px;
      max-height: 100%;
      flex-shrink: 0;
      transition: opacity 0.3s ease-in-out;
    }
    .images-container div img {
      object-fit: cover;
      height: 200px;
    } */

.images-container img.active {
  opacity: 1;
}
.active {
  width: 100%;
  height: auto;
}

</style>
