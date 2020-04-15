<template>
  <div>
    <section class="centeredPanel">
      <h3>Billing Information</h3>
      <p></p>
      <form>
        <ul class="flexcontainer">
          <label>First Name:</label>
          <input id="firstName" type="text" required v-model="firstName" />
          <label>Last Name:</label>
          <input id="lastName" type="text" required v-model="lastName" />
          <label>Email:</label>
          <input id="email" type="text" required v-model="email" />
          <label>Street Address:</label>
          <input id="streetAddress" type="text" required="true" />
          <label>City:</label>
          <input id="city" type="text" required="true" />
          <label>State:</label>
          <input id="state" type="text" required="true" v-model="state" />
          <label>Zip Code:</label>
          <input id="zipcode" type="text" required="true" v-model="zipcode"/>
          <label>Country:</label>
          <input id="country" type="text" required="true" v-model="country"/>
        </ul>
        <input @click="buyTickets" class="block" type="button" value="Buy Tickets" />
        <!--A purchase receipt generates using the above inputs, 
          seat(s) selected, # & type of tickets selected, showtime & movie
        Need to figure out if this should be a new view or the component loads below?-->
      </form>
    </section>
  </div>
</template>

<script>
export default {
  data() {
    return {
      firstName: "",
      lastName: "",
      email: "",
      streetAddress: "",
      city: "",
      state: "",
      zipcode: "",
      country: ""
    };
  },
  methods: {
    buyTickets() {
      if (this.firstName != "" && this.lastName !="" && this.email !="" && this.state !="" && this.zipcode !="" && this.country !="") {
        window.alert(`You have selected ${this.totalTickets} tickets for ${this.movieName} at ${this.showtime}`); 
        this.$router.push({
          name: "receipt",
          params: { id: 1 } //replace this with the actual purchaseId
        });
      }
    }
  },
  props:{
    totalTickets:Number,
    movieName:String,
    showtime:String
  }
};
</script>

<style>
</style>