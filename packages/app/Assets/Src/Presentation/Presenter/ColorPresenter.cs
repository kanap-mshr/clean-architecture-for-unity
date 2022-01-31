using UnityEngine;
using UniRx;

public class ColorPresenter : MonoBehaviour {
  [SerializeField]
  private ColorView _view;

  private ColorUseCase _useCase;

  private void onSaveButtonClicked() {
    _useCase.Save();
  }

  // イベントの紐付け
  private void SetEvents() {
    _view.SaveButton.OnClickAsObservable()
      .Subscribe(_ => onSaveButtonClicked())
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
