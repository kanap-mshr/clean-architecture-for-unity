using UnityEngine;

public class ColorDataStore
{
  // Entity
  private ColorEntity _entity;

  // ストレージからロード
  public ColorEntity Load() {
    if (_entity != null) {
      return _entity;
    }
    var r = PlayerPrefs.HasKey("r") ? PlayerPrefs.GeFloat("r") : 1f;
    var g = PlayerPrefs.HasKey("g") ? PlayerPrefs.GeFloat("g") : 1f;
    var b = PlayerPrefs.HasKey("b") ? PlayerPrefs.GeFloat("b") : 1f;
    _entity = new ColorEntity(r, g, b);
    return _entity;
  }

  // ストレージに保存
  public void Save(ColorEntity entity) {
    _entity = entity;
    PlayerPrefs.SeFloat("r", entity.R);
    PlayerPrefs.SeFloat("g", entity.G);
    PlayerPrefs.SeFloat("b", entity.B);
    PlayerPrefs.Save();
  }
}
