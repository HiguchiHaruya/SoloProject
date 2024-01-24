//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ImageManager : MonoBehaviour
//{
//    Image _thisImage;
//    Color _color;
//    void Start()
//    {
//        _thisImage = GetComponent<Image>();
//        _color = _thisImage.color;
//        _thisImage.enabled = false;
//    }


//    public void DestroyImage(int _combo)
//    {
//        int _max = 0;
//        int _border = 15;
//        if (_combo > _max)
//        {
//            StartCoroutine(Fadeout());
//            _thisImage.enabled = true;
//            _max += _border;
//        }

//    }
//    IEnumerator Fadeout()
//    {
//        float _fadeoutTime = 2.0f;
//        float currentTime = 0.0f;
//        while (currentTime < _fadeoutTime)
//        {
//            float alpha = Mathf.Lerp(_color.a, 0f, currentTime / _fadeoutTime);
//            _thisImage.color = new Color(_color.r, _color.g, _color.b, alpha);
//            currentTime += _fadeoutTime;
//        }
//        yield return null;
//        _thisImage.enabled = false;
//    }
//    void Update()
//    {

//    }
//}
