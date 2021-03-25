<template>


    <!-- v-on:click="filter = 0"
    v-bind:class="{ 'selected-well': filter === 0 }" -->
  <div
    class="well"
  >
    <span class="amount"> {{ averageRating }} </span>
    Average Rating
  </div>
</template>

<script>
export default {
  name: "AverageSummary",
  props: {
      theReviewArray: Array,
  },
  data(){
      return {
          
      }
  },
  computed: {
    averageRating() {
      // Calculate the average rating of all the reviews (add ratings of all reviews then divide by the count)
      if (this.theReviewArray.length === 0) {
        return 0;
      }

      let sum = this.theReviewArray.reduce((accum, review) => {
        return accum + review.rating;
      }, 0);
      return (sum / this.theReviewArray.length).toFixed(2);
    },

  },
};
</script>

<style scoped>
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