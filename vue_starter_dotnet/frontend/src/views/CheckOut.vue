<template>
  <div>
      <Purchase></Purchase>
  </div>
</template>

<script>
import Purchase from "../components/Purchase";
export default {
    components: {
    Purchase

  },
  props: {
    selectedSeatNumbers: Array,
    movieId: Number,
    date: String, //YYYY-MM-DD
    startTime: String, //HH:MM
    price: Number
  },

}
</script>

<style>

</style>