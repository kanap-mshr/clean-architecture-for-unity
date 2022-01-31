using UnityEngine;

public class ColorTranslator {
  // Entity から Model に変換
  public ColorModel TranslateEntityToModel(ColorEntity entity) {
    return new ColorModel(new Color(entity.R, entity.G, entity.B));
  }

  public ColorEntity TranslateModelToEntity(ColorModel model) {
    return new ColorEntity(
          model.DisplayColor.Value.r,
          model.DisplayColor.Value.g,
          model.DisplayColor.Value.b
          );
  }
}
