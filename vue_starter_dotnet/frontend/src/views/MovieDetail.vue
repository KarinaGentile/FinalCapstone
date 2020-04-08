<template>
  <div id="movie">
    <section class="centeredPanel">
      <h3>Your movie id is {{mID}}</h3>
      <img class="poster" v-bind:src="mPosterURL" />
      <div id="descriptionBox">
        <h3>{{mTitle}} --- {{mRating}} ({{mGenre}})</h3>
        <p>Starring: {{mCast}}</p>
        <p>{{mPlot}}</p>
        <p></p>
        <p></p>
        <Showings v-bind:showings="this.showings"></Showings>
      </div>
    </section>
  </div>
</template>

<script>
export default {
  data() {
    return {
      movie: null,
      mID: 0,
      movies: []
    };
  },
  created() {
    let url = process.env.VUE_APP_REMOTE_API;
    url += "/api/movies";
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
        console.table(json);
        this.movies = json;
      });
    this.mID = this.$route.params.id;
    this.movie = this.movies.find(m => {
      m.movieID == this.mID;
    });
    console.log(this.movie);
  }
};
</script>

<style>
</style>

<!--After I click on a movie title or poster, I land on this page
Should only display one movie & list of showings for next 7 days 
Should have a button to initiate ticket purchase workflow
 -->