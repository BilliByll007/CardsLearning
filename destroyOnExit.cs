using UnityEngine;
using Vuforia;

public class OnDistro : MonoBehaviour
{
    /*public void OnBecameInvisible() {
        Destroy(this.gameObject);
    }*/

    public ObserverBehaviour imageTarget;

    void Start() {
        if (imageTarget == null)
            imageTarget = GetComponentInParent<ObserverBehaviour>();

        if (imageTarget != null) {
            imageTarget.OnTargetStatusChanged += OnStatusChanged;
            Actualizar(imageTarget.TargetStatus);
        } else {
            Debug.LogError("No se encuentra el ImageTarget");
        }
    }

    void OnStatusChanged(
        ObserverBehaviour behaviour,
        TargetStatus status) {
        Actualizar(status);
    }

    void Actualizar(TargetStatus status) {
        bool detectado = status.Status == Status.TRACKED;

        foreach (Renderer r in GetComponentsInChildren<Renderer>(true))
            r.enabled = detectado;

        Debug.Log("Estado ImageTarget: " + status.Status);
    }

    void OnDestroy() {
        if (imageTarget != null)
            imageTarget.OnTargetStatusChanged -= OnStatusChanged;
    }
}
