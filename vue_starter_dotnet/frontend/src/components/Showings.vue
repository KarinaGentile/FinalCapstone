<template>
  <div class="Showings">
    <!-- <router-link v-bind:to="{name:'ticket-selection', params:{ticketId}}"> 
    <button v-for="s in showings" v-bind:key="s.id">{{s.startTimeFormatted}}
    </button></router-link> -->
    <button @click="showingSelected" v-for="s in showings" v-bind:key="s.id">{{s.startTimeFormatted}}
    </button>
  </div>
</template>
<!-- When I click on a showtime, 3 drop-downs or counter buttons show up for adult, child, & senior ticket options.
After selection, estimated total populates & seatgrid shows up below.
If startime < 12:00PM, -$2.00 for each ticket
I am able to reserve as many seats as # of tickets that have been selected.
-->
<script>
export default {
  data() {
    return {
    };
  },
  props:
  {
    showings: Array,
  },
  methods: {
    showingSelected($event) {
      this.$emit('showing-selected',$event.target.innerText)
      console.log('button pressed for sel showing')
    }
  }
};
</script>

<style>
.Showings {
  display: flexbox;
}

button {
  background-color: rgb(194, 180, 180);
}

</style>