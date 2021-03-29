<template>
  <form class="new-book-form" @submit.prevent="addBook">
    <div>
      <label for="title">Title: </label>
      <input
        type="text"
        name="title"
        id="title"
        class="title-input"
        v-model="newBook.title"
      />
    </div>
    <div>
      <label for="author">Author: </label>
      <input
        type="text"
        name="author"
        id="author"
        class="author-input"
        v-model="newBook.author"
      />
    </div>
    <div>
      <label for="isbn">ISBN: </label>
      <input
        type="text"
        name="isbn"
        id="isbn"
        class="isbn-input"
        v-model="newBook.isbn"
      />
    </div>
    <div>
      <label for="read"> Has been read? </label>
      <input
        type="checkbox"
        name="read"
        id="read"
        class="read-input"
        v-model="newBook.read"
      />
    </div>
    <input type="button" value="Cancel" @click.prevent="Cancel"/>
    <input type="submit" value="Submit">
  </form>
</template>

<script>
export default {
  name: "NewBookForm",
  data() {
    return {
      newBook: {
        title: "",
        author: "",
        isbn: "",
        read: true,
      },
    };
  },
  methods: {
    addBook() {
      this.$store.commit("ADD_BOOK", this.newBook);
    },
  },
};
</script>

<style scoped>
</style>