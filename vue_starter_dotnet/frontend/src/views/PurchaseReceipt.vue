<template>
  <div>
       <section class="centeredPanel">
    <p>Receipt for purchase {{purchaseId}}</p>
    <section 
    v-bind:key="this.receipt.purchaseId"
    v-bind:rPrice="this.receipt.price"
    v-bind:rCustomer="this.receipt.customerName">
    </section>
  </div>
</template>

<script>
export default {
  name: "PurchaseReceipt",
  data() {
    return {
      receipt: {
        purchaseId: 1,
        numTickets: 2,
        customerName: "John Movie",
        price: 100.0,
        theater: "1",
        startTime: "10:00 am April 16th, 2020",
        movieName: "Wreck-it ralph",
        seatNumbers: ["F1", "G4"],
        purchaseTimeStamp: "11:10 am April 15th, 2020"
      },
      movieId: 0,
      userId: 0,
      theaterId: 0,
      showingId: 0,
      


    };
  },
  created() {
    this.purchaseId = this.$route.params.id;
    //here we will look up the API to get the purchase with the Id
  }
};
</script>

<style>
</style>