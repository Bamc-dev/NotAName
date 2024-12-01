using UnityEngine;

public class ButtonStele : MonoBehaviour, IInteractable, IGlowing
{
    public bool isGood = false;
    public bool isEnabled = false;
    public bool solved = false;
    private Material material;
    public bool CanInteract(PickupController item)
    {
        if(!isEnabled && !solved)
        {
            return true;
        }
        return false;
    }
    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    public void GlowingMethod()
    {
        material.color = Color.black;
        Color emissionColor = Color.green * 3;

        // material.EnableKeyword("_EMISSION");
        material.SetFloat("_EmissiveExposureWeight",0);
    }

    public void UnGlowingMethod()
    {
        material.color = Color.black;
        Color emissionColor = Color.green * -10;

        // material.EnableKeyword("_EMISSION");
        material.SetFloat("_EmissiveExposureWeight", 1);
        this.isEnabled = false;
    }
    public void Interact()
    {
        GlowingMethod();
        this.isEnabled = true;
    }


}
