using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrash : MonoBehaviour
{
    [SerializeField] private GameObject crashUI;
    [SerializeField] private LevelEndHandler levelEndHandler;
    [SerializeField] private GameObject explosion;

    [SerializeField] private AudioSource boom;

    public bool canDrive;
    private CarVal carVal;
    private Transform tr;

    private void Start()
    {
        crashUI = GameObject.Find("CrashUI");
        levelEndHandler = GameObject.Find("LevelEndHandler").GetComponent<LevelEndHandler>();

        carVal = GetComponent<CarVal>();
        tr = GetComponent<Transform>();

        canDrive = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("ObjCar"))
        {
            canDrive = false;
            float rand1 = Random.Range(-carVal.speed, carVal.speed * 2);
            float rand2 = Random.Range(-carVal.speed, carVal.speed * 2);

            float rand3 = Random.Range(rand1, rand2);
            for (float i = -carVal.speed; i <= rand3; rand3 -= 1.5f) {
                transform.Rotate(tr.rotation.x, tr.rotation.y, rand3 * 2 * (2 * Time.deltaTime), Space.Self);
            }

            GetComponent<Rigidbody2D>().AddForce(new Vector2(rand1, rand2), ForceMode2D.Force);

            //if(levelEndHandler.levelDone == false)
            //{
                ContactPoint2D contact = other.contacts[0];
                Vector2 pos = contact.point;
                Quaternion rot = transform.rotation;

                Instantiate(explosion, pos, rot);

                StartCoroutine(Crashed());
            //}
        }
    }

    private IEnumerator Crashed()
    {
        boom.Play();
        levelEndHandler.levelDone = true;
        yield return new WaitForSecondsRealtime(1.5f);
        crashUI.GetComponent<RectTransform>().localPosition = new Vector2(0, 0);
    }
}
