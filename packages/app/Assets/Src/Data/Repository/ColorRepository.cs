public class ColorRepository {
  // DataStore
  private ColorDataStore _dataStore;

  // コンストラクタ
  public ColorRepository() {
    _dataStore = new ColorDataStore();
  }

  // ロード
  public ColorEntity Load() {
    return _dataStore.Load();
  }

  // 保存
  public void Save(ColorEntity entity) {
    _dataStore.Save(entity);
  }
}
