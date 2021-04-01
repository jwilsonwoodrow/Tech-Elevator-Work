<template>
  <div class = "details">
    <h5 class="title">Title:{{ book.title }}</h5>
    <h5>Author: {{ book.author }}</h5>
    <img
      v-if="book.isbn"
      v-bind:src="
        'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'
      "
    />
  </div>
</template>
<script>
export default {
  name: "book-details",
  components: {},
  created() {
    this.book = this.$store.state.books.find(
      (item) => item.isbn === this.$route.params.id
    );
  },
};
</script>

<style>
</style>