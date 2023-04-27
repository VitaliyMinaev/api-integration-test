# Weather Forecast Coding Quiz

This project contains an API code and a Docker image for a weather forecast application. The purpose of this project is to create a proxy that will use the given API to display the received data, based on the user's selected region.

## Getting Started
To get started, you will need to have the API code and/or the Docker image on your local machine. You can either clone the API code from the GitHub repository or pull the Docker image from DockerHub using the following command:

```console
docker image pull vitaliiminaev:weather-forecast
```

If you choose to run the Docker image, you can use the following command:

```console
docker run --name weather-forecast-api -d -p 8080:80 vitaliiminaev/weather-forecast:v1
```

## API Description

The API has two endpoints, the first being HealthCheck, which is available at the root URL, and the second being WeatherForecast, which waits for an HttpGet request and returns a generated weather forecast. The endpoint URL for the WeatherForecast is:

```console
http(s)://localhost:{port}/WeatherForecast
```

## Usage

Once you have the API code or Docker image on your local machine, you can create a proxy (console application, web API, mobile application) that will use the given API to display the weather forecast for the selected region.

For example, if you create a console application, you can specify the region as a parameter at startup. If you create a mobile application, you can automatically obtain the user's region using GPS.
