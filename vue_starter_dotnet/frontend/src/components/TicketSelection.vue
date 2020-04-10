<template>
  <div id="ticketInterface">
    <h3>Please select the number and type of tickets</h3>
    <label>Adults ($8.75):</label>
    <input
      @change="getTotalTickets"
      type="number"
      v-bind:max="maxAdult"
      min="0"
      v-model.number="adultTickets"
    />
    <label>Children ($5.25):</label>
    <input
      @change="getTotalTickets"
      type="number"
      v-bind:max="maxChild"
      min="0"
      v-model.number="childTickets"
    />
    <label>Seniors ($6.00):</label>
    <input
      @change="getTotalTickets"
      type="number"
      v-bind:max="maxSenior"
      min="0"
      v-model.number="seniorTickets"
    />
    <p v-bind:key="totalTickets" class="block">Total number of tickets: {{totalTickets}}</p>
    <p class="estimate" v-bind:key="totalPrice">Your estimated total is ${{totalPrice}}</p>
    <p>Catching a film before noon? Enjoy $2.00 off per ticket with our Matinee Special!</p>
    <input @click="confirmSelection" class="block" type="button" value="Confirm selection" />
  </div>
</template>
<script>
import Showings from "../components/Showings";
export default {
  data() {
    return {
      childTickets: 0,
      adultTickets: 0,
      seniorTickets: 0,
      totalTickets: 0,
      maxChild: 9,
      maxAdult: 9,
      maxSenior: 9,
      childPrice: 0.0,
      adultPrice: 0.0,
      seniorPrice: 0.0,
      totalPrice: 0.0,
      Showings
    };
  },
  props: {
    showings: Array,
    selectedStartTime: String
  },
  methods: {
    confirmSelection() {
      console.log("Selection confirmed");
      console.log(this.selectedStartTime);
      this.$emit("selection-confirmed");
    },
    getTotalTickets() {
      this.maxAdult = 9 - (this.childTickets + this.seniorTickets);
      this.maxChild = 9 - (this.adultTickets + this.seniorTickets);
      this.maxSenior = 9 - (this.childTickets + this.adultTickets);
      this.totalTickets =
        this.childTickets + this.adultTickets + this.seniorTickets;
      console.log("children: " + this.childTickets);
      console.log("adult: " + this.adultTickets);
      console.log("senior: " + this.seniorTickets);
      console.log("total: " + this.totalTickets);
      this.totalPrice = newGetTotalPrice(
        this.childTickets,
        this.adultTickets,
        this.seniorTickets,
        this.selectedStartTime
      );
      return this.totalTickets;
    }
  },
  created() {
    console.log(
      "selectedStartTime from ticket interface" + this.selectedStartTime
    );
  }
};

function newGetTotalPrice(childTickets, adultTickets, seniorTickets, selectedStartTime) {
  let childPrice = 0;
  let adultPrice = 0;
  let seniorPrice = 0;

  if (selectedStartTime < "12:00") {
    childPrice = 3.25 * childTickets;
    adultPrice = 6.75 * adultTickets;
    seniorPrice = 4.0 * seniorTickets;
  } else {
    childPrice = 5.25 * childTickets;
    adultPrice = 8.75 * adultTickets;
    seniorPrice = 6.0 * seniorTickets;
  }
  let totalPrice = childPrice + adultPrice + seniorPrice;
  console.log("total: " + totalPrice);
  return totalPrice;
}
</script>

<style scoped>
#ticketInterface {
  padding-left: 3px;
  padding-right: 3px;
  padding-top: 5px;
  padding-bottom: 5px;
  background-color: lightgray;
  border-bottom: 2px solid black;
}

.block {
  display: block;
}

.estimate {
  text-align: left;
}
</style>