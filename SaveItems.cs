using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
public class dotween : MonoBehaviour
{

   
    public ItemDatabase itemDB;
    


   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveButton();
        }else if (Input.GetKeyDown(KeyCode.L))
        {
            LoadButton();
        }else if (Input.GetKeyDown(KeyCode.N))
        {
            itemDB.itemList.Add(new ItemEntry() { name = "emptyName", value = Random.Range(0, 11), craftingMaterial =(CraftingMaterial)Random.Range(0,5) }) ;

        }

    }
    public void LoadButton()
    {
        FileStream stream = new FileStream(Application.dataPath + "/item_dataBase.xml", FileMode.Open);
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        itemDB = (ItemDatabase)serializer.Deserialize(stream);
        stream.Close();
    }
    public void SaveButton()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/item_dataBase.xml", FileMode.OpenOrCreate);
        serializer.Serialize(stream, itemDB);
        stream.Close();

    }
    


    [System.Serializable]
    public class ItemEntry
    {
        public string name;
        public int value;
        public CraftingMaterial craftingMaterial;
        public Vector3 position = new Vector3(1, 2, 3);
        public Color color = Color.white;
        
    }
    [System.Serializable] 
    public class ItemDatabase
    {
        [XmlArray("Equipment")]
        public List<ItemEntry> itemList;
    }
    public enum CraftingMaterial
    {
        Wood,
        Metal,
        Copper,
        Steel,
        Obsidian
    }
}
