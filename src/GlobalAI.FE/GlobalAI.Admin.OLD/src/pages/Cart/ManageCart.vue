<template>
   <div class="h-screen bg-gray-100 mt-40">
    <div class="mx-auto max-w-5xl justify-center px-6 md:flex md:space-x-6 xl:px-0">
      <div class="rounded-lg md:w-2/3">
        <section class=" bg-gray-100 text-gray-600  " x-data="app">
            <div class="flex flex-col justify-center h-full">
                <!-- Table -->
                <div class="w-full  bg-white shadow-lg rounded-sm border border-gray-200">
                    <header class="px-5 py-4 border-b border-gray-100">
                        <div class="font-semibold text-gray-800">Giỏ hàng</div>
                    </header>

                    <div class="overflow-x-auto p-3">
                        <table class="table-auto w-full">
                            <thead class="text-xs font-semibold uppercase text-gray-400 bg-gray-50">
                                <tr>
                                    <th>
                                        <input type="checkbox" class="w-5 h-5" value="id-2"
                                            @click="toggleCheckbox($el, 120.50)">
                                    </th>
                                    <th class="p-2">
                                        <div class="font-semibold text-left">Tên sản phẩm</div>
                                    </th>
                                    <th class="p-2">
                                        <div class="font-semibold text-left">Số lượng</div>
                                    </th>
                                    <th class="p-2">
                                        <div class="font-semibold text-left">Đơn giá</div>
                                    </th>
                                    <th class="p-2">
                                        <div class="font-semibold text-center">Thao tác</div>
                                    </th>
                                </tr>
                            </thead>

                            <tbody class="text-sm divide-y divide-gray-100">
                                <!-- record 1 -->
                                <tr>
                                    <td class="p-2">
                                        <input type="checkbox" class="w-5 h-5" value="id-1"
                                            @click="toggleCheckbox($el, 2890.66)" />
                                    </td>
                                    <td class="p-3 flex justify-between">
                                        <img src="https://images.unsplash.com/photo-1515955656352-a1fa3ffcd111?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80" alt="product-image" class="w-full rounded-lg sm:w-40" />

                                        <div class="justify-between font-medium ml-5 sm:mt-0">
                                            <h2 class="text-lg font-bold text-gray-900">Nike Air Max 2019</h2>
                                            <p class="mt-1 text-xs text-gray-700">Cỡ 43</p>
                                        </div>
                                    </td>
                                    <td class="p-2">
                                        <div class="flex items-center border-gray-100">
                                            <span class="cursor-pointer rounded-l bg-gray-100 py-1 px-3.5 duration-100 hover:bg-blue-500 hover:text-blue-50"> - </span>
                                            <input class="h-8 w-8 border bg-white text-center text-xs outline-none" type="number" value="2" min="1" />
                                            <span class="cursor-pointer rounded-r bg-gray-100 py-1 px-3 duration-100 hover:bg-blue-500 hover:text-blue-50"> + </span>
                                        </div>
                                    </td>
                                    <td class="p-2">
                                        <div class="text-left font-medium text-green-500">
                                            $369 
                                        </div>
                                    </td>
                                    <td class="p-2">
                                        <div class="flex justify-center">
                                            <button>
                                                <svg class="w-8 h-8 hover:text-blue-600 rounded-full hover:bg-gray-100 p-1"
                                                    fill="none" stroke="currentColor" viewBox="0 0 24 24"
                                                    xmlns="http://www.w3.org/2000/svg">
                                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                                        d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16">
                                                    </path>
                                                </svg>
                                            </button>
                                        </div>
                                    </td>
                                </tr>

                                <!-- record 2 -->
                                <tr>
                                    <td class="p-2">
                                        <input type="checkbox" class="w-5 h-5" value="id-2"
                                            @click="toggleCheckbox($el, 120.50)" />
                                    </td>
                                    <td class="p-3 flex justify-between">
                                        <img src="https://images.unsplash.com/photo-1515955656352-a1fa3ffcd111?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80" alt="product-image" class="w-full rounded-lg sm:w-40" />

                                        <div class="justify-between font-medium ml-5 sm:mt-0">
                                            <h2 class="text-lg font-bold text-gray-900">Nike Air Max 2019</h2>
                                            <p class="mt-1 text-xs text-gray-700">Cỡ 43</p>
                                        </div>
                                    </td>
                                    <td class="p-2">
                                        <div class="flex items-center border-gray-100">
                                            <span class="cursor-pointer rounded-l bg-gray-100 py-1 px-3.5 duration-100 hover:bg-blue-500 hover:text-blue-50"> - </span>
                                            <input class="h-8 w-8 border bg-white text-center text-xs outline-none" type="number" value="2" min="1" />
                                            <span class="cursor-pointer rounded-r bg-gray-100 py-1 px-3 duration-100 hover:bg-blue-500 hover:text-blue-50"> + </span>
                                        </div>
                                    </td>
                                    <td class="p-2">
                                        <div class="text-left font-medium text-green-500">
                                            $369
                                        </div>
                                    </td>
                                    <td class="p-2">
                                        <div class="flex justify-center">
                                            <button>
                                                <svg class="w-8 h-8 hover:text-blue-600 rounded-full hover:bg-gray-100 p-1"
                                                    fill="none" stroke="currentColor" viewBox="0 0 24 24"
                                                    xmlns="http://www.w3.org/2000/svg">
                                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
                                                        d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16">
                                                    </path>
                                                </svg>
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </section>
        
      </div>
      <!-- Sub total -->
      <div class="mt-40 h-full rounded-lg border bg-white p-6 shadow-md md:mt-0 md:w-1/3">
        <div class="mb-2 flex justify-between">
          <p class="text-gray-700 font-semibold">Địa chỉ</p>
          <a class="link text-blue-700 ">Thay đổi</a>
        </div>
        <p class="mb-3">Văn phòng <br>
            369 Trương Định, Giáp Bát, Hoàng Mai, Hà Nội</p>
        <div class="mb-2 flex justify-between">
          <p class="text-gray-700">Giá bán</p>
          <p class="text-gray-700">$369</p>
        </div>
        <div class="flex justify-between">
          <p class="text-gray-700">Giá chiết khấu</p>
          <p class="text-gray-700">$369</p>
        </div>
        <p class="text-gray-700 mt-3 font-semibold">Hình thức thanh toán</p>      
            <label class="cursor-pointer label ">
                <input type="checkbox" checked="checked" class="ml-6 checkbox-sm checkbox " />
                <span class="label-text">Lấy hàng và thanh toán trực tiếp </span>
            </label>
            <label class="cursor-pointer label">

                <input type="checkbox" checked="checked" class="ml-6 checkbox-sm checkbox " />
                <span class="label-text mr-10">Thanh toán chuyển khoản </span>
            </label>
            <label class="flex items-center justify-end mt-3">
                <button class="bg-blue-500  text-blue-50 text-blue-50 hover:bg-blue-600 ml-3  focus:ring-offset-2  transition  ease-in-out  rounded text-white px-6 py-1 text-sm">
                          Ảnh bill chuyển khoản</button>  
            </label>
            <div 
        class="relative order-first md:order-last h-1 md:h-auto flex justify-center items-center border border-dashed border-gray-400 col-span-2 mt-3 rounded-lg bg-no-repeat bg-center bg-origin-padding bg-cover">
            <span class="text-gray-400 opacity-75">
                <svg class="w-14 h-14"  xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="0.7" stroke="currentColor">
             <path stroke-linecap="round" stroke-linejoin="round"
                d="M2.25 15.75l5.159-5.159a2.25 2.25 0 013.182 0l5.159 5.159m-1.5-1.5l1.409-1.409a2.25 2.25 0 013.182 0l2.909 2.909m-18 3.75h16.5a1.5 1.5 0 001.5-1.5V6a1.5 1.5 0 00-1.5-1.5H3.75A1.5 1.5 0 002.25 6v12a1.5 1.5 0 001.5 1.5zm10.5-11.25h.008v.008h-.008V8.25zm.375 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z" />
            </svg>
            </span>
    </div>
        <hr class="my-4" />
        
        <div class="flex justify-between">
            
          <p class="text-lg font-bold">Tổng thanh toán</p>
          <div class="">
            <p class="mb-1 text-lg font-bold">$999</p>
            <p class="text-sm text-gray-700">Tiết kiệm $369</p> 
          </div>
        </div>
        <div class=" flex items-center justify-end">
    <label class="label cursor-pointer mt-10">
      <input type="checkbox" checked="checked" class="checkbox" />
      <span class="label-text mr-3">&nbsp;Đồng ý điều khoản</span>      
    </label>

  </div>
        <button class="focus:outline-none focus:ring-2 mt-3 w-full rounded-md bg-blue-500 py-1.5 font-medium hover:bg-indigo-600 bg-indigo-700 duration-150 focus:ring-indigo-400 transition  ease-in-out">Check out</button>
      </div>
    </div>
  </div>
    </template>
    
    <script>

import { RouterLink, useRouter } from 'vue-router'
    export default {
      name: "ManageCart",
      props: {
          
        },
        
      data() {
        return {
          openTab: 1
        }
      },
      methods: {
        toggleTabs: function(tabNumber){
          this.openTab = tabNumber
        }
      }
      
    }
    const router = useRouter()

    </script>
    
    