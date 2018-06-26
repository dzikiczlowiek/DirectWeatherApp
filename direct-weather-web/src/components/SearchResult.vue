<template>
  <div v-if="response">
    <div v-if="response.status == 'Ok'">
    <WeatherInfo v-bind:weatherInfo="response.payload"></WeatherInfo>
    </div>
    <div v-else>
      {{response.message}}
    </div>
  </div>
</template>

<script>
import WeatherInfo from './WeatherInfo';

export default {
  name:"result",
  props: ['searchResult'],
  components: {
    WeatherInfo
    },
  data () {
    return {
      response: "",
    }
  },
  methods: {
    created: function () {
        this.response = this.searchResult;
    }
  },
  watch: {
      searchResult: function (val) {
      this.response = val;
    }
  }
};
</script>
