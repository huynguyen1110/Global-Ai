<template>
    <HeaderVue />
    <div class="flex flex-col p-0">
        <section id="body">
            <BannerVue />
            <slot />
        </section>
    </div>
    <FooterVue />
</template>

<script>
    import HeaderVue from '../components/Header.vue';
    import FooterVue from '../components/Footer.vue';
    import BannerVue from '../components/Banner.vue';

    export default {
        components: {
            HeaderVue, FooterVue, BannerVue
        }
    }
</script>
