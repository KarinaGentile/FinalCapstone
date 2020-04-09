<template>
  <div class="Showings">
    <router-link v-bind:to="{name:'seat-selection', params:{id:mId}}"> 
    <button v-for="s in showings" v-bind:key="s.id">{{s.startTimeFormatted}}
    </button></router-link>
  </div>
</template>

<script>
export default {
  data() {
    return {
    };
  },
  props:
  {
    showings: Array,
  }
};
</script>

<style>
.Showings {
  display: flexbox;
}

button {
  background-color: rgb(194, 180, 180);
}

</style>