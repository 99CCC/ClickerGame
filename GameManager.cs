using Godot;
using System;
using System.Reflection.Emit;

public partial class GameManager : Node
{
    public static GameManager Instance;
    private  Timer _timer;
    public int totalCPS { get; set; }

    public  int _counter = 0;
    
    
    public ClickObject _clickObject;
    public UpgradePanel _upgradePanel;

    public Clicker _clicker;
    public AutoClicker _autoClicker;


    public override void _Ready()
    {
        totalCPS = 0;

        //Getting Node because it has a scene, 
        //then the scene allows you to access the methods within the scenes nodes
        _clickObject = GetNode<ClickObject>("/root/Main/ClickObject");
        _upgradePanel = GetNode<UpgradePanel>("/root/Main/UpgradePanel");

        //Newing this class, because its a CS script and theres no Node to be gotten
        _clicker = new Clicker();
        _autoClicker = new AutoClicker();

        //Need to instansiate the GameManager, its set at singleton by AutoLoading (in Godot Editor ->
        //Project Settings/Globals/Autoload add the Script that has the class you need to be instansiated
        //Then the Global Variable Box doesnt to anything for C#, and we therefore must write the code below!
        //Also remember to add it as an attribute up above
        Instance = this;

        var timer = GetNode<Timer>("/root/Main/Timer");
        timer.Timeout += TimedOut;
    }

    public void AddClicks()
    {
        _counter += _clicker.Power;
        _clickObject._counterLabel.SetText(_counter.ToString());
    }

    public void removeClicks(int cost)
    {
        _counter -= cost;
        _clickObject._counterLabel.SetText(_counter.ToString());
    }

    private void TimedOut()
    {
        GD.Print("test");
        _counter += totalCPS;
        GD.Print(totalCPS);
        _clickObject._counterLabel.SetText(_counter.ToString());
    }

}
