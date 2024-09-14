using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;


public partial class BuildingPanel : Control
{

    //public Button _purchaseClickPower;
    //public Button _purchaseAutoClicker;

    private string prefixBuildingPath = "ScrollContainer/VBoxContainerParent/";
    private string csvPath = "Features/BuildingPanel/Building.csv";

    public Dictionary<string, object[]> buildingDict;
    private List<string> buildingList;
    private string buildingName;

    //TODO: Fix the linking between items and their buttons plus 
    public override void _Ready()
    {
        StreamReader reader = null;
        
            reader = new StreamReader(File.OpenRead(csvPath));

            buildingList = new List<string>();

            while (!reader.EndOfStream){
                var line = reader.ReadLine();
                var values = line.Split(';');
                foreach(var item in values){
                    buildingList.Add(item);
                }
            }

            buildingDict = new Dictionary<string, object[]>();

            for(int i = 0;i<buildingList.Count;i++){
                buildingName = buildingList[i];
           
                Button button = new Button();
                button = GetNode<Button>($"{prefixBuildingPath}{buildingName}/Button");           

                Item item = GameManager.Instance.itemDictionary[buildingName];
                
                button.Pressed += () => PurchaseUpgrade(item);

                Label level = new Label();
                level = GetNode<Label>($"{prefixBuildingPath}{buildingName}/Button/VBoxContainer/HBoxContainer2/_levelVar");
                

                Label cost = new Label();
                cost = GetNode<Label>($"{prefixBuildingPath}{buildingName}/Button/VBoxContainer/HBoxContainer2/_costVar");
                cost.Text = GameManager.Instance.itemDictionary[buildingName].Cost.ToString();

                object[] buildingArray = {button, level, cost};
                buildingDict.Add(buildingName, buildingArray);
            }
    }


    public void PurchaseUpgrade(Item item)
    {
        Item retrievedItem = GameManager.Instance.itemDictionary[item.Name];

        if (GameManager.Instance._counter >= retrievedItem.Cost)
        {
            object[] array = buildingDict[retrievedItem.Name];
           
            Label _levelLabel = (Label)(array[1]);
            Label _costLabel = (Label)(array[2]);

            GameManager.Instance._counterContainer.RemoveCash(retrievedItem.Cost);
            GameManager.Instance.itemDictionary[retrievedItem.Name].Upgrade(retrievedItem);
            GD.Print("From BuildingPanel.PurchaseUpgrade", retrievedItem.Power);

            _levelLabel.Text = retrievedItem.Level.ToString();
            _costLabel.Text = retrievedItem.Cost.ToString();

        }
        else
        {
            GD.Print("not enough clicks");
        }
    }
}


