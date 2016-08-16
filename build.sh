#!/bin/bash.
cd "src/YogaCore"
sudo docker build -t ${python -c "import uuid; print str(uuid.uuid1())"} .