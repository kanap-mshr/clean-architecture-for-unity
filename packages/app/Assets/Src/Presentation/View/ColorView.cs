using UnityEngine;
using UnityEngine.UI;

public class ColorView : MonoBehaviour {
  // 色表示
  [SerializeField]
  private Image _colorImage;

  [SerializeField]
  private Slider _redSlider;
  public Slider RedSlider {
    get { return _redSlider; }
  }

  [SerializeField]
  private Slider _greenSlider;
  public Slider GreenSlider {
    get { return _greenSlider; }
  }

  [SerializeField]
  private Slider _blueSlider;
  public Slider BlueSlider {
    get { return _blueSlider; }
  }

  [SerializeField]
  private Button _saveButton;
  public Button SaveButton {
    get { return _saveButton; }
  }

  [SerializeField]
  private Button _resetButton;
  public Button ResetButton {
    get { return _resetButton; }
  }

  public void SetColor(Color color) {
    _colorImage.color = color;
    _redSlider.value = color.r;
    _greenSlider.value = color.g;
    _blueSlider.value = color.b;
  }
}
