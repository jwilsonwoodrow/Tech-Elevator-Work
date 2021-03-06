import Vue from 'vue'
import VueRouter from 'vue-router'
import Products from "../views/Products.vue"
import ProductDetail from "../views/ProductDetail.vue"
import AddReview from "../views/AddReviewPage.vue"
import About from "../views/About.vue"

Vue.use(VueRouter)
/*
  01: Create the home page and a route for the home page
    * Add Products.vue View, which contains ProductsList.vue component
    * Add a route to the routes table
*/
const routes = [
  {
    path: "/",
    name: "products", //not required, acts like an id
    component: Products,
  },
  {
    path: "/products/:id",
    name: "product-detail",
    component: ProductDetail,
  },
  {
    path: "/products/:id/add-review",
    name: "add-review",
    component: AddReview,
  },
  {
    path: "/about",
    name: "about",
    component: About
  }


]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
