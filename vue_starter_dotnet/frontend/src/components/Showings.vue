<template>
  <div class="Showings">
    <button v-for="s in showings" v-bind:key="s.id">{{s.startTimeFormatted}}</button>
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