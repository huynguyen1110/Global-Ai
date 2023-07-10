import moment from 'moment';

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.use(moment);

  return {
    provide: { moment },
  };
});