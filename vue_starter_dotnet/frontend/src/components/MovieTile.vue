<template>
  <div id="movieTile" >
    <router-link v-bind:to="{name:'movie-detail', params:{id:mId}}">
      <img class="poster" v-bind:src="mPoster" />
    </router-link>
    <div id="descriptionBox" v-on:showing-selected="passShowSelEvent" >
      <router-link v-bind:to="{name:'movie-detail', params:{id:mId}}">
        <h3>{{mTitle}}</h3>
      </router-link>
      <h3>{{mRated}} ({{mGenre}})</h3>
      <p class="bold">Starring: {{mActors}}</p>
      <p>{{mPlot}}</p>
      <p></p>
      <p v-if="isDetailPage === true" class="bold">
        Showtimes for:
        <select
          @change="newDateSelected"
          id="dates"
          name="dates"
          v-model="selectedDate"
        >
          <option
            v-bind:key="d"
            v-bind:value="d"
            v-for="d in dropDownDates"
            aria-placeholder="Select a Date"
          >{{d}}</option>
        </select>
      </p>
      <p v-if="isDetailPage !== true" class="bold" p.message="hide">Today's Showtimes:</p>
      <Showings v-bind:showings="this.showings" v-on:showing-selected="passShowSelEvent"></Showings>
    </div>
  </div>
</template>
<script>
import Showings from "../components/Showings";

export default {
  data() {
    return {
      showings: [
        {
          showingId: 0,
          startTime: "",
          endTime: "",
          movieId: 0,
          theaterId: 0
        }
      ],
      selectedDate: null,
      dropDownDates: []
    };
  },

  props: {
    mId: Number,
    mTitle: String,
    mRated: String,
    mPlot: String,
    mActors: String,
    mRuntime: Number,
    mPoster: String,
    mIMDBId: String,
    mGenre: String,
    isDetailPage: Boolean
  },
  components: {
    Showings
  },
  methods: {
    
    passShowSelEvent() {
      console.log("got showing selected event");
      this.$emit("display-tickets");
    },
    fillInDate() {
      let today = new Date();
      console.log(today);
      for (let i = 0; i < 7; i++) {
        let d = new Date();
        d.setDate(today.getDate() + i);
        this.dropDownDates[i] = d;
        // d.setDate(d.getDate() + i);
      }
      console.log(this.dropDownDates);
    },
    newDateSelected() {
      console.log("new date selected");
      console.log(this.selectedDate);
      let searchDate = this.formatDate(this.selectedDate);
      console.log(searchDate);
      let url = process.env.VUE_APP_REMOTE_API;
      url += `/api/showings/${this.mId}/${searchDate}`;
      // url += `/api/showings/2`;
      console.log("Generated url: " + url);
      fetch(url)
        .then(response => {
          if (!response.ok) {
            console.log("Response status: " + response.status);
            console.log("Response status text: " + response.statusText);
            throw new Error("Netw. response not ok");
          }
          return response.json();
        })
        .then(json => {
          // console.table(json);
          this.showings = json;
        })
        .then(() => {
          window.alert(`You have selected showtimes for ${this.selectedDate}`);
        });
    },
    formatDate(date) {
      let d = new Date(date),
        month = "" + (d.getMonth() + 1),
        day = "" + d.getDate(),
        year = d.getFullYear();
      console.log("formatted date: " + year + month + day);
      // console.log('format: '+month);
      if (month.length < 2) {
        month = "0" + month;
      }
      if (day.length < 2) {
        day = "0" + day;
        console.log([year, month, day].join("-"));
      }
      return `${year}-${month}-${day}`;
    }
  },

  created() {
    this.fillInDate();
    console.log(this.mId);
    let url = process.env.VUE_APP_REMOTE_API;
    url += `/api/showings/${this.mId}`;
    // url += `/api/showings/2`;
    console.log("Generated url: " + url);
    fetch(url)
      .then(response => {
        if (!response.ok) {
          console.log("Response status: " + response.status);
          console.log("Response status text: " + response.statusText);
          throw new Error("Netw. response not ok");
        }
        return response.json();
      })
      .then(json => {
        // console.table(json);
        this.showings = json;
      });
  }
};
</script>

<style scoped>
#movieTile {
  display: flex;
  padding-left: 3px;
  padding-right: 3px;
  padding-top: 5px;
  padding-bottom: 5px;
  background-color: lightgray;
  border-bottom: 2px solid black;
}

#descriptionBox {
  display: flex;
  flex-direction: column;
}

.poster {
  margin-right: 10px;
}

a:hover,
a:link,
a:active {
  text-decoration: none;
}
.bold {
  font-weight: bold;
}
</style>