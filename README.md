# Yoga-Core project.

Hello, welcome to my simple project. This is a repository that contain several experiments on asp.net core, entity framework core. The goal is to make sure that we can build and run some simple asp.net core application both on windows and linux platform.

## What do you need?

1. For linux platform, make sure `DOCKER` are installed on your machine. for how-to-install-that-docker, please refer to this [link](https://docs.docker.com/engine/installation/linux/ubuntulinux/).
2. For windows platform, just clone/download this repository and run the project.

### Linux platform
Clone this repository.
```shell
$ git clone https://github.com/putuyoga/yoga-core.git yoga-core
```

Modify the `./src/YogaCore/Dockerfile` as needed. If your work environment are behind proxy, just change the proxy configuration. If not, delete the line that mention proxy.
```shell
$ vim ./yoga-core/src/YogaCore/Dockerfile
```

Change the working directory to YogaCore
```shell
$ cd ./yoga-core/src/YogaCore/
```

Build the container image
```shell
$ sudo docker build -t [your image name] .
```

Wait for a moment, after finish, make sure the image result are present.
```shell
$ docker images
REPOSITORY          TAG                 IMAGE ID            CREATED             VIRTUAL SIZE
[your image name]		latest              ccb7994d2bc1        39 seconds ago         499.8 MB
```

... to be continued