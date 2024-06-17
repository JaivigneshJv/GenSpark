// var sampleMethod = () => {
//   return "Hello World";
// };
// const greetPromise = new Promise((resolve, reject) => {
//   resolve("Hello World");
// });
// // const datePromise = new Promise((resolve, reject) => {
// //     var date = new Date();
// //     let day = date.getDay();
// //     if(day == 0 || day == 6)
// //         resolve('Weekend');
// //     else
// //         reject('Weekday');
// // });
// const numberPromise = (num) => {
//   return new Promise((resolve, reject) => {
//     if (num % 2 == 0) resolve("Even");
//     else reject("Odd");
//   });
// };
// const fileReadPromise = (fName) => {
//   return new Promise((resolve, reject) => {
//     const fileReader = new FileReader();
//     //var file = new File( [],fileName=fName, {type: "text/plain"});
//     fileReader.onload = () => {
//       resolve({fileName: fName.name, content: fileReader.result});
//     };
//     fileReader.onerror = () => {
//       reject("Error in reading file");
//     };
//     fileReader.readAsText(fName);
//   });
// };
// var clickButton = () => {
//   //var data = sampleMethod();
//   // greetPromise.then((data) => {
//   //     alert(data);
//   // });
//   //alert(data);
//   // datePromise.then((data) => {
//   //     alert(data);
//   // }).catch((error) => {
//   //     alert("OOPS.. You are working today "+error);
//   // });
//   // numberPromise(10).then((data) => {

//   //     alert(data);
//   // }).catch((error) => {
//   //     alert("OOPS.. "+error);
//   // });
//   console.log("Before File Read");
//   const fileData = document.getElementById("fileInput").files[0];
//   fileReadPromise(fileData)
//     .then((data) => {
//       console.log(data);
//       alert(data.content);
//     })
//     .catch((error) => {
//       console.log("error");
//       alert("OOPS.. " + error);
//     });
// };

// var clickButton = async () => {
//   document.getElementById("btn").innerHTML = "fetching...";

//   try {
//     const response = await axios.get(
//       `https://api.themoviedb.org/3/discover/movie?include_adult=true&include_video=false&language=en-US&page=1&sort_by=popularity.desc`,
//       {
//         headers: {
//           Authorization: `Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJkMDMwMDY0YjZiMTNjNmM0ZTNhMzgwNzFkMTJmOTNlNiIsInN1YiI6IjY0MmMxODc4YWM4ZTZiMzQ3NzAzYmU0NCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.HtF23PksaCZCe6G1y-jau9VYpX1V7rsN_xqPiEfCMWA`,
//         },
//       }
//     );
//     if (response.status === 200) {
//       console.log(response.data);
//       document.getElementById("btn").innerHTML = "fetched...";
//       const movies = response.data.results;
//       const table = document.createElement("table");
//       const tableBody = document.createElement("tbody");
//       movies.forEach((movie) => {
//         const row = document.createElement("tr");
//         const titleCell = document.createElement("td");
//         const titleText = document.createTextNode(movie.title);
//         titleCell.appendChild(titleText);
//         row.appendChild(titleCell);
//         tableBody.appendChild(row);
//       });
//       table.appendChild(tableBody);
//       document.body.appendChild(table);
//     } else {
//       return;
//     }
//   } catch (error) {
//     console.log(error);
//   }
// };
// var clickButton = async () => {
//   document.getElementById("btn").innerHTML = "fetching...";

