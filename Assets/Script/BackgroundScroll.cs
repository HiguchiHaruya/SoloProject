//using UnityEngine;

//public class BackgroundScroll : MonoBehaviour
//{
//    [SerializeField] float scrollSpeed = 30f;
//    GameManager _gm;
//    Renderer rend;

//    void Start()
//    {
//        rend = GetComponent<Renderer>();
//        _gm = gameObject.GetComponent<GameManager>();
//    }

//    void Update()
//    {
//        float offsetY = Time.time * scrollSpeed;
//        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offsetY));
//    }
//}
