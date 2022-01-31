using UnityEngine;
using UniRx;

public class ColorPresenter : MonoBehaviour {
  [SerializeField]
  private ColorView _view;

  private ColorUseCase _useCase;

  private void onRedSliderValueChanged(float value) {
    Debug.Log("onRedSliderValueChanged: " + value);
    _useCase.SetRed(value);
  }

  private void onGreenSliderValueChanged(float value) {
    Debug.Log("onGreenSliderValueChanged: " + value);
    _useCase.SetGreen(value);
  }

  private void onBlueSliderValueChanged(float value) {
    Debug.Log("onBlueSliderValueChanged: " + value);
    _useCase.SetBlue(value);
  }

  private void onSaveButtonClicked() {
    Debug.Log("onSaveButtonClicked");
    _useCase.Save();
  }

  private void onResetButtonClicked() {
    Debug.Log("onResetButtonClicked");
    _useCase.Reset();
  }

  // イベントの紐付け
  private void SetEvents() {
    _view.RedSlider.OnValueChangedAsObservable()
      .Subscribe(onRedSliderValueChanged)
      .AddTo(this);

    _view.GreenSlider.OnValueChangedAsObservable()
      .Subscribe(onGreenSliderValueChanged)
      .AddTo(this);

    _view.BlueSlider.OnValueChangedAsObservable()
      .Subscribe(onBlueSliderValueChanged)
      .AddTo(this);

    _view.SaveButton.OnClickAsObservable()
      .Subscribe(_ => onSaveButtonClicked())
      .AddTo(this);

    _view.ResetButton.OnClickAsObservable()
      .Subscribe(_ => onResetButtonClicked())
      .AddTo(this);
  }

  // 値の変更の監視
  private void Bind() {
    _useCase.GetDisplayColor()
      .Subscribe(_view.SetColor)
      .AddTo(this);
  }

  void Start() {
    _useCase = new ColorUseCase();
    Bind();
    SetEvents();
  }
}
