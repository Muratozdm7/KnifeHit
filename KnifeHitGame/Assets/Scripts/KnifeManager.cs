using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();
    [SerializeField] private List<GameObject> knifeIconList = new List<GameObject>();

    [SerializeField] private GameObject knifePrefabs;
    [SerializeField] private GameObject knifeIconPrefabs;

    [SerializeField] private Vector2 knifeIconPosition;

    [SerializeField] private int knifeCount;

    private int knifeIndex = 0;




    private void Start()
    {
        CreateKnifes();
        CreateKnifeIcons();
    }


    private void CreateKnifes()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnife = Instantiate(knifePrefabs, transform.position, Quaternion.identity);
            newKnife.SetActive(false);
            knifeList.Add(newKnife);
        }

        knifeList[0].SetActive(true);
    }


    private void CreateKnifeIcons()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnifeIcon = Instantiate(knifeIconPrefabs, knifeIconPosition, knifeIconPrefabs.transform.rotation);
            knifeIconPosition.y += 0.3f;
            knifeIconList.Add(newKnifeIcon);
        }
    }


    public void SetDisableKnifeIcon()
    {
        knifeIconList[(knifeIconList.Count - 1) - knifeIndex].SetActive(false);
    }


    public void SetActiveKnife()
    {
        if (knifeIndex < knifeCount - 1)
        {
            knifeIndex++;
            knifeList[knifeIndex].SetActive(true);
        }
    }
}
