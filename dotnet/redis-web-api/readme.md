# Redis Web API Field Test
Shows a way to connect .Net 5 webapi App to Redis, and to use it. Implemented with the default Weather Forecast example.

## Idea
Comes from [Intro to Redis in C# - Caching Made Easy](https://youtu.be/UrQWii_kfIE)

## It works because

The Weather Forecast Controller has a log, indicating where to fetch the data, either from an imaginary DB or from Redis.

The log shows:

```
info: RedisWebAPI.App.Controllers.WeatherForecastController[0]
      Loading from API at 03/14/2021 23:24:39
info: RedisWebAPI.App.Controllers.WeatherForecastController[0]
      Loading from CACHE at 03/14/2021 23:24:44
info: RedisWebAPI.App.Controllers.WeatherForecastController[0]
      Loading from CACHE at 03/14/2021 23:24:51
info: RedisWebAPI.App.Controllers.WeatherForecastController[0]
      Loading from CACHE at 03/14/2021 23:24:53
info: RedisWebAPI.App.Controllers.WeatherForecastController[0]
      Loading from CACHE at 03/14/2021 23:24:54
info: RedisWebAPI.App.Controllers.WeatherForecastController[0]
      Loading from API at 03/14/2021 23:25:05
info: RedisWebAPI.App.Controllers.WeatherForecastController[0]
      Loading from CACHE at 03/14/2021 23:25:07
```

So it is considered to be working as expected.

No unit tests are provided since this field test is at the controller level.

## Redis

An example docker-compose file for setting up Redis has been provided for references.

You will also need to provide your own config file. Please refer to https://redis.io/topics/config
