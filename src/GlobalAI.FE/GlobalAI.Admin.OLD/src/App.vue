<template>
    <component v-if="$route.meta.layout" :is="$route.meta.layout">
        <router-view></router-view>
    </component>
    <router-view v-else></router-view>
</template>

<script>
import { getListDichVu, getMyPermissions } from './api/api.dichvu'

export default {
    created() {
        // getMyPermissions()
        //     .then((res) => getListDichVu())
        //     .then()
    },
}
</script>
