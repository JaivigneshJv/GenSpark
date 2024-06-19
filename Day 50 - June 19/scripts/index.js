document.addEventListener("DOMContentLoaded", () => {
  let skip = 0;
  const limit = 6;
  const quotesContainer = document.getElementById("quotes-container");
  const loading = document.getElementById("loading");

  const fetchQuotes = async () => {
    try {
      const homeContainer = document.querySelector(".home-container");
      const randomContainer = document.querySelector(".random-container");
      randomContainer.classList.add("d-none");
      homeContainer.classList.remove("d-none");
      document.querySelector(".nav-random").classList.remove("active");
      document.querySelector(".nav-home").classList.add("active");
      loading.style.display = "block";
      const response = await fetch(
        `https://dummyjson.com/quotes?limit=${limit}&skip=${skip}`
      );
      const data = await response.json();
      appendQuotes(data.quotes);
      skip += limit;
      loading.style.display = "none";
    } catch (error) {
      console.error("Error fetching quotes:", error);
      loading.style.display = "none";
    }
  };

  const appendQuotes = (quotes) => {
    quotes.forEach((quote, index) => {
      const quoteElement = document.createElement("div");
      quoteElement.setAttribute(
        "data-aos",
        index % 2 === 0 ? "fade-down-right" : "fade-down-left"
      );
      quoteElement.classList.add("quote");
      quoteElement.classList.add("mt-3");
      quoteElement.classList.add("p-5");

      if (quote.id % 2 === 0) quoteElement.classList.add("text-end");
      else quoteElement.classList.add("text-start");
      quoteElement.innerHTML = `
      <figure>
        <blockquote class="blockquote">
          <p class="mb-0">${quote.quote}</p>
        </blockquote>
        <figcaption class="blockquote-footer">
          ${quote.author}
        </figcaption>
      </figure>
    `;
      quotesContainer.appendChild(quoteElement);
    });
  };

  const handleScroll = () => {
    if (window.innerHeight + window.scrollY >= document.body.offsetHeight) {
      fetchQuotes();
    }
  };

  window.addEventListener("scroll", handleScroll);

  // Initial fetch
  fetchQuotes();
});

showRandom = async () => {
  const homeContainer = document.querySelector(".home-container");
  const randomContainer = document.querySelector(".random-container");
  const randomQuote = document.querySelector(".random-quote");
  const randomAuthor = document.querySelector(".random-author");
  const loading = document.getElementById("radom-loading");
  const randomBtn = document.getElementById("random-quote-btn");
  randomBtn.classList.remove("d-none");
  document.querySelector(".nav-home").classList.remove("active");
  document.querySelector(".nav-random").classList.add("active");
  homeContainer.classList.add("d-none");
  randomContainer.classList.remove("d-none");
  const response = await fetch(`https://dummyjson.com/quotes/random`);
  const data = await response.json();
  randomQuote.textContent = data.quote;
  randomAuthor.textContent = data.author;
  loading.style.display = "none";
};

const allQuotes = [];

async function getAllQuotes() {
  await axios.get("https://dummyjson.com/quotes").then((response) => {
    axios
      .get(`https://dummyjson.com/quotes?limit=${response.data.total}`)
      .then((response) => {
        allQuotes.push(...response.data.quotes);
      });
  });
}

getAllQuotes();

document.getElementById("search-input").addEventListener("input", (e) => {
  if (e.target.value.length == 0) {
    window.location.reload();
    return;
  }
  if (e.target.value.length > 3) {
    const searchValue = e.target.value.toLowerCase();
    const searchResults = allQuotes.filter((quote) => {
      return quote.author.toLowerCase().includes(searchValue);
    });
    const homeContainer = document.querySelector(".home-container");
    const randomContainer = document.querySelector(".random-container");
    randomContainer.classList.add("d-none");
    homeContainer.classList.add("d-none");
    const searchContainer = document.querySelector(".search-container");
    searchContainer.innerHTML = " ";
    searchResults.forEach((quote, index) => {
      const quoteElement = document.createElement("div");
      quoteElement.setAttribute(
        "data-aos",
        index % 2 === 0 ? "fade-down-right" : "fade-down-left"
      );
      quoteElement.classList.add("quote");
      quoteElement.classList.add("p-5");

      if (quote.index % 2 === 0) quoteElement.classList.add("text-end");
      else quoteElement.classList.add("text-start");
      quoteElement.innerHTML = `
        <figure>
            <blockquote class="blockquote">
            <p class="mb-0">${quote.quote}</p>
            </blockquote>
            <figcaption class="blockquote-footer">
            ${quote.author}
            </figcaption>
        </figure>
        `;
      searchContainer.appendChild(quoteElement);
    });
  }
});

