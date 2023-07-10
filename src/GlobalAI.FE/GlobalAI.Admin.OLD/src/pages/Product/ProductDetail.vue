<template>
<div>
  <!-- Product Info -->
  <div class="card lg:card-side bg-base-100 shadow-xl">
    <figure><img src="/src/assets/images/vue.jpg" alt="Album"/></figure>
    <div class="card-body">
      <h2 class="card-title">Gà rán giòn rụm</h2>
      <div class="rating rating-md rating-half">
        <input :disabled="true" type="radio" name="rating-10" class="rating-hidden" />
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-1" />
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-2" />
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-1"  />
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-2" />
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-1" />
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-2" />
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-1" />
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-2" />
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-1" checked/>
        <input :disabled="true" type="radio" name="rating-10" class="bg-green-500 mask mask-star-2 mask-half-2" />
      </div>
      <p class="mt-3"><span class="text-red-500 font-bold">$</span>&nbsp;Giá bán</p>
      <p class="mt-3"><span class="text-red-500 font-bold">$</span>&nbsp;Chiết khấu</p>
      <div class="text-sm breadcrumbs">
    <ul>
      <li>
        <a class="">
          <font-awesome-icon :icon="['fa', 'circle-info']" />
          <!-- link toi co the truyen vao param -->
          <!-- <button @click="supplier" class="btn btn-link btn-xs">Thông tin nhà cung cấp</button> -->
          <!-- link toi chua co cach truyen vao param -->
          <router-link class="btn btn-link btn-xs" to="/gsaler/product/supplier/1">Thông tin nhà cung cấp</router-link> 
          <!-- <a href="/gsaler/product/supplier/1" class="link link-primary">Thông tin nhà cung cấp</a> -->
        </a>
      </li> 
      
    </ul>
  </div>
    </div>
  </div>
  <!-- Product Detail Info -->
    <div class="flex flex-wrap">
      <div class="w-full">
        <ul class="flex mb-0 list-none flex-wrap pt-3 pb-4 flex-row">
          <li class="-mb-px mr-2 last:mr-0 flex-auto text-center">
            <a class="text-xs font-bold uppercase px-5 py-3 shadow-lg rounded block leading-normal" v-on:click="toggleTabs(1)" v-bind:class="{'text-green-600 bg-white': openTab !== 1, 'text-white bg-green-600': openTab === 1}">
              Mô tả
            </a>
          </li>
          <li class="-mb-px mr-2 last:mr-0 flex-auto text-center">
            <a class="text-xs font-bold uppercase px-5 py-3 shadow-lg rounded block leading-normal" v-on:click="toggleTabs(2)" v-bind:class="{'text-green-600 bg-white': openTab !== 2, 'text-white bg-green-600': openTab === 2}">
              Điều khoản
            </a>
          </li>
          <li class="-mb-px mr-2 last:mr-0 flex-auto text-center">
            <a class="text-xs font-bold uppercase px-5 py-3 shadow-lg rounded block leading-normal" v-on:click="toggleTabs(3)" v-bind:class="{'text-green-600 bg-white': openTab !== 3, 'text-white bg-green-600': openTab === 3}">
              Đánh giá & bình luận
            </a>
          </li>
        </ul>
        <div class="relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-lg rounded">
          <div class="px-4 py-5 flex-auto">
            <div class="tab-content tab-space">
              <div v-bind:class="{'hidden': openTab !== 1, 'block': openTab === 1}">
                <p>
                  Gà rán miền Nam Hoa Kỳ, hay còn gọi là gà rán, là một món ăn xuất xứ từ miền Nam Hoa Kỳ; nguyên liệu chính là những miếng thịt gà đã được lăn bột rồi chiên trên chảo, chiên ngập dầu, chiên áp suất hoặc chiên không dầu.
                 
                </p>
              </div>
              <div v-bind:class="{'hidden': openTab !== 2, 'block': openTab === 2}">
                <p>
                  Điều khoản dịch vụ là các thỏa thuận pháp lý giữa nhà cung cấp dịch vụ và người muốn sử dụng dịch vụ đó. Người đó phải đồng ý tuân theo các điều khoản dịch vụ để sử dụng dịch vụ được cung cấp. Điều khoản dịch vụ cũng có thể chỉ là một tuyên bố từ chối trách nhiệm, đặc biệt là về việc sử dụng các trang web
                 
                </p>
              </div>
              <div v-bind:class="{'hidden': openTab !== 3, 'block': openTab === 3}">
                <p>
                  Những câu đánh giá sản phẩm hay, nếu như bạn là người mua hàng thường xuyên thì chắc hẳn đã nghĩ tới những câu đánh giá sản phẩm hay ở trên sàn thương mại điện tử nói chung.
                  Với những câu đánh giá sản phẩm hay thì sẽ có thể giúp cho không chỉ là người mua hàng thiếu ý tưởng đánh giá, mà còn giúp cho nhà bán hàng trong việc sáng tạo các câu đánh giá để seeding cho những sản phẩm đăng bán của mình. Hôm nay hãy cùng Azgad tìm hiểu về những câu đánh giá sản phẩm hay này nhé!
                </p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
<div>

  <div class=" flex items-center justify-end">
    <label class="label cursor-pointer">
      <input type="checkbox" checked="checked" class="checkbox" />
      <span class="label-text mr-3">&nbsp;Đồng ý điều khoản</span>      
    </label>

  </div>
  
  <div class="flex justify-end items-center mt-3">
    <button class="bg-white hover:bg-green-500 text-green-700 font-semibold hover:text-white py-2 px-4 border border-green-500 hover:border-transparent rounded">
      Thêm vào giỏ hàng
    </button>
    <div class="w-4"></div>
    <RouterLink to="/gsaler/cart">
      <button  class="mr-3 bg-white hover:bg-green-500 text-green-700 font-semibold hover:text-white py-2 px-4 border border-green-500 hover:border-transparent rounded">
        Mua hàng
      </button>
    </RouterLink>
  </div>
</div>
     
</div>
</template>

<script >
import { useRouter } from 'vue-router'

export default {
  name: "ProductDetail",
  props: {
      productId: {
        type: Number,
        required: false
      }
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
const supplier = () => {
    router.push({name: 'ProductSupplier',params: { id: '1' }})
}

const cart = () => {
    router.push({name: 'ManageCart'})
}
</script>

