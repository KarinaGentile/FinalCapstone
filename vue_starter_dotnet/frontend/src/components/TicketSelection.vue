<template>
  <div id="ticketInterface">
    <h3>Please select your tickets:</h3>
     <ul class="flexcontainer">
    <span>
   
    <label>ADULTS($8.75):   </label>
    <input
    id="Adult"
      @change="getTotalTickets"
      type="number"
      v-bind:max="maxAdult"
      min="0"
      v-model.number="adultTickets"
    />
    
    </span>
    </ul>
     <ul class="flexcontainer">
    <span>
    <label>CHILDREN($5.25):</label>
    <input
    id="Child"
      @change="getTotalTickets"
      type="number"
      v-bind:max="maxChild"
      min="0"
      v-model.number="childTickets"
    />
  
    </span>
      </ul>
        <ul class="flexcontainer">
    <span>
    <label>SENIORS($6.00):   </label>
    <input
    id="Senior"
      @change="getTotalTickets"
      type="number"
      v-bind:max="maxSenior"
      min="0"
      v-model.number="seniorTickets"
    />
    </span>
    </ul>
    <ul class="flexcontainer">
    <p v-bind:key="totalTickets" class="block">Total number of tickets: {{totalTickets}}</p>
    <p class="estimate" v-bind:key="totalPrice">TOTAL: {{totalPrice}} + tax</p>
    <p>Catching a film before noon? Enjoy $2.00 off per ticket with our Matinee Special!</p>
    <input @click="confirmSelection" class="block" type="button" value="Select Seats" />
    </ul> 
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
      childPrice: 0.00,
      adultPrice: 0.00,
      seniorPrice: 0.00,
      totalPrice: 0.00,
      Showings
    };
  },
  props: {
    showings: Array,
    selectedStartTime: String
    // childPrice:Decimal,
    // adultPrice:Decimal,
    // seniorPrice:Decimal,
    // totalPrice:Decimal,
  },
  methods: {
    confirmSelection() {
      console.log("Selection confirmed");
      console.log(this.selectedStartTime);
      if (this.totalTickets > 0) {
        this.$emit("selection-confirmed", this.totalTickets, this.totalPrice);
      } else {
        window.alert("One or more tickets must be selected");
      }
    },
    getTotalTickets() {
      this.maxAdult = 9 - (this.childTickets + this.seniorTickets);
      this.maxChild = 9 - (this.adultTickets + this.seniorTickets);
      this.maxSenior = 9 - (this.childTickets + this.adultTickets);
      this.totalTickets =
        this.childTickets + this.adultTickets + this.seniorTickets;
      // console.log("children: " + this.childTickets);
      // console.log("adult: " + this.adultTickets);
      // console.log("senior: " + this.seniorTickets);
      // console.log("total: " + this.totalTickets);
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
const formatter = new Intl.NumberFormat('en-US', {
  style: 'currency',
  currency: 'USD',
  minimumFractionDigits: 2
})
function newGetTotalPrice(
  childTickets,
  adultTickets,
  seniorTickets,
  selectedStartTime
) {
  let childPrice = 0.00;
  let adultPrice = 0.00;
  let seniorPrice = 0.00;

  if (selectedStartTime < "12:00") {
    childPrice = 3.25 * childTickets;
    adultPrice = 6.75 * adultTickets;
    seniorPrice = 4.00 * seniorTickets;
  } else {
    childPrice = 5.25 * childTickets;
    adultPrice = 8.75 * adultTickets;
    seniorPrice = 6.00 * seniorTickets;
  }
  let totalPrice = childPrice + adultPrice + seniorPrice;
  console.log("total: " + totalPrice);
  return formatter.format(totalPrice);
}

</script>

<style scoped>
#label{
  text-emphasis: strong;
}
#ticketInterface {
  padding-left: 3px;
  padding-right: 3px;
  padding-top: 5px;
  padding-bottom: 5px;
  background-color: lightgray;
  border-bottom: 2px solid black;
}
.flexcontainer{
  display:flex;
  flex-direction: column;
align-items: center;
justify-content: center;
}

.Adult
{
  flex:1;
}
.Child
{
  flex:1;
}
.Senior
{
  flex:1;
}
.block {
  display: block;
  align-content: center;
    padding: 10px;
  background-color: lightgrey;
  font-weight: bolder;
  color: rgb(85, 7, 7);
  border-block-end-color: darkred;
}

.estimate {
  text-align: center;
  font-weight: bolder;
}


</style>