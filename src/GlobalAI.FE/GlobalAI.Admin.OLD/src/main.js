import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store';
import Toast from "vue-toastification";
import "vue-toastification/dist/index.css";
import Vue3EasyDataTable from 'vue3-easy-data-table';
import 'vue3-easy-data-table/dist/style.css';
import 'vue-multiselect/dist/vue-multiselect.css';
import moment from 'moment';
import Datepicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css';
import 'vue3-cute-component/dist/style.css'
import { plugin } from 'vue3-cute-component'
import './index.css';

/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core';

/* import font awesome icon component */
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';

/* import specific icons */
import { faDownload, faPrint, faFileWord, faUserSecret, faFileExcel, faSearch, faArrowLeft, faDoorOpen, faClose, faReply, faCheck, faHand, faEnvelope, faFolderOpen, faThumbsDown, faHourglassStart, faEye, faInfo, faCircleInfo, faBars, faTimes, } from '@fortawesome/free-solid-svg-icons';

/* add icons to the library */
library.add(faFileWord, faDownload, faPrint, faUserSecret, faFileExcel, faSearch, faArrowLeft, faDoorOpen, faClose, faReply, faCheck, faHand, faEnvelope, faFolderOpen, faHourglassStart, faThumbsDown, faInfo, faCircleInfo, faBars, faTimes)


const app = createApp(App).component('font-awesome-icon', FontAwesomeIcon);

app.config.globalProperties.$moment = moment;

app.component('EasyDataTable', Vue3EasyDataTable)
    .component('Datepicker', Datepicker)
    .use(router).use(store).use(Toast, {
        transition: "Vue-Toastification__bounce",
        maxToasts: 20,
        newestOnTop: true
    })
    .use(moment)
    .use(plugin)
    .mount('#app');
