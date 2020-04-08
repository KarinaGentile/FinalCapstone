<template>
  <div id="movieTile">
    <router-link v-bind:to="{name:'movie-detail', params:{id:2}}"> <img class="poster" v-bind:src="mPosterURL"/></router-link>
    <div id="descriptionBox">
      <h3>{{mTitle}} --- {{mRating}} ({{mGenre}})</h3>
      <p>Starring: {{mCast}}</p>
      <p>{{mPlot}}</p>
      <p></p>
      <p></p>
      <Showings
      v-bind:showings="this.showings"></Showings>
    </div>
  </div>
</template>
<!--router-link to="/movies/:id" -->
<script>
import Showings from "../components/Showings";

export default {
  data() {
    return {
      showings:
      [
        {
          showingId: 0,
          startTime: "",
          endTime: "",
          movieId: 0,
          theaterId: 0
        }
      ]
    };
  },
  props: {
    mId: Number,
    mTitle: String,
    mRating: String,
    mPlot: String,
    mCast: String,
    mRuntime: Number,
    mPosterURL: String,
    mIMDBId: String,
    mGenre: String
  },
  components: {
    Showings
  },
  created() {
    console.log(this.mId)
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

</style>