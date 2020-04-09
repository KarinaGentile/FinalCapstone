<template>
  <div id="movieTile">
    <router-link v-bind:to="{name:'movie-detail', params:{id:mId}}">
      <img class="poster" v-bind:src="mPoster" />
    </router-link>
    <div id="descriptionBox">
      <router-link v-bind:to="{name:'movie-detail', params:{id:mId}}">
        <h3>{{mTitle}}</h3>
      </router-link>
      <h3>{{mRated}} ({{mGenre}})</h3>
      <!-- <h3>{{mTitle}} --- {{mRating}} ({{mGenre}})</h3> -->
      <p class="bold">Starring: {{mActors}}</p>
      <p>{{mPlot}}</p>
      <p></p>
      <p v-if="isDetailPage === true" class="bold">
        Showtimes:
        <select id="dates" name="dates">
          <option v-bind:value="today"></option>
          <option value="day1">Thursday</option>
          <option value="day2">Friday</option>
          <option value="day3">Saturday</option>
          <option value="day4">Sunday</option>
          <option value="day5">Monday</option>
          <option value="day6">Tuesday</option>
          <option value="day7">Wednesday</option>
        </select>
      </p>
      <p v-if="isDetailPage !== true" class="bold">Today's Showtimes:</p>
      <Showings v-bind:showings="this.showings"></Showings>
    </div>
  </div>
</template>
<!--router-link to="/movies/:id" -->
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
      dropDownDates:[

      ]
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
    isDetailPage: Boolean,
    day1: Date
    // day2:Date,
    // day3:Date,
    // day4:Date,
    // day5:Date,
    // day6:Date,
    // day7:Date,
    // day8:Date
  },
  components: {
    Showings
  },
  methods:{
function name(params) {
  
}
  },
  created() {
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