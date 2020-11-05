using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, ISelectHandler {

    private AudioSource source;

    private void Start() {
        source = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        source.Play();
    }

    public void OnSelect(BaseEventData eventData) {
        source.Play();
    }
}
