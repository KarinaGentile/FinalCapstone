<template>
  <div>
    <Purchase v-bind:showtime="startTime"></Purchase>

    <!--PurchaseReceipt generates & is emailed to customer, PurchaseReceipt is also able to be a bookmarked as a link -->
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
  }
};
</script>

<style>
</style>