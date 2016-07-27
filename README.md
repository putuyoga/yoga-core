# Yoga-Core project.

Hello, welcome to my simple project. This is my personal repository that contain several experiments, including but not limited to:
1. ASP.NET Core (previously known as ASP.NET 5)
2. Entity Framework Core
3. Single Page Application concept with AngularJS
4. Responsive Design with Bootstrap
5. Unit Test with XUnit
6. ... etc

## The Main Goal
The goal is to make sure that i know **how to** develop, build and run a simple asp.net core application both on windows and linux platform.

You need to clone this repository to make sure you get the sample working source code. 
```shell
$ git clone https://github.com/putuyoga/yoga-core.git yoga-core
```

## Windows
TBA

## Linux Platform
TBA


## Docker on Linux Platform

What is Docker and why i prefer it than a traditional virtual machine ?
In a short, Docker is a leading containerization platform. 

Instead having multiple virtual machine for multiple application on a host machine, you just having multiple container on a host machine. 

Much less resource usage comparing with virtual machine but still share same benefit, the __isolation environment__.

For linux platform, make sure `DOCKER` are installed on your machine. For `how-to-install-that-docker`, please refer to this [link](https://docs.docker.com/engine/installation/linux/ubuntulinux/).

Thanks to the community, we already have an [asp.net core docker image](https://hub.docker.com/r/microsoft/aspnet/), so it will be less step required to build an image for asp.net application.


### 1. Modify Dockerfile
Modify the `./src/YogaCore/Dockerfile` as needed. If your work environment are behind proxy wall, just change the proxy configuration. If not, just delete the line that mention proxy.
```shell
$ vim ./yoga-core/src/YogaCore/Dockerfile
```

### 2. Build the Image
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

### 3. Run the image
Try run the docker container quietly. If you love some details, just strip that `-d` argument.
```shell
$ sudo docker run -t -d -p 5000:5000 [image name]
```

You can check if the containers running or not on your machine. Don't forget to note both of container id and container names (that one with fancy name lol). 
```shell
$ sudo docker ps 
```

### 4. Create the database
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