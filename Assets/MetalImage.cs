using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetalImage : MonoBehaviour {

	public RawImage inputimage;
	public RawImage sceneimage;
	public GameObject Cube;

	void Start () 
	{
		Doit();
	}
	public void Doit()
	{

    /*  if (Input.GetMouseButtonUp(1))
        {
            Color[] color = (GetComponent<RawImage>().texture as Texture2D).GetPixels();
            Cube.GetComponent<Renderer>().text
        }
	*/
		//sceneimage.sprite = new Sprite();
		//sceneimage.sprite.rect.Set(0,0,image.width, image.height);

		Color[] pixels = (inputimage.texture as Texture2D ).GetPixels();
		print(pixels.Length);
		//sceneimage.texture = new Texture2D(inputimage.texture.width, inputimage.texture.height);
        (sceneimage.texture as Texture2D).SetPixels(pixels, 0);


	}
	 
	public void OnGUI()
	{
		//Color32[] pixels = image.GetPixels32();
		//Texture2D destTex = new Texture2D(image.width,image.height);
        //destTex.SetPixels32(pixels);
		//GUI.DrawTexture(new Rect(new Vector2(0,0),new Vector2(image.width,image.height)), image, ScaleMode.ScaleToFit);
	}
	
}
