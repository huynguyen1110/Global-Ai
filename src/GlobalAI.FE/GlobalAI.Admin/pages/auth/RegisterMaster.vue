<template>
  <div class="">
    <div class="flex content-center items-center justify-center h-full">
      <div class="w-full flex flex-col lg:flex-row space-x-0 lg:space-x-4">
        <div
          class="container min-h-full"
          :class="{ 'right-panel-active': active }"
          id="container"
        >
          <div class="form-container sign-up-container">
            <!-- G.STORE -->
            <div
              class="relative h-full flex flex-col justify-between min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-slate-200 border-0"
            >
              <div class="rounded-t mb-0 px-6 py-6">
                <div class="text-center mb-3">
                  <h6 class="text-slate-500 text-sm lg:text-3xl font-bold">
                    Gstore
                  </h6>
                </div>
                <div class="mb-3 p-5">
                  <p class="flex gap-2 items-center">
                    <font-awesome-icon :icon="['fas', 'arrow-right']" /> Là nhà
                    cung cấp
                  </p>
                  <p class="flex gap-2 items-center">
                    <font-awesome-icon :icon="['fas', 'arrow-right']" />Có nhu
                    cầu quảng bá và bán các sản phẩm.
                  </p>
                  <p class="flex gap-2 items-center">
                    <font-awesome-icon :icon="['fas', 'arrow-right']" />Cung cấp
                    các sản phẩm với giá chiết khấu cho G.saler
                  </p>
                </div>
              </div>
              <div class="px-4 lg:px-10 py-10 pt-0">
                <div class="text-center mt-6">
                  <nuxt-link
                    to="/auth/registergstore"
                    class="bg-gradient-to-br from-slate-800 to-gray-900 inline-block text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                  >
                    Đăng ký
                  </nuxt-link>
                </div>
              </div>
            </div>
          </div>
          <div class="form-container sign-in-container">
            <!-- G.SALER -->
            <div
              class="relative h-full flex flex-col justify-between min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-slate-200 border-0"
            >
              <div class="rounded-t mb-0 px-6 py-6">
                <div class="text-center mb-3">
                  <h6 class="text-slate-500 text-sm lg:text-3xl font-bold">
                    Gsaler
                  </h6>
                </div>

                <div class="mb-3 p-5">
                  <p class="flex gap-2 items-center">
                    <font-awesome-icon :icon="['fas', 'arrow-right']" /> Là nhà
                    phân phối
                  </p>
                  <p class="flex gap-2 items-center">
                    <font-awesome-icon :icon="['fas', 'arrow-right']" />Mua hàng
                    với giá chiết khấu từ G.store.
                  </p>
                  <p class="flex gap-2 items-center">
                    <font-awesome-icon :icon="['fas', 'arrow-right']" />Sau khi
                    đăng ký tài khoản có thể trực tiếp mua hàng luôn.
                  </p>
                </div>
              </div>
              <div class="px-4 lg:px-10 py-10 pt-0">
                <div class="text-center mt-6">
                  <nuxt-link
                    to="/auth/registergsaler"
                    class="bg-gradient-to-br from-slate-800 to-gray-900 inline-block text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                  >
                    Đăng ký
                  </nuxt-link>
                </div>
              </div>
            </div>
          </div>
          <div
            class="overlay-container bg-gradient-to-br from-slate-800 to-gray-900"
          >
            <div class="overlay">
              <div class="overlay-panel overlay-left flex gap-10">
                <div class="flex flex-col gap-1">
                  <h1 class="text-5xl font-bold">G.sales</h1>
                  <p>
                    Là nhà phân phối, mua hàng với giá chiết khấu từ G.store,
                    sau khi đăng ký tài khoản có thể trực tiếp mua hàng luôn.
                  </p>
                </div>
                <div>
                  <button
                    @click="addActive"
                    class="bg-[#E2E8F0] inline-block text-black active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                  >
                    <font-awesome-icon :icon="['fas', 'arrow-right']" /> Đi đến
                  </button>
                </div>
              </div>
              <div class="overlay-panel overlay-right flex gap-10">
                <div class="flex flex-col gap-1">
                  <h1 class="text-5xl font-bold">G.store</h1>
                  <p>
                    Là nhà cung cấp có nhu cầu quảng bá và bán các sản phẩm,
                    cung cấp các sản phẩm với giá chiết khấu cho G.saler
                  </p>
                </div>

                <div>
                  <button
                    @click="addActive"
                    class="bg-[#E2E8F0] inline-block text-black active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                  >
                    <font-awesome-icon :icon="['fas', 'arrow-right']" /> Đi đến
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
definePageMeta({
  layout: "auth",
});
import { ref } from "vue";

const container = ref(null);

const active = ref(false);

const addActive = () => {
  active.value = !active.value;
};
</script>

<style scoped>
button:active {
  transform: scale(0.95);
}

button:focus {
  outline: none;
}

button.ghost {
  background-color: transparent;
  border-color: #ffffff;
}

.container {
  background-color: #fff;
  border-radius: 10px;
  box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 10px 10px rgba(0, 0, 0, 0.22);
  position: relative;
  max-width: 100%;
  min-height: 480px;
}

.form-container {
  position: absolute;
  top: 0;
  height: 100%;
  transition: all 0.6s ease-in-out;
}

.sign-in-container {
  left: 0;
  width: 50%;
  z-index: 2;
}

.container.right-panel-active .sign-in-container {
  transform: translateX(100%);
}

.sign-up-container {
  left: 0;
  width: 50%;
  opacity: 0;
  z-index: 1;
}

.container.right-panel-active .sign-up-container {
  transform: translateX(100%);
  opacity: 1;
  z-index: 5;
  animation: show 0.6s;
}

@keyframes show {
  0%,
  49.99% {
    opacity: 0;
    z-index: 1;
  }

  50%,
  100% {
    opacity: 1;
    z-index: 5;
  }
}

.overlay-container {
  position: absolute;
  top: 0;
  left: 50%;
  width: 50%;
  height: 100%;
  overflow: hidden;
  transition: transform 0.6s ease-in-out;
  z-index: 100;
}

.container.right-panel-active .overlay-container {
  transform: translateX(-100%);
}

.overlay {
  background-repeat: no-repeat;
  background-size: cover;
  background-position: 0 0;
  color: #ffffff;
  position: relative;
  left: -100%;
  height: 100%;
  width: 200%;
  transform: translateX(0);
  transition: transform 0.6s ease-in-out;
}

.container.right-panel-active .overlay {
  transform: translateX(50%);
}

.overlay-panel {
  position: absolute;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  padding: 0 40px;
  text-align: center;
  top: 0;
  height: 100%;
  width: 50%;
  transform: translateX(0);
  transition: transform 0.6s ease-in-out;
}

.overlay-left {
  transform: translateX(-20%);
}

.container.right-panel-active .overlay-left {
  transform: translateX(0);
}

.overlay-right {
  right: 0;
  transform: translateX(0);
}

.container.right-panel-active .overlay-right {
  transform: translateX(20%);
}
</style>
