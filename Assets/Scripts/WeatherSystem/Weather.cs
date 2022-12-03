using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// State Pattern representing Weather
public class Weather
{
    protected WeatherForecaster forecaster;

    public Weather(WeatherForecaster weatherForecaster)
    {
        forecaster = weatherForecaster;
    }

    // Returns a string of the weather effect that is trigger based on rng
    protected string GenerateWeather()
    {
        string effectName = "";

        foreach(WeatherData data in forecaster.weatherEffects)
        {
            float rng = Random.Range(0.0f, 1.0f);

            if (rng <= data.probability)
            {
                effectName = data.effect.name;
                break;
            }
        }
        return effectName;
    }

    public virtual void enter() { }
    public virtual Weather transition() { return this; }
    public virtual void exit() { }
}
