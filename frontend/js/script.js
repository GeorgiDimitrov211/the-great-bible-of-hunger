document.addEventListener("DOMContentLoaded", () => {
    const vh = window.innerHeight;
    document.body.style.setProperty('--vh', vh + 'px');
});


// vars
let landingPage = document.getElementById('ldn-screen--js');
let homePage = document.getElementById('home-page');
let fixedNavigation = document.getElementById('recipe-listing-page');
let recipeNavigation = document.getElementById('recipe-page');
let ingPage = document.getElementById('ingredients-page')

// Skip button
let skipButton = document.getElementById('skip__button');
skipButton.addEventListener('click', () => {
    landingPage.classList.remove('displayed');
    homePage.classList.add('displayed');
    fixedNavigation.classList.add('displayed');
    recipeNavigation.classList.add('displayed');
})