using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameOverEventHandler(PlayerData stats);
    public delegate void GameTransitionHandler();
    public delegate void GameRetryEventHandler();

    public static event GameOverEventHandler GameOverEvent;
    public static event GameTransitionHandler FadeTransitionEvent;
    public static event GameRetryEventHandler GameRetryEvent;

    //для магазина
    public static Player Player => player;
    //для спавнера ну или других сущностей интересующихся активностью игры
    public static bool IsGame => isGame;

    [Header("ItemData")]
    [SerializeField] private ItemData itemData;
    [Header("Configs")]
    [SerializeField] private CircleRotatorConfig circleConfig;
    [SerializeField] private KnifeConfig knifeConfig;
    [SerializeField] private ChanseCallculatorConfig chanseCallculatorConfig;
    [Header("Entities")]
    [SerializeField] private Transform spawnKnifePoint;
    [SerializeField] private Transform spawnCircleRotaterPoint;
    [Header("Factoris")]
    [SerializeField] private KnifeFactory knifeFactory;
    [SerializeField] private ObstacleFactory obstacleFactory;
    [SerializeField] private GeneralFactory generalFactory;
    [Header("Animation")]
    [SerializeField] private FadeAnimationScreen transition;

    private CircleRotator circleRotator;
    private Circle circle;
    private ObstacleSpawner obstacleSpawner;
    private KnifeSpawner knifeSpawner;
    private static Player player;
    private VibrationEffect vibroEffector;

    private static bool isGame;

    private void Quit()
    {
        //сохарняем когда жмем EXIT в меню
        player.Save();
        Application.Quit();
    }

    private void OnEnable()
    {
        UIManager.StartEvent += StartGame;
        UIManager.EndEvent += Quit;
        Circle.WinEvent += LevelWin;
    }

    private void OnDisable()
    {
        UIManager.StartEvent -= StartGame;
        UIManager.EndEvent -= Quit;
        Circle.WinEvent -= LevelWin;
        vibroEffector.Unscribe();
    }

    private void Start()
    {
        vibroEffector = new VibrationEffect();
        vibroEffector.Initialize();
        //SpawnEntitis
        obstacleSpawner = new ObstacleSpawner(obstacleFactory, chanseCallculatorConfig);
        knifeSpawner = new KnifeSpawner(knifeFactory, spawnKnifePoint.position);
        player = new Player(knifeSpawner, knifeConfig);
        player.playerController.Activate();
        //subscribe 
        Knife.HitHandEvent += LevelLost;
        vibroEffector.Subscribe();
        transition.Subscribe();
        player.Subcribe();
        player.playerData.AddSomeApples(125);
    }

    //вызовется после клика на START в меню
    private void StartGame()
    {
        InitGame();
        //start game activity
        ChangeGameState();
    }

    public void InitGame()
    {
        //clear active entities
        if (circleRotator != null)
            Destroy(circleRotator.gameObject);
        obstacleSpawner?.Clear();
        knifeSpawner?.Clear();
        //init new entities
        circleRotator = generalFactory.Get();
        circle = circleRotator.GetComponentInChildren<Circle>();
        circleRotator.StartInitialize(circleConfig);
        knifeSpawner.CreateFirstInstance();
        obstacleSpawner.Spawn(Random.Range(0, 5), circle);
        //
        knifeSpawner.Subscribe();
    }

    public void LevelWin()
    {
        ChangeGameState();
        System.Action temp = () =>
        {
            Destroy(circleRotator.gameObject);
            StartGame();
            //обновить худ с ретрая
            GameRetryEvent?.Invoke();
        };
        StartCoroutine(WaitTimeAndShowAnimationAndCallback(2f, temp));
    }

    private void LevelLost()
    {
        ChangeGameState();
        System.Action temp = () => {
            Destroy(circleRotator.gameObject);
            GameOverEvent?.Invoke(player.playerData);
            player.ResetScore();
        };
        StartCoroutine(WaitTimeAndShowAnimationAndCallback(2f, temp));
    }

    private IEnumerator WaitTimeAndShowAnimationAndCallback(float time, System.Action callback)
    {
        yield return new WaitForSeconds(time / 2f);
        FadeTransitionEvent?.Invoke();
        yield return new WaitForSeconds(time / 2f);
        callback?.Invoke();
    }

    private void ChangeGameState()
    {
        isGame = !isGame;
    }
}
