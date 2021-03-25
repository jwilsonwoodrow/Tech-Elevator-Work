<template>
  <div>
    class="well" v-on:click="filter = 0" v-bind:class="{ 'selected-well': filter
    === 0 }" >
    <span class="amount"> {{ averageRating }} </span>
    Average Rating
  </div>
</template>

<script>
export default {
    name: "AverageSummary",
    props: {
        reviews: Object,
    },
    data() {
        return{}
    }
};
</script>

<style scoped>
div.main div.well-display {
  display: flex;
  justify-content: space-around;
}

div.main div.well-display div.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
  cursor: pointer;
}

div.main div.well-display div.well span.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}
</style>