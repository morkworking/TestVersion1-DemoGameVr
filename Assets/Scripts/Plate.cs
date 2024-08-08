using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    public TMP_Text ro1;
    public Image img;
    public Renderer rend;
    public Toggle Checkbottom;
    public Toggle Checkbottom1;
    public Toggle Checkbottom2;
    public Toggle[] Alltoggles;
    public AudioClip DingSound;
    public AudioClip Endtest;
    public GameObject WrongSe1;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ro1.text = "0.00g";
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Beaker")
        {
            if (Alltoggles[3].GetComponent<Toggle>().isOn == true)
            {
                Debug.Log("IN");
                float currentFill = rend.material.GetFloat("_Fill");
                currentFill = currentFill * 733.4f;
                ro1.text = currentFill.ToString("F0") + ("g");
                img.color = Color.black;
                //StartCoroutine(wait());
                Alltoggles[4].GetComponent<Toggle>().isOn = true;
                audioSource.PlayOneShot(DingSound);
                audioSource.PlayOneShot(Endtest);
            }
            else
            {
                StartCoroutine(ro5sec());
            }
        }

        if (collision.gameObject.tag == "Beaker1")
        {
            if (Alltoggles[1].GetComponent<Toggle>().isOn == true)
            {
                Debug.Log("IN");
                float currentFill = rend.material.GetFloat("_Fill");
                currentFill = currentFill * 100f;
                ro1.text = currentFill.ToString("F0") + ("cm3");
                img.color = Color.black;
                Alltoggles[2].GetComponent<Toggle>().isOn = true;
                audioSource.PlayOneShot(DingSound);
            }
            else
            {
                StartCoroutine(ro5sec());
            }
        }

        if (collision.gameObject.tag == "Metal")
        {
            Debug.Log("IN");
            ro1.text = "78g";
            img.color = Color.black;
            Alltoggles[0].GetComponent<Toggle>().isOn = true;
            audioSource.PlayOneShot(DingSound);
        }
    }
    IEnumerator ro5sec()
    {
        WrongSe1.SetActive(true);
        yield return new WaitForSeconds(6f);
        WrongSe1.SetActive(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Beaker")
        {
            Debug.Log("OUT");
            ro1.text = "0.0g";
            img.color = Color.black;
            //StartCoroutine(wait());
        }

        if (collision.gameObject.tag == "Beaker1")
        {
            Debug.Log("OUT");
            ro1.text = "0.0g";
            img.color = Color.black;
            //StartCoroutine(wait());
        }

        if (collision.gameObject.tag == "Metal")
        {
            Debug.Log("OUT");
            ro1.text = "0.0g";
            img.color = Color.black;
            //StartCoroutine(wait());
        }
    }


    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        ro1.text = "0.0g";
    }

    private void WeightCheck()
    {

        float currentFill = rend.material.GetFloat("_Fill");
        rend.material.SetFloat("_Fill", currentFill);

    }

}