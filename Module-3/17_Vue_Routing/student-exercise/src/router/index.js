import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home'
import MyBooks from "../views/MyBooks"
import NewBook from "../views/NewBook"
import BookDetails from "../views/Book.vue"

Vue.use(VueRouter);

const routes = [
{
  path: "/",
  name: "Home",
  component: Home
},
{
  path: "/myBooks",
  name: "MyBooks",
  component: MyBooks
},
{
  path: "/addBook",
  name: "AddBook",
  component: NewBook
},
{
  path: "/book/:id",
  name: "Book",
  component: BookDetails
}
];

const router = new VueRouter({
  mode: 'history',
  routes
});

export default router;
