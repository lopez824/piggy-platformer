using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeatherForecaster : MonoBehaviour
{
    public ParticleSystem defaultWeather;
    public int weatherInterval;

    public List<WeatherData> weatherEffects;

    public Dictionary<string, ParticleSystem> weatherParticles;
    public Dictionary<string, float> weatherProbabilites;

    [HideInInspector]
    public List<float> probabilityVector;

    private Weather currentWeather;
    private SquareMatrix matrix;

    void Awake()
    {
        weatherParticles = new Dictionary<string, ParticleSystem>();
        weatherProbabilites = new Dictionary<string, float>();
        probabilityVector = new List<float>();
        
        foreach (WeatherData data in weatherEffects)
        {
            weatherParticles.Add(data.effect.name, data.effect);
            weatherProbabilites.Add(data.effect.name, data.probability);
            probabilityVector.Add(data.probability);
        }

        matrix = new SquareMatrix(probabilityVector);
        matrix.MatrixSquared();
    }

    private void Start()
    {
        initWeather();
        StartCoroutine(UpdateWeather());
    }

    // Default weather state that is set in the inspector
    public void initWeather()
    {
        switch (defaultWeather.name)
        {
            case "Foggy":
                currentWeather = new Foggy(this);
                currentWeather.enter();
                break;
            case "Rainy":
                currentWeather = new Rainy(this);
                currentWeather.enter();
                break;
            case "SandStormy":
                currentWeather = new SandStormy(this);
                currentWeather.enter();
                break;
            case "Snowy":
                currentWeather = new Snowy(this);
                currentWeather.enter();
                break;
            case "Sunny":
                currentWeather = new Sunny(this);
                currentWeather.enter();
                break;
        }
    }

    // Changes weather state
    private void ChangeWeather()
    {
        Weather newWeather = currentWeather.transition();

        if (newWeather != null)
        {
            currentWeather.exit();
            currentWeather = newWeather;
            currentWeather.enter();
        }
    }

    // Recursive coroutine that updates weather every weatherInterval(seconds)
    private IEnumerator UpdateWeather()
    {
        yield return new WaitForSeconds(weatherInterval);
        
        ChangeWeather();
        //matrix.MatrixSquared();
        StartCoroutine(UpdateWeather());
    }
}
