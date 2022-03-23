using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelection : MonoBehaviour
{
    public GameObject playerAPrefab;
    public GameObject playerBPrefab;
    public GameObject playerCPrefab;
    public GameObject displayAbilities;
    public GameObject currentPlayer;

    public Text mainAbilitiesTxt;
    public Text boostAbilitiesTxt;

    private char playerLtr;
    private bool is_Visible = false;

    public void Awake()
    {
        currentPlayer = Instantiate(playerAPrefab);
        playerLtr = 'A';
    }


    public void Btn1Clicked()
    {
        Vector3 position = currentPlayer.transform.position;
        position.y += 2;
        Destroy(currentPlayer);
        currentPlayer = Instantiate(playerAPrefab);
        currentPlayer.transform.position = position;
        playerLtr = 'A';
        LoadAbilityInfo();
    }

    public void Btn2Clicked()
    {
        Vector3 position = currentPlayer.transform.position;
        Destroy(currentPlayer);
        currentPlayer = Instantiate(playerBPrefab);
        currentPlayer.transform.position = position;
        playerLtr = 'B';
        LoadAbilityInfo();
    }

    public void Btn3Clicked()
    {
        Vector3 position = currentPlayer.transform.position;
        position.y += 5;
        Destroy(currentPlayer);
        currentPlayer = Instantiate(playerCPrefab);
        currentPlayer.transform.position = position;
        playerLtr = 'C';
        LoadAbilityInfo();
    }

    public void DisplayAbilities()
    {
        if (!is_Visible)
        {
            LoadAbilityInfo();
            displayAbilities.SetActive(true);
            is_Visible = true;
        }

        else
        {
            displayAbilities.SetActive(false);
            is_Visible = false;
        }
    }

    public void LoadAbilityInfo()
    {
        if (playerLtr == 'A')
        {
            mainAbilitiesTxt.text = "Sword Fighting";
            boostAbilitiesTxt.text = "Instant Damage - Instantly damge enemies to half health. Can only be used once and then must load up again to be used";
        }
        else if (playerLtr == 'B')
        {
            mainAbilitiesTxt.text = "Freeze Spell - Slow down enemies with every hit. Enough hits and enemies will freeze to death";
            boostAbilitiesTxt.text = "Stun - Temporarily stun oponents for 5 seconds. Must reload in order to be used again";
        }
        else
        {
            mainAbilitiesTxt.text = "Fireball - Shoot fireballs at oponents";
            boostAbilitiesTxt.text = "Heal - Intantly heal yourself to full health. Must reload in order to be used again";
        }
    }
}
