using Bounce.DataLayer;
using Bounce.ViewLayer;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class HUDView : BaseView
{
    private HUDMediator mediator;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private List<Image> hearts = new List<Image>();
    Color fullAlphaWhite = new Color(1f, 1f, 1f, 1f);
    Color partialAlphaWhite = new Color(1f, 1f, 1f, 0.5f);


    private void Start()
    {
        Initialize();

    }


    private void Initialize()
    {
        mediator = new HUDMediator(this);
    }

    public void UpdateHealth(int value)
    {
        if (value >= 0)
        {
            int numHearts = hearts.Count;

            for (int i = 0; i < numHearts; i++)
            {
                hearts[i].color = i < value ? fullAlphaWhite : partialAlphaWhite;
            }
        }
    }
    public void UpdateLevel(int value)
    {

        levelText.text = "LEVEL :" + value.ToString();
    }
    public void UpdateCoins(int value)
    {

        coinText.text = value.ToString();

    }
}
