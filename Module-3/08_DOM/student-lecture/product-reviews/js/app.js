const name = 'Cigar Parties for Dummies';
const description = 'Host and plan the perfect cigar party for all of your squirrelly friends.';
const reviews = [
  {
    reviewer: 'Malcolm Gladwell',
    title: 'What a book!',
    review:
      "It certainly is a book. I mean, I can see that. Pages kept together with glue (I hope that's glue) and there's writing on it, in some language.",
    rating: 3
  },
  {
    reviewer: 'Tim Ferriss',
    title: 'Had a cigar party started in less than 4 hours.',
    review:
      "It should have been called the four hour cigar party. That's amazing. I have a new idea for muse because of this.",
    rating: 4
  },
  {
    reviewer: 'Ramit Sethi',
    title: 'What every new entrepreneurs needs. A door stop.',
    review:
      "When I sell my courses, I'm always telling people that if a book costs less than $20, they should just buy it. If they only learn one thing from it, it was worth it. Wish I learned something from this book.",
    rating: 1
  },
  {
    reviewer: 'Gary Vaynerchuk',
    title: 'And I thought I could write',
    review:
      "There are a lot of good, solid tips in this book. I don't want to ruin it, but prelighting all the cigars is worth the price of admission alone.",
    rating: 3
  }
];

/**
 * Add our product name to the page title
 * Get our page page title by the id and the query the .name selector
 * once you have the element you can add the product name to the span.
 */
function setPageTitle() {
  //get a reference to the DOM element 
  let titleElement = document.querySelector("#page-title > span.name")

  //set the content using innertext
  titleElement.innerText = name


}

/**
 * Add our product description to the page.
 */
function setPageDescription() {
//get the element that holds the description
let ele = document.querySelector("#main > p.description");
ele.innerText = description;
}

/**
 * I will display all of the reviews on the page.
 * I will loop over the array of reviews and use some helper functions
 * to create the elements needed for our markup and add them to the DOM
 */
function displayReviews() {
  reviews.forEach((review) => {
    let x = 1;
    //1. create the element
    let reviewDiv = document.createElement("div");

    //2. set its properties
    reviewDiv.classList.add("review");
    //reviewDiv.innerText = "Something/Anything" + x++;

    addReviewer(reviewDiv, review.reviewer)
    addRating(reviewDiv, review.rating)
    addTitle(reviewDiv, review.title)
    addReview(reviewDiv, review.review)

    //3. Add it to the DOM 
    let main = document.getElementById("main");
    main.insertAdjacentElement("beforeend", reviewDiv);
  });

}

/**
 * I will creating a new h4 element with the name of the reviewer and append it to
 * the parent element that is passed to me.
 *
 * @param {HTMLElement} el: The element to append the reviewer to
 * @param {string} name The name of the reviewer
 */
function addReviewer(parent, name) {
  //create the h4 element
  let h4 = document.createElement("h4");

  //set the content
  h4.innerText = name;

  //attach it to the parent
  parent.appendChild(h4);
}

/**
 * I will add the rating div along with a star image for the number of ratings 1-5
 * @param {HTMLElement} parent
 * @param {Number} numberOfStars
 */
function addRating(parent, numberOfStars) {
  //create the element 
  let ratingDiv = document.createElement("div")

  //set properties
  ratingDiv.classList.add("rating")
  for(let i = 1; i <= numberOfStars; i++){
    //create element 
    let img = document.createElement("img")
    img.classList.add("star")
    img.src = "img/star.png"

    //add to parent
    ratingDiv.appendChild(img);
  }

  //add rating div to parent
  parent.insertAdjacentElement("beforeend", ratingDiv)
}

/**
 * I will add an h3 element along with the review title
 * @param {HTMLElement} parent
 * @param {string} title
 */
function addTitle(parent, title) {
  //create element
  let titleH3 = document.createElement("h3")

  //set properties
  titleH3.innerText = title

  //add to parent
  parent.appendChild(titleH3)

}

/**
 * I will add the product review
 * @param {HTMLElement} parent
 * @param {string} review
 */
function addReview(parent, review) {
    //create element
    let p = document.createElement("p")

    //set properties
    p.innerText = review;
  
    //add to parent
    parent.appendChild(p)
}

// set the product reviews page title
setPageTitle();
// set the product reviews page description
setPageDescription();
// display all of the product reviews on our page
displayReviews();
