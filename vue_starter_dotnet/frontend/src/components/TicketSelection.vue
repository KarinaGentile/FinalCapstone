<template>
  <div id="ticketInterface">
      
      <h3>Please select the number and type of tickets</h3>
      <label>Adults ($8.75): </label>
      <input @change="getTotalTickets" type="number" v-bind:max="maxAdult" min="0" v-model.number="adultTickets"/>
      <label>Children ($5.25): </label>
      <input @change="getTotalTickets" type="number" v-bind:max="maxChild" min="0" v-model.number="childTickets" />
      <label>Seniors ($6.00): </label>
      <input @change="getTotalTickets" type="number" v-bind:max="maxSenior" min="0" v-model.number="seniorTickets" />
      <p v-bind:key="totalTickets" class="block">Total number of tickets: {{totalTickets}}</p>
      <p class="estimate" v-bind:key="totalPrice">Your estimated total is ${{totalPrice}}</p>
      
      
      <input @click="confirmSelection" class="block" type="button" value="Confirm selection"/>
  </div>
</template>

<script>
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
            totalPrice: 0.00
        
        }
    },
    methods: {
        confirmSelection() {
            console.log('Selection confirmed')
            this.$emit('selection-confirmed')
        },
        getTotalTickets() {
            this.maxAdult = 9 - (this.childTickets + this.seniorTickets);
            this.maxChild = 9 - (this.adultTickets + this.seniorTickets);
            this.maxSenior = 9 - (this.childTickets + this.adultTickets);
            this.totalTickets = this.childTickets + this.adultTickets + this.seniorTickets;
            console.log('children: '+this.childTickets)
            console.log('adult: '+this.adultTickets)
            console.log('senior: '+this.seniorTickets)
            console.log('total: '+this.totalTickets)
            return this.totalTickets;
        },
            getTotalPrice() {
            let childPrice = 5.25;
            let adultPrice = 8.75;
            let seniorPrice = 6.00
            this.totalPrice = childPrice + adultPrice + seniorPrice;
            console.log('total: '+this.totalPrice)
            return this.totalPrice;
        }
    }
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

.estimate{
    text-align: left;
}
</style>