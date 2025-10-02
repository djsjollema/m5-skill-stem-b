using UnityEngine;

public class Parabola : MonoBehaviour
{
    [SerializeField] Point point;

    Vector2 minScreen, maxScreen;
    int NumberOfPoints = 100;


    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float dx = (maxScreen.x - minScreen.x)/NumberOfPoints;
        
        for(int i = 0; i <= NumberOfPoints; i++)
        {
            Point pointCopy = Instantiate(point);
            pointCopy.x = minScreen.x + i*dx ;
            pointCopy.y = 0;
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
