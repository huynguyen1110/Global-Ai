<template>
  <div class="mt-4 relative bg-white rounded">
    <div
      v-for="(item, idx) in grListThuocTinhs"
      :key="idx"
      class="m-auto overflow-y-auto shadow-2xl p-12 max-h-screen"
    >
      <div class="flex flex-col gap-5">
        <div class="font-medium">
          <label class="label font-medium">
            <span class="label-text text-base uppercase"
              >Mã danh mục sản phẩm</span
            >
          </label>
          <input
            v-model="item.ma"
            type="text"
            placeholder="Mã danh mục sản phẩm..."
            class="input text-sm shadow-sm input-bordered w-full max-w-xs hover:opacity-75"
          />
        </div>
        <div class="font-medium">
          <label class="label font-medium">
            <span class="label-text text-base uppercase"
              >Tên danh mục sản phẩm</span
            >
          </label>
          <input
            v-model="item.ten"
            type="text"
            placeholder="Tên danh mục sản phẩm..."
            class="input text-sm shadow-sm input-bordered w-full max-w-xs hover:opacity-75"
          />
        </div>
        <div v-for="(thuoctinh, idx) in item.listThuocTinh" :key="idx">
          <div class="border shadow-md border-base-300 bg-base-100 rounded-box">
            <div class="flex justify-between items-center">
              <div class="text-xl flex flex-col gap-3 font-medium m-5">
                <div>
                  <label class="label">
                    <span class="label-text uppercase">Thuộc tính</span>
                  </label>
                  <input
                    :key="idx"
                    type="text"
                    placeholder="Thuộc tính..."
                    class="input shadow-sm input-bordered input-md w-full max-w-xs hover:opacity-75"
                    v-model="thuoctinh.tenThuocTinh"
                  />
                </div>
                <div
                  v-for="(
                    giaTriThuocTinh, index
                  ) in thuoctinh.listThuocTinhGiaTri"
                  :key="index"
                  class="ml-5"
                >
                  <div>
                    <label class="label">
                      <span class="label-text uppercase">Giá trị</span>
                    </label>
                  </div>
                  <div class="flex gap-3 items-center justify-between">
                    <input
                      :key="index"
                      type="text"
                      placeholder="Giá trị..."
                      class="input shadow-sm input-bordered input-sm w-full max-w-xs hover:opacity-75"
                      v-model="giaTriThuocTinh.giaTri"
                    />

                    <span
                      @click="addInputField(thuoctinh.idDanhMucThuocTinh)"
                      class="text-sm text-slate-800 hover:opacity-70 cursor-pointer"
                      ><font-awesome-icon icon="fa-plus"
                    /></span>
                  </div>
                </div>
              </div>
              <span
                @click="addgrListThuocTinhs(idx)"
                class="text-3xl text-slate-800 hover:opacity-70 m-5 cursor-pointer"
                ><font-awesome-icon icon="fa-plus"
              /></span>
            </div>
          </div>
        </div>
      </div>
      <div class="flex justify-end gap-5 mt-5">
        <button
          @click="handlePostDanhMucThuocTinhSanPham"
          class="btn btn-outline"
        >
          Thêm danh mục thuộc tính sản phẩm
        </button>
        <button
          @click="router.push('/admin/categoryattribute')"
          class="btn btn-outline btn-error"
        >
          <span class="flex">Quay về</span>
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
definePageMeta({
  layout: "admin",
});
import { ref } from "vue";
import { postDanhMucThuocTinhSanPham } from "~~/composables/useApiCategoryAttribute";
import { useRouter } from "vue-router";
const { $toast } = useNuxtApp();
const router = useRouter();

const grListThuocTinhs = ref([
  {
    ma: "",
    ten: "",
    listThuocTinh: [
      {
        idDanhMucThuocTinh: 0,
        tenThuocTinh: "",
        listThuocTinhGiaTri: [
          {
            idThuocTinh: 0,
            giaTri: "",
          },
        ],
      },
    ],
  },
]);

const handlePostDanhMucThuocTinhSanPham = () => {
  const dmAttData = grListThuocTinhs.value[0];
  postDanhMucThuocTinhSanPham(dmAttData)
    .then((response) => {
      console.log(response);
      router.push("/admin/categoryattribue");
      $toast.success("Thêm danh mục thuộc tính sản phẩm thành công");
    })
    .catch((error) => {
      console.error(error);
      $toast.error(
        "Thêm danh mục thuộc tính sản phẩm thất bại. Vui lòng thử lại!"
      );
    });
};

const addInputField = (index) => {
  grListThuocTinhs.value[0].listThuocTinh
    .filter((thuoctinh) => thuoctinh.idDanhMucThuocTinh === index)[0]
    .listThuocTinhGiaTri.push({
      idThuocTinh: (index += 2),
      giaTri: "",
    });
};

const addgrListThuocTinhs = () => {
  let previousThuocTinh =
    grListThuocTinhs.value[0].listThuocTinh[grListThuocTinhs.value.length - 1];
  let previousIdThuocTinh = previousThuocTinh;
  grListThuocTinhs.value[0].listThuocTinh.push({
    idDanhMucThuocTinh: previousThuocTinh.idDanhMucThuocTinh++,
    tenThuocTinh: "",
    listThuocTinhGiaTri: [
      {
        idThuocTinh: previousIdThuocTinh.idDanhMucThuocTinh++,
        giaTri: "",
      },
    ],
  });
};

const removeInputField = (index) => {
  grInputListGiaTris.value.splice(index, 1);
};
</script>

<style></style>
