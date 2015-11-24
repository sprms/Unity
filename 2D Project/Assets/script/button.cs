using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class button : MonoBehaviour {

    public Image img;
    public float mineral;
    static float currentMineral;
    public int _current;
    static float maxMineral;

    public TextMesh text;

    float energy;

	// Use this for initialization
	void Start () {

        // energy = PlayerPrefs.GetFloat("energy");
       // text.text = "x " + PlayerPrefs.GetFloat("energy").ToString();
        currentMineral = 130;
        maxMineral = 200;
        StartCoroutine("auto");
    }
	
	// Update is called once per frame
	void Update () {
      

        _current = (int)currentMineral;
        img.fillAmount = currentMineral / maxMineral;

    }

    public void HelperCall(GameObject target)
    {

        Debug.Log(target.name);

        if(currentMineral > 0 && currentMineral >= mineral)
        {
            if(target.name != "penguin" && target.name != "pikachu" & target.name != "acuma")
            {
                Instantiate(target, new Vector3(0, Random.RandomRange(0.8f, 2.0f), 0), target.transform.rotation);
                currentMineral -= mineral;
            }

            if(target.name == "penguin")
            {
                if (PlayerPrefs.HasKey("penguin"))
                {
                    Instantiate(target, new Vector3(0, Random.RandomRange(0.8f, 2.0f), 0), target.transform.rotation);
                    currentMineral -= mineral;
                }
                    
            }

            if (target.name == "pikachu")
            {
                if (PlayerPrefs.HasKey("pikachu"))
                {
                    Instantiate(target, new Vector3(0, Random.RandomRange(0.8f, 2.0f), 0), target.transform.rotation);
                    currentMineral -= mineral;
                }

            }

            if (target.name == "acuma")
            {
                if (PlayerPrefs.HasKey("acuma"))
                {
                    Instantiate(target, new Vector3(0, Random.RandomRange(0.8f, 2.0f), 0), target.transform.rotation);
                    currentMineral -= mineral;
                }

            }

        }
            

    }


    public void energy_drinking()
    {


        if ( PlayerPrefs.GetFloat("energy") > 0)
        {

            energy = PlayerPrefs.GetFloat("energy");
            PlayerPrefs.SetFloat("energy", energy-1);

            currentMineral = maxMineral;
        }

    }

    void OnGUI()
    {

        GUI.color = Color.gray;
        GUI.Label(new Rect(Screen.width * 0.05f, Screen.height * 0.03f, Screen.width / 2, Screen.height / 2), "<size=14>" +  _current.ToString() + " / " + maxMineral.ToString() + "</size>");
    }

    IEnumerator auto()
    {
        while (true)
        {
            if (maxMineral > currentMineral)
            {
                currentMineral += 0.02f;
               
            }



            yield return new WaitForEndOfFrame();

            
            
        }
    }
    
    
}
