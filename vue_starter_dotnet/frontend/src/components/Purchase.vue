<template>
  <div>
    <section class="centeredPanel">
      <p
        class="reservefont"
      >You are reserving seats:{{this.selectedSeatNumbers.slice(0,this.selectedSeatNumbers.length-1)}}, on {{this.date}}, for {{this.movieTitle}}, Start Time:{{this.startTime}} Total Price is:{{this.price}}</p>
      <h3 class="text">Billing Information</h3>
      <p></p>
      <form>
        <ul class="flexcontainer">
          <label class="text">First Name:</label>
          <input id="firstName" type="text" required v-model="firstName" />
          <label class="text">Last Name:</label>
          <input id="lastName" type="text" required v-model="lastName" />
          <label class="text">Email:</label>
          <input id="email" type="text" required v-model="email" />
          <label class="text">Street Address:</label>
          <input id="streetAddress" type="text" required="true" />
          <label class="text">City:</label>
          <input id="city" type="text" required="true" />
          <label class="text">State:</label>
          <input id="state" type="text" required="true" v-model="state" />
          <label class="text">Zip Code:</label>
          <input id="zipcode" type="text" required="true" v-model="zipcode" />
          <label class="text">Country:</label>
          <input id="country" type="text" required="true" v-model="country" />
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
      country: "",
      purchaseId: 0,
      movieTitle: ""
    };
  },
  methods: {
    buyTickets() {
      if (
        this.firstName != "" &&
        this.lastName != "" &&
        this.email != "" &&
        this.state != "" &&
        this.zipcode != "" &&
        this.country != ""
      ) {
        // window.alert(`You have selected ${this.totalTickets} tickets for ${this.movieName} at ${this.showtime}`);
        // let readyToLoadNextPage = false;
        let url = process.env.VUE_APP_REMOTE_API;
        url += `/api/purchase/new/${this.email}/${this.price}/${this.selectedSeatNumbers}/${this.movieId}/${this.date}/${this.startTime}`;
        fetch(url)
          .then(response => {
            console.log("start log purchase fetch");
            console.log(response);
            console.log("end log purchase fetch");
            return response.json();
          })
          .then(json => {
            console.log("start log purchase json");

            console.log(json);
            console.log(json.purchase.purchaseId);
            console.log("end log purchase json");
            if (json.purchase.purchaseId > 0) {
              this.purchaseId = json.purchase.purchaseId;
              this.$router.push({
                name: "receipt",
                params: { id: this.purchaseId }
              });
            }
          });
      }
    }
  },
  props: {
    // totalTickets: Number,
    movieId: Number,
    selectedSeatNumbers: String,
    date: String,
    price: Number,
    startTime: String
  },
  created() {
    console.log("start log purchase created");
    console.log(`movie id: ${this.movieId}`);
    console.log(`seats: ${this.selectedSeatNumbers}`);
    console.log(`date: ${this.date}`);
    console.log(`start time: ${this.startTime}`);
    console.log(`price: ${this.price}`);
    console.log("end log purchase created");
    let url = process.env.VUE_APP_REMOTE_API;
    url += `/api/movies/${this.movieId}`;
    fetch(url)
      .then(response => {
        return response.json();
      })
      .then(json => {
        this.movieTitle = json.title;
      });
    console.log("purchase.vue movie title: " + this.movieTitle);
  }
};
</script>

<style>
.text {
  color: white;
  align-content: center;
}
.block {
  align-content: center;
  padding: 10px;
  background-color: lightgrey;
  font-weight: bolder;
  color: rgb(85, 7, 7);
  border-block-end-color: darkred;
}
.flexcontainer {
  align-content: center;
  padding: 10px;
}
.reservefont {
  color: white;
}
</style>