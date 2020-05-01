### Type the following commands to run the web application

```
docker build -t isirestaurant .
docker run -it --rm -p 8000:80 --name isirestaurant isirestaurant
```

After the application starts, go to `http://localhost:8000`.
