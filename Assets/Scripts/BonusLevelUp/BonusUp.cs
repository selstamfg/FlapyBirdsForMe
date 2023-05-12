using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusUp : MonoBehaviour
{
    [SerializeField] private Button _claimBtn;

    private bool canClaimBonusUp;

    // Update is called once per frame
    void Update()
    {
        _claimBtn.interactable = canClaimBonusUp; 
    }

    public void ClaimBonusUp()
    {
        if (!canClaimBonusUp)
        {
            return;
        }
        // kod dlia polychenia nagrady
        canClaimBonusUp = false;
    }
}
