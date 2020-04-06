<template>
  <div class="home">
    <h1>Now Playing:</h1>
    <ul>
    <li></li>
    <li></li>
    <li></li>
    </ul>
    <p></p>
  </div>
</template>

<!--// import or connect to list of movies 
// display the list of movies -->


<script>
export default {
  name: 'home'
}
</script>
<!--figure out layout for the list -->


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
  background-image: lightcoral;
  font-family: "Roboto", sans-serif;
}
#app {
  width: 80vw;
  height: 100%;
  background-color: white;
}
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
  float:left;
}
.nav li {
  /* display: inline-block; */
  padding-right: 20px;
   float:left;
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

</style>
