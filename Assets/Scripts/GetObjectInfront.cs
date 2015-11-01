using UnityEngine;
using System.Collections;

public class GetObjectInfront : MonoBehaviour {
    private string nameInfront = "";
    private Texture crosshairImage;

    // Use this for initialization
    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        crosshairImage = Resources.Load("crosshair") as Texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit))
            {
                nameInfront = hit.collider.gameObject.name;
                System.Random rnd = new System.Random();
                hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color(rnd.Next(0, 100)/100f, rnd.Next(0, 100) / 100f, rnd.Next(0, 100) / 100f);
            }
        }
        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), Time.frameCount.ToString() + "\n" + nameInfront);
        float xMin = (Camera.main.rect.width * Screen.width / 2) - (crosshairImage.width / 2);
        float yMin = (Camera.main.rect.height * Screen.height / 2) - (crosshairImage.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
    }
}
