<template>
    <div class="flex flex-col items-center justify-center h-screen">
        <h1 class="text-4xl font-bold mb-4">Oops! Page not found.</h1>
        <p class="text-lg text-gray-600 mb-8">
            The page you are looking for does not exist or has been moved.
            Please check the URL and try again.
        </p>
        <router-link
            to="/"
            class="px-6 py-3 rounded-full bg-green-500 hover:bg-green-600 text-white font-semibold transition duration-300 ease-in-out"
            >Go back to home</router-link
        >
    </div>
</template>

<script>
export default {
    name: "NotFound",
    components: {
        // ...
    },
};
</script>

<style lang="scss">
// ...
</style>
