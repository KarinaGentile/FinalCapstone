<template>
  <div>
    <section id="centeredPanel">
      <div id="info">
      <h2>Receipt for Purchase #: {{purchaseId}}</h2>
      <p>**********************************************************</p>
      <p id="bold">Movie title: {{receipt.movieName}}</p>
      <p>**********************************************************</p>
      <p>Number of tickets: {{receipt.numTickets}}</p>
      <p>Customer name: {{receipt.customerName}}</p>
      
      <p>Theater number: {{receipt.theater}}</p>
      <p>Start time: {{receipt.startTime}}</p>
      
      <p>**********************************************************</p>
      <p id="bold">Total price: ${{receipt.price}}</p>
      <p>**********************************************************</p>

      </div>
      <div id="info2" >
      <ul>
      <p>Seat numbers</p>
      <li v-bind:key="sn" v-for="sn in receipt.seatNumbers">{{sn}}</li>
      </ul>
      <p id="purchase">Purchase timestamp: {{receipt.purchaseTimeStamp}}</p>
      </div>
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
      showingId: 0
    };
  },
  created() {
    this.purchaseId = this.$route.params.id;
    //here we will look up the API to get the purchase with the Id
  }
};
</script>

<style>
#centeredPanel{
  clear: both;
  display: block;
  width: 100%;
  min-height: 450px;
  max-width: 750px;
  background-color: white;
  border-color: black;
  border-style: solid;

  border-radius: 7px;
  margin: 20px auto;
  padding-top: 0.5px;
  padding-bottom: 50px;
  padding-right: 20px;
  padding-left: 20px;
  align-content: center;
  text-align: center;
}
#info{
  text-align: left;
  
}
#info2{
  padding-top: 5px;
  text-align: center;
}
#purchase{
  padding-top: 5%;
}

#bold{
  font-weight: bold;
  text-align: center;
}


</style>