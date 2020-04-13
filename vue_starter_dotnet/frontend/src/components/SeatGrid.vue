<template>
  <div>
    <!--
      grid representing seats in the theater goes here
      it's then imported into movie moviedetail
      each seat is able to be clicked on or off unless already reserved
    -->
    <h3>Please select your seats</h3>
    <p>You have {{totalTickets - numSeatsSelected}} tickets remaining</p>
    <br />
    <p>----Screen----</p>
    <div id="seatGridContainer">
      <input
        type="button"
        class="seatButton"
        v-bind:key="s.seatId"
        v-for="s in seats"
        v-bind:value="s.seatNumber"
        v-bind:id="s.seatId"
        @click.stop="seatClicked(s.seatId)"
        v-bind:class="{isAvailable: s.isAvailable, isSelected: s.isSelected}"
      />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      seats: [
        { seatId: 0, seatNumber: "A1", isAvailable: true, isSelected: false }
      ],
      numSeatsSelected: 0
    };
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
      console.table(arr);
      return arr;
    },
    seatClicked(id) {
      let seatIndex = this.seats.findIndex(seat => (seat.seatId === id));
      let seat = this.seats[seatIndex];
      if (seat.isAvailable && (this.totalTickets > this.numSeatsSelected || seat.isSelected)) {
        seat.isSelected = !seat.isSelected;
        this.numSeatsSelected = this.countSelectedSeats()
      }
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
    }

  },
  created() {
    this.seats = this.generateSeatGrid();
    this.devModeReserveRandomSeats();
  },
  props: {
    totalTickets: Number
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

.isAvailable {
  background-color: lightgray;
}

input {
  background-color: palevioletred;
}
</style>
