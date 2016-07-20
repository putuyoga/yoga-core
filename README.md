# Yoga-Core project.

Hello, welcome to my simple project. This is a repository that contain several experiments on asp.net core, entity framework core. The goal is to make sure that we can build and run some simple asp.net core application both on windows and linux platform.

## What do you need?

1. For linux platform, make sure `DOCKER` are installed on your machine.
2. For windows platform, just clone/download this repository and run the project.

### Linux platform
1. Clone this repository by using command `$ git clone https://github.com/putuyoga/yoga-core.git yoga-core`
2. Modify the `./src/YogaCore/Dockerfile` as needed. If your work environment are behind proxy, just change the proxy configuration. If not, delete the line that mention proxy. 
3. Change working directory to YogaCore `$ cd ~/src/YogaCore/`
4. Build the container image `$ sudo docker build -t [your image name] .`
5. Wait for a moment, after finish, make sure the image result is present :
> $ docker images
> REPOSITORY          TAG                 IMAGE ID            CREATED             VIRTUAL SIZE
> [your image name]		latest              ccb7994d2bc1        39 seconds ago         499.8 MB
6. ... to be continued