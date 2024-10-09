using System.Collections;
using Newtonsoft.Json;
using TMPro;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;








public class Weather_Api : MonoBehaviour
{
   
    public Sprite clear_sky;
    public Sprite fog;
    public Sprite freezing_drizzle_hail_light;
    public Sprite hailstorm;
    public Sprite heavy_rain;
    public Sprite intense_snow;
    public Sprite light_rain;
    public Sprite light_snow;
    public Sprite mainly_clear;
    public Sprite moderate_rain;
    public Sprite moderate_snow;
    public Sprite overcast;
    public Sprite partly_cloudy;
    public Sprite snow_shower;
    public Sprite thunderstorm_heavy_hail;
    public Sprite thunderstorm_light;
    public Sprite thunderstorm_light_hail;
    public Sprite thunderstorm_moderate;
    public Image id1h6;
    public Image id1h9;
    public Image id1h12;
    public Image id1h15;
    public Image id1h18;
    public Image id1h21;
    public Image id1h24;
    public Image id2h6;
    public Image id2h9;
    public Image id2h12;
    public Image id2h15;
    public Image id2h18;
    public Image id2h21;
    public Image id2h24;
    public Image id3h6;
    public Image id3h9;
    public Image id3h12;
    public Image id3h15;
    public Image id3h18;
    public Image id3h21;
    public Image id3h24;
    public Image id4h6;
    public Image id4h9;
    public Image id4h12;
    public Image id4h15;
    public Image id4h18;
    public Image id4h21;
    public Image id4h24;
    public Image id5h6;
    public Image id5h9;
    public Image id5h12;
    public Image id5h15;
    public Image id5h18;
    public Image id5h21;
    public Image id5h24;
    public Image id6h6;
    public Image id6h9;
    public Image id6h12;
    public Image id6h15;
    public Image id6h18;
    public Image id6h21;
    public Image id6h24;
    public Image id7h6;
    public Image id7h9;
    public Image id7h12;
    public Image id7h15;
    public Image id7h18;
    public Image id7h21;
    public Image id7h24;
    public class Daily
    {
        public List<string> time { get; set; }
        public List<double> apparent_temperature_max { get; set; }
        public List<double> apparent_temperature_min { get; set; }
    }

    public class DailyUnits
    {
        public string time { get; set; }
        public string apparent_temperature_max { get; set; }
        public string apparent_temperature_min { get; set; }
    }

    public class Hourly
    {
        public List<double> temperature_2m { get; set; }
        public List<int> weathercode { get; set;}
    }

    public class HourlyUnits
    {
        public string temperature_2m { get; set; }
        
    }
    

