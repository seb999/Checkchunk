# Checkchunk

<!-- ABOUT THE PROJECT -->
## About this Project
I used C# language and visual Code to build this assignement. To validate a chunk two methods are available in this project. A standard method and a recursive method.
Both works and give the same result. There is problably a more efficient and rapid way to do this using F#. I will eventually look at it tomorrow.

<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/seb999/Checkchunk
   ```

### How to run it
The application has been Dockerized. Execute the following command to create a Docker Image and run it in a container

1. To create a Docker Image
   ```sh
   docker build -t checkchunk-image -f Dockerfile .
   ```

2. To run the previous image in a container in interactive mode
   ```sh
   docker run -i checkchunk-image 
   ```
### Finally
The program run in a loop. To stop the application press q




