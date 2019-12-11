document.addEventListener("DOMContentLoaded", () => {
    const vh = window.innerHeight;
    document.body.style.setProperty('--vh', vh + 'px');

    // vars for pages:
    let landingPage = document.getElementById('ldn-screen--js');
    let homePage = document.getElementById('home-page');
    //let fixedNavigation = document.getElementById('recipe-listing-page');
    let recipePage = document.getElementById('recipe-page');
    let ingredientsPage = document.getElementById('ingredients-page');
    let recipeToGuidePage = document.getElementById('recipe-to-guide-page');
    let guidePage = document.getElementById('guide');

    //vars for back buttons:
    let ingredientsPageBack = document.getElementById('ingredients-page-back');
    let recipePageBack = document.getElementById('recipe-page-back');

    // get the element with the displayed and delete it depending 
    // on the page
    // Delete class from all function
    function removeDisplayedClass() {
        let displayedClass = document.querySelectorAll('.displayed');
        displayedClass.forEach(cls => {
            cls.classList.remove('displayed');
        });
    }

    //shows the fixed bottom navigation
    function showFixedNavigation() {
        let fixedNavigation = document.getElementById('recipe-listing-page');
        fixedNavigation.classList.add('displayed');
    }


    // Skip button
    let skipButton = document.getElementById('skip__button');
    skipButton.addEventListener('click', () => {
        removeDisplayedClass();
        ingredientsPage.classList.add('displayed');
        showFixedNavigation();
    })

    // Recipes page button
    let recipeButton = document.getElementById('recipe__button');
    recipeButton.addEventListener('click', () => {
        removeDisplayedClass();
        homePage.classList.add('displayed');
        showFixedNavigation();
        recipePage.classList.remove('displayed');
    });

    // Recipe to guide page - button
    recipeToGuidePage.addEventListener('click', () => {
        removeDisplayedClass();
        guidePage.classList.add('displayed');
        showFixedNavigation();
    })


    // Products button
    let productsButton = document.getElementById('products__button');
    productsButton.addEventListener('click', () => {
        removeDisplayedClass();
        ingredientsPage.classList.add('displayed');
        showFixedNavigation();
    });


    // Let's cook button
    let letsButton = document.getElementById('lets-cook__button');
    letsButton.addEventListener('click', () => {
        removeDisplayedClass();
        showFixedNavigation();
        recipePage.classList.add('displayed');
        
    })

    // ingredients Page Back Button
    ingredientsPageBack.addEventListener('click', () => {
        removeDisplayedClass();
        showFixedNavigation();
        homePage.classList.add('displayed');
    })

    // recipe Page Back Button
    recipePageBack.addEventListener('click', () => {
        removeDisplayedClass();
        showFixedNavigation();
        homePage.classList.add('displayed');
    })

    // guide page back button
    let guidePageBack = document.getElementById('guide-page-back');
    guidePageBack.addEventListener('click', () => {
        console.log('clicked');
        removeDisplayedClass();
        showFixedNavigation();
        recipePage.classList.add('displayed');
    })
    // We need to apply black color to the current link!
});
