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
                
                //Item itemParam = GameManager.Instance.Item.getInstanceOfItem(buildingName);

                Button button = new Button();
                button = GetNode<Button>($"{prefixBuildingPath}{buildingName}/Button");
                button.Pressed += () => PurchaseUpgrade(GameManager.Instance._clicker);

                Label level = new Label();
                level = GetNode<Label>($"{prefixBuildingPath}{buildingName}/Button/HBoxContainer2/_levelVar");

                Label cost = new Label();
                cost = GetNode<Label>($"{prefixBuildingPath}{buildingName}/Button/HBoxContainer2/_costVar");
                
                object[] buildingArray = {button, level, cost};
                buildingDict.Add(buildingName, buildingArray);
            }
    }


    public void PurchaseUpgrade(Item item)
    {
        if (GameManager.Instance._counter >= item.Cost)
        {
            object[] array = buildingDict[item.Name];
           
            //Possible issue?
            Label _levelLabel = (Label)(array[1]);
            Label _costLabel = (Label)(array[2]);

            item.Upgrade();
            GameManager.Instance._counterContainer.RemoveCash(item.Cost);

            _levelLabel.Text = item.Level.ToString();
            _costLabel.Text = item.Cost.ToString();

        }
        else
        {
            GD.Print("not enough clicks");
        }
    }
}


/*
          //Old CLicker setup
        _purchaseClickPower = GetNode<Button>($"ScrollContainer/VBoxContainerParent/ClickPower/Button");
        _purchaseClickPower.Text = $"{GameManager.Instance._clicker.Name} Upgrade\nCost: {GameManager.Instance._clicker.Cost}\nLevel: {GameManager.Instance._clicker.Level}";
        _purchaseClickPower.Pressed += () => PurchaseUpgrade(GameManager.Instance._clicker, _purchaseClickPower);

        //Auto Clicker SetUp
        _purchaseAutoClicker = GetNode<Button>("ScrollContainer/VBoxContainer/_purchaseAutoClicker");
        _purchaseAutoClicker.Text = $"{GameManager.Instance._autoClicker.Name} Upgrade\nCost: {GameManager.Instance._autoClicker.Cost}\nLevel: {GameManager.Instance._autoClicker.Level}";
        _purchaseAutoClicker.Pressed += () => PurchaseUpgrade(GameManager.Instance._autoClicker, _purchaseAutoClicker);
*/

