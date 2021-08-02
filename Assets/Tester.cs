using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class Tester : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DoIt());
    }
    Color[] pix;
    public Image image;
    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            //       Debug.Log(fileData.Length);
            string msg = "";
            foreach (byte bit in fileData)
            {
                msg += bit + " ";
            }
            //      Debug.Log(msg);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //this will auto-resize the texture dimensions.
        }
        return tex;
    }

    public IEnumerator DoIt()
    {
        string beginlink = "F:\\NeuralNetworkTutorial\\NeuralNetworkTutorial\\Backpropagation_NeuralNetworkTutorial\\mnistasjpg\\trainingSet\\trainingSet\\";
       //StartCoroutine(iterator());

        //XOR
        // 0 0 0    => 0
        // 0 0 1    => 1
        // 0 1 0    => 1
        // 0 1 1    => 0
        // 1 0 0    => 1
        // 1 0 1    => 0
        // 1 1 0    => 0
        // 1 1 1    => 1

     NeuralNetwork net = new NeuralNetwork(new int[] { 784, 25, 25, 10 }); 

        for (int i = 0; i <= 2000; i++)
        {
            int folder = Random.Range(0, 10); //0,1,2,3,4,5,6,7,8,9
            int jpgNumber = Random.Range(0, 3000);
            string link = beginlink + folder + "\\img_(" + jpgNumber + ").jpg";

            Texture2D tex = LoadPNG(link); 
            pix = tex.GetPixels(); //28x28=784
            List<float> gpix = new List<float>();
            foreach(Color gray in pix)
            gpix.Add(gray.grayscale);


            Texture2D destTex = new Texture2D(28, 28);
            destTex.SetPixels(pix, 0);
            image.sprite = Sprite.Create(destTex, new Rect(0, 0, 28, 28), new Vector2());
            
            net.FeedForward(gpix.ToArray());

            float[] lista = new float[10];
            lista[folder] = 1;
            net.BackProp(lista);
            yield return null;
        }
    //    Serializer.Save("NeuralNet",net);

        //test
      //  NeuralNetwork net = Serializer.Load<NeuralNetwork>("NeuralNet");
        for (int i = 0; i <= 10; i++)
        {
            int folder = Random.Range(0, 10);
            int jpgNumber = Random.Range(0, 3000);
            string link = beginlink + folder + "\\img_(" + jpgNumber + ").jpg";

            Texture2D tex = LoadPNG(link);
            pix = tex.GetPixels(); //28x28=784
            List<float> gpix = new List<float>();
            foreach(Color gray in pix)
            gpix.Add(gray.grayscale);

            Debug.Log("Liczba: "+folder);

             foreach(float fl in net.FeedForward(gpix.ToArray()).ToList())
             Debug.Log( fl );
             yield return null;
        }
      

/*
 //XOR Training

         NeuralNetwork net = new NeuralNetwork(new int[] { 2, 16, 16, 10 }); 
        //Itterate 5000 times and train each possible output
        //5000*8 = 40000 traning operations
        for (int i = 0; i < 5000; i++)
        {
            net.FeedForward(new float[] { 0, 0 });
            net.BackProp(new float[] { 0,0,0,0,0,0,0,0,0,0 });

            net.FeedForward(new float[] { 0, 1 });
            net.BackProp(new float[] { 1,0,0,0,0,0,0,0,0,0 });

            net.FeedForward(new float[] { 1, 0 });
            net.BackProp(new float[] { 1,0,0,0,0,0,0,0,0,0 });

            net.FeedForward(new float[] { 1, 1 });
            net.BackProp(new float[] { 1,1,0,0,0,0,0,0,0,0 });
        }

        Serializer.Save("NeuralNet",net);
      //NeuralNetwork net = Serializer.Load<NeuralNetwork>("NeuralNet");
        //output to see if the network has learnt
        //WHICH IT HAS!!!!!
        Debug.Log(net.FeedForward(new float[] { 0, 0 })[0]);
        Debug.Log(net.FeedForward(new float[] { 0, 1 })[0]);
        Debug.Log(net.FeedForward(new float[] { 1, 0 })[0]);
        Debug.Log(net.FeedForward(new float[] { 1, 1 })[0]);
        Debug.Log(net.FeedForward(new float[] { 1, 1 })[1]);

*/
        yield return null;
    }

    public void OnGUI()
    {
        //Texture2D tex = LoadPNG("F:\\NeuralNetworkTutorial\\NeuralNetworkTutorial\\Backpropagation_NeuralNetworkTutorial\\mnistasjpg\\trainingSet\\trainingSet\\0\\img_1.jpg");
        //Color[] pix = tex.GetPixels(); //28x28
        //Texture2D destTex = new Texture2D(28, 28);
        //destTex.SetPixels(pix, 0);
        //GUI.DrawTexture(new Rect(new Vector2(0,0),new Vector2(280,280)), destTex, ScaleMode.ScaleToFit);
    }
    void Update()
    {

    }

    public IEnumerator iterator()
    {
        string beginlink = "F:\\NeuralNetworkTutorial\\NeuralNetworkTutorial\\Backpropagation_NeuralNetworkTutorial\\mnistasjpg\\trainingSet\\trainingSet\\";
        for (int i = 0; i <= 1; i++)
        {
            int folder = Random.Range(0, 10); //0,1,2,3,4,5,6,7,8,9
            int jpgNumber = Random.Range(0, 3000);
            string link = beginlink + folder + "\\img_(" + jpgNumber + ").jpg";
            Texture2D tex = LoadPNG(link);
            Color[] pix = tex.GetPixels(); //28x28=784

       /*     foreach(Color pixel in pix)
            {
                Debug.Log(pixel.grayscale);
            }
        */
            Texture2D destTex = new Texture2D(28, 28);
            destTex.SetPixels(pix, 0);
            image.sprite = Sprite.Create(destTex, new Rect(0, 0, 28, 28), new Vector2());
            yield return null;

        }
    }
}
