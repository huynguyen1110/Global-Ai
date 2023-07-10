<template>
  <div class="lg:px-[45px] mx-auto">
    <!-- Container -->
    <div class="min-h-[100vh] w-full">
      <!-- header -->
      <div class="pt-[20px] bg-white">
        <!-- navbar-one -->
        <div class="flex px-[20px] items-center justify-between">
          <h1 class="text-[24px] text-[#384059] w-[15%] font-semibold">
            Đơn Hàng
          </h1>
          <div
            class="px-[20px] py-[10px] flex-1 rounded-md bg-slate-100 flex justify-between"
          >
            <div class="flex items-center gap-[10px]">
              <h4 class="text-[#384059] text-[16px] font-[600]">
                Tổng số đơn hàng
              </h4>
              <span class="text-[#CC3366] text-[16px] font-medium">0</span>
            </div>
            <div class="flex items-center gap-[10px]">
              <h4 class="text-[#384059] text-[16px] font-[600]">
                Tổng giá trị đơn đã giao
              </h4>
              <span class="text-[#CC3366] text-[16px] font-medium">0 đ</span>
            </div>
            <div class="flex items-center gap-[10px]">
              <h4 class="text-[#384059] text-[16px] font-[600]">
                Hoa hồng đơn chờ đối soát
              </h4>
              <span class="text-[#CC3366] text-[16px] font-medium">0đ</span>
            </div>
            <div class="flex items-center gap-[10px]">
              <h4 class="text-[#384059] text-[16px] font-[600]">
                Tổng thu nhập đơn đã giao
              </h4>
              <span class="text-[#CC3366] text-[16px] font-medium">0đ</span>
            </div>
          </div>
        </div>
        <!-- navbar-two -->
        <div class="mt-[20px] border-b-[1px] border-slate-100">
          <div class="flex px-[20px]">
            <div
              v-for="item in fakeNavbarOrder"
              :key="item.id"
              @click="handleClickNavOrder(item.id)"
            >
              <div
                :class="
                  checkColor === item.id
                    ? 'px-[20px] text-[#cc3366] hover:border-[#cc3366] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap border-[#cc3366] border-b-[3px] py-[15px]'
                    : 'px-[20px] text-[#384059] hover:border-[#cc3366] hover:text-[#cc3366] hover:border-b-[3px] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap  py-[15px]'
                "
              >
                <span class="text-[14px] font-[600]">{{ item.title }}</span>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- content -->
      <div class="w-full flex items-start">
        <div class="w-[32%] border-r-[1px] border-slate-200 bg-white">
          <div class="p-[20px] border-b-[1px] border-slate-200">
            <div
              class="flex items-center gap-[10px] bg-slate-200 rounded-xl overflow-hidden"
            >
              <input
                type="text"
                class="w-[85%] outline-none border-none bg-slate-200 rounded-tl-md rounded-bl-md"
                placeholder="Tìm kiếm đơn hàng"
              />
              <font-awesome-icon :icon="['fass', 'circle-xmark']" />
              <font-awesome-icon
                :icon="['fas', 'magnifying-glass']"
                class="text-[18px]"
              />
            </div>
          </div>
          <div class="min-h-[100vh] flex items-center justify-center w-full">
            <span class="text-center"> Không có đơn hàng nào</span>
          </div>
        </div>
        <div class="flex-1 relative min-h-[100vh]">
          <!-- video quảng cáo -->
          <div
            class="absolute top-[50%] left-[50%] translate-x-[-50%] translate-y-[-50%]"
          >
            <h1>Giới thiệu GlobalAI</h1>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
const checkColor = ref(1);

const fakeNavbarOrder = [
  {
    title: "Tất Cả",
    id: 1,
  },
  {
    title: "Chờ Thanh Toán",
    id: 2,
  },
  {
    title: "Chờ Xác Nhận",
    id: 3,
  },
  {
    title: "Chờ lấy hàng",
    id: 4,
  },
  {
    title: "Đang giao hàng",
    id: 5,
  },
  {
    title: "Đã giao & chờ đối soát",
    id: 6,
  },
  {
    title: "Đã đối soát",
    id: 7,
  },
  {
    title: "Đã hủy",
    id: 8,
  },
  {
    title: "Trả hàng",
    id: 9,
  },
];
const handleClickNavOrder = (id) => {
  checkColor.value = id;
};
definePageMeta({
  layout: "layout-default",
  name: "OrderLayout",
});
</script>
<style></style>
