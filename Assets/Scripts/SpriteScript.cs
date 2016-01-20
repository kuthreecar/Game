using UnityEngine;
using System.Collections;

public class SpriteScript : MonoBehaviour {

    public void Show() {
        renderer.enabled = true;
    }
    public void Hide() {
        renderer.enabled = false;
    }
    void HideChildren()
    {
         Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
         foreach ( Renderer lRenderer in lChildRenderers)
         {
              lRenderer.enabled=false;
         }
    }
    void ShowChildren()
    {
         Renderer[] lChildRenderers=gameObject.GetComponentsInChildren<Renderer>();
         foreach ( Renderer lRenderer in lChildRenderers)
         {
              lRenderer.enabled=true;
         }
    }


}