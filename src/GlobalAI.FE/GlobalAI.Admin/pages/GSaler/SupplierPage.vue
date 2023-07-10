<template>
  <div class="min-h-[100vh]">
    <div class="pt-[30px] w-full mx-auto lg:px-[185px] bg-white">
      <h1 class="lg:text-[24px] sm:pl-0 pl-4 text-[#384059] font-bold">
        Nhà Cung Cấp Xác Thực
      </h1>
      <div class="sm:flex max-w-full items-center justify-between">
        <div class="flex">
          <div
            v-for="item in navItems"
            @click="handleClickNavbar(item)"
            :key="item"
            :class="
              checkColor === item.idDanhMuc
                ? 'px-[20px] text-[#cc3366] hover:border-[#cc3366] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap border-[#cc3366] border-b-[3px] py-[15px]'
                : 'px-[20px] text-[#384059] hover:border-[#cc3366] hover:text-[#cc3366] hover:border-b-[3px] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap  py-[15px]'
            "
          >
            <span class="text-[16px] font-[600]">{{ item.tenDanhMuc }}</span>
          </div>
        </div>
        <div
          @click="handleModel"
          class="flex items-center cursor-pointer pl-4 sm:pl-0 mt-[20px] sm:mt-0"
        >
          <span class="text-[#ccc] mb-0 text-[16px]"
            >Lọc theo:
            <span class="text-[16px] font-medium text-[#384059]"
              >Tất cả danh mục , Bán chạy ,...</span
            ></span
          >
          <div class="ml-[20px] mt-[5px]">
            <font-awesome-icon :icon="['fas', 'angle-down']" />
          </div>
        </div>
      </div>
    </div>
    <!-- Card Content -->
    <div class="mx-auto container lg:px-[185px] mt-[40px]">
      <div
        class="grid grid-cols-1 sm:px-0 px-4 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4"
      >
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
        <CardSupplier />
      </div>
    </div>
    <!-- Model settings -->
    <form @submit.prevent="handleSubmitData"
      :class="{ 'show-modal': checkModel, 'hide-modal': !checkModel }"
      class="fixed bg-slate-200 top-0 right-0 bottom-0 z-50 w-[25%]"
    >
      <!-- Header -->
      <div class="flex bg-white justify-between px-[15px] py-[20px]">
        <h2 class="text-[#384059] font-medium text-[18px]">Lọc theo</h2>
        <h2 class="text-[18px] font-medium text-blue-500">Xóa bộ lọc</h2>
      </div>
      <!-- Content -->
      <div
        class="px-[15px] pt-[20px] pb-[10px] border-b-[1px] border-[#ccc] bg-white mt-[10px]"
      >
        <span class="text-[16px] text-[#384059] font-medium">Danh Mục</span>
        <div class="grid grid-cols-2 gap-3 mt-4">
          <div
            v-for="data in fakeDataCategory"
            :key="data.id"
            @click="handleSetData(data.id)"
            :class="
              checkId == data.id
                ? 'border-[1px] cursor-pointer bg-[#cc3366] border-[#ccc] rounded-3xl text-center items-center'
                : 'border-[1px] cursor-pointer border-[#ccc] rounded-3xl text-center items-center'
            "
          >
            <h3
              :class="
                checkId == data.id
                  ? 'text-[12px] mb-0 text-white font-bold'
                  : 'text-[12px] text-[#384059] font-bold'
              "
            >
              {{ data.title }}
            </h3>
            <h4
              :class="
                checkId == data.id ? 'text-[12px] text-white' : 'text-[12px]'
              "
            >
              {{ data.number }} nhà cung cấp
            </h4>
          </div>
        </div>
        <div class="text-center items-center mt-[15px]">
          <span
            class="text-center font-medium cursor-pointer text-[#384059] text-[18px]"
            >Xem thêm <font-awesome-icon :icon="['fas', 'angle-down']" />
          </span>
        </div>
      </div>
      <!-- Sắp xếp theo -->
      <div
        class="px-[15px] pt-[20px] pb-[10px] border-b-[1px] border-[#ccc] bg-white"
      >
        <span class="text-[16px] text-[#384059] font-medium">Sắp xếp theo</span>
        <div class="grid grid-cols-2 gap-3 mt-4">
          <div
            v-for="data in fakeDataSort"
            :key="data.id"
            @click="handleSetDataSort(data.id)"
            :class="
              checkIdSort == data.id
                ? 'border-[1px] cursor-pointer py-[10px] bg-[#cc3366] border-[#ccc] rounded-3xl text-center items-center'
                : 'border-[1px] py-[10px] cursor-pointer border-[#ccc] rounded-3xl text-center items-center'
            "
          >
            <h3
              :class="
                checkIdSort == data.id
                  ? 'text-[12px] mb-0 text-white font-bold'
                  : 'text-[12px] text-[#384059] font-bold'
              "
            >
              {{ data.title }}
            </h3>
          </div>
        </div>
      </div>
      <!-- Trong khoảng thời gian -->
      <div
        class="px-[15px] pt-[20px] pb-[10px] border-b-[1px] border-[#ccc] bg-white"
      >
        <span class="text-[16px] text-[#384059] font-medium"
          >Trong khoảng thời gian</span
        >
        <div class="grid grid-cols-2 gap-3 mt-4">
          <div
            v-for="data in fakeDataTime"
            :key="data.id"
            @click="handleSetDataTime(data.id)"
            :class="
              checkIdTime == data.id
                ? 'border-[1px] cursor-pointer py-[10px] bg-[#cc3366] border-[#ccc] rounded-3xl text-center items-center'
                : 'border-[1px] py-[10px] cursor-pointer border-[#ccc] rounded-3xl text-center items-center'
            "
          >
            <h3
              :class="
                checkIdTime == data.id
                  ? 'text-[12px] mb-0 text-white font-bold'
                  : 'text-[12px] text-[#384059] font-bold'
              "
            >
              {{ data.title }}
            </h3>
          </div>
        </div>
      </div>
      <!-- Footer -->
      <button
        type="submit"
        class="w-full h-[60px] bg-[#cc3366] text-white font-medium text-[20px] absolute bottom-0 flex items-center justify-center"
      >
        Áp Dụng
      </button>
    </form>
    <div
      v-show="checkModel"
      @click="closeModel"
      class="fixed top-0 left-0 right-0 w-full h-full bg-black opacity-25 z-20"
    ></div>
  </div>
