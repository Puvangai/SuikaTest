using UnityEngine;

public class AimLineController : MonoBehaviour
{

    [SerializeField] private Transform _fruitThrowTransform; // Fruit'in pozisyonunu temsil eden Transform referansı
    [SerializeField] private Transform _bottomTransform; // Çizginin alt kısmını temsil eden Transform referansı

    //Line Renderer componentini tutacak değişken
    private LineRenderer _lineRenderer;


    private float _topPos; //Line Renderer'ın üst pozisyonu
    private float _bottomPos; //Line Renderer'ın alt pozisyonu
    private float _x; //Line Renderer'ın bulunduğu x pozisyonu



    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>(); // Line Renderer componentini al atama yapıyoruz
    }

    private void Update()
    {
        _x = _fruitThrowTransform.position.x; // Fruit'in x pozisyonunu alıyoruz
        _topPos = _fruitThrowTransform.position.y; // Fruit'in üst pozisyonunu alıyoruz
        _bottomPos = _bottomTransform.position.y; //Fruit'in alt pozisyonunu alıyoruz


        _lineRenderer.SetPosition(0, new Vector3(_x, _topPos)); //Line Renderer'ın üst pozisyonunu ayarlıyoruz
        _lineRenderer.SetPosition(1, new Vector3(_x, _bottomPos)); //Line Renderer'ın alt pozisyonunu ayarlıyoruz
    }


    private void OnValidate() //Bu metod, Unity editöründe değişiklik yapıldığında çağrılır ve Line Renderer'ın pozisyonlarını günceller + olarak bu metod oyun çalışmazjen bile çalışır.
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _x = _fruitThrowTransform.position.x;
        _topPos = _fruitThrowTransform.position.y;
        _bottomPos = _bottomTransform.position.y;


        _lineRenderer.SetPosition(0, new Vector3(_x, _topPos));
        _lineRenderer.SetPosition(1, new Vector3(_x, _bottomPos));
    }
}
