using UnityEngine;

public class NetworkInitializer : MonoBehaviour
{
    [field: SerializeField]
    public DomainContainerSO DomainContainer { get; private set; }

    [field: SerializeField]
    public OneSignalManager OneSignalManager { get; private set; }

    [field: SerializeField]
    public UniWebViewController UniWebViewController { get; private set; }
}
