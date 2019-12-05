// Configuration for the sliders
// * type of slider
// * number of items per slide
// * make item in the center active item
const small__conf = {
    type: 'carousel',
    perView: 3,
    focusAt: 'center'
}
const big__conf = {
    type: 'carousel',
    perView: 5,
    focusAt: 'center'
}

// Create slider with applied confiugration
new Glide('.glide', small__conf).mount();
new Glide('.glide__time', big__conf).mount();

const sliders = document.querySelectorAll('.glide__cuisine');

sliders.forEach(slider => {
    new Glide(slider, small__conf).mount();
})



// Creating menu open/close function
var menuButton = document.getElementById('menu__trigger--js');
let filterMenu = document.getElementById('filter__trigger--js');
let submitButton = document.getElementById('submit-fliter--js'); // Hide if menu is not open

menuButton.addEventListener('click', () => {
        filterMenu.classList.add('menu__opened');
        filterMenu.style.bottom = "0%";
        submitButton.style.display = "flex";
})

submitButton.addEventListener('click', () => {
    filterMenu.classList.remove('menu__opened');
    filterMenu.style.bottom = "-10%";
    submitButton.style.display = "none";
})
