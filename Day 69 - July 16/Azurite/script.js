const sasToken =
  "<SAS_TOKEN>";
const storageAccountName = "imagewebappjv";
const containerName = "images";
const jsonFileName = "images.json";
const jsonUrl = `https://${storageAccountName}.blob.core.windows.net/${containerName}/${jsonFileName}?${sasToken}`;

document.addEventListener("DOMContentLoaded", async () => {
  await fetchAndDisplayImages();
});

document
  .getElementById("uploadForm")
  .addEventListener("submit", async function (event) {
    event.preventDefault();
    const fileInput = document.getElementById("imageInput");
    const file = fileInput.files[0];
    if (!file) {
      alert("Please select an image file.");
      return;
    }

    const blobUrl = `https://${storageAccountName}.blob.core.windows.net/${containerName}/${file.name}?${sasToken}`;

    try {
      const response = await fetch(blobUrl, {
        method: "PUT",
        headers: {
          "x-ms-blob-type": "BlockBlob",
          "Content-Type": file.type,
        },
        body: file,
      });

      if (response.ok) {
        const imageSize = (file.size / 1024).toFixed(2) + " KB";
        const uploadDate = new Date().toISOString();
        const newImage = {
          imageName: file.name,
          imageUrl: blobUrl.split("?")[0],
          size: imageSize,
          uploadDate: uploadDate,
        };

        await updateJsonFile(newImage);
        await fetchAndDisplayImages();
        alert("Image uploaded successfully.");
      } else {
        alert("Image upload failed.");
      }
    } catch (error) {
      console.error("Error uploading image:", error);
      alert("Image upload failed.");
    }
  });

async function fetchAndDisplayImages() {
  try {
    const response = await fetch(jsonUrl);
    const images = await response.json();

    const gallery = document.getElementById("gallery");
    gallery.innerHTML = "";
    images.forEach((image) => {
      const card = document.createElement("div");
      card.className = "image-card";

      const img = document.createElement("img");
      img.src = image.imageUrl;
      img.alt = image.imageName;

      const details = document.createElement("div");
      details.className = "image-details";

      const name = document.createElement("p");
      name.textContent = `Name: ${image.imageName}`;

      const size = document.createElement("p");
      size.textContent = `Size: ${image.size}`;

      const date = document.createElement("p");
      date.textContent = `Uploaded: ${new Date(
        image.uploadDate
      ).toLocaleString()}`;

      details.appendChild(name);
      details.appendChild(size);
      details.appendChild(date);

      card.appendChild(img);
      card.appendChild(details);
      gallery.appendChild(card);
    });
  } catch (error) {
    console.error("Error fetching images:", error);
  }
}

async function updateJsonFile(newImage) {
  try {
    const response = await fetch(jsonUrl);
    const images = await response.json();
    images.push(newImage);

    const updatedJsonUrl = jsonUrl.split("?")[0] + `?${sasToken}`;
    const updateResponse = await fetch(updatedJsonUrl, {
      method: "PUT",
      headers: {
        "x-ms-blob-type": "BlockBlob",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(images),
    });

    if (!updateResponse.ok) {
      throw new Error("Failed to update JSON file");
    }
  } catch (error) {
    console.error("Error updating JSON file:", error);
    alert("Failed to update JSON file.");
  }
}

