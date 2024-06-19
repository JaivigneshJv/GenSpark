# Quotes Web Application

This project is a simple web application that displays quotes, allows users to fetch random quotes, and includes search and sorting functionalities. It uses HTML, CSS, and JavaScript with some additional libraries like Bootstrap for styling, Axios for HTTP requests, and AOS for animations.

## Features

1. **Home Page:** Displays a list of quotes fetched from a dummy API.
2. **Random Quote:** Displays a random quote on button click.
3. **Search:** Allows users to search for quotes by author.
4. **Sorting:** Sorts quotes by author's name starting with a specific letter.
5. **Infinite Scroll:** Loads more quotes as the user scrolls down.

## Getting Started

### Prerequisites

Ensure you have the following installed:

- [Node.js](https://nodejs.org/) (includes npm)

### Installation

1. Clone the repository:

```sh
git clone <repository-url>
```

2. Navigate to the project directory:

```sh
cd <project-directory>
```

3. Install the dependencies:

```sh
npm install
```

### Running the Project

Start the development server:

```sh
npm start
```

This will start the project using `lite-server` and open it in your default web browser.

## Project Structure

- **index.html:** The main HTML file.
- **css/main.min.css:** The main CSS file.
- **scripts/index.js:** The main JavaScript file.
- **node_modules/**: Directory containing all the project dependencies.
- **package.json:** Contains the project configuration and dependencies.

## Dependencies

- **Bootstrap:** For responsive layout and styling.
- **Bootstrap Icons:** For icons.
- **Axios:** For making HTTP requests.
- **AOS (Animate On Scroll):** For scroll animations.

## Usage

### Home Page

On loading the home page, the application fetches quotes from the API and displays them. As the user scrolls, more quotes are fetched and appended.

### Random Quote

Click on the "Random" navigation item to fetch and display a random quote.

### Search

Type in the search input to find quotes by author. The search is case-insensitive and filters quotes based on the author's name.

### Sorting

Click on the "Sort" navigation item to sort quotes by the author's name starting with a specific letter. The sorting letter increments with each click.

## Acknowledgments

- [DummyJSON](https://dummyjson.com/) for providing a dummy API for quotes.
- [Bootstrap](https://getbootstrap.com/) for CSS framework.
- [AOS](https://michalsnik.github.io/aos/) for scroll animations.
- [Axios](https://axios-http.com/) for making HTTP requests.