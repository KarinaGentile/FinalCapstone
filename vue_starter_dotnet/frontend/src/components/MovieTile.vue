<template>
  <div id="movieTile">
    <img class="poster" v-bind:src="mPosterURL" />
    <div id="descriptionBox">
      <h3>{{mTitle}} --- {{mRating}} ({{mGenre}})</h3>
      <p>Starring: {{mCast}}</p>
      <p>{{mPlot}}</p>
      <p></p>
      <p></p>
      <Showings></Showings>
    </div>
  </div>
</template>

<script>
import Showings from "../components/Showings";

export default {
  data() {
    return {};
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