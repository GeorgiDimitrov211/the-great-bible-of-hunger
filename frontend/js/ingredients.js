document.addEventListener("DOMContentLoaded", () => {

  document.querySelector(".ingredients__submit-icon").addEventListener("click", () => {
    verifyInput();
  });

  document.querySelector("#ingredients__input-value").addEventListener("keydown", event => {
    if (event.keyCode === 13) {
      verifyInput();
    }
  });

  (async function getIngredients() {
    const savedIngredients = window.localStorage.getItem("saved-ingredients");
    if (savedIngredients) {
      console.log("Making an API call with", savedIngredients);
      // fake api call
      const rawJson = await fetch("/frontend/js/fake.json");
      const actualData = await rawJson.json();
      actualData.ingredients.forEach(ingredient => {
        const outputIngredient = document.createElement("figure");
        outputIngredient.classList.add("ingredients__list__ingredient");
        outputIngredient.innerHTML = `
          <img src="${ingredient.ImageURL}">
          <figcaption>${ingredient.Name}</figcaption>
          <span class="ingredients__list__ingredient__type">${ingredient.Type}</span>
        `;
        document.querySelector(".ingredients__list").appendChild(outputIngredient);
      });
      return;
    }
    else
    {
      document.querySelector(".ingredients__list").innerHTML = "<h4>You have no ingredients saved, try adding some!</h4>";
    };
  })();

  async function submitIngredient(ingredientToBeSubmitted) {
    console.log(ingredientToBeSubmitted);
  };

  function verifyInput() {
    const inputValue = document.querySelector("#ingredients__input-value").value;
    if (inputValue && inputValue.length > 1) {
      submitIngredient(inputValue);
    }
  };

});
