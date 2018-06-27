<template>
  <b-form id="seatchForm" class="search fadeIn"  @submit="search" >
   <b-input-group prepend="Current weather for" variant="primary">
    <b-input-group-append>
      <b-form-input id="country" v-model="parameters.country" placeholder="country" required></b-form-input>
      <b-form-input id="city" v-model="parameters.city" placeholder="city" required></b-form-input>
      <b-btn id="searchBtn" variant="primary" type="submit">Search</b-btn>
    </b-input-group-append>
  </b-input-group>
</b-form>
  
</template>

<script>

export default {
  name:"search",
  data (){
    return {
      parameters:{
        country: "",
        city: ""
      }
    }
  },
  methods: {

    search (evt) {
      evt.preventDefault();
      this.$emit('weatherInfoChanged', null);
      this.axios.get('/api/v1/weather/'+this.parameters.country.trim()+'/'+this.parameters.city.trim())
        .then(response =>{
          this.$emit('weatherInfoChanged', response.data);
        }).catch(error => {
          this.$emit('weatherInfoChanged', { status: 'Failure', message: error.message});
        });
    },
  }
};
</script>
