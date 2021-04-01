<template>
  <div>
    <!-- TODO: Display title (h1) and description (p) -->
    <h1>{{ card.title }}</h1>
    <p>{{ card.description }}</p>
    <!-- TODO: Show an animation if loading, or the real page once loading is finished -->
    <img src="../assets/ping_pong_loader.gif" v-show="isLoading" />
    <!-- TODO: Add comments-list to the display (import the component)
                Pass the card.comments as a prop 
    -->
    <comments-list :comments="card.comments" />
    <!-- TODO: Add a link to go back to the Board -->
  </div>
</template>

<script>
// TODO: Import BoardService.js to have access to our data functions
import boardService from "../services/BoardService.js";
import CommentsList from "../components/CommentsList.vue";

export default {
  name: "card-detail",
  //  TODO: Create an empty card property in data (title, description, status, comments[])
  components: {
    CommentsList,
  },
  props: {
    cardId: Number,
    boardId: Number,
  },
  data() {
    return {
      isLoading: false,
      card: {},
    };
  },
  // TODO: Add an isLoading property to the data to manage the loading animation

  // TODO: Hook into the created lifecycle event to call getCard in boardService
  //        and populate the card

  created() {
    this.isLoading = true;
    boardService.getCard(this.boardId, this.cardId).then((returnedCard) => {
      this.card = returnedCard;
      this.isLoading = false;
    });
  },
};
</script>
