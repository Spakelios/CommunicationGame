using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showNote : MonoBehaviour
{
  public GameObject note;
  public GameObject geef;
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      note.SetActive(true);
      geef.SetActive(false);
    }
  }
}