    public class Root
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }
        public HourlyUnits hourly_units { get; set; }
        public Hourly hourly { get; set; }
        public DailyUnits daily_units {get; set;}
        public Daily daily {get; set;}
    }   

    
    //public TextMeshProUGUI texthourly_units6;
    //public TextMeshProUGUI texthourly_units9;
    //public TextMeshProUGUI texthourly_units12;
    //public TextMeshProUGUI texthourly_units15;
    //public TextMeshProUGUI texthourly_units18;
    //public TextMeshProUGUI texthourly_units21;
    //public TextMeshProUGUI texthourly_units24;
    public TextMeshProUGUI texthourly6;
    public TextMeshProUGUI texthourly9;
    public TextMeshProUGUI texthourly12;
    public TextMeshProUGUI texthourly15;
    public TextMeshProUGUI texthourly18;
    public TextMeshProUGUI texthourly21;
    public TextMeshProUGUI texthourly24;
    public TextMeshProUGUI weather6d1;
    public TextMeshProUGUI weather9d1;
    public TextMeshProUGUI weather12d1;
    public TextMeshProUGUI weather15d1;
    public TextMeshProUGUI weather18d1;
    public TextMeshProUGUI weather21d1;
    public TextMeshProUGUI weather24d1;
    public TextMeshProUGUI weather6d2;
    public TextMeshProUGUI weather9d2;
    public TextMeshProUGUI weather12d2;
    public TextMeshProUGUI weather15d2;
    public TextMeshProUGUI weather18d2;
    public TextMeshProUGUI weather21d2;
    public TextMeshProUGUI weather24d2;
    public TextMeshProUGUI weather6d3;
    public TextMeshProUGUI weather9d3;
    public TextMeshProUGUI weather12d3;
    public TextMeshProUGUI weather15d3;
    public TextMeshProUGUI weather18d3;
    public TextMeshProUGUI weather21d3;
    public TextMeshProUGUI weather24d3;
    public TextMeshProUGUI weather6d4;
    public TextMeshProUGUI weather9d4;
    public TextMeshProUGUI weather12d4;
    public TextMeshProUGUI weather15d4;
    public TextMeshProUGUI weather18d4;
    public TextMeshProUGUI weather21d4;
    public TextMeshProUGUI weather24d4;
    public TextMeshProUGUI weather6d5;
    public TextMeshProUGUI weather9d5;
    public TextMeshProUGUI weather12d5;
    public TextMeshProUGUI weather15d5;
    public TextMeshProUGUI weather18d5;
    public TextMeshProUGUI weather21d5;
    public TextMeshProUGUI weather24d5;
    public TextMeshProUGUI weather6d6;
    public TextMeshProUGUI weather9d6;
    public TextMeshProUGUI weather12d6;
    public TextMeshProUGUI weather15d6;
    public TextMeshProUGUI weather18d6;
    public TextMeshProUGUI weather21d6;
    public TextMeshProUGUI weather24d6;
    public TextMeshProUGUI weather6d7;
    public TextMeshProUGUI weather9d7;
    public TextMeshProUGUI weather12d7;
    public TextMeshProUGUI weather15d7;
    public TextMeshProUGUI weather18d7;
    public TextMeshProUGUI weather21d7;
    public TextMeshProUGUI weather24d7;
    public TextMeshProUGUI today;
    public TextMeshProUGUI day2;
    public TextMeshProUGUI day3;
    public TextMeshProUGUI day4;
    public TextMeshProUGUI day5;
    public TextMeshProUGUI day6;
    public TextMeshProUGUI day7;
    public TextMeshProUGUI maxtemp1;
    public TextMeshProUGUI mintemp1;
    public TextMeshProUGUI maxtemp2;
    public TextMeshProUGUI mintemp2;
    public TextMeshProUGUI maxtemp3;
    public TextMeshProUGUI mintemp3;
    public TextMeshProUGUI maxtemp4;
    public TextMeshProUGUI mintemp4;
    public TextMeshProUGUI maxtemp5;
    public TextMeshProUGUI mintemp5;
    public TextMeshProUGUI maxtemp6;
    public TextMeshProUGUI mintemp6;
    public TextMeshProUGUI maxtemp7;
    public TextMeshProUGUI mintemp7;
    
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://api.open-meteo.com/v1/forecast?latitude=37.98&longitude=23.73&hourly=temperature_2m,weathercode&daily=apparent_temperature_max,apparent_temperature_min&timezone=Europe%2FLondon"));
       
    }
    
    private void Update()
    {
        
    }

    List<string> weather_status = new List<string>();
    List<Sprite> icons = new List<Sprite>();
    
    // Update is called once per frame
    
    IEnumerator GetRequest(String uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))  
        {
            yield return webRequest.SendWebRequest();
            switch(webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", webRequest.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Root latitude = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root longitude = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root generationtime_ms = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root utc_offset_seconds = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root timezone = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root timezone_abbreviation = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root elevation = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root hourly_units = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root hourly = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root daily = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    Root daily_units = JsonConvert.DeserializeObject<Root>(webRequest.downloadHandler.text);
                    //textlat.text = latitude.latitude.ToString();
                    //textlong.text = longitude.longitude.ToString();
                    //textgen.text = generationtime_ms.generationtime_ms.ToString();
                    //textutc.text = utc_offset_seconds.utc_offset_seconds.ToString();
                    //texttime.text = timezone.timezone;
                    //texttimeab.text = timezone_abbreviation.timezone_abbreviation;
                    //textel.text = elevation.elevation.ToString();
                    //texthourly_units6.text = hourly_units.hourly_units.temperature_2m;
                    //texthourly_units9.text = hourly_units.hourly_units.temperature_2m;
                    //texthourly_units12.text=hourly_units.hourly_units.temperature_2m;
                    //texthourly_units15.text=hourly_units.hourly_units.temperature_2m;
                    //texthourly_units18.text=hourly_units.hourly_units.temperature_2m;
                    //texthourly_units21.text=hourly_units.hourly_units.temperature_2m;
                    //texthourly_units24.text=hourly_units.hourly_units.temperature_2m;
                    texthourly6.text = hourly.hourly.temperature_2m[6].ToString() + "°C";
                    texthourly9.text = hourly.hourly.temperature_2m[9].ToString() + "°C";
                    texthourly12.text = hourly.hourly.temperature_2m[12].ToString() + "°C";
                    texthourly15.text = hourly.hourly.temperature_2m[15].ToString() + "°C";
                    texthourly18.text = hourly.hourly.temperature_2m[18].ToString() + "°C";
                    texthourly21.text = hourly.hourly.temperature_2m[21].ToString() + "°C";
                    texthourly24.text = hourly.hourly.temperature_2m[24].ToString() + "°C";
                    for (int i=0;i<168;i++)
                    {
                        if(hourly.hourly.weathercode[i]== 0 )
                        {
                        weather_status.Add("Clear Sky");
                        icons.Add(clear_sky);
                        }
                        else if(hourly.hourly.weathercode[i]== 1)  
                        {
                        weather_status.Add("Mainly clear"); 
                        icons.Add(mainly_clear);             
                        }
                        else if(hourly.hourly.weathercode[i]== 2)
                        {
                        weather_status.Add("Partly Cloudy");
                        icons.Add(partly_cloudy);
                        }
                        else if(hourly.hourly.weathercode[i]== 3)
                        {
                            weather_status.Add("Overcast");
                            icons.Add(overcast);
                        }
                        else if(hourly.hourly.weathercode[i]== 45)
                        {
                            weather_status.Add("Fog");
                            icons.Add(fog);
                        }
                        else if(hourly.hourly.weathercode[i]== 48)
                        {
                            weather_status.Add("Depositing rime fog");
                            icons.Add(fog);
                        }
                        else if(hourly.hourly.weathercode[i]== 51)
                        {
                            weather_status.Add("Drizzle");
                            icons.Add(light_rain);
                        }
                        else if (hourly.hourly.weathercode[i] == 53)
                        {
                            weather_status.Add("Moderate Drizzle");
                            icons.Add(moderate_rain);
                        }
                        else if (hourly.hourly.weathercode[i] == 55)
                        {
                            weather_status.Add("Dense Drizzle");
                            icons.Add(moderate_rain);
                        }
                        else if (hourly.hourly.weathercode[i] == 56)
                        {
                            weather_status.Add("Light Freezing Drizzle");
                            icons.Add(freezing_drizzle_hail_light);
                        }
                        else if (hourly.hourly.weathercode[i] == 57)
                        {
                            weather_status.Add("Dense Freezing Drizzle");
                            icons.Add(hailstorm);
                        }
                        else if (hourly.hourly.weathercode[i] == 61)
                        {
                            weather_status.Add("Slight Rain");
                            icons.Add(light_rain);
                        }
                        else if (hourly.hourly.weathercode[i] == 63)
                        {
                            weather_status.Add("Moderate Rain");
                            icons.Add(moderate_rain);
                        }
                        else if (hourly.hourly.weathercode[i] == 65)
                        {
                            weather_status.Add("Heavy Rain");
                            icons.Add(heavy_rain);
                        }
                        else if (hourly.hourly.weathercode[i] == 66)
                        {
                            weather_status.Add("Light Freezing Rain");
                            icons.Add(freezing_drizzle_hail_light);
                        }
                        else if (hourly.hourly.weathercode[i] == 67)
                        {
                            weather_status.Add("Heavy Freezing Rain");
                            icons.Add(hailstorm);
                        }
                        else if (hourly.hourly.weathercode[i] == 71)
                        {
                            weather_status.Add("Slight Snow Fall");
                            icons.Add(light_snow);
                        }
                        else if (hourly.hourly.weathercode[i] == 73)
                        {
                            weather_status.Add("Moderate Snow Fall");
                            icons.Add(moderate_snow);
                        }
                        else if (hourly.hourly.weathercode[i] == 75)
                        {
                            weather_status.Add("Heavy Snow Fall");
                            icons.Add(intense_snow);
                        }
                        else if (hourly.hourly.weathercode[i] == 77)
                        {
                            weather_status.Add("Snow Grains");
                            icons.Add(light_snow);
                        }
                        else if (hourly.hourly.weathercode[i] == 80)
                        {
                            weather_status.Add("Slight Rain Showers");
                            icons.Add(moderate_rain);
                        }
                        else if (hourly.hourly.weathercode[i] == 81)
                        {
                            weather_status.Add("Moderate Rain Showers");
                            icons.Add(heavy_rain);
                        }
                        else if (hourly.hourly.weathercode[i] == 82)
                        {
                            weather_status.Add("Violent Rain Showers");
                            icons.Add(heavy_rain);
                        }
                        else if (hourly.hourly.weathercode[i] == 85)
                        {
                            weather_status.Add("Slight Snow Showers");
                            icons.Add(snow_shower);
                        }
                        else if (hourly.hourly.weathercode[i] == 86)
                        {
                            weather_status.Add("Heavy Snow Showers");
                            icons.Add(snow_shower);
                        }
                        else if (hourly.hourly.weathercode[i] == 95)
                        {
                            weather_status.Add("Slight Thunderstorm");
                            icons.Add(thunderstorm_light);
                        }
                        else if (hourly.hourly.weathercode[i] == 96)
                        {
                            weather_status.Add("Thunderstorm with Hail");
                            icons.Add(thunderstorm_light_hail);
                        }
                        else if (hourly.hourly.weathercode[i] == 99)
                        {
                            weather_status.Add("Thunderstorm with Hail");
                            icons.Add(thunderstorm_heavy_hail);
                        }
                        else
                        {
                            weather_status.Add("Unknown Weather Code: ");
                        }
                    }   

                    
                    
                    weather6d1.text= weather_status[6];
                    weather9d1.text= weather_status[9];
                    weather12d1.text= weather_status[12];
                    weather15d1.text= weather_status[15];
                    weather18d1.text= weather_status[18];
                    weather21d1.text= weather_status[21];
                    weather24d1.text= weather_status[24];
                    weather6d2.text= weather_status[30];           
                    weather9d2.text= weather_status[33];
                    weather12d2.text= weather_status[36];
                    weather15d2.text= weather_status[39];
                    weather18d2.text= weather_status[42];
                    weather21d2.text= weather_status[45];
                    weather24d2.text= weather_status[48];
                    weather6d3.text= weather_status[54];
                    weather9d3.text= weather_status[57];
                    weather12d3.text = weather_status[60];
                    weather15d3.text= weather_status[63];
                    weather18d3.text= weather_status[66];
                    weather21d3.text= weather_status[69];
                    weather24d3.text= weather_status[72];
                    weather6d4.text= weather_status[78];
                    weather9d4.text= weather_status[81];
                    weather12d4.text= weather_status[84];
                    weather15d4.text= weather_status[87];
                    weather18d4.text= weather_status[90];
                    weather21d4.text= weather_status[93];
                    weather24d4.text= weather_status[96];
                    weather6d5.text= weather_status[102];
                    weather9d5.text= weather_status[105];
                    weather12d5.text= weather_status[108];
                    weather15d5.text= weather_status[111];
                    weather18d5.text= weather_status[114];
                    weather21d5.text= weather_status[117];
                    weather24d5.text= weather_status[120];
                    weather6d6.text= weather_status[126];
                    weather9d6.text= weather_status[129];
                    weather12d6.text= weather_status[132];
                    weather15d6.text= weather_status[135];
                    weather18d6.text= weather_status[138];
                    weather21d6.text= weather_status[141];
                    weather24d6.text= weather_status[144];
                    weather6d7.text= weather_status[150];
                    weather9d7.text= weather_status[153];
                    weather12d7.text= weather_status[156];
                    weather15d7.text= weather_status[159];
                    weather18d7.text= weather_status[162];
                    weather21d7.text= weather_status[165];
                    weather24d7.text= weather_status[167];
                    today.text= daily.daily.time[0];
                    day2.text= daily.daily.time[1];
                    day3.text= daily.daily.time[2];
                    day4.text= daily.daily.time[3];
                    day5.text= daily.daily.time[4];
                    day6.text= daily.daily.time[5];
                    day7.text = daily.daily.time[6];
                    maxtemp1.text= daily.daily.apparent_temperature_max[0].ToString();
                    mintemp1.text= daily.daily.apparent_temperature_min[0].ToString();
                    maxtemp2.text= daily.daily.apparent_temperature_max[1].ToString();
                    mintemp2.text= daily.daily.apparent_temperature_min[1].ToString();
                    maxtemp3.text= daily.daily.apparent_temperature_max[2].ToString();
                    mintemp3.text= daily.daily.apparent_temperature_min[2].ToString();
                    maxtemp4.text= daily.daily.apparent_temperature_max[3].ToString();
                    mintemp4.text= daily.daily.apparent_temperature_min[3].ToString();
                    maxtemp5.text= daily.daily.apparent_temperature_max[4].ToString();
                    mintemp5.text= daily.daily.apparent_temperature_min[4].ToString();
                    maxtemp6.text= daily.daily.apparent_temperature_max[5].ToString();
                    mintemp6.text= daily.daily.apparent_temperature_min[5].ToString();
                    maxtemp7.text= daily.daily.apparent_temperature_max[6].ToString();
                    mintemp7.text= daily.daily.apparent_temperature_min[6].ToString();
                    id1h6.sprite = icons[6];
                    id1h9.sprite = icons[9];
                    id1h12.sprite = icons[12];
                    id1h15.sprite = icons[15];
                    id1h18.sprite = icons[18];
                    id1h21.sprite = icons[21];
                    id1h24.sprite = icons[24];
                    id2h6.sprite = icons[30];
                    id2h9.sprite = icons[33];
                    id2h12.sprite = icons[36];
                    id2h15.sprite = icons[39];
                    id2h18.sprite = icons[42];
                    id2h21.sprite = icons[45];
                    id2h24.sprite = icons[48];
                    id3h6.sprite = icons[54];
                    id3h9.sprite = icons[57];
                    id3h12.sprite = icons[60];
                    id3h15.sprite = icons[63];
                    id3h18.sprite = icons[66];
                    id3h21.sprite = icons[69];
                    id3h24.sprite = icons[72];
                    id4h6.sprite = icons[78];
                    id4h9.sprite = icons[81];
                    id4h12.sprite = icons[84];
                    id4h15.sprite = icons[87];
                    id4h18.sprite = icons[90];
                    id4h21.sprite = icons[93];
                    id4h24.sprite = icons[96];
                    id5h6.sprite = icons[102];
                    id5h9.sprite = icons[105];
                    id5h12.sprite = icons[108];
                    id5h15.sprite = icons[111];
                    id5h18.sprite = icons[114];
                    id5h21.sprite = icons[117];
                    id5h24.sprite = icons[120];
                    id6h6.sprite = icons[126];
                    id6h9.sprite = icons[129];
                    id6h12.sprite = icons[132];
                    id6h15.sprite = icons[135];
                    id6h18.sprite = icons[138];
                    id6h21.sprite = icons[141];
                    id6h24.sprite = icons[144];
                    id7h6.sprite = icons[150];
                    id7h9.sprite = icons[153];
                    id7h12.sprite = icons[156];
                    id7h15.sprite = icons[159];
                    id7h18.sprite = icons[162];
                    id7h21.sprite = icons[165];
                    id7h24.sprite = icons[167];
        //weathertime.text = current_weather.current_weather.time;
        // Assume that myList is the list you want to iterate over
        //texthourly.text = hourly.hourly.time[0];
                    break;
            }     
        }
    }
  }
  
  
