document.addEventListener("DOMContentLoaded", () => {
    const vh = window.innerHeight;
    document.body.style.setProperty('--vh', vh + 'px');
});


// vars
let landingPage = document.getElementById('ldn-screen--js');
let homePage = document.getElementById('home-page');
let fixedNavigation = document.getElementById('recipe-listing-page');
let recipeNavigation = document.getElementById('recipe-page');
let ingredientsPage = document.getElementById('ingredients-page');

// get the element with the displayed and delete it depending 
// on the page
// Delete class from all function
function removeDisplayedClass() {
    let displayedClass = document.querySelectorAll('.displayed');
    displayedClass.forEach(cls => {
        cls.classList.remove('displayed');
    });
}


// Skip button
let skipButton = document.getElementById('skip__button');
skipButton.addEventListener('click', () => {
    removeDisplayedClass();
    ingredientsPage.classList.add('displayed');
    fixedNavigation.classList.add('displayed');
})

// Recipes page button
let recipeButton = document.getElementById('recipe__button');
recipeButton.addEventListener('click', () => {
    removeDisplayedClass();
    homePage.classList.add('displayed');
    fixedNavigation.classList.add('displayed');
    recipeNavigation.classList.add('displayed');
});


// Products button
let productsButton = document.getElementById('products__button');
productsButton.addEventListener('click', () => {
    removeDisplayedClass();
    ingredientsPage.classList.add('displayed');
    fixedNavigation.classList.add('displayed');
});


// Let's cook button
let letsButton = document.getElementById('lets-cook__button');
letsButton.addEventListener('click', () => {
    removeDisplayedClass();
    fixedNavigation.classList.add('displayed');
    recipeNavigation.classList.add('displayed');
    
})
// We need to apply black color to the current link!




