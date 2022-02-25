using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaBar : MonoBehaviour
{
    [SerializeField] private Image _manaBarSprite;
    public void UpdateManaBar(float maxMana, float currentMana)
    {
        _manaBarSprite.fillAmount = currentMana / maxMana;
        
    }
}