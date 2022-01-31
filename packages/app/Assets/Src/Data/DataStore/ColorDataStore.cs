using UnityEngine;

public class ColorDataStore {
  // Entity
  private ColorEntity _entity;

  // ストレージからロード
  public ColorEntity Load() {
    if (_entity != null) {
      return _entity;
    }
    float r = PlayerPrefs.HasKey("r") ? PlayerPrefs.GetFloat("r") : 1f;
    float g = PlayerPrefs.HasKey("g") ? PlayerPrefs.GetFloat("g") : 1f;
    float b = PlayerPrefs.HasKey("b") ? PlayerPrefs.GetFloat("b") : 1f;
    _entity = new ColorEntity(r, g, b);
    return _entity;
  }

  // ストレージに保存
  public void Save(ColorEntity entity) {
    _entity = entity;
    PlayerPrefs.SetFloat("r", entity.R);
    PlayerPrefs.SetFloat("g", entity.G);
    PlayerPrefs.SetFloat("b", entity.B);
    PlayerPrefs.Save();
  }
}
