using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractPopUp : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private Transform _player;
    [SerializeField] private Camera _camera;
    
    [FormerlySerializedAs("_offset")]
    [Header("PopUp Position")]
    [SerializeField] private Vector3 _offsetCenter = new Vector3(25,80,0);
    [SerializeField] private float _hoverClamp = 10;
    [SerializeField] private float _hoverSpeed = 1;
    private Vector3 _offsetHover;
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        _offsetHover = _offsetCenter;
        StartCoroutine(Hover());
    }

    private void Update()
    {
        GetPosition();
    }

    private void GetPosition()
    {
        _rect.position = _camera.WorldToScreenPoint(_player.position) + _offsetHover;
    }

    private IEnumerator Hover()
    {
        float hoverDistance;
        while (gameObject.activeSelf)
        {
            _offsetHover.y += (_hoverSpeed * Time.deltaTime);
            yield return null;
            hoverDistance = Vector3.Distance(_offsetCenter, _offsetHover);
            _hoverSpeed *= (hoverDistance < _hoverClamp) ? 1 : -1;
        }
        
    }

    public void ChangePlayer(Transform player)
    {
        _player = player;
    }

    private void OnDisable()
    {
        StopCoroutine(Hover());
    }
}
