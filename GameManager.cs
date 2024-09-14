using Godot;
using System.Collections.Generic;
using System.IO;

public partial class GameManager : Node
{
    public static GameManager Instance;

    public CounterContainer _counterContainer;
    public CpsContainer _cpsContainer;
    public CashButton _cashButton;


    private  Timer _timer;
    public int totalCPS = 0;
    public  int _counter = 0;

    public Dictionary<string, Item> itemDictionary;
    private List<string> itemList;


    public override void _Ready()
    {

        _counterContainer = GetNode<CounterContainer>("/root/Main/CounterLabel/TextureRect/VBoxContainer/CounterContainer");
        _cpsContainer = GetNode<CpsContainer>("/root/Main/CounterLabel/TextureRect/VBoxContainer/CpsContainer");
        _cashButton = GetNode<CashButton>("/root/Main/CashButton/Area2D/Sprite2D");

        ItemFactory itemFactory = new ItemFactory();
        itemList = itemFactory.ItemListConstructor();
        itemDictionary = itemFactory.ItemConstructor(itemList);


        Instance = this;

        var timer = GetNode<Timer>("/root/Main/Timer");
        timer.Timeout += TimedOut;
    }

    private void TimedOut()
    {
        _counterContainer.AddCashCPStoCounter(this.totalCPS);
    }


    
}
