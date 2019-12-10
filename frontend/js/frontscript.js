(function () {
    const one__conf = {
        type: 'slider',
        perView: 1,
        focusAt: 'center',
        rewind: false,
    }

    var backgroundMover;
    var spoon;


    // transition: .4s ease-out;
    // Move background effect
    function FetchData() {
        backgroundMover = document.getElementById('chef__background');
        backgrondObject = backgroundMover.contentDocument;
        spoon = backgrondObject.getElementById('spoon');
        spoon.style.transformBox = 'fill-box';
        spoon.style.transition = '.6s all ease-out';
        spoon.style.transformOrigin = 'center';
    }
    setTimeout(FetchData, 800);




    // Create slider with applied confiugration
    let skipButton = document.getElementById('skip__button');
    const landingSlider = new Glide('.lnd-screen__slider', one__conf)
    landingSlider.on('run', function (e, f) {

        if (spoon) {

            if (landingSlider.index === 0 || null || undefined) {
                backgroundMover.style.left = '0%';
                spoon.style.transform = 'rotate(' + 0 + 'deg)';

            } else if (landingSlider.index === 1) {
                backgroundMover.style.left = '-5%';
                spoon.style.transform = 'rotate(' + 20 + 'deg)';
            } else if (landingSlider.index === 2) {
                backgroundMover.style.left = '-8%';
                spoon.style.transformOrigin = 'center 70px';
                spoon.style.transform = 'rotate(' + 45 + 'deg)';
                
                //change skip button into let's cook one
                skipButton.classList.add('lets-cook');
                skipButton.innerHTML = "let's cook";

            } else {
                console.log('Luka go study more');
            }
        }

    });

    landingSlider.mount();
})();

// Configuration for the sliders
// * type of slider
// * number of items per slide
// * make item in the center active item