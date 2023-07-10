<template>
    <HeaderVue />
    <div class="flex flex-col p-0 h-full lg:h-750px">
        <section id="body">
            <slot />
        </section>
    </div>
    <FooterVue />
</template>

<script>
    import HeaderVue from '../components/Header.vue';
    import FooterVue from '../components/Footer.vue';

    export default {
        components: {
            HeaderVue, FooterVue
        }
    }
</script>