//   try {
//     const response = await fetch(
//       `https://api.themoviedb.org/3/discover/movie?include_adult=true&include_video=false&language=en-US&page=1&sort_by=popularity.desc`,
//       {
//         headers: {
//           Authorization: `Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJkMDMwMDY0YjZiMTNjNmM0ZTNhMzgwNzFkMTJmOTNlNiIsInN1YiI6IjY0MmMxODc4YWM4ZTZiMzQ3NzAzYmU0NCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.HtF23PksaCZCe6G1y-jau9VYpX1V7rsN_xqPiEfCMWA`,
//         },
//       }
//     );
//     if (response.ok) {
//       const data = await response.json();
//       console.log(data);
//       document.getElementById("btn").innerHTML = "fetched...";
//       const movies = data.results;
//       const table = document.createElement("table");
//       const tableBody = document.createElement("tbody");
//       movies.forEach((movie) => {
//         const row = document.createElement("tr");
//         const titleCell = document.createElement("td");
//         const titleText = document.createTextNode(movie.title);
//         titleCell.appendChild(titleText);
//         row.appendChild(titleCell);
//         tableBody.appendChild(row);
//       });
//       table.appendChild(tableBody);
//       document.body.appendChild(table);
//     } else {
//       return;
//     }
//   } catch (error) {
//     console.log(error);
//   }
// };
// var clickButton = async () => {
//   setTimeout(() => {}, 3000);
//   const res = await axios.get(`https://dummyjson.com/products`);
//   console.log(res.data.products);
//   const products = res.data.products;

//   const table = document.createElement("table");
//   table.classList.add("table", "table-striped", "table-bordered");

//   const tableHead = document.createElement("thead");
//   tableHead.classList.add("table-dark");
//   const headRow = document.createElement("tr");

//   for (let key in products[0]) {
//     if (key === "images" || key === "meta" || key === "reviews") continue;
//     const headTitle = document.createElement("th");
//     headTitle.textContent = key;
//     headRow.appendChild(headTitle);
//   }

//   tableHead.appendChild(headRow);
//   table.appendChild(tableHead);

//   const tableBody = document.createElement("tbody");

//   products.forEach((product) => {
//     const row = document.createElement("tr");
//     for (let key in product) {
//       if (key === "images" || key === "meta" || key === "reviews") continue;
//       const cell = document.createElement("td");

//       if (typeof product[key] === "object" && product[key] !== null) {
//         cell.textContent = JSON.stringify(product[key]);
//       } else if (
//         typeof product[key] === "string" &&
//         (product[key].endsWith(".jpg") || product[key].endsWith(".png"))
//       ) {
//         const img = document.createElement("img");
//         img.src = product[key];
//         img.classList.add("img-fluid");
//         cell.appendChild(img);
//       } else {
//         cell.textContent = product[key];
//       }

//       row.appendChild(cell);
//     }

//     tableBody.appendChild(row);
//   });

//   table.appendChild(tableBody);

//   document.getElementById("btn").style.display = "none";
//   document.getElementById("tableContainer").appendChild(table);
// };
window.onload = async () => {
  document.getElementById("skeleton").classList.remove("d-none");
  setTimeout(async () => {
    const res = await axios.get(`https://dummyjson.com/products`);
    document.getElementById("skeleton").classList.add("d-none");
    console.log(res.data.products);
    const products = res.data.products;

    const row = document.createElement("div");
    row.classList.add("row");

    products.forEach((product) => {
      const col = document.createElement("div");
      col.classList.add("col-md-3");
      col.classList.add("mb-4");

      const card = document.createElement("div");
      card.classList.add("card");

      const img = document.createElement("img");
      img.classList.add("card-img-top");
      img.alt = product.title;
      img.src = product.thumbnail || product.images[0] || "...";

      const cardBody = document.createElement("div");
      cardBody.classList.add("card-body");

      const cardTitle = document.createElement("h5");
      cardTitle.classList.add("card-title");
      cardTitle.textContent = product.title;

      const cardText = document.createElement("h6");
      cardText.classList.add("card-subtitle");
      cardText.classList.add("mb-2");
      cardText.classList.add("text-muted");

      cardText.textContent = product.description;

      const cardText2 = document.createElement("p");
      cardText2.classList.add("card-text");
      cardText2.textContent = "$" + product.price;

      cardBody.appendChild(cardTitle);
      cardBody.appendChild(cardText);
      cardBody.appendChild(cardText2);

      card.appendChild(img);
      card.appendChild(cardBody);

      col.appendChild(card);
      row.appendChild(col);
    });

    document.getElementById("tableContainer").appendChild(row);
  }, 3000);
};
