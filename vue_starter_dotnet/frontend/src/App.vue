<template>
  <div id="app">
    
    <div id="nav">
       
      <h1 class="welcome">Small Town Cinemas</h1>
      
      <div v-if="user">
        Logged in
        <div>
          <button v-on:click="logout">Logout</button>
        </div>
      </div>
      <div v-else>
        <div>
          <router-link :to="{name: 'login'}">Login</router-link>
        </div>

        <div>
          <router-link :to="{name: 'register'}">Register</router-link>
        </div>
      </div>
      <router-link to="/">Home</router-link>
    </div>

    <router-view />
  </div>
</template>

<script>
import auth from "@/auth.js";

export default {
  data() {
    return {
      user: null,
    };
  },
  methods: {
    logout() {
      auth.logout();
      this.$router.push('/login');
      this.user = null;
    },
  },
  created() {
    this.user = auth.getUser();
  },
  watch: {
    $route: function() {
      this.user = auth.getUser();
    }
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
  /* background-image: url("../../src/backgroundimg.jpg"); */
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-position: center; 
  background-size: cover;
  font-family: "Helvetica", sans-serif;
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
  float: left;
}
.nav li {
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
.welcome{
   font-family: "Helvetica";
  font-size:45px;
  align-content: left;
  outline-color: black;
   color: white;
    font-size: 50px;
    text-shadow: -1px 1px 2px #000,
                  1px 1px 2px #000,
                  1px -1px 0 #000,
                  -1px -1px 0 #000;
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

button {
  font-weight: bold;
}
.flexcontainer{
  display:flex;
  flex-direction: column;
align-items: center;
justify-content: center;
}

</style>

