# Yoga-Core project.

Hello, welcome to my simple project. This is a repository that contain several experiments on asp.net core, entity framework core. The goal is to make sure that we can build and run some simple asp.net core application both on windows and linux platform.

## What do you need?

1. For linux platform, make sure `DOCKER` are installed on your machine. for how-to-install-that-docker, please refer to this [link](https://docs.docker.com/engine/installation/linux/ubuntulinux/).
2. For windows platform, just clone/download this repository and run the project.

## On Linux platform
### Get the source code
You need to clone this repository.
```shell
$ git clone https://github.com/putuyoga/yoga-core.git yoga-core
```

Modify the `./src/YogaCore/Dockerfile` as needed. If your work environment are behind proxy, just change the proxy configuration. If not, delete the line that mention proxy.
```shell
$ vim ./yoga-core/src/YogaCore/Dockerfile
```
### Build the Image
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

### Run the image
Try run the docker container quietly. If you love some details, just strip that `-d` argument.
```shell
$ sudo docker run -t -d -p 5000:5000 [image name]
```

You can check if the containers running or not on your machine. Don't forget to note both of container id and container names (that one with fancy name lol). 
```shell
$ sudo docker ps 
```

### Create the database
For now, your application is perfectly running. *But* your application currently didn't have any database. You should create one. Enter your running docker container with container id or name. 
```shell
$ sudo docker exec -it [container id / container name] /bin/bash
```

And then move the working directory to `/app` and execute migration command.
```shell
# cd /app
# dotnet ef migrations add MyFirstMigration
# dotnet ef database update
```


... to be continued