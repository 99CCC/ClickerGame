using Godot;
using System;
using System.Collections.Generic;
using System.IO;


    public partial class ItemFactory
    {
        private string csvPath = "./Features/BuildingPanel/Building.csv";
        //private List<string> itemList;
        private Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    public static object CreateItem(string className)
        {
            Type type = Type.GetType(className);

            if (type != null && typeof(Item).IsAssignableFrom(type))
            {
                var instance = (Item)Activator.CreateInstance(type);

                return instance;
            }
            throw new ArgumentException($"Class {className} not found or does not inherit Item");

        }

        public List<string> ItemListConstructor()
        {
            StreamReader reader = null;
            List<string> itemList = new List<string>();

            reader = new StreamReader(File.OpenRead(csvPath));

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                foreach (var item in values)
                {
                    itemList.Add(item);
                }
            }
        return itemList;

        }

        public Dictionary<string, Item> ItemConstructor(List<string> itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                var itemName = itemList[i];
                var item = (Item)(CreateItem(itemName));
                itemDictionary[item.Name] = item;

            }
            return itemDictionary;

        }
}