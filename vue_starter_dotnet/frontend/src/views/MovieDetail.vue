<template>
  <div id="movie">
    <img class="poster" v-bind:src="mPosterURL" />
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

<!--After I click on a movie title or poster, I land on this page
Should only display one movie & list of showings for next 7 days 
Should have a button to initiate ticket purchase workflow
 -->