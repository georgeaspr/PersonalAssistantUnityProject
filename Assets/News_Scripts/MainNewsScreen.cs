using System.Collections;
using Newtonsoft.Json;
using TMPro;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MainNewsScreen : MonoBehaviour
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
    

    private CanvasGroup[] canvasGroups;
    public TextMeshProUGUI in_Title_tech1 ;
    public TextMeshProUGUI in_Title_politics1;
    public TextMeshProUGUI in_Title_sports1;
    public TextMeshProUGUI in_Title_business1;
    public TextMeshProUGUI in_Title_science1;
    public TextMeshProUGUI techcat1;
    public TextMeshProUGUI polcat1;
    public TextMeshProUGUI sportscat1;
    public TextMeshProUGUI buscat1;
    public TextMeshProUGUI sciencecat1;
    public Button Title_tech1;
    public Button Title_politics1;
    public Button Title_sports1;
    public Button Title_business1;
    public Button Title_science1;
    
    //To hide;
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
    public TextMeshProUGUI techcat;
    public TextMeshProUGUI polcat;
    public TextMeshProUGUI sportscat;
    public TextMeshProUGUI buscat;
    public TextMeshProUGUI sciencecat;
    public Button rmore1;
    public Button rmore2;
    public Button rmore3;
    public Button rmore4;
    public Button rmore5;
    public TextMeshProUGUI site1;
    public TextMeshProUGUI site2;
    public TextMeshProUGUI site3;
    public TextMeshProUGUI site4;
    public TextMeshProUGUI site5;
    
   

    
    
   

    public void TitleSetter(TextMeshProUGUI text, Root obj)
    {
     
        text.text = obj.results[0].title; 
    }
    
    private IEnumerator MakeAPIRequests()
    {
        // Call the first API and store the result in textFields[0]
         using (UnityWebRequest apitech = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=technology&apikey=pub_22882c654212cd3c1f4fb83e17bcfb4a1620f"))  
        {
            yield return apitech.SendWebRequest();
            switch(apitech.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apitech.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apitech success");
                    Root results = JsonConvert.DeserializeObject<Root>(apitech.downloadHandler.text);
                    TitleSetter( in_Title_tech1,results);

                    break;
            }     
        }
        // Call the second API and store the result in textFields[1]
        using (UnityWebRequest apisports = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=sports&apikey=pub_22882c654212cd3c1f4fb83e17bcfb4a1620f"))
        {
            yield return apisports.SendWebRequest();
             switch(apisports.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apisports.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apisports success");
                    Root results1 = JsonConvert.DeserializeObject<Root>(apisports.downloadHandler.text);
                    TitleSetter( in_Title_sports1,results1);
                    
                    break;
            }     
        }

         using (UnityWebRequest apipolitics = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=politics&apikey=pub_22882c654212cd3c1f4fb83e17bcfb4a1620f"))  
        {
            yield return apipolitics.SendWebRequest();
            switch(apipolitics.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apipolitics.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apipolitics success");
                    Root results2 = JsonConvert.DeserializeObject<Root>(apipolitics.downloadHandler.text);
                    TitleSetter( in_Title_politics1,results2);
                    
                    break;
            }     
        }

         using (UnityWebRequest apibusiness = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=business&apikey=pub_22882c654212cd3c1f4fb83e17bcfb4a1620f"))  
        {
            yield return apibusiness.SendWebRequest();
            switch(apibusiness.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apibusiness.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apibusiness success");
                    Root results3 = JsonConvert.DeserializeObject<Root>(apibusiness.downloadHandler.text);
                    TitleSetter( in_Title_business1,results3);
                   
                    break;
            }     
        }

         using (UnityWebRequest apiscience = UnityWebRequest.Get("https://newsdata.io/api/1/news?language=en&category=science&apikey=pub_22882c654212cd3c1f4fb83e17bcfb4a1620f"))  
        {
            yield return apiscience.SendWebRequest();
            switch(apiscience.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(String.Format("Something went wrong: {0}", apiscience.error));
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("apiscience success");
                    Root results4 = JsonConvert.DeserializeObject<Root>(apiscience.downloadHandler.text);
                    TitleSetter( in_Title_science1,results4);
                    
                    break;
            }     
        }

        // Repeat the process for the remaining APIs and textFields
        // ...

        Debug.Log("API calls completed!");
        
    }
    
     public void HideComponents()
    {
        canvasGroups = new CanvasGroup[26];
        canvasGroups[0] = Background.GetComponent<CanvasGroup>();
        canvasGroups[1] = TitlePolitics.GetComponent<CanvasGroup>();
        canvasGroups[2] = TitleScience.GetComponent<CanvasGroup>();
        canvasGroups[3] = TitleSports.GetComponent<CanvasGroup>();
        canvasGroups[4] = TitleBusiness.GetComponent<CanvasGroup>();
        canvasGroups[5] = techcat.GetComponent<CanvasGroup>();
        canvasGroups[6] = polcat.GetComponent<CanvasGroup>();
        canvasGroups[7] = sportscat.GetComponent<CanvasGroup>();
        canvasGroups[8] = buscat.GetComponent<CanvasGroup>();
        canvasGroups[9] = sciencecat.GetComponent<CanvasGroup>();
        canvasGroups[10] = b1.GetComponent<CanvasGroup>();
        canvasGroups[11] = b2.GetComponent<CanvasGroup>();
        canvasGroups[12] = b3.GetComponent<CanvasGroup>();
        canvasGroups[13] = b4.GetComponent<CanvasGroup>();
        canvasGroups[14] = b5.GetComponent<CanvasGroup>();
        canvasGroups[15] = rmore1.GetComponent<CanvasGroup>();
        canvasGroups[16] = rmore2.GetComponent<CanvasGroup>();
        canvasGroups[17] = rmore3.GetComponent<CanvasGroup>();
        canvasGroups[18] = rmore4.GetComponent<CanvasGroup>();
        canvasGroups[19] = rmore5.GetComponent<CanvasGroup>();
        canvasGroups[20] = site1.GetComponent<CanvasGroup>();
        canvasGroups[21] = site2.GetComponent<CanvasGroup>();
        canvasGroups[22] = site3.GetComponent<CanvasGroup>();
        canvasGroups[23] = site4.GetComponent<CanvasGroup>();
        canvasGroups[24] = site5.GetComponent<CanvasGroup>();     
        canvasGroups[25]= TitleTech.GetComponent<CanvasGroup>();
        /*public Image Background;
            public Button TitleTech;
            public Button TitlePolitics;
            public Button TitleSports;
            public Button TitleBusiness;
            public Button TitleScience;
            public Image b2;
            public Image b3;
            public Image b4;
            public Image b5;
            public TextMeshProUGUI date;
            public TextMeshProUGUI techcat;
            public TextMeshProUGUI polcat;
            public TextMeshProUGUI sportscat;
            public TextMeshProUGUI buscat;
            public TextMeshProUGUI sciencecat;
            public Button rmore1;
            public Button rmore2;
            public Button rmore3;
            public Button rmore4;
            public Button rmore5;
            public TextMeshProUGUI site1;
            public TextMeshProUGUI site2;
            public TextMeshProUGUI site3;
            public TextMeshProUGUI site4;
            public TextMeshProUGUI site5;*/

        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
    //}
    
   
    
    // Start is called before the first frame update
    void Awake()
    {     
       
    }

    void Start()
    {   
       
        
        in_Title_tech1 = Title_tech1.GetComponentInChildren<TextMeshProUGUI>();
        in_Title_politics1 = Title_politics1.GetComponentInChildren<TextMeshProUGUI>();
        in_Title_sports1 = Title_sports1.GetComponentInChildren<TextMeshProUGUI>();
        in_Title_business1 = Title_business1.GetComponentInChildren<TextMeshProUGUI>();
        in_Title_science1 = Title_science1.GetComponentInChildren<TextMeshProUGUI>();
        HideComponents();
        StartCoroutine(MakeAPIRequests());
    }
    
    private void Update()
    {
        
    }
}
    
   
  
  
/*public string ReadInput()
    {
        string answer = "https://newsapi.org/v2/everything?q=technology&apiKey=02eb9c14b8514c3c9618e59168ca92af";
        string userInput = userSearch.text;
        wordList.Clear();
        if (string.IsNullOrEmpty(userInput))
        {
            Debug.Log("Input field is empty");
            return answer ; // Exit the function if the input field is empty
        }
        else
        {
            string[] words = userInput.Split(' ');

            // Clear the previous contents of the wordList
            

            // Add each word to the wordList
            for (int i = 0; i < words.Length; i++)
            {
                wordList.Add(words[i]);
            }

            // Debugging: Print the wordList to the console
            string api = "https://newsapi.org/v2/everything?q=technology";
            for (int i = 0; i < wordList.Count; i++)
            {
                if(wordList[i].Equals('\n'))
                   {
                    break;
                   }
                else
                  {
                    api += "%20AND%20" + wordList[i];
                  }
            api += "&apiKey=02eb9c14b8514c3c9618e59168ca92af";
            Debug.Log(api);
            
            }
            return api;
     }
    }*/
    
   
    // private void Start()
    //{
        // Get the reference to Button1
