<template>
    <AppModalBaseVue :name="props.name" title="Thêm sản phẩm chi tiết" @opened="onShowModal"
        content-class="modal-content w-full md:w-full md:pt-5 mh max-h-full">
        <template v-slot:content>
            <div class="w-full">
                <div class="grid gap-6 mb-6 md:grid-cols-2">
                    <div class="col-span-1">
                        <label for="maSanPham" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                            Mã sản phẩm
                        </label>
                        <Field v-model="chiTiet.maSanPhamChiTiet" name="maSanPham" type="text" placeholder="Mã sản phẩm..."
                            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                        <error-message name="maSanPham" class="text-red-500" />
                    </div>
                    <div class="">
                        <label for="image" class="block uppercase text-slate-600 text-xs font-bold mb-2">Hình ảnh</label>
                        <div class="flex items-center justify-between relative">
                            <input type="file" id="image"
                                class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                                required @change="$event => uploadImage($event)" />
                            <!-- <img alt="Product Image" class="w-[50px] h-[50px] border absolute right-0 rounded"
                                :src="getImageUrl(chiTiet.thumbnail)" /> -->
                        </div>
                    </div>
                    <div class="col-span-1">
                        <label for="giaBan" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                            Giá bán
                        </label>
                        <Field v-model.number="chiTiet.giaBan" name="giaBan" type="number"
                            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                        <error-message name="giaBan" class="text-red-500" />
                    </div>
                    <div class="col-span-1">
                        <label for="giaChietKhau" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                            Giá chiết khấu
                        </label>
                        <Field v-model.number="chiTiet.giaChietKhau" name="giaChietKhau" type="number"
                            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                        <error-message name="giaChietKhau" class="text-red-500" />
                    </div>
                    <div class="col-span-1">
                        <label for="giaToiThieu" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                            Giá tối thiểu
                        </label>
                        <Field v-model.number="chiTiet.giaToiThieu" name="giaToiThieu" type="number"
                            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                        <error-message name="giaToiThieu" class="text-red-500" />
                    </div>
                    <div class="col-span-1">
                        <label for="soLuong" class="block uppercase text-slate-600 text-xs font-bold mb-2">
                            Số lượng
                        </label>
                        <Field v-model.number="chiTiet.soLuong" name="soLuong" type="number"
                            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150" />
                        <error-message name="soLuong" class="text-red-500" />
                    </div>
                </div>
                <h5 class="text-bold uppercase text-lg mb-2">Thuộc tính</h5>
                <div class="grid gap-6 mb-6 md:grid-cols-2">
                    <div v-for="(thuocTinh, index) in listThuocTinh" :key="index" class="col-span-1">
                        <label for="idGiaTri" class="block uppercase text-slate-600 text-xs font-bold mb-2">{{
                            thuocTinh.tenThuocTinh }}</label>
                        <select id="idGiaTri" v-model="chiTiet.listIdThuocTinhGiaTri[index]"
                            class="border px-3 py-3 placeholder-slate-300 text-slate-600 bg-white rounded text-sm shadow focus:outline-none focus:ring w-full ease-linear transition-all duration-150"
                            required>
                            <option value="">-- Thuộc tính --</option>
                            <option v-for="giaTri in thuocTinh.listGiaTri" :value="giaTri.id" :key="giaTri.id">
                                {{ giaTri.giaTri }}
                            </option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="flex flex-row justify-end mt-3">
                <div class="btn-group">
                    <button class="btn btn-primary" @click="addSanPhamChiTiet">Lưu</button>
                    <button class="btn btn-outline" @click="close">Đóng</button>
                </div>
            </div>
        </template>
    </AppModalBaseVue>
</template>
<script setup>
import AppModalBaseVue from '../base/AppModalBase.vue';
import { Form, Field, ErrorMessage } from "vee-validate";
import { toast } from 'vue3-toastify';
import { $vfm } from 'vue-final-modal';

const { $toast } = useNuxtApp();
const emits = defineEmits(['on-success']);
const props = defineProps({
    name: String,
    sanPham: {
        type: Object,
        default: () => ({
            id: 0,
            maSanPham: '',
            tenSanPham: '',
            moTa: '',
            idDanhMuc: '',
            idGStore: 0,
            ngayDangKi: '',
            ngayDuyet: '',
            status: 0,
            thumbnail: '',
            luotXem: 0,
            luotBan: 0,
            idDanhMucThuocTinh: 0,
        }),
    }
});

let file = null;
const listThuocTinh = ref([]);
const chiTiet = ref({
    idSanPham: 0,
    listIdThuocTinhGiaTri: [],
    idDanhMucThuocTinh: 0,
    maSanPhamChiTiet: '',
    soLuong: 0,
    moTa: '',
    giaBan: 0,
    giaChietKhau: 0,
    giaToiThieu: 0,
    thumbnail: ''
});

const onShowModal = () => {
    getDanhMucThuocTinhById(props.sanPham.idDanhMucThuocTinh).then(res => listThuocTinh.value = res.data?.data.listThuocTinh);
}

const uploadImage = ($event) => {
    file = $event.target.files[0];
}

const addSanPhamChiTiet = () => {
    const body = {
        idSanPham: props.sanPham.id,
        listSanPhamChiTiet: [
            {
                ...chiTiet.value,
                idSanPham: props.sanPham.id,
                idDanhMucThuocTinh: props.sanPham.idDanhMucThuocTinh,
                listIdThuocTinhGiaTri: chiTiet.value.listIdThuocTinhGiaTri.filter(x => x > 0),
            }
        ]
    }

    postFile(file, 'image').then(res => {
        body.listSanPhamChiTiet[0].thumbnail = res.data;
        return useApiAddSanPhamChiTiet(body);
    })
    .then(res => {
        if (res?.data.code === 200) {
            emits('on-success');
            $toast.success('Thêm mới sản phẩm chi tiết thành công');
            close();
        }
    }).catch(err => {
        const msg =
            err?.response?.data?.message || "Có sự cố xảy ra khi thêm chi tiết sản phẩm";
        $toast.error(msg);
    });
}

const close = () => {
    $vfm.hide(props.name);
}

</script>