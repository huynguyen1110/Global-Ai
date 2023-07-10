<template>
    <h1>Detail post</h1>
  </template>
  <script>
  import Navbar from "../components/Navbars/AuthNavbar.vue";
  import FooterComponent from "../components/Footers/Footer.vue";
  
  import team2 from "../assets/img/team-2-800x800.jpg";
  
  export default {
    data() {
      return {
        team2,
      };
    },
    components: {
      Navbar,
      FooterComponent,
    },
  };
  </script>
  