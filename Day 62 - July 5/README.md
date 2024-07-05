# Dockerized Python Hello World

This repository contains a simple Docker image that can be used to execute a Python program that prints "Hello, World!".

## Prerequisites

Before you can use this Docker image, make sure you have the following installed on your machine:

- Docker: [Install Docker](https://docs.docker.com/get-docker/)

## Usage

To use this Docker image, follow these steps:

1. Clone this repository to your local machine.
2. Open a terminal and navigate to the cloned repository.
3. Build the Docker image by running the following command:
    ```
    docker build -t python-hello-world .
    ```
4. Once the image is built, you can run the Python program by executing the following command:
    ```
    docker run python-hello-world
    ```

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
