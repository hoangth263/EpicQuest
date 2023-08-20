using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public TextMeshProUGUI placeText;
    public string startTitle;
     
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main.GetComponent<CameraMovement>();
        StartCoroutine(placeNameCoStart(startTitle));
    }

    // Update is called once per frame



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            if(needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
    private IEnumerator placeNameCoStart(string startTitle)
    {
        text.SetActive(true);
        placeText.text = startTitle;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