</template>
<script setup>
import { toast } from "vue3-toastify";
import CardSupplier from "~~/components/Cards/CardSupplier.vue";
const navItems = [
  {
    idDanhMuc:'1',
    tenDanhMuc:'Bán Chạy'
  },
  {
    idDanhMuc:'2',
    tenDanhMuc:'Hoa Hồng Cao'
  },
  {
    idDanhMuc:'3',
    tenDanhMuc:'Mới Nhất'
  },
];
const checkColor = ref("1");
const categoryId = ref("1");
const checkModel = ref(false);
const checkId = ref("1");
const checkIdSort = ref("1");
const checkIdTime = ref("1");
const handleClickNavbar = (item) => {
  categoryId.value = item.idDanhMuc;
  checkColor.value = item.idDanhMuc;
};
const handleSetData = (id) => {
  checkId.value = id;
};
const handleSetDataSort = (id) => {
  checkIdSort.value = id;
};
const handleSetDataTime = (id) => {
  checkIdTime.value = id;
};
const handleSubmitData = () => {
  toast.success("Phân Loại thành công")
}
const fakeDataCategory = [
  {
    id: "1",
    title: "Tất cả danh mục",
    number: 1610,
  },
  {
    id: "2",
    title: "Thời Trang Nữ",
    number: 149,
  },
  {
    id: "3",
    title: "Sắc Đẹp",
    number: 215,
  },
  {
    id: "4",
    title: "Bách Hóa Online",
    number: 241,
  },
  {
    id: "5",
    title: "Sức Khỏe",
    number: 222,
  },
  {
    id: "6",
    title: "Túi Ví",
    number: 78,
  },
];
const fakeDataSort = [
  {
    id: "1",
    title: "Bán chạy",
  },
  {
    id: "2",
    title: "Mới nhất",
  },
  {
    id: "3",
    title: "Đánh giá cao",
  },
];
const fakeDataTime = [
  {
    id: "1",
    title: "7 ngày gần đây",
  },
  {
    id: "2",
    title: "30 ngày gần đây",
  },
  {
    id: "3",
    title: "60 ngày gần đây",
  },
];

const handleModel = () => {
  checkModel.value = !checkModel.value;
  console.log(checkModel.value);
  // if(checkModel.value == true){
  //     document.body.style.overflow = 'hidden';
  // }
};
const closeModel = () => {
  checkModel.value = false;
};
definePageMeta({
  layout: "layout-default",
  name: "SupplierPage",
});
</script>
<style scoped>
.show-modal {
  opacity: 1;
  visibility: visible;
}

.hide-modal {
  opacity: 0;
  visibility: hidden;
}
.show-modal {
  animation: RightTo 0.5s forwards;
}

.hide-modal {
  animation: ToRight 0.5s forwards;
}

@keyframes RightTo {
  from {
    right: -25%;
  }
  to {
    right: 0;
  }
}
@keyframes ToRight {
  from {
    right: 25%;
  }
  to {
    right: 0;
  }
}
</style>
