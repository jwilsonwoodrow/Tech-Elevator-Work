/**************************************************
 *  Math Practice Notes:

    We need to store this information (variables):
    * Configurable: 
    *       Total Number of questions (10)
    *       Lowest operand value (0)
    *       Highest operand value (9)
    * Current Question
    * Number of correct questions
    * Question Object
        * Operand 1 & Operand 2 for current question
        * An array of possible answers, including the correct one.

    We need to handle these events:
    * User clicks on an answer
    * User clicks on Start Over
    
    We need the following functionality
    *Add event handlers
    *start the game (zero score, reset question to 1)
    *create the next question
        *generate two random operands
        *generate four possible answers, including correct
    *display next question 
        *update screen elements with question object values
    *grade the user submission
        *go to next question if there are more
        *end game if not
    *end game
*****************************************************/
const NUMBER_OF_QUESTIONS_PER_GAME = 3;
const MIN_OPERAND_VALUE = 0;
const MAX_OPERAND_VALUE = 9;

//temp code
let q = generateQuestion();
displayQuestion(q);
//

//variables to track the game
let currentQuestion;
let game = {
    currentQuestionNumber: 1,
    numberCorrect: 0,
    startOver: function(){
        this.currentQuestionNumber = 1;
        this.numberCorrect = 0;
    }

}

document.addEventListener("DOMContentLoaded", initializePage)

//hook up the event listeners, start the game
function initializePage(){
    let answerLis = document.querySelectorAll("section#answers li");
    answerLis.forEach( (li) => {
        li.addEventListener("click", userSelectedAnswer)
    });

    document.getElementById("btnStartOver").addEventListener("click", game.startOver)
}

function userSelectedAnswer(ev){

}



/*
*create the next question
    *generate two random operands
    *generate four possible answers, including correct
*/
function generateQuestion() {
    let operand1 = getRandomInteger(MIN_OPERAND_VALUE, MAX_OPERAND_VALUE)
    let operand2 = getRandomInteger(MIN_OPERAND_VALUE, MAX_OPERAND_VALUE)
    let possibleAnswers = [];
    //put correct answer first
    possibleAnswers.push(operand2 * operand1)

    for (let i = 1; i < 4; i++) {
        while (possibleAnswers[i] === undefined) {
            let randomAnswer = getRandomInteger(MIN_OPERAND_VALUE * MIN_OPERAND_VALUE, MAX_OPERAND_VALUE * MAX_OPERAND_VALUE);
            if (!possibleAnswers.includes(randomAnswer)) {
                possibleAnswers[i] = randomAnswer;
            }
        }
    }

    shuffleArray(possibleAnswers)

    return {
        operand1: operand1,
        operand2: operand2,
        possibleAnswers: possibleAnswers
    }
}

function displayQuestion(question){
    let q = generateQuestion();
    let problemDiv = document.querySelector("section#problem > div");
    problemDiv.innerText = `${question.operand1} x ${question.operand2}`

    let answerLis = document.querySelectorAll("section#answers li");
    for(let i = 0; i < 4; i++){
        answerLis[i].innerText = question.possibleAnswers[i];
    }

}




/**
 * Utility function to generate a random number from min to max (inclusive)
 * @param {number} min The lowest integer to return
 * @param {number} max The highest integer to return 
 */
function getRandomInteger(min, max) {
    return min + Math.floor(Math.random() * Math.floor(max - min + 1));
}

/**
 * Utility function to shuffle the items in an array
 * @param {object} arr
 */
function shuffleArray(arr) {
    return arr.sort(function (a, b) { return Math.random() - 0.5 })
}