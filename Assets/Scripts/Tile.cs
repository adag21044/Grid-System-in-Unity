using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private string _baseColorHex = "#FFFFFF"; // Default to white
    [SerializeField] private string _offsetColorHex = "#6EBC54"; // Example hex code
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    private Color _baseColor;
    private Color _offsetColor;

    private void Awake()
    {
        // Parse hexadecimal color codes
        ColorUtility.TryParseHtmlString(_baseColorHex, out _baseColor);
        ColorUtility.TryParseHtmlString(_offsetColorHex, out _offsetColor);
    }

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }


}
