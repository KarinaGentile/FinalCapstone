<template>
  <div>
    <h4 style="background-color: white;">{{this.selectedSeatNumbers}}</h4>
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
  data() {
    return {
      movieId: 0,
      selectedSeatNumbers: ['F2', 'F3']
    };
  },
  props: {
    date: String, //YYYY-MM-DD
    startTime: String, //HH:MM
    price: Number
  },
  created() {
    this.movieId = this.$route.params.id;
    if (this.$route.params.selectedSeats) {
      this.selectedSeatNumbers = this.$route.params.selectedSeats;
    }
    console.log(
      `Checkout created with seatnums: ${this.$route.params.selectedSeats}`
    );
  }
};
</script>

<style>
</style>