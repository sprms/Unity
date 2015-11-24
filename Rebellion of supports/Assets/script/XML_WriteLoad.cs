using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player
{
    public int daler;
}

public sealed class PlayerIO
{


    public static void Write(List<Player> player, string filePath) 
    {
        XmlDocument document = new XmlDocument();
        XmlElement PlayerList = document.CreateElement("ItemList");
        document.AppendChild(PlayerList);

        foreach(Player state in player)
        {
            PlayerList.SetAttribute("daler", state.daler.ToString());
        }

        document.Save(filePath);
    }

    public static List<Player> Read(string filePath)
    {
        XmlDocument Docuemnt = new XmlDocument();
        Docuemnt.Load(filePath);
       

        List<Player> stateList = new List<Player>();

        
        foreach (XmlElement item in Docuemnt.GetElementsByTagName("ItemList"))
        {
            Player player = new Player();

            player.daler = System.Convert.ToInt32(item.GetAttribute("daler"));

            stateList.Add(player);
        }


        return stateList;
    }
}

public class XML_WriteLoad : MonoBehaviour {


    public Text tt;

    public void test()
    {
        

        List < Player > list = PlayerIO.Read(Application.dataPath + "/Output/Player_daler.xml");

        for (int i = 0; i < list.Count; i++)
        {
            Player item = list[i];

            tt.text = item.daler.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        /*
        List<Player> daler = new List<Player>();

        Player player = new Player();

        player.daler = 10;

        daler.Add(player);

        PlayerIO.Write(daler, Application.dataPath + "/Output/Player_daler.xml");
        */

        StartCoroutine("network");
        
        List<Player> list = PlayerIO.Read(Application.dataPath + "/Output/Player_daler.xml");

        for (int i = 0; i < list.Count; i++)
        {
            Player item = list[i];

            Debug.Log(item.daler);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void ProcessBooks(XmlNodeList nodes)
    {
        Player player;

        foreach (XmlNode node in nodes)
        {
            player = new Player();
            player.daler = System.Convert.ToInt16(node.Attributes.GetNamedItem("daler").InnerText);


            

            Debug.Log(player.daler);
        }
    }

    //Finds book object in application and send the Book as parameter.


    IEnumerator network()
    {
        //Load XML data from a URL
        string url = "http://107.161.26.101/sky/Player_daler.xml";
        WWW www = new WWW(url);

        //Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
        yield return www;
        if (www.error == null)
        {
            //Sucessfully loaded the XML
            Debug.Log("Loaded following XML " + www.data);

            //Create a new XML document out of the loaded data
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(www.text.Trim());

            //Point to the book nodes and process them
            ProcessBooks(xmlDoc.SelectNodes("books/book"));
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }

    }
}