document.querySelector("form").addEventListener("submit", function (event) {
  event.preventDefault();
  const searchInput = document.getElementById("search-input").value;

  if (!isNaN(searchInput)) {
    axios
      .get("https://dummyjson.com/quotes/" + searchInput)
      .then((res) => {
        const homeContainer = document.querySelector(".home-container");
        const randomContainer = document.querySelector(".random-container");
        const randomQuote = document.querySelector(".random-quote");
        const randomAuthor = document.querySelector(".random-author");
        const randomBtn = document.getElementById("random-quote-btn");
        randomBtn.classList.add("d-none");
        document.querySelector(".nav-home").classList.remove("active");
        document.querySelector(".nav-random").classList.add("active");
        homeContainer.classList.add("d-none");
        randomContainer.classList.remove("d-none");
        randomAuthor.textContent = res.data.author;
        randomQuote.textContent = res.data.quote;
      })
      .catch((err) => {
        window.location.reload();
      });
  } else {
    return;
  }
});

let sortLetter = "a";

document.getElementById("sort-button").addEventListener("click", () => {
  allQuotes.sort((a, b) => {
    const aStartsWithLetter = a.author.toLowerCase().startsWith(sortLetter);
    const bStartsWithLetter = b.author.toLowerCase().startsWith(sortLetter);
    if (aStartsWithLetter && !bStartsWithLetter) {
      return -1;
    } else if (!aStartsWithLetter && bStartsWithLetter) {
      return 1;
    } else {
      return a.author.toLowerCase().localeCompare(b.author.toLowerCase());
    }
  });
  // Reset the current quote index to 0
  currentQuoteIndex = 0;
  // Re-render the quotes after sorting
  renderQuotess(
    allQuotes.filter((quote) =>
      quote.author.toLowerCase().startsWith(sortLetter)
    )
  );
  console.log(allQuotes);

  // Move to the next letter in the alphabet
  sortLetter = String.fromCharCode(sortLetter.charCodeAt(0) + 1);
  if (sortLetter > "z") {
    sortLetter = "a";
  }
});

let currentQuoteIndex = 0;
const quotesPerLoad = 20; // Adjust this value to your needs

function renderQuotess(quotes) {
  const quotesContainer = document.getElementById("quotes-container");
  if (currentQuoteIndex === 0) {
    quotesContainer.innerHTML = "";
  }
  for (
    let i = currentQuoteIndex;
    i < currentQuoteIndex + quotesPerLoad && i < quotes.length;
    i++
  ) {
    const quote = quotes[i];
    const quoteElement = document.createElement("div");
    quoteElement.setAttribute(
      "data-aos",
      i % 2 === 0 ? "fade-down-right" : "fade-down-left"
    );
    quoteElement.classList.add("quote");
    quoteElement.classList.add("p-5");

    if (i % 2 === 0) quoteElement.classList.add("text-end");
    else quoteElement.classList.add("text-start");
    quoteElement.innerHTML = `
      <figure>
        <blockquote class="blockquote">
          <p class="mb-0">${quote.quote}</p>
        </blockquote>
        <figcaption class="blockquote-footer">
          ${quote.author}
        </figcaption>
      </figure>
    `;
    quotesContainer.appendChild(quoteElement);
  }
  currentQuoteIndex += quotesPerLoad;
}

// Add an event listener to the scroll event of the window
window.addEventListener("scroll", () => {
  if (window.innerHeight + window.scrollY >= document.body.offsetHeight) {
    // When the user has scrolled to the bottom of the page, render more quotes
    renderQuotess(allQuotes);
  }
});
