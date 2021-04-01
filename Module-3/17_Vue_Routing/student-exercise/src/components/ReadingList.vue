<template>
  <div class="book-container">
    <router-link v-bind:to="{name: 'bookDetails', params:{isbn:book.isbn}}">
    <book-card
      v-bind:book="book"
      v-for="book in $store.state.books"
      v-bind:key="book.isbn"
      @click.native="viewBookDetails(book.isbn)"
    />
  </div>
</template>

<script>
import BookCard from "@/components/BookCard.vue";

export default {
  name: "reading-list",
  components: {
    BookCard,
  },
  props:{
    isbn: Number,
  },
  methods: {
    viewBookDetails(isbn) {
      this.$router.push(`/book/${isbn}`);
    },
  },
};
</script>

<style>
.book-container {
  display: flex;
  justify-content: space-evenly;
  flex-wrap: wrap;
}
</style>