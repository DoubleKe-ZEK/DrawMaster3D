using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Points values")]
    public int totalPoints;
    public int pointsCounter;

    public GameObject faultyObject;
    public GameObject realObject;
    public GameObject hintButton;
    public Animator realObjectAnimator;
    public List<SpriteRenderer> incrementers;

    [Header("Particle effects")]
    public GameObject particleM;
    public GameObject particleL;
    public GameObject particleR;
    public GameObject levelCompletePanel;

    [Header("Camera Positions")]
    public Transform camTargetPos;
    public Transform camCharacterFocus;

    public bool animation;
    public Camera cam;
    public bool objectMove;

    [Header("About Main Character")]
    public Animator characterAnimation;
    public int characterAnimationNumber;
    public int characterRotationValue;

    [HideInInspector]public bool djCharactersMove;
    bool cameraMove;

    public bool objectHide;
    public bool delay;
    public bool playFirstAnim;
   

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        faultyObject.SetActive(true);
        realObject.SetActive(false);
        for (int i = 0; i < incrementers.Count; i++)
        {
            incrementers[i].enabled = false;
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(pointsCounter >= totalPoints)
            {
                if(!animation)
                {
                    djCharactersMove = true;
                    faultyObject.SetActive(false);
                    realObject.SetActive(true);
                    hintButton.SetActive(false);
                    if(realObjectAnimator)
                    {
                        realObjectAnimator.SetBool("PlayAnimation", true);
                        //test();
                        //Debug.Log("test=====================");

                    }
                    StartCoroutine(BlastEffect());
                }
                else
                {
                    if (cam)
                    {
                        djCharactersMove = true;
                        faultyObject.SetActive(false);
                        realObject.SetActive(true);
                        hintButton.SetActive(false);
                        StartCoroutine(MoveTheObject());
                        if(!delay)
                        {
                            StartCoroutine(CameraPositionShiftDelay());
                        }
                        else
                        {
                            if (playFirstAnim)
                            {
                                characterAnimation.SetInteger("CharacterAnimate", 1); 
                                soundmanager.instance.playmysound(soundmanager.instance.objectForm);
                            }
                            cam.orthographic = false;
                            cam.transform.position = camTargetPos.position;
                        }
                        
                    }
                }
            }
        }

        if(cameraMove && camCharacterFocus)
        {
            if(Vector3.Distance(cam.transform.position, camCharacterFocus.position) > 0.1)
            {
                cam.transform.position = Vector3.MoveTowards(cam.transform.position, camCharacterFocus.position, 25 * Time.deltaTime);
            }
        }
    }

    public void PointsCounterIncrementer()
    {
        pointsCounter++;
    }

    public void ClearPointsCounter()
    {
        pointsCounter = 0;
    }

    public void WrongPath()
    {
        pointsCounter -= 10;
    }
    //private void FixedUpdate()
    //{
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        soundmanager.instance.playmysound(soundmanager.instance.objectForm);
    //    }
    //}
    IEnumerator BlastEffect()
    {
        yield return new WaitForSeconds(0.3f);
        particleM.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        particleL.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        particleR.SetActive(true);
        yield return new WaitForSeconds(2f);
        levelCompletePanel.SetActive(true);
        soundmanager.instance.playmysound(soundmanager.instance.levelcomplete);
    }

    IEnumerator MoveTheObject()
    {
        yield return new WaitForSeconds(0.5f);
        objectMove = true;
        yield return new WaitForSeconds(1.1f);
        StartCoroutine(BlastEffect());

    }

    public void CharacterAnimate()
    {
        StartCoroutine(CharactorAnimationIE());
       
    }


    IEnumerator CharactorAnimationIE()
    {
        yield return new WaitForSeconds(1.35f);
        if(realObject && !objectHide)
        {
            realObject.SetActive(false);
        }
        if(characterAnimation)
        {
            characterAnimation.SetInteger("CharacterAnimate", characterAnimationNumber);
            characterAnimation.gameObject.transform.rotation = Quaternion.Euler(0, characterRotationValue, 0);
        }
        cameraMove = true;
    }

    IEnumerator CameraPositionShiftDelay()
    {
        yield return new WaitForSeconds(1);
        cam.orthographic = false;        
        cam.transform.position = camTargetPos.position;
       
    }

    bool once;
    private void LateUpdate()
    {
        if (!Camera.main.orthographic && !once)
        {
            GameObject bg = GameObject.Find("Background");
            bg.transform.parent = Camera.main.transform;
            bg.transform.localScale = new Vector3(3, 3, 5);
            bg.transform.localPosition = new Vector3(0, 0, 39.3f);
            once = true;
        }
    }
}
