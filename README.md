# Yoga-Core project.

Hello, welcome to my simple project. This is my personal repository that contain several experiments on one application, including but not limited to:
1. ASP.NET Core (previously known as ASP.NET 5)
2. Entity Framework Core
3. Single Page Application concept with AngularJS
4. Responsive Design with Bootstrap
5. Unit Test with XUnit
6. ... etc

## The Main Goal
The goal i've made this repository is to make sure that i know **how to** develop, build and run a simple asp.net core application both on windows and linux platform.

You need to clone this repository to make sure you get the sample working source code. 
```shell
$ git clone https://github.com/putuyoga/yoga-core.git yoga-core
```

## Windows Platform
1. Install .NET Core SDK, [obtain here](https://www.microsoft.com/net/core#windows).
2. Add the database by executing `add_database.bat`.
3. Open `YogaCore.sln` file on Visual Studio and hit `F5` key to run application. 
4. Enjoy.

## Linux Platform
This is not a joke. Oh yeah, .NET Core can run on linux too, not limited to windows operating system. So for every .NET developer there, start from now, you should familiarize  yourself with Linux (lol).

Okay, before run the application, we need to install asp.net core to our linux machine.
### 1. Add the Repository
You can run the following command to subscribe to .net core repository feed :
```shell
$ sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
```
Obtain the server key:
```shell
$ sudo apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
```
Update the repos:
```shell
$ sudo apt-get update
```

### 2. Install .NET Core SDK
Run below command to install package of .NET Core SDK with its dependencies :
```shell
sudo apt-get install dotnet-dev-1.0.0-preview2-003121
```

### 3. Build & Run the Application
After the .NET Core SDK installed on your system, lets try build and run sample code that i have provide before. Run the following command :
```shell
$ cd ~/src/YogaCore/
$ dotnet restore
$ dotnet run
```
the first command, make sure your working directory is the root of source code application, and the second comand is to restore the packages required by application. The last command to run the application.

Thats it ? If you look carefuly, it will be run, but can not connect to database as the database did not present yet. So you need to run `add_database.sh` to properly add the database. 

Quite simple ? Yes, even you did not need Visual Studio 2015 since it is only support Windows Platform. But do not worry, you can try Visual Studio Code, or maybe.... a Vim!

### Common Problems
#### # Error when trying to obtain the Key Server
If your work environment are behind corporate proxy wall like me, maybe you getting that error like `connection time out` or `connection refused`. 

the root of problem is we can not automatically add the signature from keyserver because that proxy, even we add the proxy configuration to command!

So the solution for that one is below :
1. Run : `sudo apt-get update` and get the id of pubkey, as we do the same topic, so the key should be `417A0893`. 
2. Open http://keyserver.ubuntu.com and search the key with `0x417A0893` and hit the search button. You can obtain the public server key from [there](http://keyserver.ubuntu.com/pks/lookup?op=get&search=0xB02C46DF417A0893). 
3. Download the file/txt, whatever your tools, my favorit is using wget. 
4. And then run : `sudo apt-key add key.txt` to add the key. 
5. Run again `sudo apt-get update` and you should get working repository. 




## Docker on Linux Platform

What is Docker and why it is so popular in last few years ?
In a short, Docker is a leading containerization platform. In a long, see below explanation.

Instead having multiple virtual machine for each application, you just having multiple container on **one host machine**. 

Much less resource usage comparing with virtual machine but still share same benefit, the __isolation environment__. See image below.

![comparison-container-vm](https://www.rightscale.com/blog/sites/default/files/docker-containers-vms.png)

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