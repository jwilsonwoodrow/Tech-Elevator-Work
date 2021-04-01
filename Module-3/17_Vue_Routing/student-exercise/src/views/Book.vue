<template>
  <book-details />
</template>

<script>
import BookDetails from "../components/BookDetails.vue";
export default {
  components: { BookDetails },
  data() {
    return {
      book: Object,
    };
  },
  created(){
      this.book = parseInt(this.$route.params.book)
  }
};
</script>

<style>
</style>