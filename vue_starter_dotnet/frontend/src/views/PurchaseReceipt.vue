<template>
  <div>
    <p>Receipt for purchase {{purchaseId}}</p>
  </div>
</template>

<script>
export default {
  name: "PurchaseReceipt",
  data() {
    return {
      purchaseId: 0,
      receipt: {
        numTickets: 0,
        customerName: "",
        price: 0.0,
        theatre: "",
        startTime: "",
        movieName: "",
        seatNumbers: [],
        purchaseTimeStamp: ""
      }
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