
using System;
using UnityEngine;

namespace StopWatch
{
    internal sealed class StopWatchController : IUpdate
    {
        private const float OVERLOAD_TIME = 3600f; // 60 min
        private const string OVERLOAD_TEXT = "59:59.999";
        //private const string TIME_FORMAT = "mm\\:ss\\.fff";
        private const string TIME_FORMAT = "mm\\:ss";
        private const string PREFAB_PATH = "StopWatchCanvas";

        private GameObject _prefab;

        private StopWatchModel _model;
        private StopWatchView _view;
        private bool _isShow;
        public StopWatchController()
        {
            _prefab = Resources.Load<GameObject>(PREFAB_PATH);
            _model = new StopWatchModel();
            _view = null;
            _isShow = false;
        }

        public void Start()
        {
            _model.IsEnable = true;
        }

        public void Stop()
        {
            _model.IsEnable = false;
        }

        public void Reset()
        {
            _model.Time = 0;
        }

        public void Update(float deltaTime)
        {
            if (!_model.IsEnable) return;
            _model.Time += deltaTime;
            if (_isShow) UpdateView();
        }

        private void UpdateView()
        {
            if (_model.Time < OVERLOAD_TIME)
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(_model.Time);
                _view.StopWatchText.text = timeSpan.ToString(TIME_FORMAT);
                _view.StopWatchText.color = _view.NormalColor;
            }
            else
            {
                _view.StopWatchText.text = OVERLOAD_TEXT;
                _view.StopWatchText.color = _view.OverloadColor;
            }
        }

        public void Show()
        {
            if (_isShow) return;
            
            GameObject go = GameObject.Instantiate(_prefab);
            _view = go.GetComponent<StopWatchView>();
            _isShow = true;
            UpdateView();
        }

        public void Hide()
        {
            if (_isShow) return;

            GameObject.Destroy(_view.gameObject);
            _view = null;
            _isShow = false;
        }
    }
}
