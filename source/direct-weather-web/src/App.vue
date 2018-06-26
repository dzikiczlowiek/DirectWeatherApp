<template>
<div id="app" >
  <div class="weather-card">
    <div class="search">
      <div class="search-box">
        <h2>Weather App</h2>
        <Search v-on:weatherInfoChanged="weatherInfoChanged" ></Search>
        <SearchResult v-bind:searchResult="searchResult"></SearchResult>
        <div id="spinner" v-if="!searchResult && searchInitialized" >
          <half-circle-spinner :animation-duration="1000" :size="60" color="#007bff" />
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
import Search from './components/Search';
import SearchResult from './components/SearchResult';
import { HalfCircleSpinner } from 'epic-spinners'

export default {
  name: 'app',
  components: {
    Search,
    SearchResult,
    HalfCircleSpinner
  },
  data (){
    return {
      searchResult: "",
      searchInitialized: false
    }
  },
  methods:{
    weatherInfoChanged: function(searchResult){
      this.searchResult = searchResult;
      this.searchInitialized = true;
    }
  }
}
</script>

<style>
  #app {
    align-items: center;
    display: flex;
    flex-direction: column;
    height: 100%;
    justify-content: center;
  }

  #spinner{
    align-items: center;
    display: flex;
    justify-content: center;
    margin: 25px;
  }

  .weather-card {
    background-color: #fbfbfb;
    border-radius: 3px;
    box-shadow: 0px 0px 150px 0px rgba(0,0,0,0.5);
    color: #383842;
    display: flex;
    flex-direction: column;
    margin-top: 10vh;
    max-width: 600px;
    min-height: 410px;
    padding: 32px;
    position: relative;
    width: 100%;
    z-index: 1;
    }

  .search{
    display: flex;
    flex-direction: row;
    margin-bottom: 8px;
    position: relative;
    z-index: 1;
  }

  .search-box{
      flex: 1;
      position: relative;
  }

  @media(max-width: 650px) {
    height: initial;
    border-radius: 0;
    margin: 32px;
    max-width: 500px;
    padding: 16px;
  }

  @media(max-width: 550px) {
    box-shadow: none;
    margin: 0;
    max-width: 100%;
    min-height: 100vh;
  }
</style>


