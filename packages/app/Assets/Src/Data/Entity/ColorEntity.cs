public class ColorEntity {
  // rgb の r 成分
  public float R {
    get;
    private set;
  }

  // rgb の g 成分
  public float G {
    get;
    private set;
  }

  // rgb の B 成分
  public float B {
    get;
    private set;
  }

  public ColorEntity(float r, float g, float b) {
    R = r;
    G = g;
    B = b;
  }
}
