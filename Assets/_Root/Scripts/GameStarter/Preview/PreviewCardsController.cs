
using System;
using Unity.VisualScripting;
using UnityEngine;

internal sealed class PreviewCardsController : IUpdate
{
    public EventHandler BeforeStart = new EventHandler();
    public EventHandler OnComplete = new EventHandler();
    public EventHandler OnStartOpenPreviewCards = new EventHandler();
    public EventHandler OnStartClosePreviewCards = new EventHandler();

    private Action _onComplete;
    private float _timer;
    private bool _enabled;
    private CardsInfo _cardsInfo;
    private float _targetYAngle;
    private float _speed;
    private ZonePosition _fullScreenZonePosition;
    private UpdateController _updateController;

    public PreviewCardsController(UpdateController updateController, CardsInfo cardsInfo)
    {
        _timer = 0f;
        _enabled = false;
        _cardsInfo = cardsInfo;
        _targetYAngle = 0f;
        _speed = 0.7f;
        _fullScreenZonePosition = null;
        _updateController = updateController;
    }

    public void OnScreenDataChanged(ScreenData screenData)
    {
        _fullScreenZonePosition = screenData.ZonePositions.FullScreen;
    }

    public void Start()
    {
        BeforeStart.Handle();
        StartWait();
    }

    private void StartWait()
    {
        new Timer(_updateController, 1f, OnEndStartWait);
    }

    public void OnEndStartWait()
    {
        Start(180f, CardsPreviewStarted);
        OnStartOpenPreviewCards.Handle();
    }

    private void CardsPreviewStarted()
    {
        new Timer(_updateController, 2f, CardsPreviewEnded);
    }

    private void CardsPreviewEnded()
    {
        Start(0f, CardsPreviewCompleted);
        OnStartClosePreviewCards.Handle();
    }

    private void CardsPreviewCompleted()
    {
        _enabled = false;
        OnComplete.Handle();
    }

    public void Start(float targetYAngle, Action onComplete)
    {
        _timer = 0;
        _enabled = true;
        _targetYAngle = targetYAngle;
        _onComplete = onComplete;
    }

    public void Update(float deltaTime)
    {
        if (!_enabled) return;

        float screenWidth = Mathf.Abs(_fullScreenZonePosition.MinPosition.x - _fullScreenZonePosition.MaxPosition.x);
        float screenHieght = Mathf.Abs(_fullScreenZonePosition.MinPosition.y - _fullScreenZonePosition.MaxPosition.y);

        float speedX = screenWidth / _speed;
        float speedY = screenHieght / _speed;
        float speed = Mathf.Max(speedX, speedY);

        _timer += deltaTime * speed;

        bool allCardsComplete = true;

        foreach (Card card in _cardsInfo.Cards)
        {
            if (card != null)
            {
                float x = card.TargetPosition.x;
                float y = card.TargetPosition.y;
                float lineY = x + (screenWidth/2f) + screenHieght - _timer;
                if (y >= lineY)
                {
                    card.TargetYAngle = _targetYAngle;
                }
                if (card.CurrentYAngle != _targetYAngle) allCardsComplete = false;
            }
        }

        if (allCardsComplete)
        {
            _enabled = false;
            _onComplete.Invoke();
        }
    }
}
