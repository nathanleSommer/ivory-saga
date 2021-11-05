mongoContainerName=ivory-saga-mongo
mongoLocalhostPort=27018

echo Delete old container if exists
CONTAINER_IS_RUNNING_CHECK=$(docker inspect $mongoContainerName 2> /dev/null)
if [ $? -eq 0 ]; then
 docker rm -f $mongoContainerName
fi

echo Run new containers...
docker run -d --name $mongoContainerName \
    -v mongodata:/data/db \
    -p $mongoLocalhostPort:27017 \
    --restart=always \
    mongo:5.0.3