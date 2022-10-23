using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showballs : MonoBehaviour
{
 public GameObject balls;
 public GameObject boobs;

 private void OnTriggerEnter(Collider other)
 {
  balls.SetActive(false);
  boobs.SetActive(true);
 }
}