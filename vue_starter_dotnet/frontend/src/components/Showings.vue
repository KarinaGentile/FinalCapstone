<!-- 
v-for & v-bind for the showtime

do we need another api call here?
-->

<template>
  <div class="Showings">
    <button v-for="s in showings" v-bind:key="s.id">{{s.startTime}}</button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      // showings: [
      //   {
      //     id: 1,
      //     startTime: "10:00AM",
      //     endTime: "12:10PM"
      //   },
      //   {
      //     id: 2,
      //     startTime: "10:15AM",
      //     endTime: "12:00PM"
      //   }
      // ]
    };
  },
  props:
  {
    showings: Array,
    // sShowingId: Number,
    // sStartTime: Date,
    // sEndTime: Date,
    // sMovieId: Number,
    // sTheaterId: Number
  }
};
</script>

<style>
.Showings {
  display: flexbox;
  /* background-color: darkslategrey; */
}

</style>