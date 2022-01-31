using UnityEngine;
using UniRx;

public class ColorModel {
  private ReactiveProperty<Color> _displayColoer;

  // 表示色
  public IReadOnlyReactiveProperty<Color> DisplayColor {
    get { return _displayColoer; }
  }

  // 色を設定
  public void SetDisplayColor(Color displayColoer) {
    _displayColoer.Value = displayColoer;
  }

  // Modelを更新
  public void UpdateModel(ColorModel model) {
    SetDisplayColor(model.DisplayColor.Value);
  }

  // コンストラクタ
  public ColorModel(Color color) {
    _displayColoer = new ReactiveProperty<Color>(color);
  }
}
