<template>
  <div id="movieTile">
    <img class="poster" v-bind:src="mPosterURL" />
    <div id="descriptionBox">
      <h3>{{mTitle}} --- {{mRating}} ({{mGenre}})</h3>
      <p>Starring: {{mCast}}</p>
      <p>{{mPlot}}</p>
      <p></p>
      <p></p>
      <footer>[ShowTime1]   [Showtime2]   [Showtime3]</footer>
    </div>
  </div>    
</template>

<!--After I click on a movie title or poster, I land on this page
Should only display one movie & list of showings for next 7 days 
Should have a button to initiate ticket purchase workflow
 -->