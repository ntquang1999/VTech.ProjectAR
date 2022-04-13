using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField]
    GameObject floor;

    [SerializeField]
    GameObject stackPrefab;

    [SerializeField]
    GameObject dropPrefab;

    [SerializeField]
    GameObject sparkPrefab;

    [SerializeField]
    Transform towerGameNest;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Camera camera;

    [SerializeField] bool isLocal = true;
    [SerializeField] bool isAR = true;


    KeyCode playKey;

    GameObject currentStack;
    GameObject lastStack;

    Stack currentStackClass;

    bool playing = false;
    int sideChooser = 1;
    int score = 0;
    bool gameEnded = false;
    float perfectThreshold = 0.3f;


    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (isLocal) playKey = KeyCode.Space;
        else playKey = KeyCode.A;
    }

    void Start()
    {
        lastStack = floor;
    }

    private void Update()
    {
        if (isAR)
            UpdateARMode();
        else
            UpdateNormalMode();
    }


    void UpdateNormalMode()
    {
        scoreText.text = score + "";

        if(!gameEnded)
        {


            if (!playing)
            {
                currentStack = Instantiate(stackPrefab, towerGameNest);
                currentStackClass = currentStack.GetComponent<Stack>();
                currentStack.GetComponent<Renderer>().material.SetTextureScale("_MainTex", lastStack.GetComponent<Renderer>().material.GetTextureScale("_MainTex"));
                currentStackClass.setSide(sideChooser);
                float height = lastStack.transform.position.y + ((lastStack.transform.localScale.y + currentStack.transform.localScale.y) / 2);
                currentStackClass.setDemension(lastStack.transform.position.x, height, lastStack.transform.position.z, lastStack.transform.localScale.x, lastStack.transform.localScale.z);
                playing = true;
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Input.GetKeyUp(playKey) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                currentStackClass.setState(false);
                var posCurrent = currentStack.transform.position;
                var posLast = lastStack.transform.position;
                var scaleCurrent = currentStack.transform.localScale;
                var scaleLast = lastStack.transform.localScale;
                float offset;
                if (sideChooser == 1)
                {
                    offset = -(posCurrent.x - posLast.x);
                    if (Mathf.Abs(offset) > scaleCurrent.x)
                    {
                        StartCoroutine(LoadSceneAfterDelay(2));
                        gameEnded = true;
                        int direction = currentStackClass.directionInt;
                        currentStack.GetComponent<Rigidbody>().isKinematic = false;
                        currentStack.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(direction * 300, -100, 0),
                            new Vector3(posCurrent.x + direction*(scaleCurrent.x - 0.1f), posCurrent.y, posCurrent.z));
                    }
                    else
                    {
                        score++;
                        if (Mathf.Abs(offset) <= perfectThreshold)
                        {
                            offset = 0;
                            posCurrent.x = posLast.x;
                            score++;
                            showSpark(posCurrent, scaleCurrent);
                        }
                        scaleCurrent = new Vector3(scaleCurrent.x - Mathf.Abs(offset), scaleCurrent.y, scaleCurrent.z);
                        posCurrent = new Vector3(posCurrent.x + (offset / 2), posCurrent.y, posCurrent.z);
                        float side = -offset / Mathf.Abs(offset);
                        if (offset != 0)
                        {
                            var drop = Instantiate(dropPrefab, towerGameNest);
                            drop.transform.localScale = new Vector3(Mathf.Abs(offset), scaleCurrent.y, scaleCurrent.z);
                            drop.transform.position = new Vector3(posCurrent.x + (side * (scaleCurrent.x + drop.transform.localScale.x) / 2), posCurrent.y, posCurrent.z);
                            
                            var currentMat = currentStack.GetComponent<Renderer>().material;
                            var dropMat = drop.GetComponent<Renderer>().material;

                            currentMat.SetTextureScale("_MainTex", new Vector2(scaleCurrent.x / 10, scaleCurrent.z / 10));
                            dropMat.SetTextureScale("_MainTex", new Vector2(drop.transform.localScale.x / 10, drop.transform.localScale.z / 10));

                            if (side > 0)
                            {
                                currentMat.SetTextureOffset("_MainTex", new Vector2(drop.transform.localScale.x / 10, currentMat.GetTextureOffset("_MainTex").y));
                            }
                            else
                            {
                                dropMat.SetTextureOffset("_MainTex", new Vector2(scaleCurrent.x / 10, dropMat.GetTextureOffset("_MainTex").y));
                            }
                        }
                    }
                    

                }
                else
                {
                    offset = posCurrent.z - posLast.z;
                    if (Mathf.Abs(offset) > scaleCurrent.z)
                    {
                        StartCoroutine(LoadSceneAfterDelay(2));
                        gameEnded = true;
                        int direction = currentStackClass.directionInt;
                        currentStack.GetComponent<Rigidbody>().isKinematic = false;
                        currentStack.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, -100, direction * 300),
                            new Vector3(posCurrent.x, posCurrent.y, posCurrent.z + direction*(scaleCurrent.z - 0.1f)));
                    }
                    else
                    {
                        score++;
                        if (Mathf.Abs(offset) <= perfectThreshold)
                        {
                            offset = 0;
                            posCurrent.z = posLast.z;
                            score++;
                            //currentStack.GetComponent<Renderer>().material.color = Color.white;
                            showSpark(posCurrent, scaleCurrent);
                        }
                        scaleCurrent = new Vector3(scaleCurrent.x, scaleCurrent.y, scaleCurrent.z - Mathf.Abs(offset));
                        posCurrent = new Vector3(posCurrent.x, posCurrent.y, posCurrent.z - (offset / 2));
                        float side = offset / Mathf.Abs(offset);
                        if (offset != 0)
                        {
                            var drop = Instantiate(dropPrefab, towerGameNest);
                            drop.GetComponent<Renderer>().material.color = currentStack.GetComponent<Renderer>().material.color;
                            drop.transform.localScale = new Vector3(scaleCurrent.x, scaleCurrent.y, Mathf.Abs(offset));
                            drop.transform.position = new Vector3(posCurrent.x, posCurrent.y, posCurrent.z + (side * (scaleCurrent.z + drop.transform.localScale.z) / 2));
                            
                            var currentMat = currentStack.GetComponent<Renderer>().material;
                            var dropMat = drop.GetComponent<Renderer>().material;

                            currentMat.SetTextureScale("_MainTex", new Vector2(scaleCurrent.x / 10, scaleCurrent.z / 10));
                            dropMat.SetTextureScale("_MainTex", new Vector2(drop.transform.localScale.x / 10, drop.transform.localScale.z / 10));

                            if (side > 0)
                            {
                                currentMat.SetTextureOffset("_MainTex", new Vector2(currentMat.GetTextureOffset("_MainTex").x, drop.transform.localScale.z / 10));
                            }
                            else
                            {
                                dropMat.SetTextureOffset("_MainTex", new Vector2(dropMat.GetTextureOffset("_MainTex").x, scaleCurrent.z / 10));
                            }
                        }
                    }
                    
                }
                if(!gameEnded)
                    camera.GetComponent<CameraController>().targetPosition = new Vector3(camera.transform.position.x, posCurrent.y + 43f, camera.transform.position.z);

                currentStack.transform.position = posCurrent;
                currentStack.transform.localScale = scaleCurrent;

                lastStack = currentStack;

                playing = false;
                sideChooser = -sideChooser;
            }
        }
         
    }

    void UpdateARMode()
    {
        //scoreText.text = score + "";

        if (!gameEnded)
        {


            if (!playing)
            {
                currentStack = Instantiate(stackPrefab, towerGameNest);
                currentStackClass = currentStack.GetComponent<Stack>();
                currentStack.GetComponent<Renderer>().material.SetTextureScale("_MainTex", lastStack.GetComponent<Renderer>().material.GetTextureScale("_MainTex"));
                currentStackClass.setSide(sideChooser);
                float height = lastStack.transform.position.y + ((lastStack.transform.localScale.y + currentStack.transform.localScale.y) / 2);
                currentStackClass.setDemension(lastStack.transform.position.x, height, lastStack.transform.position.z, lastStack.transform.localScale.x, lastStack.transform.localScale.z);
                playing = true;
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Input.GetKeyUp(playKey) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                currentStackClass.setState(false);
                var posCurrent = currentStack.transform.position;
                var posLast = lastStack.transform.position;
                var scaleCurrent = currentStack.transform.localScale;
                var scaleLast = lastStack.transform.localScale;
                float offset;
                if (sideChooser == 1)
                {
                    offset = -(posCurrent.x - posLast.x);
                    if (Mathf.Abs(offset) > scaleCurrent.x)
                    {
                        StartCoroutine(LoadSceneAfterDelay(2));
                        gameEnded = true;
                        int direction = currentStackClass.directionInt;
                        currentStack.GetComponent<Rigidbody>().isKinematic = false;
                        currentStack.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(direction * 300, -100, 0),
                            new Vector3(posCurrent.x + direction * (scaleCurrent.x - 0.1f), posCurrent.y, posCurrent.z));
                    }
                    else
                    {
                        score++;
                        if (Mathf.Abs(offset) <= perfectThreshold)
                        {
                            offset = 0;
                            posCurrent.x = posLast.x;
                            score++;
                            showSpark(posCurrent, scaleCurrent);
                        }
                        scaleCurrent = new Vector3(scaleCurrent.x - Mathf.Abs(offset), scaleCurrent.y, scaleCurrent.z);
                        posCurrent = new Vector3(posCurrent.x + (offset / 2), posCurrent.y, posCurrent.z);
                        float side = -offset / Mathf.Abs(offset);
                        if (offset != 0)
                        {
                            var drop = Instantiate(dropPrefab, towerGameNest);
                            drop.transform.localScale = new Vector3(Mathf.Abs(offset), scaleCurrent.y, scaleCurrent.z);
                            drop.transform.position = new Vector3(posCurrent.x + (side * (scaleCurrent.x + drop.transform.localScale.x) / 2), posCurrent.y, posCurrent.z);

                            var currentMat = currentStack.GetComponent<Renderer>().material;
                            var dropMat = drop.GetComponent<Renderer>().material;

                            currentMat.SetTextureScale("_MainTex", new Vector2(scaleCurrent.x / 10, scaleCurrent.z / 10));
                            dropMat.SetTextureScale("_MainTex", new Vector2(drop.transform.localScale.x / 10, drop.transform.localScale.z / 10));

                            if (side > 0)
                            {
                                currentMat.SetTextureOffset("_MainTex", new Vector2(drop.transform.localScale.x / 10, currentMat.GetTextureOffset("_MainTex").y));
                            }
                            else
                            {
                                dropMat.SetTextureOffset("_MainTex", new Vector2(scaleCurrent.x / 10, dropMat.GetTextureOffset("_MainTex").y));
                            }
                        }
                    }


                }
                else
                {
                    offset = posCurrent.z - posLast.z;
                    if (Mathf.Abs(offset) > scaleCurrent.z)
                    {
                        StartCoroutine(LoadSceneAfterDelay(2));
                        gameEnded = true;
                        int direction = currentStackClass.directionInt;
                        currentStack.GetComponent<Rigidbody>().isKinematic = false;
                        currentStack.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(0, -100, direction * 300),
                            new Vector3(posCurrent.x, posCurrent.y, posCurrent.z + direction * (scaleCurrent.z - 0.1f)));
                    }
                    else
                    {
                        score++;
                        if (Mathf.Abs(offset) <= perfectThreshold)
                        {
                            offset = 0;
                            posCurrent.z = posLast.z;
                            score++;
                            //currentStack.GetComponent<Renderer>().material.color = Color.white;
                            showSpark(posCurrent, scaleCurrent);
                        }
                        scaleCurrent = new Vector3(scaleCurrent.x, scaleCurrent.y, scaleCurrent.z - Mathf.Abs(offset));
                        posCurrent = new Vector3(posCurrent.x, posCurrent.y, posCurrent.z - (offset / 2));
                        float side = offset / Mathf.Abs(offset);
                        if (offset != 0)
                        {
                            var drop = Instantiate(dropPrefab, towerGameNest);
                            drop.GetComponent<Renderer>().material.color = currentStack.GetComponent<Renderer>().material.color;
                            drop.transform.localScale = new Vector3(scaleCurrent.x, scaleCurrent.y, Mathf.Abs(offset));
                            drop.transform.position = new Vector3(posCurrent.x, posCurrent.y, posCurrent.z + (side * (scaleCurrent.z + drop.transform.localScale.z) / 2));

                            var currentMat = currentStack.GetComponent<Renderer>().material;
                            var dropMat = drop.GetComponent<Renderer>().material;

                            currentMat.SetTextureScale("_MainTex", new Vector2(scaleCurrent.x / 10, scaleCurrent.z / 10));
                            dropMat.SetTextureScale("_MainTex", new Vector2(drop.transform.localScale.x / 10, drop.transform.localScale.z / 10));

                            if (side > 0)
                            {
                                currentMat.SetTextureOffset("_MainTex", new Vector2(currentMat.GetTextureOffset("_MainTex").x, drop.transform.localScale.z / 10));
                            }
                            else
                            {
                                dropMat.SetTextureOffset("_MainTex", new Vector2(dropMat.GetTextureOffset("_MainTex").x, scaleCurrent.z / 10));
                            }
                        }
                    }

                }
                //if (!gameEnded)
                    //camera.GetComponent<CameraController>().targetPosition = new Vector3(camera.transform.position.x, posCurrent.y + 43f, camera.transform.position.z);

                currentStack.transform.position = posCurrent;
                currentStack.transform.localScale = scaleCurrent;

                lastStack = currentStack;

                playing = false;
                sideChooser = -sideChooser;
            }
        }

    }

    void showSpark(Vector3 pos, Vector3 scale)
    {
        var spark = Instantiate(sparkPrefab, towerGameNest);
        
        spark.transform.position = new Vector3(pos.x, pos.y-0.5f, pos.z);

        spark.transform.localScale = new Vector3(scale.x/10 + 0.1f, scale.y / 10 + 0.1f, scale.z / 10 + 0.1f);
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
