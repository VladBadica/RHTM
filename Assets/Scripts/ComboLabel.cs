using TMPro;
using UnityEngine;

public class ComboLabel : MonoBehaviour
{
    private float timer = 3;

    // Start is called before the first frame update
    void Start()
    {
        var existingComboLabels = GameObject.FindGameObjectsWithTag("ComboLabel");
        foreach (var comboObject in existingComboLabels)
        {
            if(comboObject != gameObject)
            {
                if (comboObject.TryGetComponent<Transform>(out var comboLabelTransform))
                {
                    comboLabelTransform.position += new Vector3(0, 30, 0);
                }
                if (comboObject.TryGetComponent<TextMeshProUGUI>(out var comboLabelColor))
                {
                    var color = comboLabelColor.color;
                    color.a -= 0.15f;
                    comboLabelColor.color = color;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
