using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Loading : MonoBehaviour
{
    private Image image;
    public AnimationCurve curve;
    public float fadeTime = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        image = GetComponent<Image>();
        StartCoroutine(FadeIn());
    }

    //Fades in at start
    IEnumerator FadeIn()
    {
        float a;
        float t = 1;
        while (t > 0)
        {
            a = curve.Evaluate(t);
            t -= Time.deltaTime/fadeTime;
            image.color = new Color(0, 0, 0, a);
            
            //Wait for next frame
            yield return 0;
        }
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    
    //Fades out and loads scene
    IEnumerator FadeOut(string scene)
    {
        float a;
        float t = 0;
        while (t < 1)
        {
            a = curve.Evaluate(t);
            t += Time.deltaTime/fadeTime;
            image.color = new Color(0, 0, 0, a);
            
            //Wait for next frame
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
