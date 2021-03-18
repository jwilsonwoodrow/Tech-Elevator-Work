// add pageTitle
let pageTitle = "My Shopping List";
// add groceries
let groceries = ["Apples", "Bananas", "Cranberries", "Dino Nuggets", "Everything", "Fries", "Gelato", "Hamburgers", "Ice", "Jam"];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  let ele = document.querySelector("div.shopping-list > #title");
  ele.innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  let ele = document.querySelector("div.shopping-list > #groceries");
  let list = document.createElement('ul')
  ele.appendChild(list);
  groceries.forEach(element => {
    let item = document.createElement("li")
    item.innerText = element;
    item.id = 
    ele.appendChild(item);
  });
}

/**
 * This function will be called when the button is clicked. You will need to get a reference
 * to every list item and add the class completed to each one
 */
function markCompleted() {
  let ele = document.querySelectorAll("div.shopping-list li");
  ele.forEach(item => {
    item.classList.add("completed");
  });
}

setPageTitle();

displayGroceries();

// Don't worry too much about what is going on here, we will cover this when we discuss events.
document.addEventListener('DOMContentLoaded', () => {
  // When the DOM Content has loaded attach a click listener to the button
  const button = document.querySelector('.btn');
  button.addEventListener('click', markCompleted);
});
