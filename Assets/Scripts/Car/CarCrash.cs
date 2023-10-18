using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{
    [SerializeField] private GameObject crashUI;
    [SerializeField] private GameObject successUI;
    [SerializeField] private LevelEndHandler levelEndHandler;
    [SerializeField] private GameObject explosion;

    [SerializeField] private CrossingBox crossingBox;

    [SerializeField] private AudioSource boom;


    public bool canDrive;
    private CarVal carVal;
    private Transform tr;

    private void Start()
    {
        crashUI = GameObject.Find("CrashUI");
        successUI = GameObject.Find("SuccessUI");
        levelEndHandler = GameObject.Find("LevelEndHandler").GetComponent<LevelEndHandler>();

        if (levelEndHandler.adaCrossing) crossingBox = GameObject.Find("Dumbass Box").GetComponent<CrossingBox>();

        carVal = GetComponent<CarVal>();
        tr = GetComponent<Transform>();

        canDrive = true;
    }

    private void Update()
    {
        if(levelEndHandler.levelDone == true)
        {
            canDrive = false;
        }

        if(levelEndHandler.arrived == levelEndHandler.needed)
        {
            canDrive = false;
        }

        if (levelEndHandler.adaCrossing)
        {
            if(crossingBox.allSafe == true)
            {
                canDrive = true;
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        canDrive = false;

        GetComponent<CarTurn>().turning = false;

        float rand1 = Random.Range(-carVal.speed, carVal.speed * 2);
        float rand2 = Random.Range(-carVal.speed, carVal.speed * 2);

        float rand3 = Random.Range(rand1, rand2);
        for (float i = -carVal.speed; i <= rand3; rand3 -= 2) {
            transform.Rotate(tr.rotation.x, tr.rotation.y, rand3 * 2 * (2 * Time.deltaTime), Space.Self);
        }

        GetComponent<Rigidbody2D>().AddForce(new Vector2(rand1, rand2), ForceMode2D.Force);

        ContactPoint2D contact = other.contacts[0];
        Vector2 pos = contact.point;
        Quaternion rot = transform.rotation;

        if(successUI.transform.position != Vector3.zero)
        {
            Instantiate(explosion, pos, rot);
            boom.Play();
            StartCoroutine(Crashed());
        }
    }

    private IEnumerator Crashed()
    {
        levelEndHandler.levelDone = true;
        yield return new WaitForSecondsRealtime(1f);
        crashUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }
}
