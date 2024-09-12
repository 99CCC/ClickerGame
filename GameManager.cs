using Godot;

public partial class GameManager : Node
{
    public static GameManager Instance;
    private  Timer _timer;
    public int totalCPS { get; set; }

    public  int _counter = 0;
    
    public CounterContainer _counterContainer;
    public CpsContainer _cpsContainer;

    public VBoxContainer _buildingPanel;

    public Clicker _clicker;
    public CashButton _cashButton;
    public AutoClicker _autoClicker;
    

    public override void _Ready()
    {
        totalCPS = 0;

        _counterContainer = GetNode<CounterContainer>("/root/Main/CounterLabel/TextureRect/VBoxContainer/CounterContainer");
        _cpsContainer = GetNode<CpsContainer>("/root/Main/CounterLabel/TextureRect/VBoxContainer/CpsContainer");
        _buildingPanel = GetNode<VBoxContainer>("/root/Main/BuildingPanel/ScrollContainer/VBoxContainer");
        _cashButton = GetNode<CashButton>("/root/Main/CashButton/Area2D/Sprite2D");

        _clicker = new Clicker();
        _autoClicker = new AutoClicker();

        Instance = this;

        var timer = GetNode<Timer>("/root/Main/Timer");
        timer.Timeout += TimedOut;

    }

    private void TimedOut()
    {
        _counter += totalCPS;
        _counterContainer.AddCashCPStoCounter();
    }

}
