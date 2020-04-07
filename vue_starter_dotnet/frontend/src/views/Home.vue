<template>
  <div class="home">
    <section class="centeredPanel">
      <h1>Now Playing:</h1>

      <movie-tile
        v-for="m in movies"
        v-bind:key="m.movieId"
        v-bind:mTitle="m.title"
        v-bind:mPosterURL="m.posterURL"
        v-bind:mRating="m.rating"
        v-bind:mPlot="m.plot"
        v-bind:mCast="m.cast"
        v-bind:mGenre="m.genre"
        v-bind:mId="m.movieId"
      />

      <p></p>
    </section>
  </div>
</template>

<!--// import or connect to list of movies 
// display the list of movies -->


<script>
import MovieTile from "../components/MovieTile";
import Showings from "../components/Showings";

export default {
  name: "home",
  components: {
    MovieTile
  },
  data() {
    return {
      movies: [
        {
          id: 0,
          title: "",
          rating: "",
          plot: "",
          runtime: 0,
          cast: "",
          posterURL: "",
          genre: ""
        }
      ],
      Showings
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
  }
};
</script>



<style>
body {
  background-image: url("../../src/backgroundimg.jpg");
}

</style>
