<template>
  <div class="container mx-auto px-4 h-full">
    <div class="flex content-center items-center justify-center h-full">
      <div class="w-full flex flex-col lg:flex-row space-x-0 lg:space-x-4">
        <!-- G.STORE -->
        <div
          class="relative flex flex-col justify-between min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-slate-200 border-0">
          <div class="rounded-t mb-0 px-6 py-6">
            <div class="text-center mb-3">
              <h6 class="text-slate-500 text-sm lg:text-3xl font-bold">
                Gstore
              </h6>
            </div>
            <div class="mb-3 p-5">
              <p><span class="font-bold">G.store</span> là nhà cung cấp</p>
              <p>
                Có nhu cầu quảng bá và bán các sản phẩm. <br />
                Cung cấp các sản phẩm với giá chiết khấu cho G.saler
              </p>
            </div>
          </div>
          <div class="px-4 lg:px-10 py-10 pt-0">
            <div class="text-center mt-6">
              <button
                class="bg-slate-800 text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150"
                type="button" v-on:click="toggleModal()">
                Đăng ký
              </button>
            </div>
          </div>
        </div>
        <!-- G.SALER -->
        <div
          class="relative flex flex-col justify-between min-w-0 break-words w-full mb-6 shadow-lg rounded-lg bg-slate-200 border-0">
          <div class="rounded-t mb-0 px-6 py-6">
            <div class="text-center mb-3">
              <h6 class="text-slate-500 text-sm lg:text-3xl font-bold">
                Gsaler
              </h6>
            </div>
            <div class="mb-3 p-5">
              <p><span class="font-bold">G.saler</span> là nhà phân phối</p>
              <p>
                Mua hàng với giá chiết khấu từ G.store. <br />
                Sau khi đăng ký tài khoản có thể trực tiếp mua hàng luôn.
              </p>
            </div>
          </div>
          <div class="px-4 lg:px-10 py-10 pt-0">
            <div class="text-center mt-6">
              <router-link to="/auth/register/gsaler"
                class="bg-slate-800 inline-block text-white active:bg-slate-600 text-sm font-bold uppercase px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 w-full ease-linear transition-all duration-150">
                Đăng ký
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div>

    <div v-if="showModal"
      class="  fixed inset-0 z-50 outline-none focus:outline-none justify-center items-center flex">
      <div class="relative w-auto my-6 mx-auto max-w-6xl">
        <!--content-->
        <div class="border-0 rounded-lg shadow-lg relative flex flex-col w-full bg-white outline-none focus:outline-none">
          <!--header-->
          <div class="flex items-start justify-between p-5 border-b border-solid border-slate-200 rounded-t">
            <h3 class="text-2xl font-semibold">
              Thêm mới
            </h3>
            <button
              class="p-1 ml-auto bg-transparent border-0 text-black opacity-100 float-right text-3xl leading-none font-semibold outline-none focus:outline-none"
              v-on:click="toggleModal()">
              <span
                class="bg-transparent text-black-500 opacity-1000 h-6 w-6 text-2xl block outline-none focus:outline-none">
                ×
              </span>
            </button>
          </div>
          <!--body-->
          <div class="relative p-3 flex-auto">
            <div class="-mx-3 flex flex-wrap">
              <div class="w-full px-3 sm:w-1/2">
                <div class="mb-5">
                  <label for="date" class="mb-3 block text-base font-medium text-[#07074D]">
                    Tên sản phẩm
                  </label>
                  <input id="name"
                    class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
                    placeholder="Nhập sản phẩm" />
                  
                </div>
              </div>
              <div class="w-full px-3 sm:w-1/2">
                <div class="mb-5">
                  <label for="time" class="mb-3 block text-base font-medium text-[#07074D]">
                    Giá sản phẩm
                  </label>
                  <input id="name"
              class="mb-3 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border"
              placeholder="Nhập sản phẩm" />
                </div>
              </div>
            </div>

