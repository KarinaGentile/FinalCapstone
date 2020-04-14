<template>
  <div>
      <Purchase></Purchase>
<<<<<<< HEAD
=======
      <PurchaseReceipt></PurchaseReceipt>
      <!--PurchaseReceipt generates & is emailed to customer, PurchaseReceipt is also able to be a bookmarked as a link -->
>>>>>>> b9dff9bba5d43aeb82cc8cf71d0e23d6a305657b
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