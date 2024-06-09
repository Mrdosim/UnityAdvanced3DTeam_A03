using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum weatherState
{
    SUN,
    RAIN,
    SNOW
}

public class WeatherCycle : MonoBehaviour
{
    public GameObject rain;
    public GameObject snow;
    public float durationTime;

    private float nowtime = 0;
    private int weathernum = 0;

    private void Start()
    {
        WeatherDisable(rain);
        WeatherDisable(snow);
    }

    void Update()
    {
        nowtime += Time.deltaTime;

        if(nowtime > durationTime)
        {
            weathernum = Random.Range(0, 2);

            DuringWeather(weathernum);

            nowtime = 0;
        }
    }

    private void DuringWeather(int weathernum)
    {
        switch (weathernum)
        {
            case (int)weatherState.SUN:
                WeatherDisable(rain);
                WeatherDisable(snow);
                break;
            case (int)weatherState.RAIN:
                WeatherEnable(rain);
                WeatherDisable(snow);
                break;
            case (int)weatherState.SNOW:
                WeatherEnable(snow);
                WeatherDisable(rain);
                break;
        }

    }

    private void WeatherEnable(GameObject Weather)
    {
        ParticleSystem weatherParticleSystem = new ParticleSystem();
        weatherParticleSystem = Weather.GetComponent<ParticleSystem>();
        weatherParticleSystem.Play();
    }

    private void WeatherDisable(GameObject Weather)
    {
        ParticleSystem weatherParticleSystem = new ParticleSystem();
        weatherParticleSystem = Weather.GetComponent<ParticleSystem>();
        weatherParticleSystem.Stop();
    }

}
