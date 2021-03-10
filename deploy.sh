dotnet publish -c Release
docker build -t service-practice ./bin/Release/net5.0/publish
docker tag service-practice registry.heroku.com/bloggr-ethanvach/web
docker push registry.heroku.com/bloggr-ethanvach/web
heroku container:release web -a bloggr-ethanvach
echo press any key
read end