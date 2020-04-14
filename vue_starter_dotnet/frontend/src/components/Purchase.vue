<template>
  <div>
    <section class="centeredPanel">
      <h3>Billing Information</h3>
      <p></p>
      <ul class="flexcontainer">
      <label>First Name:</label>
      <input id="firstName" type="text" />
      <label>Last Name:</label>
      <input id="lastName" type="text" />
      <label>Email:</label>
      <input id="email" type="text" />
      <label>Street Address:</label>
      <input id="streetAddress" type="text" />
      <label>City:</label>
      <input id="city" type="text" />
      <label>Last Name:</label>
      <input id="state" type="text" />
      <label>Zip Code:</label>
      <input id="zipcode" type="text" />
      <label>Country:</label>
      <input id="country" type="text" />
      </ul>
          <input @click="buyTickets" class="block" type="button" value="Buy Tickets" />
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
  }
};
</script>

<style>
</style>