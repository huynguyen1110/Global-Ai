<template>
    <div class="mt-[40px] mb-[50px] w-full overflow-hidden">
        <!-- Navbar danh mục -->
        <div class="flex max-w-full">
            <div
                v-for="item in navItems"
                @click="handleClickNavbar(item)"
                :key="item"
                :class="
                    checkColor === item.id
                        ? 'px-[20px] text-[#cc3366] hover:border-[#cc3366] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap border-[#cc3366] border-b-[3px] py-[15px]'
                        : 'px-[20px] text-[#384059] hover:border-[#cc3366] hover:text-[#cc3366] hover:border-b-[3px] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap  py-[15px]'
                "
            >
                <span class="text-[16px] font-[600]">{{
                    item.tenDanhMuc
                }}</span>
            </div>
        </div>
        <card-list-product :products="productNavbar" />
    </div>
    <div class="flex absolute bottom-0 w-full items-center justify-center">
        <card-pagination
            :pageNumber="pageNumber"
            :total-pages="totalPages"
            :next-page="nextPage"
            :prev-page="prevPage"
            v-on:click-page="handlePageClick"
        ></card-pagination>
    </div>
</template>
<script setup>
import CardListProductShort from "../../components/Cards/CardListProductShort.vue";
import CardListProduct from "../../components/Cards/CardListProduct.vue";
import CardPagination from "~~/components/Cards/CardPagination.vue";
import { getSanPhamDanhMucPhanTrang } from "~~/composables/useApiProduct";
const checkColor = ref();

// Get Sản phẩm theo Navbar danh mục
const pageSize = 15;
const navItems = ref([]);
const pageNumber = ref(1);
const skip = ref(0);
const categoryId = ref("1");
const productNavbar = ref([]);
const totalPages = ref(1);

watchEffect(() => {
    getSanPhamDanhMucPhanTrang(
        categoryId.value,
        pageSize,
        pageNumber.value,
        skip.value
    )
        .then((res) => {
            productNavbar.value = res?.data?.data?.items;
            console.log(productNavbar.value);
        })
        .catch((err) => console.log(err));
});

watchEffect(() => {
    getFullSanPham(categoryId.value)
        .then((res) => {
            console.log(res?.data?.data.totalItems);
            totalPages.value =
                Math.floor(res?.data?.data.totalItems / pageSize) + 1;
            console.log(totalPages.value);
        })
        .catch((error) => {
            console.log(error);
        });
});

onMounted(() => {
    getDanhMucSanPham()
        .then((res) => {
            navItems.value = res?.data?.data.items;
            // Dữ liệu mặc định
            checkColor.value = res?.data?.data.items[0].id
            categoryId.value = res?.data?.data.items[0].id;
        })
        .catch((error) => {
            console.log(error);
        });
});

const nextPage = () => {
    pageNumber.value++;
    skip.value = (pageNumber.value - 1) * pageSize;
};
const handlePageClick = (page) => {
    pageNumber.value = page;
    skip.value = (pageNumber.value - 1) * pageSize;
};

const prevPage = () => {
    pageNumber.value--;
    console.log(123);
    skip.value = (pageNumber.value - 1) * pageSize;
};
const handleClickNavbar = (item) => {
    categoryId.value = item.id;
    checkColor.value = item.id;
};
</script>
<style></style>
