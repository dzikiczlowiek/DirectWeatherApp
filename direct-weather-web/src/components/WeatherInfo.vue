 <template>
    <div class="top">
        <div class="info">
            <div class="city">{{weatherInfo.location.city}}, {{weatherInfo.location.country}}</div>
            <div class="night">{{weatherInfo.dateTimestamp | moment("dddd, MMMM Do YYYY")}}</div>
            <div class="temp">{{weatherInfo.temperature.value}}° {{weatherInfo.temperature.format}}</div>
            <div class="humidity"><span>Humidity: </span>{{weatherInfo.humidity}}</div>
        </div>
</div>
</template>      

<script>
import moment from 'vue-moment';

export default {
  name:"weatherInfo",
  props: ['weatherInfo'],
  data () {
    return {
      weather: "",
    }
  },
  methods: {
    created: function () {
        this.weather = this.weatherInfo;
    }
  },
  watch: {
    weatherInfo: function (val) {
      this.weather = val;

    }
  }
};
</script>

<style >
.info .city:after {
	content: '';
	width: 15px;
	height: 2px;
	position: relative;
	display: inline-block;
	vertical-align: middle;
	margin-left: 10px;
}

.city span {
	font-size: 13px;
	font-weight: bold;

	text-transform: lowercase;
	text-align: left;
}

.temp {
	font-size: 73px;
	display: block;
	position: relative;
	font-weight: bold;
}

</style>
