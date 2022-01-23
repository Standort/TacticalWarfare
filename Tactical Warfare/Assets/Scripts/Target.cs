using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer renderer;
    float red, blue, green;
    Color newColor;

    void Start()
    {
        renderer = GetComponent<Renderer>();

       red=   renderer.material.color.r;
        blue = renderer.material.color.b;
        green = renderer.material.color.g;
         newColor = new Color(red, green, blue, 1f);

    }

    private void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        renderer.material.color = newColor;
    }
    private void Update()
    {
        
    }
}