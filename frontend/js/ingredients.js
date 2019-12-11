document.addEventListener("DOMContentLoaded", () => {
  const baseUrl = "http://localhost:5000/api";
  let empty = false;

  const ingredientsList = document.querySelector(".ingredients__list");
  const errorMessage = document.querySelector(".ingredients__input-error");

  document.querySelector(".ingredients__submit-icon").addEventListener("click", () => {
    verifyInput();
  });

  document.querySelector("#ingredients__input-value").addEventListener("keydown", event => {
    errorMessage.classList.remove("thrown");
    if (event.keyCode === 13) {
      verifyInput();
    }
  });

  (async function getIngredients() {
    const savedIngredients = window.localStorage.getItem("saved-ingredients");
    if (savedIngredients) {
      console.log("Making an API call with", savedIngredients);

      // const rawData = await fetch("/frontend/js/fake.json");
      // const actualData = await rawData.json();
      // actualData.ingredients.forEach(ingredient => {
      //   renderIngredient(ingredient);
      // });
      return;
    }
    else
    {
      empty = true;
      ingredientsList.innerHTML = "<h5>You have no ingredients saved, try adding some!</h5>";
    };
  })();

  async function fetchIngredient(ingredientQuery) {
    const rawIngredient = await fetch(`${baseUrl}/ingredient/${ingredientQuery}`);
    const actualIngredient = await rawIngredient.json();
    if (actualIngredient && actualIngredient.status) {
      errorMessage.classList.add("thrown");
      return;
    }
    renderIngredient(actualIngredient);
  };

  function verifyInput() {
    const inputValue = document.querySelector("#ingredients__input-value").value;
    if (inputValue && inputValue.length > 1) {
      fetchIngredient(inputValue);
    } else {
      errorMessage.classList.add("thrown");
    }
  };

  function renderIngredient(ingredient) {
    if (empty = true) {
      ingredientsList.innerHTML = "<h5>Your ingredients:</h5>";
      empty = false;
    }
    const outputIngredient = document.createElement("figure");
    outputIngredient.classList.add("ingredients__list__ingredient");
    outputIngredient.innerHTML = `
      <figcaption>${ingredient.name}</figcaption>
      <div class="ingredients__list__ingredient__data">
        <img src="${ingredient.imageURL}">
        <div class="ingredients__list__ingredient__type">${ingredient.type}</div>
      </div>
    `;
    ingredientsList.append(outputIngredient);
    let savedIngredients = Array.from(window.localStorage.getItem("saved-ingredients"));
    console.log("saved", savedIngredients);
    if (!savedIngredients) savedIngredients = [];
    savedIngredients.push(ingredient.ingredientId);
    window.localStorage.setItem("saved-ingredients", savedIngredients);
    console.log("updated", Array.from(window.localStorage.getItem("saved-ingredients")));
  }
});
