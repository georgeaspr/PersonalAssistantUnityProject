using System.Collections;
using Newtonsoft.Json;
using TMPro;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class News_Api_Script : MonoBehaviour
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Result
    {
        public string title { get; set; }
        public string link { get; set; }
        public List<string> keywords { get; set; }
        public List<string> creator { get; set; }
        public object video_url { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string pubDate { get; set; }
        public string image_url { get; set; }
        public string source_id { get; set; }
        public List<string> category { get; set; }
        public List<string> country { get; set; }
        public string language { get; set; }
    }

    public class Root
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Result> results { get; set; }
        public string nextPage { get; set; }
    }
    private CanvasGroup[] Hidesmain;
    private CanvasGroup[] Revsmain;
    private CanvasGroup[] Revsnews;
    private CanvasGroup[] Hidesnews;
    private CanvasGroup[] Hidesarticle;
    private CanvasGroup[] Hidesback;
    private CanvasGroup[] Revsback;
    private CanvasGroup[] Revsarticle;
    public Button tech;
    public Button science;
    public Button business;
    public Button sports;
    public Button politics;
    public TextMeshProUGUI in_Title_tech;
    public TextMeshProUGUI in_Title_politics;
    public TextMeshProUGUI in_Title_sports;
    public TextMeshProUGUI in_Title_business;
    public TextMeshProUGUI in_Title_science;
    public TextMeshProUGUI techcat;
    public TextMeshProUGUI polcat;
    public TextMeshProUGUI sportscat;
    public TextMeshProUGUI buscat;
    public TextMeshProUGUI sciencecat;
    public TextMeshProUGUI site1;
    public TextMeshProUGUI site2;
    public TextMeshProUGUI site3;
    public TextMeshProUGUI site4;
    public TextMeshProUGUI site5;
    public Image Background;
    public Button TitleTech;
    public Button TitlePolitics;
    public Button TitleSports;
    public Button TitleBusiness;
    public Button TitleScience;
    public Image b1;
    public Image b2;
    public Image b3;
    public Image b4;
    public Image b5;
    public Button rmore1;
    public Button rmore2;
    public Button rmore3;
    public Button rmore4;
    public Button rmore5;
    public Button BackButton;
    public int page;


    //Hide
    public Image main_background;
    public Image square;
    public Image square1;
    public Image square2;
    public TextMeshProUGUI Top_headlines;
    public Button TitleTech1;
    public Button TitlePolitics1;
    public Button TitleSports1;
    public Button TitleBusiness1;
    public Button TitleScience1;
    public Image btech;
    public Image bpolitics;
    public Image bsports;
    public Image bbusiness;
    public Image bscience;
    public TextMeshProUGUI techcat1;
    public TextMeshProUGUI polcat1;
    public TextMeshProUGUI sportscat1;
    public TextMeshProUGUI buscat1;
    public TextMeshProUGUI sciencecat1;
    public TextMeshProUGUI TextTech;
    public TextMeshProUGUI TextPol;
    public TextMeshProUGUI TextSports;
    public TextMeshProUGUI TextBus;
    public TextMeshProUGUI TextScience;
    public TMP_Dropdown categories;
    public Button fsv;

    //Article
    public Image Abackground;
    public ScrollRect scroll;
    public TextMeshProUGUI title;
    public TextMeshProUGUI content;
    public TextMeshProUGUI pubdate;
    public TextMeshProUGUI creator;
    public TextMeshProUGUI source;




    public void TitleSetter(TextMeshProUGUI text, Root obj)
    {
        string trunctext = obj.results[0].title;
        text.text = TruncateText(trunctext, 111);
    }

    private string TruncateText(string text, int maxLength)
    {
        if (text.Length > maxLength)
        {
            return text.Substring(0, maxLength - 3) + "...";
        }
        return text;
    }

    public void OnButtonBackClick(int page)
    {

        Hidesback = new CanvasGroup[1];
        Hidesback[0] = BackButton.GetComponent<CanvasGroup>();
        if (page == 0)
        {
            Hidesback[0].alpha = 0f;
            Hidesback[0].interactable = false;
            Hidesback[0].blocksRaycasts = false;

        }
        else if (page == 1)
        {

            HideNews();
            RevMain();


        }
        else if (page == 2)
        {
            HideArticle();
            RevBack();
            HideMain();


        }
    }




    //public TMP_InputField userSearch;




    private IEnumerator MakeAPIRequests()
    {
        // Call the first API and store the result in textFields[0]
        using (UnityWebRequest apitech = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=technology&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return apitech.SendWebRequest();
            switch (apitech.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apitech.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apitech success");
                    Root results = JsonConvert.DeserializeObject<Root>(apitech.downloadHandler.text);
                    TitleSetter(in_Title_tech, results);
                    TitleSetter(TextTech, results);
                    Root source = JsonConvert.DeserializeObject<Root>(apitech.downloadHandler.text);
                    site1.text = "Source: " + source.results[0].source_id;
                    break;
            }
        }
        // Call the second API and store the result in textFields[1]
        using (UnityWebRequest apisports = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=sports&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return apisports.SendWebRequest();
            switch (apisports.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apisports.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apisports success");
                    Root results1 = JsonConvert.DeserializeObject<Root>(apisports.downloadHandler.text);
                    TitleSetter(in_Title_sports, results1);
                    TitleSetter(TextSports, results1);
                    Root source1 = JsonConvert.DeserializeObject<Root>(apisports.downloadHandler.text);
                    site2.text = "Source: " + source1.results[0].source_id;
                    break;
            }
        }

        using (UnityWebRequest apipolitics = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=politics&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return apipolitics.SendWebRequest();
            switch (apipolitics.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apipolitics.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apipolitics success");
                    Root results2 = JsonConvert.DeserializeObject<Root>(apipolitics.downloadHandler.text);
                    TitleSetter(in_Title_politics, results2);
                    TitleSetter(TextPol, results2);
                    Root source2 = JsonConvert.DeserializeObject<Root>(apipolitics.downloadHandler.text);
                    site3.text = "Source: " + source2.results[0].source_id;
                    break;
            }
        }

        using (UnityWebRequest apibusiness = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=business&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return apibusiness.SendWebRequest();
            switch (apibusiness.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apibusiness.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apibusiness success");
                    Root results3 = JsonConvert.DeserializeObject<Root>(apibusiness.downloadHandler.text);
                    TitleSetter(in_Title_business, results3);
                    TitleSetter(TextBus, results3);
                    Root source3 = JsonConvert.DeserializeObject<Root>(apibusiness.downloadHandler.text);
                    site4.text = "Source: " + source3.results[0].source_id;
                    break;
            }
        }

        using (UnityWebRequest apiscience = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=science&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return apiscience.SendWebRequest();
            switch (apiscience.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apiscience.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apiscience success");
                    Root results4 = JsonConvert.DeserializeObject<Root>(apiscience.downloadHandler.text);
                    TitleSetter(in_Title_science, results4);
                    TitleSetter(TextScience, results4);
                    Root source4 = JsonConvert.DeserializeObject<Root>(apiscience.downloadHandler.text);
                    site5.text = "Source: " + source4.results[0].source_id;
                    break;
            }
        }

        // Repeat the process for the remaining APIs and textFields
        // ...

        Debug.Log("API calls completed!");

    }

    public void HideArticle()
    {

        Hidesarticle = new CanvasGroup[2];
        Hidesarticle[0] = Abackground.GetComponent<CanvasGroup>();
        Hidesarticle[1] = scroll.GetComponent<CanvasGroup>();
        foreach (CanvasGroup canvasGroup in Hidesarticle)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void RevArticle()
    {
        Revsarticle = new CanvasGroup[2];
        Revsarticle[0] = Abackground.GetComponent<CanvasGroup>();
        Revsarticle[1] = scroll.GetComponent<CanvasGroup>();
        foreach (CanvasGroup canvasGroup in Revsarticle)
        {
            if (canvasGroup.alpha == 0f)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
        }
    }
    public void RevBack()
    {
        Revsback = new CanvasGroup[1];
        Revsback[0] = BackButton.GetComponent<CanvasGroup>();
        if (Revsback[0].alpha == 0f)
        {
            Revsback[0].alpha = 1f;
            Revsback[0].interactable = true;
            Revsback[0].blocksRaycasts = true;
        }
        else
        {
            return;
        }

    }

    public void RevMain()
    {
        page = 0;
        OnButtonBackClick(0);
        Revsmain = new CanvasGroup[27];
        Revsmain[0] = square.GetComponent<CanvasGroup>();
        Revsmain[1] = square1.GetComponent<CanvasGroup>();
        Revsmain[2] = square2.GetComponent<CanvasGroup>();
        Revsmain[3] = Top_headlines.GetComponent<CanvasGroup>();
        Revsmain[4] = TitleTech1.GetComponent<CanvasGroup>();
        Revsmain[5] = TitlePolitics1.GetComponent<CanvasGroup>();
        Revsmain[6] = TitleSports1.GetComponent<CanvasGroup>();
        Revsmain[7] = TitleBusiness1.GetComponent<CanvasGroup>();
        Revsmain[8] = TitleScience1.GetComponent<CanvasGroup>();
        Revsmain[9] = btech.GetComponent<CanvasGroup>();
        Revsmain[10] = bpolitics.GetComponent<CanvasGroup>();
        Revsmain[11] = bsports.GetComponent<CanvasGroup>();
        Revsmain[12] = bbusiness.GetComponent<CanvasGroup>();
        Revsmain[13] = bscience.GetComponent<CanvasGroup>();
        Revsmain[14] = techcat1.GetComponent<CanvasGroup>();
        Revsmain[15] = polcat1.GetComponent<CanvasGroup>();
        Revsmain[16] = sportscat1.GetComponent<CanvasGroup>();
        Revsmain[17] = buscat1.GetComponent<CanvasGroup>();
        Revsmain[18] = sciencecat1.GetComponent<CanvasGroup>();
        Revsmain[19] = categories.GetComponent<CanvasGroup>();
        Revsmain[20] = fsv.GetComponent<CanvasGroup>();
        Revsmain[21] = main_background.GetComponent<CanvasGroup>();
        Revsmain[22] = TextTech.GetComponent<CanvasGroup>();
        Revsmain[23] = TextPol.GetComponent<CanvasGroup>();
        Revsmain[24] = TextSports.GetComponent<CanvasGroup>();
        Revsmain[25] = TextBus.GetComponent<CanvasGroup>();
        Revsmain[26] = TextScience.GetComponent<CanvasGroup>();

        foreach (CanvasGroup canvasGroup in Revsmain)
        {
            if (canvasGroup.alpha == 0f)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
        }
    }

    public void HideNews()
    {

        Hidesnews = new CanvasGroup[27];
        Hidesnews[0] = Background.GetComponent<CanvasGroup>();
        Hidesnews[1] = TitlePolitics.GetComponent<CanvasGroup>();
        Hidesnews[2] = TitleScience.GetComponent<CanvasGroup>();
        Hidesnews[3] = TitleSports.GetComponent<CanvasGroup>();
        Hidesnews[4] = TitleBusiness.GetComponent<CanvasGroup>();
        Hidesnews[5] = techcat.GetComponent<CanvasGroup>();
        Hidesnews[6] = polcat.GetComponent<CanvasGroup>();
        Hidesnews[7] = sportscat.GetComponent<CanvasGroup>();
        Hidesnews[8] = buscat.GetComponent<CanvasGroup>();
        Hidesnews[9] = sciencecat.GetComponent<CanvasGroup>();
        Hidesnews[10] = b1.GetComponent<CanvasGroup>();
        Hidesnews[11] = b2.GetComponent<CanvasGroup>();
        Hidesnews[12] = b3.GetComponent<CanvasGroup>();
        Hidesnews[13] = b4.GetComponent<CanvasGroup>();
        Hidesnews[14] = b5.GetComponent<CanvasGroup>();
        Hidesnews[15] = rmore1.GetComponent<CanvasGroup>();
        Hidesnews[16] = rmore2.GetComponent<CanvasGroup>();
        Hidesnews[17] = rmore3.GetComponent<CanvasGroup>();
        Hidesnews[18] = rmore4.GetComponent<CanvasGroup>();
        Hidesnews[19] = rmore5.GetComponent<CanvasGroup>();
        Hidesnews[20] = site1.GetComponent<CanvasGroup>();
        Hidesnews[21] = site2.GetComponent<CanvasGroup>();
        Hidesnews[22] = site3.GetComponent<CanvasGroup>();
        Hidesnews[23] = site4.GetComponent<CanvasGroup>();
        Hidesnews[24] = site5.GetComponent<CanvasGroup>();
        Hidesnews[25] = TitleTech.GetComponent<CanvasGroup>();
        Hidesnews[26] = main_background.GetComponent<CanvasGroup>();


        foreach (CanvasGroup canvasGroup in Hidesnews)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

    }

    public void HideMain()
    {
        page = 1;
        Hidesmain = new CanvasGroup[26];
        Hidesmain[0] = square.GetComponent<CanvasGroup>();
        Hidesmain[1] = square1.GetComponent<CanvasGroup>();
        Hidesmain[2] = square2.GetComponent<CanvasGroup>();
        Hidesmain[3] = Top_headlines.GetComponent<CanvasGroup>();
        Hidesmain[4] = TitleTech1.GetComponent<CanvasGroup>();
        Hidesmain[5] = TitlePolitics1.GetComponent<CanvasGroup>();
        Hidesmain[6] = TitleSports1.GetComponent<CanvasGroup>();
        Hidesmain[7] = TitleBusiness1.GetComponent<CanvasGroup>();
        Hidesmain[8] = TitleScience1.GetComponent<CanvasGroup>();
        Hidesmain[9] = btech.GetComponent<CanvasGroup>();
        Hidesmain[10] = bpolitics.GetComponent<CanvasGroup>();
        Hidesmain[11] = bsports.GetComponent<CanvasGroup>();
        Hidesmain[12] = bbusiness.GetComponent<CanvasGroup>();
        Hidesmain[13] = bscience.GetComponent<CanvasGroup>();
        Hidesmain[14] = techcat1.GetComponent<CanvasGroup>();
        Hidesmain[15] = polcat1.GetComponent<CanvasGroup>();
        Hidesmain[16] = sportscat1.GetComponent<CanvasGroup>();
        Hidesmain[17] = buscat1.GetComponent<CanvasGroup>();
        Hidesmain[18] = sciencecat1.GetComponent<CanvasGroup>();
        Hidesmain[19] = categories.GetComponent<CanvasGroup>();
        Hidesmain[20] = fsv.GetComponent<CanvasGroup>();
        Hidesmain[21] = TextTech.GetComponent<CanvasGroup>();
        Hidesmain[22] = TextPol.GetComponent<CanvasGroup>();
        Hidesmain[23] = TextSports.GetComponent<CanvasGroup>();
        Hidesmain[24] = TextBus.GetComponent<CanvasGroup>();
        Hidesmain[25] = TextScience.GetComponent<CanvasGroup>();
        foreach (CanvasGroup canvasGroup in Hidesmain)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        Revsnews = new CanvasGroup[26];
        Revsnews[0] = Background.GetComponent<CanvasGroup>();
        Revsnews[1] = TitlePolitics.GetComponent<CanvasGroup>();
        Revsnews[2] = TitleScience.GetComponent<CanvasGroup>();
        Revsnews[3] = TitleSports.GetComponent<CanvasGroup>();
        Revsnews[4] = TitleBusiness.GetComponent<CanvasGroup>();
        Revsnews[5] = techcat.GetComponent<CanvasGroup>();
        Revsnews[6] = polcat.GetComponent<CanvasGroup>();
        Revsnews[7] = sportscat.GetComponent<CanvasGroup>();
        Revsnews[8] = buscat.GetComponent<CanvasGroup>();
        Revsnews[9] = sciencecat.GetComponent<CanvasGroup>();
        Revsnews[10] = b1.GetComponent<CanvasGroup>();
        Revsnews[11] = b2.GetComponent<CanvasGroup>();
        Revsnews[12] = b3.GetComponent<CanvasGroup>();
        Revsnews[13] = b4.GetComponent<CanvasGroup>();
        Revsnews[14] = b5.GetComponent<CanvasGroup>();
        Revsnews[15] = rmore1.GetComponent<CanvasGroup>();
        Revsnews[16] = rmore2.GetComponent<CanvasGroup>();
        Revsnews[17] = rmore3.GetComponent<CanvasGroup>();
        Revsnews[18] = rmore4.GetComponent<CanvasGroup>();
        Revsnews[19] = rmore5.GetComponent<CanvasGroup>();
        Revsnews[20] = site1.GetComponent<CanvasGroup>();
        Revsnews[21] = site2.GetComponent<CanvasGroup>();
        Revsnews[22] = site3.GetComponent<CanvasGroup>();
        Revsnews[23] = site4.GetComponent<CanvasGroup>();
        Revsnews[24] = site5.GetComponent<CanvasGroup>();
        Revsnews[25] = TitleTech.GetComponent<CanvasGroup>();
        foreach (CanvasGroup canvasGroup in Revsnews)
        {
            if (canvasGroup.alpha == 0f)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }
        }


    }

    public void OnButtonFSVClick()
    {

        HideMain();
        RevBack();
        StartCoroutine(MakeAPIRequests());


    }



    private IEnumerator TechRequest()
    {
        // Call the first API and store the result in textFields[0]
        using (UnityWebRequest api1 = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=technology&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return api1.SendWebRequest();
            switch (api1.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", api1.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apitech success");
                    Root resultstech = JsonConvert.DeserializeObject<Root>(api1.downloadHandler.text);
                    title.text = resultstech.results[0].title;
                    pubdate.text = "Date published: " + resultstech.results[0].pubDate;
                    source.text = "Source: " + resultstech.results[0].source_id;
                    content.text = resultstech.results[0].content;
                    creator.text = "Author: " + resultstech.results[0].creator[0];

                    break;
            }
        }
    }

    public void OnButtonTechClick()
    {
        page = 2;
        HideNews();
        RevBack();
        RevArticle();
        StartCoroutine(TechRequest());

    }



    private IEnumerator SportsRequest()
    {
        // Call the first API and store the result in textFields[0]
        using (UnityWebRequest api2 = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=sports&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return api2.SendWebRequest();
            switch (api2.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", api2.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apisports success");
                    Root resultssport = JsonConvert.DeserializeObject<Root>(api2.downloadHandler.text);
                    title.text = resultssport.results[0].title;
                    pubdate.text = "Date published: " + resultssport.results[0].pubDate;
                    source.text = "Source: " + resultssport.results[0].source_id;
                    content.text = resultssport.results[0].content;
                    creator.text = "Author: " + resultssport.results[0].creator[0];

                    break;
            }
        }
    }

    public void OnButtonSportsClick()
    {
        page = 2;
        HideNews();
        RevBack();
        RevArticle();
        StartCoroutine(SportsRequest());

    }

    private IEnumerator PoliticsRequest()
    {
        // Call the first API and store the result in textFields[0]
        using (UnityWebRequest api3 = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=politics&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return api3.SendWebRequest();
            switch (api3.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", api3.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apipolitics success");
                    Root resultspol = JsonConvert.DeserializeObject<Root>(api3.downloadHandler.text);
                    title.text = resultspol.results[0].title;
                    pubdate.text = "Date published: " + resultspol.results[0].pubDate;
                    source.text = "Source: " + resultspol.results[0].source_id;
                    content.text = resultspol.results[0].content;
                    creator.text = "Author: " + resultspol.results[0].creator[0];

                    break;
            }
        }
    }

    public void OnButtonPoliticsClick()
    {
        page = 2;
        HideNews();
        RevBack();
        RevArticle();
        StartCoroutine(PoliticsRequest());

    }

    private IEnumerator BusinessRequest()
    {
        // Call the first API and store the result in textFields[0]
        using (UnityWebRequest api4 = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=business&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return api4.SendWebRequest();
            switch (api4.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", api4.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apibusiness success");
                    Root resultsbus = JsonConvert.DeserializeObject<Root>(api4.downloadHandler.text);
                    title.text = resultsbus.results[0].title;
                    pubdate.text = "Date published: " + resultsbus.results[0].pubDate;
                    source.text = "Source: " + resultsbus.results[0].source_id;
                    content.text = resultsbus.results[0].content;
                    creator.text = "Author: " + resultsbus.results[0].creator[0];

                    break;
            }
        }
    }


    public void OnButtonBusinessClick()
    {
        page = 2;
        HideNews();
        RevBack();
        RevArticle();
        StartCoroutine(BusinessRequest());

    }

    private IEnumerator ScienceRequest()
    {
        // Call the first API and store the result in textFields[0]
        using (UnityWebRequest api5 = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=science&apikey=pub_23831dccc5553f4d63bdbf84a4dd347f92cae"))
        {
            yield return api5.SendWebRequest();
            switch (api5.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", api5.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apiscience success");
                    Root resultssci = JsonConvert.DeserializeObject<Root>(api5.downloadHandler.text);
                    title.text = resultssci.results[0].title;
                    pubdate.text = "Date published: " + resultssci.results[0].pubDate;
                    source.text = "Source: " + resultssci.results[0].source_id;
                    content.text = resultssci.results[0].content;
                    creator.text = "Author: " + resultssci.results[0].creator[0];

                    break;
            }
        }
    }

    public void OnButtonScienceClick()
    {
        page = 2;
        HideNews();
        RevBack();
        RevArticle();
        StartCoroutine(ScienceRequest());

    }

    // Start is called before the first frame update
    void Awake()
    {

        fsv = GameObject.Find("FullScreenView").GetComponent<Button>();
        fsv.onClick.AddListener(OnButtonFSVClick);
        BackButton = GameObject.Find("BackButton").GetComponent<Button>();
        BackButton.onClick.AddListener(() => OnButtonBackClick(page)); //button.onClick.AddListener(() => MethodName(argument1, argument2));
        rmore1 = GameObject.Find("rmore1").GetComponent<Button>();
        rmore2 = GameObject.Find("rmore2").GetComponent<Button>();
        rmore3 = GameObject.Find("rmore3").GetComponent<Button>();
        rmore4 = GameObject.Find("rmore4").GetComponent<Button>();
        rmore5 = GameObject.Find("rmore5").GetComponent<Button>();
        in_Title_tech = TitleTech.GetComponentInChildren<TextMeshProUGUI>();
        in_Title_politics = TitlePolitics.GetComponentInChildren<TextMeshProUGUI>();
        in_Title_sports = TitleSports.GetComponentInChildren<TextMeshProUGUI>();
        in_Title_business = TitleBusiness.GetComponentInChildren<TextMeshProUGUI>();
        in_Title_science = TitleScience.GetComponentInChildren<TextMeshProUGUI>();
        rmore1.onClick.AddListener(OnButtonTechClick);
        rmore2.onClick.AddListener(OnButtonPoliticsClick);
        rmore3.onClick.AddListener(OnButtonScienceClick);
        rmore4.onClick.AddListener(OnButtonSportsClick);
        rmore5.onClick.AddListener(OnButtonBusinessClick);
        TextTech = TitleTech1.GetComponentInChildren<TextMeshProUGUI>();
        TextPol = TitlePolitics1.GetComponentInChildren<TextMeshProUGUI>();
        TextSports = TitleSports1.GetComponentInChildren<TextMeshProUGUI>();
        TextBus = TitleBusiness1.GetComponentInChildren<TextMeshProUGUI>();
        TextScience = TitleScience1.GetComponentInChildren<TextMeshProUGUI>();

    }

    void Start()
    {

        OnButtonBackClick(0);
        StartCoroutine(MakeAPIRequests());
    }

    private void Update()
    {

    }
}




