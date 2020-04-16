<template>
  <div>
    <!--
      grid representing seats in the theater goes here
      it's then imported into movie moviedetail
      each seat is able to be clicked on or off unless already reserved
    -->
    <h3 class="text">Please select your seats</h3>
    <h4 class="text">You have {{totalTickets - numSeatsSelected}} tickets remaining</h4>
    <br />
    <p class="screen">Screen</p>
    <div id="seatGridContainer">
      <input
        type="button"
        class="seatButton"
        v-bind:key="s.seatNumber"
        v-for="s in seats"
        v-bind:value="s.seatNumber"
        v-bind:id="s.seatNumber"
        @click.stop="seatClicked(s.seatId)"
        v-bind:class="{isAvailable: s.isAvailable, isSelected: s.isSelected}"
      />
    </div>

    <p></p>

    <router-link
      v-if="totalTickets === numSeatsSelected"
      v-bind:to="{name:'check-out', params: {id: movieId, selectedSeats: seatNumbers, date: date, startTime: startTime, price: totalPrice}}"
    >
      <input class="block" type="button" value="Check Out" />
    </router-link>
  </div>
</template>

<script>
export default {
  data() {
    return {
      seats: [
        { seatId: 0, seatNumber: "A1", isAvailable: true, isSelected: false }
      ],
      // seatNumbers: "A1-A2", // hardcoded
      numSeatsSelected: 0
    };
  },
  computed: {
    seatNumbers: function () {
      let str = "";
      this.seats.forEach(s => {
        if (s.isSelected) {
          str += `${s.seatNumber}-`
        }
      });
      return str;
    }
  },
  methods: {
    generateSeatGrid() {
      let arr = [];
      let row = "A";
      let seatNum = 1;
      for (let i = 0; i < 150; i++) {
        arr.push({
          seatId: i,
          seatNumber: `${row}${seatNum}`,
          isAvailable: true,
          isSelected: false
        });
        seatNum = seatNum + 1;
        if (seatNum > 15) {
          seatNum = 1;
        }
        if (i >= 134) {
          row = "J";
        } else if (i >= 119) {
          row = "I";
        } else if (i >= 104) {
          row = "H";
        } else if (i >= 89) {
          row = "G";
        } else if (i >= 74) {
          row = "F";
        } else if (i >= 59) {
          row = "E";
        } else if (i >= 44) {
          row = "D";
        } else if (i >= 29) {
          row = "C";
        } else if (i >= 14) {
          row = "B";
        }
      }
      // console.table(arr);
      return arr;
    },
    seatClicked(id) {
      let seatIndex = this.seats.findIndex(seat => seat.seatId === id);
      let seat = this.seats[seatIndex];
      if (
        seat.isAvailable &&
        (this.totalTickets > this.numSeatsSelected || seat.isSelected)
      ) {
        seat.isSelected = !seat.isSelected;
        this.numSeatsSelected = this.countSelectedSeats();
      }
      console.log("seatgrid price total: " + this.totalPrice);
    },
    countSelectedSeats() {
      let count = 0;
      this.seats.forEach(s => {
        if (s.isSelected) {
          count++;
        }
      });
      return count;
    },
    devModeReserveRandomSeats() {
      this.seats.forEach(s => {
        const rand = Math.random();
        if (rand < 0.1) {
          s.isAvailable = false;
        }
      });
    },
    markReservedSeats() {
      this.seats.forEach(seat => {
        if (this.reservedSeats.includes(seat.seatNumber)) {
          seat.isAvailable = false;
        }
      });
    }
  },
  created() {
    this.seats = this.generateSeatGrid();
    // this.devModeReserveRandomSeats();
    this.markReservedSeats();
  },
  props: {
    totalTickets: Number,
    reservedSeats: Array,
    movieId: Number,
    date: String,
    startTime: String,
    totalPrice: Number
  }
};
</script>

<style scoped>
#seatGridContainer {
  display: grid;
  grid-template-columns: auto auto auto auto auto auto auto auto auto auto auto auto auto auto auto;
}

input.isSelected {
  background-color: lightskyblue;
}

.isSelected {
  background-color: lightskyblue;
}

.isAvailable {
  background-color: lightgray;
}

input {
  background-color: palevioletred;
}

.block {
  padding: 10px;
  background-color: lightgrey;
  font-weight: bolder;
  color: rgb(85, 7, 7);
  border-block-end-color: darkred;
}

.text{
  color:ghostwhite;
}

.screen{
  color:honeydew;
  border:black;
  background-color:black;
  width: 100%;
  height: 25px;
  border-radius: 50% / 100%;
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>
