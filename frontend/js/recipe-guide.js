document.addEventListener("DOMContentLoaded", () => {

    var currentStep = 0;
    setBarry(0);


    (async function getRecipeData() {
        const getJson = await fetch("/frontend/js/fakeguide.json");
        const realJson = await getJson.json();

        realJson.ingredients.forEach(ingredient => {
            document.querySelector('.ingredient__stuff-container').innerHTML += `
            <div class="ingredient__ingredients-container displayed">
                <div>
                    <h1>${ingredient.number}</h1>
                </div>

                <div>
                    <p>${ingredient.text}</p>
                </div>        
            </div>
            `;
        });

        realJson.guide.forEach(step => {
            document.querySelector('#guide').innerHTML += `
            <div class="guide__text-container">
                <div>
                    <h1>${step.number}</h1>
                </div>
        
                <div>
                    <p>${step.text}</p>
                </div>     
            </div>
            `;    
        });        

        document.querySelector(".guide__step-button--increase").addEventListener("click", () => {
            if (currentStep < realJson.guide.length) {
                currentStep ++;
                changeStep();
            };
        });

        document.querySelector(".guide__step-button--decrease").addEventListener("click", () =>  {
            if  (currentStep > 0) {
                currentStep --;
            }
            changeStep();
        });

    })();

    function changeStep() {
        const allGuideTextContainers = document.querySelectorAll(".guide__text-container");

        let allForRecipeMaking = Array.from(allGuideTextContainers);
        allForRecipeMaking.unshift(document.querySelector(".ingredient__stuff-container"));

        let progressFill = (currentStep/(allForRecipeMaking.length - 1))*100;
        setBarry(progressFill);

        for (var amountOfTimesItHasRun = 0; amountOfTimesItHasRun < allForRecipeMaking.length; amountOfTimesItHasRun++) {
            allForRecipeMaking[amountOfTimesItHasRun].classList.remove("displayed");
        };
        allForRecipeMaking[currentStep].classList.add("displayed");
    }

    function setBarry(percentage) {
        let barry = document.querySelector(".guide__progressbar");
        barry.style.setProperty('--fill', percentage + '%');
        barry.innerText = percentage + '%';
    }
});

//progress bar & position of the buttons
