<template>
  <div class="home">
    <section class="centeredPanel">
      <h1>Now Playing:</h1>

      <movie-tile
        v-for="m in movies"
        v-bind:key="m.id"
        v-bind:mTitle="m.title"
        v-bind:mPosterURL="m.posterURL"
        v-bind:mRating="m.rating"
        v-bind:mPlot="m.plot"
        v-bind:mCast="m.cast"
        v-bind:mGenre="m.genre"
      />

      <p></p>
    </section>
  </div>
</template>

<!--// import or connect to list of movies 
// display the list of movies -->


<script>
import MovieTile from "../components/MovieTile";

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
      ]
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
  margin: 0;
  padding: 0;
  width: 100vw;
  height: 100%;
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  background-color: darkred;
  background-image: url("../../src/backgroundimg.jpg");
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-position: center; 
  background-size: cover;
  font-family: "Helvetica", sans-serif;
}
/* #app {
  width: 80vw;
  height: 100%;
  background-color: white;
} */
header {
  height: 50px;
  width: 100%;
  display: flex;
  flex-direction: row;
  background-color: rgb(247, 247, 247);
}
.nav {
  padding: 14px;
  margin: 0;
  flex: 1;
  list-style-type: none;
  float: left;
}
.nav li {
  /* display: inline-block; */
  padding-right: 20px;
  float: left;
}
.nav li a,
.nav li a:visited {
  text-decoration: none;
  color: rgb(56, 56, 146);
  text-transform: uppercase;
  font-size: 13px;
}
.nav li a:hover {
  text-decoration: none;
}

.fas {
  margin-right: 4px;
}
.content {
  padding: 20px;
}
ul {
  list-style-type: none;
}
section.centeredPanel {
  clear: both;
  display: block;
  width: 100%;
  min-height: 450px;
  max-width: 750px;
  background-color: rgb(100, 90, 90);
  border-radius: 7px;
  margin: 20px auto;
  padding-top: 0.5px;
  padding-bottom: 50px;
  padding-right: 20px;
  padding-left: 20px;
  align-content: center;
  text-align: center;
}
h1 {
  font-weight: bold;
}
</style>
