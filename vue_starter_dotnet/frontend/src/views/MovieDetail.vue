<template>
  <div id="movie">
    <section class="centeredPanel">
      <h3>{{mTitle}}</h3>
      <img class="poster" v-bind:src="mPoster" />
      <div id="movieBox">
        <h3>{{mRated}} ({{mGenre}})</h3>
        <p>Starring: {{mActors}}</p>
        <p>{{mPlot}}</p>
        <p></p>
        <p></p>
        <!-- <Showings v-bind:showings="this.showings"></Showings> -->
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
    url += `/api/movies/${this.$route.param.id}`;
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
        this.movie = json;
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