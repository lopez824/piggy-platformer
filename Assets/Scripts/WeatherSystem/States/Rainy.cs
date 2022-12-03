using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainy : Weather
{
    public Rainy(WeatherForecaster weatherForecaster) : base(weatherForecaster)
    {
        forecaster = weatherForecaster;
    }

    public override void enter()
    {
        forecaster.weatherParticles["Rainy"].Play();
    }

    public override Weather transition()
    {
        string newWeather = GenerateWeather();
        switch (newWeather)
        {
            case "Foggy":
                return new Foggy(forecaster);
            case "Rainy":
                return new Rainy(forecaster);
            case "SandStormy":
                return new SandStormy(forecaster);
            case "Snowy":
                return new Snowy(forecaster);
            case "Sunny":
                return new Sunny(forecaster);
        }

        return null;
    }

    public override void exit()
    {
        forecaster.weatherParticles["Rainy"].Stop();
    }
}
