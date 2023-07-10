// import VueNumberFormat from '@coders-tm/vue-number-format'
import { component as VueNumber } from '@coders-tm/vue-number-format'

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.component('vue-number', VueNumber);
})