<div class="w-full relative grid grid-cols-1 md:grid-cols-3 border border-gray-300 bg-gray-100 rounded-lg">
    <div
        class="rounded-l-lg p-4 bg-gray-200 flex flex-col justify-center items-center border-0 border-r border-gray-300 ">
        <label class="cursor-pointer hover:opacity-80 inline-flex items-center shadow-md my-2 px-2 py-2 bg-gray-900 text-gray-50 border border-transparent
        rounded-md font-semibold text-xs uppercase tracking-widest hover:bg-gray-700 active:bg-gray-900 focus:outline-none 
       focus:border-gray-900 focus:ring ring-gray-300 disabled:opacity-25 transition ease-in-out duration-150" for="restaurantImage">
           
    Chọn ảnh đại diện
            <input id="restaurantImage" class="text-sm cursor-pointer w-36 hidden" type="file">
        </label>

    </div>
    <div 
        class="relative order-first md:order-last h-28 md:h-auto flex justify-center items-center border border-dashed border-gray-400 col-span-2 m-2 rounded-lg bg-no-repeat bg-center bg-origin-padding bg-cover">
            <span class="text-gray-400 opacity-75">
                <svg class="w-14 h-14"  xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="0.7" stroke="currentColor">
             <path stroke-linecap="round" stroke-linejoin="round"
                d="M2.25 15.75l5.159-5.159a2.25 2.25 0 013.182 0l5.159 5.159m-1.5-1.5l1.409-1.409a2.25 2.25 0 013.182 0l2.909 2.909m-18 3.75h16.5a1.5 1.5 0 001.5-1.5V6a1.5 1.5 0 00-1.5-1.5H3.75A1.5 1.5 0 002.25 6v12a1.5 1.5 0 001.5 1.5zm10.5-11.25h.008v.008h-.008V8.25zm.375 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z" />
            </svg>
            </span>
    </div>
</div>

            <div class="-mx-3 mt-3 flex flex-wrap">
              <div class="w-full px-3 sm:w-1/2">
                <div class="mb-5">
                  <label for="date" class="mb-3 block text-base font-medium text-[#07074D]">
                    Ngày bán
                  </label>
                  <input type="date" name="date" id="date"
                    class="mb-5 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border" />
                </div>
              </div>
              <div class="w-full px-3 sm:w-1/2">
                <div class="mb-5">
                  <label for="time" class="mb-3 block text-base font-medium text-[#07074D]">
                    Thời gian bán
                  </label>
                  <input type="time" name="time" id="time"
                    class="mb-5 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-10 flex items-center pl-3 text-sm border-gray-300 rounded border" />
                </div>
              </div>
            </div>
            <label for="name" class="text-gray-800 text-sm font-bold leading-tight tracking-normal">Mô tả</label>
            <textarea type="text" name="" placeholder="Nhập mô tả"
              class="p-5 mb-5 mt-2 text-gray-600 focus:outline-none focus:border focus:border-indigo-700 font-normal w-full h-12 flex items-center pl-3 text-sm border-gray-300 rounded border"
              id=""></textarea>
            <div class="flex items-center mt-5 mb-3 space-x-4">
              <input class="inline-flex rounded-full" type="checkbox" id="check1" name="check1" />
              <label class="inline-flex font-semibold text-gray-400" for="check1">
                Sản phẩm có số lượng lớn</label><br />
              <input class="inline-flex" type="checkbox" id="check2" name="check2" checked />
              <label class="inline-flex font-semibold text-blue-500" for="check2">
                Sản phẩm chất lượng cao</label><br />
            </div>
          </div>
          <!--footer-->
          <div class="flex items-center justify-end p-6 border-t border-solid border-slate-200 rounded-b">

            <button
              class=" focus:outline-none focus:ring-2 focus:ring-offset-2  focus:ring-gray-400 ml-3 bg-gray-100 transition duration-150 text-gray-600 ease-in-out hover:border-gray-400 hover:bg-gray-300 border rounded px-8 py-2 text-sm"
              v-on:click="toggleModal()">Hủy</button>

            <button
              class="ml-3 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-700 transition duration-150 ease-in-out hover:bg-indigo-600 bg-indigo-700 rounded text-white px-8 py-2 text-sm">
                      Lưu lại</button>
          </div>
        </div>
      </div>
    </div>
    <div v-if="showModal" class="opacity-25 fixed inset-0 z-40 bg-black"></div>
  </div>
</template>
<script >
import github from "../../assets/img/github.svg";
import google from "../../assets/img/google.svg";


export default {
  data() {
    return {
      github,
      google,
      showModal: false
    };
  },
  methods: {
    toggleTabs: function (tabNumber) {
      this.openTab = tabNumber
    },

    seeMore: function (event) {
      this.more = event;
    },

    toggleModal: function () {
      this.showModal = !this.showModal;
    }
  }
};
</script>
