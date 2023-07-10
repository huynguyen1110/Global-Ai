<template>
  <div>
    <index-navbar />
    <section class="header relative pt-16 items-center flex h-screen max-h-860-px">
      <div class="container mx-auto items-center flex flex-wrap">
        <div class="w-full md:w-8/12 lg:w-6/12 xl:w-6/12 px-4">
          <div class="pt-32 sm:pt-0">
            <h2 class="font-semibold text-4xl text-slate-600">
              Global AI - Sàn thương mại điện tử.
            </h2>
            <p class="mt-4 text-lg leading-relaxed text-slate-500">
              Sàn thương mại điện tử Global AI là một nền tảng trực tuyến kết nối các nhà cung cấp và các nhà phân phối
              với nhau, cho phép các nhà cung cấp và các nhà phân phối mua bán hàng hóa và dịch vụ với số lượng lớn và giá
              chiết khấu cao.
            </p>
            <div class="mt-12">
              <router-link to="/auth/register-master"
                class="github-star ml-1 text-white font-bold px-6 py-4 rounded outline-none focus:outline-none mr-1 mb-1 bg-slate-700 active:bg-slate-600 uppercase text-sm shadow hover:shadow-lg ease-linear transition-all duration-150">
                Đăng ký
              </router-link>
              <router-link to="/auth/login"
                class="get-started text-white font-bold px-6 py-4 rounded outline-none focus:outline-none mr-1 mb-1 bg-emerald-500 active:bg-emerald-600 uppercase text-sm shadow hover:shadow-lg ease-linear transition-all duration-150">
                Đăng nhập
              </router-link>
            </div>
          </div>
        </div>
      </div>

      <img class="absolute top-0 b-auto right-0 pt-16 sm:w-6/12 -mt-48 sm:mt-0 w-10/12 max-h-860-px" :src="patternVue"
        alt="..." />
    </section>
    <!-- tại sao chọn -->
    <section class="pb-20 relative block bg-slate-800">
      <div class="bottom-auto top-0 left-0 right-0 w-full absolute pointer-events-none overflow-hidden -mt-20 h-20"
        style="transform: translateZ(0);">
        <svg class="absolute bottom-0 overflow-hidden" xmlns="http://www.w3.org/2000/svg" preserveAspectRatio="none"
          version="1.1" viewBox="0 0 2560 100" x="0" y="0">
          <polygon class="text-slate-800 fill-current" points="2560 0 2560 100 0 100"></polygon>
        </svg>
      </div>

      <div class="container mx-auto px-4 lg:pt-24 lg:pb-20 bg-state-800">
        <div class="flex flex-wrap text-center justify-center">
          <div class="w-full lg:w-6/12 px-4">
            <h2 class="max-[768px]:text-4xl md:text-5xl font-semibold text-white">
              Tại sao chọn Global-AI
            </h2>
            <p class="text-lg leading-relaxed mt-4 mb-4 text-slate-400">
              Sàn thương mại điện tử Global AI giúp tăng tính chuyên nghiệp và uy tín của nhà cung cấp, giúp nhà phân phối
              cảm thấy tin tưởng khi giao dịch trực tuyến.
            </p>
          </div>
        </div>
        <div class="flex flex-wrap mt-12 justify-center">
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class=" hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center">
              <svg fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M16.5 18.75h-9m9 0a3 3 0 013 3h-15a3 3 0 013-3m9 0v-3.375c0-.621-.503-1.125-1.125-1.125h-.871M7.5 18.75v-3.375c0-.621.504-1.125 1.125-1.125h.872m5.007 0H9.497m5.007 0a7.454 7.454 0 01-.982-3.172M9.497 14.25a7.454 7.454 0 00.981-3.172M5.25 4.236c-.982.143-1.954.317-2.916.52A6.003 6.003 0 007.73 9.728M5.25 4.236V4.5c0 2.108.966 3.99 2.48 5.228M5.25 4.236V2.721C7.456 2.41 9.71 2.25 12 2.25c2.291 0 4.545.16 6.75.47v1.516M7.73 9.728a6.726 6.726 0 002.748 1.35m8.272-6.842V4.5c0 2.108-.966 3.99-2.48 5.228m2.48-5.492a46.32 46.32 0 012.916.52 6.003 6.003 0 01-5.395 4.972m0 0a6.726 6.726 0 01-2.749 1.35m0 0a6.772 6.772 0 01-3.044 0">
                </path>
              </svg>
            </div>
            <h6 class="text-xl mt-5 font-semibold text-white">
              Uy tín
            </h6>
            <p class="mt-2 mb-4 text-slate-400">
              Nhiều thương hiệu lớn tin chọn
            </p>
          </div>
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class=" hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center">
              <svg fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M15.59 14.37a6 6 0 01-5.84 7.38v-4.8m5.84-2.58a14.98 14.98 0 006.16-12.12A14.98 14.98 0 009.631 8.41m5.96 5.96a14.926 14.926 0 01-5.841 2.58m-.119-8.54a6 6 0 00-7.381 5.84h4.8m2.581-5.84a14.927 14.927 0 00-2.58 5.84m2.699 2.7c-.103.021-.207.041-.311.06a15.09 15.09 0 01-2.448-2.448 14.9 14.9 0 01.06-.312m-2.24 2.39a4.493 4.493 0 00-1.757 4.306 4.493 4.493 0 004.306-1.758M16.5 9a1.5 1.5 0 11-3 0 1.5 1.5 0 013 0z">
                </path>
              </svg>
            </div>
            <h6 class="text-xl mt-5 font-semibold text-white">
              Mở rộng thị trường
            </h6>
            <p class="mt-2 mb-4 text-slate-400">
              Tăng doanh số bán hàng, tạo ra nhiều cơ hội kinh doanh mới
            </p>
          </div>
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class=" hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center">
              <svg fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M12 21a9.004 9.004 0 008.716-6.747M12 21a9.004 9.004 0 01-8.716-6.747M12 21c2.485 0 4.5-4.03 4.5-9S14.485 3 12 3m0 18c-2.485 0-4.5-4.03-4.5-9S9.515 3 12 3m0 0a8.997 8.997 0 017.843 4.582M12 3a8.997 8.997 0 00-7.843 4.582m15.686 0A11.953 11.953 0 0112 10.5c-2.998 0-5.74-1.1-7.843-2.918m15.686 0A8.959 8.959 0 0121 12c0 .778-.099 1.533-.284 2.253m0 0A17.919 17.919 0 0112 16.5c-3.162 0-6.133-.815-8.716-2.247m0 0A9.015 9.015 0 013 12c0-1.605.42-3.113 1.157-4.418">
                </path>
              </svg>
            </div>
            <h6 class="text-xl mt-5 font-semibold text-white">
              Chi phí thấp
            </h6>
            <p class="mt-2 mb-4 text-slate-400">
              Tiết kiệm chi phí khởi nghiệp và chi phí vận hành
            </p>
          </div>
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class=" hover:scale-90 text-slate-800 p-3 w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center">
              <svg fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M12 6v12m-3-2.818l.879.659c1.171.879 3.07.879 4.242 0 1.172-.879 1.172-2.303 0-3.182C13.536 12.219 12.768 12 12 12c-.725 0-1.45-.22-2.003-.659-1.106-.879-1.106-2.303 0-3.182s2.9-.879 4.006 0l.415.33M21 12a9 9 0 11-18 0 9 9 0 0118 0z">
                </path>
              </svg>
            </div>
            <h6 class="text-xl mt-5 font-semibold text-white">
              Dễ dàng quản lý
            </h6>
            <p class="mt-2 mb-4 text-slate-400">
              Quản lý sản phẩm, đơn hàng và thanh toán dễ dàng và thuận tiện
            </p>
          </div>
          <div class="w-full lg:w-4/12 px-4 text-center py-2.5">
            <div
              class="hover:scale-90 text-slate-800 p-3  w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center">
              <svg fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M6.633 10.5c.806 0 1.533-.446 2.031-1.08a9.041 9.041 0 012.861-2.4c.723-.384 1.35-.956 1.653-1.715a4.498 4.498 0 00.322-1.672V3a.75.75 0 01.75-.75A2.25 2.25 0 0116.5 4.5c0 1.152-.26 2.243-.723 3.218-.266.558.107 1.282.725 1.282h3.126c1.026 0 1.945.694 2.054 1.715.045.422.068.85.068 1.285a11.95 11.95 0 01-2.649 7.521c-.388.482-.987.729-1.605.729H13.48c-.483 0-.964-.078-1.423-.23l-3.114-1.04a4.501 4.501 0 00-1.423-.23H5.904M14.25 9h2.25M5.904 18.75c.083.205.173.405.27.602.197.4-.078.898-.523.898h-.908c-.889 0-1.713-.518-1.972-1.368a12 12 0 01-.521-3.507c0-1.553.295-3.036.831-4.398C3.387 10.203 4.167 9.75 5 9.75h1.053c.472 0 .745.556.5.96a8.958 8.958 0 00-1.302 4.665c0 1.194.232 2.333.654 3.375z">
                </path>
              </svg>
            </div>
            <h5 class="text-xl mt-5 font-semibold text-white">
              Tăng tính cạnh tranh
            </h5>
            <p class="mt-2 mb-4 text-slate-400">
              Cung cấp sản phẩm với giá cả cạnh tranh
            </p>
          </div>
          <div class="w-full lg:w-4/12  px-4 text-center py-2.5">
            <div
              class="hover:scale-90 text-slate-800 p-3  w-32 h-32 shadow-lg rounded-full bg-white inline-flex items-center justify-center">
              <svg fill="none" stroke="currentColor" stroke-width="1.5" viewBox="0 0 24 24"
                xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                <path stroke-linecap="round" stroke-linejoin="round"
                  d="M12 18v-5.25m0 0a6.01 6.01 0 001.5-.189m-1.5.189a6.01 6.01 0 01-1.5-.189m3.75 7.478a12.06 12.06 0 01-4.5 0m3.75 2.383a14.406 14.406 0 01-3 0M14.25 18v-.192c0-.983.658-1.823 1.508-2.316a7.5 7.5 0 10-7.517 0c.85.493 1.509 1.333 1.509 2.316V18">
                </path>
              </svg>
            </div>
            <h5 class="text-xl mt-5 font-semibold text-white">
              Tiết kiệm
            </h5>
            <p class="mt-2 mb-4 text-slate-400">
              Tối ưu hoá thời gian tìm kiếm khách hàng
            </p>
          </div>
        </div>
      </div>
    </section>
    <section>
      <section>
        <div class="container mx-auto px-4 lg:pt-24  bg-state-800 flex flex-wrap">
          <div class="lg:w-6/12 px-4  py-2.5 float-right">
            <img class="mx-auto" src="src\assets\z4225887963689_bcc32d4fe527e8a0cc92d16d234b00b0.jpg" alt="free shoping">
          </div>
          <div class="w-full lg:w-6/12 px-4  py-2.5">

            <h2 class="sm:text-4xl lg:text-6xl font-bold my-4">Global AI mang lại những gì cho người dùng?
            </h2>
            <p class="font-medium my-2"><span></span>
              Cung cấp cho người dùng các thông tin về nhà cung cấp và các sản phẩm, giúp họ đánh giá tính đáng tin cậy
              của nhà cung cấp và sản phẩm trước khi quyết định mua hàng.
            </p>
            <p class="font-medium my-2">
              Giúp các nhà cung cấp mở rộng thị trường bán hàng và tìm kiếm khách hàng mới trên khắp mọi nơi.
            </p>
          </div>

        </div>
      </section>
    </section>
    <!-- Blog -->
    <section>
      <div class="bg-slate-100 py-24 sm:py-14">
        <div class="mx-auto max-w-7xl px-6 lg:px-8">
          <div class="mx-auto max-w-2xl lg:mx-0">
            <h2 class="text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">Blog</h2>
            <p class="mt-2 text-lg leading-8 text-gray-600">Làm thế nào để kinh doanh hiệu quả?</p>
          </div>
          <div
            class="mx-auto mt-5 grid max-w-2xl grid-cols-1 gap-y-16 gap-x-8 border-t border-gray-200 pt-10  sm:pt-16 lg:mx-0 lg:max-w-none lg:grid-cols-3">
            <article class="flex max-w-xl flex-col items-start justify-between">
              <div class="flex items-center gap-x-4 text-xs">
                <time datetime="2020-03-16" class="text-gray-500">Mar 16, 2020</time>
                <a href="#"
                  class="relative z-10 rounded-full bg-gray-50 py-1.5 px-3 font-medium text-gray-600 hover:bg-gray-100">Marketing</a>
              </div>
              <div class="group relative">
                <h3 class="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
                  <a href="#">
                    <span class="absolute inset-0"></span>
                    AI có phải là tương lai của việc tạo video không?
                  </a>
                </h3>
                <p class="mt-5 text-sm leading-6 text-gray-600 line-clamp-3">AI có đang thay đổi cách chúng ta tạo video
                  không? AI sáng tạo sử dụng nội dung hiện có như âm thanh, video và văn bản để tạo nội dung gốc. Các nhà
                  tiếp thị video có thể tự động hóa quy trình viết kịch bản và chỉnh sửa chỉ trong vài giây.</p>
              </div>
              <div class="relative mt-8 flex items-center gap-x-4">
                <img src="src\assets\icons8-administrator-male-40.png" alt="" class="h-10 w-10 rounded-full bg-gray-50">
                <div class="text-sm leading-6">
                  <p class="font-semibold text-gray-900">
                    <a href="#">
                      <span class="absolute inset-0"></span>
                      Admin
                    </a>
                  </p>
                  <p class="text-gray-600">Creator</p>
                </div>
              </div>
            </article>

            <article class="flex max-w-xl flex-col items-start justify-between">
              <div class="flex items-center gap-x-4 text-xs">
                <time datetime="2020-03-16" class="text-gray-500">Mar 16, 2020</time>
                <a href="#"
                  class="relative z-10 rounded-full bg-gray-50 py-1.5 px-3 font-medium text-gray-600 hover:bg-gray-100">Marketing</a>
              </div>
              <div class="group relative">
                <h3 class="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
                  <a href="#">
                    <span class="absolute inset-0"></span>
                    Dữ liệu từ hơn 600 người tiêu dùng đã thay đổi như thế nào kể từ năm 2022
                  </a>
                </h3>
                <p class="mt-5 text-sm leading-6 text-gray-600 line-clamp-3">Để giúp các nhà tiếp thị cũng như các chuyên
                  gia kinh doanh, chúng tôi đã tiến hành một cuộc khảo sát hai năm một lần với hơn 600 người trưởng thành
                  ở Hoa Kỳ vào tháng 5 năm 2022 và tháng 1 năm 2023, đồng thời tìm hiểu sâu về dữ liệu theo từng thế hệ
                </p>
              </div>
              <div class="relative mt-8 flex items-center gap-x-4">
                <img src="src\assets\icons8-administrator-male-40.png" alt="" class="h-10 w-10 rounded-full bg-gray-50">
                <div class="text-sm leading-6">
                  <p class="font-semibold text-gray-900">
                    <a href="#">
                      <span class="absolute inset-0"></span>
                      Admin
                    </a>
                  </p>
                  <p class="text-gray-600">Creator</p>
                </div>
              </div>
            </article>

            <article class="flex max-w-xl flex-col items-start justify-between">
              <div class="flex items-center gap-x-4 text-xs">
                <time datetime="2020-03-16" class="text-gray-500">Mar 16, 2020</time>
                <a href="#"
                  class="relative z-10 rounded-full bg-gray-50 py-1.5 px-3 font-medium text-gray-600 hover:bg-gray-100">Marketing</a>
              </div>
              <div class="group relative">
                <h3 class="mt-3 text-lg font-semibold leading-6 text-gray-900 group-hover:text-gray-600">
                  <a href="#">
                    <span class="absolute inset-0"></span>
                    Cách tìm người có ảnh hưởng để quảng bá doanh nghiệp nhỏ của bạn vào năm 2023
                  </a>
                </h3>
                <p class="mt-5 text-sm leading-6 text-gray-600 line-clamp-3">Bạn đang muốn quảng bá doanh nghiệp nhỏ của
                  mình trên mạng xã hội nhưng không có nhiều ngân sách? Hãy tìm hiểu cách tìm và làm việc với những người
                  có ảnh hưởng để truyền tải thông điệp của bạn - với chi phí chỉ bằng một phần nhỏ khi làm việc với những
                  người nổi tiếng</p>
              </div>
              <div class="relative mt-8 flex items-center gap-x-4">
                <img src="src\assets\icons8-administrator-male-40.png" alt="" class="h-10 w-10 rounded-full bg-gray-50">
                <div class="text-sm leading-6">
                  <p class="font-semibold text-gray-900">
                    <a href="#">
                      <span class="absolute inset-0"></span>
                      Admin
                    </a>
                  </p>
                  <p class="text-gray-600">Creator</p>
                </div>
              </div>
            </article>

            <!-- More posts... -->
          </div>
        </div>
      </div>
    </section>
    <!-- Lĩnh vực nổi bật -->
    <section class="mb-32">
      <div class="justify-center text-center flex flex-wrap mt-24">
        <div class="w-full md:w-6/12 px-12 md:px-4">
          <h2 class="font-semibold text-4xl">Lĩnh vực nổi bật</h2>
        </div>
      </div>
    </section>
    <section class="block relative z-1 bg-slate-600">
      <div class="container mx-auto">
        <div class="justify-center flex flex-wrap">
          <div class="w-full lg:w-12/12 px-4 -mt-24">
            <div class="flex flex-wrap">
              <div class="w-full lg:w-4/12 px-4">
                <h5 class="text-xl font-semibold pb-4 text-center">
                  Mỹ Phẩm
                </h5>
                <router-link to="/product/category/1">
                  <div
                    class="hover:-mt-4 relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-lg rounded-lg ease-linear transition-all duration-150">
                    <img alt="..." class="align-middle border-none max-w-full h-auto rounded-lg" :src="login" />
                  </div>
                </router-link>
              </div>

              <div class="w-full lg:w-4/12 px-4">
                <h5 class="text-xl font-semibold pb-4 text-center">
                  Thời trang
                </h5>
                <router-link to="/auth/login">
                  <div
                    class="hover:-mt-4 relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-lg rounded-lg ease-linear transition-all duration-150">
                    <img alt="..." class="align-middle border-none max-w-full h-auto rounded-lg" :src="profile" />
                  </div>
                </router-link>
              </div>

              <div class="w-full lg:w-4/12 px-4">
                <h5 class="text-xl font-semibold pb-4 text-center">
                  Điện máy, điện tử
                </h5>
                <router-link to="/auth/login">
                  <div
                    class="hover:-mt-4 relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-lg rounded-lg ease-linear transition-all duration-150">
                    <img alt="..." class="align-middle border-none max-w-full h-auto rounded-lg" :src="landing" />
                  </div>
                </router-link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <!-- Đối tác  -->
    <section>
      <div class="bg-white py-24 sm:py-28">
        <div class="mx-auto max-w-7xl px-6 lg:px-8">
          <h2 class="text-center text-lg font-bold leading-8 text-gray-900">ĐƯỢC SỰ TIN TƯỞNG CỦA CÁC DOANH NGHIỆP</h2>
          <div
            class="mx-auto mt-10 grid max-w-lg grid-cols-4 items-center gap-x-8 gap-y-10 sm:max-w-xl sm:grid-cols-6 sm:gap-x-10 lg:mx-0 lg:max-w-none lg:grid-cols-5">
            <img class="col-span-2 max-h-12 w-full object-contain lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/transistor-logo-gray-900.svg" alt="Transistor" width="158"
              height="48">
            <img class="col-span-2 max-h-12 w-full object-contain lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/reform-logo-gray-900.svg" alt="Reform" width="158" height="48">
            <img class="col-span-2 max-h-12 w-full object-contain lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/tuple-logo-gray-900.svg" alt="Tuple" width="158" height="48">
            <img class="col-span-2 max-h-12 w-full object-contain sm:col-start-2 lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/savvycal-logo-gray-900.svg" alt="SavvyCal" width="158"
              height="48">
            <img class="col-span-2 col-start-2 max-h-12 w-full object-contain sm:col-start-auto lg:col-span-1"
              src="https://tailwindui.com/img/logos/158x48/statamic-logo-gray-900.svg" alt="Statamic" width="158"
              height="48">
          </div>
        </div>
      </div>
    </section>
    <footer-component />
  </div>
</template>
<style>
.bg-custom-1 {
  background-color: #f2f1f2;
}
</style>
<script setup>
import IndexNavbar from "../components/Navbars/IndexNavbar.vue";
import FooterComponent from "../components/Footers/Footer.vue";
import patternVue from '../assets/3297746_16544.jpg';


// const patternVue = ref("../assets/img/pattern_vue.png");
import componentBtn from "../assets/img/component-btn.png";
import componentProfileCard from "../assets/img/component-profile-card.png";
import componentInfoCard from "../assets/img/component-info-card.png";
import componentInfo2 from "../assets/img/component-info-2.png";
import componentMenu from "../assets/img/component-menu.png";
import componentBtnPink from "../assets/img/component-btn-pink.png";
import documentation from "../assets/img/documentation.png";
import login from "../assets/img/login.jpg";
import profile from "../assets/img/profile.jpg";
import landing from "../assets/img/landing.jpg";

</script>
