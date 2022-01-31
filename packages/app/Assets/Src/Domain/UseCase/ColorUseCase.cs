using UnityEngine;
using UniRx;

public class ColorUseCase {
  private ColorRepository _repository;
  private ColorTranslator _translator;
  private ColorModel _model;

  public void Save() {
    ColorEntity entity = _translator.TranslateModelToEntity(_model);
    _repository.Save(entity);
  }

  public void Reset() {
    ColorEntity entity = _repository.Load();
    ColorModel model = _translator.TranslateEntityToModel(entity);
    _model.UpdateModel(model);
  }

  public void SetRed(float red) {
    Color color = _model.DisplayColor.Value;
    color.r = red;
    _model.SetDisplayColor(color);
  }

  public void SetGreen(float green) {
    Color color = _model.DisplayColor.Value;
    color.g = green;
    _model.SetDisplayColor(color);
  }

  public void SetBlue(float blue) {
    Color color = _model.DisplayColor.Value;
    color.b = blue;
    _model.SetDisplayColor(color);
  }

  // 監視用に Model の Disp;ayColor を返す
  public IReadOnlyReactiveProperty<Color> GetDisplayColor() {
    return _model.DisplayColor;
  }

  public ColorUseCase() {
    _repository = new ColorRepository();
    _translator = new ColorTranslator();
    ColorEntity entity = _repository.Load();
    _model = _translator.TranslateEntityToModel(entity);
  }
}
